<%@ Page Title="" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true"
    CodeBehind="DriverMasterList.aspx.cs" Inherits="LifeLineRoad.ContentPages.DriverMasterList" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <div class="panel panel-default">
        <div class="panel-heading">
            Driver Master List
            <div class="pull-right">
                <asp:Button ID="btnAddNew" runat="server" Text="Add New Driver" CssClass="btn btn-success btn-xs"
                    OnClick="btnAddNew_Click" />
            </div>
        </div>
        <div class="table-responsive">
            <asp:GridView ID="gvList" runat="server" AutoGenerateColumns="false" DataKeyNames="driverId"
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
                    <asp:BoundField HeaderText="Driver Name" DataField="driverName" />
                    <asp:BoundField HeaderText="Date Of Birth" DataField="dateOfBirth" DataFormatString="{0:dd/MM/yyyy}" />
                    <asp:BoundField HeaderText="Address 1" DataField="address1" />
                    <asp:BoundField HeaderText="Address 2" DataField="address2" />
                    <asp:BoundField HeaderText="City" DataField="city" />
                    <asp:BoundField HeaderText="State" DataField="StateName" />
                    <asp:BoundField HeaderText="Mobile No" DataField="mobileNo" />
                    <asp:BoundField HeaderText="License No" DataField="LicenseNo" />
                </Columns>
            </asp:GridView>
        </div>
    </div>
</asp:Content>
