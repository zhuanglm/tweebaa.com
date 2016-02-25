
$(document).ready(
   function () {
       var Request = new Object();
       Request = GetRequest();
       type = Request["type"];
       if (type == null || type == "" || type == "undefined") {
           type = "";
           $("#labType").text("All");
       }
       $("#labType").text(type);
       loadCount();
       loadMeinv();
   });

   var page = 1;
   var recordCount = 0;
   var pageCount = 0;
   var type = "";

   function Serch() {
       if (type!="") {
           window.location.href = "../Home/HomeShareDetail.aspx?type=" + type;

       }
       else {
           window.location.href = "../Home/HomeShareDetail.aspx";
       }
       
   }
   function SetState(shareType) {
       if (shareType == -1 || type == null || type == "" || type == "undefined") {
           type = "";
           $("#labType").text("All");          
       }
       else {
           type = shareType;
           $("#labType").text(type);
       }      
   }

//获取总记录数、页数
   function loadCount() {
       var begTime = $("#txtBegin").val();
       var endTime = $("#txtEnd").val();
       $.ajax({
           type: "Post",
           url: "../AjaxPages/shareAjax.aspx",
           data: "{'action':'queryhomecount','type':'" + type + "','begTime':'" + begTime + "','endTime':'" + endTime + "'}",
           success: function (resu) {
               if (resu == "") {
                   return;
               }
               var arry = new Array();
               arry = resu.split(",");
               recordCount = arry[0];
               pageCount = arry[1];
               $("#labCount").text("(" + recordCount + " Records)");
               kkpager.generPageHtml({
                   lang: {
                       firstPageText: 'First',
                       firstPageTipText: 'First',
                       lastPageText: 'Last',
                       lastPageTipText: 'Last',
                       prePageText: 'Prev',
                       prePageTipText: 'Prev',
                       buttonTipBeforeText: 'Page ',
                       buttonTipAfterText: '',
                       nextPageText: 'Next',
                       nextPageTipText: 'Next'
                   }
                   ,
                   pno: 1,
                   total: pageCount, //总页码
                   //总数据条数
                   totalRecords: recordCount,
                   mode: 'click', //默认值是link，可选link或者click
                   click: function (n) {
                       page = n;
                       loadMeinv();
                       this.selectPage(n); //手动选中按钮
                       return false;
                   }
               });
           },
           error: function (obj) {
               // alert("Load failed");
           }
       });
     
   }

function loadMeinv() {    
    $("#tableShare").empty();   
    $("#tableShare").append('<tr><th>Date</th><th>Product Name</th><th>Promote Via </th><th> Visits</th><th> Buyers</th><th>Income Amount($)</th><th> Copy Share Link</th></tr>');
    var beginTime = $("#txtBegin").val();
    var endTime = $("#txtEnd").val();

    var order = "";
    $.ajax({
        type: "Post",
        url: "../AjaxPages/shareAjax.aspx",
        data: "{'action':'query','type':'" + type
                    + "','beginTime':'" + beginTime
                    + "','endTime':'" + endTime
                    + "','order':'" + order
                    + "','page':'" + page
                    + "'}",
        success: function (resu) {
            if (resu == "") {
                return;
            }
            var timeTemp;
            var obj = eval("(" + resu + ")");
            for (var i = 0; i < obj.length; i++) {
                var prd = obj[i];
                var prdid = "'" + prd.prdguid + "'";
                var mymoney = prd.mymoney;
                if (mymoney == null) {
                    mymoney = 0;
                }
                var time = prd.addtime.replace(/-/g, '/').substring(0, 10);
                var state = prd.wnstat;
                var prdUrl = "../Product/submitReview.aspx?id=" + prd.prdguid;
                var copyText = "'" + prd.shareurl + "'";
                if (state == 0) {
                    prdUrl = "../Product/prdReview.aspx?id=" + prd.prdguid;
                }
                if (state == 2) {
                    prdUrl = "../Product/presaleBuy.aspx?id=" + prd.prdguid;
                }
                if (state == 3) {
                    prdUrl = "../Product/saleBuy.aspx?id=" + prd.prdguid;
                }
                var html = "";
                html += '<tr><td>' + time + '</td>'
                        + '<td style="width:30%;">' + prd.name + '</td>'
                        + '<td>' + prd.sharetype + '</td>'
                        + '<td>' + prd.visitcount + '</td>'
                        + '<td>' + prd.successcount + '</td>'
                        + '<td>' + mymoney + '</td>'
                        + '<td style="width:130px;" ><input type="button"  class="submit simple"  style="color:white;border:none;width:50px;height:20px;" value="Copy" onclick="CopyToClip(' + copyText + ')" /></td></tr>';
                $("#tableShare").append(html);
            }
            //$("#tableShare").append("</tbody>");
            uniteTable("tableShare", 1);
        },
        error: function (obj) {
            //alert("Load failed");
        }
    });

}


function GetRequest() {
    var url = location.search;
    var theRequest = new Object();
    if (url.indexOf("?") != -1) {
        var str = url.substr(1);
        strs = str.split("&");
        for (var i = 0; i < strs.length; i++) {
            theRequest[strs[i].split("=")[0]] = (strs[i].split("=")[1]);
        }
    }
    return theRequest;
}


function CopyToClip(txtCopy) {
    var input = document.createElement('textarea');
    document.body.appendChild(input);
    input.value = txtCopy;
    input.focus();
    input.select();
    document.execCommand('Copy');

    var userAgent = navigator.userAgent;
    if (userAgent.indexOf('Chrome') > 0) {
        input.remove();
    }
    else {
        input.style.display = "none";
        //.hide();
    }
    alert("Share link has been copied to the clipboard.");
}

function uniteTable(tableId, colLength) {
    //colLength-- 需要合并单元格的列 1开始 
    var tb = document.getElementById(tableId);
    tb.style.display = '';
    var i = 0;
    var j = 0;
    var rowCount = tb.rows.length; //   行数  
    var colCount = tb.rows[0].cells.length; //   列数  
    var obj1 = null;
    var obj2 = null;
    //为每个单元格命名  
    for (i = 0; i < rowCount; i++) {
        for (j = 0; j < colCount; j++) {
            tb.rows[i].cells[j].id = "tb__" + i.toString() + "_" + j.toString();
        }
    }
    //合并行  
    for (i = 0; i < colCount; i++) {
        if (i == colLength) break;
        obj1 = document.getElementById("tb__0_" + i.toString())
        for (j = 1; j < rowCount; j++) {
            obj2 = document.getElementById("tb__" + j.toString() + "_" + i.toString());
            if (obj1.innerText == obj2.innerText) {
                obj1.rowSpan++;
                obj2.parentNode.removeChild(obj2);
            } else {
                obj1 = document.getElementById("tb__" + j.toString() + "_" + i.toString());
            }
        }
    }
    //    //合并列 
    //    for (i = 0; i < rowCount; i++) {
    //        colCount = tb.rows[i].cells.length;
    //        obj1 = document.getElementById(tb.rows[i].cells[0].id);
    //        for (j = 1; j < colCount; j++) {
    //            if (j >= colLength) break;
    //            if (obj1.colSpan >= colLength) break;

    //            obj2 = document.getElementById(tb.rows[i].cells[j].id);
    //            if (obj1.innerText == obj2.innerText) {
    //                obj1.colSpan++;
    //                obj2.parentNode.removeChild(obj2);
    //                j = j - 1;
    //            }
    //            else {
    //                obj1 = obj2;
    //                j = j + obj1.rowSpan;
    //            }
    //        }
    //    }
}