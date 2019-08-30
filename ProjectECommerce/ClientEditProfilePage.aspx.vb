Imports System.Data.SqlClient
Imports System.Data
Imports System.Configuration

Public Class ClientEditProfilePage
    Inherits System.Web.UI.Page

    Private conn As String = ConfigurationManager.ConnectionStrings("ConnStr").ToString



    Protected Sub Page_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load

        ' to avoid error invalid call back and post back problem 
        If Not IsPostBack Then
            If Not Session("Username") Is Nothing Then
                FindUserID()
            End If
            BindAll()
        End If

    End Sub

    ' Populate the textboxes of the Datalist with user data  
    Public Sub BindAll()
        Dim conString As String = ConfigurationManager.ConnectionStrings("ConnStr").ConnectionString
        Dim query As String = "SELECT * FROM Users WHERE userID=@userID"
        Dim cmd As SqlCommand = New SqlCommand(query)

        cmd.Parameters.AddWithValue("@userID", Label1.Text)
        Dim con As SqlConnection = New SqlConnection(conString)
        Dim sda As SqlDataAdapter = New SqlDataAdapter
        cmd.Connection = con
        sda.SelectCommand = cmd
        Dim ds As DataSet = New DataSet
        sda.Fill(ds)
        Datalist1.DataSource = ds
        Datalist1.DataBind()
    End Sub

    ' find the current userID and place its value in Label 1
    Private Sub FindUserID()
        Dim currentUserName As String = Session("Username")

        Using sqlCon As New SqlConnection(conn)
            Using cmd As New SqlCommand()

                cmd.CommandText = "SELECT userID FROM [Users] WHERE userUsername=@currentUserName"
                cmd.Parameters.AddWithValue("@currentUserName", currentUserName)
                cmd.Connection = sqlCon
                sqlCon.Open()
                Dim currentUserID As String = cmd.ExecuteScalar()
                Label1.Text = currentUserID.ToString
                Session("userID") = currentUserID

                sqlCon.Close()
            End Using
        End Using
    End Sub

    ' take the values in the datalist, update them, and write them in table Users
    Protected Sub btnEditProfile_Click(sender As Object, e As EventArgs)
        ' for validation verification  
        If Page.IsValid Then

            ' retreive values from the Datalist 
            Dim lastName As String = DirectCast(Datalist1.Controls(0).FindControl("txtLastName"), TextBox).Text
            Dim firstName As String = DirectCast(Datalist1.Controls(0).FindControl("txtFirstName"), TextBox).Text
            Dim gender As String = DirectCast(Datalist1.Controls(0).FindControl("txtGender"), TextBox).Text

            Dim dateOfBirth As Date = Date.Parse(DirectCast(Datalist1.Controls(0).FindControl("txtDateOfBirth"), TextBox).Text)
            Dim address As String = DirectCast(Datalist1.Controls(0).FindControl("txtAddress"), TextBox).Text
            Dim city As String = DirectCast(Datalist1.Controls(0).FindControl("txtCity"), TextBox).Text
            Dim state As String = DirectCast(Datalist1.Controls(0).FindControl("txtState"), TextBox).Text
            Dim zip As String = DirectCast(Datalist1.Controls(0).FindControl("txtZip"), TextBox).Text
            Dim phone As String = DirectCast(Datalist1.Controls(0).FindControl("txtPhone"), TextBox).Text
            Dim email As String = DirectCast(Datalist1.Controls(0).FindControl("txtEmail"), TextBox).Text
            Dim username As String = DirectCast(Datalist1.Controls(0).FindControl("txtUsername"), TextBox).Text
            Dim password As String = DirectCast(Datalist1.Controls(0).FindControl("txtPassword"), TextBox).Text

            Dim con As New SqlConnection
            con.ConnectionString = ConfigurationManager.ConnectionStrings("ConnStr").ToString
            con.Open()
            Dim cmd As New SqlCommand
            cmd.Connection = con

            'update the values in Users table
            cmd.CommandText = "UPDATE [Users] SET userLastName=@userLastName, userFirstName=@userFirstName, userGender=@userGender, userDateOfBirth=@userDateOfBirth, userAddress=@userAddress, userCity=@userCity, userState=@userState, userZip=@userZip, userPhone=@userPhone, userEmail=@userEmail, userUsername=@userUsername, userPassword=@userPassword WHERE userID=@userID"

            cmd.Parameters.AddWithValue("@userID", Label1.Text)
            cmd.Parameters.AddWithValue("@userLastName", lastName)
            cmd.Parameters.AddWithValue("@userFirstName", firstName)
            cmd.Parameters.AddWithValue("@userGender", gender)
            cmd.Parameters.AddWithValue("@userDateOfBirth", dateOfBirth)
            cmd.Parameters.AddWithValue("@userAddress", address)
            cmd.Parameters.AddWithValue("@userCity", city)
            cmd.Parameters.AddWithValue("@userState", state)
            cmd.Parameters.AddWithValue("@userZip", zip)
            cmd.Parameters.AddWithValue("@userPhone", phone)
            cmd.Parameters.AddWithValue("@userEmail", email)
            cmd.Parameters.AddWithValue("@userUsername", username)
            cmd.Parameters.AddWithValue("@userPassword", password)


            cmd.ExecuteNonQuery()
            Label2.Text = "Update Successful"

        Else
            Label2.Text = "Failed to update"
        End If

    End Sub

    Private Sub _Default_PreInit(sender As Object, e As EventArgs) Handles Me.PreInit
        If (Not Session("Theme") Is Nothing) Then
            Page.Theme = Session("Theme").ToString()
        End If
    End Sub
End Class