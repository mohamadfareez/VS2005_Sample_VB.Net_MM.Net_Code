Imports System
Imports System.Collections
Imports System.ComponentModel
Imports System.Data
Imports System.Drawing
Imports System.Web
Imports System.Web.SessionState
Imports System.Web.UI
Imports System.Web.UI.WebControls
Imports System.Web.UI.HtmlControls

Imports OakLeaf.MM.Main
Imports OakLeaf.MM.Main.Web.UI
Imports OakLeaf.MM.Main.Business
Imports OakLeaf.MM.Main.Patterns
Imports OakLeaf.MM.Main.Web.UI.WebControls

Public Class UserLogin
    Inherits mmBaseUserLogin

    ''' <summary>
    ''' Page Load handler
    ''' </summary>
    Protected Sub Page_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load
        Me.FocusedControl = Me.txtUsername
        Me.PageCaption.InnerText = Me.GetMessage("Application User Login")
    End Sub

    ''' <summary>
    ''' Login button handler
    ''' </summary>
    Protected Sub btnLogin_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnLogin.Click
        Me.Username = Me.txtUsername.Text
        Me.Password = Me.txtPassword.Text
        If (Not Me.Login()) Then
            Me.lblErrorMessage.Text = Me.ErrorMessage
        End If
    End Sub

    ''' <summary>
    ''' Log out button handler
    ''' </summary>
    Protected Sub btnLogout_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnLogout.Click
        mmBaseUserLogin.Logout(Me.Context)
        Me.lblErrorMessage.Text = Me.GetMessage("This computer is no longer logged in")
    End Sub

    Public Overrides Sub HookUserAuthenticated(ByVal userPK As Object)
        Me.Response.Redirect("Listing.aspx")
    End Sub
End Class
