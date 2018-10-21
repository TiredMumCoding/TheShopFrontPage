<%@ Page Title="" Language="VB" MasterPageFile="~/MasterPage.master" AutoEventWireup="false" CodeFile="itemPage.aspx.vb" Inherits="itemPage" %>
<%@ MasterType VirtualPath ="~/MasterPage.master"%>

<asp:Content ID="Content1" ContentPlaceHolderID="head" Runat="Server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" Runat="Server">
    <br /><br/>
    <h2><asp:GridView ID="Grid" runat="server" CssClass="item"></asp:GridView></h2>
    <br /><br />
    <div class="wrapper">
    <asp:Button ID="btn" runat="server" Text="Add To Basket" OnClick="add_Basket" CssClass="btn" /><br /><br />
    <asp:Label ID ="itemAdded" runat="server" Text=""></asp:Label><br /><br />
          <asp:Button ID="shop" runat="server" Text="Continue Shopping" OnClick ="continue_Shop" CssClass="btn" />
          </div>
    <asp:GridView ID="testGrid" runat="server"></asp:GridView><br />
</asp:Content>

