Imports System
Imports System.Collections
Imports System.Collections.Specialized
Imports System.ComponentModel
Imports System.Data
Imports System.Drawing
Imports System.Globalization
Imports System.Web
Imports System.Web.SessionState
Imports System.Web.UI
Imports System.Web.UI.WebControls
Imports System.Web.UI.HtmlControls

Imports OakLeaf.MM.Main
Imports OakLeaf.MM.Main.Web.UI
Imports OakLeaf.MM.Main.Web.UI.WebControls


Public Class LanguageConfiguration
    Inherits mmBaseWebPage

    Protected ShowSystemMessages As Boolean = False

    Protected Sub Page_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load

        Me.PageCaption.InnerText = Me.GetMessage("Language Administration")

        ' Put user code to initialize the page here
        If Not (Request.QueryString("SystemMessages") Is Nothing) Then
            Me.ShowSystemMessages = True
            Me.chkShowSystemMessages.Checked = True
        End If

        ' *** Grab Languages and messages
        If Not Me.IsPostBack Then

            Me.ShowMessages()
            Me.ShowLanguageList()

            Dim T As Object = Session("mmCurrentLanguage")
            If Not (T Is Nothing) Then
                Me.lstLanguage.SelectedValue = T.ToString()
            End If
        End If

        ' Get the list of all cultures
        Dim cultures As CultureInfo() = CultureInfo.GetCultures(CultureTypes.AllCultures)
        Me.lstAddCulture.DataSource = cultures
        Me.lstAddCulture.DataTextField = "Name"
        Me.lstAddCulture.DataValueField = "Name"
        Me.lstAddCulture.DataBind()
        Me.lstAddCulture.SelectedIndex = Me.lstAddCulture.Items.Count - 1

    End Sub

    ' Displays a list of the default Messages (key) to translate
    Public Sub ShowMessages()
        Dim Labels As New StringCollection

        If Me.ShowSystemMessages Then
            ' *** Grab all the dialog messages and dump into the Labels collection
            Dim Messages As DataTable = mmAppBase.MessageMgr.GetDialogText().Tables(0)
            Dim Msg As DataRow
            For Each Msg In Messages.Rows
                Labels.Add(CStr(Msg(mmAppBase.MessageMgr.MessageKeyField)))
            Next Msg
        Else
            Dim T As Object = Session("mmLocalizeLocalizeStrings")
            If T Is Nothing Then
                Me.lstMessages.Items.Clear()
                Return
            End If

            Labels = CType(T, StringCollection)
        End If

        Me.lstMessages.DataSource = Labels
        Me.lstMessages.DataBind()
    End Sub

    ' Fills up the lstLanguages dialog with a list of languages.
    Public Sub ShowLanguageList()
        Me.lstLanguage.DataSource = mmAppBase.LanguageMgr.GetAllLanguages().Tables(0)
        Me.lstLanguage.DataValueField = "LanguagePk"
        Me.lstLanguage.DataTextField = "Description"
        Me.lstLanguage.DataBind()
    End Sub

    Public Shared Sub GetLocalizableObjects(ByVal Container As Control, ByRef Labels As StringCollection)
        If Labels Is Nothing Then
            Labels = New StringCollection
        End If
        ' *** Drill through each control on the form
        Dim control As Control
        For Each control In Container.Controls
            ' ** Recursively call down into any containers
            If control.Controls.Count > 0 Then
                GetLocalizableObjects(control, Labels)
            End If
            ' ** only work on those that support interface
            If TypeOf control Is ImmLocalize Then
                Dim LocalizedControl As OakLeaf.MM.Main.ImmLocalize = CType(control, ImmLocalize)
                Labels.Add(LocalizedControl.OriginalText)
            End If
        Next control
    End Sub

    Protected Sub lstMessages_SelectedIndexChanged(ByVal sender As Object, ByVal e As System.EventArgs) Handles lstMessages.SelectedIndexChanged, lstLanguage.SelectedIndexChanged

        Dim T As String = Me.lstLanguage.SelectedValue
        Dim Language As Integer = 1
        Try
            Language = Integer.Parse(T)
        Catch
        End Try
        Me.txtTranslatedText.Text = mmAppBase.MessageMgr.GetMessage(Me.lstMessages.SelectedValue, Language)
    End Sub

    Protected Sub btnSave_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles btnSave.Click
        Dim T As String = Me.lstLanguage.SelectedValue
        Dim Language As Integer = 1
        Try
            Language = Integer.Parse(T)
        Catch
            Me.ShowError("No message to translate selected:")
            Return
        End Try

        Dim OriginalText As String = Me.lstMessages.SelectedValue
        If mmUtils.Empty(OriginalText) Then
            Me.ShowError("No original text to translate.")
            Return
        End If

        mmAppBase.MessageMgr.SaveTranslatedText(OriginalText, Me.txtTranslatedText.Text, Language)
    End Sub

    Protected Sub ShowError(ByVal Message As String)
        Me.lblError.Text = Message
    End Sub

    Protected Sub btnShowLanguageEditor_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles btnShowLanguageEditor.Click
        If Not Me.txtAddLanguage.Visible Then
            Me.txtAddLanguage.Visible = True
            Me.btnAddLanguage.Visible = True
            Me.btnDeleteLanguage.Visible = True
            Me.lblCulture.Visible = True
            Me.lstAddCulture.Visible = True
            Me.lstAddCulture.SelectedIndex = Me.lstAddCulture.Items.Count - 1
        Else
            Me.txtAddLanguage.Visible = False
            Me.btnAddLanguage.Visible = False
            Me.btnDeleteLanguage.Visible = False
            Me.lblCulture.Visible = False
            Me.lstAddCulture.Visible = False
        End If
    End Sub

    Protected Sub btnAddLanguage_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles btnAddLanguage.Click
        If Me.txtAddLanguage.Text <> "" Then
            mmAppBase.LanguageMgr.AddLanguage(Me.txtAddLanguage.Text, lstAddCulture.SelectedValue)
            Me.ShowLanguageList()
            Me.txtAddLanguage.Text = ""
        End If
        Me.lstAddCulture.SelectedIndex() = Me.lstAddCulture.Items.Count - 1
    End Sub

    Protected Sub btnDeleteLanguage_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles btnDeleteLanguage.Click
        Dim T As String = Me.lstLanguage.SelectedValue
        Dim Language As Integer = 1
        Try
            Language = Integer.Parse(T)
        Catch
            Me.ShowError("No message to translate selected:")
            Return
        End Try

        mmAppBase.LanguageMgr.Delete(Language)
        Me.ShowLanguageList()
    End Sub

    Protected Sub chkShowSystemMessages_CheckedChanged(ByVal sender As Object, ByVal e As System.EventArgs) Handles chkShowSystemMessages.CheckedChanged
        If Me.chkShowSystemMessages.Checked Then
            Me.ShowSystemMessages = True
        Else
            Me.ShowSystemMessages = False
        End If
        Me.ShowMessages()
    End Sub

    Protected Sub lstLanguage_SelectedIndexChanged(ByVal sender As Object, ByVal e As System.EventArgs) Handles lstLanguage.SelectedIndexChanged
        Me.txtTranslatedText.Text = mmAppBase.MessageMgr.GetMessage(Me.lstMessages.SelectedValue, Me.lstLanguage.SelectedValue)
    End Sub

End Class
