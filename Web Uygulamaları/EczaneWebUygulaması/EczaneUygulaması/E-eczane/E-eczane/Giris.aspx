<%@ Page Title="" Language="C#" MasterPageFile="~/Tema.Master" AutoEventWireup="true" CodeBehind="Giris.aspx.cs" Inherits="E_eczane.Giris" %>
<asp:Content ID="Content1" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <div class="container">
    <div class="row" style="margin-bottom:15%">
		<div class="col-xs-10 col-xs-offset-1 col-sm-8 col-sm-offset-2 col-md-4 col-md-offset-4">
			<div class="login-panel panel panel-default">
				<div class="panel-heading" style="color:red;font-size:15pt"><b>E-ECZANE'YE GİRİŞ</b></div>
				<div class="panel-body">
					 <form id="form1" runat="server">
						<fieldset>
							<div class="form-group">
                                 <asp:TextBox class="form-control" ID="TextKullanici" runat="server" placeholder="Kullanıc adınızı giriniz" autocomplete="off" autofocus=""></asp:TextBox>
							</div>
							<div class="form-group">
                                 <asp:TextBox class="form-control" ID="TextboxSifre" runat="server" placeholder="Şifre giriniz" autocomplete="off" type="password" value="" ></asp:TextBox>
							</div>
                            <asp:Button ID="ButtonGiris"  runat="server" Text="GİRİŞ" class="btn btn-primary" OnClick="ButtonGiris_Click" /></fieldset><br />

                         <asp:Label ID="LabelDurum" runat="server" Text="" ForeColor="Red" Visible="false"></asp:Label>
					</form>
				</div>
			</div>
		</div><!-- /.col-->
	</div><!-- /.row -->	
    </div>

</asp:Content>
