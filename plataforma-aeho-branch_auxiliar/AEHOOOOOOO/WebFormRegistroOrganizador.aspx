<%@ Page Title="" Language="C#" MasterPageFile="~/SiteMaster.Master" AutoEventWireup="true" CodeBehind="WebFormRegistroOrganizador.aspx.cs" Inherits="AEHOOOOOOO.WebFormRegistroOrganizador" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <asp:GridView ID="GridView1" runat="server" AllowPaging="True" AutoGenerateColumns="False" DataKeyNames="id" DataSourceID="SqlDataSource1" OnRowCommand="GridView1_RowCommand" CellPadding="5" CellSpacing="5" Font-Names="Verdana" ForeColor="#333333" GridLines="None">
        <AlternatingRowStyle BackColor="White" />
        <Columns>
            <asp:BoundField DataField="id" HeaderText="id" InsertVisible="False" ReadOnly="True" SortExpression="id" />
            <asp:BoundField DataField="nome" HeaderText="nome" SortExpression="nome" />
            <asp:BoundField DataField="nascimento" HeaderText="nascimento" SortExpression="nascimento" />
            <asp:BoundField DataField="rg" HeaderText="rg" SortExpression="rg" />
            <asp:BoundField DataField="cpf" HeaderText="cpf" SortExpression="cpf" />
            <asp:BoundField DataField="CNPJ" HeaderText="CNPJ" SortExpression="CNPJ" />
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
            <asp:ButtonField CommandName="EditarRegistro" Text="Editar" />
        </Columns>
        <EditRowStyle BackColor="#7C6F57" />
        <FooterStyle BackColor="#1C5E55" Font-Bold="True" ForeColor="White" />
        <HeaderStyle BackColor="#1C5E55" Font-Bold="True" ForeColor="White" />
        <PagerStyle BackColor="#666666" ForeColor="White" HorizontalAlign="Center" />
        <RowStyle BackColor="#E3EAEB" />
        <SelectedRowStyle BackColor="#C5BBAF" Font-Bold="True" ForeColor="#333333" />
        <SortedAscendingCellStyle BackColor="#F8FAFA" />
        <SortedAscendingHeaderStyle BackColor="#246B61" />
        <SortedDescendingCellStyle BackColor="#D4DFE1" />
        <SortedDescendingHeaderStyle BackColor="#15524A" />
    </asp:GridView>
    <asp:SqlDataSource ID="SqlDataSource1" runat="server" ConnectionString="<%$ ConnectionStrings:ConnectionString %>" SelectCommand="SELECT * FROM [Registro]"></asp:SqlDataSource>
</asp:Content>
