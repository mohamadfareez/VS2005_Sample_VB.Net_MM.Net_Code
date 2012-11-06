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


Public Class MessageDisplay
    Inherits OakLeaf.MM.Main.Web.UI.mmMessageDisplay

    Private Sub Page_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load
        ' Set the display properties and pass down
        Me.DisplayPage()
    End Sub

End Class
