<%@ Page Title="" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true"
    CodeBehind="DriverMaster.aspx.cs" Inherits="LifeLineRoad.ContentPages.DriverMaster" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
    <script type="text/javascript">
        $(function () {
            $('#datetimepicker5').datetimepicker({
                format: 'dd/mm/yyyy',
                minView: 'month',
                autoclose: true
            });
        });
    </script>
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <div class="panel panel-default">
        <div class="panel-heading">
            Driver Master
        </div>
        <div class="panel-body">
            <div class="form-horizontal">
                <div class="form-group">
                    <label for="inputEmail3" class="col-sm-2 control-label">
                        Driver Name</label>
                    <div class="col-sm-5">
                        <asp:TextBox ID="txtDriverName" class="form-control input-sm" runat="server" MaxLength="50"></asp:TextBox>
                    </div>
                    <div class="col-sm-5">
                        <label class="control-label">
                            <asp:RequiredFieldValidator ID="RequiredFieldValidator1" runat="server" ErrorMessage="Driver Name is mandatory."
                                ControlToValidate="txtDriverName" CssClass="val-required" SetFocusOnError="true"
                                ValidationGroup="save" Display="Dynamic"></asp:RequiredFieldValidator>
                        </label>
                    </div>
                </div>
                <div class="form-group">
                    <label for="inputEmail3" class="col-sm-2 control-label">
                        Date Of Birth</label>
                    <div class="col-md-3">
                        <div class="input-group input-group-sm date" id="datetimepicker5">
                            <asp:TextBox ID="txtDOB" class="form-control" runat="server"></asp:TextBox>
                            <span class="input-group-addon"><span class="glyphicon glyphicon-remove"></span>
                            </span><span class="input-group-addon"><span class="glyphicon glyphicon-calendar"></span>
                            </span>
                        </div>
                    </div>
                    <div class="col-sm-5">
                        <label class="control-label">
                        </label>
                    </div>
                </div>
                <div class="form-group">
                    <label for="inputEmail3" class="col-sm-2 control-label">
                        Address 1</label>
                    <div class="col-sm-5">
                        <asp:TextBox ID="txtAddress1" class="form-control input-sm" runat="server" MaxLength="200"></asp:TextBox>
                    </div>
                    <div class="col-sm-5">
                        <label class="control-label">
                            <asp:RequiredFieldValidator ID="RequiredFieldValidator2" runat="server" ErrorMessage="Address 1 is mandatory."
                                ControlToValidate="txtAddress1" CssClass="val-required" SetFocusOnError="true"
                                ValidationGroup="save" Display="Dynamic"></asp:RequiredFieldValidator>
                        </label>
                    </div>
                </div>
                <div class="form-group">
                    <label for="inputEmail3" class="col-sm-2 control-label">
                        Address 2</label>
                    <div class="col-sm-5">
                        <asp:TextBox ID="txtAddress2" class="form-control input-sm" runat="server" MaxLength="200"></asp:TextBox>
                    </div>
                    <div class="col-sm-5">
                        <label class="control-label">
                        </label>
                    </div>
                </div>
                <div class="form-group">
                    <label for="inputEmail3" class="col-sm-2 control-label">
                        City</label>
                    <div class="col-sm-5">
                        <asp:TextBox ID="txtCity" class="form-control input-sm" runat="server" MaxLength="50"></asp:TextBox>
                    </div>
                    <div class="col-sm-5">
                        <label class="control-label">
                        </label>
                    </div>
                </div>
                <div class="form-group">
                    <label for="inputEmail3" class="col-sm-2 control-label">
                        State</label>
                    <div class="col-sm-5">
                        <asp:DropDownList ID="ddlState" runat="server" class="form-control input-sm">
                        </asp:DropDownList>
                    </div>
                    <div class="col-sm-5">
                        <label class="control-label">
                            <asp:RequiredFieldValidator ID="RequiredFieldValidator5" runat="server" ErrorMessage="State is mandatory."
                                ControlToValidate="ddlState" CssClass="val-required" SetFocusOnError="true" InitialValue="0"
                                ValidationGroup="save" Display="Dynamic"></asp:RequiredFieldValidator>
                        </label>
                    </div>
                </div>
                <div class="form-group">
                    <label for="inputEmail3" class="col-sm-2 control-label">
                        Mobile Number</label>
                    <div class="col-sm-5">
                        <asp:TextBox ID="txtMobileNo" class="form-control input-sm" runat="server" MaxLength="10"></asp:TextBox>
                    </div>
                    <div class="col-sm-5">
                        <label class="control-label">
                            <asp:RequiredFieldValidator ID="RequiredFieldValidator3" runat="server" ErrorMessage="Mobile No is mandatory."
                                ControlToValidate="txtMobileNo" CssClass="val-required" SetFocusOnError="true"
                                ValidationGroup="save" Display="Dynamic"></asp:RequiredFieldValidator>
                        </label>
                    </div>
                </div>
                <div class="form-group">
                    <label for="inputEmail3" class="col-sm-2 control-label">
                        License No.</label>
                    <div class="col-sm-5">
                        <asp:TextBox ID="txtLicenseNo" class="form-control input-sm" runat="server" MaxLength="50"></asp:TextBox>
                    </div>
                    <div class="col-sm-5">
                        <label class="control-label">
                            <asp:RequiredFieldValidator ID="RequiredFieldValidator4" runat="server" ErrorMessage="License No is mandatory."
                                ControlToValidate="txtLicenseNo" CssClass="val-required" SetFocusOnError="true"
                                ValidationGroup="save" Display="Dynamic"></asp:RequiredFieldValidator>
                        </label>
                    </div>
                </div>
                <div class="form-group">
                    <div class="col-sm-offset-2 col-sm-10">
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
    </div>
</asp:Content>
