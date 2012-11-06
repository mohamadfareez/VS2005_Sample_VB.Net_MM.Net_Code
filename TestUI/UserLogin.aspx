<%@ Page Language="VB" AutoEventWireup="false" CodeFile="UserLogin.aspx.vb" Inherits="UserLogin" StylesheetTheme="MMTheme" %>

<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">

<html xmlns="http://www.w3.org/1999/xhtml" >
<head id="Head1" runat="server">
    <title>User Login</title>
</head>
<body>
    <form id="form1" runat="server">
    <div>
    			<h1><mm:mmLabel id="lblUserLoginHeader" runat="server" Text="Application User Login" Font-Size="Medium"></mm:mmLabel></h1>
			<p>
                &nbsp;<table style="WIDTH: 369px; HEIGHT: 100px" cellpadding="6" width="369" align="center" bgcolor="#eeeeee"
					border="0">
					<tr>
						<td class="blockheader" colspan="2"><strong><mm:mmlabel id="lblUserLogin" runat="server" text="User Login"></mm:mmlabel></strong>
						</td>
					</tr>
					<tr>
						<td style="WIDTH: 79px">
							<mm:mmlabel id="lblUserID" runat="server" text="User ID:"></mm:mmlabel>
						</td>
						<td><mm:mmTextBox runat="server" ControlID="00000000-0000-0000-0000-000000000000" IsPostBack="False"
								BindingSource="this" AccessLevel="Full" BindingSourceMember="Username" SecuritySetup="True"
								ID="txtUsername" size="20" maxsize="15" Width="148px"></mm:mmTextBox>
						</td>
					</tr>
					<tr>
						<td style="WIDTH: 79px">
							<mm:mmlabel id="lblPassword" runat="server" text="Password:"></mm:mmlabel>
						</td>
						<td>
							<mm:mmTextBox runat="server" ControlID="00000000-0000-0000-0000-000000000000" TextMode="Password"
								IsPostBack="False" BindingSource="this" Width="148px" AccessLevel="Full" BindingSourceMember="Password"
								SecuritySetup="True" ID="txtPassword" size="20" maxsize="15"></mm:mmTextBox>
						</td>
					</tr>
					<tr>
						<td></td>
						<td>
							<p>
								<mm:mmbutton id="btnLogin" runat="server" text="Log in" width="120px" onclick="btnLogin_Click"></mm:mmbutton>&nbsp;
								<mm:mmbutton id="btnLogout" runat="server" text="Log out" width="120px" onclick="btnLogout_Click"></mm:mmbutton></p>
						</td>
					</tr>
					<tr>
						<td></td>
						<td><asp:label id="lblErrorMessage" runat="server" width="264px" cssclass="errormessage"></asp:label></td>
					</tr>
				</table>
			</p>
				<hr>
    </div>
    </form>
</body>
</html>
