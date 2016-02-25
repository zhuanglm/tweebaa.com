//发送订单
function PushTrades{

var v_data = "{ action:'" + action
                    + "',id:'" + prdID
                    + "',prdName:'" + escape(prdName)
                    + "',prdCate:'" + escape(prdCate)
                    + "',prdAdvantage:'" + escape(prdAdvantage)
                    + "',prdAnswer:'" + escape(prdAnswer)
                    + "',prdContent:'" + escape(prdContent)
                    + "',prdPic:'" + escape(piclist)
                    + "',prdVideo:'" + escape(videoTemp)
                    + "',prdPrice:'" + escape(prdPrice)
                    + "',prdSupplyPrice:'" + escape(prdSupplyPrice)
                    + "',prdSupplyWay:'" + escape(prdSupplyWay)
                    + "',prdCompany:'" + escape(prdCompany)
                    + "',prdCompanyIndus:'" + escape(prdCompanyIndus)
                    + "',prdCompanyWeb:'" + escape(prdCompanyWeb) + "'}";
    $.ajax({
        type: "POST",
        url: 'http://testapi.iscs.com.cn/openapi/uriStr',
        data: v_data,    
        dataType: "text",
        success: function (resu) {         
          
        },
        error: function (XMLHttpRequest, textStatus, errorThrown) {           
            alert("保存失败");
        }
    });

}