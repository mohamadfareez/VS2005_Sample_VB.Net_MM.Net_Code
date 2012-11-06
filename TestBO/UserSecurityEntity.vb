Imports System
Imports System.Data

Imports OakLeaf.MM.Main
Imports OakLeaf.MM.Main.Business
Imports OakLeaf.MM.Main.Data

''' <summary>
''' Summary description for UserSecurityEntity
''' </summary>
<Serializable()> _
Partial Public Class UserSecurityEntity
    Inherits ABusinessEntity

    ''' <summary>
	''' AccessLevel
	''' </summary>
	Public Property AccessLevel() As Int16
		Get
			If Not Me.Row Is Nothing Then
				Return CType(mmType.GetNonNullableDbValue(Me.Row("AccessLevel"), "System.Int16"), System.Int16)
			Else
				Return Me._accessLevel
			End If
		End Get
		Set
			If Not Me.Row Is Nothing
				Me.Row("AccessLevel") = Value 
			End If
			Me._accessLevel = Value
		End Set
	End Property
	Private _AccessLevel As Int16

	''' <summary>
	''' SecurityFK
	''' </summary>
	Public Property SecurityFK() As String
		Get
			If Not Me.Row Is Nothing Then
				Return CType(mmType.GetNullableDbValue(Me.Row("SecurityFK")), System.String)
			Else
				Return Me._securityFK
			End If
		End Get
		Set(ByVal value As String)
			If Not Me.Row Is Nothing
				Me.Row("SecurityFK") = mmType.SetNullableDbValue(value) 
			End If
			Me._securityFK = Value
		End Set
	End Property
	Private _SecurityFK As String

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
	''' UserSecurityPK
	''' </summary>
	Public Property UserSecurityPK() As Integer
		Get
			If Not Me.Row Is Nothing Then
				Return CType(mmType.GetNonNullableDbValue(Me.Row("UserSecurityPK"), "System.Int32"), System.Int32)
			Else
				Return Me._userSecurityPK
			End If
		End Get
		Set
			If Not Me.Row Is Nothing
				Me.Row("UserSecurityPK") = Value 
			End If
			Me._userSecurityPK = Value
		End Set
	End Property
	Private _UserSecurityPK As Integer
End Class