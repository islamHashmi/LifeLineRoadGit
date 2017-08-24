<%@ Page Title="" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="InvoiceList.aspx.cs" Inherits="LifeLineRoad.ContentPages.InvoiceList" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <div class="panel panel-default">
        <div class="panel-heading">
            Invoice List
            <div class="pull-right">
                <asp:Button ID="btnAddNew" runat="server" Text="Add New Invoice" CssClass="btn btn-success btn-xs"
                    OnClick="btnAddNew_Click" />
            </div>
        </div>
        <div class="table-responsive">
            <asp:GridView ID="gvList" runat="server" AutoGenerateColumns="false" DataKeyNames="InvoiceId"
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
                    <asp:BoundField HeaderText="Invoice No" DataField="InvoiceNo" />
                    <asp:BoundField HeaderText="Date" DataField="InvoiceDate" DataFormatString="{0:dd/MM/yyyy}" />
                    <asp:BoundField HeaderText="Consignee Name" DataField="ConsigneeName" />
                    <asp:BoundField HeaderText="From Location" DataField="FromLocation" />
                    <asp:BoundField HeaderText="To Location" DataField="ToLocation" />
                    <asp:BoundField HeaderText="Vehicle No" DataField="VehicleNo" />
                    <asp:BoundField HeaderText="T.E.N. No" DataField="TENNo" />
                    <asp:BoundField HeaderText="Total Amount" DataField="TotalAmount" />
                </Columns>
            </asp:GridView>
        </div>
    </div>
</asp:Content>
