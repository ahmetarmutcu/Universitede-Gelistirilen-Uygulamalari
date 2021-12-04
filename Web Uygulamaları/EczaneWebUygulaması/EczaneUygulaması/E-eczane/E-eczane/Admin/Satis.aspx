<%@ Page Title="" Language="C#" MasterPageFile="~/Admin/AdminTema.Master" AutoEventWireup="true" CodeBehind="Satis.aspx.cs" Inherits="E_eczane.Admin.Satis" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <div class="col-md-12" style="margin-top: 5%">
        <div class="col-md-8">
            <table>

                <tr>
                    <td class="control-label col-md-2">İLAÇ  ADET</td>
                    <td>
                        <div class="form-group col-md-8">
                            <asp:TextBox class="form-control" ID="TextAdet" runat="server" autocomplete="off" autofocus=""></asp:TextBox>
                        </div>

                    </td>
                </tr>
                <tr>
                    <td class="control-label col-md-2">İLAÇ ADI</td>
                    <td>
                        <div class="form-group col-md-8">
                            <asp:DropDownList ID="DropIlacAdi" runat="server" CssClass="col-md-8 form-control"></asp:DropDownList>
                        </div>

                    </td>
                </tr>
                <tr>
                    <td class="control-label col-md-2">MÜŞTERİ</td>
                    <td>
                        <div class="form-group col-md-8">
                            <asp:DropDownList ID="DropMusteri" runat="server" CssClass="col-md-8 form-control"></asp:DropDownList>
                        </div>
                    </td>
                </tr>

            </table>
        </div>
        <div class="col-md-4">

            <asp:Button ID="ButtonSatisEkle" runat="server" Text="SAT" class="btn btn-primary" Width="200PX" OnClick="ButtonSatisEkle_Click" /><br />
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
