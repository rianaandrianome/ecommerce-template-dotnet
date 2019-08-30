Imports System.Data
Imports System.Configuration
Imports System.Data.SqlClient

Public Class AdminHomePage
    Inherits System.Web.UI.Page

    Private conn As String = ConfigurationManager.ConnectionStrings("ConnStr").ToString

    Protected Sub Page_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load
        labelApplication.Text = ("Number Of Applications: " + Application("Applications").ToString)
        labelSession.Text = ("Number Of User Online: " + Application("Sessions").ToString)

        BindDLLUser()

        If Not IsPostBack Then
            BindUsersData()
            BindGvPayment()
            BindGvReview()

            PanelBlock.Visible = False
            PanelPayment.Visible = False
            PanelReview.Visible = False
        End If



    End Sub


    Sub BindDLLUser()
        ' populate the DDLUsers 
        If Not Me.IsPostBack Then

            Using sqlCon As New SqlConnection(conn)
                Using cmd As New SqlCommand("SELECT * FROM Users")
                    cmd.CommandType = CommandType.Text
                    cmd.Connection = sqlCon
                    Using da As New SqlDataAdapter(cmd)
                        Dim ds As New DataSet()
                        da.Fill(ds)
                        DDLUsers.DataSource = ds.Tables(0)
                        DDLUsers.DataTextField = "userUsername"
                        DDLUsers.DataValueField = "userID"
                        DDLUsers.DataBind()
                    End Using
                End Using
            End Using
            DDLUsers.Items.Insert(0, New ListItem("-- User List --", "0"))
        End If
    End Sub

    Protected Sub DDLUsers_SelectedIndexChanged(sender As Object, e As EventArgs)
        lblUsername.Text = DDLUsers.SelectedItem.Text

        Using sqlCon As New SqlConnection(conn)
            Using cmd As New SqlCommand()
                cmd.CommandText = "SELECT isBlocked FROM Users WHERE userUsername=@userUsername AND userID=@userID"

                cmd.Parameters.AddWithValue("@userUsername", DDLUsers.SelectedItem.Text)
                cmd.Parameters.AddWithValue("@userID", DDLUsers.SelectedItem.Value)

                cmd.Connection = sqlCon
                sqlCon.Open()
                lblBlocked.Text = cmd.ExecuteScalar()

                sqlCon.Close()
            End Using
        End Using

        DDLUsers.ClearSelection()
        BindDLLUser()
    End Sub

    'populate the DDL to chose user 
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

    Sub ResetAll()
        lblUsername.Text = ""
        lblBlocked.Text = ""
    End Sub

    Protected Sub ButtonBlock_Click(sender As Object, e As EventArgs)
        If String.IsNullOrEmpty(lblUsername.Text) Then
            lblMsg.Text = "Please Select user To block"
            lblMsg.ForeColor = System.Drawing.Color.Red
            Return
        End If

        Dim IsUpdated As Boolean = False
        Using sqlCon As New SqlConnection(conn)
            Using cmd As New SqlCommand()
                cmd.CommandText = "UPDATE Users Set isBlocked=@isBlocked WHERE userUsername=@userUsername"

                cmd.Parameters.AddWithValue("@userUsername", lblUsername.Text)
                cmd.Parameters.AddWithValue("@isBlocked", "yes")

                cmd.Connection = sqlCon
                sqlCon.Open()
                IsUpdated = cmd.ExecuteNonQuery() > 0
                sqlCon.Close()
            End Using
        End Using

        If IsUpdated Then
            lblMsg.Text = "User '" & lblUsername.Text & "' blocked successfully!"
            lblMsg.ForeColor = System.Drawing.Color.Green
        Else
            lblMsg.Text = "Error while blocking '" & lblUsername.Text & "'"
            lblMsg.ForeColor = System.Drawing.Color.Red
        End If
        BindUsersData()
        ResetAll()
    End Sub

    Protected Sub ButtonUnblock_Click(sender As Object, e As EventArgs)
        If String.IsNullOrEmpty(lblUsername.Text) Then
            lblMsg.Text = "Please select user to unblock"
            lblMsg.ForeColor = System.Drawing.Color.Red
            Return
        End If

        Dim IsUpdated As Boolean = False
        Using sqlCon As New SqlConnection(conn)
            Using cmd As New SqlCommand()
                cmd.CommandText = "UPDATE Users SET isBlocked=@isBlocked WHERE userUsername=@userUsername"

                cmd.Parameters.AddWithValue("@userUsername", lblUsername.Text)
                cmd.Parameters.AddWithValue("@isBlocked", "no")

                cmd.Connection = sqlCon
                sqlCon.Open()
                IsUpdated = cmd.ExecuteNonQuery() > 0
                sqlCon.Close()
            End Using
        End Using

        If IsUpdated Then
            lblMsg.Text = "User '" & lblUsername.Text & "' unblocked successfully!"
            lblMsg.ForeColor = System.Drawing.Color.Green
        Else
            lblMsg.Text = "Error while unblocking '" & lblUsername.Text & "'"
            lblMsg.ForeColor = System.Drawing.Color.Red
        End If
        BindUsersData()
        ResetAll()
    End Sub

    Sub BindGvPayment()
        Using sqlCon As New SqlConnection(conn)
            Using cmd As New SqlCommand()
                cmd.CommandText = "SELECT product, unitPrice, Cart.userID, quantity, shippingAddress, paymentStatus, userUsername, cartID FROM Cart, Users WHERE Cart.userID=Users.userID"


                cmd.Connection = sqlCon
                sqlCon.Open()
                Dim da As New SqlDataAdapter(cmd)
                Dim dt As New DataTable()
                da.Fill(dt)
                gvApprovePayment.DataSource = dt
                gvApprovePayment.DataBind()
                sqlCon.Close()
            End Using
        End Using
    End Sub

    Protected Sub ButtonApprove_Click(sender As Object, e As EventArgs)

        Dim IsUpdated As Boolean = False
        Using sqlCon As New SqlConnection(conn)
            Using cmd As New SqlCommand()
                cmd.CommandText = "UPDATE Cart Set paymentStatus=@paymentStatus WHERE userID=@userID AND cartID=@cartID"

                cmd.Parameters.AddWithValue("@userID", lblUserID.Text)
                cmd.Parameters.AddWithValue("@cartID", lblCartID.Text)
                cmd.Parameters.AddWithValue("@paymentStatus", "PAID")

                cmd.Connection = sqlCon
                sqlCon.Open()
                IsUpdated = cmd.ExecuteNonQuery() > 0
                sqlCon.Close()
            End Using
        End Using

        If IsUpdated Then
            lblMsg2.Text = "Payment approved successfully!"
            lblMsg2.ForeColor = System.Drawing.Color.Green
        Else
            lblMsg2.Text = "Error while approving payment"
            lblMsg2.ForeColor = System.Drawing.Color.Red
        End If
        BindGvPayment()
        ResetAll()
    End Sub

    Protected Sub ButtonReject_Click(sender As Object, e As EventArgs)
        Dim IsUpdated As Boolean = False
        Using sqlCon As New SqlConnection(conn)
            Using cmd As New SqlCommand()
                cmd.CommandText = "UPDATE Cart Set paymentStatus=@paymentStatus WHERE userID=@userID AND cartID=@cartID"

                cmd.Parameters.AddWithValue("@userID", lblUserID.Text)
                cmd.Parameters.AddWithValue("@cartID", lblCartID.Text)
                cmd.Parameters.AddWithValue("@paymentStatus", "UNPAID")

                cmd.Connection = sqlCon
                sqlCon.Open()
                IsUpdated = cmd.ExecuteNonQuery() > 0
                sqlCon.Close()
            End Using
        End Using

        If IsUpdated Then
            lblMsg2.Text = "Payment rejected"
            lblMsg2.ForeColor = System.Drawing.Color.Green
        Else
            lblMsg2.Text = "Error while rejecting payment"
            lblMsg2.ForeColor = System.Drawing.Color.Red
        End If
        BindGvPayment()
        ResetAll()
    End Sub

    Protected Sub gvApprovePayment_SelectedIndexChanged(sender As Object, e As EventArgs)
        lblUsernameP.Text = (TryCast(gvApprovePayment.SelectedRow.FindControl("labelUsernameGvP"), Label)).Text
        lblPaymentStatusPT.Text = (TryCast(gvApprovePayment.SelectedRow.FindControl("labelPaymentStatusGvP"), Label)).Text
        lblUserID.Text = gvApprovePayment.DataKeys(gvApprovePayment.SelectedRow.RowIndex).Value.ToString()
        lblCartID.Text = (TryCast(gvApprovePayment.SelectedRow.FindControl("labelCartID"), Label)).Text
    End Sub


    Sub BindGvReview()
        Using sqlCon As New SqlConnection(conn)
            Using cmd As New SqlCommand()
                cmd.CommandText = "SELECT * FROM Review"

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

    Protected Sub btnAdminPublish_Click(sender As Object, e As EventArgs)
        ' admin validate a review and set its status to published for it to be displayed in client side 

        Dim IsUpdated As Boolean = False
        Using sqlCon As New SqlConnection(conn)
            Using cmd As New SqlCommand()
                cmd.CommandText = "UPDATE Review SET status=@status WHERE username=@username AND reviewID=@reviewID"

                cmd.Parameters.AddWithValue("@status", "published")
                cmd.Parameters.AddWithValue("@username", lblUsernameReviewPanel.Text)
                cmd.Parameters.AddWithValue("@reviewID", lblReviewIDPanel.Text)

                cmd.Connection = sqlCon
                sqlCon.Open()
                IsUpdated = cmd.ExecuteNonQuery() > 0
                sqlCon.Close()
            End Using
        End Using

        If IsUpdated Then
            lblMsgRP.Text = "Review published successfully!"
            lblMsgRP.ForeColor = System.Drawing.Color.Green
        Else
            lblMsgRP.Text = "Error while publishing review"
            lblMsgRP.ForeColor = System.Drawing.Color.Red
        End If

        BindGvReview()
        ResetAllReviewPanel()
    End Sub

    Protected Sub btnAdminReply_Click(sender As Object, e As EventArgs)
        'admin reply to a review found in gridview 

        Dim IsUpdated As Boolean = False
        Using sqlCon As New SqlConnection(conn)
            Using cmd As New SqlCommand()
                cmd.CommandText = "UPDATE Review SET reply=@reply WHERE username=@username AND reviewID=@reviewID"

                cmd.Parameters.AddWithValue("@reply", txtReplyPanel.Text)
                cmd.Parameters.AddWithValue("@username", lblUsernameReviewPanel.Text)
                cmd.Parameters.AddWithValue("@reviewID", lblReviewIDPanel.Text)

                cmd.Connection = sqlCon
                sqlCon.Open()
                IsUpdated = cmd.ExecuteNonQuery() > 0
                sqlCon.Close()
            End Using
        End Using

        If IsUpdated Then
            lblMsgRP.Text = "Reply posted successfully!"
            lblMsgRP.ForeColor = System.Drawing.Color.Green
        Else
            lblMsgRP.Text = "Error while posting reply"
            lblMsgRP.ForeColor = System.Drawing.Color.Red
        End If

        BindGvReview()
        ResetAllReviewPanel()

    End Sub

    Protected Sub gvReview_SelectedIndexChanged(sender As Object, e As EventArgs)
        lblReviewIDPanel.Text = gvReview.DataKeys(gvReview.SelectedRow.RowIndex).Value.ToString()
        lblUsernameReviewPanel.Text = (TryCast(gvReview.SelectedRow.FindControl("lblUsernameGvReview"), Label)).Text
        lblReviewPanel.Text = (TryCast(gvReview.SelectedRow.FindControl("lblReviewGvReview"), Label)).Text
        txtReplyPanel.Text = (TryCast(gvReview.SelectedRow.FindControl("lblReplyGvReview"), Label)).Text
        lblStatusPanel.Text = (TryCast(gvReview.SelectedRow.FindControl("lblStatusGvReview"), Label)).Text



    End Sub

    Sub ResetAllReviewPanel()
        lblUsernameReviewPanel.Text = ""
        lblReviewPanel.Text = ""
        txtReplyPanel.Text = ""
        lblStatusPanel.Text = ""
    End Sub

    Protected Sub ButtonPanelBlock_Click1(sender As Object, e As EventArgs)
        PanelBlock.Visible = True
        PanelPayment.Visible = False
        PanelReview.Visible = False
    End Sub

    Protected Sub ButtonPanelPayment_Click(sender As Object, e As EventArgs)
        PanelPayment.Visible = True
        PanelBlock.Visible = False
        PanelReview.Visible = False

    End Sub

    Protected Sub ButtonPanelReview_Click(sender As Object, e As EventArgs)
        PanelReview.Visible = True
        PanelBlock.Visible = False
        PanelPayment.Visible = False
    End Sub

    Protected Sub ButtonHide_Click(sender As Object, e As EventArgs)
        PanelBlock.Visible = False
        PanelPayment.Visible = False
        PanelReview.Visible = False
    End Sub

    Private Sub _Default_PreInit(sender As Object, e As EventArgs) Handles Me.PreInit
        If (Not Session("Theme") Is Nothing) Then
            Page.Theme = Session("Theme").ToString()
        End If
    End Sub
End Class