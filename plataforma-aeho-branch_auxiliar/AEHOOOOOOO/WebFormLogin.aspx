<%@ Page Title="" Language="C#" MasterPageFile="~/MasterAno.Master" AutoEventWireup="true" CodeBehind="WebFormLogin.aspx.cs" Inherits="AEHOOOOOOO.WebFormLogin" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">

    <div class="ls-label">
    <asp:Label ID="Label1" runat="server" CssClass="ls-label-text">Login:</asp:Label>
        <asp:TextBox ID="TextBoxUsuario" runat="server" CssClass="ls-login-bg-user ls-field-lg"></asp:TextBox>
        </div>
    <div class="ls-label">
    <asp:Label ID="Label2" runat="server" CssClass="ls-label-text">Senha:</asp:Label>
        <asp:TextBox ID="TextBoxSenha" runat="server" CssClass="ls-login-bg-password ls-field-lg" TextMode="Password"></asp:TextBox>
        </div>
    <asp:Button ID="Button1" runat="server" Text="Entrar" CssClass="ls-btn-primary ls-btn-block ls-btn-lg" OnClick="Button1_Click"/>
<asp:SqlDataSource ID="SqlDataSource1" runat="server" ConnectionString='<%$ ConnectionStrings:dbplataformaAEHOConnectionString %>' SelectCommand="SELECT * FROM [Registro]"></asp:SqlDataSource>
</asp:Content>
