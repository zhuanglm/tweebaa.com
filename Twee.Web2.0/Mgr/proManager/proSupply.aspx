<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="proSupply.aspx.cs" Inherits="TweebaaWebApp2.Mgr.proManager.proSupply" %>

<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">

<html xmlns="http://www.w3.org/1999/xhtml">
<head id="Head1" runat="server">
 <title></title>
    <meta http-equiv="Content-Type" content="text/html;charset=UTF-8" />
    <meta http-equiv="X-UA-Compatible" content="IE=EmulateIE7" />
    <script src="../../js/util.js" type="text/javascript"></script>
    <script src="../../js/xd.js" type="text/javascript"></script>
     <script src="../../js/jquery.min.js" type="text/javascript"></script>
    <script src="../../js/jquery.placeholder2.js" type="text/javascript"></script>
    <script src="../../js/biaodan2.js" type="text/javascript"></script>
    <script src="../../js/selectCss.js" type="text/javascript"></script>
    <script type="text/javascript" src="../../js/newfloat.js"></script>
    <link href="../css/mgr.css" rel="stylesheet" />
    <link href="../css/aspnetpager.css" rel="stylesheet" />
    <link href="../ui/themes/default/easyui.css" rel="stylesheet" type="text/css" />
    <link href="../ui/themes/demo.css" rel="stylesheet" type="text/css" />
    <link href="../ui/themes/icon.css" rel="stylesheet" type="text/css" />
    <script src="../ui/jquery.min.js" type="text/javascript"></script>
    <script src="../ui/jquery.easyui.min.js" type="text/javascript"></script>
    <script src="../ui/easyloader.js" type="text/javascript"></script>
</head>
<body style="padding: 2px;">
    <form id="form1" runat="server">
    <table class="tbtable" style="width: 100%;">
        <tr>
            <td class="title" style="white-space: nowrap; text-align:left"> Product Guid</td>
            <td style="white-space: nowrap;"><asp:Label ID="lblProductGuid" runat="server" ></asp:Label></td>
        </tr>
        <tr>
            <td class="title" style="white-space: nowrap; text-align:left"> Product Name</td>
            <td style="white-space: nowrap;"><asp:Label ID="lblProductName" runat="server" ></asp:Label></td>
        </tr>
        <tr>
            <td class="title" style="white-space: nowrap; text-align:left"> Estimate Price</td>
            <td style="white-space: nowrap;"><asp:Label ID="lblEstimatePrice" runat="server" ></asp:Label></td>
        </tr>
        <tr>
            <td class="title" style="white-space: nowrap; text-align:left"> Sale Price</td>
            <td style="white-space: nowrap;"><asp:Label ID="lblSalePrice" runat="server" ></asp:Label></td>
        </tr>
        <tr>
            <td class="title" style="white-space: nowrap; text-align:left"> Min. Order Quantity</td>
            <td style="white-space: nowrap;"><asp:Label ID="lblMinimumOrderQuantity" runat="server" ></asp:Label></td>
        </tr>
        <tr>
            <td colspan="2">
              <a id="btn" href="#" class="easyui-linkbutton" onclick="DoAddSupply()">Add Supply</a> 
            </td>
        </tr>
    </table>
    <table class="tbtable" style="width: 100%;">
        <tr>
        <td><asp:GridView ID="gdvItem" runat="server" HeaderStyle-BackColor="#7FFFD4" 
                HeaderStyle-ForeColor="Black" AutoGenerateColumns="false" 
                onrowdatabound="gdvItem_RowDataBound"
                onselectedindexchanged="gdvItem_SelectedIndexChanged">
            <Columns>
                <asp:BoundField DataField="ruleid" HeaderText="ID" ItemStyle-Width="50" ItemStyle-HorizontalAlign="Center" />
                <asp:BoundField DataField="TweebaaSku" HeaderText="TweeBaa SKU" ItemStyle-Width="85" />
                <asp:BoundField DataField="SupplierSku" HeaderText="Supplier SKU" ItemStyle-Width="85" />
                <asp:BoundField DataField="SpecType" HeaderText="Spec Type" ItemStyle-Width="60" />
                <asp:BoundField DataField="SpecName" HeaderText="Spec Name" ItemStyle-Width="60" />
                <asp:BoundField DataField="Color" HeaderText="Color" ItemStyle-Width="60" />
                <asp:BoundField DataField="SalePrice" HeaderText="Sale Price" ItemStyle-Width="80" ItemStyle-HorizontalAlign="Right"  />
                <asp:BoundField DataField="WholesalePrice" HeaderText="Wholesale Price" ItemStyle-Width="80" ItemStyle-HorizontalAlign="Right"  />
                <asp:BoundField DataField="SupplierShipFee" HeaderText="Supplier Ship Fee" ItemStyle-Width="80" ItemStyle-HorizontalAlign="Right"  />
                <asp:BoundField DataField="Weight" HeaderText="Weight" ItemStyle-Width="60" ItemStyle-HorizontalAlign="Right"/>
                <asp:BoundField DataField="PackageLength" HeaderText="Package Length" ItemStyle-Width="60" ItemStyle-HorizontalAlign="Right"/>
                <asp:BoundField DataField="PackageWidth" HeaderText="Package Width" ItemStyle-Width="60" ItemStyle-HorizontalAlign="Right"/>
                <asp:BoundField DataField="PackageHeight" HeaderText="Package Height" ItemStyle-Width="60" ItemStyle-HorizontalAlign="Right"/>
                <asp:BoundField DataField="PackageWeight" HeaderText="Package Weight" ItemStyle-Width="60" ItemStyle-HorizontalAlign="Right"/>
                <asp:BoundField DataField="SupplierName" HeaderText="Supplier Name" ItemStyle-Width="100" />
                <asp:BoundField DataField="SupplierStatus" HeaderText="Supplier Status" ItemStyle-Width="60" ItemStyle-HorizontalAlign="Center"/>
                <asp:BoundField DataField="SupplierEmail" HeaderText="Supplier Email" ItemStyle-Width="100"/>
                <asp:TemplateField HeaderText="Edit" ItemStyle-HorizontalAlign="Center" ItemStyle-Width="60">
                    <ItemTemplate>
                        <input id="btnEdit" type="button" value="Edit"  onclick='DoEditSupply(<%# Eval("ruleid") %>)'/>
                    </ItemTemplate>
                </asp:TemplateField>
                <asp:TemplateField HeaderText="Delete" ItemStyle-HorizontalAlign="Center" ItemStyle-Width="60">
                    <ItemTemplate>
                        <asp:Button ID="btnDeleteItem" runat="server" Text="Delete"  RowIndex='<%# Container.DisplayIndex %>' CausesValidation="False" OnClick="btnDeleteItem_Click"
                        OnClientClick="javascript:return ConfirmDeleteItem();" />
                    </ItemTemplate>
                </asp:TemplateField>
            </Columns>
        </asp:GridView></td>
        </tr>
    </table>

    <div id="winAddSupply" title="Add Supply">

    <table class="tbtable" style="width:400px;">
        <tr>
            
            <td colspan="4" style="text-align:left" class="title">Copy From Tweebaa Sku #: 
            <input type="text" id="txtEditCopyFromTweebaaSKU" style="width:100px" maxlength="10"/>
            <a href="javascript:void(0)" onclick="DoCopySupply()" class="easyui-linkbutton">Copy</a>
            </td>
        </tr>
        <tr>
          <td colspan="4">
             <strong class="title">Supplier Email of Tweebaa Member:</strong> <input type="text" id="txtEditSupplierEmail" style="width:200px" maxlength="100"/>
             <strong class="title">Password: </strong><input type="password" id="txtEditSupplierPassword" style="width:100px" maxlength="100"/>
          </td>
        </tr>
        <tr>
            <td class="title">Tweebaa SKU: </td>
            <td><input type="text" id="txtEditTweebaaSKU" style="width:300px" maxlength="10" readonly/></td>
            <td class="title">Supplier SKU: </td>
            <td><input type="text" id="txtEditSupplierSKU" style="width:300px" maxlength="50"/></td>
        </tr>
        <tr>
            <td class="title">Spec Type: </td>
            <td><asp:HiddenField ID="hidEditSpecTypeID" runat="server" />
                <asp:DropDownList ID="ddlEditSpecType" runat="server" Width="120"></asp:DropDownList>
            </td>
            <td class="title">Spec Name: </td>
            <td><input type="text" id="txtEditSpecName" style="width:300px" maxlength="50" />
            </td>
        </tr>
        <tr>
            <td class="title">Sale Price: </td>
            <td><input type="text" id="txtEditSalePrice" maxlength="10" style="width:300px" /></td>
            <td class="title">Wholesale Price: </td>
            <td><input type="text" id="txtEditWholesalePrice" maxlength="10" style="width:300px" /></td>
        </tr>
        <tr>
            <td class="title">Supplier Ship Fee: </td>
            <td><input type="text" id="txtEditSupplierShipFee" maxlength="10" style="width:300px" /></td>
            <td class="title">Minimum Quantity: </td>
            <td><input type="text" id="txtEditMinQty" maxlength="5" style="width:300px" /></td>
        </tr>
        <tr>
            <td class="title">Color: </td>
            <td><input type="text" id="txtEditColor" maxlength="10" style="width:300px" /></td>
            <td class="title">Weight(lbs): </td>
            <td><input type="text" id="txtEditWeight" maxlength="10" style="width:300px" /></td>
        </tr>
        <tr>
            <td class="title">Package Weight(lbs): </td>
            <td><input type="text" id="txtEditPackageWeight" maxlength="10" style="width:300px" /></td>
            <td class="title">Package Length(inch): </td>
            <td><input type="text" id="txtEditPackageLength" maxlength="10" style="width:300px" /></td>
        </tr>
        <tr>
            <td class="title">Package Width(inch): </td>
            <td><input type="text" id="txtEditPackageWidth" maxlength="10" style="width:300px" /></td>
            <td class="title">Package Height(inch): </td>
            <td><input type="text" id="txtEditPackageHeight" maxlength="10" style="width:300px" /></td>
        </tr>
      </table>

      <br /><strong style="margin-left:5px">Ship To Country</strong>:
      <table id="tblShipToCountry" class="tbtable" style="width:400px;">
        <tr>
            <th>Select</th><th>Country</th><th>Free Shipping</th>
        </tr>
        <tr>
            <td><input id="Checkbox1" type="checkbox" /></td>
            <td>Country</td>
            <td><input id="Checkbox2" type="checkbox" /></td>
        </tr>
      </table>

      <br /><strong style="margin-left:5px">Ship From</strong>:
      <table class="tbtable" style="width:100%;">
        <tr>
            <td class="title">Supplier ID: </td>
            <td><input type="text" id="txtEditShipFromSupplierID" maxlength="10" style="width:100px" /></td>
            <td class="title">Company Name: </td>
            <td><input type="text" id="txtEditShipFromCompanyName" maxlength="100" style="width:180px" /></td>
            <td class="title">Contact Name: </td>
            <td><input type="text" id="txtEditShipFromContactName" maxlength="100" style="width:180px" /></td>
        </tr>
        <tr>
            <td class="title">Address: </td>
            <td colspan="3"><input type="text" id="txtEditShipFromAddress" maxlength="100" style="width:400px" /></td>
            <td class="title">Zip Code: </td>
            <td ><input type="text" id="txtEditShipFromZip" maxlength="10" style="width:180px" /></td>
        </tr>
        <tr>
            <td class="title">City: </td>
            <td><input type="text" id="txtEditShipFromCity" maxlength="100" style="width:180px" /></td>
            <td class="title">Country: </td>
            <td><asp:HiddenField ID="hidEditShipFromCountryID" runat="server" />
                <asp:DropDownList ID="ddlEditShipFromCountry" runat="server" Width="120"></asp:DropDownList>
            </td>
            <td class="title">Province: </td>
            <td><asp:HiddenField ID="hidEditShipFromProvinceID" runat="server" />
                <asp:DropDownList ID="ddlEditShipFromProvince" runat="server" Width="180"></asp:DropDownList>
            </td>
        </tr>
        <tr>
            <td class="title">Phone: </td>
            <td><input type="text" id="txtEditShipFromPhone" maxlength="16" style="width:100px" /></td>
            <td class="title">Email: </td>
            <td><input type="text" id="txtEditShipFromEmail" maxlength="100" style="width:180px" /></td>
            <td class="title">Web Site: </td>
            <td><input type="text" id="txtEditShipFromWebSite" maxlength="100" style="width:180px" /></td>
        </tr>
      </table>
      <br /><strong class="title" style="margin-left:5px">Ship Method</strong>: <input type="text" id="txtEditShipMethod" maxlength="50" style="width:250px" />

      <table >
        <tr>
            <td style="text-align:center" ><a href="javascript:void(0)" onclick="DoSave()" class="easyui-linkbutton">Save</a></td>
        </tr>
      </table>

    </div>
    
    <script type="text/javascript">

        var gsOperation = "";               // Edit or Add
        var giEditRuleID = 0;               // edit rules ID
        var gsEditSupplierUserGuid = "";    // supplier userid of the edit rule

        $(document).ready(function () {
        });

        $(function () {
            $('#winAddSupply').window({
                collapsible: false,
                minimizable: false,
                maximizable: false,
                left: 2,
                top: 10,
                modal: true
            });
            $('#winAddSupply').window('close');
     
        });
 
        function ConfirmDeleteItem() {
            if (!confirm("Are you sure you want to delete this item?")) return false;
            return true;
        }

        function DoAddSupply() {
            gsOperation = "Add";

            // get a new TweebaaSKU
            var sNewTweebaaSKU = TweebaaWebApp2.Mgr.proManager.proSupply.GetNewTweebaaSKU().value;
            $("#txtEditTweebaaSKU").val(sNewTweebaaSKU);

            // load spec type combobox
            LoadSpecType();

            // load ship to country
            LoadShipToCountry();

            // load ship from country
            LoadShipFromCountry();

            // load ship from province
            LoadShipFromProvince()

            // set Test data
            //SetTestData();

            // open popup            
            $('#winAddSupply').window('setTitle', 'Add Supply');
            $('#winAddSupply').window('open');
        }

        function LoadSpecType() {
            // load spec type combobox
            var sBlankSpecTypeID = "6";
            $("#ddlEditSpecType").combobox({
                valueField: 'SpecTypeID',
                textField: 'SpecTypeName',
                data: eval(TweebaaWebApp2.Mgr.proManager.proSupply.GetSpecTypeList().value),
                onSelect: function (e) {
                    $("#<%=hidEditSpecTypeID%>").val("").val(e.value);
                }
            });
            $("#ddlEditSpecType").combobox("setValue", sBlankSpecTypeID);    // set the current spec type to blank
        }

        function LoadShipToCountry() {
            // get country list
            var res = TweebaaWebApp2.Mgr.proManager.proSupply.GetCountryList();
            var obj = eval(res.value);
            //alert(res.value);
            //alert(obj.length);
            var sHtml = '<tr><th>Select</th><th>Country</th><th>Free Shipping</th></tr>';

            for (var i = 0; i < obj.length; i++) {
                // do not display "other" countries
                if (obj[i].id != 17) {
                    var sCountrySelected = "";
                    var sFreeShipSelected = "";
                    sHtml += '<tr>';
                    sHtml += '<td><input id="chkShipToCountry' + i.toString() + '"' + sCountrySelected + ' type="checkbox"  value="' + obj[i].id + '" /></td>';
                    sHtml += '<td>' + obj[i].country + '</td>';
                    sHtml += '<td><input id="chkShipToCountryFree' + i.toString() + '"' + sFreeShipSelected + ' type="checkbox" /></td>';
                    sHtml += '</tr>';
                }
            }
            $("#tblShipToCountry").html(sHtml);

        }

        function LoadShipFromCountry() {

            // load ship from country
            var sCurCountryID = "1"; // USA;
            $("#ddlEditShipFromCountry").combobox({
                valueField: 'id',
                textField: 'country',
                data: eval(TweebaaWebApp2.Mgr.proManager.proSupply.GetCountryList().value),
                onSelect: function (e) {
                    $("#<%=hidEditShipFromCountryID%>").val("").val(e.value);
                    LoadShipFromProvince();
                }
            });
            $("#ddlEditShipFromCountry").combobox("setValue", sCurCountryID);    // set the current country
        }

        function LoadShipFromProvince() {

            // load ship from country
            var sCurCountryID = $("#ddlEditShipFromCountry").combobox("getValue");
            //alert(sCurCountryID);
            var sCurProvinceID = "1"; 
            $("#ddlEditShipFromProvince").combobox({
                valueField: 'ProID',
                textField: 'ProName',
                data: eval(TweebaaWebApp2.Mgr.proManager.proSupply.GetProvinceList(sCurCountryID).value),
                onSelect: function (e) {
                    $("#<%=hidEditShipFromProvinceID%>").val("").val(e.value);
                }
            });
            //$("#ddlEditShipFromProvince").combobox("setValue", sDefaultProvinceID);    // set the current country
        }

        function CheckInput() {
            
            // supplier email
            var sSupplierEmail = $.trim($("#txtEditSupplierEmail").val());
            if (!IsEmail(sSupplierEmail)) {
                alert("Please enter a valid email of the supplier!");
                $("#txtEditSupplierEmail").focus();
                return false;
            }

            // supplier password
            var sSupplierPassword = $.trim($("#txtEditSupplierPassword").val());
            if (sSupplierPassword.length == 0) {
                alert("Please enter the password of the supplier!");
                $("#txtEditSupplierPassword").focus();
                return false;
            }

            // get the user guid of the supplier as tweebaa member
            var sSupplierUserGuid = GetSupplierUserGuid(sSupplierEmail, sSupplierPassword);
            if (sSupplierUserGuid.length == 0) {
                alert("Could not find the Tweebaa member!");
                $("#txtEditSupplierEmail").focus();
                return false;
            }

            // when edit the two supplier user id must be the same
            if (gsOperation == "Edit") {
                //alert(sSupplierUserGuid + " " + gsEditSupplierUserGuid);
                if (sSupplierUserGuid != gsEditSupplierUserGuid) {
                    alert("Tweebaa member is not the supplier of the edit item!");
                    $("#txtEditSupplierEmail").focus();
                    return false;
                }
            }


            // check Tweebaa SKU #  10 digits number
            var sTweebaaSKU = $.trim($("#txtEditTweebaaSKU").val());
            if (sTweebaaSKU.length !=10 || !IsNumber(sTweebaaSKU)) {
                alert("Please enter a valid Tweebaa SKU #!");
                $("#txtEditTweebaaSKU").focus();
                return false;
            }

            // check if Tweebaa SKU duplicated when add
            if ( gsOperation == "Add") {
                var sTweebaaSKUExist = TweebaaWebApp2.Mgr.proManager.proSupply.IsTweebaaSKUExist(sTweebaaSKU).value;
                if (sTweebaaSKUExist == "1") {
                    alert("Tweebaa SKU has alreay existed!");
                    $("#txtEditTweebaaSKU").focus();
                    return false;
                }
            }

            // check Supplier SKU #
            var sSupplierSKU = $.trim($("#txtEditSupplierSKU").val());
            if (sSupplierSKU.length ==0) {
                alert("Please enter the supplier SKU #!");
                $("#txtEditSupplierSKU").focus();
                return false;
            }

            // check spec type 
            /*
            var sSpecType = $("#ddlEditSpecType").combobox("getValue");
            if (sSpecType == "6" || sSpecType.length == 0) {
                alert("Please select the Spec Type!");
                $('#ddlEditSpecType').next().find('input').focus();
                return false;
            }

            // spec name
            var sSpecName = $.trim($("#txtEditSpecName").val());
            if (sSpecName.length == 0) {
                alert("Please enter the Spec Name!");
                $("#txtEditSpecName").focus();
                return false;
            }
            */

            // Sale price
            var sSalePrice = $.trim($("#txtEditSalePrice").val());
            if (!IsPositiveDecimal(sSalePrice)) {
                alert("Please enter a valid sale price!");
                $("#txtEditSalePrice").focus();
                return false;
            }

            // wholesale price
            var sWholesalePrice = $.trim($("#txtEditWholesalePrice").val());
            if (!IsPositiveDecimal(sWholesalePrice)) {
                alert("Please enter a valid wholesale price!");
                $("#txtEditWholesalePrice").focus();
                return false;
            }

            var dSalePrice = parseFloat(sSalePrice);
            var dWholesalePrice = parseFloat(sWholesalePrice);
            if (dSalePrice < dWholesalePrice) {
                alert("Sale price cannot be less than the wholesale price!");
                $("#txtEditSalePrice").focus();
                return false;
            }

            // Supplier Ship Fee
            var sSupplierShipFee = $.trim($("#txtEditSupplierShipFee").val());
            if (!IsPositiveDecimal(sSupplierShipFee)) {
                alert("Please enter a valid Supplier Ship Fee!");
                $("#txtEditSupplierShipFee").focus();
                return false;
            }

            // minimum quantity
            var sMinQty = $.trim($("#txtEditMinQty").val());
            if (!IsNumber(sMinQty)) {
                alert("Please enter a valid minimum quantity!");
                $("#txtEditMinQty").focus();
                return false;
            }

            // color
            var sColor = $.trim($("#txtEditColor").val());
            if (sColor.length == 0) {
                alert("Please enter the Color!");
                $("#txtEditColor").focus();
                return false;
            }

            // weight
            var sWeight = $.trim($("#txtEditWeight").val());
            if (!IsPositiveDecimal(sWeight)) {
                alert("Please enter a valid weight!");
                $("#txtEditWeight").focus();
                return false;
            }

            // package weight
            var sPackageWeight = $.trim($("#txtEditPackageWeight").val());
            if (!IsPositiveDecimal(sPackageWeight)) {
                alert("Please enter a valid package weight!");
                $("#txtEditPackageWeight").focus();
                return false;
            }

            // package length
            var sPackageLength = $.trim($("#txtEditPackageLength").val());
            if (!IsPositiveDecimal(sPackageLength)) {
                alert("Please enter a valid package length!");
                $("#txtEditPackageLength").focus();
                return false;
            }

            // package width
            var sPackageWidth = $.trim($("#txtEditPackageWidth").val());
            if (!IsPositiveDecimal(sPackageWidth)) {
                alert("Please enter a valid package width!");
                $("#txtEditPackageWidth").focus();
                return false;
            }

            // package width
            var sPackageHeight = $.trim($("#txtEditPackageHeight").val());
            if (!IsPositiveDecimal(sPackageHeight)) {
                alert("Please enter a valid package Height!");
                $("#txtEditPackageHeight").focus();
                return false;
            }

            // must have one country to ship 
            var i = 0;

            var bCountrySeleted = false;

            while (true) {
                var objCountry = $("#chkShipToCountry" + i.toString());
                var sCountryID = objCountry.val();
                if (sCountryID == undefined) break;
                var bCountrySelected = objCountry.is(":checked");

                if (bCountrySelected) {
                    bCountrySeleted = true;
                    break;
                }
                i = i + 1;
            }
            if (!bCountrySeleted) {
                alert("Please select ship to country!");
                $("#chkShipToCountry").focus();
                return false;
            }

            // ship from supplier ID  // first three characters of company name + 4 digitd + (D | W)
            var sShipFromSupplierID = $.trim($("#txtEditShipFromSupplierID").val());
            if (!IsSupplierID(sShipFromSupplierID)) {
                alert("Please enter a valid supplier ID!");
                $("#txtEditShipFromSupplierID").focus();
                return false;
            }

            // ship from company name
            var sShipFromCompanyName = $.trim($("#txtEditShipFromCompanyName").val());
            if (sShipFromCompanyName.length <3 ) {
                alert("Please enter the ship from company name (at least 3 characters)!");
                $("#txtEditShipFromCompanyName").focus();
                return false;
            }

            // first 3 characters must be the same as company name
            if (sShipFromSupplierID.substring(0, 3).toUpperCase() != sShipFromCompanyName.substring(0, 3).toUpperCase()) {
                alert("First 3 chars of supplier ID must be the same as the company name!");
                $("#txtEditShipSupplierID").focus();
                return false;
            }

            // ship from contact name
            var sShipFromContactName = $.trim($("#txtEditShipFromContactName").val());
            if (sShipFromContactName.length == 0) {
                alert("Please enter the ship from contact name!");
                $("#txtEditShipFromContactName").focus();
                return false;
            }

            // ship from address
            var sShipFromAddress = $.trim($("#txtEditShipFromAddress").val());
            if (sShipFromAddress.length == 0) {
                alert("Please enter the ship from address!");
                $("#txtEditShipFromAddress").focus();
                return false;
            }

            // ship from Zip
            var sShipFromZip = $.trim($("#txtEditShipFromZip").val());
            if (sShipFromZip.length == 0) {
                alert("Please enter the ship from ZIP code!");
                $("#txtEditShipFromZip").focus();
                return false;
            }

            // ship from City
            var sShipFromCity = $.trim($("#txtEditShipFromCity").val());
            if (sShipFromCity.length == 0) {
                alert("Please enter the ship from city!");
                $("#txtEditShipFromCity").focus();
                return false;
            }

            // ship from country
            var sShipFromCountry = $("#ddlEditShipFromCountry").combobox("getValue");
            if (sShipFromCountry.length == 0) {
                alert("Please select the ship from country!");
                $('#ddlEditShipFromCountry').next().find('input').focus();
                return false;
            }

            // ship from province
            var sShipFromProvince = $("#ddlEditShipFromProvince").combobox("getValue");
            //alert(sShipFromProvince);
            if (sShipFromProvince.length == 0) {
                alert("Please select the ship from province!");
                $('#ddlEditShipFromProvince').next().find('input').focus();
                return false;
            }

            // ship from phone
            var sShipFromPhone = $.trim($("#txtEditShipFromPhone").val());
            if (!IsPhone(sShipFromPhone) ) {
                alert("Please enter a valid ship from phone!");
                $('#txtEditShipFromPhone').focus();
                return false;
            }

            // ship from email
            var sShipFromEmail = $.trim($("#txtEditShipFromEmail").val());
            if (!IsEmail(sShipFromEmail)) {
                alert("Please enter a valid ship from email!");
                $('#txtEditShipFromEmail').focus();
                return false;
            }

            // ship from web site
            var sShipFromWebSite = $.trim($("#txtEditShipFromWebSite").val());
            if (sShipFromWebSite.length > 0) {
                if (!IsURL(sShipFromWebSite)) {
                    alert("Please enter a valid ship from web site!");
                    $('#txtEditShipFromWebSite').focus();
                    return false;
                }
            }

            // ship method
            var sShipMethod = $.trim($("#txtEditShipMethod").val());
            if (sShipMethod.length == 0){
                alert("Please enter the ship method!");
                $('#txtEditShipMethod').focus();
                return false;
            }


            //
            return true;
        }

        function DoSaveNewSupply() {
            // check input
            if (!CheckInput()) return false;

            var sPrdGuid = '<%=_sPrdGuid %>';

            // accept from input
            var sSupplierEmail = $.trim($("#txtEditSupplierEmail").val());
            var sSupplierPassword = $.trim($("#txtEditSupplierPassword").val());

            // get the user guid of the supplier as tweebaa member
            var sSupplierUserGuid = GetSupplierUserGuid(sSupplierEmail, sSupplierPassword);
            if (sSupplierUserGuid.length == 0) {
                alert("Could not find the Tweebaa member!");
                $("#txtEditSupplierEmail").focus();
                return false;
            }

            var sTweebaaSKU = $.trim($("#txtEditTweebaaSKU").val());
            var sSupplierSKU = $.trim($("#txtEditSupplierSKU").val());
            
            // check if Tweebaa SKU duplicated
            var sTweebaaSKUExist = TweebaaWebApp2.Mgr.proManager.proSupply.IsTweebaaSKUExist(sTweebaaSKU).value;
            if (sTweebaaSKUExist == "1") {
                alert("Tweebaa SKU has alreay existed!");
                $("#txtEditTweebaaSKU").focus();
                return false;
            }

            var sSpecType = $("#ddlEditSpecType").combobox("getValue");
            var sSpecName = $.trim($("#txtEditSpecName").val());
            var sSalePrice = $.trim($("#txtEditSalePrice").val());
            var sWholesalePrice = $.trim($("#txtEditWholesalePrice").val());
            var sSupplierShipFee = $.trim($("#txtEditSupplierShipFee").val());
            var sMinQty = $.trim($("#txtEditMinQty").val());
            var sColor = $.trim($("#txtEditColor").val());
            var sWeight = $.trim($("#txtEditWeight").val());
            var sPackageWeight = $.trim($("#txtEditPackageWeight").val());
            var sPackageLength = $.trim($("#txtEditPackageLength").val());
            var sPackageWidth = $.trim($("#txtEditPackageWidth").val());
            var sPackageHeight = $.trim($("#txtEditPackageHeight").val());
            // Ship To country
            var sShipToCountry = GetShipToCountryInput();
            var sShipFromSupplierID = $.trim($("#txtEditShipFromSupplierID").val());
            var sShipFromCompanyName = $.trim($("#txtEditShipFromCompanyName").val());
            var sShipFromContactName = $.trim($("#txtEditShipFromContactName").val());
            var sShipFromAddress = $.trim($("#txtEditShipFromAddress").val());
            var sShipFromZip = $.trim($("#txtEditShipFromZip").val());
            var sShipFromCity = $.trim($("#txtEditShipFromCity").val());
            var sShipFromCountry = $("#ddlEditShipFromCountry").combobox("getValue");
            var sShipFromProvince = $("#ddlEditShipFromProvince").combobox("getValue");
            var sShipFromPhone = $.trim($("#txtEditShipFromPhone").val());
            var sShipFromEmail = $.trim($("#txtEditShipFromEmail").val());
            var sShipFromWebSite = $.trim($("#txtEditShipFromWebSite").val());
            var sShipMethod = $.trim($("#txtEditShipMethod").val());


            var sRet = TweebaaWebApp2.Mgr.proManager.proSupply.SaveNewSupply(
                    sPrdGuid,
                    sSupplierEmail,
                    sSupplierPassword,
                    sSupplierUserGuid,
                    sTweebaaSKU,
                    sSupplierSKU,
                    sSpecType,
                    sSpecName,
                    sSalePrice,
                    sWholesalePrice,
                    sSupplierShipFee,
                    sMinQty,
                    sColor,
                    sWeight,
                    sPackageWeight,
                    sPackageLength,
                    sPackageWidth,
                    sPackageHeight,
                    sShipToCountry,
                    sShipFromSupplierID,
                    sShipFromCompanyName,
                    sShipFromContactName,
                    sShipFromAddress,
                    sShipFromZip,
                    sShipFromCity,
                    sShipFromCountry,
                    sShipFromProvince,
                    sShipFromPhone,
                    sShipFromEmail,
                    sShipFromWebSite,
                    sShipMethod
                 ).value;

            if (sRet == "1") {
                alert("Supply has been added successfully");
                location.reload();
            }
            else
                alert("Cannot add the the supply: " + sRet);
        }

        


        function GetSupplierUserGuid(sEmail, sPassword) {
            var sUserGuid = TweebaaWebApp2.Mgr.proManager.proSupply.GetUserGuid(sEmail, sPassword).value
            return sUserGuid;
        }



        function GetShipToCountryInput() {
            // return  like   "1 FREE, 3, 6, 8 FREE,18, ..."
            var sData = "";
            i = 0;
            while (true) {
                var objCountry = $("#chkShipToCountry" + i.toString());
                var sCountryID = objCountry.val();
                if (sCountryID == undefined) break;
                var bCountrySelected = objCountry.is(":checked");
                var bShipToCountryFree = $("#chkShipToCountryFree" + i.toString()).is(":checked");
                //alert(sCountryID + " " + bCountrySelected + " " + bShipToCountryFree);
                if (bCountrySelected) {
                    if (sData != "") sData = sData + ",";
                    sData = sData + sCountryID + " " + (bShipToCountryFree ? "FREE" : "");
                }
                i = i + 1;
            }
            return sData;
        }

        function IsEmail(s) {
            if (s.trim() == "") return false;
            var sEmailArr = s.split("@");
            if (sEmailArr.length != 2) return false;
            if (sEmailArr[0] == "" || sEmailArr[1] == "") return false;
            var sEmailDomainArr = sEmailArr[1].split(".");
            if (sEmailDomainArr.length <= 1) return false;
            for (var i = 0; i < sEmailDomainArr.length; i++) {
                if (sEmailDomainArr[i] == "") return false;
            }
            return true;
        }


        function IsNumber(s) {
            if (s.length == 0) return false;
            for (var i = 0; i < s.length; i++) {
                var c = s.substring(i, i + 1);
                if (c < "0" || c > "9") return false;
            }
            return true;
        }

        function IsPositiveDecimal(s) {
            if (s.length == 0) return false;
            for (var i = 0; i < s.length; i++) {
                var c = s.substring(i, i + 1);
                if ((c < "0" || c > "9") && c != "." && c != "-" && c != "+") return false;
            }

            var dVal = parseFloat(s);
            if (isNaN(dVal)) return false;

            if (dVal < 0) return false;

            return true;
        }

        function IsSupplierID(s) {
            // format XXX9999D  or  XXX9999W
            if (s.length != 8) return false;
            var sDigitPart = s.substring(3, 7);
            //alert(sDigitPart);
            //alert(s.substring(7, 8).toUpperCase());
            if (!IsNumber(sDigitPart)) return false;
            if (s.substring(7, 8).toUpperCase() != "D" && s.substring(7, 8).toUpperCase() != "W") return false; 
            return true;
        }

        function IsURL(s) {
            if (s.length == 0) return false;
            var regURL = new RegExp('^(http|https):\/\/[^ "]+$', 'i');
            return regURL.test(s);
        }

        function IsPhone(s) {
            if (s.length > 10 && IsNumber(s)) return true;
            var regPhone = /^\(\d{3}\) ?\d{3}( |-)?\d{4}|^\d{3}( |-)?\d{3}( |-)?\d{4}$/;
            return regPhone.test(s);
        }


        function SetTestData() {
            $("#txtEditSupplierEmail").val("lidecao@gmail.com");
            $("#txtEditSupplierPassword").val("cld912");
            $("#txtEditTweebaaSKU").val("0123456789");
            $("#txtEditSupplierSKU").val("9876543210");
            $("#ddlEditSpecType").combobox("setValue", "1");
            $("#txtEditSpecName").val("912");
            $("#txtEditSalePrice").val("10.99");
            $("#txtEditWholesalePrice").val("4.00");
            $("#txtEditMinQty").val("50");
            $("#txtEditColor").val("white");
            $("#txtEditWeight").val("10");
            $("#txtEditPackageWeight").val("9");
            $("#txtEditPackageLength").val("8");
            $("#txtEditPackageWidth").val("7");
            $("#txtEditPackageHeight").val("6");

            $("#txtEditShipFromSupplierID").val("XXX1234D");
            $("#txtEditShipFromCompanyName").val("XXXJack Test Company Inc.");
            $("#txtEditShipFromContactName").val("Jack Test.");
            $("#txtEditShipFromAddress").val("888 test address ave.");
            $("#txtEditShipFromCity").val("Toronto");
            $("#txtEditShipFromZip").val("X1X1X1");

            $("#txtEditShipFromPhone").val("1234567890");
            $("#txtEditShipFromEmail").val("lidecao@gmail.com");
            $("#txtEditShipFromWebSite").val("http://tweebaa.com");
            $("#txtEditShipMethod").val("Tweebaa Standard 2-10 Business Days");
            $("#txtEditCopyFromTweebaaSKU").val("7654321890");
        }

        function DoCopySupply() {
            var sPrdGuid = '<%=_sPrdGuid %>';
            var sCopyFromTweebaaSKU = $.trim($("#txtEditCopyFromTweebaaSKU").val());
            var sSKUInfo = ShowRuleInfo(sPrdGuid, sCopyFromTweebaaSKU);

            if (sSKUInfo != "[]") {
                obj = eval(sSKUInfo)[0];
                ShowShipFromCountry(obj.id);  
                ShowShipFromInfo(obj.ShipFrom_ID);
                //ShowShipMethod(obj.ShipFrom_ID);
            }

        }

        function ShowRuleInfo(sPrdGuid, sTweebaaSKU) {
            var sSKUInfo = TweebaaWebApp2.Mgr.proManager.proSupply.GetRuleInfo(sPrdGuid, sTweebaaSKU).value;
            if (sSKUInfo == "[]") {
                alert("Tweebaa SKU #:" + sTweebaaSKU + " of this product does not exist!");
                return sSkuInfo;
            }
            var obj = eval(sSKUInfo)[0];
            //alert(sSKUInfo);
            //$("#txtEditTweebaaSKU").val(obj.prosku);
            if (obj.suppliersku     != null) $("#txtEditSupplierSKU").val(obj.suppliersku);
            if (obj.proruletitle    != null) $("#ddlEditSpecType").combobox("setValue", obj.proruletitle);
            if (obj.prorule         != null) $("#txtEditSpecName").val(obj.prorule);
            
            var sRuleSalePrice  = TweebaaWebApp2.Mgr.proManager.proSupply.GetRuleSalePrice(obj.id, 1).value;
            $("#txtEditSalePrice").val(sRuleSalePrice);
            if (obj.WholesalePrice  != null) $("#txtEditWholesalePrice").val(obj.WholesalePrice);
            if (obj.prostock        != null) $("#txtEditMinQty").val(obj.prostock);
            if (obj.SupplierShipFee != null) $("#txtEditSupplierShipFee").val(obj.SupplierShipFee);
            if (obj.color           != null) $("#txtEditColor").val(obj.color);
            if (obj.proweight       != null) $("#txtEditWeight").val(obj.proweight);
            if (obj.PackageWeight   != null) $("#txtEditPackageWeight").val(obj.PackageWeight);
            if (obj.PackageLength   != null) $("#txtEditPackageLength").val(obj.PackageLength);
            if (obj.PackageWidth    != null) $("#txtEditPackageWidth").val(obj.PackageWidth);
            if (obj.PackageHeight   != null) $("#txtEditPackageHeight").val(obj.PackageHeight);
            if (obj.SupplierShipMethodName != null) $("#txtEditShipMethod").val(obj.SupplierShipMethodName);

            return sSKUInfo;
        }

        function ShowShipFromInfo(iShipFromID) {
            var sShipFromInfo = TweebaaWebApp2.Mgr.proManager.proSupply.GetShipFromInfo(iShipFromID).value;
            if (sShipFromInfo == "[]") {
                alert("Ship From ID#:" + iShipFromID + " does not exist!");
                return sShipFromInfo;
            }
            var obj = eval(sShipFromInfo)[0];
            //alert(sShipFromInfo);
            // Ship from
            if (obj.Supplier_ID          != null) $("#txtEditShipFromSupplierID").val(obj.Supplier_ID);
            if (obj.ShipFrom_CompanyName != null) $("#txtEditShipFromCompanyName").val(obj.ShipFrom_CompanyName);
            if (obj.ShipFrom_ContactName != null) $("#txtEditShipFromContactName").val(obj.ShipFrom_ContactName);
            if (obj.ShipFrom_Address1    != null) $("#txtEditShipFromAddress").val(obj.ShipFrom_Address1);
            if (obj.ShipFrom_City        != null) $("#txtEditShipFromCity").val(obj.ShipFrom_City);
            if (obj.ShipFrom_Zip         != null) $("#txtEditShipFromZip").val(obj.ShipFrom_Zip);
            if (obj.Country_ID           != null) $("#ddlEditShipFromCountry").combobox("setValue", obj.Country_ID);
            if (obj.Province_ID          != null) $("#ddlEditShipFromProvince").combobox("setValue", obj.Province_ID);
            if (obj.ShipFrom_Phone       != null) $("#txtEditShipFromPhone").val(obj.ShipFrom_Phone);
            if (obj.ShipFrom_Email       != null) $("#txtEditShipFromEmail").val(obj.ShipFrom_Email);
            if (obj.ShipFrom_WebSite     != null) $("#txtEditShipFromWebSite").val(obj.ShipFrom_WebSite);

            return sShipFromInfo;
        }

        function DoSave() {

            if (gsOperation == "Add") {
                DoSaveNewSupply();
            }
            else if (gsOperation == "Edit") {
                DoUpdateSupply();
            }
            
        }

        function ShowShipFromCountry(sRuleID) {

            // get spec type list
            var res = TweebaaWebApp2.Mgr.proManager.proSupply.GetSKUShipToCountryList(sRuleID);
            var obj = eval(res.value);
            //alert(res.value);
            //alert(obj.length);
            var sHtml = '<tr><th>Select</th><th>Country</th><th>Free Shipping</th></tr>';

            for (var i = 0; i < obj.length; i++) {
                // do not display "other" countries
                if (obj[i].id != 17) {
                    var sCountrySelected = obj[i].selected == "1" ? " checked " : "";
                    var sFreeShipSelected = obj[i].ProductShipToCountry_IsFree == "1" ? " checked " : "";
                    sHtml += '<tr>';
                    sHtml += '<td><input id="chkShipToCountry' + i.toString() + '"' + sCountrySelected + ' type="checkbox"  value="' + obj[i].id + '" /></td>';
                    sHtml += '<td>' + obj[i].country + '</td>';
                    sHtml += '<td><input id="chkShipToCountryFree' + i.toString() + '"' + sFreeShipSelected + ' type="checkbox" /></td>';
                    sHtml += '</tr>';
                }
            }
            $("#tblShipToCountry").html(sHtml);
        }

        function DoEditSupply(iRuleID) {
     
            if (!confirm("Are you sure you want to edit this item?")) return false;

            gsOperation = "Edit";
            giEditRuleID = iRuleID;
                   
            // load spec type combobox
            LoadSpecType();

            // load ship to country
            LoadShipToCountry();

            // load ship from country
            LoadShipFromCountry();

            // load ship from province
            LoadShipFromProvince()

            var sPrdGuid = '<%=_sPrdGuid %>';
            var sTweebaaSKU = TweebaaWebApp2.Mgr.proManager.proSupply.GetTweebaaSKU(iRuleID).value;
            var sSKUInfo = ShowRuleInfo(sPrdGuid, sTweebaaSKU);
            var sSupplierUserGuid = TweebaaWebApp2.Mgr.proManager.proSupply.GetSupplierUserGuid(iRuleID).value;
            gsEditSupplierUserGuid = sSupplierUserGuid;

            $("#txtEditTweebaaSKU").val(sTweebaaSKU);

            if (sSKUInfo != "[]") {
                obj = eval(sSKUInfo)[0];
                ShowShipFromCountry(obj.id);
                ShowShipFromInfo(obj.ShipFrom_ID);
                //ShowShipMethod(obj.ShipFrom_ID);
            }

            // open popup
            $('#winAddSupply').window('setTitle', 'Edit Supply');
            $('#winAddSupply').window('open');

            return false;
        }


        function DoUpdateSupply() {
            if (!CheckInput()) return false;
            var sPrdGuid = '<%=_sPrdGuid %>';

            // accept from input
            var sSupplierEmail = $.trim($("#txtEditSupplierEmail").val());
            var sSupplierPassword = $.trim($("#txtEditSupplierPassword").val());

            // get the user guid of the supplier as tweebaa member
            var sSupplierUserGuid = GetSupplierUserGuid(sSupplierEmail, sSupplierPassword);
            if (sSupplierUserGuid.length == 0) {
                alert("Could not find the Tweebaa member!");
                $("#txtEditSupplierEmail").focus();
                return false;
            }

            var sTweebaaSKU = $.trim($("#txtEditTweebaaSKU").val());
            var sSupplierSKU = $.trim($("#txtEditSupplierSKU").val());
            var sSpecType = $("#ddlEditSpecType").combobox("getValue");
            var sSpecName = $.trim($("#txtEditSpecName").val());
            var sSalePrice = $.trim($("#txtEditSalePrice").val());
            var sWholesalePrice = $.trim($("#txtEditWholesalePrice").val());
            var sSupplierShipFee = $.trim($("#txtEditSupplierShipFee").val());
            var sMinQty = $.trim($("#txtEditMinQty").val());
            var sColor = $.trim($("#txtEditColor").val());
            var sWeight = $.trim($("#txtEditWeight").val());
            var sPackageWeight = $.trim($("#txtEditPackageWeight").val());
            var sPackageLength = $.trim($("#txtEditPackageLength").val());
            var sPackageWidth = $.trim($("#txtEditPackageWidth").val());
            var sPackageHeight = $.trim($("#txtEditPackageHeight").val());
            // Ship To country
            var sShipToCountry = GetShipToCountryInput();
            var sShipFromSupplierID = $.trim($("#txtEditShipFromSupplierID").val());
            var sShipFromCompanyName = $.trim($("#txtEditShipFromCompanyName").val());
            var sShipFromContactName = $.trim($("#txtEditShipFromContactName").val());
            var sShipFromAddress = $.trim($("#txtEditShipFromAddress").val());
            var sShipFromZip = $.trim($("#txtEditShipFromZip").val());
            var sShipFromCity = $.trim($("#txtEditShipFromCity").val());
            var sShipFromCountry = $("#ddlEditShipFromCountry").combobox("getValue");
            var sShipFromProvince = $("#ddlEditShipFromProvince").combobox("getValue");
            var sShipFromPhone = $.trim($("#txtEditShipFromPhone").val());
            var sShipFromEmail = $.trim($("#txtEditShipFromEmail").val());
            var sShipFromWebSite = $.trim($("#txtEditShipFromWebSite").val());
            var sShipMethod = $.trim($("#txtEditShipMethod").val());
 
            var sRet = TweebaaWebApp2.Mgr.proManager.proSupply.UpdateSupply(
                    giEditRuleID,
                    sPrdGuid,
                    sSupplierEmail,
                    sSupplierPassword,
                    sSupplierUserGuid,
                    sTweebaaSKU,
                    sSupplierSKU,
                    sSpecType,
                    sSpecName,
                    sSalePrice,
                    sWholesalePrice,
                    sSupplierShipFee,
                    sMinQty,
                    sColor,
                    sWeight,
                    sPackageWeight,
                    sPackageLength,
                    sPackageWidth,
                    sPackageHeight,
                    sShipToCountry,
                    sShipFromSupplierID,
                    sShipFromCompanyName,
                    sShipFromContactName,
                    sShipFromAddress,
                    sShipFromZip,
                    sShipFromCity,
                    sShipFromCountry,
                    sShipFromProvince,
                    sShipFromPhone,
                    sShipFromEmail,
                    sShipFromWebSite,
                    sShipMethod
                 ).value;

            if (sRet == "1") {
                alert("Supply has been updated successfully");
                location.reload();
            }
            else
                alert("Cannot update the supply: " + sRet);
          
            
            return true;
        }
    </script>
    </form>
</body>
</html>
