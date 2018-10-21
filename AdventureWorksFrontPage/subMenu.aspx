<%@ Page Title="" Language="VB" MasterPageFile="~/MasterPage.master" AutoEventWireup="false" CodeFile="subMenu.aspx.vb" Inherits="subMenu" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" Runat="Server">


</asp:Content>

<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" Runat="Server">
        <asp:label runat="server" Text="" ID="catname" value="test"></asp:label> <br /><br />
    <asp:HiddenField  ID="hfaccordion" runat="server" /> 
            <asp:repeater id="parentRepeater" runat="server">
        <itemtemplate><Button class="accordion"> <%# DataBinder.Eval(Container.DataItem, "englishproductsubcategoryname") %> </Button>
        <div class="panel <%# DataBinder.Eval(Container.DataItem, "englishproductsubcategoryname") %>"><asp:repeater runat="server" id="childRepeater" datasource ='<%# Container.DataItem.Row.GetChildRows("myrelation")%>'>
            <itemtemplate><asp:linkbutton runat="server" text=<%#Container.DataItem("englishproductname")%> OnClick ="product_Click"
                CommandArgument=<%#Container.DataItem("productkey")%>></asp:linkbutton></br></itemtemplate>
            </asp:repeater></div>
            </itemtemplate>
    </asp:repeater>
</asp:Content>

