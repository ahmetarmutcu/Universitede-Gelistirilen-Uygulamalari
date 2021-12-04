<%@ Page Title="" Language="C#" MasterPageFile="~/Admin/AdminTema.Master" AutoEventWireup="true" CodeBehind="Ilaclar.aspx.cs" Inherits="E_eczane.Admin.Ilaclar" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <h1 style="text-align: center; color: red">İLAÇLAR</h1>
    <div class="col-md-12" style="margin-bottom: 5%">
        <asp:GridView ID="GridViewIlacListele" runat="server"
            AutoGenerateColumns="False" CellPadding="4" ForeColor="#333333"
            GridLines="None" Height="315px" Width="100%" AutoGenerateSelectButton="True" OnSelectedIndexChanged="GridViewIlacListele_SelectedIndexChanged">
            <AlternatingRowStyle BackColor="White" />
            <Columns>
                <asp:BoundField DataField="ilacID" HeaderText="İLAÇ ID" />
                <asp:BoundField DataField="ilacIsim" HeaderText="İLAÇ ADI" />
                <asp:BoundField DataField="ilacAciklama" HeaderText="İLAÇ AÇIKLAMA" />
                <asp:BoundField DataField="firmaIsim" HeaderText="İLAÇ FİRMA ADI" />
                <asp:BoundField DataField="kategoriIsim" HeaderText="İLAÇ KATEGORİ ADI" />
                <asp:BoundField DataField="ilacAdet" HeaderText="İLAÇ ADET" />
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
        <h1 style="text-align: center; color: red">İLAÇ  SİL</h1>
        <div class="col-md-12">
            <div class="col-md-8">
                <table>
                    <tr>
                        <td class="control-label col-md-2">İLAÇ ID</td>
                        <td>
                            <div class="form-group col-md-8">
                                <asp:TextBox class="form-control" ID="TextIlacID" runat="server" autocomplete="off" autofocus=""></asp:TextBox>
                            </div>
                        </td>
                    </tr>
                </table>
            </div>
            <div class="col-md-4">
                <br />
                <asp:Button ID="ButtonDetaySil" runat="server" Text="SİL" class="btn btn-danger" Width="200PX" OnClick="ButtonDetaySil_Click" /><br />
                <br />
                <br />
                <br />
               
            </div>
        </div>
        <hr />
        <hr />
    </div>
     <div style="margin-top: 10%">
        <h1 style="text-align: center; color: red">İLAÇ KAYDET</h1>
         <div class="col-md-12">
             <asp:GridView ID="GridIlacListele" runat="server"
            AutoGenerateColumns="False" CellPadding="4" ForeColor="#333333"
            GridLines="None" Height="315px" Width="100%" AutoGenerateSelectButton="True"  >
            <AlternatingRowStyle BackColor="White" />
            <Columns>
                <asp:BoundField DataField="ilacID" HeaderText="İLAÇ ID" />
                <asp:BoundField DataField="firmaIsim" HeaderText="İLAÇ ADI" />
                <asp:BoundField DataField="kategoriIsim" HeaderText="İLAÇ KATEGORİ ADI" />
                <asp:BoundField DataField="ilacResim" HeaderText="İLAÇ RESİM ADI" />
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
        <div class="col-md-12" style="margin-top:5%">
            <div class="col-md-8">
                <table>
                     <tr>
                        <td class="control-label col-md-2">İLAÇ  ADI</td>
                        <td>
                            <div class="form-group col-md-8">
                                <asp:TextBox class="form-control" ID="TextBoxilacAdi" runat="server" autocomplete="off" autofocus=""></asp:TextBox>
                            </div>

                        </td>
                    </tr>
                    <tr>
                        <td class="control-label col-md-2">İLAÇ  AÇIKLAMA</td>
                        <td>
                            <div class="form-group col-md-8">
                                <asp:TextBox class="form-control" ID="TextBoxilacAciklama" runat="server" autocomplete="off" autofocus=""></asp:TextBox>
                            </div>

                        </td>
                    </tr>
                      <tr>
                        <td class="control-label col-md-2">İLAÇ  ADET</td>
                        <td>
                            <div class="form-group col-md-8">
                                <asp:TextBox class="form-control" ID="TextBoxIlacAdet" runat="server" autocomplete="off" autofocus=""></asp:TextBox>
                            </div>

                        </td>
                    </tr>
                    <tr>
                        <td class="control-label col-md-2">İLAÇ FİRMA ADI</td>
                        <td>
                            <div class="form-group col-md-8">
                                <asp:DropDownList ID="DropDownIlacFirma" runat="server" CssClass="col-md-8 form-control"></asp:DropDownList>
                            </div>

                        </td>
                    </tr>
                    <tr>
                        <td class="control-label col-md-2">İLAÇ KATEGORİSİ</td>
                        <td>
                            <div class="form-group col-md-8">
                                <asp:DropDownList ID="DropDownIlacKategori" runat="server" CssClass="col-md-8 form-control"></asp:DropDownList>
                            </div>
                        </td>
                    </tr>
                    <tr>
                        <td class="control-label col-md-2">İLAÇ RESMİ</td>
                        <td>
                            <div class="form-group col-md-8">
                                <asp:FileUpload ID="FileResim" CssClass="col-md-8 form-control" runat="server" />
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
              
                <asp:Button ID="ButtonEKLE" runat="server" Text="EKLE" class="btn btn-primary" Width="200PX" OnClick="ButtonEKLE_Click" /><br />
                <br />
                <br />
                <br />
                <asp:Label ID="LabelDurum" runat="server" Text="" ForeColor="Red" Visible="false"></asp:Label>
            </div>
        </div>
        <hr />
        <hr />
    </div>
    
</asp:Content>


