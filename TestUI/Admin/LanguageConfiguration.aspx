<%@ Page Language="VB" AutoEventWireup="false" CodeFile="LanguageConfiguration.aspx.vb" Inherits="LanguageConfiguration" StylesheetTheme="MMTheme" %>

<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">

<html xmlns="http://www.w3.org/1999/xhtml" >
<head runat="server">
    <title>Language Administration</title>
</head>
<body>
     <form id="form1" runat="server">
			<h1><mm:mmlabel id="lblHeader" runat="server">Language Administration</mm:mmlabel></h1>
			<table class="gridheader" cellpadding="10" width="100%">
				<tr>
					<td>
						<p><mm:mmlabel id="lblGridHeader" runat="server">This form allows you to translate messages for any controls that are marked as localizable on the form. You can select the original message text and enter a translation for each of the available languages.</mm:mmlabel></p>
					</td>
				</tr>
			</table>
			<br>
			<mm:mmHyperLink id="lnkAdminForm" runat="server" Text="Admin Form" NavigateUrl="default.aspx"></mm:mmHyperLink>
			<p></p>
			<table id="Table1" height="384" cellpadding="4" width="739" align="center" bgcolor="#eeeeee"
				border="1">
				<tr>
					<td valign="top" width="305" rowspan="2">
						<p><strong><mm:mmlabel id="lblUserList" runat="server" text="Localizable Text:"></mm:mmlabel></strong><mm:mmlistbox id="lstMessages" runat="server" height="408px" width="320px" autopostback="True" OnSelectedIndexChanged="lstMessages_SelectedIndexChanged"></mm:mmlistbox></p>
					</td>
					<td valign="top" colspan="2">
						<p><strong><mm:mmlabel id="lblLanguages" runat="server" text="Languages:"></mm:mmlabel><br>
							</strong>
							<mm:mmdropdownlist id="lstLanguage" runat="server" width="371px" autopostback="True" OnSelectedIndexChanged="lstLanguage_SelectedIndexChanged"></mm:mmdropdownlist><mm:mmbutton id="btnShowLanguageEditor" runat="server" text="..." OnClick="btnShowLanguageEditor_Click"></mm:mmbutton><br>
							<mm:mmtextbox id="txtAddLanguage" runat="server" width="144px" visible="False"></mm:mmtextbox><strong><mm:mmlabel id="lblCulture" runat="server" text="Culture:" visible="False"></mm:mmlabel></strong><mm:mmdropdownlist id="lstAddCulture" runat="server" autopostback="True" width="89px" Visible="False"></mm:mmdropdownlist><mm:mmbutton id="btnAddLanguage" runat="server" text="Add" visible="False" OnClick="btnAddLanguage_Click"></mm:mmbutton><mm:mmbutton id="btnDeleteLanguage" runat="server" text="Delete" visible="False" OnClick="btnDeleteLanguage_Click"></mm:mmbutton></p>
						<p><strong><mm:mmlabel id="lblTranslatedText" runat="server" text="Translated Text:"></mm:mmlabel><br>
							</strong>
							<mm:mmtextbox id="txtTranslatedText" runat="server" height="92px" width="395px" TextMode="MultiLine"></mm:mmtextbox><br>
							<mm:mmbutton id="btnSave" accesskey="S" runat="server" text="Save Translation" OnClick="btnSave_Click"></mm:mmbutton></p>
						<p><mm:mmlabel id="lblError" runat="server" enableviewstate="False" cssclass="errormessage" AccessLevel="Full" BindingProperty="Text" BindingSource="" BindingSourceMember="" ControlID="00000000-0000-0000-0000-000000000000" DisplayFormat="" IsPostBack="False" SecuritySetup="True" UserFieldName=""></mm:mmlabel></p>
						<p align="center"><img src="..\images\mmlogo.gif"></p>
					</td>
				<tr>
					<td><mm:mmcheckbox id="chkShowSystemMessages" runat="server" autopostback="True" text="Show System Messages" OnCheckedChanged="chkShowSystemMessages_CheckedChanged"></mm:mmcheckbox></td>
					<td align="right"><mm:mmhyperlink id="lnkSecurityAdmin" runat="server" navigateurl="javascript:window.close();">Close Form</mm:mmhyperlink></td>
				<tr>
				</tr>
			</table>
			<p>&nbsp;</p>
    </form>
</body>
</html>
