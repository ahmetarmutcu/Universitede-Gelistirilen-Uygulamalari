<%@ Page Title="" Language="C#" MasterPageFile="~/Tema.Master" AutoEventWireup="true" CodeBehind="Iletisim.aspx.cs" Inherits="E_eczane.Iletisim" %>
<asp:Content ID="Content1" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
<div class="contact_info">
		<div class="container">
			<div class="row">
				<div class="col-lg-10 offset-lg-1">
					<div class="contact_info_container d-flex flex-lg-row flex-column justify-content-between align-items-between">

						<!-- Contact Item -->
						<div class="contact_info_item d-flex flex-row align-items-center justify-content-start">
							<div class="contact_info_image"><img src="images/contact_1.png" alt=""></div>
							<div class="contact_info_content">
								<div class="contact_info_title">Telefon</div>
								<div class="contact_info_text">+38 068 005 3570</div>
							</div>
						</div>

						<!-- Contact Item -->
						<div class="contact_info_item d-flex flex-row align-items-center justify-content-start">
							<div class="contact_info_image"><img src="images/contact_2.png" alt=""></div>
							<div class="contact_info_content">
								<div class="contact_info_title">Email</div>
								<div class="contact_info_text">Eeczane@gmail.com</div>
							</div>
						</div>

						<!-- Contact Item -->
						<div class="contact_info_item d-flex flex-row align-items-center justify-content-start">
							<div class="contact_info_image"><img src="images/contact_3.png" alt=""></div>
							<div class="contact_info_content">
								<div class="contact_info_title">Adres </div>
								<div class="contact_info_text">SAKARYA/TÜRKİYE</div>
							</div>
						</div>

					</div>
				</div>
			</div>
		</div>
	</div>

	<!-- Contact Form -->

	<div class="contact_form">
		<div class="container">
			<div class="row">
				<div class="col-lg-10 offset-lg-1">
					<div class="contact_form_container">
						<div class="contact_form_title">SORU SOR ?</div>

						<form id="form3" runat="server">
						<fieldset>
							<div class="form-group">
                                 <asp:TextBox class="form-control" ID="TextSoru" runat="server" placeholder="Soru yazınız" autocomplete="off" autofocus=""></asp:TextBox>
							</div>
						
                            <asp:Button ID="ButtonGonder"  runat="server" Text="GÖNDER" class="btn btn-primary" OnClick="ButtonGonder_Click" /></fieldset><br />

                         <asp:Label ID="LabelDurum" runat="server" Text="" ForeColor="Red" Visible="false"></asp:Label>
					</form>

					</div>
				</div>
			</div>
		</div>
	</div>
    <hr />
</asp:Content>
