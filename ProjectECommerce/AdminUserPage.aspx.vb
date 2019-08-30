
Imports System.Data.SqlClient
Imports System.Data
Imports System.Configuration


Public Class AdminUserPage
    Inherits System.Web.UI.Page

    Private conn As String = ConfigurationManager.ConnectionStrings("ConnStr").ToString


    Protected Sub Page_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load
        lblMsg.Text = ""
        If Not IsPostBack Then
            BindUsersData()
        End If

        ' re initialise the ddl selected item
        If (Not IsPostBack) Then

            fillCountry()
        End If


    End Sub

    'fill country DDL 
    Sub fillCountry()
        'bind dropdownlist with xml file
        Dim Ds As New DataSet
        Dim physicalPath As String = Server.MapPath("xml/stateXMLFile.xml")
        Ds.ReadXml(physicalPath)

        stateDropDownList.DataTextField = "countryName"
        stateDropDownList.DataValueField = "countryCode"
        stateDropDownList.DataSource = Ds
        stateDropDownList.DataBind()

        Dim li As New ListItem
        stateDropDownList.Items.Insert(0, li)

    End Sub


    'call this method to bind gridview 
    Private Sub BindUsersData()
        Using sqlCon As New SqlConnection(conn)
            Using cmd As New SqlCommand()
                cmd.CommandText = "SELECT * FROM Users"
                cmd.Connection = sqlCon
                sqlCon.Open()
                Dim da As New SqlDataAdapter(cmd)
                Dim dt As New DataTable()
                da.Fill(dt)
                gvUsers.DataSource = dt
                gvUsers.DataBind()
                sqlCon.Close()
            End Using
        End Using
    End Sub


    'Insert click event to insert new record to database 
    Protected Sub btnInsert_Click(ByVal sender As Object, ByVal e As EventArgs)
        Dim IsAdded As Boolean = False

        Dim userLastName As String = txtLastName.Text.Trim()
        Dim userFirstName As String = txtFirstName.Text.Trim()

        Dim userGender As String = ""

        If RadioButtonMale.Checked = True Then
            userGender = RadioButtonMale.Text.Trim()
        End If
        If RadioButtonFemale.Checked = True Then
            userGender = RadioButtonFemale.Text.Trim()
        End If

        Dim userDateOfBirth As String = txtDateOfBirth.Text.Trim()
        Dim userAddress As String = txtAddress.Text.Trim()
        Dim userCity As String = txtCity.Text.Trim()
        Dim userState As String = stateDropDownList.SelectedItem.Text

        Dim userZip As String = txtZip.Text.Trim()
        Dim userPhone As String = txtPhone.Text.Trim()
        Dim userEmail As String = txtEmail.Text.Trim()
        Dim userUsername As String = txtUsername.Text.Trim()
        Dim userPassword As String = txtPassword.Text.Trim()

        Using sqlCon As New SqlConnection(conn)
            Using cmd As New SqlCommand()
                cmd.CommandText = "INSERT INTO Users(userLastName, userFirstName, userGender, userDateOfBirth, userAddress, userCity, userState, userZip, userPhone, userEmail, userUsername, userPassword, isBlocked) VALUES(@userLastName, @userFirstName, @userGender, @userDateOfBirth, @userAddress, @userCity, @userState, @userZip, @userPhone, @userEmail, @userUsername, @userPassword, @isBlocked)"

                cmd.Parameters.AddWithValue("@userLastName", userLastName)
                cmd.Parameters.AddWithValue("@userFirstName", userFirstName)
                cmd.Parameters.AddWithValue("@userGender", userGender)
                cmd.Parameters.AddWithValue("@userDateOfBirth", userDateOfBirth)
                cmd.Parameters.AddWithValue("@userAddress", userAddress)
                cmd.Parameters.AddWithValue("@userCity", userCity)
                cmd.Parameters.AddWithValue("@userState", userState)
                cmd.Parameters.AddWithValue("@userZip", userZip)
                cmd.Parameters.AddWithValue("@userPhone", userPhone)
                cmd.Parameters.AddWithValue("@userEmail", userEmail)
                cmd.Parameters.AddWithValue("@userUsername", userUsername)
                cmd.Parameters.AddWithValue("@userPassword", userPassword)
                cmd.Parameters.AddWithValue("@isBlocked", "no")

                cmd.Connection = sqlCon
                sqlCon.Open()
                IsAdded = cmd.ExecuteNonQuery() > 0
                sqlCon.Close()
            End Using
        End Using
        If IsAdded Then
            lblMsg.Text = "'" & userLastName & "' user added successfully!"
            lblMsg.ForeColor = System.Drawing.Color.Green

            BindUsersData()
        Else
            lblMsg.Text = "Error while adding '" & userLastName & "' details"
            lblMsg.ForeColor = System.Drawing.Color.Red
        End If
        ResetAll() 'to reset all form controls 
    End Sub

    'Update click event to update existing record from the gridview 
    Protected Sub btnUpdate_Click(ByVal sender As Object, ByVal e As EventArgs)
        If String.IsNullOrEmpty(txtUserID.Text) Then
            lblMsg.Text = "Please select record to update"
            lblMsg.ForeColor = System.Drawing.Color.Red
            Return
        End If
        Dim IsUpdated As Boolean = False

        Dim userID As Integer = Convert.ToInt32(txtUserID.Text)
        Dim userLastName As String = txtLastName.Text.Trim()
        Dim userFirstName As String = txtFirstName.Text.Trim()

        Dim userGender As String = ""

        If RadioButtonMale.Checked = True Then
            userGender = RadioButtonMale.Text
        End If
        If RadioButtonFemale.Checked = True Then
            userGender = RadioButtonFemale.Text
        End If

        Dim userDateOfBirth As String = txtDateOfBirth.Text.Trim()
        Dim userAddress As String = txtAddress.Text.Trim()
        Dim userCity As String = txtCity.Text.Trim()

        Dim userState As String = stateDropDownList.SelectedItem.Text
        Dim userZip As String = txtZip.Text.Trim()
        Dim userPhone As String = txtPhone.Text.Trim()
        Dim userEmail As String = txtEmail.Text.Trim()
        Dim userUsername As String = txtUsername.Text.Trim()
        Dim userPassword As String = txtPassword.Text.Trim()

        Using sqlCon As New SqlConnection(conn)
            Using cmd As New SqlCommand()

                cmd.CommandText = "UPDATE Users SET userLastName=@userLastName, userFirstName=@userFirstName, userGender=@userGender, userDateOfBirth=@userDateOfBirth, userAddress=@userAddress, userCity=@userCity, userState=@userState, userZip=@userZip, userPhone=@userPhone, userEmail=@userEmail, userUsername=@userUsername, userPassword=@userPassword  WHERE userID=@userID"

                cmd.Parameters.AddWithValue("@userID", UserID)
                cmd.Parameters.AddWithValue("@userLastName", userLastName)
                cmd.Parameters.AddWithValue("@userFirstName", userFirstName)
                cmd.Parameters.AddWithValue("@userGender", userGender)
                cmd.Parameters.AddWithValue("@userDateOfBirth", userDateOfBirth)
                cmd.Parameters.AddWithValue("@userAddress", userAddress)
                cmd.Parameters.AddWithValue("@userCity", userCity)
                cmd.Parameters.AddWithValue("@userState", userState)
                cmd.Parameters.AddWithValue("@userZip", userZip)
                cmd.Parameters.AddWithValue("@userPhone", userPhone)
                cmd.Parameters.AddWithValue("@userEmail", userEmail)
                cmd.Parameters.AddWithValue("@userUsername", userUsername)
                cmd.Parameters.AddWithValue("@userPassword", userPassword)

                cmd.Connection = sqlCon
                sqlCon.Open()
                IsUpdated = cmd.ExecuteNonQuery() > 0
                sqlCon.Close()
            End Using
        End Using
        If IsUpdated Then
            lblMsg.Text = "'" & userLastName & "' user updated successfully!"
            lblMsg.ForeColor = System.Drawing.Color.Green
        Else
            lblMsg.Text = "Error while updating '" & userLastName & "' subject details"
            lblMsg.ForeColor = System.Drawing.Color.Red
        End If
        gvUsers.EditIndex = -1
        BindUsersData()
        ResetAll() 'to reset all form controls 
    End Sub


    'Delete click event to delete selected record from the database 
    Protected Sub btnDelete_Click(ByVal sender As Object, ByVal e As EventArgs)
        If String.IsNullOrEmpty(txtUserID.Text) Then
            lblMsg.Text = "Please select record to delete"
            lblMsg.ForeColor = System.Drawing.Color.Red
            Return
        End If
        Dim IsDeleted As Boolean = False

        Dim userID As Integer = Convert.ToInt32(txtUserID.Text)
        Dim userLastName As String = txtLastName.Text.Trim()
        Dim userFirstName As String = txtFirstName.Text.Trim()

        Dim userGender As String = ""

        If RadioButtonMale.Checked = True Then
            userGender = RadioButtonMale.Text
        End If
        If RadioButtonFemale.Checked = True Then
            userGender = RadioButtonFemale.Text
        End If

        Dim userDateOfBirth As String = txtDateOfBirth.Text.Trim()
        Dim userAddress As String = txtAddress.Text.Trim()
        Dim userCity As String = txtCity.Text.Trim()

        Dim userState As String = stateDropDownList.SelectedItem.Text

        Dim userZip As String = txtZip.Text.Trim()
        Dim userPhone As String = txtPhone.Text.Trim()
        Dim userEmail As String = txtEmail.Text.Trim()
        Dim userUsername As String = txtUsername.Text.Trim()
        Dim userPassword As String = txtPassword.Text.Trim()

        Using sqlCon As New SqlConnection(conn)
            Using cmd As New SqlCommand()
                cmd.CommandText = "DELETE FROM Users WHERE userID=@userID"
                cmd.Parameters.AddWithValue("@userID", userID)
                cmd.Connection = sqlCon
                sqlCon.Open()
                IsDeleted = cmd.ExecuteNonQuery() > 0
                sqlCon.Close()
            End Using
        End Using
        If IsDeleted Then
            lblMsg.Text = "'" & userLastName & "' user deleted successfully!"
            lblMsg.ForeColor = System.Drawing.Color.Green
            BindUsersData()
        Else
            lblMsg.Text = "Error while deleting '" & userLastName & "' details"
            lblMsg.ForeColor = System.Drawing.Color.Red
        End If
        ResetAll() 'to reset all form controls 
    End Sub

    'Cancel click event to clear and reset all the textboxes 
    Protected Sub btnCancel_Click(ByVal sender As Object, ByVal e As EventArgs)
        ResetAll() 'to reset all form controls 
    End Sub

    ' select elements in the gridview row
    Protected Sub gvUsers_SelectedIndexChanged(ByVal sender As Object, ByVal e As EventArgs)
        txtUserID.Text = gvUsers.DataKeys(gvUsers.SelectedRow.RowIndex).Value.ToString()
        txtLastName.Text = (TryCast(gvUsers.SelectedRow.FindControl("labelLastName"), Label)).Text
        txtFirstName.Text = (TryCast(gvUsers.SelectedRow.FindControl("labelFirstName"), Label)).Text

        Dim gender As String = (TryCast(gvUsers.SelectedRow.FindControl("labelGender"), Label)).Text
        If gender = "Male" Then
            RadioButtonMale.Checked = True
        ElseIf gender = "Female" Then
            RadioButtonFemale.Checked = True
        End If

        txtDateOfBirth.Text = (TryCast(gvUsers.SelectedRow.FindControl("labelDateOfBirth"), Label)).Text

        txtAddress.Text = (TryCast(gvUsers.SelectedRow.FindControl("labelAddress"), Label)).Text
        txtCity.Text = (TryCast(gvUsers.SelectedRow.FindControl("labelCity"), Label)).Text

        stateDropDownList.SelectedItem.Text = (TryCast(gvUsers.SelectedRow.FindControl("labelState"), Label)).Text

        txtZip.Text = (TryCast(gvUsers.SelectedRow.FindControl("labelZip"), Label)).Text
        txtPhone.Text = (TryCast(gvUsers.SelectedRow.FindControl("labelPhone"), Label)).Text
        txtEmail.Text = (TryCast(gvUsers.SelectedRow.FindControl("labelEmail"), Label)).Text
        txtUsername.Text = (TryCast(gvUsers.SelectedRow.FindControl("labelUsername"), Label)).Text
        txtPassword.Text = (TryCast(gvUsers.SelectedRow.FindControl("labelPassword"), Label)).Text

        'make invisible Insert button during update/delete 
        btnInsert.Visible = False
    End Sub

    'call to reset all form controls 
    Private Sub ResetAll()
        btnInsert.Visible = True
        txtUserID.Text = ""
        txtLastName.Text = ""
        txtFirstName.Text = ""
        'txtGender.Text = ""
        txtDateOfBirth.Text = ""
        txtAddress.Text = ""
        txtCity.Text = ""
        'txtState.Text = ""
        txtZip.Text = ""
        txtPhone.Text = ""
        txtEmail.Text = ""
        txtUsername.Text = ""
        txtPassword.Text = ""

    End Sub

    Private Sub _Default_PreInit(sender As Object, e As EventArgs) Handles Me.PreInit
        If (Not Session("Theme") Is Nothing) Then
            Page.Theme = Session("Theme").ToString()
        End If
    End Sub
End Class