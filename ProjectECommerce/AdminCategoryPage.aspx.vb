
Imports System.Data.SqlClient
Imports System.Data
Imports System.Configuration


Partial Class AdminCategoryPage
    Inherits System.Web.UI.Page


    Private conn As String = ConfigurationManager.ConnectionStrings("ConnStr").ToString

    Protected Sub Page_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load
        lblMsg.Text = ""
        If Not IsPostBack Then
            BindCategoryData()
        End If
    End Sub

    'call this method to bind gridview 
    Private Sub BindCategoryData()
        Using sqlCon As New SqlConnection(conn)
            Using cmd As New SqlCommand()
                cmd.CommandText = "SELECT * FROM Category"
                cmd.Connection = sqlCon
                sqlCon.Open()
                Dim da As New SqlDataAdapter(cmd)
                Dim dt As New DataTable()
                da.Fill(dt)
                gvCategory.DataSource = dt
                gvCategory.DataBind()
                sqlCon.Close()
            End Using
        End Using
    End Sub

    'Insert click event to insert new record to database 
    Protected Sub btnInsert_Click(ByVal sender As Object, ByVal e As EventArgs)
        Dim IsAdded As Boolean = False
        Dim CategoryName As String = txtCategoryName.Text.Trim()

        Using sqlCon As New SqlConnection(conn)
            Using cmd As New SqlCommand()
                cmd.CommandText = "INSERT INTO Category(CategoryName) VALUES(@categoryName)"
                cmd.Parameters.AddWithValue("@categoryName", CategoryName)
                cmd.Connection = sqlCon
                sqlCon.Open()
                IsAdded = cmd.ExecuteNonQuery() > 0
                sqlCon.Close()
            End Using
        End Using
        If IsAdded Then
            lblMsg.Text = "'" & CategoryName & "' subject details added successfully!"
            lblMsg.ForeColor = System.Drawing.Color.Green

            BindCategoryData()
        Else
            lblMsg.Text = "Error while adding '" & CategoryName & "' category"
            lblMsg.ForeColor = System.Drawing.Color.Red
        End If
        ResetAll() 'to reset all form controls 
    End Sub

    'Update click event to update existing record from the gridview 
    Protected Sub btnUpdate_Click(ByVal sender As Object, ByVal e As EventArgs)
        If String.IsNullOrEmpty(txtCategoryID.Text) Then
            lblMsg.Text = "Please select record to update"
            lblMsg.ForeColor = System.Drawing.Color.Red
            Return
        End If
        Dim IsUpdated As Boolean = False
        Dim CategoryID As Integer = Convert.ToInt32(txtCategoryID.Text)
        Dim CategoryName As String = txtCategoryName.Text.Trim()

        Using sqlCon As New SqlConnection(conn)
            Using cmd As New SqlCommand()
                cmd.CommandText = "UPDATE Category SET CategoryName=@categoryName WHERE CategoryID=@categoryID"
                cmd.Parameters.AddWithValue("@categoryID", CategoryID)
                cmd.Parameters.AddWithValue("@categoryName", CategoryName)

                cmd.Connection = sqlCon
                sqlCon.Open()
                IsUpdated = cmd.ExecuteNonQuery() > 0
                sqlCon.Close()
            End Using
        End Using
        If IsUpdated Then
            lblMsg.Text = "'" & CategoryName & "' Category details updated successfully!"
            lblMsg.ForeColor = System.Drawing.Color.Green
        Else
            lblMsg.Text = "Error while updating '" & CategoryName & "' Category details"
            lblMsg.ForeColor = System.Drawing.Color.Red
        End If
        gvCategory.EditIndex = -1
        BindCategoryData()
        ResetAll() 'to reset all form controls 
    End Sub


    'Delete click event to delete selected record from the database 
    Protected Sub btnDelete_Click(ByVal sender As Object, ByVal e As EventArgs)
        If String.IsNullOrEmpty(txtCategoryID.Text) Then
            lblMsg.Text = "Please select record to delete"
            lblMsg.ForeColor = System.Drawing.Color.Red
            Return
        End If
        Dim IsDeleted As Boolean = False
        Dim CategoryID As Integer = Convert.ToInt32(txtCategoryID.Text)
        Dim CategoryName As String = txtCategoryName.Text.Trim()
        Using sqlCon As New SqlConnection(conn)
            Using cmd As New SqlCommand()
                cmd.CommandText = "DELETE FROM Category WHERE CategoryID=@categoryID"
                cmd.Parameters.AddWithValue("@categoryID", CategoryID)
                cmd.Connection = sqlCon
                sqlCon.Open()
                IsDeleted = cmd.ExecuteNonQuery() > 0
                sqlCon.Close()
            End Using
        End Using
        If IsDeleted Then
            lblMsg.Text = "'" & CategoryName & "' category deleted successfully!"
            lblMsg.ForeColor = System.Drawing.Color.Green
            BindCategoryData()
        Else
            lblMsg.Text = "Error while deleting '" & CategoryName & "' category "
            lblMsg.ForeColor = System.Drawing.Color.Red
        End If
        ResetAll() 'to reset all form controls 
    End Sub

    'Cancel click event to clear and reset all the textboxes 
    Protected Sub btnCancel_Click(ByVal sender As Object, ByVal e As EventArgs)
        ResetAll() 'to reset all form controls 
    End Sub


    Protected Sub gvCategory_SelectedIndexChanged(ByVal sender As Object, ByVal e As EventArgs)
        txtCategoryID.Text = gvCategory.DataKeys(gvCategory.SelectedRow.RowIndex).Value.ToString()
        txtCategoryName.Text = (TryCast(gvCategory.SelectedRow.FindControl("labelCategoryName"), Label)).Text

        'make invisible Insert button during update/delete 
        btnInsert.Visible = False
    End Sub

    'call to reset all form controls 
    Private Sub ResetAll()
        btnInsert.Visible = True
        txtCategoryID.Text = ""
        txtCategoryName.Text = ""

    End Sub

    Private Sub _Default_PreInit(sender As Object, e As EventArgs) Handles Me.PreInit
        If (Not Session("Theme") Is Nothing) Then
            Page.Theme = Session("Theme").ToString()
        End If
    End Sub

End Class