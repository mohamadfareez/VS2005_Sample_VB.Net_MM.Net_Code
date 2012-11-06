Imports System.Data
Imports OakLeaf.MM.Main
Imports OakLeaf.MM.Main.Security
Imports OakLeaf.MM.Main.Business
Imports OakLeaf.MM.Main.Web.UI
Imports OakLeaf.MM.Main.Web

Public Class UserAdmin
    Inherits mmBusinessWebPage

    Protected oUser As mmUser
    Protected oRole As mmRole
    Protected dsUsers As DataSet

    Protected Sub Page_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load

        Me.PageCaption.InnerText = Me.GetMessage("User Administration")

        Me.oRole = mmAppWeb.Factory.CreateRoleObject()
        Me.oUser = mmAppWeb.Factory.CreateUserObject()

        If Not Me.IsPostBack Then
            Me.LoadUserList()
            Me.LoadRoleLists(Nothing) ' Fill the All Roles list
        End If
        Me.lstUsers.SelectedValue = Request.Form("lstUsers")
    End Sub

    ' Loads the user list
    Protected Function LoadUserList() As Boolean
        If Not (Me.oUser.GetAllUserNames() Is Nothing) Then
            dsUsers = Me.oUser.GetCurrentDataSet()
            Me.lstUsers.DataSource = dsUsers.Tables(0)
            Me.lstUsers.DataValueField = Me.oUser.PrimaryKey
            Me.lstUsers.DataTextField = Me.oUser.FullNameField
            Me.lstUsers.DataBind()
            Return True
        End If

        Return False
    End Function

    ' Loads a user into the controls
    Protected Function LoadUser(ByVal Pk As Object) As Boolean
        Me.lblError.Text = ""

        If Me.oUser.LoadRow(Pk) Then
            Dim User As DataRow = Me.oUser.DataRow
            Me.txtFirstName.Text = CStr(User(Me.oUser.FirstNameField))
            Me.txtLastName.Text = CStr(User(Me.oUser.LastNameField))
            Me.txtUserId.Text = CStr(User(Me.oUser.UserIDField))
            If Not User(Me.oUser.PasswordField) Is System.DBNull.Value Then
                Me.txtPassword.Text = CStr(User(Me.oUser.PasswordField))
            End If
            Me.txtPk.Text = CStr(Pk.ToString())

            Me.btnSave.Enabled = True
            Return True
        End If

        Me.btnSave.Enabled = True
        Return False
    End Function

    ' Saves a user from the form variables
    Protected Function SaveUser(ByVal UserPk As Object) As Boolean
        If UserPk Is Nothing Then
            ' Add new user
            If Me.oUser.NewRow() Is Nothing Then
                Return False
            End If
        Else
            If Not Me.oUser.LoadRow(UserPk) Then
                Return False
            End If
        End If

        Dim User As DataRow = Me.oUser.DataRow

        User(Me.oUser.FirstNameField) = Me.txtFirstName.Text
        User(Me.oUser.LastNameField) = Me.txtLastName.Text
        User(Me.oUser.UserIDField) = Me.txtUserId.Text
        User(Me.oUser.PasswordField) = Me.txtPassword.Text

        If Me.oUser.SaveRow() <> mmSaveDataResult.RulesPassed Then
            Return False
        End If

        If UserPk Is Nothing Then
            ' *** refresh the list of users
            Me.LoadUserList()

            ' *** for now just clear the fields - don't know how to get the Pk back from insert
            Me.ClearFields()
        End If

        Return True
    End Function

    Public Sub ClearFields()
        Me.txtPk.Text = "-1"
        Me.txtLastName.Text = ""
        Me.txtFirstName.Text = ""
        Me.txtPassword.Text = ""
        Me.txtUserId.Text = ""
    End Sub

    ' Loads the Roles List
    Public Sub LoadRoleLists(ByVal UserPk As Object)
        If Not (mmType.IsEmpty(UserPk)) Then
            Dim dsAvailable As DataSet = Me.oRole.GetUserNonMemberRoles(UserPk)
            Me.lstAvailableRoles.DataSource = dsAvailable.Tables(Me.oRole.NonMemberTable).DefaultView
            Me.lstAvailableRoles.DataValueField = Me.oRole.PrimaryKey
            Me.lstAvailableRoles.DataTextField = Me.oRole.DescriptionField
            Me.lstAvailableRoles.DataBind()

            Dim dsSelected As DataSet = Me.oRole.GetUserRoles(UserPk)
            Me.lstSelectedRoles.DataSource = dsSelected.Tables(Me.oRole.TableName).DefaultView
            Me.lstSelectedRoles.DataValueField = Me.oRole.PrimaryKey
            Me.lstSelectedRoles.DataTextField = Me.oRole.DescriptionField
            Me.lstSelectedRoles.DataBind()
        End If

        Dim dsAllRoles As DataSet = Me.oRole.GetAllRoles()
        Me.lstAllRoles.DataSource = dsAllRoles.Tables(Me.oRole.TableName).DefaultView
        Me.lstAllRoles.DataValueField = Me.oRole.PrimaryKey
        Me.lstAllRoles.DataTextField = Me.oRole.DescriptionField
        Me.lstAllRoles.DataBind()
    End Sub

    Protected Function GetUserPk() As Object
        Dim UserPk As Object = Nothing
        Try
            UserPk = Me.txtPk.Text
        Catch
            Me.lblError.Text = Me.GetMessage("Invalid user selected")
            Return Nothing
        End Try
        Return UserPk
    End Function

    Protected Sub lstUsers_SelectedIndexChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles lstUsers.SelectedIndexChanged
        Dim UserPk As Object = Nothing
        Try
            UserPk = Me.lstUsers.SelectedValue
        Catch
            Me.lblError.Text = "Invalid UserPk"
            Return
        End Try

        Me.LoadUser(UserPk)
        Me.LoadRoleLists(UserPk)
    End Sub


    Protected Sub btnSave_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnSave.Click
        Dim UserPk As Object = Nothing
        Try
            UserPk = Me.txtPk.Text
            If UserPk.ToString() = "-1" Then
                UserPk = Nothing
            End If
        Catch
            Me.lblError.Text = "Invalid Pk Value. Can't save" ' Developer message
            Return
        End Try

        If Not Me.SaveUser(UserPk) Then
            Me.lblError.Text = Me.GetMessage("Unable to save user")
        Else
            Me.lblError.Text = Me.GetMessage("User saved")
        End If
    End Sub


    Protected Sub btnAdd_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnAdd.Click
        Me.ClearFields()
        Me.btnSave.Enabled = True
    End Sub

    Protected Sub btnDelete_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnDelete.Click
        Dim UserPk As Object = Nothing

        If Me.lstUsers.SelectedIndex < 0 Then
            Me.lblError.Text = Me.GetMessage("No User selected")
            Return
        End If

        Try
            UserPk = Long.Parse(Me.txtPk.Text)
        Catch
            Me.lblError.Text = "Invalid Pk Value. Can't save" ' Developer message
            Return
        End Try

        If Not Me.oUser.Delete(UserPk) Then
            Me.lblError.Text = Me.GetMessage("Unable to delete user")
        Else
            Me.lblError.Text = Me.GetMessage("User deleted")
            Me.ClearFields()
            Me.LoadUserList()
        End If
    End Sub


    Protected Sub btnAddRole_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnAddRole.Click
        Dim RolePk As Long = -1
        If Me.lstAvailableRoles.SelectedIndex < 0 Then
            Me.lblError.Text = Me.GetMessage("No Role selected to add")
            Return
        End If

        RolePk = Integer.Parse(Me.lstAvailableRoles.SelectedValue)

        Dim UserPk As Object = Nothing
        Try
            UserPk = Me.txtPk.Text
        Catch
            Me.lblError.Text = "Invalid Pk Value. Can't save" ' Developer message
        End Try

        If Not Me.oRole.AddUserToRole(UserPk, RolePk) Then
            Me.lblError.Text = Me.GetMessage("Unable to add user to role")
        End If

        Me.LoadRoleLists(UserPk)
    End Sub

    Protected Sub btnRemoveRole_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnRemoveRole.Click
        Dim RolePk As Object = Nothing
        If Me.lstSelectedRoles.SelectedIndex < 0 Then
            Me.lblError.Text = Me.GetMessage("No Role selected to remove")
            Return
        End If

        RolePk = Me.lstSelectedRoles.SelectedValue

        Dim UserPk As Object = Me.GetUserPk()

        If Not Me.oRole.RemoveUserFromRole(UserPk, RolePk) Then
            Me.lblError.Text = Me.GetMessage("Unable to remove user from role")
        End If

        Me.LoadRoleLists(UserPk)
    End Sub

    Protected Sub btnDeleteRole_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnDeleteRole.Click
        Dim RolePk As Object = Nothing

        If Me.lstAllRoles.SelectedIndex < 0 Then
            Me.lblError.Text = Me.GetMessage("No Role Selected to delete")
            Return
        End If

        RolePk = Me.lstAllRoles.SelectedValue

        If Not Me.oRole.Delete(RolePk) Then
            Me.lblError.Text = Me.GetMessage("Unable to delete role")
        End If

        Dim UserPk As Object = Me.GetUserPk()
        Me.LoadRoleLists(UserPk)
    End Sub

    Protected Sub btnAddNewRole_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnAddNewRole.Click
        If Me.txtNewRole.Text = "" Then
            Me.lblError.Text = ""
            Return
        End If

        Me.oRole.NewRow()

        Dim Role As DataRow = Me.oRole.DataRow

        Role(Me.oRole.DescriptionField) = Me.txtNewRole.Text

        If Me.oRole.SaveRow() <> mmSaveDataResult.RulesPassed Then
            Me.lblError.Text = Me.GetMessage("Unable to add new role")
        End If

        Dim UserPk As Object = Me.GetUserPk()
        Me.txtNewRole.Text = ""
        Me.LoadRoleLists(UserPk)
    End Sub

End Class
