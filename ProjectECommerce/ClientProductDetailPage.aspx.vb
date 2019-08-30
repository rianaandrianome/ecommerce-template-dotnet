
Imports System.Data
Imports System.Configuration
Imports System.Data.SqlClient

Public Class ClientProductDetailPage
    Inherits System.Web.UI.Page


    Private conn As String = ConfigurationManager.ConnectionStrings("ConnStr").ToString
    Protected Sub Page_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load
        If Not IsPostBack Then
            If Not Session("Username") Is Nothing Then
                FindUserID()

            End If

        End If
    End Sub

    Private Sub FindUserID()
        Using sqlCon As New SqlConnection(conn)
            Using cmd As New SqlCommand()

                cmd.CommandText = "SELECT userID FROM [Users] WHERE userUsername=@currentUserName"

                cmd.Parameters.AddWithValue("@currentUserName", Session("Username"))

                cmd.Connection = sqlCon
                sqlCon.Open()

                Dim currentUserID As String = cmd.ExecuteScalar()
                Label1.Text = currentUserID


                sqlCon.Close()
            End Using
        End Using
    End Sub


    Protected Sub ButtonAddToCart_Click(sender As Object, e As EventArgs)

        Dim product As String = DirectCast(DataList1.Controls(0).FindControl("lblProductName"), Label).Text
        Dim price As Decimal = Decimal.Parse(DirectCast(DataList1.Controls(0).FindControl("lblPrice"), Label).Text)
        Dim image As String = DirectCast(DataList1.Controls(0).FindControl("Image1"), Image).ImageUrl

        Dim ProductID As Integer = Integer.Parse(Request.QueryString("productID"))

        Dim IsAdded As Boolean = False

        Using sqlCon As New SqlConnection(conn)
            Using cmd As New SqlCommand()
                cmd.CommandText = "INSERT INTO Cart(product, image, Cart.unitPrice, userID, quantity, paymentStatus, shippingAddress) VALUES(@product, @image, @unitPrice, @userID, @quantity, @paymentStatus, @shippingAddress)"

                cmd.Parameters.AddWithValue("@product", product)
                cmd.Parameters.AddWithValue("@image", image)
                cmd.Parameters.AddWithValue("@unitPrice", price)
                cmd.Parameters.AddWithValue("@userID", Label1.Text)
                cmd.Parameters.AddWithValue("@quantity", 1)
                cmd.Parameters.AddWithValue("@paymentStatus", "UNPAID")
                cmd.Parameters.AddWithValue("@shippingAddress", "Null")

                cmd.Connection = sqlCon
                sqlCon.Open()
                IsAdded = cmd.ExecuteNonQuery() > 0
                sqlCon.Close()
            End Using
        End Using

        If IsAdded Then
            lblMsg.Text = "'Product added successfully to cart!"
            lblMsg.ForeColor = System.Drawing.Color.Green

        Else
            lblMsg.Text = "Error while adding product to cart"
            lblMsg.ForeColor = System.Drawing.Color.Red
        End If


    End Sub
    Private Sub _Default_PreInit(sender As Object, e As EventArgs) Handles Me.PreInit
        If (Not Session("Theme") Is Nothing) Then
            Page.Theme = Session("Theme").ToString()
        End If
    End Sub

End Class