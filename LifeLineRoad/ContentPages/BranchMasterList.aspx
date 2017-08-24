<%@ Page Title="" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true"
    CodeBehind="BranchMasterList.aspx.cs" Inherits="LifeLineRoad.ContentPages.BranchMasterList" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <div class="panel panel-default">
        <div class="panel-heading">
            Branch Master List
            <div class="pull-right">
                <asp:Button ID="btnAddNew" runat="server" Text="Add New Branch" CssClass="btn btn-success btn-xs"
                    OnClick="btnAddNew_Click" />
            </div>
        </div>
        <div class="table-responsive">
            <asp:GridView ID="gvList" runat="server" AutoGenerateColumns="false" DataKeyNames="branchId"
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
                    <asp:BoundField HeaderText="Company Name" DataField="companyName" />
                    <asp:BoundField HeaderText="Branch Name" DataField="branchName" />
                    <asp:BoundField HeaderText="Address" DataField="branchAddress" />
                    <asp:BoundField HeaderText="City" DataField="city" />
                    <asp:BoundField HeaderText="State" DataField="stateName" />
                    <asp:BoundField HeaderText="Pincode" DataField="pincode" />
                    <asp:BoundField HeaderText="Phone No" DataField="mobileNo" />
                    <asp:BoundField HeaderText="Mobile No" DataField="phoneNo" />
                </Columns>
            </asp:GridView>
        </div>
    </div>
</asp:Content>
