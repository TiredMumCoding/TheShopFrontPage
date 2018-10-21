<%@ Page Title="" Language="VB" MasterPageFile="~/MasterPage.master" AutoEventWireup="false" CodeFile="MainMenu.aspx.vb" Inherits="MainMenu" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" Runat="Server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" Runat="Server">
    <asp:Repeater ID="repeat" runat="server" >
    <itemtemplate>
        <div class="rep" />
        <div class="inrep firstIm <%# DataBinder.Eval(Container.DataItem, "englishproductcategoryname") %>"><asp:image cssclass="img1" runat="server" src=<%# DataBinder.Eval(Container.DataItem, "Source") %> /></div>
        <div class="inrep secondIm <%# DataBinder.Eval(Container.DataItem, "englishproductcategoryname") %>"><asp:image CssClass="img2" runat="server" src=<%# DataBinder.Eval(Container.DataItem, "Source") %> /></div>
        <div class="inrep <%# DataBinder.Eval(Container.DataItem, "englishproductcategoryname") %> btn"><asp:linkbutton runat="server" text=<%# DataBinder.Eval(Container.DataItem, "englishproductcategoryname") %>
            onclick="catSelect" CommandArgument=<%# DataBinder.Eval(Container.DataItem, "productcategorykey") %>
            CommandName=<%# DataBinder.Eval(Container.DataItem, "englishproductcategoryname") %>></asp:linkbutton></div>
        </div>
    </itemtemplate>
    </asp:Repeater>
</asp:Content>

