<%@ Page Title="" Language="C#" MasterPageFile="~/MasterAtleta.Master" AutoEventWireup="true" CodeBehind="WebFormSuasMensagens.aspx.cs" Inherits="AEHOOOOOOO.WebFormSuasMensagens" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <asp:Table ID="Table1" runat="server"></asp:Table>
    <asp:Button ID="Button1" runat="server" Text="Enviar nova mensagem" OnClick="Button1_Click" CssClass="ls-btn" />
</asp:Content>
