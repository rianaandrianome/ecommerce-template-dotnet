

Imports System.Data.SqlClient
Imports System.Data
Imports System.Configuration


Public Class Registration
    Inherits System.Web.UI.Page

    Protected Sub Page_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load


        Dim Ds As New DataSet
        Dim physicalPath As String = Server.MapPath("xml/stateXMLFile.xml")
        Ds.ReadXml(physicalPath)
        stateDropDownList.DataTextField = "countryName"
        stateDropDownList.DataValueField = "countryCode"
        stateDropDownList.DataSource = Ds
        stateDropDownList.DataBind()
        Dim li As New ListItem("Select", "-1")
        stateDropDownList.Items.Insert(0, li)


    End Sub

    Private Sub buttonRegister_Click(sender As Object, e As EventArgs) Handles buttonRegister.Click

        If Page.IsValid Then
            Dim con As New SqlConnection
            con.ConnectionString = ConfigurationManager.ConnectionStrings("ConnStr").ToString
            con.Open()
            Dim cmd As New SqlCommand
            cmd.Connection = con

            cmd.CommandText = "insert into [Users]
                                                            (userLastName,
                                                            userFirstName, 
                                                            userGender, 
                                                            userDateOfBirth, 
                                                            userAddress, 
                                                            userCity, 
                                                            userState, 
                                                            userZip, 
                                                            userPhone, 
                                                            userEmail,
                                                            userUsername, 
                                                            userPassword, isBlocked) 
                                               values
                                                            (@userLastName,
                                                            @userFirstName, 
                                                            @userGender, 
                                                            @userDateOfBirth, 
                                                            @userAddress, 
                                                            @userCity, 
                                                            @userState, 
                                                            @userZip, 
                                                            @userPhone, 
                                                            @userEmail,
                                                            @userUsername, 
                                                            @userPassword, @isBlocked)"


            cmd.Parameters.AddWithValue("@userLastName", txtLastName.Text)
            cmd.Parameters.AddWithValue("@userFirstName", txtFirstName.Text)
            If RadioButtonMale.Checked = True Then
                cmd.Parameters.AddWithValue("@userGender", RadioButtonMale.Text)
            End If
            If RadioButtonFemale.Checked = True Then
                cmd.Parameters.AddWithValue("@userGender", RadioButtonFemale.Text)
            End If
            cmd.Parameters.AddWithValue("@userDateOfBirth", txtDateOfBirth.Text)
            cmd.Parameters.AddWithValue("@userAddress", txtAddress.Text)
            cmd.Parameters.AddWithValue("@userCity", txtCity.Text)
            cmd.Parameters.AddWithValue("@userState", stateDropDownList.DataValueField)
            cmd.Parameters.AddWithValue("@userZip", txtZip.Text)
            cmd.Parameters.AddWithValue("@userPhone", txtPhone.Text)
            cmd.Parameters.AddWithValue("@userEmail", txtEmail.Text)
            cmd.Parameters.AddWithValue("@userUsername", txtUsername.Text)
            cmd.Parameters.AddWithValue("@userPassword", txtPassword.Text)
            cmd.Parameters.AddWithValue("@isBlocked", "no")

            cmd.ExecuteNonQuery()
            Label1.Text = "Registion Successful"
            Response.Redirect("~/LoginPage.aspx")
        Else
            Label1.Text = "Registration Failed"
        End If

    End Sub

    Private Sub _Default_PreInit(sender As Object, e As EventArgs) Handles Me.PreInit
        If (Not Session("Theme") Is Nothing) Then
            Page.Theme = Session("Theme").ToString()
        End If
    End Sub
End Class