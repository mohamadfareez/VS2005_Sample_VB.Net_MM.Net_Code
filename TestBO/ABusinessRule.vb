Imports System
Imports System.Collections.Generic
Imports System.ComponentModel
Imports System.Text

Imports OakLeaf.MM.Main
Imports OakLeaf.MM.Main.Business
Imports OakLeaf.MM.Main.Collections
Imports OakLeaf.MM.Main.Security
Imports OakLeaf.MM.Main.Managers

''' <summary>
''' Application-level Business Rule class
''' </summary>
Public Class ABusinessRule
    Inherits mmBusinessRule

    ''' <summary>
    ''' Constructor
    ''' </summary>
    ''' <param name="hostObject">Host object</param>
    Public Sub New(ByVal hostObject As ImmBusinessRuleHost)
        MyBase.New(hostObject)
    End Sub

End Class