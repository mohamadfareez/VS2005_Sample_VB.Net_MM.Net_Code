Imports System
Imports System.Collections.Generic
Imports System.ComponentModel
Imports System.Text

Imports OakLeaf.MM.Main
Imports OakLeaf.MM.Main.Business
Imports OakLeaf.MM.Main.Collections
Imports OakLeaf.MM.Main.Patterns

''' <summary>
''' Summary description for ABusinessTest
''' </summary>
Public Class AAppTest

    ''' <summary>
    ''' Constructor
    ''' </summary>
    Public Sub New()
        mmAppBase.Factory = New AAppTestFactory()
        mmAppBase.IsRunning = True
    End Sub

End Class

''' <summary>
''' AAppTestFactory
''' </summary>
Public Class AAppTestFactory
    Inherits mmFactory

End Class

