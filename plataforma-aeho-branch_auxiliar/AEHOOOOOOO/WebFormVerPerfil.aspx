<%@ Page Title="" Language="C#" MasterPageFile="~/MasterAtleta.Master" AutoEventWireup="true" CodeBehind="WebFormVerPerfil.aspx.cs" Inherits="AEHOOOOOOO.WebFormVerPerfil" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <asp:Image ID="ImagePerfil" runat="server" /><br /><br />
    <asp:Label ID="LabelNome" runat="server" Text="Nome: "></asp:Label><br /><br />
    <asp:Label ID="LabelNascimento" runat="server" Text="Nascimento: "></asp:Label><br /><br />
    <asp:Label ID="LabelRg" runat="server" Text="Rg: "></asp:Label><br /><br />
    <asp:Label ID="LabelCPF" runat="server" Text="CPF: "></asp:Label><br /><br />
    <asp:Label ID="LabelGenero" runat="server" Text="Gênero: "></asp:Label><br /><br />
    <asp:Label ID="LabelEmail" runat="server" Text="E-mail: "></asp:Label><br /><br />
    <asp:Label ID="LabelUsuario" runat="server" Text="Nome de Usuário: "></asp:Label><br /><br />
    <asp:Label ID="LabelPrivilegio" runat="server" Text="Privilégio: "></asp:Label><br /><br />

    <asp:Label ID="LabelRua" runat="server" Text="Rua: "></asp:Label><br /><br />
    <asp:Label ID="LabelNumero" runat="server" Text="Número: "></asp:Label><br /><br />
    <asp:Label ID="LabelBairro" runat="server" Text="Bairro: "></asp:Label><br />
<asp:ObjectDataSource ID="ObjectDataSource1" runat="server" SelectMethod="buscar" TypeName="Sistema_Aeho.Registro"></asp:ObjectDataSource>
<br />
    <asp:Label ID="LabelUF" runat="server" Text="UF: "></asp:Label><br /><br />
    <asp:Label ID="LabelCidade" runat="server" Text="Cidade: "></asp:Label><br /><br />
    <asp:Label ID="LabelCEP" runat="server" Text="CEP: "></asp:Label><br /><br />
    <asp:Label ID="LabelComplemento" runat="server" Text="Complemento: "></asp:Label><br /><br />

    
</asp:Content>
