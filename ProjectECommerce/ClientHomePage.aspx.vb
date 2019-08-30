Imports System.Data
Imports System.Configuration
Imports System.Data.SqlClient


Public Class ClientHomePage
    Inherits System.Web.UI.Page


    Private conn As String = ConfigurationManager.ConnectionStrings("ConnStr").ToString
    Dim currentID As String

    Protected Sub Page_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load
        If Not Page.IsPostBack Then

            If Not Session("Username") Is Nothing Then
                FindUserID()
                BindGvPurchases()
                BindGvReview()
            End If
            PanelPurchaseHistory.Visible = False
            PanelReview.Visible = False

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
                lblUserID.Text = currentID

                sqlCon.Close()
            End Using
        End Using
    End Sub

    Sub BindGvPurchases()

        Using sqlCon As New SqlConnection(conn)
                Using cmd As New SqlCommand()
                    cmd.CommandText = "SELECT * FROM Cart where userID=@userID"

                    cmd.Parameters.AddWithValue("@userID", lblUserID.Text)

                    cmd.Connection = sqlCon
                    sqlCon.Open()
                    Dim da As New SqlDataAdapter(cmd)
                    Dim dt As New DataTable()
                    da.Fill(dt)
                    gvPurchase.DataSource = dt
                    gvPurchase.DataBind()
                    sqlCon.Close()
                End Using
            End Using



    End Sub

    Sub BindGvReview()
        Using sqlCon As New SqlConnection(conn)
            Using cmd As New SqlCommand()
                cmd.CommandText = "SELECT * FROM Review WHERE status=@status"

                cmd.Parameters.AddWithValue("@status", "published")
                cmd.Connection = sqlCon
                sqlCon.Open()
                Dim da As New SqlDataAdapter(cmd)
                Dim dt As New DataTable()
                da.Fill(dt)
                gvReview.DataSource = dt
                gvReview.DataBind()
                sqlCon.Close()

            End Using
        End Using
    End Sub

    Protected Sub gvReview_SelectedIndexChanged(sender As Object, e As EventArgs)
        txtReview.Text = (TryCast(gvReview.SelectedRow.FindControl("lblReview"), Label)).Text
        lblReviewIDH.Text = (TryCast(gvReview.SelectedRow.FindControl("lblReviewID"), Label)).Text
    End Sub

    Protected Sub btnAddReply_Click(sender As Object, e As EventArgs)

        If Not Session("Username") Is Nothing Then
            Dim IsUpdated As Boolean = False
            Using sqlCon As New SqlConnection(conn)
                Using cmd As New SqlCommand()
                    cmd.CommandText = "UPDATE Review SET reply=@reply WHERE reviewID=@reviewID"

                    cmd.Parameters.AddWithValue("@reply", txtReply.Text)
                    cmd.Parameters.AddWithValue("@reviewID", lblReviewIDH.Text)

                    cmd.Connection = sqlCon
                    sqlCon.Open()
                    IsUpdated = cmd.ExecuteNonQuery() > 0
                    sqlCon.Close()
                End Using
            End Using
            If IsUpdated Then
                lblMsgR.Text = "Replied successfully!"
                lblMsgR.ForeColor = System.Drawing.Color.Green
            Else
                lblMsgR.Text = "Error during replying"
                lblMsgR.ForeColor = System.Drawing.Color.Red
            End If

            BindGvReview()
            ResetAllPanelReview()
        Else
            MsgBox("Please login to be able to reply")
        End If



    End Sub

    Protected Sub btnAddReview_Click(sender As Object, e As EventArgs)
        If Not Session("Username") Is Nothing Then

            Dim IsAdded As Boolean = False

            Using sqlCon As New SqlConnection(conn)
                Using cmd As New SqlCommand()
                    cmd.CommandText = "INSERT INTO Review(review, status, reply, username) VALUES(@review, @status, @reply, @username)"

                    cmd.Parameters.AddWithValue("@review", txtReview.Text)
                    cmd.Parameters.AddWithValue("@status", "Unpublished")
                    cmd.Parameters.AddWithValue("@reply", "")
                    cmd.Parameters.AddWithValue("@username", Session("Username"))

                    cmd.Connection = sqlCon
                    sqlCon.Open()
                    IsAdded = cmd.ExecuteNonQuery() > 0
                    sqlCon.Close()
                End Using
            End Using

            If IsAdded Then
                lblMsgR.Text = "Review Submitted successfully!"
                lblMsgR.ForeColor = System.Drawing.Color.Green

            Else
                lblMsgR.Text = "Error while adding review"
                lblMsgR.ForeColor = System.Drawing.Color.Red
            End If
            BindGvReview()
            ResetAllPanelReview() 'to reset all form controls 
        Else
            MsgBox("Please login to be able to add a review")
        End If



    End Sub

    Sub ResetAllPanelReview()
        txtReply.Text = ""
        txtReview.Text = ""
    End Sub

    Protected Sub ButtonPurchaseHistory_Click(sender As Object, e As EventArgs)
        If Session("Username") Is Nothing Then
            MsgBox("Please Login to view your purchase history")
        Else
            PanelPurchaseHistory.Visible = True
            PanelReview.Visible = False
        End If

    End Sub

    Protected Sub ButtonReview_Click(sender As Object, e As EventArgs)
        PanelPurchaseHistory.Visible = False
        PanelReview.Visible = True
    End Sub

    Protected Sub ButtonHide_Click(sender As Object, e As EventArgs)
        PanelPurchaseHistory.Visible = False
        PanelReview.Visible = False
    End Sub

    Private Sub _Default_PreInit(sender As Object, e As EventArgs) Handles Me.PreInit
        If (Not Session("Theme") Is Nothing) Then
            Page.Theme = Session("Theme").ToString()
        End If
    End Sub
End Class