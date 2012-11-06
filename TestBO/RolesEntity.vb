Imports System
Imports System.Data

Imports OakLeaf.MM.Main
Imports OakLeaf.MM.Main.Business
Imports OakLeaf.MM.Main.Data

''' <summary>
''' Summary description for RolesEntity
''' </summary>
<Serializable()> _
Partial Public Class RolesEntity
    Inherits ABusinessEntity

    ''' <summary>
	''' Description
	''' </summary>
	Public Property Description() As String
		Get
			If Not Me.Row Is Nothing Then
				Return CType(mmType.GetNullableDbValue(Me.Row("Description")), System.String)
			Else
				Return Me._description
			End If
		End Get
		Set(ByVal value As String)
			If Not Me.Row Is Nothing
				Me.Row("Description") = mmType.SetNullableDbValue(value) 
			End If
			Me._description = Value
		End Set
	End Property
	Private _Description As String

	''' <summary>
	''' RolePK
	''' </summary>
	Public Property RolePK() As Integer
		Get
			If Not Me.Row Is Nothing Then
				Return CType(mmType.GetNonNullableDbValue(Me.Row("RolePK"), "System.Int32"), System.Int32)
			Else
				Return Me._rolePK
			End If
		End Get
		Set
			If Not Me.Row Is Nothing
				Me.Row("RolePK") = Value 
			End If
			Me._rolePK = Value
		End Set
	End Property
	Private _RolePK As Integer
End Class