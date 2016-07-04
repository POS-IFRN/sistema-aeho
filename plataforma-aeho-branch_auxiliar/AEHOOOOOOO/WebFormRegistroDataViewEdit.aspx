<%@ Page Title="" Language="C#" MasterPageFile="~/SiteMaster.Master" AutoEventWireup="true" CodeBehind="WebFormRegistroDataViewEdit.aspx.cs" Inherits="AEHOOOOOOO.WebFormRegistroDataViewEdit" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <asp:DetailsView ID="DetailsView1" runat="server" Height="50px" Width="500px" AutoGenerateRows="False" BackColor="White" BorderColor="White" BorderStyle="Ridge" BorderWidth="2px" CellPadding="3" CellSpacing="1" DataKeyNames="id" DataSourceID="SqlDataSource1" GridLines="None">
        <EditRowStyle BackColor="#9471DE" Font-Bold="True" ForeColor="White" />
        <Fields>
            <asp:BoundField DataField="id" HeaderText="id" InsertVisible="False" ReadOnly="True" SortExpression="id" />
            <asp:BoundField DataField="nome" HeaderText="nome" SortExpression="nome" />
            <asp:BoundField DataField="inicioInscricao" HeaderText="inicioInscricao" SortExpression="inicioInscricao" />
            <asp:BoundField DataField="encerramentoInscricao" HeaderText="encerramentoInscricao" SortExpression="encerramentoInscricao" />
            <asp:BoundField DataField="dataEvento" HeaderText="dataEvento" SortExpression="dataEvento" />
            <asp:BoundField DataField="dataFimEvento" HeaderText="dataFimEvento" SortExpression="dataFimEvento" />
            <asp:BoundField DataField="modalidade" HeaderText="modalidade" SortExpression="modalidade" />
            <asp:BoundField DataField="horario" HeaderText="horario" SortExpression="horario" />
            <asp:BoundField DataField="genero" HeaderText="genero" SortExpression="genero" />
            <asp:BoundField DataField="descricao" HeaderText="descricao" SortExpression="descricao" />
            <asp:BoundField DataField="valorInscricao" HeaderText="valorInscricao" SortExpression="valorInscricao" />
            <asp:BoundField DataField="numeromaximoInscritos" HeaderText="numeromaximoInscritos" SortExpression="numeromaximoInscritos" />
            <asp:BoundField DataField="status_competicao" HeaderText="status_competicao" SortExpression="status_competicao" />
            <asp:BoundField DataField="Organizador_id" HeaderText="Organizador_id" SortExpression="Organizador_id" />
            <asp:BoundField DataField="rua" HeaderText="rua" SortExpression="rua" />
            <asp:BoundField DataField="numero" HeaderText="numero" SortExpression="numero" />
            <asp:BoundField DataField="bairro" HeaderText="bairro" SortExpression="bairro" />
            <asp:BoundField DataField="uf" HeaderText="uf" SortExpression="uf" />
            <asp:BoundField DataField="cidade" HeaderText="cidade" SortExpression="cidade" />
            <asp:BoundField DataField="cep" HeaderText="cep" SortExpression="cep" />
            <asp:BoundField DataField="complemento" HeaderText="complemento" SortExpression="complemento" />
            <asp:CommandField ShowDeleteButton="True" ShowEditButton="True" />
        </Fields>
        <FooterStyle BackColor="#C6C3C6" ForeColor="Black" />
        <HeaderStyle BackColor="#4A3C8C" Font-Bold="True" ForeColor="#E7E7FF" />
        <PagerStyle BackColor="#C6C3C6" ForeColor="Black" HorizontalAlign="Right" />
        <RowStyle BackColor="#DEDFDE" ForeColor="Black" />
    </asp:DetailsView>
    <asp:SqlDataSource ID="SqlDataSource1" runat="server" ConnectionString="<%$ ConnectionStrings:ConnectionString %>" DeleteCommand="DELETE FROM Competicao WHERE (id = @id)" SelectCommand="SELECT * FROM Competicao
WHERE (id = @competicao_id)" UpdateCommand="UPDATE Competicao SET nome = @nome, inicioInscricao = @inicioInscricao, encerramentoInscricao = @encerramentoInscricao, dataEvento = @dataEvento, dataFimEvento = @dataFimEvento, modalidade = @modalidade, horario = @horario, genero = @genero, descricao = @descricao, valorInscricao = @valorInscricao, numeromaximoInscritos = @numeromaximoInscritos, status_competicao = @status_competicao, Organizador_id = @Organizador_id , rua = @rua, numero = @numero, bairro = @bairro, uf = @uf, cidade = @cidade, cep = @cep, complemento = @complemento">
        <DeleteParameters>
            <asp:Parameter Name="id" />
        </DeleteParameters>
        <SelectParameters>
            <asp:SessionParameter Name="competicao_id" SessionField="competicao_id" />
        </SelectParameters>
        <UpdateParameters>
            <asp:Parameter Name="nome" />
            <asp:Parameter Name="inicioInscricao" />
            <asp:Parameter Name="encerramentoInscricao" />
            <asp:Parameter Name="dataEvento" />
            <asp:Parameter Name="dataFimEvento" />
            <asp:Parameter Name="modalidade" />
            <asp:Parameter Name="horario" />
            <asp:Parameter Name="genero" />
            <asp:Parameter Name="descricao" />
            <asp:Parameter Name="valorInscricao" />
            <asp:Parameter Name="numeromaximoInscritos" />
            <asp:Parameter Name="status_competicao" />
            <asp:Parameter Name="Organizador_id" />
            <asp:Parameter Name="rua" />
            <asp:Parameter Name="numero" />
            <asp:Parameter Name="bairro" />
            <asp:Parameter Name="uf" />
            <asp:Parameter Name="cidade" />
            <asp:Parameter Name="cep" />
            <asp:Parameter Name="complemento" />
        </UpdateParameters>
    </asp:SqlDataSource>
</asp:Content>
