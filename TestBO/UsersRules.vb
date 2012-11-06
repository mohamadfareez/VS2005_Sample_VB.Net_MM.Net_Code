Imports System
Imports System.ComponentModel
Imports System.Data
Imports System.Collections.Generic

Imports OakLeaf.MM.Main
Imports OakLeaf.MM.Main.Business
Imports OakLeaf.MM.Main.Collections

''' <summary>
''' Summary description for UsersRules
''' </summary>
Partial Public Class UsersRules
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
				Dim Entity As New UsersEntity()
				Entity.SetDataRow(ds.Tables(tableName).Rows(Me.CurrentRow))

				'' Call validation methods
				Me.ValidateFirstName(Entity.FirstName)
				Me.ValidateLastName(Entity.LastName)
				Me.ValidateUserID(Entity.UserID)
			End If
	
		End If

        Return Me.ErrorProviderBrokenRuleCount = 0
    End Function

	''' <summary>
	''' Validates the First Name
	''' </summary>
	Public Function ValidateFirstName(firstName As String) As String
		Dim Msg As String = Nothing
		If mmType.IsEmpty(firstName) Then
			Me.EntityPropertyDisplayName = "First Name"

			Msg = Me.RequiredFieldMessagePrefix + _
				Me.EntityPropertyDisplayName + _
				Me.RequiredFieldMessageSuffix

			AddErrorProviderBrokenRule("FirstName",  Msg)
		End If
		Return Msg
	End Function

	''' <summary>
	''' Validates the Last Name
	''' </summary>
	Public Function ValidateLastName(lastName As String) As String
		Dim Msg As String = Nothing
		If mmType.IsEmpty(lastName) Then
			Me.EntityPropertyDisplayName = "Last Name"

			Msg = Me.RequiredFieldMessagePrefix + _
				Me.EntityPropertyDisplayName + _
				Me.RequiredFieldMessageSuffix

			AddErrorProviderBrokenRule("LastName",  Msg)
		End If
		Return Msg
	End Function

	''' <summary>
	''' Validates the User ID
	''' </summary>
	Public Function ValidateUserID(userID As String) As String
		Dim Msg As String = Nothing
		If mmType.IsEmpty(userID) Then
			Me.EntityPropertyDisplayName = "User ID"

			Msg = Me.RequiredFieldMessagePrefix + _
				Me.EntityPropertyDisplayName + _
				Me.RequiredFieldMessageSuffix

			AddErrorProviderBrokenRule("UserID",  Msg)
		End If
		Return Msg
	End Function

End Class