<%@ Page Title="" Language="C#" MasterPageFile="~/Admin/AdminTema.Master" AutoEventWireup="true" CodeBehind="SiparisDetay.aspx.cs" Inherits="E_eczane.Admin.SiparisDetay" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
     <h1 style="text-align: center; color: red">SİPARİŞ DETAY</h1>

    <div class="col-md-12" style="margin-bottom:5%">
        <asp:GridView ID="GridSiparisListele" runat="server"
            AutoGenerateColumns="False" CellPadding="4" ForeColor="#333333"
            GridLines="None" Height="315px" Width="100%" AutoGenerateSelectButton="True" >
            <AlternatingRowStyle BackColor="White" />
            <Columns>
                <asp:BoundField DataField="ilacIsim" HeaderText="İLAÇ ADI" />
                <asp:BoundField DataField="yoneticiIsim" HeaderText="YONETİCİ İSİM" />
                <asp:BoundField DataField="yoneticiSoyisim" HeaderText="YONETİCİ SOYİSİM" />
                <asp:BoundField DataField="siparisAdet" HeaderText="ADET" />
                <asp:BoundField DataField="siparisTarihi" HeaderText="SİPARİŞ TARİHİ" />
            </Columns>
            <EditRowStyle BackColor="#7C6F57" />
            <FooterStyle BackColor="#1C5E55" Font-Bold="True" ForeColor="White" />
            <HeaderStyle BackColor="#1C5E55" Font-Bold="True" ForeColor="White" />
            <PagerStyle BackColor="#666666" ForeColor="White" HorizontalAlign="Center" />
            <RowStyle BackColor="#E3EAEB" />
            <SelectedRowStyle BackColor="#C5BBAF" Font-Bold="True" ForeColor="#333333" />
            <SortedAscendingCellStyle BackColor="#F8FAFA" />
            <SortedAscendingHeaderStyle BackColor="#246B61" />
            <SortedDescendingCellStyle BackColor="#D4DFE1" />
            <SortedDescendingHeaderStyle BackColor="#15524A" />
        </asp:GridView>
    </div>
</asp:Content>
