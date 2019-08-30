
Imports System.Data.SqlClient
Imports System.Data
Imports System.Configuration
Imports System.IO
Imports System.Collections.Generic

Public Class AdminProductPage
    Inherits System.Web.UI.Page


    Private conn As String = ConfigurationManager.ConnectionStrings("ConnStr").ToString

    Protected Sub Page_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load

        lblMsg.Text = ""

        If Not IsPostBack Then
            BindProductData()
        End If

        If Not IsPostBack Then
            BindDdlCategory()
        End If

    End Sub

    Protected Sub btnUpload_Click(sender As Object, e As EventArgs) Handles btnUpload.Click
        If FileUpload1.HasFile Then
            Dim FileExtension As String = System.IO.Path.GetExtension(FileUpload1.FileName)
            If Not FileExtension.ToLower = ".png" And Not FileExtension.ToLower = ".jpg" And Not FileExtension.ToLower = ".jpeg" And Not FileExtension.ToLower = ".gif" Then
                lblStatus.Text = "only image file is allowed"
                lblStatus.ForeColor = System.Drawing.Color.Red

            Else
                FileUpload1.SaveAs(Server.MapPath("~/images/" + FileUpload1.FileName))
                lblStatus.Text = "file uploaded"
                lblStatus.ForeColor = System.Drawing.Color.Green
            End If
        Else
            lblStatus.Text = "Please select a file to Upload"
            lblStatus.ForeColor = System.Drawing.Color.Red
        End If

        txtImageUrl.Text = "~/images/" + FileUpload1.FileName
    End Sub



    'call this method to bind gridview 
    Private Sub BindProductData()
        Using sqlCon As New SqlConnection(conn)
            Using cmd As New SqlCommand()
                cmd.CommandText = "SELECT productID, productName, Product.categoryID, imageUrl, unitPrice, color, size, brand, description, categoryName FROM Product, Category WHERE Product.categoryID=Category.categoryID"
                cmd.Connection = sqlCon
                sqlCon.Open()
                Dim da As New SqlDataAdapter(cmd)
                Dim dt As New DataTable()
                da.Fill(dt)
                gvProduct.DataSource = dt
                gvProduct.DataBind()
                sqlCon.Close()
            End Using
        End Using
    End Sub

    'call this method to bind ddlCategory 
    Private Sub BindDdlCategory()
        Using sqlCon As New SqlConnection(conn)
            Using cmd As New SqlCommand()
                cmd.CommandText = "SELECT categoryID, categoryName FROM Category"
                cmd.CommandType = CommandType.Text

                cmd.Connection = sqlCon
                sqlCon.Open()

                ddlCategory.DataSource = cmd.ExecuteReader()
                ddlCategory.DataTextField = "categoryName"
                ddlCategory.DataValueField = "categoryID"
                ddlCategory.DataBind()
                sqlCon.Close()

            End Using
        End Using
        ddlCategory.Items.Insert(0, New ListItem("Select category", "0"))
    End Sub

    'Insert click event to insert new record to database 
    Protected Sub btnInsert_Click(ByVal sender As Object, ByVal e As EventArgs)

        Dim IsAdded As Boolean = False

        Dim productName As String = txtProductName.Text
        Dim categoryID As String = Convert.ToInt32(ddlCategory.SelectedItem.Value)

        Dim imageUrl As String = txtImageUrl.Text
        Dim unitPrice As String = txtUnitPrice.Text
        Dim color As String = txtColor.Text
        Dim size As String = txtSize.Text
        Dim brand As String = txtBrand.Text
        Dim description As String = txtDescription.Text


        Using sqlCon As New SqlConnection(conn)
            Using cmd As New SqlCommand()
                cmd.CommandText = "INSERT INTO Product(productName, categoryID, imageUrl, unitPrice, color, size, brand, description) VALUES(@productName, @categoryID, @imageUrl, @unitPrice, @color, @size, @brand, @description)"

                cmd.Parameters.AddWithValue("@productName", productName)
                cmd.Parameters.AddWithValue("@categoryID", CategoryID)
                cmd.Parameters.AddWithValue("@imageUrl", ImageUrl)
                cmd.Parameters.AddWithValue("@unitPrice", unitPrice)
                cmd.Parameters.AddWithValue("@color", color)
                cmd.Parameters.AddWithValue("@size", size)
                cmd.Parameters.AddWithValue("@brand", brand)
                cmd.Parameters.AddWithValue("@description", description)

                cmd.Connection = sqlCon
                sqlCon.Open()
                IsAdded = cmd.ExecuteNonQuery() > 0
                sqlCon.Close()
            End Using
        End Using

        If IsAdded Then
            lblMsg.Text = "'" & productName & "' product added successfully!"
            lblMsg.ForeColor = System.Drawing.Color.Green

            BindProductData()
        Else
            lblMsg.Text = "Error while adding '" & productName & "' product details"
            lblMsg.ForeColor = System.Drawing.Color.Red
        End If

        ResetAll() 'to reset all form controls 
    End Sub

    'Update click event to update existing record from the gridview 
    Protected Sub btnUpdate_Click(ByVal sender As Object, ByVal e As EventArgs)

        If String.IsNullOrEmpty(txtProductId.Text) Then
            lblMsg.Text = "Please select record to update"
            lblMsg.ForeColor = System.Drawing.Color.Red
            Return
        End If
        Dim IsUpdated As Boolean = False

        Dim ProductID As Integer = Convert.ToInt32(txtProductId.Text)
        Dim ProductName As String = txtProductName.Text.Trim()
        Dim categoryID As String = Convert.ToInt32(ddlCategory.SelectedItem.Value)

        Dim ImageUrl As String = txtImageUrl.Text
        Dim UnitPrice As String = txtUnitPrice.Text
        Dim color As String = txtColor.Text
        Dim size As String = txtSize.Text
        Dim brand As String = txtBrand.Text
        Dim description As String = txtDescription.Text

        Using sqlCon As New SqlConnection(conn)
            Using cmd As New SqlCommand()
                cmd.CommandText = "UPDATE Product SET productName=@productName, categoryID=@categoryID, imageUrl=@imageUrl, unitPrice = @unitPrice, color=@color, size=@size, brand=@brand, description=@description WHERE productID=@productID"

                cmd.Parameters.AddWithValue("@productID", ProductID)
                cmd.Parameters.AddWithValue("@productName", ProductName)
                cmd.Parameters.AddWithValue("@categoryID", categoryID)
                cmd.Parameters.AddWithValue("@imageUrl", ImageUrl)
                cmd.Parameters.AddWithValue("@unitPrice", UnitPrice)
                cmd.Parameters.AddWithValue("@color", color)
                cmd.Parameters.AddWithValue("@size", size)
                cmd.Parameters.AddWithValue("@brand", brand)
                cmd.Parameters.AddWithValue("@description", description)

                cmd.Connection = sqlCon
                sqlCon.Open()
                IsUpdated = cmd.ExecuteNonQuery() > 0
                sqlCon.Close()
            End Using
        End Using
        If IsUpdated Then
            lblMsg.Text = "'" & ProductName & "' product updated successfully!"
            lblMsg.ForeColor = System.Drawing.Color.Green
        Else
            lblMsg.Text = "Error while updating '" & ProductName & "' product details"
            lblMsg.ForeColor = System.Drawing.Color.Red
        End If
        gvProduct.EditIndex = -1
        BindProductData()
        ResetAll() 'to reset all form controls 
    End Sub

    'Delete click event to delete selected record from the database 
    Protected Sub btnDelete_Click(ByVal sender As Object, ByVal e As EventArgs)
        If String.IsNullOrEmpty(txtProductId.Text) Then
            lblMsg.Text = "Please select record to delete"
            lblMsg.ForeColor = System.Drawing.Color.Red
            Return
        End If
        Dim IsDeleted As Boolean = False

        Dim productID As Integer = Convert.ToInt32(txtProductId.Text)
        Dim productName As String = txtProductName.Text.Trim()
        Dim categoryID As String = Convert.ToInt32(ddlCategory.SelectedItem.Value)
        Dim imageUrl As String = txtImageUrl.Text.Trim()
        Dim unitPrice As String = txtUnitPrice.Text.Trim()
        Dim color As String = txtColor.Text.Trim()
        Dim size As String = txtSize.Text.Trim()
        Dim brand As String = txtBrand.Text.Trim()


        Using sqlCon As New SqlConnection(conn)
            Using cmd As New SqlCommand()
                cmd.CommandText = "DELETE FROM Product WHERE productID=@productID"
                cmd.Parameters.AddWithValue("@productID", ProductID)
                cmd.Connection = sqlCon
                sqlCon.Open()
                IsDeleted = cmd.ExecuteNonQuery() > 0
                sqlCon.Close()
            End Using
        End Using
        If IsDeleted Then
            lblMsg.Text = "'" & productName & "' product deleted successfully!"
            lblMsg.ForeColor = System.Drawing.Color.Green
            BindProductData()
        Else
            lblMsg.Text = "Error while deleting '" & productName & "' product details"
            lblMsg.ForeColor = System.Drawing.Color.Red
        End If
        ResetAll() 'to reset all form controls 
    End Sub

    'Cancel click event to clear and reset all the textboxes 
    Protected Sub btnCancel_Click(ByVal sender As Object, ByVal e As EventArgs)
        ResetAll() 'to reset all form controls 
    End Sub


    Protected Sub gvProduct_SelectedIndexChanged(ByVal sender As Object, ByVal e As EventArgs)

        txtProductId.Text = gvProduct.DataKeys(gvProduct.SelectedRow.RowIndex).Value.ToString()
        txtProductName.Text = (TryCast(gvProduct.SelectedRow.FindControl("lblProductName"), Label)).Text
        ddlCategory.SelectedItem.Text = (TryCast(gvProduct.SelectedRow.FindControl("lblCategoryID"), Label)).Text
        txtImageUrl.Text = (TryCast(gvProduct.SelectedRow.FindControl("lblProductImage"), ImageButton)).ImageUrl
        txtUnitPrice.Text = (TryCast(gvProduct.SelectedRow.FindControl("lblUnitPrice"), Label)).Text
        txtColor.Text = (TryCast(gvProduct.SelectedRow.FindControl("lblColor"), Label)).Text
        txtSize.Text = (TryCast(gvProduct.SelectedRow.FindControl("lblSize"), Label)).Text
        txtBrand.Text = (TryCast(gvProduct.SelectedRow.FindControl("lblBrand"), Label)).Text
        txtDescription.Text = (TryCast(gvProduct.SelectedRow.FindControl("lblDescription"), Label)).Text

        'make invisible Insert button during update/delete 
        btnInsert.Visible = False
    End Sub

    'call to reset all form controls 
    Private Sub ResetAll()
        btnInsert.Visible = True
        txtProductId.Text = ""
        txtProductName.Text = ""
        'txtCategoryID.Text = ""
        txtImageUrl.Text = ""
        txtUnitPrice.Text = ""
        txtColor.Text = ""
        txtSize.Text = ""
        txtBrand.Text = ""
        txtDescription.Text = ""
    End Sub

    Private Sub _Default_PreInit(sender As Object, e As EventArgs) Handles Me.PreInit
        If (Not Session("Theme") Is Nothing) Then
            Page.Theme = Session("Theme").ToString()
        End If
    End Sub

End Class