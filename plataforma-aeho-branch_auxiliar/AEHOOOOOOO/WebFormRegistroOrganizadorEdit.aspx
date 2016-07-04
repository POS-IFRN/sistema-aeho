<%@ Page Title="" Language="C#" MasterPageFile="~/SiteMaster.Master" AutoEventWireup="true" CodeBehind="WebFormRegistroOrganizadorEdit.aspx.cs" Inherits="AEHOOOOOOO.WebFormRegistroOrganizadorEdit" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <asp:DetailsView ID="DetailsView1" runat="server" Height="50px" Width="500px" AutoGenerateRows="False" BackColor="White" BorderColor="White" BorderStyle="Ridge" BorderWidth="2px" CellPadding="3" CellSpacing="1" DataKeyNames="id" DataSourceID="SqlDataSource1">
        <EditRowStyle BackColor="#9471DE" Font-Bold="True" ForeColor="White" />
        <Fields>
            <asp:BoundField DataField="nome" HeaderText="nome" SortExpression="nome" />
            <asp:BoundField DataField="nascimento" HeaderText="nascimento" SortExpression="nascimento" />
            <asp:BoundField DataField="rg" HeaderText="rg" SortExpression="rg" />
            <asp:BoundField DataField="cpf" HeaderText="cpf" SortExpression="cpf" />
            <asp:BoundField DataField="CNPJ" HeaderText="CNPJ" SortExpression="CNPJ" />
            <asp:BoundField DataField="id" HeaderText="id" InsertVisible="False" ReadOnly="True" SortExpression="id" />
            <asp:BoundField DataField="genero" HeaderText="genero" SortExpression="genero" />
            <asp:BoundField DataField="email" HeaderText="email" SortExpression="email" />
            <asp:BoundField DataField="usuario" HeaderText="usuario" SortExpression="usuario" />
            <asp:BoundField DataField="senha" HeaderText="senha" SortExpression="senha" />
            <asp:BoundField DataField="rua" HeaderText="rua" SortExpression="rua" />
            <asp:BoundField DataField="numero" HeaderText="numero" SortExpression="numero" />
            <asp:BoundField DataField="bairro" HeaderText="bairro" SortExpression="bairro" />
            <asp:BoundField DataField="uf" HeaderText="uf" SortExpression="uf" />
            <asp:BoundField DataField="cidade" HeaderText="cidade" SortExpression="cidade" />
            <asp:BoundField DataField="cep" HeaderText="cep" SortExpression="cep" />
            <asp:BoundField DataField="complemento" HeaderText="complemento" SortExpression="complemento" />
            <asp:BoundField DataField="privilegio" HeaderText="privilegio" SortExpression="privilegio" />
            <asp:CommandField ShowEditButton="True" ShowDeleteButton="True" />
        </Fields>
    </asp:DetailsView>
    <asp:SqlDataSource ID="SqlDataSource1" runat="server" ConnectionString="<%$ ConnectionStrings:ConnectionString %>" DeleteCommand="DELETE FROM Registro WHERE id = @id" SelectCommand="SELECT * FROM Registro WHERE id = @registro_id" UpdateCommand="UPDATE Registro SET nome = @nome, nascimento = @nascimento, rg = @rg, cpf = @cpf, CNPJ = @CNPJ, genero = @genero, email = @email, usuario = @usuario, senha = @senha, rua = @rua, numero = @numero, bairro = @bairro, uf = @uf, cidade = @cidade, cep = @cep, complemento = @complemento, privilegio = @privilegio">
        <DeleteParameters>
            <asp:Parameter Name="id" />
        </DeleteParameters>
        <SelectParameters>
            <asp:SessionParameter Name="registro_id" SessionField="registro_id" />
        </SelectParameters>
        <UpdateParameters>
            <asp:Parameter Name="nome" />
            <asp:Parameter Name="nascimento" />
            <asp:Parameter Name="rg" />
            <asp:Parameter Name="cpf" />
            <asp:Parameter Name="CNPJ" />
            <asp:Parameter Name="genero" />
            <asp:Parameter Name="email" />
            <asp:Parameter Name="usuario" />
            <asp:Parameter Name="senha" />
            <asp:Parameter Name="rua" />
            <asp:Parameter Name="numero" />
            <asp:Parameter Name="bairro" />
            <asp:Parameter Name="uf" />
            <asp:Parameter Name="cidade" />
            <asp:Parameter Name="cep" />
            <asp:Parameter Name="complemento" />
            <asp:Parameter Name="privilegio" />
        </UpdateParameters>
    </asp:SqlDataSource>
</asp:Content>
