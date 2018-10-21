Imports System.Data
Imports System.Data.SqlClient

Partial Class subMenu
    Inherits System.Web.UI.Page

    Public Sub Pageload(Sender As Object, e As EventArgs) Handles Me.Load
        catname.Text = Session("catname")

        Dim connectionString As String
        Dim DS As New DataSet

        connectionString = ConfigurationManager.ConnectionStrings("AdventureWorksDW_WroxSSRS2012ConnectionString").ConnectionString
        Dim cnn As SqlConnection = New SqlConnection(connectionString)
        cnn.Open()

        Dim cmd As New SqlCommand("select productsubcategorykey, englishproductsubcategoryname from dimproductsubcategory where productcategorykey = @catkey", cnn)
        cmd.Parameters.Add("@catkey", SqlDbType.Int)
        cmd.Parameters("@catkey").Value = Session("catkey")

        Dim cmd1 As New SqlCommand("select p.productkey, p.ProductSubcategoryKey, p.englishproductname from dimproduct p inner join dimproductsubcategory s on p.ProductSubcategoryKey = s.ProductSubcategoryKey where s.productcategorykey = @key", cnn)
        cmd1.Parameters.Add("@key", SqlDbType.Int)
        cmd1.Parameters("@key").Value = Session("catkey")

        Dim DA As New SqlDataAdapter(cmd)
        Dim DA1 As New SqlDataAdapter(cmd1)

        DA.Fill(DS, "subcat")
        DA1.Fill(DS, "product")

        DS.Relations.Add("myRelation",
        DS.Tables("subcat").Columns("productsubcategorykey"),
        DS.Tables("product").Columns("ProductSubcategoryKey"))


        parentRepeater.DataSource = DS
        parentRepeater.DataBind()


    End Sub

    Public Sub Product_Click(sender As Object, e As EventArgs)
        Dim btn As LinkButton = sender
        Session("id") = sender.commandargument
        Session("shopping") = Request.Url.ToString
        Response.Redirect("itemPage.aspx")
        'Response.Write("<script>window.open('itemPage.aspx','_blank', 'height=570,width=600')</script>")

    End Sub


End Class
