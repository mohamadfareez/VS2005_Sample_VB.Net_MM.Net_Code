Imports System
Imports System.Data

Imports OakLeaf.MM.Main
Imports OakLeaf.MM.Main.Business
Imports OakLeaf.MM.Main.Data

''' <summary>
''' Summary description for UserRolesEntity
''' </summary>
<Serializable()> _
Partial Public Class UserRolesEntity
    Inherits ABusinessEntity

    ''' <summary>
	''' RoleFK
	''' </summary>
	Public Property RoleFK() As Integer
		Get
			If Not Me.Row Is Nothing Then
				Return CType(mmType.GetNonNullableDbValue(Me.Row("RoleFK"), "System.Int32"), System.Int32)
			Else
				Return Me._roleFK
			End If
		End Get
		Set
			If Not Me.Row Is Nothing
				Me.Row("RoleFK") = Value 
			End If
			Me._roleFK = Value
		End Set
	End Property
	Private _RoleFK As Integer

	''' <summary>
	''' UserFK
	''' </summary>
	Public Property UserFK() As Integer
		Get
			If Not Me.Row Is Nothing Then
				Return CType(mmType.GetNonNullableDbValue(Me.Row("UserFK"), "System.Int32"), System.Int32)
			Else
				Return Me._userFK
			End If
		End Get
		Set
			If Not Me.Row Is Nothing
				Me.Row("UserFK") = Value 
			End If
			Me._userFK = Value
		End Set
	End Property
	Private _UserFK As Integer

	''' <summary>
	''' UserRolesPK
	''' </summary>
	Public Property UserRolesPK() As Integer
		Get
			If Not Me.Row Is Nothing Then
				Return CType(mmType.GetNonNullableDbValue(Me.Row("UserRolesPK"), "System.Int32"), System.Int32)
			Else
				Return Me._userRolesPK
			End If
		End Get
		Set
			If Not Me.Row Is Nothing
				Me.Row("UserRolesPK") = Value 
			End If
			Me._userRolesPK = Value
		End Set
	End Property
	Private _UserRolesPK As Integer
End Class