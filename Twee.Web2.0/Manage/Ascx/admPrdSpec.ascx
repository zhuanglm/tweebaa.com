﻿<%@ Control Language="C#" AutoEventWireup="true" CodeBehind="admPrdSpec.ascx.cs" Inherits="TweebaaWebApp2.Manage.Ascx.admPrdSpec" %>
<script src="../js/jquery-1.7.2.min.js" type="text/javascript"></script>
<script type="text/javascript">

    function addRow2(obj) {
        var rowIndex = obj.parentNode.parentNode.rowIndex;
        //var resrow = document.getElementById(id);
        var resrow = document.getElementById("table2").rows[rowIndex];
        rowIndex--;
        var newRow = resrow.cloneNode(true); //document.createElement("tr");  

        var parent = resrow.parentNode;
        if (parent.lastChild == resrow) {
            //如果targetElement是parent最后一个子元素，插入newElement  
            parent.appendChild(newRow);
        } else {
            //如果不是，插入到targetElement下一个兄弟节点的前面  
            parent.insertBefore(newRow, resrow.nextSibling);
        }

        var inputObj = newRow.getElementsByTagName("input");
        //inputObj[0].value = newRow.find("#task_type").value;
        inputObj[2].value = newRow.find("#txtSpcName").value;
        inputObj[3].value = newRow.find("#txtSpcValue").value;
        inputObj[3].value = newRow.find("#txtIDX").value;

        inputObj[inputObj.length - 2].style.display = "";
        inputObj[inputObj.length - 1].style.display = "none";
    }
    function deleRow2(obj) {
        var rootTable = document.getElementById("table2");
        rootTable.deleteRow(obj.parentNode.parentNode.rowIndex);

    }
    function getData2() {
        var strData = "";
        var strColor = "";
        var resrows = document.getElementById("table2").rows;
        var ckbList = $(".ckbclass");
        for (var i = 1; i < resrows.length; i++) {
            var inputObj = resrows[i].getElementsByTagName("input");
            // strData += inputObj[3].value + "," + inputObj[4].value + "," + inputObj[inputObj.length - 3].value + "," + inputObj[inputObj.length - 2].value + "," + inputObj[inputObj.length - 1].value + ";";
            strData += inputObj[3].value + "," + inputObj[4].value + "," + inputObj[inputObj.length - 1].value + ";";

            var ckb = ckbList[i - 1];
            // alert(ckbList.length);
            var str = CheckValue(ckb);
            strColor += str + ";";
            //  strData += inputObj[2].value + "," + inputObj[3].value + "," + inputObj[4].value + "," + inputObj[5].value + ";";
            //alert(inputObj.length);
            // alert(inputObj[3].value);
            //alert(inputObj[4].value);
            //alert(inputObj[inputObj.length - 1].value);


        }
        var txt = document.getElementById('<%=txtData2.ClientID%>');
        txt.value = strData;
        var txtColor = document.getElementById('<%=txtColor.ClientID%>');
        txtColor.value = strColor;
        //  alert(strColor);

    }
    function CheckValue(obj) {
        //在JS端调用CheckBoxList

        var chkObject = obj;
        var chkInput = chkObject.getElementsByTagName("input");

        // alert("a" + chkInput.length);
        // var arrListValue = chkObject.listvalue.split(',');
        var arrListValue = chkObject.attributes.getNamedItem("listvalue").nodeValue.split(',');
        //alert("aaaaaaaaaaaaaaaaaa:" + arrListValue);
        var count = arrListValue.length;
        //alert("count:"+count);
        var strCheckChecked = "";
        var arrCheckChecked;
        var chkValue = "";

        //每次点击CheckBoxList的一个Item，都循环把所有Item的选中状态按0、1标志，存入一个变量，最后再根据这个标志来决定checkboxlist中要取的值

        for (var i = 0; i < chkInput.length; i++) {
            if (chkInput[i].checked) {
                strCheckChecked = strCheckChecked + "1" + ",";
            }
            else {
                strCheckChecked = strCheckChecked + "0" + ",";
            }
        }
        // alert("strCheckChecked:" + strCheckChecked);
        arrCheckChecked = RTrim(strCheckChecked).split(',');
        //alert("bbbb:");
        for (var j = 0; j < count; j++) {
            //alert(count);
            if (arrCheckChecked[j] == "1") {
                chkValue += arrListValue[j] + ",";
                // alert(chkValue);
            }
        }
        chkValue = RTrim(chkValue);
        return chkValue;

    }

    //如果有则移除末尾的逗号
    function RTrim(str) {
        if (str.charAt(str.length - 1) == ",")
            return str.substring(0, str.length - 1);
        else
            return str;
    }

    //    function onchecked(v, flag) {
    //        if (flag == true) {
    //            if (document.getElementById("txtColor").value == "") {
    //                document.getElementById("txtColor").value = v;
    //            } else {
    //                document.getElementById("txtColor").value += "," + v;
    //            }
    //        }
    //    }

</script>
<input type="hidden" id="txtData2" runat="server" />
<input type="hidden" id="txtColor" runat="server" />
<asp:UpdatePanel runat="server" ID="UpdatePanel1">
    <ContentTemplate>
<table cellspacing="0" cellpadding="0" border="0" class="tableStyle">
   <%-- <tr>
        <td style="height: 40px; text-align: left;">
            规格名称：
        </td>
        <td style="text-align: left;">
            <asp:TextBox ID="txtName" CssClass="input_tx" runat="server" Width="300px"></asp:TextBox>
        </td>
    </tr>
    <tr>
        <td style="height: 40px; text-align: left;">
            规格备注：
        </td>
        <td style="text-align: left;">
        </td>
    </tr>--%>
    <tr>
        <td>
            <table id="table2" cellpadding="2" cellspacing="0" border="1">
                <thead>
                    <tr>
                        <th width="18%">
                            操作
                        </th>
                        <th width="10%">
                            规格名称
                        </th>
                        <th width="10%">
                            规格值
                        </th>
                        <th width="40%">
                            选择颜色
                        </th>
                       <%--  <th width="8%">
                            价格
                        </th>
                        <th width="8%">
                            库存
                        </th>--%>
                        <th>
                            排序
                        </th>
                    </tr>
                </thead>
                <tbody>
                    <asp:Repeater ID="repPrice" runat="server" OnItemDataBound="repPrice_DataBound" >
                        <ItemTemplate>
                            <tr id="workDay">
                                <td>
                                    <input type="button" id="dele2" onclick="deleRow2(this)" value="删除" class="btnSerch" />
                                    <input type="button" id="add2" onclick="addRow2(this)" value="添加" class="btnSerch" />
                                    <input type="hidden" id="hidID" value='<%#Eval("specguid") %>' />
                                </td>
                                <td>
                                    <input class="input_tx" id="txtSpcName" type="text" runat="server" value='<%#Eval("specname") %>' style=" width:100px;" />
                                </td>
                                <td>
                                    <input class="input_tx" id="txtSpcValue" type="text" runat="server" value='<%#Eval("specvalue") %>' style=" width:100px;" />
                                </td>
                                <td>
                                    <%-- <input class="input_tx" id="txtSpeColor" type="text" runat="server" value='<%#Eval("colorname") %>' />--%>
                                    <asp:CheckBoxList ID="ckbColor2"  runat="server" RepeatColumns="4" RepeatDirection="Horizontal"
                                        CellPadding="10" CssClass="ckbclass">
                                    </asp:CheckBoxList>                                
                                  
                                </td>
                               <%--  <td>
                                    <input class="input_tx" id="txtPrice" type="text" runat="server" value='<%#Eval("price") %>' style=" width:80px;" />
                                </td>
                                 <td>
                                    <input class="input_tx" id="txtNumber" type="text" runat="server" value='<%#Eval("number") %>' style=" width:80px;" />
                                </td>--%>
                                <td>
                                    <input class="input_tx" id="txtIDX" type="text" runat="server" value='<%#Eval("idx") %>' style=" width:50px;" /> 
                                </td>
                            </tr>
                        </ItemTemplate>
                    </asp:Repeater>
                </tbody>
            </table>
        </td>
    </tr>
    <tr>
        <td style="text-align: center;">
            <asp:Button ID="btnAdd" runat="server" CssClass="btnSerch" Text="保存" OnClientClick="getData2()" OnClick="btnSave_Click" />
        </td>
    </tr>
</table>
   </ContentTemplate>
</asp:UpdatePanel>