<%@ Page Language="VB" AutoEventWireup="false" CodeFile="Default.aspx.vb" Inherits="_Default" StylesheetTheme="MMTheme" %>

<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">

<html xmlns="http://www.w3.org/1999/xhtml" >
<head runat="server">
    <title>System Message Translation</title>
</head>
<body>
<form id="form1" runat="server">
    <h1>
        <mm:mmlabel id="lblPageHeader" runat="server" text="Mere Mortals Web Administration"></mm:mmlabel></h1>
             <p>&nbsp;</p>
         <table cellpadding="4" width="600" align="center" bgcolor="#eeeeee" border="1">
            <tr>
               <td valign="top" colspan="2">
                  <h2><mm:mmlabel id="lblAppAdministration" runat="server" text="Application Administration"></mm:mmlabel></h2>
                  <hr/>
                  <mm:mmlabel id="lblErrorMessage" runat="server" cssclass="ErrorMessage"></mm:mmlabel></td>
            </tr>
            <tr>
               <td valign="top"><img src="..\images\mmlogo.gif">
               </td>
               <td><br/>
                  <h3>
                     <mm:mmlabel id="lblSecurityTask" runat="server" text="Security Tasks"></mm:mmlabel></h3>
                  <hr/>
                  <ul>
                     <li>
                        <mm:mmhyperlink id="lnkSecurityAdmin" runat="server" navigateurl="UserAdmin.aspx">Security Administration</mm:mmhyperlink>
                     <li>
                        <mm:mmlinkbutton id="btnSecurityLogin" runat="server" OnClick="btnSecurityLogin_Click">Login for Security Administration</mm:mmlinkbutton></li></ul>
                  <p>
                     <h3>
                        <mm:mmlabel id="lblLocalizationTasks" runat="server" text="Localization Tasks"></mm:mmlabel></h3>
                     <ul>
                        <li>
                           <mm:mmlinkbutton id="btnShowTranslationDialogs" runat="server" text="Show Translation Buttons" OnClick="btnShowTranslationDialogs_Click"></mm:mmlinkbutton>
                        <li>
                           <mm:mmhyperlink id="lblSystemTranslation" runat="server" text="System Message Translation" navigateurl="LanguageConfiguration.aspx?SystemMessages=true"></mm:mmhyperlink></li></ul>
                  <p><br>
                  </p>
                  <h3>
                  <hr/>
                     <mm:mmlabel id="lblSecuritySettings" runat="server" text="System Settings"></mm:mmlabel></h3>
					<b><mm:mmlabel id="lblFrameworkVersion" runat="server" text=".NET Framework Version:"></mm:mmlabel></b><br/>
						<%= Environment.Version.ToString() %>
					<p><b><mm:mmlabel id="lblSystemAccount" runat="server" text="System Account Running App:"></mm:mmlabel></b><br/>
						<%= Environment.UserName %></p>
					<p><b><mm:mmlabel id="lblLoggedOnUser" runat="server" text="Logged on User:"></mm:mmlabel></b><br/>
						<%=IIf(User.Identity.Name = "", "Anonymous User" , User.Identity.Name)%>
					</p>
               </td>
            </tr>
         </table>
    </form>
</body>
</html>
