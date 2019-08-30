Public Class AdminMasterPage
    Inherits System.Web.UI.MasterPage

    Protected Sub Page_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load

        lblWelcome.Text = "Welcome " + Session("Username")
        ImageButtonSign.ImageUrl = "~/images/signOutButton.png"

    End Sub

    Private Sub ImageButtonSign_Click(sender As Object, e As ImageClickEventArgs) Handles ImageButtonSign.Click
        If Not Session("Username") Is Nothing Then
            Session.Remove("Username")

            FormsAuthentication.SignOut()
            Session.Abandon()
            ' Clear the authentication cookie
            Dim c As New HttpCookie(FormsAuthentication.FormsCookieName, "")
            c.Expires = DateTime.Now.AddYears(-1)
            Response.Cookies.Add(c)

            'successful login
            Response.Redirect("~/ClientHomePage.aspx")
        Else
            'unsuccessful login
            Response.Redirect("~/LoginPage.aspx")
        End If
    End Sub


    Protected Sub ImageButtonEditProfile_Click(sender As Object, e As ImageClickEventArgs) Handles ImageButtonEditProfile.Click
        Response.Redirect("~/ClientEditProfilePage.aspx")
    End Sub

    Protected Sub btnBlue_Click(sender As Object, e As EventArgs) Handles btnBlue.Click
        Session("Theme") = "BlueTheme"
        Server.Transfer(Request.FilePath)
    End Sub

    Protected Sub btnRed_Click(sender As Object, e As EventArgs)
        Session("Theme") = "RedTheme"
        Server.Transfer(Request.FilePath)
    End Sub

    Protected Sub btnDefault_Click(sender As Object, e As EventArgs)
        Session("Theme") = "DefaultTheme"
        Server.Transfer(Request.FilePath)
    End Sub

End Class