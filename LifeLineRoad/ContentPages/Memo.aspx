<%@ Page Title="" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true"
    CodeBehind="Memo.aspx.cs" Inherits="LifeLineRoad.ContentPages.Challan" %>

<%@ Register Assembly="AjaxControlToolkit" Namespace="AjaxControlToolkit" TagPrefix="asp" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
    <script type="text/javascript">
        $(function () {
            $('#datetimepicker5').datetimepicker({
                format: 'dd/mm/yyyy',
                minView: 'month',
                autoclose: true
            });
        });

        function GetID_Consignee(source, eventArgs) {
            var HdnKey = eventArgs.get_value();
            document.getElementById('<%=hfConsigneeId.ClientID %>').value = HdnKey;
        };

        function GetID_Vehicle(source, eventArgs) {
            var HdnKey = eventArgs.get_value();
            document.getElementById('<%=hfVehicleId.ClientID %>').value = HdnKey;
        };

    </script>
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <asp:UpdatePanel ID="UpdatePanelError" runat="server" UpdateMode="Always">
        <ContentTemplate>
            <asp:Panel ID="pnlMessage" runat="server" class="alert alert-danger" role="alert">
                <asp:Label ID="lblErrorMsg" runat="server" Text=""></asp:Label>
            </asp:Panel>
        </ContentTemplate>
    </asp:UpdatePanel>

    <div class="panel panel-default">
        <div class="panel-heading">
            Memo
        </div>
        <div class="panel-body">
            <div class="row">
                <div class="col-md-8">
                    <div class="form-horizontal">
                        <div class="form-group">
                            <label for="inputEmail3" class="col-sm-4 control-label">
                                Memo No</label>
                            <div class="col-sm-2">
                                <asp:TextBox ID="txtMemoNo" class="form-control input-sm" runat="server" ReadOnly="true" ></asp:TextBox>
                            </div>
                            <label for="inputEmail3" class="col-sm-2 control-label">
                                Date</label>
                            <div class="col-sm-4">
                                <div class="input-group input-group-sm date" id="datetimepicker5">
                                    <asp:TextBox ID="txtDate" class="form-control" runat="server"></asp:TextBox>
                                    <span class="input-group-addon"><span class="glyphicon glyphicon-remove"></span>
                                    </span><span class="input-group-addon"><span class="glyphicon glyphicon-calendar"></span>
                                    </span>
                                </div>
                            </div>
                        </div>
                        <div class="form-group">
                            <label for="inputEmail3" class="col-sm-4 control-label">
                                M/s.
                            </label>
                            <div class="col-sm-8">
                                <asp:UpdatePanel ID="UpdatePanel1" runat="server" UpdateMode="Conditional">
                                    <ContentTemplate>
                                        <asp:TextBox ID="txtCompanyName" class="form-control input-sm" runat="server" MaxLength="50"
                                            AutoPostBack="true" OnTextChanged="txtCompanyName_TextChanged"></asp:TextBox>
                                        <div id="completionList1" style="height: 200px; overflow: auto;">
                                        </div>
                                        <asp:AutoCompleteExtender ID="AutoCompleteExtender1" runat="server" CompletionInterval="100"
                                            ServicePath="~/WebServices/ConsigneesList.asmx" ServiceMethod="ConsigneeNameList"
                                            CompletionSetCount="1" EnableCaching="true" MinimumPrefixLength="1" TargetControlID="txtCompanyName"
                                            CompletionListElementID="completionList1" OnClientItemSelected="GetID_Consignee">
                                        </asp:AutoCompleteExtender>
                                        <asp:HiddenField ID="hfConsigneeId" runat="server" />
                                        <asp:HiddenField ID="hfConsigneeIdSave" runat="server" />
                                    </ContentTemplate>
                                </asp:UpdatePanel>
                            </div>
                        </div>
                        <div class="form-group">
                            <label for="inputEmail3" class="col-sm-4 control-label">
                                Vehicle No.
                            </label>
                            <div class="col-sm-8">
                                <asp:UpdatePanel ID="UpdatePanel2" runat="server" UpdateMode="Conditional">
                                    <ContentTemplate>
                                        <asp:TextBox ID="txtVehicleNo" class="form-control input-sm" runat="server" MaxLength="50"
                                            AutoPostBack="true" OnTextChanged="txtVehicleNo_TextChanged"></asp:TextBox>
                                        <div id="completionList2" style="height: 200px; overflow: auto;">
                                        </div>
                                        <asp:AutoCompleteExtender ID="AutoCompleteExtender2" runat="server" CompletionInterval="100"
                                            ServicePath="~/WebServices/VehiclesList.asmx" ServiceMethod="VehicleNoList" CompletionSetCount="1"
                                            EnableCaching="true" MinimumPrefixLength="1" TargetControlID="txtVehicleNo" CompletionListElementID="completionList2"
                                            OnClientItemSelected="GetID_Vehicle">
                                        </asp:AutoCompleteExtender>
                                        <asp:HiddenField ID="hfVehicleId" runat="server" />
                                        <asp:HiddenField ID="hfVehicleIdSave" runat="server" />
                                    </ContentTemplate>
                                </asp:UpdatePanel>
                            </div>
                        </div>
                        <div class="form-group">
                            <label for="inputEmail3" class="col-sm-4 control-label">
                                Loading
                            </label>
                            <div class="col-sm-4">
                                <asp:TextBox ID="txtPickupLoc" class="form-control input-sm" runat="server" MaxLength="100"
                                    placeholder="Pick-up Location"></asp:TextBox>
                            </div>
                            <div class="col-sm-4">
                                <asp:TextBox ID="txtDropLoc" class="form-control input-sm" runat="server" MaxLength="100"
                                    placeholder="Drop Location"></asp:TextBox>
                            </div>
                        </div>
                        <div class="form-group">
                            <label for="inputEmail3" class="col-sm-4 control-label">
                                Weight</label>
                            <div class="col-sm-3">
                                <asp:TextBox ID="txtWeight" class="form-control input-sm" runat="server" MaxLength="10"></asp:TextBox>
                                <asp:FilteredTextBoxExtender ID="FilteredTextBoxExtender1" runat="server" TargetControlID="txtWeight"
                                    FilterType="Numbers,Custom" ValidChars=".">
                                </asp:FilteredTextBoxExtender>
                            </div>
                        </div>
                        <div class="form-group">
                            <label for="inputEmail3" class="col-sm-4 control-label">
                                Hire Fixed Rs.</label>
                            <div class="col-sm-8">
                                <asp:TextBox ID="txtHireFixedAmt" class="form-control input-sm" runat="server" MaxLength="12"></asp:TextBox>
                                <asp:FilteredTextBoxExtender ID="FilteredTextBoxExtender2" runat="server" TargetControlID="txtHireFixedAmt"
                                    FilterType="Numbers,Custom" ValidChars=".">
                                </asp:FilteredTextBoxExtender>
                            </div>
                        </div>
                        <div class="form-group">
                            <label for="inputEmail3" class="col-sm-4 control-label">
                                Advance Rs.</label>
                            <div class="col-sm-8">
                                <asp:TextBox ID="txtAdvanceAmt" class="form-control input-sm" runat="server" MaxLength="255"></asp:TextBox>
                                <asp:FilteredTextBoxExtender ID="FilteredTextBoxExtender3" runat="server" TargetControlID="txtAdvanceAmt"
                                    FilterType="Numbers,Custom" ValidChars=".">
                                </asp:FilteredTextBoxExtender>
                            </div>
                        </div>
                        <div class="form-group">
                            <label for="inputEmail3" class="col-sm-4 control-label">
                                Balance Rs.</label>
                            <div class="col-sm-8">
                                <asp:TextBox ID="txtBalanceAmt" class="form-control input-sm" runat="server" MaxLength="255"></asp:TextBox>
                                <asp:FilteredTextBoxExtender ID="FilteredTextBoxExtender4" runat="server" TargetControlID="txtBalanceAmt"
                                    FilterType="Numbers,Custom" ValidChars=".">
                                </asp:FilteredTextBoxExtender>
                            </div>
                        </div>
                        <div class="form-group">
                            <label for="inputEmail3" class="col-sm-4 control-label">
                                Balance At</label>
                            <div class="col-sm-8">
                                <asp:TextBox ID="txtBalanceAt" class="form-control input-sm" runat="server" MaxLength="255"></asp:TextBox>
                            </div>
                        </div>
                        <div class="form-group">
                            <div class="col-sm-offset-4 col-sm-10">
                                <asp:Button ID="btnSave" runat="server" Text="Save" class="btn btn-primary btn-sm"
                                    OnClick="btnSave_Click" ValidationGroup="save" />
                                <asp:Button ID="btnClear" runat="server" Text="Clear" class="btn btn-default btn-sm"
                                    OnClick="btnClear_Click" />
                                <asp:Button ID="btnList" runat="server" Text="List" class="btn btn-warning btn-sm"
                                    OnClick="btnList_Click" />
                            </div>
                        </div>
                    </div>
                </div>
                <div class="col-md-4">
                    <div class="form-horizontal">
                        <div class="form-group">
                            <div class="col-sm-12">
                                <label class="val-required-pad">
                                    <asp:RequiredFieldValidator ID="RequiredFieldValidator1" runat="server" ErrorMessage="Date is mandatory."
                                        ControlToValidate="txtDate" CssClass="val-required" SetFocusOnError="true" Display="Dynamic"
                                        ValidationGroup="save"></asp:RequiredFieldValidator>
                                </label>
                            </div>
                        </div>
                        <div class="form-group">
                            <div class="col-sm-12">
                                <label class="val-required-pad">
                                    <asp:RequiredFieldValidator ID="RequiredFieldValidator2" runat="server" ErrorMessage="Consignee is mandatory."
                                        ControlToValidate="txtCompanyName" CssClass="val-required" SetFocusOnError="true"
                                        Display="Dynamic" ValidationGroup="save"></asp:RequiredFieldValidator>
                                </label>
                            </div>
                        </div>
                        <div class="form-group">
                            <div class="col-sm-12">
                                <label class="val-required-pad">
                                    <asp:RequiredFieldValidator ID="RequiredFieldValidator3" runat="server" ErrorMessage="Vehicle No. is mandatory."
                                        ControlToValidate="txtVehicleNo" CssClass="val-required" SetFocusOnError="true"
                                        Display="Dynamic" ValidationGroup="save"></asp:RequiredFieldValidator>
                                </label>
                            </div>
                        </div>
                        <div class="form-group">
                            <div class="col-sm-12">
                            </div>
                        </div>
                        <div class="form-group">
                            <div class="col-sm-12">
                            </div>
                        </div>
                        <div class="form-group">
                            <div class="col-sm-12">
                            </div>
                        </div>
                    </div>
                </div>
            </div>
        </div>
    </div>
</asp:Content>
