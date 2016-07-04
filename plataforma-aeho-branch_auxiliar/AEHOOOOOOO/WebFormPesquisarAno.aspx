<%@ Page Title="" Language="C#" MasterPageFile="~/MasterAno.Master" AutoEventWireup="true" CodeBehind="WebFormPesquisarAno.aspx.cs" Inherits="AEHOOOOOOO.WebFormPesquisarAno" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <asp:Label ID="Label123" runat="server" Text="Label"></asp:Label>
    <asp:GridView ID="GridView1" runat="server" AutoGenerateColumns="False" CellPadding="4" CellSpacing="6" DataSourceID="ObjectDataSource1" Font-Bold="False" ForeColor="#333333" GridLines="None">
        <AlternatingRowStyle BackColor="White" />
        <Columns>
            <asp:BoundField DataField="Organizador_usuario" HeaderText="Organizador" SortExpression="Organizador_usuario">
            <HeaderStyle Font-Bold="True" />
            </asp:BoundField>
            <asp:BoundField DataField="Descricao" HeaderText="Descrição" SortExpression="Descricao" />
            <asp:BoundField DataField="Genero" HeaderText="Gênero" SortExpression="Genero" />
            <asp:BoundField DataField="Modalidade" HeaderText="Modalidade" SortExpression="Modalidade" />
            <asp:BoundField DataField="Nome" HeaderText="Título" SortExpression="Nome" />
            <asp:BoundField DataField="Status_competicao" HeaderText="Status da competição" SortExpression="Status_competicao">
            <HeaderStyle Font-Bold="True" />
            </asp:BoundField>
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
    <br />
    <asp:ObjectDataSource ID="ObjectDataSource1" runat="server" SelectMethod="buscar" TypeName="Sistema_Aeho.Competicao">
        <SelectParameters>
            <asp:ControlParameter ControlID="TextBuscar" DefaultValue="" Name="strbsc" PropertyName="Text" Type="String" />
        </SelectParameters>
    </asp:ObjectDataSource>
     <asp:HyperLink ID="HyperLinkAbertas1" runat="server" NavigateUrl="~/WebFormCompAbertDAO.aspx" ForeColor="#6666FF">Detalhes - Competições Abertas</asp:HyperLink><br /><br />
    <asp:HyperLink ID="HyperLinkEncerradas1" runat="server" NavigateUrl="~/WebFormCompEncerDAO.aspx" ForeColor="#6666FF" >Detalhes - Competições Encerradas</asp:HyperLink>
</asp:Content>
