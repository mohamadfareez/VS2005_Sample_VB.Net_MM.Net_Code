Imports System
Imports System.Data

Imports OakLeaf.MM.Main
Imports OakLeaf.MM.Main.Business
Imports OakLeaf.MM.Main.Data

''' <summary>
''' Summary description for UsersEntity
''' </summary>
<Serializable()> _
Partial Public Class UsersEntity
    Inherits ABusinessEntity

    ''' <summary>
	''' FirstName
	''' </summary>
	Public Property FirstName() As String
		Get
			If Not Me.Row Is Nothing Then
				Return CType(mmType.GetNullableDbValue(Me.Row("FirstName")), System.String)
			Else
				Return Me._firstName
			End If
		End Get
		Set(ByVal value As String)
			If Not Me.Row Is Nothing
				Me.Row("FirstName") = mmType.SetNullableDbValue(value) 
			End If
			Me._firstName = Value
		End Set
	End Property
	Private _FirstName As String

	''' <summary>
	''' LanguageFK
	''' </summary>
	Public Property LanguageFK() As Nullable(Of Integer)
		Get
			If Not Me.Row Is Nothing Then
				Return CType(mmType.GetNullableDbValue(Me.Row("LanguageFK")), System.Int32)
			Else
				Return Me._languageFK
			End If
		End Get
		Set(ByVal value As Nullable(Of Integer))
			If Not Me.Row Is Nothing
				Me.Row("LanguageFK") = mmType.SetNullableDbValue(value) 
			End If
			Me._languageFK = Value
		End Set
	End Property
	Private _LanguageFK As Nullable(Of Integer)

	''' <summary>
	''' LastName
	''' </summary>
	Public Property LastName() As String
		Get
			If Not Me.Row Is Nothing Then
				Return CType(mmType.GetNullableDbValue(Me.Row("LastName")), System.String)
			Else
				Return Me._lastName
			End If
		End Get
		Set(ByVal value As String)
			If Not Me.Row Is Nothing
				Me.Row("LastName") = mmType.SetNullableDbValue(value) 
			End If
			Me._lastName = Value
		End Set
	End Property
	Private _LastName As String

	''' <summary>
	''' Password
	''' </summary>
	Public Property Password() As String
		Get
			If Not Me.Row Is Nothing Then
				Return CType(mmType.GetNullableDbValue(Me.Row("Password")), System.String)
			Else
				Return Me._password
			End If
		End Get
		Set(ByVal value As String)
			If Not Me.Row Is Nothing
				Me.Row("Password") = mmType.SetNullableDbValue(value) 
			End If
			Me._password = Value
		End Set
	End Property
	Private _Password As String

	''' <summary>
	''' UserID
	''' </summary>
	Public Property UserID() As String
		Get
			If Not Me.Row Is Nothing Then
				Return CType(mmType.GetNullableDbValue(Me.Row("UserID")), System.String)
			Else
				Return Me._userID
			End If
		End Get
		Set(ByVal value As String)
			If Not Me.Row Is Nothing
				Me.Row("UserID") = mmType.SetNullableDbValue(value) 
			End If
			Me._userID = Value
		End Set
	End Property
	Private _UserID As String

	''' <summary>
	''' UserPK
	''' </summary>
	Public Property UserPK() As Integer
		Get
			If Not Me.Row Is Nothing Then
				Return CType(mmType.GetNonNullableDbValue(Me.Row("UserPK"), "System.Int32"), System.Int32)
			Else
				Return Me._userPK
			End If
		End Get
		Set
			If Not Me.Row Is Nothing
				Me.Row("UserPK") = Value 
			End If
			Me._userPK = Value
		End Set
	End Property
	Private _UserPK As Integer
End Class