<%@ Page Title="" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true"
    CodeBehind="BranchMaster.aspx.cs" Inherits="LifeLineRoad.ContentPages.BranchMaster" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
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
                        Company Namez</label>
                    <div class="col-sm-5">
                        <asp:DropDownList ID="ddlCompany" runat="server" CssClass="form-control input-sm">
                        </asp:DropDownList>
                    </div>
                    <div class="col-sm-5">
                        <label class="control-label">
                            <asp:RequiredFieldValidator ID="RequiredFieldValidator3" runat="server" ErrorMessage="Select Company Name."
                                ControlToValidate="ddlCompany" CssClass="val-required" SetFocusOnError="true" InitialValue="0"
                                ValidationGroup="save" Display="Dynamic"></asp:RequiredFieldValidator>
                        </label>
                    </div>
                </div>   
                <div class="form-group">
                    <label for="inputEmail3" class="col-sm-2 control-label">
                        Branch Name</label>
                    <div class="col-sm-5">
                        <asp:TextBox ID="txtBranchName" CssClass="form-control input-sm" runat="server" MaxLength="50"></asp:TextBox>
                    </div>
                    <div class="col-sm-5">
                        <label class="control-label">
                            <asp:RequiredFieldValidator ID="RequiredFieldValidator1" runat="server" ErrorMessage="Branch Name is mandatory."
                                ControlToValidate="txtBranchName" CssClass="val-required" SetFocusOnError="true"
                                ValidationGroup="save" Display="Dynamic"></asp:RequiredFieldValidator>
                        </label>
                    </div>
                </div>                
                <div class="form-group">
                    <label for="inputEmail3" class="col-sm-2 control-label">
                        Address</label>
                    <div class="col-sm-5">
                        <asp:TextBox ID="txtAddress1" CssClass="form-control input-sm" runat="server" MaxLength="250"></asp:TextBox>
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
                        City</label>
                    <div class="col-sm-5">
                        <asp:TextBox ID="txtCity" CssClass="form-control input-sm" runat="server" MaxLength="100"></asp:TextBox>
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
                        <asp:DropDownList ID="ddlState" runat="server" CssClass="form-control input-sm">
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
                        Pincode</label>
                    <div class="col-sm-5">
                        <asp:TextBox ID="txtPincode" runat="server" CssClass="form-control input-sm" MaxLength="6"></asp:TextBox>
                    </div>
                    <div class="col-sm-5">
                        <label class="control-label">
                            <asp:RequiredFieldValidator ID="RequiredFieldValidator6" runat="server" ErrorMessage="Pincode is mandatory."
                                ControlToValidate="txtPincode" CssClass="val-required" SetFocusOnError="true" InitialValue="0"
                                ValidationGroup="save" Display="Dynamic"></asp:RequiredFieldValidator>
                        </label>
                    </div>
                </div>
                <div class="form-group">
                    <label for="inputEmail3" class="col-sm-2 control-label">
                        Mobile Number</label>
                    <div class="col-sm-5">
                        <asp:TextBox ID="txtMobileNo" CssClass="form-control input-sm" runat="server" MaxLength="10"></asp:TextBox>
                    </div>
                    <div class="col-sm-5">
                        <label class="control-label">
                        </label>
                    </div>
                </div>
                <div class="form-group">
                    <label for="inputEmail3" class="col-sm-2 control-label">
                        Phone Number</label>
                    <div class="col-sm-5">
                        <asp:TextBox ID="txtPhoneNo" CssClass="form-control input-sm" runat="server" MaxLength="10"></asp:TextBox>
                    </div>
                    <div class="col-sm-5">
                        <label class="control-label">
                        </label>
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
    </div>
</asp:Content>
