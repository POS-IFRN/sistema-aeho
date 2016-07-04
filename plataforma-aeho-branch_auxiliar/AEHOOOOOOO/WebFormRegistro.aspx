<%@ Page Title="" Language="C#" MasterPageFile="~/MasterAno.Master" AutoEventWireup="true" CodeBehind="WebFormRegistro.aspx.cs" Inherits="AEHOOOOOOO.WebFormRegistro" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <div>
        <table style="width: 100%;">

            <tr>
                <td>
                    <div class="ls-label col-md-3">
                     Nome:
                     <asp:TextBox ID="TextBoxNome" runat="server" Placeholder="Nome e sobrenome" Width="400"></asp:TextBox>
                    </div>
                </td>
                <td><asp:RequiredFieldValidator ID="RequiredFieldValidator1" runat="server" ErrorMessage="Esse campo não pode ficar em branco" Font-Bold="True" Enabled="True" ControlToValidate="TextBoxNome" SetFocusOnError="True" ForeColor="Red"></asp:RequiredFieldValidator></td>
            </tr>
            <tr>
                <td>
                    <div class="ls-label col-md-3">
                        Data de nascimento
                        <asp:TextBox ID="TextBoxNascimento" runat="server" Width="400" ></asp:TextBox>
                    </div>
                </td>
                <td><asp:RequiredFieldValidator ID="RequiredFieldValidator2" runat="server" ErrorMessage="Esse campo não pode ficar em branco" Font-Bold="True" Enabled="True" ControlToValidate="TextBoxNascimento" SetFocusOnError="True" ForeColor="Red"></asp:RequiredFieldValidator>
                     <asp:RegularExpressionValidator ID="RegularExpressionValidator6" runat="server" ErrorMessage="Data no formato incorreto! Favor utilizar o formato dd/mm/aaaa" ValidationExpression="\d{2}:\d{2}" ControlToValidate="TextBoxNascimento" Font-Bold="True" ForeColor="Red">Data de nascimento no formato incorreto! Favor utilizar o formato dd/mm/aaaa!</asp:RegularExpressionValidator>
                </td>
            </tr>

            <tr>
                <td>
                    <div class="ls-label col-md-3">
                        RG
                        <asp:TextBox ID="TextBoxRG" runat="server" Placeholder="XXX.XXX.XXX"  Width="400"></asp:TextBox>
                    </div>
                </td>
                <td> <asp:RequiredFieldValidator ID="RequiredFieldValidator3" runat="server" ErrorMessage="Esse campo não pode ficar em branco" Font-Bold="True" Enabled="True" ControlToValidate="TextBoxRG" SetFocusOnError="True" ForeColor="Red"></asp:RequiredFieldValidator> </td>
            </tr>

            <tr>
                <td>
                    <div class="ls-label col-md-3">
                        CPF
                        <asp:TextBox ID="TextBoxCPF" runat="server" Placeholder="XXX.XXX.XXX-XX"  Width="400"></asp:TextBox>
                    </div>
                </td>
                <td><asp:RequiredFieldValidator ID="RequiredFieldValidator4" runat="server" ErrorMessage="Esse campo não pode ficar em branco" Font-Bold="True" Enabled="True" ControlToValidate="TextBoxCPF" SetFocusOnError="True" ForeColor="Red"></asp:RequiredFieldValidator></td>
            </tr>

            <tr>
                <td>
                    <div class="ls-label col-md-3">
                        Gênero<br />
                        <br />
                        <asp:DropDownList ID="DropDownListGenero" runat="server" EnableTheming="True" Width="400">
                            <asp:ListItem Value="Masculino">Masculino</asp:ListItem>
                             <asp:ListItem Value="Feminino">Feminino</asp:ListItem>
                        </asp:DropDownList>
                    </div>
                </td>
                <td>&nbsp; </td>
            </tr>

            <tr>
                <td>
                    <div class="ls-label col-md-3">
                        CEP
                        <asp:TextBox ID="TextBoxCEP" runat="server" Placeholder="XXXXX-XXX" AutoPostBack="False" Width="400"></asp:TextBox>
                    </div>
                </td>
                <td> <asp:RequiredFieldValidator ID="RequiredFieldValidator14" runat="server" ErrorMessage="Esse campo não pode ficar em branco" Font-Bold="True" Enabled="True" ControlToValidate="TextBoxCEP" SetFocusOnError="True" ForeColor="Red"></asp:RequiredFieldValidator> 
                    <br />
                    <asp:RegularExpressionValidator ID="RegularExpressionValidator1" runat="server" ErrorMessage="RegularExpressionValidator" ControlToValidate="TextBoxCEP" ValidationExpression="\d{5}-\d{3}" Font-Bold="True" ForeColor="Red">CEP no formato incorreto! Formato correto: XXXXX-XXX</asp:RegularExpressionValidator></td>
            </tr>

            <tr>
                <td>
                    <div class="ls-label col-md-3">
                        Rua
                        <asp:TextBox ID="TextBoxRua" runat="server" Placeholder="Rua dos bobos" Width="400"></asp:TextBox>
                    </div>
                </td>
                <td><asp:RequiredFieldValidator ID="RequiredFieldValidator5" runat="server" ErrorMessage="Esse campo não pode ficar em branco" Font-Bold="True" Enabled="True" ControlToValidate="TextBoxRua" SetFocusOnError="True" ForeColor="Red"></asp:RequiredFieldValidator></td>
            </tr>

            <tr>
                <td>
                    <div class="ls-label col-md-3">
                         Número
                         <asp:TextBox ID="TextBoxNumero" runat="server" Placeholder="0" Width="400"></asp:TextBox>
                    </div>
                </td>
                <td><asp:RequiredFieldValidator ID="RequiredFieldValidator6" runat="server" ErrorMessage="Esse campo não pode ficar em branco" Font-Bold="True" Enabled="True" ControlToValidate="TextBoxNumero" SetFocusOnError="True" ForeColor="Red"></asp:RequiredFieldValidator></td>
            </tr>

            <tr>
                <td>
                    <div class="ls-label col-md-3">
                        Complemento
                        <asp:TextBox ID="TextBoxComplemento" runat="server" Placeholder="Perto da mercearia" Width="400"></asp:TextBox>
                    </div>
                </td>
                <td>&nbsp; </td>
            </tr>

            <tr>
                <td>
                    <div class="ls-label col-md-3">
                        Bairro
                        <asp:TextBox ID="TextBoxBairro" runat="server" Placeholder="Tirol" Width="400"></asp:TextBox>
                    </div>    
                </td>
                <td><asp:RequiredFieldValidator ID="RequiredFieldValidator7" runat="server" ErrorMessage="Esse campo não pode ficar em branco" Font-Bold="True" Enabled="True" ControlToValidate="TextBoxBairro" SetFocusOnError="True" ForeColor="Red"></asp:RequiredFieldValidator></td>
            </tr>

            <tr>
                <td>
                     <div class="ls-label col-md-3">
                         Cidade
                         <asp:TextBox ID="TextBoxCidade" runat="server" Placeholder="Quebec" Width="400"></asp:TextBox>
                    </div>  
                </td>
                <td><asp:RequiredFieldValidator ID="RequiredFieldValidator8" runat="server" ErrorMessage="Esse campo não pode ficar em branco" Font-Bold="True" Enabled="True" ControlToValidate="TextBoxCidade" SetFocusOnError="True" ForeColor="Red"></asp:RequiredFieldValidator></td>
            </tr>

            <tr>
                <td>
                     <div class="ls-label col-md-3">
                           UF
                           <asp:TextBox ID="TextBoxUF" runat="server" Placeholder="RJ" Width="400"></asp:TextBox>
                    </div>
                </td>
                <td><asp:RequiredFieldValidator ID="RequiredFieldValidator9" runat="server" ErrorMessage="Esse campo não pode ficar em branco" Font-Bold="True" Enabled="True" ControlToValidate="TextBoxUF" SetFocusOnError="True" ForeColor="Red"></asp:RequiredFieldValidator></td>
            </tr>

            <tr>
                <td>
                    <div class="ls-label col-md-3">
                        Email
                        <asp:TextBox ID="TextBoxEmail" runat="server" Placeholder="user@user.com" Width="400"></asp:TextBox>
                    </div>
                </td>
                <td><asp:RequiredFieldValidator ID="RequiredFieldValidator10" runat="server" ErrorMessage="Esse campo não pode ficar em branco" Font-Bold="True" Enabled="True" ControlToValidate="TextBoxEmail" SetFocusOnError="True" ForeColor="Red"></asp:RequiredFieldValidator></td>
            </tr>

            <tr>
                <td>
                    <div class="ls-label col-md-3">
                        Foto de Perfil
                        <asp:FileUpload ID="FileUpload1" runat="server" Width="400" />
                    </div>
                </td>
                <td><asp:RequiredFieldValidator ID="RequiredFieldValidator11" runat="server" ErrorMessage="Esse campo não pode ficar em branco" Font-Bold="True" Enabled="True" ControlToValidate="FileUpload1" SetFocusOnError="True" ForeColor="Red"></asp:RequiredFieldValidator></td>
            </tr>

            <tr>
                <td>
                    <div class="ls-label col-md-3">
                         Login
                        <asp:TextBox ID="TextBoxLogin" runat="server" Placeholder="username" Width="400"></asp:TextBox>
                    </div>
                </td>
                <td><asp:RequiredFieldValidator ID="RequiredFieldValidator12" runat="server" ErrorMessage="Esse campo não pode ficar em branco" Font-Bold="True" Enabled="True" ControlToValidate="TextBoxLogin" SetFocusOnError="True" ForeColor="Red"></asp:RequiredFieldValidator></td>
            </tr>

            <tr>
                <td>
                    <div class="ls-label col-md-3">
                        Senha
                        <asp:TextBox ID="TextBoxSenha" runat="server" Placeholder="password" TextMode="Password" Width="400"></asp:TextBox>
                    </div>
                </td>
                <td><asp:RequiredFieldValidator ID="RequiredFieldValidator13" runat="server" ErrorMessage="Esse campo não pode ficar em branco" Font-Bold="True" Enabled="True" ControlToValidate="TextBoxSenha" SetFocusOnError="True" ForeColor="Red"></asp:RequiredFieldValidator></td>
            </tr>

        </table>

        <hr />
        <div class="ls-actions-btn">
            <asp:Button class="ls-btn" ID="Button1" runat="server" Text="Salvar" OnClick="Button1_Click" />
            
        </div>
    </div>
    <script type="text/javascript" src="http://code.jquery.com/jquery-2.0.3.min.js"></script>
    <script src="http://assets.locaweb.com.br/locastyle/3.7.4/javascripts/locastyle.js" type="text/javascript"></script>
    <asp:SqlDataSource ID="SqlDataSource1" runat="server"></asp:SqlDataSource>
</asp:Content>
