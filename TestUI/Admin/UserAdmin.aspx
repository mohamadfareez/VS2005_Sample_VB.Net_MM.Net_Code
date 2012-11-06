<%@ Page Language="VB" AutoEventWireup="false" CodeFile="UserAdmin.aspx.vb" Inherits="UserAdmin" StylesheetTheme="MMTheme" %>

<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">

<html xmlns="http://www.w3.org/1999/xhtml" >
<head id="Head1" runat="server">
    <title>User Administration</title>
    <link rel="stylesheet" type="text/css" />
</head>
<body>
    <form id="form1" runat="server">
         <h1>
            <mm:mmlabel id="lblHeader" runat="server" text="User and Role Administration"></mm:mmlabel></h1>
         <table class="gridheader" cellpadding="10">
            <tr>
               <td style="width: 1033px">
					<mm:mmLabel id="lblGridHeader" runat="server" AccessLevel="Full" BindingProperty="Text" BindingSource="" BindingSourceMember="" ControlID="00000000-0000-0000-0000-000000000000" DisplayFormat="" IsPostBack="False" SecuritySetup="True" Text="This form allows you to administer Users and Roles in your Mere Mortals .Net Application. Here you can add users and edit the security attributes and add users to specific Roles. You can also create and delete new Roles from this form." UserFieldName=""></mm:mmLabel>
               </td>
            </tr>
         </table>
         <br/>
         <mm:mmHyperLink id="lnkBackToAdmin" runat="server" Text="Back to Admin Form" NavigateUrl="default.aspx"></mm:mmHyperLink>
         <p><strong>
               <table id="Table1" cellpadding="4" width="794" border="1" bgcolor="#eeeeee" align="center"
                  height="474">
                  <tbody>
                     <tr>
                        <td width="218" valign="top">
                           <p>
                              <strong><mm:mmlabel id="lblUserList" runat="server" text="List of Users:"></mm:mmlabel></strong>
            </strong>
            <br/>
            <mm:mmlistbox id="lstUsers" runat="server" width="230px" height="458px" autopostback="True" OnSelectedIndexChanged="lstUsers_SelectedIndexChanged"></mm:mmlistbox><br/>
            <mm:mmbutton id="btnAdd" runat="server" width="72px" text="Add" OnClick="btnAdd_Click"></mm:mmbutton>
            <mm:mmbutton id="btnDelete" runat="server" width="72px" text="Delete" OnClick="btnDelete_Click"></mm:mmbutton>
         </p>
         <td valign="top" width="288">
            <p>
               <br>
               <strong>
                  <mm:mmlabel id="lblFirstName" runat="server" text="First Name:"></mm:mmlabel></strong>
               <br/>
               <mm:mmtextbox id="txtFirstName" runat="server" size="40" maxlength="40"></mm:mmtextbox></p>
            <p><strong>
                  <mm:mmlabel id="lblLastName" runat="server" text="Last Name:"></mm:mmlabel></strong>
               <br/>
               <mm:mmtextbox id="txtLastName" runat="server" size="40" maxlength="40"></mm:mmtextbox></p>
            <p><strong>
                  <mm:mmlabel id="lblUserID" runat="server" text="User Id:"></mm:mmlabel></strong>
               <br/>
               <mm:mmtextbox id="txtUserId" runat="server" size="10" maxlength="10"></mm:mmtextbox><br/>
               <br/>
               <strong>
                  <mm:mmlabel id="lblPassword" runat="server" text="Password:"></mm:mmlabel></strong>
               <br/>
               <mm:mmtextbox id="txtPassword" runat="server" size="10" maxlength="10"></mm:mmtextbox></p>
            <p>
               <mm:mmbutton id="btnSave" runat="server" width="88px" text="Save" enabled="False" OnClick="btnSave_Click"></mm:mmbutton><br/>
               <mm:mmtextbox id="txtPk" runat="server" visible="False" width="184px"></mm:mmtextbox><br/>
               <mm:mmlabel id="lblError" runat="server" width="296px" cssclass="errormessage"></mm:mmlabel>
               <br/>
            </p>
            <p align="center">
               <img src="..\images\mmlogo.gif"></p>
         </td>
         <td valign="top">
            <p><br/>
               <strong>
                  <mm:mmlabel id="lblSelectedRoles" runat="server" text="Selected Roles:"></mm:mmlabel>
               </strong>
               <br/>
               <mm:mmlistbox id="lstSelectedRoles" runat="server" width="224px" height="100px"></mm:mmlistbox>
               <mm:mmbutton id="btnAddRole" runat="server" text="^ Add" width="72px" OnClick="btnAddRole_Click"></mm:mmbutton>&nbsp;
               <mm:mmbutton id="btnRemoveRole" runat="server" text="Remove" width="72px" OnClick="btnRemoveRole_Click"></mm:mmbutton><br/>
               <br/>
               <strong>
                  <mm:mmlabel id="lblAvailableRoles" runat="server" text="Available Roles:"></mm:mmlabel>
               </strong>
               <br/>
               <mm:mmlistbox id="lstAvailableRoles" runat="server" width="224px" height="114px"></mm:mmlistbox>
               <strong>
                  <mm:mmlabel id="lblAllRoles" runat="server" text="All Roles:"></mm:mmlabel></strong><br/>
               <mm:mmlistbox id="lstAllRoles" runat="server" height="106px" width="224px"></mm:mmlistbox><br/>
               <mm:mmbutton id="btnDeleteRole" runat="server" width="112px" text="Delete Role" OnClick="btnDeleteRole_Click"></mm:mmbutton><br/>
               <mm:mmtextbox id="txtNewRole" runat="server" width="232px"></mm:mmtextbox><br>
               <mm:mmbutton id="btnAddNewRole" runat="server" width="112px" text="Add New Role" OnClick="btnAddNewRole_Click"></mm:mmbutton></p>
         </td>
         <p>&nbsp;</p>
    </form>
</body>
</html>
