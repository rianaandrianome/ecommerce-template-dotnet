
Imports System.Data.SqlClient
Imports System.Data
Imports System.Configuration



Public Class ClientPaymentPage
    Inherits System.Web.UI.Page

    Private conn As String = ConfigurationManager.ConnectionStrings("ConnStr").ToString
    Dim currentID As String

    Protected Sub Page_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load

        If Not Page.IsPostBack Then
            FindUserID()
            BindPayment()
        End If

    End Sub


    Private Sub FindUserID()
        Dim currentUserName As String = Session("Username")

        Using sqlCon As New SqlConnection(conn)
            Using cmd As New SqlCommand()
                cmd.CommandText = "SELECT userID FROM [Users] WHERE userUsername=@currentUserName"

                cmd.Parameters.AddWithValue("@currentUserName", currentUserName)

                cmd.Connection = sqlCon
                sqlCon.Open()

                currentID = cmd.ExecuteScalar()
                Label1.Text = currentID

                sqlCon.Close()
            End Using
        End Using
    End Sub

    Public Sub BindPayment()
        Using sqlCon As New SqlConnection(conn)
            Using cmd As New SqlCommand()
                cmd.CommandText = "SELECT* FROM Cart WHERE userID=@currentID"
                cmd.Parameters.AddWithValue("@currentID", Label1.Text)
                cmd.Connection = sqlCon
                sqlCon.Open()
                Dim da As New SqlDataAdapter(cmd)
                Dim dt As New DataTable()
                da.Fill(dt)
                DataList1.DataSource = dt
                DataList1.DataBind()
                sqlCon.Close()
            End Using
        End Using

    End Sub

    Protected Sub ButtonPay_Click(sender As Object, e As EventArgs)

        Dim IsAdded As Boolean = False

        Using sqlCon As New SqlConnection(conn)
            Using cmd As New SqlCommand()

                cmd.CommandText = "UPDATE Cart SET paymentStatus=@paymentStatus, shippingAddress=@shippingAddress WHERE userID=@userID"

                cmd.Parameters.AddWithValue("@userID", Label1.Text)
                cmd.Parameters.AddWithValue("@paymentStatus", "CHECKEDOUT")
                cmd.Parameters.AddWithValue("@shippingAddress", txtShippingAddress.Text)


                cmd.Connection = sqlCon
                sqlCon.Open()
                IsAdded = cmd.ExecuteNonQuery() > 0
                sqlCon.Close()
            End Using
        End Using
        MsgBox("Thank you! Request of payment successfull: You will receive notification uppon payment confirmation.")

    End Sub

    Private Sub _Default_PreInit(sender As Object, e As EventArgs) Handles Me.PreInit
        If (Not Session("Theme") Is Nothing) Then
            Page.Theme = Session("Theme").ToString()
        End If
    End Sub
End Class