Imports System.Data
Imports System.Data.SqlClient

Partial Class itemPage
    Inherits System.Web.UI.Page


    Public Sub Pageload(sender As Object, e As EventArgs) Handles Me.Load

        Dim DS As New DataSet

        Dim connectionString As String = ConfigurationManager.ConnectionStrings("AdventureWorksDW_WroxSSRS2012ConnectionString").ConnectionString
        Dim cnn As SqlConnection = New SqlConnection(connectionString)
        cnn.Open()

        Dim cmd As New SqlCommand("select productkey, englishproductname as Item, case when listprice Is null then 100 else listprice end as Price From [AdventureWorksDW_WroxSSRS2012].[dbo].[DimProduct] Where productkey = @productKey", cnn)

        cmd.Parameters.Add("@productKey", SqlDbType.Int)
        cmd.Parameters("@productKey").Value = Session("id")

        Dim DA As New SqlDataAdapter(cmd)
        DA.Fill(DS)
        Grid.DataSource = DS
        Grid.DataBind()

        Grid.HeaderRow.Cells(0).Visible = False
        Grid.HeaderRow.Cells(1).CssClass = "item"
        Grid.HeaderRow.Cells(2).CssClass = "item"

        For Each row In Grid.Rows

            row.cells(0).visible = False
            row.cells(1).cssclass = "item"
            row.cells(2).cssclass = "item"
            row.cells(2).text = String.Format("{0:C2}", Convert.ToDecimal(row.cells(2).Text))

        Next



        cnn.Close()

    End Sub

    Public Sub add_Basket(sender As Object, e As EventArgs)

        Dim complete As Boolean = False

        If Session("ShoppingList").count > 0 Then
            Dim i As Integer = 0
            For Each item In Session("ShoppingList")
                If item.id = Session("ID") Then
                    Session("ShoppingList").item(i).quan = Session("ShoppingList").item(i).quan + 1
                    complete = True
                End If
                i = i + 1
            Next

        End If

        If complete = False Then

            Dim connectionString As String = ConfigurationManager.ConnectionStrings("AdventureWorksDW_WroxSSRS2012ConnectionString").ConnectionString
            Dim cnn As SqlConnection = New SqlConnection(connectionString)
            cnn.Open()

            Dim cmd As New SqlCommand("select productkey, englishproductname as Item, case when listprice Is null then 100 else listprice end as Price, 1 as quantity From [AdventureWorksDW_WroxSSRS2012].[dbo].[DimProduct] Where productkey = @productKey", cnn)

            cmd.Parameters.Add("@productKey", SqlDbType.Int)
            cmd.Parameters("@productKey").Value = Session("id")

            Dim basket As New MasterPage.Shopping_Basket
            Dim Reader As SqlDataReader = cmd.ExecuteReader()
            Reader.Read()
            basket.id = Reader.Item("productkey").ToString
            basket.prd = Reader.Item("item").ToString
            basket.prc = Reader.Item("price").ToString
            basket.quan = Reader.Item("quantity").ToString
            Reader.Close()
            cnn.Close()

            Session("ShoppingList").Add(basket)
            complete = True

            If (complete) Then
                itemAdded.Text = "Item Successfully Added"
            End If

        End If

    End Sub

    Public Sub continue_Shop(Sender As Object, E As EventArgs)
        If Not (Request.UrlReferrer Is Nothing) Then
            Response.Redirect(Session("shopping"))
        End If

    End Sub

End Class
