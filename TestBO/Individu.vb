Imports System.Data
Imports System.Collections.Generic
Imports System.ComponentModel

Imports OakLeaf.MM.Main.Business
Imports OakLeaf.MM.Main.Collections
Imports OakLeaf.MM.Main.Data

''' <summary>
''' Summary description for Individu
''' </summary>
Partial Public Class Individu
    Inherits ABusinessObject(Of IndividuEntity)

    
	#Region "Association Properties"

	'''<summary>
	''' Business Entity object
	''' </summary>
	Public Overrides Property Entity() As IndividuEntity
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
	Private _entity As IndividuEntity

	''' <summary>
	''' Business Rule object
	''' </summary>
	Public Overridable Property Rules As IndividuRules
		Get
			Return CType(Me.BusinessRuleObj, IndividuRules)
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
        Me.TableName = "Individu"
        Me.PrimaryKey = ""
		Me.DefaultCommandType = CommandType.Text
    End Sub

	''' <summary>
	''' Factory method that creates a business rule object
	''' </summary>
	''' <returns>Reference to the business rule object</returns>
	Protected Overrides Function CreateBusinessRuleObject() As mmBusinessRule
		Return New IndividuRules(Me)
	End Function

	''' <summary>
	''' Set default values on the new row
	''' </summary>
	''' <param name="dataRow">New DataRow</param>
	Protected Overrides Sub HookSetDefaultValues(dataRow As DataRow)
		Dim Entity As IndividuEntity = Me.CreateEntityObject()
		Entity.SetDataRow(dataRow)

		'' Store the hard-coded default values via the entity object
		Entity.PK_Individu = 0
	End Sub
End Class