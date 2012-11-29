Imports Microsoft.VisualBasic
Imports OakLeaf.MM.Main.Web.UI

Imports System.Globalization
Imports System.Threading



Public Class TestBusinessWebPage
    Inherits mmBusinessWebPage

    Protected Overrides Sub OnInit(ByVal e As System.EventArgs)
        ' Check user authorized access.
        Me.RequiresSecurity = True

        MyBase.OnInit(e)

        Thread.CurrentThread.CurrentCulture = CultureInfo.CreateSpecificCulture("ms-MY")
        Thread.CurrentThread.CurrentUICulture = CultureInfo.CreateSpecificCulture("ms-MY")
    End Sub
End Class
