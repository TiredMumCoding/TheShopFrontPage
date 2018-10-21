<%@ Page Title="" Language="VB" MasterPageFile="~/MasterPage.master" AutoEventWireup="false" CodeFile="viewBasket.aspx.vb" Inherits="viewBasket" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" Runat="Server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" Runat="Server">
    <h2 class="wrapper">Shopping Basket</h2>
    <asp:GridView ID="gridbasket" runat="server" cssclass="item"></asp:GridView>
    <asp:Label ID="thetotal" Text="" runat="server" CssClass="heading" /><br /><br />
      <div class="wrapper">
        <asp:Button ID="check" runat="server" Text="Checkout" OnClick ="check_Out" CssClass="btn" />
          <asp:Button ID="shop" runat="server" Text="Continue Shopping" OnClick ="continue_Shop" CssClass="btn" />
          </div>
</asp:Content>

