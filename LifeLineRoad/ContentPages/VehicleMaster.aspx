<%@ Page Title="" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true"
    CodeBehind="VehicleMaster.aspx.cs" Inherits="LifeLineRoad.ContentPages.VehicleMaster" %>

<%@ Register Assembly="AjaxControlToolkit" Namespace="AjaxControlToolkit" TagPrefix="asp" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <div class="form-horizontal">
        <div class="form-group">
            <label for="inputEmail3" class="col-sm-2 control-label">
                Maker Name</label>
            <div class="col-sm-5">
                <asp:TextBox ID="txtMakerName" class="form-control input-sm" runat="server" MaxLength="100"></asp:TextBox>
            </div>
            <div class="col-sm-5">
                <label class="control-label">
                    <asp:RequiredFieldValidator ID="RequiredFieldValidator1" runat="server" ErrorMessage="Maker Name is mandatory."
                        ControlToValidate="txtMakerName" CssClass="val-required" SetFocusOnError="true"
                        Display="Dynamic" ValidationGroup="save"></asp:RequiredFieldValidator>
                </label>
            </div>
        </div>
        <div class="form-group">
            <label for="inputEmail3" class="col-sm-2 control-label">
                Model</label>
            <div class="col-sm-5">
                <asp:TextBox ID="txtModelName" class="form-control input-sm" runat="server" MaxLength="50"></asp:TextBox>
            </div>
            <div class="col-sm-5">
                <label class="control-label">
                    <asp:RequiredFieldValidator ID="RequiredFieldValidator4" runat="server" ErrorMessage="Model Name is mandatory."
                        ControlToValidate="txtModelName" CssClass="val-required" SetFocusOnError="true"
                        Display="Dynamic" ValidationGroup="save"></asp:RequiredFieldValidator>
                </label>
            </div>
        </div>
        <div class="form-group">
            <label for="inputEmail3" class="col-sm-2 control-label">
                Vehicle No.</label>
            <div class="col-sm-5">
                <asp:TextBox ID="txtVehicleNo" class="form-control input-sm" runat="server" MaxLength="50"></asp:TextBox>
            </div>
            <div class="col-sm-5">
                <label class="control-label">
                    <asp:RequiredFieldValidator ID="RequiredFieldValidator2" runat="server" ErrorMessage="Vehicle No is mandatory."
                        ControlToValidate="txtVehicleNo" CssClass="val-required" SetFocusOnError="true"
                        Display="Dynamic" ValidationGroup="save"></asp:RequiredFieldValidator>
                </label>
            </div>
        </div>
        <div class="form-group">
            <label for="inputEmail3" class="col-sm-2 control-label">
                Engine No.</label>
            <div class="col-sm-5">
                <asp:TextBox ID="txtEngineNo" class="form-control input-sm" runat="server" MaxLength="50"></asp:TextBox>
            </div>
            <div class="col-sm-5">
                <label class="control-label">
                    <asp:RequiredFieldValidator ID="RequiredFieldValidator5" runat="server" ErrorMessage="Engine No is mandatory."
                        ControlToValidate="txtEngineNo" CssClass="val-required" SetFocusOnError="true"
                        Display="Dynamic" ValidationGroup="save"></asp:RequiredFieldValidator>
                </label>
            </div>
        </div>
        <div class="form-group">
            <label for="inputEmail3" class="col-sm-2 control-label">
                Chasis No.</label>
            <div class="col-sm-5">
                <asp:TextBox ID="txtChasisNo" class="form-control input-sm" runat="server" MaxLength="50"></asp:TextBox>
            </div>
            <div class="col-sm-5">
                <label class="control-label">
                    <asp:RequiredFieldValidator ID="RequiredFieldValidator6" runat="server" ErrorMessage="Chasis No is mandatory."
                        ControlToValidate="txtChasisNo" CssClass="val-required" SetFocusOnError="true"
                        Display="Dynamic" ValidationGroup="save"></asp:RequiredFieldValidator>
                </label>
            </div>
        </div>
        <div class="form-group">
            <label for="inputEmail3" class="col-sm-2 control-label">
                Year</label>
            <div class="col-sm-1">
                <asp:TextBox ID="txtManufacYear" class="form-control input-sm" runat="server" MaxLength="4"></asp:TextBox>
                <asp:FilteredTextBoxExtender ID="FilteredTextBoxExtender4" runat="server" TargetControlID="txtManufacYear"
                    FilterType="Numbers">
                </asp:FilteredTextBoxExtender>
            </div>
            <div class="col-sm-5">
                <label class="control-label">
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
</asp:Content>
