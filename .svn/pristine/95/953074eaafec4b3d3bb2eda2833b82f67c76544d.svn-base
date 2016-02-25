<%@ Control Language="C#" AutoEventWireup="true" CodeBehind="admPrdBaseInfo.ascx.cs" Inherits="TweebaaWebApp.Manage.Ascx.admPrdBaseInfo" %>
<script type="text/javascript">

    function addRow1(obj) {
        var rowIndex = obj.parentNode.parentNode.rowIndex;
        //var resrow = document.getElementById(id);
        var resrow = document.getElementById("table1").rows[rowIndex];
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
        //newRow.innerHTML=resrow.innerHTML;  
        //var selectObjOld = resrow.getElementsByTagName("select");
        //var selectObj = newRow.getElementsByTagName("select");           
        //var selectIndex = selectObjOld[0].selectedIndex;          
        //selectObj[0].options[selectIndex].selected = true;


        var inputObj = newRow.getElementsByTagName("input");
        inputObj[2].value = newRow.find("#txtCount1").value;
        inputObj[3].value = newRow.find("#txtCount1").value;
        inputObj[4].value = newRow.find("#txtPrice").value;


        inputObj[inputObj.length - 2].style.display = "";
        inputObj[inputObj.length - 1].style.display = "none";
    }
    function deleRow1(obj) {
        var rootTable = document.getElementById("table1");
        rootTable.deleteRow(obj.parentNode.parentNode.rowIndex);

    }
    function getData1() {
        var strData = "";
        var resrows = document.getElementById("table1").rows;
        for (var i = 1; i < resrows.length; i++) {
            var inputObj = resrows[i].getElementsByTagName("input");
            strData += inputObj[2].value + "," + inputObj[3].value + "," + inputObj[4].value + ";";
        }
        var txt = document.getElementById('<%=txtData.ClientID%>');
        txt.value = strData;
        //alert(strData);
        //document.getElementById("txtData").value = strData;
        //alert(document.getElementById("txtData").value);

    }

    
</script>
<input type="hidden" id="txtData" runat="server" />
<asp:UpdatePanel runat="server" ID="UpdatePanel1">
    <ContentTemplate>
        <table cellspacing="0" cellpadding="0" border="0" class="tableStyle">
            <tr>
                <td style="height: 40px; text-align: left;">
                    产品名称：
                </td>
                <td style="text-align: left;">
                    <%--<input class="input_tx" id="txtName" enableviewstate="true" type="text" runat="server" />--%>
                    <asp:TextBox ID="txtName" CssClass="input_tx" runat="server" Width="300px"></asp:TextBox>
                </td>
            </tr>
            <tr>
                <td style="height: 40px; text-align: left;">
                    所属分区：
                </td>
                <td style="text-align: left;">
                    <%-- <select name="pid" id="parType" runat="server"  style=" width:237px;">                        
                    </select>--%>
                    <asp:DropDownList ID="ddlType" runat="server" Width="150px">
                        <asp:ListItem Value="1">评审区</asp:ListItem>
                        <asp:ListItem Value="2">预售区</asp:ListItem>
                        <asp:ListItem Value="3">销售区</asp:ListItem>
                        <asp:ListItem Value="-1">屏蔽</asp:ListItem>
                    </asp:DropDownList>
                </td>
            </tr>
            <tr>
                <td style="height: 40px; text-align: left;">
                    产品类别：
                </td>
                <td style="text-align: left;">
                    <asp:DropDownList ID="ddlType1" runat="server" Width="150px" AutoPostBack="true"
                        OnSelectedIndexChanged="ddlType1_SelectedIndexChanged">
                    </asp:DropDownList>
                    <asp:DropDownList ID="ddlType2" runat="server" Width="150px">
                    </asp:DropDownList>
                    <span>不修改类别，默认不选择</span>
                </td>
            </tr>
            <tr>
                <td style="height: 40px; text-align: left;">
                    价格：
                </td>
                <td style="text-align: left;">
                    <%--  cellpadding="2" cellspacing="0" border="1"--%>
                    <table id="table1" cellpadding="2" cellspacing="0" border="1">
                        <thead>
                            <%--style="font-size: 13px;"--%>
                            <tr>
                                <%--style="background: #E1F4F9"--%>
                                <th>
                                    操作
                                </th>
                                <th>
                                    购买数量区间
                                </th>
                                <th>
                                    价格
                                </th>
                            </tr>
                        </thead>
                        <tbody>
                            <asp:Repeater ID="repPrice" runat="server">
                                <ItemTemplate>
                                    <tr id="workDay">
                                        <td>
                                            <input type="button" id="dele1" onclick="deleRow1(this)" value="删除" class="btnSerch" />
                                            <input type="button" id="add1" onclick="addRow1(this)" value="添加" class="btnSerch" />
                                        </td>
                                        <td>
                                            <input class="input_tx" id="txtCount1" type="text" runat="server" value='<%#Eval("p1") %>' />--
                                            <input class="input_tx" id="txtCount2" type="text" runat="server" value='<%#Eval("p2") %>' />
                                        </td>
                                        <td>
                                            <input class="input_tx" id="txtPrice" type="text" runat="server" value='<%#Eval("price") %>' />
                                        </td>
                                    </tr>
                                </ItemTemplate>
                            </asp:Repeater>
                        </tbody>
                    </table>
                </td>
            </tr>
            <tr>
                <td style="height: 40px; text-align: left;">
                    颜色：
                </td>
                <td style="text-align: left;">
                    <br />
                    <asp:CheckBoxList ID="ckbColor" runat="server" RepeatColumns="3" RepeatDirection="Horizontal"
                        CellPadding="10">
                    </asp:CheckBoxList>
                </td>
            </tr>
            <%-- <tr>
        <td style="height: 40px; text-align: left;">
            规格：
        </td>
        <td style="text-align: left;">
            <br />
            <asp:CheckBoxList ID="CheckBoxList1" runat="server" RepeatColumns="3" RepeatDirection="Horizontal"
                CellPadding="10">
            </asp:CheckBoxList>
        </td>
    </tr>--%>
            <%--<tr>
                    <td style="height: 40px;">
                        排序：
                    </td>
                    <td>
                    </td>
                </tr>--%>
            <tr>
                <td colspan="2" style="text-align: center;">
                    <asp:Button ID="btnAdd" runat="server" Text="保存"  CssClass="btnSerch" OnClientClick="getData1()" OnClick="btnSave_Click" />

                </td>
            </tr>
        </table>
    </ContentTemplate>
</asp:UpdatePanel>
