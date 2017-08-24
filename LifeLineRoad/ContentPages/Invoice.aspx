<%@ Page Title="" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true"
    CodeBehind="Invoice.aspx.cs" Inherits="LifeLineRoad.ContentPages.Invoice" %>

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

        $(function () {
            $('#datetimepicker6').datetimepicker({
                format: 'dd/mm/yyyy',
                minView: 'month',
                autoclose: true
            });
        });

        $(function () {
            $('#datetimepicker7').datetimepicker({
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
    <script type="text/javascript">
        function calculate_amount() {

            var freight = document.getElementById('<%= txtFrieght.ClientID %>').value;
            var advance = document.getElementById('<%= txtAdvance.ClientID %>').value;
            var balance = document.getElementById('<%= txtBalance.ClientID %>').value;
            var toPay = document.getElementById('<%= txtToPay.ClientID %>').value;
            var hamali = document.getElementById('<%= txtHamali.ClientID %>').value;
            var detention = document.getElementById('<%= txtDetention.ClientID %>').value;
            var otherCharge = document.getElementById('<%= txtOtherCharge.ClientID %>').value;
            var netAmount = document.getElementById('<%= txtNetAmount.ClientID %>').value;

            var _freight = 0, _advance = 0, _balance = 0, _toPay = 0, _hamali = 0, _detention = 0, _otherCharge = 0, _netAmount = 0;

            if (freight != '') {
                _freight = parseFloat(freight);
            }

            if (advance != '') {
                _advance = parseFloat(advance);
            }

            if (balance != '') {
                _balance = parseFloat(balance);
            }

            if (toPay != '') {
                _toPay = parseFloat(toPay);
            }

            if (hamali != '') {
                _hamali = parseFloat(hamali);
            }

            if (detention != '') {
                _detention = parseFloat(detention);
            }

            if (otherCharge != '') {
                _otherCharge = parseFloat(otherCharge);
            }

            var totalAmount = _freight + _advance + _balance + _toPay + _hamali + _detention + _otherCharge;
            console.log(totalAmount);


            $('#<%= txtNetAmount.ClientID %>').val(totalAmount);
        }
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
            Invoice
        </div>
        <div class="panel-body">
            <div class="row">
                <div class="col-md-3">
                    <div class="form-group form-inline">
                        <label for="exampleInputEmail1">
                            Bill No &nbsp; &nbsp;</label>
                        <asp:TextBox ID="txtBillNo" class="form-control input-sm" runat="server" ReadOnly="true"></asp:TextBox>
                    </div>
                </div>
                <div class="col-md-5">
                </div>
                <div class="col-md-4">
                    <div class="form-group form-inline text-right">
                        <label for="exampleInputEmail1">
                            Date &nbsp; &nbsp;</label>
                        <div class="input-group input-group-sm date" id="datetimepicker5">
                            <asp:TextBox ID="txtDate" class="form-control" runat="server"></asp:TextBox>
                            <span class="input-group-addon"><span class="glyphicon glyphicon-remove"></span>
                            </span><span class="input-group-addon"><span class="glyphicon glyphicon-calendar"></span>
                            </span>
                        </div>
                    </div>
                </div>
            </div>
            <div class="row">
                <div class="col-md-4">
                    <div class="form-group form-inline">
                        <label for="exampleInputEmail1">
                            M/s. &nbsp; &nbsp;</label>
                        <asp:UpdatePanel ID="UpdatePanel1" runat="server" UpdateMode="Conditional" style="display: inline;">
                            <ContentTemplate>
                                <asp:TextBox ID="txtCompanyName" class="form-control input-sm" runat="server" MaxLength="50"
                                    AutoPostBack="true" OnTextChanged="txtCompanyName_TextChanged" Width="85%"></asp:TextBox>
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
                <div class="col-md-4">
                    <div class="form-group form-inline">
                        <label for="exampleInputEmail1">
                            From &nbsp; &nbsp;</label>
                        <asp:TextBox ID="txtPickupLoc" class="form-control input-sm" runat="server" MaxLength="100"
                            placeholder="Pick-up Location" Width="85%"></asp:TextBox>
                    </div>
                </div>
                <div class="col-md-4">
                    <div class="form-group form-inline">
                        <label for="exampleInputEmail1">
                            To &nbsp; &nbsp;</label>
                        <asp:TextBox ID="txtDropLoc" class="form-control input-sm" runat="server" MaxLength="100"
                            placeholder="Drop Location" Width="85%"></asp:TextBox>
                    </div>
                </div>
            </div>
            <div class="row">
                <div class="col-md-4">
                    <div class="form-group form-inline">
                        <label for="inputEmail3">
                            Truck No. &nbsp; &nbsp;</label>
                        <asp:UpdatePanel ID="UpdatePanel2" runat="server" UpdateMode="Conditional" style="display: inline;">
                            <ContentTemplate>
                                <asp:TextBox ID="txtVehicleNo" class="form-control input-sm" runat="server" MaxLength="50"
                                    AutoPostBack="true" OnTextChanged="txtVehicleNo_TextChanged" Width="70%"></asp:TextBox>
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
                <div class="col-md-3">
                    <div class="form-group form-inline">
                        <label for="inputEmail3">
                            T.E.N. on &nbsp; &nbsp;</label>
                        <asp:TextBox ID="txtTENno" class="form-control input-sm" runat="server" MaxLength="10"></asp:TextBox>
                    </div>
                </div>
                <div class="col-md-4">
                    <div class="form-group form-inline">
                        <label for="inputEmail3">
                            PAN No. &nbsp; &nbsp;</label>
                        <asp:TextBox ID="TextBox1" class="form-control input-sm" runat="server" MaxLength="10"
                            ReadOnly="true" Text="AVNPP5214F"></asp:TextBox>
                    </div>
                </div>
            </div>
            <div class="row" style="border-top: 1px solid #000; padding-top: 15px;">
                <div class="col-md-12">
                    <div class="row">
                        <div class="col-md-2">
                            <div class="form-group">
                                <label for="exampleInputEmail1">
                                    Loading Date</label>
                                <div class="input-group input-group-sm date" id="datetimepicker6">
                                    <asp:TextBox ID="txtLoadingDate" class="form-control" runat="server"></asp:TextBox>
                                    <span class="input-group-addon"><span class="glyphicon glyphicon-remove"></span>
                                    </span><span class="input-group-addon"><span class="glyphicon glyphicon-calendar"></span>
                                    </span>
                                </div>
                            </div>
                        </div>
                        <div class="col-md-2">
                            <div class="form-group">
                                <label for="exampleInputEmail1">
                                    Unloading Date</label>
                                <div class="input-group input-group-sm date" id="datetimepicker7">
                                    <asp:TextBox ID="txtUnloadingDate" class="form-control" runat="server"></asp:TextBox>
                                    <span class="input-group-addon"><span class="glyphicon glyphicon-remove"></span>
                                    </span><span class="input-group-addon"><span class="glyphicon glyphicon-calendar"></span>
                                    </span>
                                </div>
                            </div>
                        </div>
                        <div class="col-md-2">
                            <div class="form-group">
                                <label for="exampleInputEmail1">
                                    Freight</label>
                                <asp:TextBox ID="txtFrieght" runat="server" CssClass="form-control input-sm" onblur="calculate_amount()"></asp:TextBox>
                            </div>
                        </div>
                        <div class="col-md-2">
                            <div class="form-group">
                                <label for="exampleInputEmail1">
                                    Advance</label>
                                <asp:TextBox ID="txtAdvance" runat="server" CssClass="form-control input-sm" onblur="calculate_amount()"></asp:TextBox>
                            </div>
                        </div>
                        <div class="col-md-2">
                            <div class="form-group">
                                <label for="exampleInputEmail1">
                                    Balance</label>
                                <asp:TextBox ID="txtBalance" runat="server" CssClass="form-control input-sm" onblur="calculate_amount()"></asp:TextBox>
                            </div>
                        </div>
                        <div class="col-md-2">
                            <div class="form-group">
                                <label for="exampleInputEmail1">
                                    To Pay</label>
                                <asp:TextBox ID="txtToPay" runat="server" CssClass="form-control input-sm" onblur="calculate_amount()"></asp:TextBox>
                            </div>
                        </div>
                    </div>
                    <div class="row">
                        <div class="col-md-2">
                            <div class="form-group">
                                <label for="exampleInputEmail1">
                                    Hamali</label>
                                <asp:TextBox ID="txtHamali" runat="server" CssClass="form-control input-sm" onblur="calculate_amount()"></asp:TextBox>
                            </div>
                        </div>
                        <div class="col-md-2">
                            <div class="form-group">
                                <label for="exampleInputEmail1">
                                    Detention</label>
                                <asp:TextBox ID="txtDetention" runat="server" CssClass="form-control input-sm" onblur="calculate_amount()"></asp:TextBox>
                            </div>
                        </div>
                        <div class="col-md-2">
                            <div class="form-group">
                                <label for="exampleInputEmail1">
                                    Other Charge</label>
                                <asp:TextBox ID="txtOtherCharge" runat="server" CssClass="form-control input-sm"
                                    onblur="calculate_amount()"></asp:TextBox>
                            </div>
                        </div>
                        <div class="col-md-2">
                            <div class="form-group">
                                <label for="exampleInputEmail1">
                                    Net Amount</label>
                                <asp:TextBox ID="txtNetAmount" runat="server" CssClass="form-control input-sm" onblur="calculate_amount()"></asp:TextBox>
                            </div>
                        </div>
                        <div class="col-md-2">
                            <div style="margin-top: 27px;">
                                <asp:Button ID="btnItemSave" runat="server" Text="Save" CssClass="btn btn-primary btn-xs"
                                    OnClick="btnItemSave_Click" />
                                <asp:Button ID="btnItemClear" runat="server" Text="Clear" CssClass="btn btn-default btn-xs"
                                    OnClick="btnItemClear_Click" />
                            </div>
                        </div>
                        <div class="col-md-2">
                        </div>
                    </div>
                </div>
            </div>
            <div class="row">
                <div class="col-md-12">
                    <div class="table-responsive">
                        <asp:GridView ID="gvItemList" runat="server" CssClass="table table-striped table-bordered table-hover table-condensed"
                            AutoGenerateColumns="false" ShowFooter="true" OnRowDataBound="gvItemList_RowDataBound">
                            <Columns>
                                <asp:TemplateField>
                                    <ItemTemplate>
                                        <asp:LinkButton ID="btnEdit" runat="server" OnClick="btnEdit_Click" data-toggle="tooltip"
                                            title="Click here to edit this record.">
                                <span class="fa fa-pencil"></span>
                                        </asp:LinkButton>
                                    </ItemTemplate>
                                    <ItemStyle HorizontalAlign="Center" Width="30px" />
                                </asp:TemplateField>
                                <asp:TemplateField>
                                    <ItemTemplate>
                                        <asp:LinkButton ID="btnDelete" runat="server" OnClick="btnDelete_Click" data-toggle="tooltip"
                                            title="Click here to delete this record.">
                                <span class="fa fa-trash"></span>
                                        </asp:LinkButton>
                                    </ItemTemplate>
                                    <ItemStyle HorizontalAlign="Center" Width="30px" />
                                </asp:TemplateField>
                                <asp:BoundField HeaderText="Loading Date" DataField="LoadingDate" />
                                <asp:BoundField HeaderText="Unloading Date" DataField="UnloadingDate" />
                                <asp:BoundField HeaderText="Freight" DataField="Freight" />
                                <asp:BoundField HeaderText="Advance" DataField="Advance" />
                                <asp:BoundField HeaderText="Balance" DataField="Balance" />
                                <asp:BoundField HeaderText="To Pay" DataField="ToPay" />
                                <asp:BoundField HeaderText="Hamali" DataField="Hamali" />
                                <asp:BoundField HeaderText="Detention" DataField="Detention" />
                                <asp:TemplateField HeaderText="Other Charge">
                                    <ItemTemplate>
                                        <asp:Label ID="lblOtherCharge" runat="server" Text='<%# Eval("OtherCharge") %>'></asp:Label>
                                    </ItemTemplate>
                                    <FooterTemplate>
                                        <asp:Label ID="lblTotalOC" runat="server" Text="Total"></asp:Label>
                                        <asp:Image ID="rupee" runat="server" ImageUrl="~/Images/Rupee_symbol.png" Width="10"
                                            Height="10" />
                                    </FooterTemplate>
                                </asp:TemplateField>
                                <asp:TemplateField HeaderText="Net Amount">
                                    <ItemTemplate>
                                        <asp:Label ID="lblNetAmt" runat="server" Text='<%# Eval("NetAmount") %>'></asp:Label>
                                    </ItemTemplate>
                                    <FooterTemplate>
                                        <asp:Label ID="lblTotalNetAmt" runat="server"></asp:Label>
                                    </FooterTemplate>
                                </asp:TemplateField>
                            </Columns>
                        </asp:GridView>
                    </div>
                </div>
            </div>
            <div class="form-group">
                <div class="col-sm-offset-2 col-sm-10">
                    <asp:Button ID="btnSave" runat="server" Text="Save" CssClass="btn btn-primary btn-sm"
                        OnClick="btnSave_Click" ValidationGroup="save" />
                    <asp:Button ID="btnClear" runat="server" Text="Clear" CssClass="btn btn-default btn-sm"
                        OnClick="btnClear_Click" />
                    <asp:Button ID="btnList" runat="server" Text="List" CssClass="btn btn-warning btn-sm"
                        OnClick="btnList_Click" />
                </div>
            </div>
        </div>
    </div>
</asp:Content>
