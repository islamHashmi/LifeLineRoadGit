<%@ Page Title="" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true"
    CodeBehind="ExpenseMaster.aspx.cs" Inherits="LifeLineRoad.ContentPages.ExpenseMaster" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
    <script type="text/javascript">
        $(function () {
            $('#datetimepicker5').datetimepicker({
                format: 'dd/mm/yyyy',
                minView: 'month',
                autoclose: true
            });
        });
    </script>
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <div class="panel panel-default">
        <div class="panel-heading">
            Expense Master
        </div>
        <div class="panel-body">
            <div class="form-horizontal">
                <div class="form-group">
                    <label for="inputEmail3" class="col-sm-2 control-label">
                        Expense Name</label>
                    <div class="col-sm-5">
                        <asp:TextBox ID="txtExpenseName" class="form-control input-sm" runat="server" MaxLength="50"></asp:TextBox>
                    </div>
                    <div class="col-sm-5">
                        <label class="control-label">
                            <asp:RequiredFieldValidator ID="RequiredFieldValidator1" runat="server" ErrorMessage="Expense Name is mandatory."
                                ControlToValidate="txtExpenseName" CssClass="val-required" SetFocusOnError="true"
                                ValidationGroup="save" Display="Dynamic"></asp:RequiredFieldValidator>
                        </label>
                    </div>
                </div>
                <div class="form-group">
                    <label for="inputEmail3" class="col-sm-2 control-label">
                        Date</label>
                    <div class="col-md-3">
                        <div class="input-group input-group-sm date" id="datetimepicker5">
                            <asp:TextBox ID="txtEffectiveDate" class="form-control" runat="server"></asp:TextBox>
                            <span class="input-group-addon"><span class="glyphicon glyphicon-remove"></span>
                            </span><span class="input-group-addon"><span class="glyphicon glyphicon-calendar"></span>
                            </span>
                        </div>
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
        </div>
    </div>
</asp:Content>
