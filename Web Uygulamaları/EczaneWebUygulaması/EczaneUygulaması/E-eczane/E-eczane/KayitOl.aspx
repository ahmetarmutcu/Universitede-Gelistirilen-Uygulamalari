<%@ Page Title="" Language="C#" MasterPageFile="~/Tema.Master" AutoEventWireup="true" CodeBehind="KayitOl.aspx.cs" Inherits="E_eczane.KayitOl" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
        <div class="contact_form">
		<div class="container">
			<div class="row">
				<div class="col-lg-10 offset-lg-1">
					<div class="contact_form_container">
						<div class="contact_form_title">ÜYE OL</div>
                         <form id="contact_form" runat="server">
						        <fieldset>
                                    <div class="form-group" >
                                 <asp:TextBox class="form-control col-md-6" ID="TextKullaniciAdi" runat="server" placeholder="Kullanıcı Adını giriniz" autocomplete="off" autofocus=""></asp:TextBox>
							</div>
							<div class="form-group">
                                 <asp:TextBox class="form-control col-md-6" ID="TextSifre" runat="server" placeholder="Şifrenizi giriniz" autocomplete="off" type="password" value="" ></asp:TextBox>
							</div>
                            <asp:Button ID="ButtonUyeOl"  runat="server" Text="ÜYE OL" class="btn btn-primary" OnClick="ButtonUyeOl_Click" /></fieldset><br />
                             <asp:Label ID="LabelDurum" runat="server" Text="" ForeColor="Red" Visible="false" Font-Bold="true" Font-Size="Medium"></asp:Label>
						</form>

					</div>
				</div>
			</div>
            <div>

            </div>
		</div>
	</div>
</asp:Content>
