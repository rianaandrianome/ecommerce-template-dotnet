Imports System.Data.SqlClient
Imports System.Data
Imports System.Configuration



Public Class ClientCartPage
    Inherits System.Web.UI.Page


    Private conn As String = ConfigurationManager.ConnectionStrings("ConnStr").ToString
    Dim currentID As String

    Protected Sub Page_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load

        If Not Page.IsPostBack Then
            FindUserID()
            BindData()
            TotalAmount()
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

    Public Sub BindData()
        Using sqlCon As New SqlConnection(conn)
            Using cmd As New SqlCommand()
                cmd.CommandText = "SELECT* FROM Cart WHERE userID=@currentID AND paymentStatus<>@paymentStatus "
                cmd.Parameters.AddWithValue("@currentID", Label1.Text)
                cmd.Parameters.AddWithValue("@paymentStatus", "PAID")
                cmd.Connection = sqlCon
                sqlCon.Open()
                Dim da As New SqlDataAdapter(cmd)
                Dim dt As New DataTable()
                da.Fill(dt)
                GridView1.DataSource = dt
                GridView1.DataBind()
                sqlCon.Close()
            End Using
        End Using

    End Sub

    Sub TotalAmount()

        Using sqlCon As New SqlConnection(conn)
            Using cmd As New SqlCommand()
                cmd.CommandText = "SELECT SUM(unitPrice*quantity) FROM Cart WHERE userID=@currentID"
                cmd.Parameters.AddWithValue("@currentID", Label1.Text)
                cmd.Connection = sqlCon
                sqlCon.Open()

                Dim totalAmount As Decimal = cmd.ExecuteScalar()
                LabelTotalAmount.Text = totalAmount
                sqlCon.Close()
            End Using
        End Using

    End Sub


    Protected Sub GridView1_PageIndexChanging(sender As Object, e As GridViewPageEventArgs)
        GridView1.PageIndex = e.NewPageIndex
        BindData()
    End Sub

    Protected Sub GridView1_RowEditing(sender As Object, e As GridViewEditEventArgs)
        GridView1.EditIndex = e.NewEditIndex
        BindData()
    End Sub

    Protected Sub GridView1_RowCancelingEdit(sender As Object, e As GridViewCancelEditEventArgs)
        e.Cancel = True
        GridView1.EditIndex = -1
        BindData()
    End Sub

    Protected Sub GridView1_RowUpdating(sender As Object, e As GridViewUpdateEventArgs)
        Dim row As GridViewRow
        row = GridView1.Rows(e.RowIndex)

        Dim txtQuantity As TextBox = row.FindControl("txtQuantity")
        Dim lblProduct As Label = row.FindControl("lblProduct")

        If lblProduct Is Nothing Then
            Exit Sub
        End If

        Dim quantity As Integer = txtQuantity.Text
        Dim product As String = lblProduct.Text

        UpdateProduct(quantity, product)

        TotalAmount()
    End Sub

    Public Sub UpdateProduct(quantity As Integer, product As String)
        Dim Query As String = "UPDATE Cart SET quantity = @quantity WHERE product= @product"
        Dim conn As String = ConfigurationManager.ConnectionStrings("ConnStr").ToString

        Dim con As New SqlConnection(conn)
        Dim com As New SqlCommand(Query, con)
        com.Parameters.Add("@product", SqlDbType.NVarChar).Value = product
        com.Parameters.Add("@quantity", SqlDbType.Int).Value = quantity

        con.Open()
        com.ExecuteNonQuery()
        con.Close()
        GridView1.EditIndex = -1
        BindData()

    End Sub

    Protected Sub GridView1_RowDeleting(sender As Object, e As GridViewDeleteEventArgs)
        Dim row As GridViewRow
        row = GridView1.Rows(e.RowIndex)
        Dim LblCartID As Label = Row.FindControl("LblCartID")

        Dim cartID As String = LblCartID.Text

        Dim IsDeleted As Boolean = False

        Using sqlCon As New SqlConnection(conn)
            Using cmd As New SqlCommand()
                cmd.CommandText = "DELETE FROM Cart WHERE cartID=@cartID"
                cmd.Parameters.AddWithValue("@cartID", cartID)
                cmd.Connection = sqlCon
                sqlCon.Open()
                IsDeleted = cmd.ExecuteNonQuery() > 0
                sqlCon.Close()
            End Using
        End Using
        BindData()
        TotalAmount()
    End Sub

    Private Sub _Default_PreInit(sender As Object, e As EventArgs) Handles Me.PreInit
        If (Not Session("Theme") Is Nothing) Then
            Page.Theme = Session("Theme").ToString()
        End If
    End Sub
End Class