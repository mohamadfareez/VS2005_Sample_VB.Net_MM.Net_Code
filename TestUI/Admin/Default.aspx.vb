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

Partial Class _Default
    Inherits mmBaseWebPage

    Protected SecurityAdminLoggedIn As Boolean = False

    Protected Sub Page_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load

        Me.PageCaption.InnerText = Me.GetMessage("Application Administration")

        If Not mmAppBase.Localize Then
            Me.btnShowTranslationDialogs.Enabled = False
            Me.lblSystemTranslation.Enabled = False
            Me.lblLocalizationTasks.Text = "Localization Tasks (Disabled)"
        End If

        ' Put user code to initialize the page here
        'this.btnShowTranslationDialogs.Text = "New Text";

        Try
            Me.SecurityAdminLoggedIn = CBool(Session("mmUserSecurity_SecurityAdmin"))
        Catch
        End Try
        If Me.SecurityAdminLoggedIn Then
            Me.btnSecurityLogin.Text = Me.GetMessage("Log out of Security Administration Mode")
        Else
            Me.btnSecurityLogin.Text = Me.GetMessage("Log into Security Administration Mode")
        End If

        Dim t As Object = Session("mmLocalizeAdministration")
        If Not (t Is Nothing) And CBool(t) Then
            Me.btnShowTranslationDialogs.Text = Me.GetMessage("Hide Translation Buttons")
        End If

    End Sub

    Protected Sub btnSecurityLogin_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnSecurityLogin.Click
        If Me.SecurityAdminLoggedIn Then
            Session("mmUserSecurity_SecurityAdmin") = False
            Me.lblErrorMessage.Text = Me.GetMessage("You are now logged out of Security Administration Mode")
            Me.btnSecurityLogin.Text = Me.GetMessage("Log into Security Administration Mode")
        Else
            Session("mmUserSecurity_SecurityAdmin") = True
            Me.lblErrorMessage.Text = Me.GetMessage("You are now running in Security Administration Mode")
            Me.btnSecurityLogin.Text = Me.GetMessage("Log out of Security Administration Mode")
        End If
    End Sub


    Protected Sub btnShowTranslationDialogs_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles btnShowTranslationDialogs.Click
        Dim t As Object = Session("mmLocalizeAdministration")
        If t Is Nothing Or CBool(t) = False Then
            Session("mmLocalizeAdministration") = True
            Me.btnShowTranslationDialogs.Text = Me.GetMessage("Hide Translation Buttons")
        Else
            Session.Remove("mmLocalizeAdministration")
            Me.btnShowTranslationDialogs.Text = Me.GetMessage("Show Translation Buttons")
        End If
    End Sub

End Class
