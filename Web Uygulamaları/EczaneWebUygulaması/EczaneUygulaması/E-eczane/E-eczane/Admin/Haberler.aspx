<%@ Page Title="" Language="C#" MasterPageFile="~/Admin/AdminTema.Master" AutoEventWireup="true" CodeBehind="Haberler.aspx.cs" Inherits="E_eczane.Admin.Haberler" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
  
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <h1 style="text-align: center; color: red">HABERLER</h1>

    <div class="col-md-12" style="margin-bottom:5%">
        <asp:GridView ID="GridViewHaberListele" runat="server"
            AutoGenerateColumns="False" CellPadding="4" ForeColor="#333333"
            GridLines="None" Height="315px" Width="100%" AutoGenerateSelectButton="True" OnSelectedIndexChanged="GridViewHaberListele_SelectedIndexChanged">
            <AlternatingRowStyle BackColor="White" />
            <Columns>
                <asp:BoundField DataField="haberID" HeaderText="HABER ID" />
                <asp:BoundField DataField="haberBaslik" HeaderText="HABER BAŞLIK" />
                <asp:BoundField DataField="haberAciklama" HeaderText="HABER AÇIKLAMA" />
                <asp:BoundField DataField="haberTarih" HeaderText="HABER TARİH" />
                <asp:BoundField DataField="haberResim" HeaderText="HABER RESİM" />
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
    <div style="margin-top:10%">
        <div class="col-md-12">
            <div class="col-md-8">
               <table>
             <tr>
                <td class="control-label col-md-2">Haber ID</td>
                <td>
                    <div class="form-group col-md-8">
                        <asp:Label ID="LabelHaberID" runat="server" Text="Label" Font-Bold="true" ForeColor="Red" Font-Size="Large"></asp:Label>
                    </div>

                </td>
            </tr>
            <tr>
                <td class="control-label col-md-2">Haber Adı</td>
                <td>
                    <div class="form-group col-md-8">
                        <asp:TextBox class="form-control" ID="TextHaberAdi" runat="server" autocomplete="off" autofocus="" ></asp:TextBox>
                    </div>

                </td>
            </tr>
           <tr>
                <td class="control-label col-md-2">Haber Açıklaması</td>
                <td>
                    <div class="form-group col-md-8">
                        <asp:TextBox class="form-control" ID="TextHaberAciklamasi" runat="server" autocomplete="off" autofocus=""></asp:TextBox>
                    </div>


                </td>
            </tr>
            <tr>
              <td class="control-label col-md-2">Haber Resim</td>
                <td>
                    <div class="form-group col-md-8">
                        <asp:TextBox class="form-control" ID="TextBoxHaberResim" runat="server" type="file" autocomplete="off" autofocus=""></asp:TextBox>
                    </div>

                </td>
            </tr>
             <tr>
            
                <td>
                    <div class="form-group col-md-8">
                        <asp:TextBox class="form-control" ID="TextBoxTarih" runat="server"  autocomplete="off" autofocus="" Visible="false"></asp:TextBox>
                    </div>

                </td>
            </tr>
           
        </table>
            </div>
            <div class="col-md-4">
                 <asp:Button ID="ButtonEKLE"  runat="server" Text="EKLE" class="btn btn-primary" Width="200PX" OnClick="ButtonEKLE_Click" /><br /><br />
                  <asp:Button ID="ButtonSil"  runat="server" Text="SİL" class="btn btn-danger" Width="200PX"  OnClick="ButtonSil_Click" /><br /><br />
                  <asp:Button ID="ButtonDuzenle"  runat="server" Text="DÜZENLE" class="btn btn-success" Width="200PX" OnClick="ButtonDuzenle_Click"  /><br /><br />
                 <asp:Button ID="ButtonReset"  runat="server" Text="TEMİZLE" class="btn btn-default" Width="200PX" OnClick="ButtonReset_Click"  /><br /><br />
                 <asp:Label ID="LabelDurum" runat="server" Text="" ForeColor="Red" Visible="false"></asp:Label>
            </div>
        </div>
     
        <hr />
        <hr />
    </div>
</asp:Content>
