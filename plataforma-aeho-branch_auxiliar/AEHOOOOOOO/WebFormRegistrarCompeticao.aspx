<%@ Page Title="" Language="C#" MasterPageFile="~/MasterOrganizador.Master" AutoEventWireup="true" CodeBehind="WebFormRegistrarCompeticao.aspx.cs" Inherits="AEHOOOOOOO.ReghistrarCOmpete" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
            <div>
            <br />
            <br />
            <table style="width: 100%;">
                <tr>
                    <td>
                        <div class="ls-label col-md-3">
                            Nome da Competição
                            <asp:TextBox ID="TextBoxNome" runat="server" Placeholder="Nome da Competição" Width="400"></asp:TextBox>
                        </div>
                    </td>
                    <td><asp:RequiredFieldValidator ID="RequiredFieldValidator1" runat="server" ErrorMessage="Esse campo não pode ficar em branco" ControlToValidate="TextBoxNome" SetFocusOnError="True" Display="Static" Font-Bold="True" ForeColor="Red"></asp:RequiredFieldValidator></td>
                </tr>

                <tr>
                    <td>
                        <div class="ls-label col-md-3">
                            Início das Inscrições
                            <asp:TextBox ID="TextBoxInicio" runat="server"  Width="400"></asp:TextBox>
                        </div>
                    </td>
                    <td><asp:RequiredFieldValidator ID="RequiredFieldValidator2" runat="server" ErrorMessage="Esse campo não pode ficar em branco" ControlToValidate="TextBoxInicio" SetFocusOnError="True" Display="Static" Font-Bold="True" ForeColor="Red"> </asp:RequiredFieldValidator>
                        <asp:RegularExpressionValidator ID="RegularExpressionValidator4" runat="server" ErrorMessage="Data no formato incorreto! Favor utilizar o formato dd/mm/aaaa" ValidationExpression="\d{2}/\d{2}/\d{4}" ControlToValidate="TextBoxInicio" Font-Bold="True" ForeColor="Red">Data no formato incorreto! Favor utilizar o formato dd/mm/aaaa!</asp:RegularExpressionValidator>
                    </td>
                </tr>

                <tr>
                    <td>
                        <div class="ls-label col-md-3">
                            Encerramento das Inscrições
                            <asp:TextBox ID="TextBoxEncerramento" runat="server"  Width="400"></asp:TextBox>
                        </div>
                    </td>
                    <td><asp:RequiredFieldValidator ID="RequiredFieldValidator3" runat="server" ErrorMessage="Esse campo não pode ficar em branco" ControlToValidate="TextBoxEncerramento" SetFocusOnError="True" Display="Static" Font-Bold="True" ForeColor="Red"> </asp:RequiredFieldValidator>
                         <asp:RegularExpressionValidator ID="RegularExpressionValidator5" runat="server" ErrorMessage="Data no formato incorreto! Favor utilizar o formato dd/mm/aaaa" ValidationExpression="\d{2}/\d{2}/\d{4}" ControlToValidate="TextBoxEncerramento" Font-Bold="True" ForeColor="Red">Data no formato incorreto! Favor utilizar o formato dd/mm/aaaa!</asp:RegularExpressionValidator>
                    </td>
                </tr>

                <tr>
                    <td>
                        <div class="ls-label col-md-3">
                            Data Competição
                            <asp:TextBox ID="TextBoxData" runat="server"  Width="400"></asp:TextBox>
                        </div>
                    </td>
                    <td><asp:RequiredFieldValidator ID="RequiredFieldValidator4" runat="server" ErrorMessage="Esse campo não pode ficar em branco" ControlToValidate="TextBoxData" SetFocusOnError="True" Display="Static" Font-Bold="True" ForeColor="Red"> </asp:RequiredFieldValidator>
                         <asp:RegularExpressionValidator ID="RegularExpressionValidator3" runat="server" ErrorMessage="Data no formato incorreto! Favor utilizar o formato dd/mm/aaaa" ValidationExpression="\d{2}/\d{2}/\d{4}" ControlToValidate="TextBoxData" Font-Bold="True" ForeColor="Red">Data no formato incorreto! Favor utilizar o formato dd/mm/aaaa!</asp:RegularExpressionValidator>
                    </td>
                </tr>

                <tr>
                    <td>
                        <div class="ls-label col-md-3">
                            Encerramento da Competição
                            <asp:TextBox ID="TextBoxEnCompet" runat="server"  Width="400"></asp:TextBox>
                        </div>
                    </td>
                    <td><asp:RequiredFieldValidator ID="RequiredFieldValidator5" runat="server" ErrorMessage="Esse campo não pode ficar em branco" ControlToValidate="TextBoxEnCompet" SetFocusOnError="True" Display="Static" Font-Bold="True" ForeColor="Red"> </asp:RequiredFieldValidator>
                        <asp:RegularExpressionValidator ID="RegularExpressionValidator2" runat="server" ErrorMessage="Data no formato incorreto! Favor utilizar o formato dd/mm/aaaa" ValidationExpression="\d{2}/\d{2}/\d{4}" ControlToValidate="TextBoxEnCompet" Font-Bold="True" ForeColor="Red">Data no formato incorreto! Favor utilizar o formato dd/mm/aaaa!</asp:RegularExpressionValidator>
                    </td>
                </tr>

                <tr>
                    <td><div class="ls-label col-md-3">
            Modalidade
            <asp:TextBox ID="TextBoxModal" runat="server" Placeholder="Modalidade da Competição" Width="400"></asp:TextBox>
        </div></td>
                    <td><asp:RequiredFieldValidator ID="RequiredFieldValidator6" runat="server" ErrorMessage="Esse campo não pode ficar em branco" ControlToValidate="TextBoxModal" SetFocusOnError="True" Display="Static" Font-Bold="True" ForeColor="Red"> </asp:RequiredFieldValidator></td>
                </tr>

                <tr>
                    <td><div class="ls-label col-md-3">
            Horário da Competicao
            <asp:TextBox ID="TextBoxHorario" runat="server" Placeholder="12:30" Width="400"></asp:TextBox>
        </div></td>
                    <td><asp:RequiredFieldValidator ID="RequiredFieldValidator7" runat="server" ErrorMessage="Esse campo não pode ficar em branco" ControlToValidate="TextBoxHorario" SetFocusOnError="True" Display="Static" Font-Bold="True" ForeColor="Red"> </asp:RequiredFieldValidator>
                        <asp:RegularExpressionValidator ID="RegularExpressionValidator6" runat="server" ErrorMessage="Data no formato incorreto! Favor utilizar o formato dd/mm/aaaa" ValidationExpression="\d{2}:\d{2}" ControlToValidate="TextBoxHorario" Font-Bold="True" ForeColor="Red">Horário no formato incorreto! Favor utilizar o formato hh:mm!</asp:RegularExpressionValidator>
                    </td>

                </tr>

                <tr>
                    <td>
                        <div class="ls-label col-md-3">
                            Gênero<br />
                            <br />
                            <asp:DropDownList ID="DropDownListGenero" runat="server" EnableTheming="True" Width="400">
                                <asp:ListItem Value="Masculino">Masculino</asp:ListItem>
                                <asp:ListItem Value="Feminino">Feminino</asp:ListItem>
                                <asp:ListItem Value="Unissex">Feminino e Masculino</asp:ListItem>
                            </asp:DropDownList>
                         </div>
                    </td>
                    <td>&nbsp;</td>
                </tr>

                <tr>
                    <td>
                        <div class="ls-label col-md-3">
                            <br />
                            Rua
                            <asp:TextBox ID="TextBoxRua" runat="server" Placeholder="Rua dos Bobos" Width="400"></asp:TextBox>
                        </div>
                    </td>
                    <td><asp:RequiredFieldValidator ID="RequiredFieldValidator8" runat="server" ErrorMessage="Esse campo não pode ficar em branco" ControlToValidate="TextBoxRua" SetFocusOnError="True" Display="Static" Font-Bold="True" ForeColor="Red"> </asp:RequiredFieldValidator></td>
                </tr>

                <tr>
                    <td><div class="ls-label col-md-3">
             <br />
            Numero
            <asp:TextBox ID="TextBoxNumero" runat="server" Placeholder="16" Width="400"></asp:TextBox>
        </div>  </td>
                    <td><asp:RequiredFieldValidator ID="RequiredFieldValidator9" runat="server" ErrorMessage="Esse campo não pode ficar em branco" ControlToValidate="TextBoxNumero" SetFocusOnError="True" Display="Static" Font-Bold="True" ForeColor="Red"> </asp:RequiredFieldValidator></td>
                </tr>

                <tr>
                    <td><div class="ls-label col-md-3">
             <br />
            Bairro
            <asp:TextBox ID="TextBoxBairro" runat="server" Placeholder="Tirol" Width="400"></asp:TextBox>
        </div></td>
                    <td><asp:RequiredFieldValidator ID="RequiredFieldValidator10" runat="server" ErrorMessage="Esse campo não pode ficar em branco" ControlToValidate="TextBoxBairro" SetFocusOnError="True" Display="Static" Font-Bold="True" ForeColor="Red"> </asp:RequiredFieldValidator></td>
                </tr>

                <tr>
                    <td><div class="ls-label col-md-3">
            CEP
            <asp:TextBox ID="TextBoxCep" runat="server" Placeholder="59065-210" AutoPostBack="False" Width="400"></asp:TextBox>
        </div></td>
                    <td><asp:RegularExpressionValidator ID="RegularExpressionValidator1" runat="server" ErrorMessage="RegularExpressionValidator" ControlToValidate="TextBoxCep" ValidationExpression="\d{5}-\d{3}" Font-Bold="True" ForeColor="Red">CEP no formato incorreto! Formato correto: XXXXX-XXX</asp:RegularExpressionValidator><asp:RequiredFieldValidator ID="RequiredFieldValidator11" runat="server" ErrorMessage="Esse campo não pode ficar em branco" ControlToValidate="TextBoxCep" SetFocusOnError="True" Display="Static" Font-Bold="True" ForeColor="Red"> </asp:RequiredFieldValidator></td>
                </tr>

                <tr>
                    <td><div class="ls-label col-md-3">
             <br />
            Ponto de Referência
            <asp:TextBox ID="TextBoxPontoReferencia" runat="server" Placeholder="Perto da casa de Daniel Souza" Width="400"></asp:TextBox>
        </div></td>
                    <td><asp:RequiredFieldValidator ID="RequiredFieldValidator12" runat="server" ErrorMessage="Esse campo não pode ficar em branco" ControlToValidate="TextBoxPontoReferencia" SetFocusOnError="True" Display="Static" Font-Bold="True" ForeColor="Red"> </asp:RequiredFieldValidator></td>
                </tr>

                <tr>
                    <td><div class="ls-label col-md-3">
            Cidade
            <asp:TextBox ID="TextBoxCidade" runat="server" Placeholder="Natal" Width="400"></asp:TextBox>
        </div></td>
                    <td><asp:RequiredFieldValidator ID="RequiredFieldValidator13" runat="server" ErrorMessage="Esse campo não pode ficar em branco" ControlToValidate="TextBoxCidade" SetFocusOnError="True" Display="Static" Font-Bold="True" ForeColor="Red"> </asp:RequiredFieldValidator></td>
                </tr>

                <tr>
                    <td><div class="ls-label col-md-3">
            UF
            <asp:TextBox ID="TextBoxUF" runat="server" Placeholder="RN" Width="400"></asp:TextBox>
        </div></td>
                    <td><asp:RequiredFieldValidator ID="RequiredFieldValidator14" runat="server" ErrorMessage="Esse campo não pode ficar em branco" ControlToValidate="TextBoxUF" SetFocusOnError="True" Display="Static" Font-Bold="True" ForeColor="Red"> </asp:RequiredFieldValidator></td>
                </tr>

                <tr>
                    <td><div class="ls-label col-md-3">
            Valor inscricão
            <asp:TextBox ID="TextBoxValor" runat="server" Placeholder="R$ 100,00" Width="400"></asp:TextBox>
        </div></td>
                    <td><asp:RequiredFieldValidator ID="RequiredFieldValidator15" runat="server" ErrorMessage="Esse campo não pode ficar em branco" ControlToValidate="TextBoxValor" SetFocusOnError="True" Display="Static" Font-Bold="True" ForeColor="Red"> </asp:RequiredFieldValidator></td>
                </tr>

                <tr>
                    <td><div class="ls-label col-md-3">
            Valor da Premiação
            <asp:TextBox ID="TextBoxPremiacao" runat="server" Placeholder="R$ 10000,00" Width="400"></asp:TextBox>
        </div></td>
                    <td><asp:RequiredFieldValidator ID="RequiredFieldValidator16" runat="server" ErrorMessage="Esse campo não pode ficar em branco" ControlToValidate="TextBoxPremiacao" SetFocusOnError="True" Display="Static" Font-Bold="True" ForeColor="Red"> </asp:RequiredFieldValidator></td>
                </tr>

                <tr>
                    <td><div class="ls-label col-md-3">
            Descricao
            <asp:TextBox ID="TextBoxDesc" runat="server" Placeholder="Informacoes adicionais sobre a competicao" Width="400"></asp:TextBox>
        </div></td>
                    <td><asp:RequiredFieldValidator ID="RequiredFieldValidator17" runat="server" ErrorMessage="Esse campo não pode ficar em branco" ControlToValidate="TextBoxDesc" SetFocusOnError="True" Display="Static" Font-Bold="True" ForeColor="Red"> </asp:RequiredFieldValidator></td>
                </tr>

                <tr>
                    <td><div class="ls-label col-md-3">
            Maximo Inscritos
            <asp:TextBox ID="TextBoxNumeroInscritos" runat="server" Placeholder="100" Width="400"></asp:TextBox>
        </div></td>
                    <td>  <asp:RequiredFieldValidator ID="RequiredFieldValidator18" runat="server" ErrorMessage="Esse campo não pode ficar em branco" ControlToValidate="TextBoxNumeroInscritos" SetFocusOnError="True" Display="Static" Font-Bold="True" ForeColor="Red"> </asp:RequiredFieldValidator></td>
                </tr>

                <tr>
                    <td><div class="ls-label col-md-3">
            Foto de Divulgacao
            <asp:FileUpload ID="FileUpload1" runat="server" Width="400" />
        </div></td>
                    <td><asp:RequiredFieldValidator ID="RequiredFieldValidator19" runat="server" ErrorMessage="Esse campo não pode ficar em branco" ControlToValidate="FileUpload1" SetFocusOnError="True" Display="Static" Font-Bold="True" ForeColor="Red"> </asp:RequiredFieldValidator></td>
                </tr>

            </table>

        <div class="ls-label col-md-3">
            <br /><br /><br />
            <asp:Button ID="Button1" runat="server" Text="Submeter para Avaliacao" OnClick="Button1_Click" />
        </div>
       
    </div>

    <script type="text/javascript" src="http://code.jquery.com/jquery-2.0.3.min.js"></script>
    <script src="http://assets.locaweb.com.br/locastyle/3.7.4/javascripts/locastyle.js" type="text/javascript"></script>
    <asp:SqlDataSource ID="SqlDataSource1" runat="server" ConnectionString="<%$ ConnectionStrings:RegistroComConnectionString %>" SelectCommand="SELECT * FROM [Competicao]"></asp:SqlDataSource>
</asp:Content>
