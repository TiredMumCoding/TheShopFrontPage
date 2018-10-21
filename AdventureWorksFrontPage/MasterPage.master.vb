
Partial Class MasterPage
    Inherits System.Web.UI.MasterPage

    Class Shopping_Basket

        Private productid As String

        Property id() As String

            Get
                Return productid
            End Get
            Set(ByVal Value As String)
                productid = Value
            End Set
        End Property

        Private product As String

        Property prd() As String

            Get
                Return product
            End Get
            Set(ByVal Value As String)
                product = Value
            End Set
        End Property

        Private price As String

        Property prc() As String

            Get
                Return price
            End Get
            Set(ByVal Value As String)
                price = Value
            End Set
        End Property


        Private quantity As String

        Property quan() As String

            Get
                Return quantity
            End Get
            Set(ByVal Value As String)
                quantity = Value
            End Set
        End Property

    End Class

    Public Sub PageLoad(sender As Object, e As EventArgs) Handles Me.Load

        If Not IsPostBack Then
            Dim o As Object = Session("ShoppingList")
            If o Is Nothing Then
                Dim ShoppingList As New List(Of Shopping_Basket)()
                Session("ShoppingList") = ShoppingList
            End If
        End If


    End Sub

    Public Sub ViewBasket(sender As Object, e As EventArgs)
        Response.Redirect("viewbasket.aspx")
    End Sub

End Class

