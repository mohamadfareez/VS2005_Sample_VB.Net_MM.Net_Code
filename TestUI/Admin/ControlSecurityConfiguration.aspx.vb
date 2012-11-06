Imports System
Imports System.Collections
Imports System.ComponentModel
Imports System.Data
Imports System.Drawing
Imports System.Web
Imports System.Web.SessionState
Imports System.Web.UI
Imports System.Web.UI.WebControls
Imports System.Web.UI.HtmlControls

Imports OakLeaf.MM.Main
Imports OakLeaf.MM.Main.Security
Imports OakLeaf.MM.Main.Web
Imports OakLeaf.MM.Main.Web.UI
Imports OakLeaf.MM.Main.Business

Partial Class ControlSecurityConfiguration
    Inherits mmBusinessWebPage

    Public ControlId As String

    Protected oUser As mmUser
    Protected oRole As mmRole
    Protected oUserSecurity As mmUserSecurity
    Protected oRoleSecurity As mmRoleSecurity
    Protected oSecurityManager As mmSecurityManager

    Protected oSecurity As mmSecurity
    Protected dsUserSecurity As DataSet
    Protected dsRoleSecurity As DataSet
    Protected AccessLevels(2) As String

    Dim AdminLogin As Boolean = True

    Protected Sub Page_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load

        Me.btnClose.Attributes.Add("OnClick", "CloseWindow();")
        Me.PageCaption.InnerText = Me.GetMessage("Control Security Configuration")

        AccessLevels(0) = Me.GetMessage("None")
        AccessLevels(1) = Me.GetMessage("Read-Only")
        AccessLevels(2) = Me.GetMessage("Full")

        Try
            AdminLogin = CBool(Session("mmUserSecurity_SecurityAdmin"))
        Catch
        End Try
        If Not AdminLogin Then
            Me.btnLogout.Text = Me.GetMessage("Log in for Security Admin")
        End If

        ' Put user code to initialize the page here
        ' Store a reference to the secure control
        'this.SecureControl = secureControl;
        Me.ControlId = Request.QueryString("ControlId")

        ' Instantiate and register the User and Role objects
        Me.oUser = mmAppWeb.Factory.CreateUserObject()
        Me.RegisterBizObj(Me.oUser)
        Me.oRole = mmAppWeb.Factory.CreateRoleObject()
        Me.RegisterBizObj(Me.oRole)

        Me.oUserSecurity = mmAppWeb.Factory.CreateUserSecurityObject()
        Me.oRoleSecurity = mmAppWeb.Factory.CreateRoleSecurityObject()
        Me.oSecurityManager = mmAppWeb.Factory.CreateSecurityManager()

        Me.oSecurity = mmAppWeb.Factory.CreateSecurityObject()

        ' Get the control description
        Me.txtControlDescription.Text = Me.oSecurity.GetSecurityObjectDescription(New Guid(Me.ControlId))

        ' Get all Users and Roles
        Me.oUser.GetAllUserNames()
        Me.oRole.GetAllRoles()

        ' Get the user and role security data
        Me.dsUserSecurity = Me.oUserSecurity.GetAllUserSecurity()
        Me.dsRoleSecurity = Me.oRoleSecurity.GetAllRoleSecurity()

        If Not Me.IsPostBack Then
            ' Set the access level combo boxes
            Dim AccessLevel As String
            For Each AccessLevel In AccessLevels
                Me.cboRoleAccessLevel.Items.Add(AccessLevel)
            Next AccessLevel
            For Each AccessLevel In AccessLevels
                Me.cboUserAccessLevel.Items.Add(AccessLevel)
            Next AccessLevel
            Me.lstUsers.DataSource = Me.oUser.GetCurrentDataSet().Tables(0).DefaultView
            Me.lstUsers.DataTextField = Me.oUser.FullNameField
            Me.lstUsers.DataValueField = Me.oUser.PrimaryKey
            Me.lstUsers.DataBind()

            Me.lstRoles.DataSource = Me.oRole.GetCurrentDataSet().Tables(0).DefaultView
            Me.lstRoles.DataTextField = Me.oRole.DescriptionField
            Me.lstRoles.DataValueField = Me.oRole.PrimaryKey
            Me.lstRoles.DataBind()
        End If
    End Sub

    Protected Sub btnSaveUser_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnSaveUser.Click

        Dim AccessLevel As Integer = Me.cboUserAccessLevel.SelectedIndex
        Dim UserPK As Integer = 0

        If Me.lstUsers.SelectedIndex < 0 Then
            Me.lblUserError.Text = Me.GetMessage("No User selected")
            Return
        End If

        Try
            UserPK = Int32.Parse(Me.lstUsers.SelectedValue)
        Catch
        End Try

        If UserPK > 0 Then
            Me.oUserSecurity.SetUserSecurity(UserPK, New Guid(Me.ControlId), AccessLevel, dsUserSecurity)
        End If

        If Me.oUserSecurity.SaveDataSet(Me.dsUserSecurity) = mmSaveDataResult.RulesPassed Then
            Me.lblUserError.Text = Me.GetMessage("User access level set")
        Else
            Me.lblUserError.Text = Me.GetMessage("User access level failed to set")
        End If
    End Sub

    Protected Sub btnSaveRole_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnSaveRole.Click

        Dim AccessLevel As Integer = Me.cboRoleAccessLevel.SelectedIndex
        Dim RolePK As Integer = 0

        If Me.lstRoles.SelectedIndex < 0 Then
            Me.lblRoleError.Text = Me.GetMessage("No Role selected")
            Return
        End If

        Try
            RolePK = Int32.Parse(Me.lstRoles.SelectedValue)
        Catch
        End Try

        If RolePK > 0 Then
            Me.oRoleSecurity.SetRoleSecurity(RolePK, Me.ControlId, AccessLevel, Me.dsRoleSecurity)

            If Me.oRoleSecurity.SaveDataSet(Me.dsRoleSecurity) = mmSaveDataResult.RulesPassed Then
                Me.lblRoleError.Text = Me.GetMessage("Role Assigned to control")
                Return
            End If
        End If

        Me.lblRoleError.Text = Me.GetMessage("Role Assignment failed")

    End Sub

    Protected Sub btnLogout_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnLogout.Click
        Session("mmUserSecurity_SecurityAdmin") = False

        If Not AdminLogin Then
            Session("mmUserSecurity_SecurityAdmin") = True
            Me.btnLogout.Text = Me.GetMessage("Log out of Security Admin")
            Me.lblUserError.Text = Me.GetMessage("Logged in for Security Admin")
        Else
            Session("mmUserSecurity_SecurityAdmin") = False
            Me.btnLogout.Text = Me.GetMessage("Log in for Security Admin")
            Me.lblUserError.Text = Me.GetMessage("Logged out of Security Admin")
        End If
    End Sub

    Protected Sub lstUsers_SelectedIndexChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles lstUsers.SelectedIndexChanged
        Dim UserPK As Integer = 0
        Try
            UserPK = Int32.Parse(Me.lstUsers.SelectedValue)
        Catch
        End Try
        Dim AccessLevel As mmSecurityAccessLevel = Me.oSecurityManager.GetAccessLevel(UserPK, New Guid(Me.ControlId))
        Me.cboUserAccessLevel.SelectedIndex = CInt(AccessLevel)
    End Sub

    Protected Sub lstRoles_SelectedIndexChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles lstRoles.SelectedIndexChanged
        Dim RolePK As Integer = 0
        Try
            RolePK = Int32.Parse(Me.lstRoles.SelectedValue)
        Catch
        End Try
        Dim AccessLevel As mmSecurityAccessLevel = mmAppWeb.DefaultSecurityAccessLevel

        ' Search for a role security record for the current control 
        ' and the currently selected role
        Dim rows() As DataRow
        Dim Value As Object = Me.lstRoles.SelectedValue

        rows = Me.oRoleSecurity.GetCurrentDataSet().Tables(0).Select((Me.oRoleSecurity.RoleFKField + " = " + RolePK.ToString() + " AND " + Me.oUserSecurity.SecurityFKField + " = '" + Me.ControlId + "'"))

        If rows.Length > 0 Then
            ' Convert the database setting to the corresponding access level
            AccessLevel = Me.oSecurityManager.ConvertAccessLevel(rows(0)(Me.oRoleSecurity.AccessLevelField))
        End If

        Me.cboRoleAccessLevel.SelectedIndex = CInt(AccessLevel)
    End Sub

    ''' <summary>
    ''' Close the window
    ''' </summary>
    Protected Sub btnClose_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles btnClose.Click
        Response.Write("<script language='javascript'> { window.close();}</script>")
    End Sub
End Class
