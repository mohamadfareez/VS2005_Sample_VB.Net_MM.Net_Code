Imports OakLeaf.MM.Main.Web
Imports OakLeaf.MM.Main.Patterns

' Web application object
Public Class AppWeb
    Inherits mmAppWeb

    Public Sub New()
        ' Initialize the ApplicationName property
        ApplicationName = "<MMApplicationName>"

        Me.InitializeComponent()
    End Sub

#Region " Windows Form Designer generated code "
    Private Sub InitializeComponent()

    End Sub
#End Region

    ' Creates the application-level factory
    Public Overrides Function CreateFactory() As mmFactory
        Return New Factory
    End Function

End Class


