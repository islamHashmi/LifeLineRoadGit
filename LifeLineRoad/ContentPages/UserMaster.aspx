<%@ Page Title="" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true"
    CodeBehind="UserMaster.aspx.cs" Inherits="LifeLineRoad.ContentPages.UserMaster" %>

<%@ Register Assembly="AjaxControlToolkit" Namespace="AjaxControlToolkit" TagPrefix="asp" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <div class="panel panel-default">
        <div class="panel-heading">
            User Master
        </div>
        <div class="panel-body">
            <div class="form-horizontal">
                <div class="form-group">
                    <label for="inputEmail3" class="col-sm-2 control-label">
                        User Name</label>
                    <div class="col-sm-5">
                        <asp:TextBox ID="txtUserName" class="form-control input-sm" runat="server" MaxLength="50"></asp:TextBox>
                    </div>
                    <div class="col-sm-5">
                        <label class="control-label">
                            <asp:RequiredFieldValidator ID="RequiredFieldValidator1" runat="server" ErrorMessage="User Name is mandatory."
                                ControlToValidate="txtUserName" CssClass="val-required" SetFocusOnError="true"
                                ValidationGroup="save" Display="Dynamic"></asp:RequiredFieldValidator>
                        </label>
                    </div>
                </div>
                <div class="form-group">
                    <label for="inputEmail3" class="col-sm-2 control-label">
                        Login Id</label>
                    <div class="col-sm-5">
                        <asp:TextBox ID="txtLoginId" class="form-control input-sm" runat="server" MaxLength="20"></asp:TextBox>
                    </div>
                    <div class="col-sm-5">
                        <label class="control-label">
                            <asp:RequiredFieldValidator ID="RequiredFieldValidator3" runat="server" ErrorMessage="Login Id is mandatory."
                                ControlToValidate="txtLoginId" CssClass="val-required" SetFocusOnError="true"
                                ValidationGroup="save" Display="Dynamic"></asp:RequiredFieldValidator>
                        </label>
                    </div>
                </div>
                <div class="form-group">
                    <label for="inputEmail3" class="col-sm-2 control-label">
                        Password</label>
                    <div class="col-sm-5">
                        <asp:TextBox ID="txtPasswd" class="form-control input-sm" runat="server" MaxLength="20"></asp:TextBox>
                    </div>
                    <div class="col-sm-5">
                        <label class="control-label">
                            <asp:RequiredFieldValidator ID="RequiredFieldValidator2" runat="server" ErrorMessage="Password is mandatory."
                                ControlToValidate="txtPasswd" CssClass="val-required" SetFocusOnError="true"
                                ValidationGroup="save" Display="Dynamic"></asp:RequiredFieldValidator>
                        </label>
                    </div>
                </div>
                <div class="form-group">
                    <label for="inputEmail3" class="col-sm-2 control-label">
                        Confirm Password</label>
                    <div class="col-sm-5">
                        <asp:TextBox ID="txtConPasswd" class="form-control input-sm" runat="server" MaxLength="20"></asp:TextBox>
                    </div>
                    <div class="col-sm-5">
                        <label class="control-label">
                            <asp:CompareValidator ID="CompareValidator1" runat="server" ErrorMessage="Both password do not match."
                                ControlToValidate="txtConPasswd" ControlToCompare="txtPasswd" CssClass="val-required"
                                ValidationGroup="save" Display="Dynamic"></asp:CompareValidator>
                        </label>
                    </div>
                </div>
                <div class="form-group">
                    <label for="inputEmail3" class="col-sm-2 control-label">
                        Mobile Number</label>
                    <div class="col-sm-5">
                        <asp:TextBox ID="txtMobileNo" class="form-control input-sm" runat="server" MaxLength="10"></asp:TextBox>
                        <asp:FilteredTextBoxExtender ID="FilteredTextBoxExtender1" runat="server" TargetControlID="txtMobileNo"
                            FilterType="Numbers">
                        </asp:FilteredTextBoxExtender>
                    </div>
                    <div class="col-sm-5">
                        <label class="control-label">
                        </label>
                    </div>
                </div>
                <div class="form-group">
                    <label for="inputEmail3" class="col-sm-2 control-label">
                        Email Address</label>
                    <div class="col-sm-5">
                        <asp:TextBox ID="txtEmailId" class="form-control input-sm" runat="server" MaxLength="255"></asp:TextBox>
                    </div>
                    <div class="col-sm-5">
                        <label class="control-label">
                            <asp:RegularExpressionValidator ID="RegularExpressionValidator1" runat="server" ControlToValidate="txtEmailId"
                                ErrorMessage="Email Address is not valid." CssClass="val-required" Display="Dynamic"
                                ValidationExpression="^\w+([-+.]\w+)*@\w+([-.]\w+)*\.\w+([-.]\w+)*\s*$">
                            </asp:RegularExpressionValidator>
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
