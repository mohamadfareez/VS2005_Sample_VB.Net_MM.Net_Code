Imports System
Imports System.ComponentModel
Imports System.Data
Imports System.Collections.Generic

Imports OakLeaf.MM.Main
Imports OakLeaf.MM.Main.Business
Imports OakLeaf.MM.Main.Collections

''' <summary>
''' Summary description for UserRolesRules
''' </summary>
Partial Public Class UserRolesRules
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
				Dim Entity As New UserRolesEntity()
				Entity.SetDataRow(ds.Tables(tableName).Rows(Me.CurrentRow))

				'' Call validation methods
				Me.ValidateRoleFK(Entity.RoleFK)
				Me.ValidateUserFK(Entity.UserFK)
			End If
	
		End If

        Return Me.ErrorProviderBrokenRuleCount = 0
    End Function

	''' <summary>
	''' Validates the Role FK
	''' </summary>
	Public Function ValidateRoleFK(roleFK As Integer) As String
		Dim Msg As String = Nothing
		If mmType.IsEmpty(roleFK) Then
			Me.EntityPropertyDisplayName = "Role FK"

			Msg = Me.RequiredFieldMessagePrefix + _
				Me.EntityPropertyDisplayName + _
				Me.RequiredFieldMessageSuffix

			AddErrorProviderBrokenRule("RoleFK",  Msg)
		End If
		Return Msg
	End Function

	''' <summary>
	''' Validates the User FK
	''' </summary>
	Public Function ValidateUserFK(userFK As Integer) As String
		Dim Msg As String = Nothing
		If mmType.IsEmpty(userFK) Then
			Me.EntityPropertyDisplayName = "User FK"

			Msg = Me.RequiredFieldMessagePrefix + _
				Me.EntityPropertyDisplayName + _
				Me.RequiredFieldMessageSuffix

			AddErrorProviderBrokenRule("UserFK",  Msg)
		End If
		Return Msg
	End Function

End Class