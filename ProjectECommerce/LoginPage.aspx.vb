
Imports System.Data.SqlClient
Imports System.Data
Imports System.Configuration

Public Class LoginPage
    Inherits System.Web.UI.Page

    Private conn As String = ConfigurationManager.ConnectionStrings("ConnStr").ToString
    Protected Sub Page_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load

    End Sub

    Private Sub btnLogin_Click(sender As Object, e As EventArgs) Handles btnLogin.Click
        If Page.IsValid Then

            Dim bool1 As Boolean = ValidationL()

            If bool1 = True Then
                Dim conStr As String
                Dim userType As Integer = -1
                Dim isBlocked As String = ""

                conStr = ConfigurationManager.ConnectionStrings("ConnStr").ToString

                Dim con As New SqlConnection(conStr)
                Dim cmd As New SqlCommand

                cmd.CommandText = "SELECT userType, isBlocked FROM [Users] WHERE userUsername=@userUsername and userPassword =@userPassword"

                cmd.Parameters.Add("@userUsername", SqlDbType.VarChar).Value = txtUsername.Text
                cmd.Parameters.Add("@userPassword", SqlDbType.VarChar).Value = txtPassword.Text

                cmd.Connection = con
                con.Open()
                Dim da As New SqlDataAdapter(cmd)
                Dim dt As New DataTable()
                da.Fill(dt)

                Dim gv As GridView = New GridView()
                gv.DataSource = dt

                userType = dt.Rows(0)("userType")
                isBlocked = dt.Rows(0)("isBlocked").ToString()



                If isBlocked = "yes" Then
                    Response.Redirect("~/ClientBlockedPage.aspx")

                ElseIf userType = 1 And isBlocked = "no" Then
                    Session("UserName") = txtUsername.Text
                    Response.Redirect("~/AdminHomePage.aspx")

                ElseIf userType = 2 And isBlocked = "no" Then
                    Session("UserName") = txtUsername.Text
                    Response.Redirect("~/ClientHomePage.aspx")

                Else
                    MsgBox("invalid username/Pasword")

                End If

                con.Close()
            Else
                MsgBox("Invalid credentials")
                txtUsername.Text = ""
            End If

        End If
    End Sub

    Public Function ValidationL() As Boolean
        Dim bool As Boolean = False

        Dim sqlCon As New SqlConnection(conn)
        Dim cmd As New SqlCommand
        cmd.CommandText = "SELECT userID FROM Users WHERE userUsername=@userUsername AND userPassword=@userPassword"

        cmd.Parameters.Add("@userUsername", SqlDbType.VarChar).Value = txtUsername.Text
        cmd.Parameters.Add("@userPassword", SqlDbType.VarChar).Value = txtPassword.Text

        cmd.Connection = sqlCon
        sqlCon.Open()

        Dim userID As String = cmd.ExecuteScalar()

        If userID Is Nothing Then
            bool = False
        Else
            bool = True
        End If

        Return bool
        sqlCon.Close()

    End Function


    Private Sub _Default_PreInit(sender As Object, e As EventArgs) Handles Me.PreInit
        If (Not Session("Theme") Is Nothing) Then
            Page.Theme = Session("Theme").ToString()
        End If
    End Sub
End Class