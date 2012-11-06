Imports System
Imports System.Collections.Generic
Imports System.ComponentModel
Imports System.Data
Imports System.Text

Imports OakLeaf.MM.Main
Imports OakLeaf.MM.Main.Business
Imports OakLeaf.MM.Main.Collections
Imports OakLeaf.MM.Main.Security
Imports OakLeaf.MM.Main.Managers

''' <summary>
''' Application-level Business Object class
''' </summary>
Public Class ABusinessObject(Of EntityType As {mmBusinessEntity, New})
    Inherits mmBusinessObjectGeneric(Of EntityType)

    ''' <summary>
    ''' Constructor
    ''' </summary>
    Public Sub New()
        Me.DatabaseKey = "TestProject"
        Me.RetrieveAutoIncrementPK = True
    End Sub

End Class
