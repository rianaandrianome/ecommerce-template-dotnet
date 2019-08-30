
Imports System.Data
Imports System.Configuration
Imports System.Data.SqlClient


Public Class ClientProductPage
    Inherits System.Web.UI.Page


    Dim CurrentPageIndex As Integer
    Private conn As String = ConfigurationManager.ConnectionStrings("ConnStr").ToString

    Protected Sub Page_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load
        BindAll()
        If Not IsPostBack Then
            BindAll()


            If Not Session("Username") Is Nothing Then
                FindUserID()
            Else
                HyperLink1.Visible = False

            End If


        End If

        ' populate the DDLCategory
        If Not Me.IsPostBack Then
            Dim constrCat As String = ConfigurationManager.ConnectionStrings("ConnStr").ConnectionString
            Using connCat As New SqlConnection(constrCat)
                Using cmdCat As New SqlCommand("SELECT categoryID, categoryName FROM Category")
                    cmdCat.CommandType = CommandType.Text
                    cmdCat.Connection = connCat
                    Using daCat As New SqlDataAdapter(cmdCat)
                        Dim dsCat As New DataSet()
                        daCat.Fill(dsCat)
                        DDLCategory.DataSource = dsCat.Tables(0)
                        DDLCategory.DataTextField = "categoryName"
                        DDLCategory.DataValueField = "categoryID"
                        DDLCategory.DataBind()
                    End Using
                End Using
            End Using
            DDLCategory.Items.Insert(0, New ListItem("--Filter By Category--", "0"))
        End If

        ' populate the DDLBrand 
        If Not Me.IsPostBack Then
            Dim constrBrand As String = ConfigurationManager.ConnectionStrings("ConnStr").ConnectionString
            Using connBrand As New SqlConnection(constrBrand)
                Using cmdBrand As New SqlCommand("SELECT DISTINCT brand FROM Product")
                    cmdBrand.CommandType = CommandType.Text
                    cmdBrand.Connection = connBrand
                    Using daBrand As New SqlDataAdapter(cmdBrand)
                        Dim dsBrand As New DataSet()
                        daBrand.Fill(dsBrand)
                        DDLBrand.DataSource = dsBrand.Tables(0)
                        DDLBrand.DataTextField = "brand"
                        DDLBrand.DataValueField = "brand"
                        DDLBrand.DataBind()
                    End Using
                End Using
            End Using
            DDLBrand.Items.Insert(0, New ListItem("--Filter By Brand--", "0"))
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
                Dim currentUserID As String = cmd.ExecuteScalar()
                txtUserID.Text = currentUserID
                Session("userID") = currentUserID

                sqlCon.Close()
            End Using
        End Using
    End Sub

    ' bind all 
    Public Sub BindAll()
        Dim conString As String = ConfigurationManager.ConnectionStrings("ConnStr").ConnectionString
        Dim query As String = "SELECT * FROM Product"
        Dim cmd As SqlCommand = New SqlCommand(query)

        Dim con As SqlConnection = New SqlConnection(conString)
        Dim sda As SqlDataAdapter = New SqlDataAdapter
        cmd.Connection = con
        sda.SelectCommand = cmd
        Dim ds As DataSet = New DataSet
        sda.Fill(ds)
        Datalist1.DataSource = ds
        Datalist1.DataBind()
    End Sub

    'bind with filter category
    Public Sub BindCat()
        Dim conString As String = ConfigurationManager.ConnectionStrings("ConnStr").ConnectionString
        Dim query As String = "SELECT top 10 * FROM Product WHERE categoryID=@categoryID or @categoryID=''"
        Dim cmd As SqlCommand = New SqlCommand(query)
        cmd.Parameters.AddWithValue("@categoryID", DDLCategory.SelectedItem.Value)
        Dim con As SqlConnection = New SqlConnection(conString)
        Dim sda As SqlDataAdapter = New SqlDataAdapter
        cmd.Connection = con
        sda.SelectCommand = cmd
        Dim ds As DataSet = New DataSet
        sda.Fill(ds)
        Datalist1.DataSource = ds
        Datalist1.DataBind()
    End Sub

    'bind with filter brand
    Public Sub BindBrand()
        Dim conString As String = ConfigurationManager.ConnectionStrings("ConnStr").ConnectionString
        Dim query As String = "SELECT top 10 * FROM Product WHERE brand=@brand or @brand=''"
        Dim cmd As SqlCommand = New SqlCommand(query)
        cmd.Parameters.AddWithValue("@brand", DDLBrand.SelectedItem.Text)
        Dim con As SqlConnection = New SqlConnection(conString)
        Dim sda As SqlDataAdapter = New SqlDataAdapter
        cmd.Connection = con
        sda.SelectCommand = cmd
        Dim ds As DataSet = New DataSet
        sda.Fill(ds)
        Datalist1.DataSource = ds
        Datalist1.DataBind()
    End Sub

    Public Sub BindPrice()

        Dim min As Decimal
        Dim max As Decimal

        Select Case DDLPrice.SelectedItem.Value
            Case 1
                min = 1
                max = 1000
            Case 2
                min = 1000
                max = 5000
            Case 3
                min = 5000
                max = 10000
            Case 4
                min = 10000
                max = 20000
            Case 5
                min = 20000
                max = 50000
            Case Else
                DDLPrice.ClearSelection()
        End Select

        Dim conString As String = ConfigurationManager.ConnectionStrings("ConnStr").ConnectionString
        Dim query As String = " SELECT * FROM Product WHERE unitPrice BETWEEN @min and @max"
        Dim cmd As SqlCommand = New SqlCommand(query)
        cmd.Parameters.AddWithValue("@min", min)
        cmd.Parameters.AddWithValue("@max", max)
        Dim con As SqlConnection = New SqlConnection(conString)
        Dim sda As SqlDataAdapter = New SqlDataAdapter
        cmd.Connection = con
        sda.SelectCommand = cmd
        Dim ds As DataSet = New DataSet
        sda.Fill(ds)
        Datalist1.DataSource = ds
        Datalist1.DataBind()
    End Sub

    Protected Sub btnShowAll_Click(sender As Object, e As EventArgs)
        DDLCategory.ClearSelection()
        DDLBrand.ClearSelection()
        DDLPrice.ClearSelection()
        BindAll()
    End Sub

    Protected Sub DDLCategory_SelectedIndexChanged(sender As Object, e As EventArgs)
        BindCat()
    End Sub

    Protected Sub DDLBrand_SelectedIndexChanged(sender As Object, e As EventArgs)
        BindBrand()
    End Sub

    Protected Sub DDLPrice_SelectedIndexChanged(sender As Object, e As EventArgs)
        BindPrice()
    End Sub

    Private Sub _Default_PreInit(sender As Object, e As EventArgs) Handles Me.PreInit
        If (Not Session("Theme") Is Nothing) Then
            Page.Theme = Session("Theme").ToString()
        End If
    End Sub


End Class