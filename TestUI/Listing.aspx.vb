Imports System.Data

Imports OakLeaf.MM.Main.Business
Imports OakLeaf.MM.Main.Web.UI
Imports OakLeaf.MM.Main.Web.UI.WebControls

''' <summary>
''' Summary description for Listing
''' </summary>
Partial Class Listing
    Inherits TestBusinessWebPage



    ''' <summary>
    ''' Page Load handler
    ''' </summary>
    Protected Sub Page_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load
        Session("ValueID") = CInt(Me.Request.QueryString("Value"))
        If Not Session("ValueID") = 0 Then
            Session("Transaksi") = "Kemaskini"
            Me.Response.Redirect("Details.aspx")
        End If
    End Sub

    Protected Sub btnCari_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles btnCari.Click
        Me.gvList.DataBind()
    End Sub

    Protected Sub btnBaru_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles btnBaru.Click
        Session("Transaksi") = "Baru"
        Me.Response.Redirect("Details.aspx")
    End Sub
End Class
