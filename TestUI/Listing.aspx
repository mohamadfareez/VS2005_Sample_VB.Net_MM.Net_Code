<%@ Page Language="VB" MasterPageFile="~/MasterPageMain.master" AutoEventWireup="false" CodeFile="Listing.aspx.vb" Inherits="Listing" title="Untitled Page" %>
<asp:Content ID="Content1" ContentPlaceHolderID="ContentPlaceHolder1" Runat="Server">
    <div style="text-align: center">
        <table border="0" cellpadding="0" cellspacing="0" style="width: 100%">
            <tr>
                <td style="width: 100px">
                    <strong><span style="text-decoration: underline">Halaman Senarai Pengguna</span></strong></td>
            </tr>
            <tr>
                <td style="width: 100px">
                </td>
            </tr>
            <tr>
                <td style="width: 100px">
                    Nama Pengguna :
                    <mm:mmTextBox ID="txtCariNamaPengguna" runat="server"></mm:mmTextBox></td>
            </tr>
            <tr>
                <td style="width: 100px">
                </td>
            </tr>
            <tr>
                <td style="width: 100px">
                    <mm:mmButton ID="btnCari" runat="server" Text="CARI" /></td>
            </tr>
            <tr>
                <td style="width: 100px">
                </td>
            </tr>
            <tr>
                <td align="center" style="width: 100px">
                    <mm:mmGridView ID="gvList" runat="server" AccessLevel="Full" AutoGenerateColumns="False"
                        BackColor="#CCCCCC" BindingSource="" BindingSourceMember="" BorderColor="#999999"
                        BorderStyle="Solid" BorderWidth="3px" CellPadding="4" CellSpacing="2" ControlID="00000000-0000-0000-0000-000000000000"
                        DataSourceID="odsGV" ForeColor="Black" IsPostBack="False" SecuritySetup="True"
                        UserFieldName="">
                        <FooterStyle BackColor="#CCCCCC" />
                        <HeaderStyle BackColor="Black" Font-Bold="True" ForeColor="White" />
                        <PagerStyle BackColor="#CCCCCC" ForeColor="Black" HorizontalAlign="Left" />
                        <Columns>
                            <asp:BoundField DataField="Nama" HeaderText="Nama" />
                            <asp:BoundField DataField="NoMyKad" HeaderText="No MyKad" />
                            <asp:BoundField DataField="TkhLahir" HeaderText="Tarikh Lahir" />
                            <asp:HyperLinkField DataNavigateUrlFields="PK_Individu" DataNavigateUrlFormatString="Listing.aspx?Value={0}"
                                DataTextFormatString="{0:dd/MM/yyyy}" Text="LIHAT" />
                        </Columns>
                        <SelectedRowStyle BackColor="#000099" Font-Bold="True" ForeColor="White" />
                        <RowStyle BackColor="White" />
                    </mm:mmGridView>
                    <asp:ObjectDataSource ID="odsGV" runat="server" SelectMethod="GetAllListIndividu"
                        TypeName="TestBusiness.Individu">
                        <SelectParameters>
                            <asp:ControlParameter ControlID="txtCariNamaPengguna" Name="Nama" PropertyName="Text"
                                Type="String" />
                        </SelectParameters>
                    </asp:ObjectDataSource>
                </td>
            </tr>
        </table>
    </div>
</asp:Content>

