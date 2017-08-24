<%@ Page Title="" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="ConsigneeMasterList.aspx.cs" Inherits="LifeLineRoad.ContentPages.ConsigneeMasterList" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
<div class="panel panel-default">
        <div class="panel-heading">
            Consignor Master List
            <div class="pull-right">
                <asp:Button ID="btnAddNew" runat="server" Text="Add New Consignee" CssClass="btn btn-success btn-xs"
                    OnClick="btnAddNew_Click" />
            </div>
        </div>
        <div class="table-responsive">
            <asp:GridView ID="gvList" runat="server" AutoGenerateColumns="false" DataKeyNames="consigneeId"
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
                    <asp:BoundField HeaderText="Company Name" DataField="consigneeName" />
                    <asp:BoundField HeaderText="First Name" DataField="firstName" />
                    <asp:BoundField HeaderText="Last Name" DataField="lastName" />
                    <asp:BoundField HeaderText="Address" DataField="companyAddress" />
                    <asp:BoundField HeaderText="City" DataField="city" />
                    <asp:BoundField HeaderText="Phone No" DataField="phoneNumber" />
                    <asp:BoundField HeaderText="Email Id" DataField="emailAddress" />
                    <asp:BoundField HeaderText="VAT No" DataField="vatNumber" />
                    <asp:BoundField HeaderText="CST No" DataField="cstNumber" />
                </Columns>
            </asp:GridView>
        </div>
    </div>
</asp:Content>
