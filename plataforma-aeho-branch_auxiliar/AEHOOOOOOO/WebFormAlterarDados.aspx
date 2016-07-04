<%@ Page Title="" Language="C#" MasterPageFile="~/SiteMaster.Master" AutoEventWireup="true" CodeBehind="WebFormAlterarDados.aspx.cs" Inherits="AEHOOOOOOO.WebFormRegistrarOrganizador" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <div class="ls-form" id="conteudo">
        <div class="ls-label col-md-3">
            Nome
            <asp:TextBox ID="TextBoxNome" runat="server" ReadOnly="False"></asp:TextBox>
        </div>
        <div class="ls-label col-md-3">
            Data de nascimento
            <asp:TextBox ID="TextBoxNascimento" runat="server" Class="datepicker" ReadOnly="False"></asp:TextBox>
        </div>
        <div class="ls-label col-md-3">
            RG
            <asp:TextBox ID="TextBoxRG" runat="server" ReadOnly="False"></asp:TextBox>
        </div>
        <div class="ls-label col-md-3">
            CPF
            <asp:TextBox ID="TextBoxCPF" runat="server" ReadOnly="False"></asp:TextBox>
        </div>
        <div class="ls-label col-md-3">
            CEP
            <asp:TextBox ID="TextBoxCEP" runat="server" ReadOnly="False"></asp:TextBox>
        </div>
        <div class="ls-label col-md-3">
            Rua
            <asp:TextBox ID="TextBoxRua" runat="server" ReadOnly="False"></asp:TextBox>
        </div>
        <div class="ls-label col-md-3">
            Número
            <asp:TextBox ID="TextBoxNumero" runat="server" ReadOnly="False"></asp:TextBox>
        </div>
        <div class="ls-label col-md-3">
            Bairro
            <asp:TextBox ID="TextBoxBairro" runat="server" ReadOnly="False"></asp:TextBox>
        </div>
        <div class="ls-label col-md-3">
            Cidade
            <asp:TextBox ID="TextBoxCidade" runat="server" ReadOnly="False"></asp:TextBox>
        </div>
        <div class="ls-label col-md-3">
            Complemento
            <asp:TextBox ID="TextBoxComplemento" runat="server" ReadOnly="False"></asp:TextBox>
        </div>
        <div class="ls-label col-md-3">
            UF
            <asp:TextBox ID="TextBoxUF" runat="server"  ReadOnly="False"></asp:TextBox>
        </div>
        <div class="ls-label col-md-3">
            Email
            <asp:TextBox ID="TextBoxEmail" runat="server"  ReadOnly="False"></asp:TextBox>
        </div>
        <!--<div class="ls-label col-md-3">
            Foto de Perfil
            <asp:FileUpload ID="FileUpload1" runat="server" />
        </div>-->
                              
        <hr />
    
       
        <div class="ls-actions-btn" id="botoesPagina">
            <asp:Button class="ls-btn" ID="Button1" runat="server" Text="Alterar dados" OnClick="Button1_Click" PostBackUrl="~/WebFormAlterarDados.aspx" />
            
            
            
        </div>
    </div>
</asp:Content>
