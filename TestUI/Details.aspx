<%@ Page Language="VB" MasterPageFile="~/MasterPageMain.master" AutoEventWireup="false" CodeFile="Details.aspx.vb" Inherits="Details" title="Untitled Page" %>

<%@ Register Assembly="Mere Mortals Framework 2005 Infragistics Web Controls" Namespace="OakLeaf.MM.Main.Web.UI.WebControls.Infragistics"
    TagPrefix="cc1" %>
<asp:Content ID="Content1" ContentPlaceHolderID="ContentPlaceHolder1" Runat="Server">
    <table border="0" cellpadding="1" cellspacing="1" style="width: 100%">
        <tr>
            <td align="right" style="width: 50%">
            </td>
            <td align="center" style="width: 2px">
            </td>
            <td align="left" style="width: 50%; height: 20px">
            </td>
        </tr>
        <tr>
            <td align="center" colspan="3">
                <strong><span style="text-decoration: underline">Maklumat Pengguna</span></strong></td>
        </tr>
        <tr>
            <td align="right" style="width: 50%">
            </td>
            <td align="center" style="width: 2px">
            </td>
            <td align="left" style="width: 50%; height: 20px">
            </td>
        </tr>
        <tr>
            <td align="right" style="width: 50%">
                Nama</td>
            <td align="center" style="width: 2px">
                :</td>
            <td align="left" style="width: 50%">
                <mm:mmTextBox ID="txtNama" runat="server" BindingSource="Individu" BindingSourceMember="Nama"></mm:mmTextBox></td>
        </tr>
        <tr>
            <td align="right" style="width: 50%">
            </td>
            <td align="center" style="width: 2px">
            </td>
            <td align="left" style="width: 50%; height: 5px">
            </td>
        </tr>
        <tr>
            <td align="right" style="width: 50%">
                No MyKad</td>
            <td align="center" style="width: 2px">
                :</td>
            <td align="left" style="width: 50%; height: 5px;">
                <cc1:mmWebMaskEdit ID="txtNoMyKad" runat="server" BindingSource="Individu" BindingSourceMember="NoMyKad"
                    InputMask="############" SelectionOnFocus="CaretToBeginning">
                </cc1:mmWebMaskEdit>
            </td>
        </tr>
        <tr>
            <td align="right" style="width: 50%">
            </td>
            <td align="center" style="width: 2px">
            </td>
            <td align="left" style="width: 50%">
            </td>
        </tr>
        <tr>
            <td align="right" style="width: 50%">
                Tarikh Lahir</td>
            <td align="center" style="width: 2px">
                :</td>
            <td align="left" style="width: 50%">
                <cc1:mmWebDateChooser ID="wdcTkhLahir" runat="server" BindingSource="Individu" BindingSourceMember="TkhLahir">
                </cc1:mmWebDateChooser>
            </td>
        </tr>
        <tr>
            <td align="right" style="width: 50%">
            </td>
            <td align="center" style="width: 2px">
            </td>
            <td align="left" style="width: 50%; height: 5px">
            </td>
        </tr>
        <tr>
            <td align="right" style="width: 50%">
                Alamat</td>
            <td align="center" style="width: 2px">
                :</td>
            <td align="left" style="width: 50%">
                <mm:mmTextBox ID="txtAlamat" runat="server" BindingSource="Individu" BindingSourceMember="Alamat"
                    TextMode="MultiLine"></mm:mmTextBox></td>
        </tr>
        <tr>
            <td align="right" style="width: 50%">
            </td>
            <td align="center" style="width: 2px">
            </td>
            <td align="left" style="width: 50%; height: 5px">
            </td>
        </tr>
        <tr>
            <td align="right" style="width: 50%">
                Poskod</td>
            <td align="center" style="width: 2px">
                :</td>
            <td align="left" style="width: 50%">
                <cc1:mmWebMaskEdit ID="txtPoskod" runat="server" BindingSource="Individu" BindingSourceMember="Poskod"
                    InputMask="######" SelectionOnFocus="CaretToBeginning">
                </cc1:mmWebMaskEdit>
            </td>
        </tr>
        <tr>
            <td align="right" style="width: 50%">
            </td>
            <td align="center" style="width: 2px">
            </td>
            <td align="left" style="width: 50%; height: 5px">
            </td>
        </tr>
        <tr>
            <td align="right" style="width: 50%">
                Negeri</td>
            <td align="center" style="width: 2px">
                :</td>
            <td align="left" style="width: 50%">
                <mm:mmDropDownList ID="ddlNegeri" runat="server" BindingValueSource="Individu" BindingValueSourceMember="FK_Negeri"
                    DataSourceID="odsNegeri" DataTextField="Deskripsi" DataValueField="PK_Negeri">
                </mm:mmDropDownList>
                <asp:ObjectDataSource ID="odsNegeri" runat="server" SelectMethod="GetAllData" TypeName="TestBusiness.Negeri">
                </asp:ObjectDataSource>
            </td>
        </tr>
        <tr>
            <td align="right" style="width: 50%">
            </td>
            <td align="center" style="width: 2px">
            </td>
            <td align="left" style="width: 50%; height: 20px">
            </td>
        </tr>
        <tr>
            <td align="center" colspan="3">
                <table border="0" cellpadding="1" cellspacing="1">
                    <tr>
                        <td style="width: 100px">
                            <mm:mmButton ID="btnSimpan" runat="server" Text="SIMPAN" /></td>
                        <td style="width: 100px">
                            <mm:mmButton ID="btnPadam" runat="server" Text="PADAM" /></td>
                        <td style="width: 100px">
                            <mm:mmButton ID="btnKembali" runat="server" Text="KEMBALI" /></td>
                    </tr>
                </table>
            </td>
        </tr>
    </table>
</asp:Content>

