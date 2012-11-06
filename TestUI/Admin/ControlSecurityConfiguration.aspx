<%@ Page Language="VB" AutoEventWireup="false" CodeFile="ControlSecurityConfiguration.aspx.vb" Inherits="ControlSecurityConfiguration" StylesheetTheme="MMTheme" %>

<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">

<html xmlns="http://www.w3.org/1999/xhtml" >
<head runat="server">
    <title>Control Security Configuration</title>
</head>
<body>
      <form id="Form1" method="post" runat="server">
         <h1><mm:mmLabel id="lblHeader" runat="server" Text="Control Security Configuration"></mm:mmLabel></h1>
         <table class="gridheader" cellpadding="10">
            <tr>
               <td><mm:mmLabel id="lblGridHeader" runat="server">This form is used to configure the access rights for users and roles of the application. You can assign users and roles to the control and set the specific access for each.</mm:mmLabel></td>
            </tr>
         </table>
         <br/>
         <br/>
         <p></p>
		<p><strong>
			<mm:mmLabel id="lblFieldDescription" runat="server" Text="Field Description:"></mm:mmLabel><br/>
			<mm:mmtextbox id="txtControlDescription" runat="server" backcolor="#E0E0E0" readonly="True" width="504px"></mm:mmtextbox><br/>
			</strong><br/>
		</p>
         <table id="Table1" cellpadding="6" width="300" bgcolor="#eeeeee" border="1">
            <tr>
               <td style="WIDTH: 175px">
					<p><strong>
						<mm:mmLabel id="lblAvailableUsers" runat="server">Available Users:</mm:mmLabel>
						<mm:mmlistbox id="lstUsers" runat="server" width="272px" height="136px" autopostback="True" onselectedindexchanged="lstUsers_SelectedIndexChanged"></mm:mmlistbox>
					</strong></p>
               </td>
				<td><strong>
					<mm:mmlabel id="lblUserAssign" runat="server" Text="Right to assign:"></mm:mmlabel><br/>
					</strong>
					<mm:mmdropdownlist id="cboUserAccessLevel" runat="server" width="160px"></mm:mmdropdownlist><br/>
					<mm:mmbutton id="btnSaveUser" accesskey="s" runat="server" width="128px" text="Set User Access" onclick="btnSaveUser_Click"></mm:mmbutton>
					<br/>
					<mm:mmlabel id="lblUserError" runat="server" width="200px" cssclass="ErrorMessage"></mm:mmlabel>
				</td>
            </tr>
         </table>
         <p>
            <table style="WIDTH: 464px; HEIGHT: 166px" cellpadding="6" width="464" bgcolor="#eeeee0"
               border="1">
               <tr>
                  <td>
						<p><strong><mm:mmLabel id="lblAvailableControls" runat="server" Text="Available Roles:"></mm:mmLabel></strong><br/>
							<mm:mmlistbox id="lstRoles" runat="server" width="272px" height="136px" autopostback="True" onselectedindexchanged="lstRoles_SelectedIndexChanged"></mm:mmlistbox></p>
                  </td>
                  <td>
                     <p><strong>
						<mm:mmLabel id="lblRoleAssign" runat="server" Text="Right to assign:"></mm:mmLabel></strong><br/>
                        <mm:mmdropdownlist id="cboRoleAccessLevel" runat="server" width="168px"></mm:mmdropdownlist><br/>
                        <mm:mmbutton id="btnSaveRole" accesskey="s" runat="server" width="136px" text="Set Role Access" onclick="btnSaveRole_Click"></mm:mmbutton><br/>
                     </p>
                     <p><mm:mmlabel id="lblRoleError" runat="server" width="200px" cssclass="ErrorMessage"></mm:mmlabel></p>
                  </td>
               </tr>
            </table>
            <table id="Table2" cellspacing="1" cellpadding="1" width="97%" border="0">
               <tr>
                  <td valign="top">
					<mm:mmButton id="btnClose" runat="server" Text="Close"></mm:mmButton>
					<mm:mmbutton id="btnLogout" runat="server" width="216px" text="Logout from Security Admin" onclick="btnLogout_Click"></mm:mmbutton></td>
                  <td valign="top" align="right">
					<mm:mmHyperLink id="lnkSecurityAdmin" runat="server" Text="Security Administration" NavigateUrl="UserAdmin.aspx"></mm:mmHyperLink>
                  </td>
               </tr>
            </table>
         </p>
         <p></p>
      </form>
</body>
</html>
