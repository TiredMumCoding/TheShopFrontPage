Imports System.Data
Imports System.Data.SqlClient

Partial Class viewBasket
    Inherits System.Web.UI.Page

    Public Sub pageload(sender As Object, e As EventArgs) Handles Me.Load


        If Session("ShoppingList").count > 0 Then

            Dim dt As New DataTable
            Dim Total As Decimal = 0

            dt.Columns.Add("id")
            dt.Columns.Add("prd")
            dt.Columns.Add("prc")
            dt.Columns.Add("quan")
            dt.Columns.Add("totalprc")

            For Each item In Session("ShoppingList")
                Dim row = dt.NewRow
                row("id") = item.id
                row("prd") = item.prd
                row("prc") = Math.Round(CDec(item.prc), 2).ToString("c2")
                row("quan") = item.quan
                row("totalprc") = (Math.Round(CDec(item.prc), 2) * CDec(item.quan)).ToString("c2")

                dt.Rows.Add(row)
            Next

            For Each row In dt.Rows
                Total = Total + CDec(row("totalprc"))
            Next

            Dim totalrow = dt.NewRow
            totalrow("id") = ""
            totalrow("prd") = "Total"
            totalrow("prc") = ""
            totalrow("quan") = ""
            totalrow("totalprc") = Math.Round(CDec(Total), 2).ToString("c2")

            dt.Rows.Add(totalrow)

            gridbasket.DataSource = dt
            gridbasket.DataBind()

            gridbasket.HeaderRow.Visible = False

            For Each row In gridbasket.Rows
                row.cells(0).visible = False
                row.cells(1).cssclass = "item"
                row.cells(2).cssclass = "item"
                row.cells(3).cssclass = "item"
                row.cells(4).cssclass = "item"

            Next


        End If

    End Sub

    Public Sub check_Out(Sender As Object, E As EventArgs)
        Response.Redirect("checkOut.aspx")
    End Sub

    Public Sub continue_Shop(Sender As Object, E As EventArgs)
        If Not (Request.UrlReferrer Is Nothing) Then
            Response.Redirect(Session("shopping"))
        End If

    End Sub

End Class
