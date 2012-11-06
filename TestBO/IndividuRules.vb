Imports System
Imports System.ComponentModel
Imports System.Data
Imports System.Collections.Generic

Imports OakLeaf.MM.Main
Imports OakLeaf.MM.Main.Business
Imports OakLeaf.MM.Main.Collections

''' <summary>
''' Summary description for IndividuRules
''' </summary>
Partial Public Class IndividuRules
    Inherits  ABusinessRule

    ''' <summary>
    ''' Constructor
    ''' </summary>
    Public Sub New(ByVal hostObject As ImmBusinessRuleHost)
        MyBase.New(hostObject)
    End Sub

    ''' <summary>
    ''' Checks business rules against the specified DataTable
    ''' </summary>
    ''' <param name="ds">DataSet</param>
    ''' <param name="tableName">Table Name</param>
    ''' <returns>Logical true if rules passed, otherwise false</returns>
    Public Overrides Function CheckRulesHook(ByVal ds As DataSet, ByVal tableName As String) As Boolean
        If ds.Tables(tableName).Rows.Count > 0 Then

			Dim Row As DataRow = ds.Tables(tableName).Rows(Me.CurrentRow)
			If Row.RowState <> DataRowState.Unchanged AND Row.RowState <> DataRowState.Deleted Then
				Dim Entity As New IndividuEntity()
				Entity.SetDataRow(ds.Tables(tableName).Rows(Me.CurrentRow))

				'' Call validation methods
			End If
	
		End If

        Return Me.ErrorProviderBrokenRuleCount = 0
    End Function

End Class