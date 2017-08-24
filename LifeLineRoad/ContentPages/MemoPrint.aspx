<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="MemoPrint.aspx.cs" Inherits="LifeLineRoad.ContentPages.MemoPrint" %>

<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">
<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title>Memo Print</title>
    <link href="../bootstrap/css/printStyle.css" rel="stylesheet" type="text/css" />
</head>
<body>
    <form id="form1" runat="server">
    <div>
        <asp:Table ID="Table1" runat="server" BorderStyle="Solid" BorderWidth="1px">
            <asp:TableRow runat="server">
                <asp:TableCell ID="TableCell1" runat="server" CssClass="text-left">
                    <strong> Tel. : 022-31901610</strong>
                </asp:TableCell>
                <asp:TableCell ID="TableCell2" runat="server" CssClass="text-center">
                    <u>Subject to Navi Mumbai Juridiction only</u>
                </asp:TableCell>
                <asp:TableCell ID="TableCell3" runat="server" CssClass="text-right">
                   <strong> Mob. : 8452047781 <br />
                    &nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;
                    9029475333</strong>
                </asp:TableCell>
            </asp:TableRow>
            <asp:TableRow runat="server">
                <asp:TableCell ID="TableCell4" runat="server">
                    <img src="../Images/Life Line Road VC.png" alt="Logo" height="70" />
                </asp:TableCell>
                <asp:TableCell ID="TableCell5" runat="server" ColumnSpan="2">
                    <p class="comp-name">LIFE LINE ROAD CARRIER</p>
                    <p class="comp-tag">Transport Contractors & Commission Agents</p>
                    <p class="comp-tag">LCV & LPT Service available for all over South & North India.</p>
                </asp:TableCell>
            </asp:TableRow>
            <asp:TableRow runat="server">
                <asp:TableCell ID="TableCell7" runat="server" ColumnSpan="3" CssClass="spl-in text-center">
                    <p>Specialist for LPT & 20 feet Container</p>
                </asp:TableCell>
            </asp:TableRow>
            <asp:TableRow runat="server">
                <asp:TableCell ID="TableCell10" runat="server" ColumnSpan="3" CssClass="text-center">
                    <p class="comp-address">Plot No. 92, Office No. 101, Sector - 19C, Near APMC Police Station,
                    <br />Vashi, Navi Mumbai - 400705 <span>.</span> Email : manojkumarpoonia94@gmail.com</p>
                </asp:TableCell>
            </asp:TableRow>
            <asp:TableRow runat="server">
                <asp:TableCell ID="TableCell13" runat="server" CssClass="bill-no">
                    No.
                    <asp:Label ID="lblMemoNo" runat="server" Text="899" ForeColor="Red"></asp:Label>
                </asp:TableCell>
                <asp:TableCell ID="TableCell14" runat="server"></asp:TableCell>
                <asp:TableCell ID="TableCell15" runat="server" CssClass="bill-no">
                    Date :
                    <asp:Label ID="lblDate" runat="server" Text="24/08/2017" ForeColor="Black"></asp:Label>
                </asp:TableCell>
            </asp:TableRow>
            <asp:TableRow runat="server">
                <asp:TableCell ID="TableCell16" runat="server" ColumnSpan="3">
                    M/s.
                    <asp:Label ID="lblConsignee" runat="server" Text="ABC Corp"></asp:Label>
                </asp:TableCell>
            </asp:TableRow>
            <asp:TableRow runat="server">
                <asp:TableCell ID="TableCell19" runat="server" ColumnSpan="3">
                    <p class="style1">As per your order we are sending following :</p>
                </asp:TableCell>
            </asp:TableRow>
            <asp:TableRow runat="server">
                <asp:TableCell ID="TableCell22" runat="server" ColumnSpan="3">
                    Vehicle No.
                    <asp:Label ID="lblVehicle" runat="server" Text="MH-04-ER-5248"></asp:Label>
                </asp:TableCell>
            </asp:TableRow>
            <asp:TableRow runat="server">
                <asp:TableCell ID="TableCell25" runat="server">
                    Pick-up Location
                    <asp:Label ID="lblPickup" runat="server" Text="Dadar"></asp:Label>
                </asp:TableCell>
                <asp:TableCell ID="TableCell26" runat="server">
                    Drop Location
                    <asp:Label ID="lblDrop" runat="server" Text="Vashi"></asp:Label>
                </asp:TableCell>
                <asp:TableCell ID="TableCell27" runat="server">
                    Weight
                    <asp:Label ID="lblWeight" runat="server" Text="500.00"></asp:Label>
                </asp:TableCell>
            </asp:TableRow>
            <asp:TableRow runat="server">
                <asp:TableCell ID="TableCell28" runat="server" ColumnSpan="3">
                    Hire Fixed Rs.
                    <asp:Label ID="lblHireFixedRs" runat="server" Text="58400.00"></asp:Label>
                </asp:TableCell>
            </asp:TableRow>
            <asp:TableRow runat="server">
                <asp:TableCell ID="TableCell31" runat="server" ColumnSpan="3">
                    Advance Rs.
                    <asp:Label ID="lblAdvanceRs" runat="server" Text="5200.00"></asp:Label>
                </asp:TableCell>
            </asp:TableRow>
            <asp:TableRow runat="server">
                <asp:TableCell ID="TableCell34" runat="server" ColumnSpan="3">
                    Balance Rs.
                    <asp:Label ID="lblBalanceRs" runat="server" Text="8000.20"></asp:Label>
                </asp:TableCell>
            </asp:TableRow>
            <asp:TableRow runat="server">
                <asp:TableCell ID="TableCell37" runat="server" ColumnSpan="3">
                    Balance At
                    <asp:Label ID="lblBalanceAt" runat="server" Text="9251.25"></asp:Label>
                </asp:TableCell>
            </asp:TableRow>
            <asp:TableRow runat="server">
                <asp:TableCell ID="TableCell40" runat="server" ColumnSpan="3">
                    PAN No.
                    <asp:Label ID="lblPanNo" runat="server" Text="ADSE4564D"></asp:Label>
                </asp:TableCell>
            </asp:TableRow>
            <asp:TableRow runat="server">
                <asp:TableCell ID="TableCell43" runat="server" ColumnSpan="3" CssClass="note">
                    <p>Note :</p>
                    <ol style="list-style-type:decimal;">
                        <li>
                            You will be responsible for the S.T. & C.S.T. No. of the consignore & <br />consignee and checked the vehicle R.T.O.
                        </li>
                        <li>
                            We are not responsible for leakage, Breakage & Damage during <br />Transportation of Goods booked under Owner's Risk.
                        </li>
                        <li>
                            Loading & Unloading Charges must be paid by party only.
                        </li>
                        <li>
                            Charges due to height & length will be extra.
                        </li>
                    </ol>
                </asp:TableCell>
            </asp:TableRow>
            <asp:TableRow runat="server">
                <asp:TableCell ID="TableCell46" runat="server" ColumnSpan="3">
                    <p>For Life Line Road Carrier</p>
                </asp:TableCell>
            </asp:TableRow>
        </asp:Table>
    </div>
    </form>
</body>
</html>
