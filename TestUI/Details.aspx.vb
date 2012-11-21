Imports System.Data

Imports OakLeaf.MM.Main.Business
Imports OakLeaf.MM.Main.Web.UI
Imports OakLeaf.MM.Main.Web.UI.WebControls

'Imports Library Object
Imports TestBusiness

''' <summary>
''' Summary description for Details
''' </summary>
Partial Class Details
    Inherits mmBusinessWebPage

    'Declare Table Object
    Protected oIndividu As New Individu

    ''' <summary>
    ''' Page Load handler
    ''' </summary>
    Protected Sub Page_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load
        'Register Object Table
        Me.oIndividu = CType(Me.RegisterBizObj(New Individu), Individu)

        'Checking id session no value redirect to listing form else load the data by primary key
        If CInt(Session("ValueID")) = 0 Then
            Me.Response.Redirect("Listing.aspx")
        Else
            If Not Me.IsPostBack Then 'First time page loaded
                'Load data by primary key pass by session valueid
                Me.oIndividu.LoadRow(Session("ValueID"))
                'Save dataset to session after load
                Session("dsIndividu") = Me.oIndividu.DataSet()
            Else 'Any transaction event on the same page
                'Keep the dataset uptodate by session
                Dim dsIndividu As DataSet = CType(Session("dsIndividu"), DataSet)
                Me.oIndividu.SetCurrentDataSet(dsIndividu)
            End If
        End If
    End Sub

    Protected Sub btnKembali_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles btnKembali.Click
        Session("ValueID") = 0
        Me.Response.Redirect("Listing.aspx")
    End Sub

    Protected Sub btnSimpan_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles btnSimpan.Click
        Try
            Me.oIndividu.TransactionBegin()
            Dim dsIndividu As DataSet = CType(Session("dsIndividu"), DataSet)

            If Me.oIndividu.SaveDataSet(dsIndividu) = mmSaveDataResult.RulesPassed Then
                Me.oIndividu.TransactionCommit()
                Me.MyMsgBox("Rekod berjaya disimpan")
            ElseIf Me.oIndividu.Rules.HasBrokenRules Then
                Dim msgBrokenRules As String = Me.oIndividu.Rules.GetAllBrokenRules()
                Me.MyMsgBox(Replace(msgBrokenRules, vbCrLf, "\n"))
            Else
                Me.oIndividu.HandleException(Me.oIndividu.Exception)
                Me.MyMsgBox("Rekod tidak berjaya disimpan")
            End If

        Catch ex As Exception
            Me.oIndividu.TransactionRollback()
            Me.MyMsgBox("Rekod tidak berjaya disimpan")
        End Try
    End Sub

    Protected Sub MyMsgBox(ByVal tcMessage As String)
        Dim lcScript As String
        lcScript = "<script language=""javascript"">" & _
                   " alert(""" & tcMessage & """)" & vbCrLf & _
                   "</script>"
        Page.ClientScript.RegisterStartupScript(GetType(String), "PopUp", lcScript)
    End Sub

    Protected Sub btnPadam_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles btnPadam.Click
        If Me.oIndividu.Delete(Session("ValueID")) Then
            Me.Response.Redirect("Listing.aspx")
        Else
            Me.MyMsgBox("Rekod tidak berjaya dipadam")
        End If
    End Sub
End Class
