<%@ Page Title="" Language="C#" MasterPageFile="~/Admin/AdminTema.Master" AutoEventWireup="true" CodeBehind="Sorular.aspx.cs" Inherits="E_eczane.Admin.Sorular" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <h1 style="text-align: center; color: red">SORULAR</h1>

    <div class="col-md-12" style="margin-bottom: 5%">
        <asp:GridView ID="gridlistele" runat="server"
            AutoGenerateColumns="False" CellPadding="4" ForeColor="#333333"
            GridLines="None" Height="315px" Width="100%" AutoGenerateSelectButton="True" OnSelectedIndexChanged="gridlistele_SelectedIndexChanged">
            <AlternatingRowStyle BackColor="White" />
            <Columns>
                <asp:BoundField DataField="soruID" HeaderText="SORU ID" />
                <asp:BoundField DataField="kullaniciAdi" HeaderText="KULLANICI ADI" />
                <asp:BoundField DataField="soruAciklama" HeaderText="SORU" />
                <asp:BoundField DataField="soruTarih" HeaderText="SORU TARİHİ" />

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
    <div style="margin-top: 10%">
        <div class="col-md-12">
            <div class="col-md-8">
                <table>
                    <tr>
                        <td class="control-label col-md-2">SORU ID</td>
                        <td>
                            <div class="form-group col-md-8">
                                <asp:Label ID="LabelSoruID" runat="server" Text="Label" Font-Bold="true" ForeColor="Red" Font-Size="Large"></asp:Label>
                            </div>

                        </td>
                    </tr>
                    <tr>
                        <td class="control-label col-md-2">KULLANICI ADI</td>
                        <td>
                            <div class="form-group col-md-8">
                                <asp:TextBox class="form-control" ID="TextKullanicAdi" runat="server" autocomplete="off" autofocus=""></asp:TextBox>
                            </div>

                        </td>
                    </tr>
                    <tr>
                        <td class="control-label col-md-2">SORU</td>
                        <td>
                            <div class="form-group col-md-8">
                                <asp:TextBox class="form-control" ID="TextSoru" runat="server" autocomplete="off" autofocus=""></asp:TextBox>
                            </div>


                        </td>
                    </tr>
                    <tr>

                        <td>
                            <div class="form-group col-md-8">
                                <asp:TextBox class="form-control" ID="TextBoxTarih" runat="server" autocomplete="off" autofocus="" Visible="false"></asp:TextBox>
                            </div>
                        </td>
                    </tr>
                </table>
            </div>
            <div class="col-md-4">

                <asp:Button ID="ButtonSil" runat="server" Text="SİL" class="btn btn-danger" Width="200PX" OnClick="ButtonSil_Click" /><br />
                <br />
                <asp:Button ID="ButtonTemizle" runat="server" Text="TEMİZLE" class="btn btn-default" Width="200PX" OnClick="ButtonTemizle_Click" /><br />
                <br />
                <asp:Label ID="LabelDurum" runat="server" Text="" ForeColor="Red" Visible="false"></asp:Label>
            </div>
        </div>

        <hr />
        <hr />
    </div>

</asp:Content>
