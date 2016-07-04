<%@ Page Title=" Alterar Senha "  MasterPageFile="~/SiteMaster.Master" Language="C#"  AutoEventWireup="true" CodeBehind="WebFormAlterarSenha.aspx.cs" Inherits="AEHOOOOOOO.WebFormAlterarSenha" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    
    
    <div>
      &nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp; <asp:Label ID="Label1" runat="server" Text="Alteração de Senha"></asp:Label>
        <br /> <br /> 
        <asp:Label ID="Label2" runat="server" Text="Senha antiga: "></asp:Label>
        &nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;<asp:TextBox ID="TextBoxSenhaAntiga" runat="server" TextMode="Password"></asp:TextBox>
        <br />
       <asp:Label ID="Label3" runat="server" Text="Nova Senha: "></asp:Label>
    &nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;<asp:TextBox ID="TextBoxSenhaNova" runat="server" TextMode="Password"></asp:TextBox>
        <br />
        <asp:Label ID="Label4" runat="server" Text="Confirmar Senha:            "></asp:Label>
       <asp:TextBox ID="TextBoxConfirmarNovaSenha" runat="server" TextMode="Password"></asp:TextBox>
        <br /> <br />
        <asp:Button class="ls-btn" ID="Button1" runat="server" Text="Alterar Senha" PostBackUrl="~/WebFormAlterarSenha.aspx" OnClick="Button1_Click" />&nbsp;
        <asp:Button class="ls-btn" ID="Button2" runat="server" Text="Apagar" PostBackUrl="~/WebFormAlterarSenha.aspx" OnClick="Button2_Click" />
    </div>
    
  </asp:Content>