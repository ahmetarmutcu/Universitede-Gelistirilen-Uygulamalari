<%@ Page Title="" Language="C#" MasterPageFile="~/Admin/AdminTema.Master" AutoEventWireup="true" CodeBehind="IlacKategori.aspx.cs" Inherits="E_eczane.Admin.IlacKategori" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
     <h1 style="text-align: center; color: red">İLAÇ KATEGORİ SAYFASI</h1>
         <div class="col-md-12" style="margin-bottom:5%">
             <asp:GridView ID="GridIlacKategori" runat="server"
            AutoGenerateColumns="False" CellPadding="4" ForeColor="#333333"
            GridLines="None" Height="315px" Width="100%" AutoGenerateSelectButton="True" OnSelectedIndexChanged="GridIlacKategori_SelectedIndexChanged"  >
            <AlternatingRowStyle BackColor="White" />
            <Columns>
                <asp:BoundField DataField="kategoriID" HeaderText="KATEGORİ ID" />
                <asp:BoundField DataField="kategoriIsim" HeaderText="KATEGORİ ADI" />
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
     <div>
        <div class="col-md-12">
            <div class="col-md-8">
               <table>
             <tr>
                <td class="control-label col-md-2">İLAÇ KATEGORİ ID</td>
                <td>
                    <div class="form-group col-md-8">
                        <asp:Label ID="lblIlacKategoriID" runat="server" Text="Label" Font-Bold="true" ForeColor="Red" Font-Size="Large"></asp:Label>
                    </div>

                </td>
            </tr>
            <tr>
                <td class="control-label col-md-2">KATEGORİ ADI</td>
                <td>
                    <div class="form-group col-md-8">
                        <asp:TextBox class="form-control" ID="TextKategoriAdi" runat="server" autocomplete="off" autofocus="" ></asp:TextBox>
                    </div>

                </td>
            </tr>
        </table>
            </div>
            <div class="col-md-4">
                 <asp:Button ID="ButtonEkle"  runat="server" Text="EKLE" class="btn btn-primary" Width="200PX" OnClick="ButtonEkle_Click" /><br /><br />
                  <asp:Button ID="ButtonSil"  runat="server" Text="SİL" class="btn btn-danger" Width="200PX"  OnClick="ButtonSil_Click" /><br /><br />
                 <asp:Label ID="LabelDurum" runat="server" Text="" ForeColor="Red" Visible="false"></asp:Label>
            </div>
        </div>
     
        <hr />
        <hr />
    </div>
</asp:Content>
