Imports System
Imports System.Data

Imports OakLeaf.MM.Main
Imports OakLeaf.MM.Main.Business
Imports OakLeaf.MM.Main.Data

''' <summary>
''' Summary description for RoleSecurityEntity
''' </summary>
<Serializable()> _
Partial Public Class RoleSecurityEntity
    Inherits ABusinessEntity

    ''' <summary>
	''' AccessLevel
	''' </summary>
	Public Property AccessLevel() As Nullable(Of Int16)
		Get
			If Not Me.Row Is Nothing Then
				Return CType(mmType.GetNullableDbValue(Me.Row("AccessLevel")), System.Int16)
			Else
				Return Me._accessLevel
			End If
		End Get
		Set(ByVal value As Nullable(Of Int16))
			If Not Me.Row Is Nothing
				Me.Row("AccessLevel") = mmType.SetNullableDbValue(value) 
			End If
			Me._accessLevel = Value
		End Set
	End Property
	Private _AccessLevel As Nullable(Of Int16)

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
	''' RoleSecurityPK
	''' </summary>
	Public Property RoleSecurityPK() As Integer
		Get
			If Not Me.Row Is Nothing Then
				Return CType(mmType.GetNonNullableDbValue(Me.Row("RoleSecurityPK"), "System.Int32"), System.Int32)
			Else
				Return Me._roleSecurityPK
			End If
		End Get
		Set
			If Not Me.Row Is Nothing
				Me.Row("RoleSecurityPK") = Value 
			End If
			Me._roleSecurityPK = Value
		End Set
	End Property
	Private _RoleSecurityPK As Integer

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
End Class