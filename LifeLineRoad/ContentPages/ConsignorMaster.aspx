<%@ Page Title="" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true"
    CodeBehind="ConsignorMaster.aspx.cs" Inherits="LifeLineRoad.ContentPages.ConsignorMaster" %>

<%@ Register Assembly="AjaxControlToolkit" Namespace="AjaxControlToolkit" TagPrefix="asp" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <div class="panel panel-default">
        <div class="panel-heading">
            Consignor Master
        </div>
        <div class="panel-body">
            <div class="row">
                <div class="col-md-6">
                    <div class="form-horizontal">
                        <div class="form-group">
                            <label for="inputEmail3" class="col-sm-4 control-label">
                                Company Name</label>
                            <div class="col-sm-8">
                                <asp:TextBox ID="txtCompanyName" class="form-control input-sm" runat="server" MaxLength="250"></asp:TextBox>
                                <asp:RequiredFieldValidator ID="RequiredFieldValidator1" runat="server" ErrorMessage="Comapny Name is mandatory."
                                    ControlToValidate="txtCompanyName" CssClass="val-required" SetFocusOnError="true"
                                    Display="Dynamic" ValidationGroup="save"></asp:RequiredFieldValidator>
                            </div>
                        </div>
                        <div class="form-group">
                            <label for="inputEmail3" class="col-sm-4 control-label">
                                First Name</label>
                            <div class="col-sm-8">
                                <asp:TextBox ID="txtFirstName" class="form-control input-sm" runat="server" MaxLength="50"></asp:TextBox>
                                <asp:RequiredFieldValidator ID="RequiredFieldValidator4" runat="server" ErrorMessage="First Name is mandatory."
                                    ControlToValidate="txtFirstName" CssClass="val-required" SetFocusOnError="true"
                                    Display="Dynamic" ValidationGroup="save"></asp:RequiredFieldValidator>
                            </div>
                        </div>
                        <div class="form-group">
                            <label for="inputEmail3" class="col-sm-4 control-label">
                                Last Name</label>
                            <div class="col-sm-8">
                                <asp:TextBox ID="txtLastName" class="form-control input-sm" runat="server" MaxLength="50"></asp:TextBox>
                            </div>
                        </div>
                        <div class="form-group">
                            <label for="inputEmail3" class="col-sm-4 control-label">
                                Mobile No.</label>
                            <div class="col-sm-8">
                                <asp:TextBox ID="txtMobile" class="form-control input-sm" runat="server" MaxLength="10"></asp:TextBox>
                                <asp:FilteredTextBoxExtender ID="FilteredTextBoxExtender2" runat="server" TargetControlID="txtMobile"
                                    FilterType="Numbers">
                                </asp:FilteredTextBoxExtender>
                            </div>
                        </div>
                        <div class="form-group">
                            <label for="inputEmail3" class="col-sm-4 control-label">
                                Phone No.</label>
                            <div class="col-sm-8">
                                <asp:TextBox ID="txtPhone" class="form-control input-sm" runat="server" MaxLength="10"></asp:TextBox>
                                <asp:FilteredTextBoxExtender ID="FilteredTextBoxExtender1" runat="server" TargetControlID="txtPhone"
                                    FilterType="Numbers">
                                </asp:FilteredTextBoxExtender>
                            </div>
                        </div>
                        <div class="form-group">
                            <label for="inputEmail3" class="col-sm-4 control-label">
                                Fax No.</label>
                            <div class="col-sm-8">
                                <asp:TextBox ID="txtFaxNo" class="form-control input-sm" runat="server" MaxLength="12"></asp:TextBox>
                                <asp:FilteredTextBoxExtender ID="FilteredTextBoxExtender3" runat="server" TargetControlID="txtFaxNo"
                                    FilterType="Numbers">
                                </asp:FilteredTextBoxExtender>
                            </div>
                        </div>
                        <div class="form-group">
                            <label for="inputEmail3" class="col-sm-4 control-label">
                                Email Address</label>
                            <div class="col-sm-8">
                                <asp:TextBox ID="txtEmail" class="form-control input-sm" runat="server" MaxLength="255"></asp:TextBox>
                                <asp:RegularExpressionValidator ID="RegularExpressionValidator1" runat="server" ControlToValidate="txtEmail"
                                    ErrorMessage="Email Address is not valid." CssClass="val-required" Display="Dynamic"
                                    ValidationExpression="^\w+([-+.]\w+)*@\w+([-.]\w+)*\.\w+([-.]\w+)*\s*$" ValidationGroup="save">
                                </asp:RegularExpressionValidator>
                            </div>
                        </div>
                    </div>
                </div>
                <div class="col-md-6">
                    <div class="form-horizontal">
                        <div class="form-group">
                            <label for="inputEmail3" class="col-sm-4 control-label">
                                Address</label>
                            <div class="col-sm-8">
                                <asp:TextBox ID="txtAddress" TextMode="MultiLine" Height="85px" class="form-control input-sm"
                                    runat="server" MaxLength="500"></asp:TextBox>
                                <asp:RequiredFieldValidator ID="RequiredFieldValidator2" runat="server" ErrorMessage="Address is mandatory."
                                    ControlToValidate="txtAddress" CssClass="val-required" SetFocusOnError="true"
                                    Display="Dynamic" ValidationGroup="save"></asp:RequiredFieldValidator>
                            </div>
                        </div>
                        <div class="form-group">
                            <label for="inputEmail3" class="col-sm-4 control-label">
                                City</label>
                            <div class="col-sm-8">
                                <asp:TextBox ID="txtCity" class="form-control input-sm" runat="server" MaxLength="100"></asp:TextBox>
                            </div>
                        </div>
                        <div class="form-group">
                            <label for="inputEmail3" class="col-sm-4 control-label">
                                State</label>
                            <div class="col-sm-8">
                                <asp:DropDownList ID="ddlState" runat="server" class="form-control input-sm">
                                </asp:DropDownList>
                            </div>
                        </div>
                        <div class="form-group">
                            <label for="inputEmail3" class="col-sm-4 control-label">
                                Pincode</label>
                            <div class="col-sm-8">
                                <asp:TextBox ID="txtPincode" class="form-control input-sm" runat="server" MaxLength="6"></asp:TextBox>
                                <asp:FilteredTextBoxExtender ID="FilteredTextBoxExtender4" runat="server" TargetControlID="txtPincode"
                                    FilterType="Numbers">
                                </asp:FilteredTextBoxExtender>
                            </div>
                        </div>
                        <div class="form-group">
                            <label for="inputEmail3" class="col-sm-4 control-label">
                                VAT No.</label>
                            <div class="col-sm-8">
                                <asp:TextBox ID="txtVatNo" class="form-control input-sm" runat="server" MaxLength="50"></asp:TextBox>
                            </div>
                        </div>
                        <div class="form-group">
                            <label for="inputEmail3" class="col-sm-4 control-label">
                                CST No.</label>
                            <div class="col-sm-8">
                                <asp:TextBox ID="txtCstNo" class="form-control input-sm" runat="server" MaxLength="50"></asp:TextBox>
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
            </div>
        </div>
    </div>
</asp:Content>
