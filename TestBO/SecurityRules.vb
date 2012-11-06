Imports System
Imports System.ComponentModel
Imports System.Data
Imports System.Collections.Generic

Imports OakLeaf.MM.Main
Imports OakLeaf.MM.Main.Business
Imports OakLeaf.MM.Main.Collections

''' <summary>
''' Summary description for SecurityRules
''' </summary>
Partial Public Class SecurityRules
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
				Dim Entity As New SecurityEntity()
				Entity.SetDataRow(ds.Tables(tableName).Rows(Me.CurrentRow))

				'' Call validation methods
				Me.ValidateSecurityPK(Entity.SecurityPK)
			End If
	
		End If

        Return Me.ErrorProviderBrokenRuleCount = 0
    End Function

	''' <summary>
	''' Validates the Security PK
	''' </summary>
	Public Function ValidateSecurityPK(securityPK As String) As String
		Dim Msg As String = Nothing
		If mmType.IsEmpty(securityPK) Then
			Me.EntityPropertyDisplayName = "Security PK"

			Msg = Me.RequiredFieldMessagePrefix + _
				Me.EntityPropertyDisplayName + _
				Me.RequiredFieldMessageSuffix

			AddErrorProviderBrokenRule("SecurityPK",  Msg)
		End If
		Return Msg
	End Function

End Class