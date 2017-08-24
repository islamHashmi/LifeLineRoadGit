<%@ Page Title="" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true"
    CodeBehind="VehicleMasterList.aspx.cs" Inherits="LifeLineRoad.ContentPages.VehicleMasterList" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <div class="panel panel-default">
        <div class="panel-heading">
            Driver Master List
            <div class="pull-right">
                <asp:Button ID="btnAddNew" runat="server" Text="Add User" CssClass="btn btn-success btn-xs"
                    OnClick="btnAddNew_Click" />
            </div>
        </div>
        <div class="table-responsive">
            <asp:GridView ID="gvList" runat="server" AutoGenerateColumns="false" DataKeyNames="vehicleId"
                CssClass="table table-striped table-hover table-condensed" GridLines="None">
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
                    <asp:BoundField HeaderText="Maker Name" DataField="makerName" />
                    <asp:BoundField HeaderText="Model" DataField="modelName" />
                    <asp:BoundField HeaderText="Vehicle No" DataField="vehicleNo" />
                    <asp:BoundField HeaderText="Engine No" DataField="engineNo" />
                    <asp:BoundField HeaderText="Chasis No" DataField="chasisNo" />
                    <asp:BoundField HeaderText="Manufactured Year" DataField="yearManufactured" />
                </Columns>
            </asp:GridView>
        </div>
    </div>
</asp:Content>
