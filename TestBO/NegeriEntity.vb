Imports System
Imports System.Data

Imports OakLeaf.MM.Main
Imports OakLeaf.MM.Main.Business
Imports OakLeaf.MM.Main.Data

''' <summary>
''' Summary description for NegeriEntity
''' </summary>
<Serializable()> _
Partial Public Class NegeriEntity
    Inherits ABusinessEntity

    ''' <summary>
	''' Deskripsi
	''' </summary>
	Public Property Deskripsi() As String
		Get
			If Not Me.Row Is Nothing Then
				Return CType(mmType.GetNullableDbValue(Me.Row("Deskripsi")), System.String)
			Else
				Return Me._deskripsi
			End If
		End Get
		Set(ByVal value As String)
			If Not Me.Row Is Nothing
				Me.Row("Deskripsi") = mmType.SetNullableDbValue(value) 
			End If
			Me._deskripsi = Value
		End Set
	End Property
	Private _Deskripsi As String

	''' <summary>
	''' KodNegeri
	''' </summary>
	Public Property KodNegeri() As String
		Get
			If Not Me.Row Is Nothing Then
				Return CType(mmType.GetNullableDbValue(Me.Row("KodNegeri")), System.String)
			Else
				Return Me._kodNegeri
			End If
		End Get
		Set(ByVal value As String)
			If Not Me.Row Is Nothing
				Me.Row("KodNegeri") = mmType.SetNullableDbValue(value) 
			End If
			Me._kodNegeri = Value
		End Set
	End Property
	Private _KodNegeri As String

	''' <summary>
	''' PK_Negeri
	''' </summary>
	Public Property PK_Negeri() As Int64
		Get
			If Not Me.Row Is Nothing Then
				Return CType(mmType.GetNonNullableDbValue(Me.Row("PK_Negeri"), "System.Int64"), System.Int64)
			Else
				Return Me._pK_Negeri
			End If
		End Get
		Set
			If Not Me.Row Is Nothing
				Me.Row("PK_Negeri") = Value 
			End If
			Me._pK_Negeri = Value
		End Set
	End Property
	Private _PK_Negeri As Int64
End Class