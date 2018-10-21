Imports System.Data
Imports System.Data.SqlClient

Partial Class MainMenu
    Inherits System.Web.UI.Page

    Public Sub Pageload(sender As Object, e As EventArgs) Handles Me.Load

        Dim connectionString As String = ConfigurationManager.ConnectionStrings("AdventureWorksDW_WroxSSRS2012ConnectionString").ConnectionString
        Dim cnn As New SqlConnection(connectionString)
        cnn.Open()
        'change bikes to cycles to stop the product category class also acting on the subccategory
        Dim cmd As New SqlCommand("select productcategorykey, case when englishproductcategoryname = 'Bikes' then 'Cycles' else EnglishProductCategoryName end as EnglishProductCategoryName, case when productcategorykey = 1 then 'bike1.png' when productcategorykey = 2 then 'comp1.png' when productcategorykey = 3 then 'clothes1.png' when productcategorykey = 4 then 'access1.png' else 'graph.png' end as Source FROM DimProductCategory", cnn)

        Dim DA As New SqlDataAdapter(cmd)
        Dim DS As New DataSet

        DA.Fill(DS)
        repeat.DataSource = DS
        repeat.DataBind()

        cnn.Close()



    End Sub

    Public Sub catSelect(sender As Object, e As EventArgs)
        Session("catkey") = sender.CommandArgument
        Session("catname") = sender.CommandName
        Response.Redirect("subMenu.aspx")

    End Sub

End Class
