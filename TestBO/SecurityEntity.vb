Imports System
Imports System.Data

Imports OakLeaf.MM.Main
Imports OakLeaf.MM.Main.Business
Imports OakLeaf.MM.Main.Data

''' <summary>
''' Summary description for SecurityEntity
''' </summary>
<Serializable()> _
Partial Public Class SecurityEntity
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
	''' SecurityPK
	''' </summary>
	Public Property SecurityPK() As String
		Get
			If Not Me.Row Is Nothing Then
				Return CType(mmType.GetNullableDbValue(Me.Row("SecurityPK")), System.String)
			Else
				Return Me._securityPK
			End If
		End Get
		Set(ByVal value As String)
			If Not Me.Row Is Nothing
				Me.Row("SecurityPK") = mmType.SetNullableDbValue(value) 
			End If
			Me._securityPK = Value
		End Set
	End Property
	Private _SecurityPK As String
End Class