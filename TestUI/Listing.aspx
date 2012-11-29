<%@ Page Language="VB" MasterPageFile="~/MasterPageMain.master" AutoEventWireup="false" CodeFile="Listing.aspx.vb" Inherits="Listing" title="Untitled Page" %>
<asp:Content ID="Content1" ContentPlaceHolderID="ContentPlaceHolder1" Runat="Server">
    <div style="text-align: center">
        <table border="0" cellpadding="0" cellspacing="0" style="width: 100%">
            <tr>
                <td style="height: 20px" align="center">
                </td>
            </tr>
            <tr>
                <td align="center">
                    <strong><span style="text-decoration: underline">Halaman Senarai Pengguna</span></strong></td>
            </tr>
            <tr>
                <td style="height: 20px" align="center">
                </td>
            </tr>
            <tr>
                <td align="center">
                    Nama Pengguna :
                    <mm:mmTextBox ID="txtCariNamaPengguna" runat="server"></mm:mmTextBox></td>
            </tr>
            <tr>
                <td style="height: 12px" align="center">
                </td>
            </tr>
            <tr>
                <td align="center">
                    &nbsp;<table border="0" cellpadding="1" cellspacing="1">
                        <tr>
                            <td style="width: 100px">
                                <mm:mmButton ID="btnCari" runat="server" Text="CARI" /></td>
                            <td style="width: 100px">
                                <mm:mmButton ID="btnBaru" runat="server" Text="BARU" /></td>
                        </tr>
                    </table>
                </td>
            </tr>
            <tr>
                <td style="height: 12px" align="center">
                </td>
            </tr>
            <tr>
                <td align="center">
                    <mm:mmGridView ID="gvList" runat="server" AccessLevel="Full" AutoGenerateColumns="False"
                        BackColor="#CCCCCC" BorderColor="#999999"
                        BorderStyle="Solid" BorderWidth="3px" CellPadding="4" CellSpacing="2" ControlID="00000000-0000-0000-0000-000000000000"
                        DataSourceID="odsGV" ForeColor="Black" IsPostBack="False" SecuritySetup="True">
                        <FooterStyle BackColor="#CCCCCC" />
                        <HeaderStyle BackColor="Black" Font-Bold="True" ForeColor="White" />
                        <PagerStyle BackColor="#CCCCCC" ForeColor="Black" HorizontalAlign="Left" />
                        <Columns>
                            <asp:BoundField DataField="Nama" HeaderText="Nama" />
                            <asp:BoundField DataField="NoMyKad" HeaderText="No MyKad" />
                            <asp:BoundField DataField="TkhLahir" HeaderText="Tarikh Lahir" DataFormatString="{0:dd/MM/yyyy}"  />
                            <asp:HyperLinkField DataNavigateUrlFields="PK_Individu" DataNavigateUrlFormatString="Listing.aspx?Value={0}"
                               Text="LIHAT" />
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

