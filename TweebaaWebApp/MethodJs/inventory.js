//产品基本信息
function ProBasicInfo(id, userid, proId, proName, proRight, proAddress, proExample, proExamplePrice, smallNum, proNum, stock, stockNum, state) {
    this.id = id == null ? "0" : id; //ID这里指数据表的主键
    this.userid = userid == null ? "" : userid; //用户 ID
    this.proid = proId == null ? "" : proId; //产品ID
    this.proright = proRight == null ? "" : proRight; //产权信息
    this.proaddress = proAddress == null ? "" : proAddress; //所在地
    this.proexample = proExample == null ? "" : proExample; //样品
    this.proexampleprice = proExamplePrice == null ? "" : proExamplePrice; //收费样品价格
    this.prosmallnum = smallNum == null ? "" : smallNum; //最小起定量
    this.promodelnum = proNum == null ? "" : proNum; //货号
    this.stock = stock == null ? "" : stock; //库存
    this.stocknum=stockNum == null ? "" : stockNum; //生产周期天数
    this.state = state==null?"0":state; //状态 
}
function getRadioValue(name){
   var k=$("label[name='"+name+"'][class='hRadio hRadio_Checked']").eq(0).attr("value");
   return k;
}
var _proid = $("#proId").attr("value");
function ProBasicInfoToJson() {
    var pro = new ProBasicInfo();
    pro.id = $("#probaseid").attr("value");
    pro.userid = $("#userId").attr("value");
    pro.proid = $("#proId").attr("value");
	
    pro.proright = getRadioValue('proRight');
	
    pro.proaddress = $("#proAddress").val();
    pro.proexample = getRadioValue('proExample');//'proExample']:checked").val();
    pro.proexampleprice = $("#proExamplePrice").val();
    pro.prosmallnum = $("#smallNum").val();
    pro.promodelnum = $("#proNum").val();
    pro.stock = getRadioValue('stock');//$("input[type='radio'][name='stock']:checked").val();
    pro.stocknum = $("#stockNum").val();
    var jsonString = $.toJSON(pro);
    return jsonString;
}
//产品规格信息
function ProRuleInfo(id, userid, proId, proruletitle, prorule, prostock, prosku, probulk, proweight, probox, prosize, proboxweight, procolor) {
    this.id = id == null ? "0" : id; //ID这里指数据表的主键
    this.userid = userid == null ? "" : userid; //用户 ID
    this.proid = proId == null ? "" : proId; //产品ID
    this.proruletitle = proruletitle == null ? "" : proruletitle; //规格类型
    this.prorule = prorule == null ? "" : prorule; //规格名称
    this.prostock = prostock == null ? "" : prostock; //库存
    this.prosku = prosku == null ? "" : prosku; //SUK
    this.probulk = probulk == null ? "" : probulk; //体积
    this.proweight = proweight == null ? "" : proweight; //重量
    this.probox=probox == null ? "" : probox; //装箱量
    this.prosize = prosize==null?"":prosize; //装箱尺寸
    this.proboxweight = proboxweight == null ? "" : proboxweight; //装箱重量
    this.procolor = procolor == null ? "" : procolor; //颜色
}


//产品详情以及仓储信息
function ProDetailOtherInfo(id,proid,userid,procaizhi,procaizhicontent,prosend,prosendarea,prostockout,prostockoutinfo,prosaleservice,prosaleserviceinfo) {
    this.id = id == null ? "" : id;
    this.userid = userid == null ? "" : userid; //用户 ID
    this.proid = proId == null ? "" : proId; //产品ID
    this.procaizhi = procaizhi == null ? "" : procaizhi; //材质
    this.procaizhicontent = procaizhicontent == null ? "" : procaizhicontent; //产品详情
    this.prosend = prosend == null ? "" : prosend; //是否提供一件代发
    this.prosendarea = prosendarea == null ? "" : prosendarea; //发货范围
    this.prostockout = prostockout == null ? "" : prostockout; //海外仓库
    this.prostockoutinfo = prostockoutinfo == null ? "" : prostockoutinfo; //海外仓库信息
    this.prosaleservice = prosaleservice == null ? "" : prosaleservice; //售后服务
    this.prosaleserviceinfo=prosaleserviceinfo == null ? "" : prosaleserviceinfo; //售后服务信息
}
function ProDetailOtherInfoToJson(){
    var pro = new ProDetailOtherInfo();
    pro.id = $("#proOtherId").val();
    pro.userid = $("#userId").attr("value");
    pro.proid = $("#proId").attr("value");
    pro.procaizhi =$("#procaizhi").val(); 
    pro.procaizhicontent = escape(editor.html()); 
    pro.prosend =getRadioValue('prosend'); //$("input[name='prosend'][type='radio']:checked").val();
    //var che = $("#chklist[tip='prosendarea']").find("input[type='checkbox']");
    var che = $("#chklist[tip='prosendarea']").find("label[class='checkbox checked']");
    var prosendareaStr = '';
    che.each(function () {
        prosendareaStr+= '_' + $(this).prev().eq(0).attr('value');
    });
	//che.each(function(){
	//   if($(this).attr("checked")=='checked'){
	//     prosendareaStr+='_'+$(this).attr('value');
	//   }
	//});
	if(prosendareaStr.length>0){
      pro.prosendarea = prosendareaStr.substring(1);
	}
    pro.prostockout = getRadioValue('prostockout');//$("input[name='prostockout'][type='radio']:checked").val();
    pro.prostockoutinfo = $("#prostockoutinfo").val();
    pro.prosaleservice = getRadioValue('prosaleservice');//$("input[name='prosaleservice'][type='radio']:checked").val();
	pro.prosaleserviceinfo = $("#prosaleserviceinfo").val();
    //alert($.toJSON(pro));
	return $.toJSON(pro);
}

function SendToServer(option) {
    if (verfy() == false)
        return;
    if (option != 'save') {
        if (!verfyInput()) {
            alert('Please fill in the item shall be recorded');
            return;
        }
    }
    var _action=$("#probaseid").val();
	var url='../AjaxPages/inventoryAjax.aspx?action=add';
	if(_action!="")
	   url='../AjaxPages/inventoryAjax.aspx?action=update';
    $.ajax({
        type: "Post",
        url: url,
        data: ProBasicInfoToJson()+ "§"+ProDetailOtherInfoToJson(),
        success: function (resu) {
            if (resu == 'add_success') {
                alert('send success');
                window.location.href = "../Product/prdReviewStep2.aspx?step=supply";
            }
			if(resu=='update_success')
			  alert('update success');
			if(resu=='add_fail')
			  alert('save fail');
			if(resu=='update_fail')
			  alert('update fail');
            //window.location.href = "../Product/preview.aspx?proid="+_proid;
        },
        error: function (obj) {
            alert(obj);
        }
    });
}

//验证事件
function verfy() {
    var reg = /^\d+(\.\d+)?$/;
   var pan=true;
   $("input[isnum='true']").each(function () {
       var text = $(this).val();
       if (text.length > 0 && !reg.test(text)) {
           $(this).focus().select().css('border-color', 'red');
           alert('some error in the red border');
           pan = false;
           return false;
       }
   });
   return pan;
}

function verfyInput() {
    var proRight = getRadioValue('proRight');
    if (proRight == null) {
        return false;
    }
    var proExample = getRadioValue('proExample');
    if (proExample == null)
        return false;
    var stock = getRadioValue('stock');
    if (stock == null)
        return false;
   
    var caizhi = $("#procaizhi").val();
    if (caizhi == '')
        return false;
    var prosend = getRadioValue('prosend');
    if (prosend == null)
        return false;
    var prosaleservice = getRadioValue('prosaleservice');
    if (prosaleservice == null)
        return false;

    return true;
}

//添加规格事件
function AddProRule() {
   var timestamp = new Date().getTime();
   var index=$("#ruleArea").find("div").length+timestamp;
   var htmlItem="<div class='js-eg-box' id='rule_"+index+"'>";
   htmlItem += "<input type=\"text\" id='ruleitem_" + index + "' onkeyup='RuleText(this)' class=\"txt\"  value=\"example：10*10*10cm\"  onfocus=\"if(this.value=='example：10*10*10cm')this.value='';this.style.color='#333'\" onblur=\"if(this.value==''){this.value='example：10*10*10cm';this.style.color='#ccc'}\"  />";
   //htmlItem += "<input type='text' id=ruleitemtext_" + index + " style='display:none;' /><a style=\"border:0;margin:0 0 0 3px\" align=\"absmiddle\" ><img style='cursor:pointer;' id=ruleitemimg_" + index + " src='../Images/color.png'/ onclick=iColorShow('ruleitemtext_" + index + "','ruleitemimg_" + index + "') />&nbsp;</a>";
   htmlItem += "<a href='javascript:void(0)' onclick='DeleteProRule(" + index + ")'>delete</a>";
   htmlItem+="</div>";
   $(htmlItem).appendTo($("#ruleArea")); //添加规格文本框

}

//添加规格行事件
function addRuleTr2() {
    var ruleTitle = $("#ruleArea").find("input[type='text']").length;
    if (ruleTitle == 0) {
        alert('please add specifications'); return;
    }
    var selectControl = "<select style='width:85px;' class='ruleSel'>";
    $("#ruleArea").find("input[type='text']").each(function () {
        var value = $(this).val();
        selectControl += "<option value=" + value + ">" + value + "</option>";
    });
    selectControl += "</select>";

    var index = new Date().getTime();
    //添加规格表格行
    var trItem = "<tr id='trrule'>";
    //trItem += "<td class=\"w120\"><input type='text' value='10*10*10cm' id='proruletitle' tips='-1' readonly='readonly' style='border:0px;' /></td>";
    trItem += "<td><input type='checkbox' class='chk' value=''/></td>";
    trItem += "<td>"+selectControl+"</td>";
    trItem += "<td><input type='text' class='procolor' id=ruleitemtext_" + index + " style='display:none;' /><a style=\"border:0;margin:0 0 0 3px\" align=\"absmiddle\" ><img style='cursor:pointer;' id=ruleitemimg_" + index + " src='../Images/color.png'/ onclick=iColorShow('ruleitemtext_" + index + "','ruleitemimg_" + index + "') />&nbsp;</a></td>";
    trItem += "<td><input type=\"text\" class='barcode' /></td>";
    trItem += "<td><input type=\"text\" class='stock' /></td>";
    trItem += "<td><input type=\"text\" class='prosku' /></td>";
    trItem += "<td><input type=\"text\" class='probulk'  /></td>";
    trItem += "<td><input type=\"text\"  class='proweight'  /></td>";
    trItem += "<td><input type=\"text\"  class='probox' /></td>";
    trItem += "<td><input type=\"text\" class='prosize' /></td>";
    trItem += "<td><input type=\"text\"  class='proboxweight'  /></td>";
    trItem += "<td><input type='button' style='cursor:pointer;' value='save' onclick='saveRule(this)' /></td>";
    trItem += "<td><input type='button' style='cursor:pointer;' value='range' class='price' onclick='openPrice(this)' disabled=disabled /></td>";
    trItem += "</tr>";
    $(trItem).appendTo($("#tbRule"));
}

//删除规格行事件
function ruleDeleteTr(obj) {
    $(obj).remove();
}
//删除规格行事件,复选删除
function deleteRuleTr2(){
   //加载规格ID
   var rule_ids="";
   $("#tbRule tr").find("input[class='chk']").each(function(){
      var _id=$(this).val();
	  if($(this).attr('checked')=="checked"){
		  if(_id!=null && _id.length>0){
			rule_ids+=','+_id;
		  }
		  $(this).parent().parent().remove();//删除这一行
	  }
   });
   if(rule_ids.length>0){
      rule_ids=rule_ids.substring(1);
	  var url="../AjaxPages/inventoryRuleSaveAjax.aspx?action=deleteRule";
	  var data="&ruleids="+rule_ids;
	  $.ajax({
        type: "Post",
        url: url,
        data:data,
        success: function (obj) {
            if(obj==-1)
			  alert('no data for delete');
			if(obj=='error')
			  alert('delete fail');
        },
        error: function (obj) {
            
        }
    });
   }
}

//保存规格行事件
function saveRule(obj) {
    var trObj = $(obj).parent().parent(); //获取当前行
	
	var ruleid=trObj.find("input[class='chk']").eq(0).val();
    var rule=trObj.find("select[class='ruleSel']").eq(0).val();
	var color=trObj.find("input[class='procolor']").eq(0).val();
	var barcode=trObj.find("input[class='barcode']").eq(0).val();
	var stock=trObj.find("input[class='stock']").eq(0).val();
	var prosku=trObj.find("input[class='prosku']").eq(0).val();
	var probulk=trObj.find("input[class='probulk']").eq(0).val();
	var proweight=trObj.find("input[class='proweight']").eq(0).val();
	var probox=trObj.find("input[class='probox']").eq(0).val();
	var prosize=trObj.find("input[class='prosize']").eq(0).val();
	var proboxweight=trObj.find("input[class='proboxweight']").eq(0).val();
	
	if(color==null || color=='') color='none';
	if (verfyNumber(stock) == false) { alert('Supply to Tweebaa input is wrong, It must be a number'); return; }
	//if (verfyNumber(probulk) == false) { alert('Volume input is wrong'); return; }
	//if(verfyNumber(proweight)==false){ alert('Products weight is wrong');return;}
	//if(verfyNumber(probox)==false){ alert('装箱量输入不正确');return;}
	//if(verfyNumber(prosize)==false){ alert('装箱尺寸输入不正确');return;}
	if (verfyNumber(proboxweight) == false) { alert('Carton weight input is wrong , It must be a number'); return; }
	if (verfySKU(prosku) == false) { alert('SKU enter duplicate'); return; }
	
	var proId=$("#pro_id_record").val();
	
	var url="../AjaxPages/inventoryRuleSaveAjax.aspx?action=saveRule";
	var data="&proid="+proId;
	data+="&ruleid="+ruleid;
	data+="&rule="+rule;
	data+="&color="+color;
	data+="&barcode="+barcode;
	data+="&stock="+stock;
	data+="&prosku="+prosku;
	data+="&probulk="+probulk;
	data+="&proweight="+proweight;
	data+="&probox="+probox;
	data+="&prosize="+prosize;
	data+="&proboxweight="+proboxweight;
	data+="&protitleid="+$("#cima").val();

	$.ajax({
	    type: "Post",
	    url: url,
	    data: data,
	    success: function (newid) {
	        //alert(newid);
	        //给复选框最新ID
	        trObj.find("input[class='chk']").eq(0).val(newid);
	        //生效价格区间按钮
	        trObj.find("input[class='price']").eq(0).removeAttr("disabled");
	        if ($("#hidBarcode").val() == '2') {
	            alert('save barcode success');
	        }
	    },
	    error: function (obj) {
	        if (obj == -1)
	            alert('please login');
	        if (obj == -2)
	            alert('bad request');
	        if (obj == -3)
	            alert('save specifications data fail');
	    }
	});

    
}

//打开价格区间
function openPrice(obj) { 
  //获取当前行
  var trObj=$(obj).parent().parent();
  //获取当前行的规格ID
  var _ruleId=trObj.find("input[type='checkbox']").eq(0).val();
  if(_ruleId==null || _ruleId=="")
   return;
   
  $("#pricedl").attr("tips",'').attr("tips",_ruleId);
  var url="../AjaxPages/inventoryRuleSaveAjax.aspx?action=getPrices";
  var data="&ruleid="+_ruleId;
  $.ajax({
        type: "Post",
        url: url,
        data:data,
        success: function (res) {
			GeneratePriceList(res);
			var eICP=getElementPos2(obj);
			  $("#divPrice").css({
					'top': eICP.y + ($(obj).outerHeight()) + "px",
					'left': (eICP.x)-410 + "px",
					'position': 'absolute',
					'zIndex':'9999'
				}).fadeIn("fast");
        },
        error: function (obj) {
            if(obj==-1)
                alert('please login');
			if(obj==-2)
			    alert('bad request');
			if(obj==-3)
			    alert('save range data fail');
        }
    });
  
}
//生成价格区间列表
function GeneratePriceList(res){
   $("#pricedl").html('');
   if(res=="-1") //表示没有数据
   {
      AddPriceArea(); //添加空价格行
   }
   else
   {
      var json=eval(res);
      $(json).each(function(index){
	    var val=json[index];
	    var from=val.countfrom;
		var to=val.countto;
		var price=val.price;

		var html="<dd>from<input type='text' id='pricefrom' class='livetxt' value='"+from+"' />";
		   html+="to<input type='text' id='priceto' class='livetxt'  value='"+to+"' />";
		   html+="$<input type='text' id='price' class='livetxt' value='"+price+"' />";
		   html+="<a href='javascript:void(0)' onclick='deletePriceArea(this)'>delete</a></dd>";
		$(html).appendTo($("#pricedl"));
	 });
   }
}

//保存价格区间
function SavePriceArea(){
   var ruleid=$("#pricedl").attr("tips");
   var proId=$("#pro_id_record").val();
   var str='';
   var pan=true;
   $("#pricedl").find("dd").each(function(){
       var from=$(this).find("input[id='pricefrom']").eq(0).val();
	   var to=$(this).find("input[id='priceto']").eq(0).val();
	   var price=$(this).find("input[id='price']").eq(0).val();
	   if(!verfyNumber(from) || !verfyNumber(to) || !verfyNumber(price)){
	      $(this).find("input[id='pricefrom']").eq(0).css('border-color','red');
		  $(this).find("input[id='priceto']").eq(0).css('border-color','red');
		  $(this).find("input[id='price']").eq(0).css('border-color','red');
		  pan=false;
		  return false;
	   }
	   var temp=from+'_'+to+'_'+price;
	   str+=','+temp;
   });
   if(str.length>0 && pan==true)
   {
      var data="&ruleid="+ruleid+"&proid="+proId+"&pricearea="+str.substring(1);
	  var url="../AjaxPages/inventoryRuleSaveAjax.aspx?action=savePrices";
	  $.ajax({
        type: "Post",
        url: url,
        data:data,
        success: function (res) {
			if(res=='success'){
			   $("#divPrice").fadeOut("fast");
			}else if(res=="error"){
			  alert('save fail');
			}else if(res==-1){
			  alert('some wrong at price range data');
			}
        },
        error: function (obj) {
            if(obj==-1)
                alert('please login');
			if(obj==-2)
			    alert('bad request');
			if(obj==-3)
			    alert('save range data fail');
        }
    });
   }
}

//验证数字
function verfyNumber(num){
   var reg = /^\d+(\.\d+)?$/;
   if(!reg.test(num))
      return false;
   else
      return true;
}
//验证SKU唯一性
function verfySKU(sku){
   if(sku==null || sku=="")
     return false;
   var count=0;
   $("#tbRule").find('tr').find("input[class='prosku']").each(function(){
      if($(this).val()==sku)
	    count++;
   });
   if(count>1)
     return false;
   else
     return true;
}

function addPriceTr2() {
    //添加价格表行
    var prItem = "<tr id='prrule'>";
    prItem += "<td class=\"w120\"><input type='text' value='10*10*10cm' id='proruletitle' tips='-1' class='t' readonly='readonly' style='border:0px;' /></td>";
    prItem += "<td class=\"w120 price\"><input type=\"text\" id='suggest' class=\"livetxt\" placeholder=\"count\"/></td>";
    prItem += "<td class=\"qujian\">";
    prItem += "<dl>";
    prItem += "<dd>从<input type=\"text\" id='pricefrom' isnum='true' class=\"livetxt\" placeholder=\"count\"/>到<input type=\"text\" id='priceto' isnum='true' class=\"livetxt\" placeholder=\"count\" />$<input type=\"text\" id='price' isnum='true' class=\"livetxt\" placeholder=\"price\"/> <a  class=\"add-eg l\"  onclick=AddPriceArea(this)>add</a></dd>";
    prItem += "</dl>";
    prItem += "</td>";
    prItem += "</tr>";
    $(prItem).appendTo($("#tbPrice"));
}


//添加行内价格区间
function AddPriceArea(){
   var html="<dd>from<input type='text' id='pricefrom' class='livetxt'  />";
   html+="to<input type='text' id='priceto' class='livetxt'   />";
   html+="$<input type='text' id='price' class='livetxt'  />";
   html+="<a href='javascript:void(0)' onclick='deletePriceArea(this)'>delete</a></dd>";
   $(html).appendTo($("#pricedl"));
}

//删除价格区间行
function deletePriceArea(obj){
   $(obj).parent().remove();
}

//Copy价格表区间
function CopyPriceArea(){
   $("#tbPrice tr td[class='qujian']").html('');
   $("#pricedl").clone().appendTo($("#tbPrice tr td[class='qujian']"));
}

//删除规格事件
function DeleteProRule(index){
   //删除当前行
    var ruleId = "rule_" + index;
    //var ruleItemId = "ruleitem_" + index;
    //var ruleItemValue = $("#" + ruleItemId).val();//获取规格值
   $("#"+ruleId).remove();
   //删除规格表格行
   /*
   $("#tbRule tr[id='trrule']").each(function () {
       var select = $(this).find('select').eq(0);
       var selectVal = $(select).val();
       if (selectVal == ruleItemValue) {
           $(this).remove();
       }
   });
     */}

//添加规格文本框onkeyup事件
function RuleText(obj){
   var text=$(obj).val();
   //规则名称不能重复
   var repeat=0;
   var pan=true;
   $("#ruleArea input").each(function(){
      var ruletemp=$(this).val();
	  if(ruletemp==text){
	    repeat++;
	  }
	  if(repeat>1){
	      alert('prompt message：specification can not be same');
		pan=false;
		return false;
	  }
   });
   if(pan==true){
   var index=$(obj).attr("id").split('_')[1];
	   //规格表格行
	   $("#trrule_"+index).find("td:first input[type='text']").val(text);
	   //价格表格行
	   $("#prrule_"+index).find("td:first input[type='text']").val(text);
   }
   
}

//改变规格事件[下拉事件]
$("#cima").change(function () {
    $("#ruleArea").empty();
    $("#tbRule tr[id!='tbHead']").remove();
	$("#tbPrice tr[id!='tpHead']").remove();
});

//产品规格录入
function btntxtInputFuc(_type){
   var stock=$("#btntxt"+_type).val();
   $("#tbRule tr td input[class='"+_type+"']").val(stock);
}



function getElementPos2(obj) {

    var ua = navigator.userAgent.toLowerCase();

    var isOpera = (ua.indexOf('opera') != -1);

    var isIE = (ua.indexOf('msie') != -1 && !isOpera); // not opera spoof

    var el =obj; //document.getElementById(elementId);



    if (el.parentNode === null || el.style.display == 'none') {

        return false;

    }





    var parent = null;

    var pos = [];

    var box;



    if (el.getBoundingClientRect)    //IE
    {

        box = el.getBoundingClientRect();

        var scrollTop = Math.max(document.documentElement.scrollTop, document.body.scrollTop);

        var scrollLeft = Math.max(document.documentElement.scrollLeft, document.body.scrollLeft);

        return { x: box.left + scrollLeft, y: box.top + scrollTop };

    }

    else if (document.getBoxObjectFor)    // gecko    
    {

        box = document.getBoxObjectFor(el);

        var borderLeft = (el.style.borderLeftWidth) ? parseInt(el.style.borderLeftWidth) : 0;

        var borderTop = (el.style.borderTopWidth) ? parseInt(el.style.borderTopWidth) : 0;

        pos = [box.x - borderLeft, box.y - borderTop];

    }

    else    // safari & opera    
    {

        pos = [el.offsetLeft, el.offsetTop];

        parent = el.offsetParent;



        if (parent != el) {

            while (parent) {

                pos[0] += parent.offsetLeft;

                pos[1] += parent.offsetTop;

                parent = parent.offsetParent;

            }

        }



        if (ua.indexOf('opera') != -1 || (ua.indexOf('safari') != -1 && el.style.position == 'absolute')) {

            pos[0] -= document.body.offsetLeft;

            pos[1] -= document.body.offsetTop;

        }

    }



    if (el.parentNode) {

        parent = el.parentNode;

    }

    else {

        parent = null;

    }



    while (parent && parent.tagName != 'BODY' && parent.tagName != 'HTML') { // account for any scrolled ancestors

        pos[0] -= parent.scrollLeft;

        pos[1] -= parent.scrollTop;



        if (parent.parentNode) {

            parent = parent.parentNode;

        }

        else {

            parent = null;

        }

    }



    return { x: pos[0], y: pos[1] };

}


















































