<%@ Page Title="" Language="C#" MasterPageFile="~/SiteMaster.Master" AutoEventWireup="true" CodeBehind="WebFormRegistroDataView.aspx.cs" Inherits="AEHOOOOOOO.WebFormRegistroDataView" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <asp:GridView ID="GridView1" runat="server" AllowPaging="True" AutoGenerateColumns="False" ShowDeleteButton="true" BorderColor="#006600" CellPadding="5" CellSpacing="5" DataKeyNames="id" DataSourceID="SqlDataSource1" Font-Names="verdana" Font-Size="Small" ForeColor="#333333" GridLines="None" Font-Strikeout="False" Height="50px" OnRowCommand="GridView1_RowCommand">
        <AlternatingRowStyle BackColor="White" />
        <Columns>
            <asp:BoundField DataField="id" HeaderText="id" InsertVisible="False" ReadOnly="True" SortExpression="id" />
            <asp:BoundField DataField="nome" HeaderText="Nome" SortExpression="nome" />
            <asp:BoundField DataField="inicioInscricao" HeaderText="Data Inicio Inscricao" SortExpression="inicioInscricao" DataFormatString="{0:d}" />
            <asp:BoundField DataField="encerramentoInscricao" HeaderText="Data Encerramento Inscricao" SortExpression="encerramentoInscricao" DataFormatString="{0:d}" />
            <asp:BoundField DataField="dataEvento" HeaderText="Data Competicao" SortExpression="dataEvento" DataFormatString="{0:d}" />
            <asp:BoundField DataField="dataFimEvento" HeaderText="Data Fim da Competicao" SortExpression="dataFimEvento" DataFormatString="{0:d}" />
            <asp:BoundField DataField="modalidade" HeaderText="Modalidade" SortExpression="modalidade" />
            <asp:BoundField DataField="horario" HeaderText="Horário da Competicao" SortExpression="horario" />
            <asp:BoundField DataField="genero" HeaderText="Gênero" SortExpression="genero" />
            <asp:BoundField DataField="descricao" HeaderText="Descricão" SortExpression="descricao" />
            <asp:BoundField DataField="valorInscricao" HeaderText="Valor da Inscricão" SortExpression="valorInscricao" />
            <asp:BoundField DataField="numeromaximoInscritos" HeaderText="N Máximo de Inscritos" SortExpression="numeromaximoInscritos" />
            <asp:BoundField DataField="status_competicao" HeaderText="Status Competicao" SortExpression="status_competicao" />
            <asp:BoundField DataField="Organizador_id" HeaderText="ID do Organizador" SortExpression="Organizador_id" />
            <asp:BoundField DataField="rua" HeaderText="Rua" SortExpression="rua" />
            <asp:BoundField DataField="numero" HeaderText="Numero" SortExpression="numero" />
            <asp:BoundField DataField="bairro" HeaderText="Bairro" SortExpression="bairro" />
            <asp:BoundField DataField="uf" HeaderText="UF" SortExpression="uf" />
            <asp:BoundField DataField="cidade" HeaderText="Cidade" SortExpression="cidade" />
            <asp:BoundField DataField="cep" HeaderText="CEP" SortExpression="cep" />
            <asp:BoundField DataField="complemento" HeaderText="Descricao" SortExpression="complemento" />
            <asp:ButtonField CommandName="Editar" Text="Editar" />
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
    <asp:SqlDataSource ID="SqlDataSource1" runat="server" ConnectionString="<%$ ConnectionStrings:ConnectionString %>" SelectCommand="SELECT * FROM [Competicao]"></asp:SqlDataSource>
</asp:Content>
