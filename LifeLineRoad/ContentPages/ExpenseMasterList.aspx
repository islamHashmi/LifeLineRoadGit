<%@ Page Title="" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true"
    CodeBehind="ExpenseMasterList.aspx.cs" Inherits="LifeLineRoad.ContentPages.ExpenseMasterList" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
<div class="panel panel-default">
        <div class="panel-heading">
            Expense Master List
            <div class="pull-right">
                <asp:Button ID="btnAddNew" runat="server" Text="Add New Expense" CssClass="btn btn-success btn-xs"
                    OnClick="btnAddNew_Click" />
            </div>
        </div>
        <div class="table-responsive">
            <asp:GridView ID="gvList" runat="server" AutoGenerateColumns="false" DataKeyNames="expenseId"
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
                    <asp:BoundField HeaderText="Expense Name" DataField="expenseName" />
                    <asp:BoundField HeaderText="Date" DataField="effectiveDate" DataFormatString="{0:dd/MM/yyyy}" />
                </Columns>
            </asp:GridView>
        </div>
    </div>
</asp:Content>
