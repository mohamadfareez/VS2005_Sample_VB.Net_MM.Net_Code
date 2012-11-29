Imports System.Data

Imports OakLeaf.MM.Main.Business
Imports OakLeaf.MM.Main.Web.UI
Imports OakLeaf.MM.Main.Web.UI.WebControls

''' <summary>
''' Summary description for Logout
''' </summary>
Partial Class Logout
    Inherits mmBaseUserLogin

    ''' <summary>
    ''' Page Load handler
    ''' </summary>
    Protected Sub Page_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load
        mmBaseUserLogin.Logout()
        Session.Contents.Clear()
        Response.Redirect("UserLogin.aspx")
    End Sub

End Class
