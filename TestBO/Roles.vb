Imports System.Data
Imports System.Collections.Generic
Imports System.ComponentModel

Imports OakLeaf.MM.Main.Business
Imports OakLeaf.MM.Main.Collections
Imports OakLeaf.MM.Main.Data

''' <summary>
''' Summary description for Roles
''' </summary>
Partial Public Class Roles
    Inherits ABusinessObject(Of RolesEntity)

    
	#Region "Association Properties"

	'''<summary>
	''' Business Entity object
	''' </summary>
	Public Overrides Property Entity() As RolesEntity
		Get
			If Me._entity Is Nothing Then
				Me._entity = Me.CreateEntityObject()
			End If
			Me._entity.SetDataRow(Me.DataRow)
			Return Me._entity
		End Get
		Set
			Me._entity = value
		End Set
	End Property
	Private _entity As RolesEntity

	''' <summary>
	''' Business Rule object
	''' </summary>
	Public Overridable Property Rules As RolesRules
		Get
			Return CType(Me.BusinessRuleObj, RolesRules)
		End Get
		Set
			Me.BusinessRuleObj = value
		End Set
	End Property

	#End Region

	''' <summary>
    ''' Constructor
    ''' </summary>
    Public Sub New()
        Me.TableName = "Roles"
        Me.PrimaryKey = "RolePK"
		Me.DefaultCommandType = CommandType.Text
    End Sub

	''' <summary>
	''' Factory method that creates a business rule object
	''' </summary>
	''' <returns>Reference to the business rule object</returns>
	Protected Overrides Function CreateBusinessRuleObject() As mmBusinessRule
		Return New RolesRules(Me)
	End Function
End Class