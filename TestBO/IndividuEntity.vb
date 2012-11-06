Imports System
Imports System.Data

Imports OakLeaf.MM.Main
Imports OakLeaf.MM.Main.Business
Imports OakLeaf.MM.Main.Data

''' <summary>
''' Summary description for IndividuEntity
''' </summary>
<Serializable()> _
Partial Public Class IndividuEntity
    Inherits ABusinessEntity

    ''' <summary>
	''' Alamat
	''' </summary>
	Public Property Alamat() As String
		Get
			If Not Me.Row Is Nothing Then
				Return CType(mmType.GetNullableDbValue(Me.Row("Alamat")), System.String)
			Else
				Return Me._alamat
			End If
		End Get
		Set(ByVal value As String)
			If Not Me.Row Is Nothing
				Me.Row("Alamat") = mmType.SetNullableDbValue(value) 
			End If
			Me._alamat = Value
		End Set
	End Property
	Private _Alamat As String

	''' <summary>
	''' FK_Negeri
	''' </summary>
	Public Property FK_Negeri() As Nullable(Of Int64)
		Get
			If Not Me.Row Is Nothing Then
				Return CType(mmType.GetNullableDbValue(Me.Row("FK_Negeri")), System.Int64)
			Else
				Return Me._fK_Negeri
			End If
		End Get
		Set(ByVal value As Nullable(Of Int64))
			If Not Me.Row Is Nothing
				Me.Row("FK_Negeri") = mmType.SetNullableDbValue(value) 
			End If
			Me._fK_Negeri = Value
		End Set
	End Property
	Private _FK_Negeri As Nullable(Of Int64)

	''' <summary>
	''' Nama
	''' </summary>
	Public Property Nama() As String
		Get
			If Not Me.Row Is Nothing Then
				Return CType(mmType.GetNullableDbValue(Me.Row("Nama")), System.String)
			Else
				Return Me._nama
			End If
		End Get
		Set(ByVal value As String)
			If Not Me.Row Is Nothing
				Me.Row("Nama") = mmType.SetNullableDbValue(value) 
			End If
			Me._nama = Value
		End Set
	End Property
	Private _Nama As String

	''' <summary>
	''' NoMyKad
	''' </summary>
	Public Property NoMyKad() As Nullable(Of Decimal)
		Get
			If Not Me.Row Is Nothing Then
				Return CType(mmType.GetNullableDbValue(Me.Row("NoMyKad")), System.Decimal)
			Else
				Return Me._noMyKad
			End If
		End Get
		Set(ByVal value As Nullable(Of Decimal))
			If Not Me.Row Is Nothing
				Me.Row("NoMyKad") = mmType.SetNullableDbValue(value) 
			End If
			Me._noMyKad = Value
		End Set
	End Property
	Private _NoMyKad As Nullable(Of Decimal)

	''' <summary>
	''' PK_Individu
	''' </summary>
	Public Property PK_Individu() As Int64
		Get
			If Not Me.Row Is Nothing Then
				Return CType(mmType.GetNonNullableDbValue(Me.Row("PK_Individu"), "System.Int64"), System.Int64)
			Else
				Return Me._pK_Individu
			End If
		End Get
		Set
			If Not Me.Row Is Nothing
				Me.Row("PK_Individu") = Value 
			End If
			Me._pK_Individu = Value
		End Set
	End Property
	Private _PK_Individu As Int64

	''' <summary>
	''' Poskod
	''' </summary>
	Public Property Poskod() As Nullable(Of Decimal)
		Get
			If Not Me.Row Is Nothing Then
				Return CType(mmType.GetNullableDbValue(Me.Row("Poskod")), System.Decimal)
			Else
				Return Me._poskod
			End If
		End Get
		Set(ByVal value As Nullable(Of Decimal))
			If Not Me.Row Is Nothing
				Me.Row("Poskod") = mmType.SetNullableDbValue(value) 
			End If
			Me._poskod = Value
		End Set
	End Property
	Private _Poskod As Nullable(Of Decimal)

	''' <summary>
	''' TkhLahir
	''' </summary>
	Public Property TkhLahir() As Nullable(Of DateTime)
		Get
			If Not Me.Row Is Nothing Then
				Return CType(mmType.GetNullableDbValue(Me.Row("TkhLahir")), System.DateTime)
			Else
				Return Me._tkhLahir
			End If
		End Get
		Set(ByVal value As Nullable(Of DateTime))
			If Not Me.Row Is Nothing
				Me.Row("TkhLahir") = mmType.SetNullableDbValue(value) 
			End If
			Me._tkhLahir = Value
		End Set
	End Property
	Private _TkhLahir As Nullable(Of DateTime)
End Class