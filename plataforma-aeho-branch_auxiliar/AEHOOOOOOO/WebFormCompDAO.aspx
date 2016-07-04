<%@ Page Title="" Language="C#" MasterPageFile="~/MasterAno.Master" AutoEventWireup="true" CodeBehind="WebFormCompDAO.aspx.cs" Inherits="AEHOOOOOOO.WebFormCompDAO" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <asp:Label ID="Label2" runat="server" Text="Label"></asp:Label>
    <asp:Label ID="Label1" runat="server" Text="Label"></asp:Label>
    <asp:Label ID="Label3" runat="server" Text="Label"></asp:Label>
    <asp:Label id="LabelVencedores" runat="server" text=""></asp:Label>
    <hr />
    <asp:Label ID="Label5" runat="server" Text="Atletas da competição." Visible="False"></asp:Label>
    <br />
    <asp:TextBox ID="TextBox4" runat="server" Visible="False"></asp:TextBox>
     <asp:Button ID="Button2" runat="server" Text="Pesquisar" OnClick="Button2_Click" CssClass="ls-btn" Visible="False" />
        <asp:GridView ID="GridView2" runat="server" AutoGenerateColumns="False" CssClass="ls-table ls-bg-header ls-table-striped" AllowPaging="True" PageSize="5">
            <Columns>
            
            <asp:BoundField DataField="Nome" HeaderText="Atletas Inscritos" SortExpression="Nome" ControlStyle-CssClass="hidden-xs" />
            <asp:BoundField DataField="Usuario" HeaderText="Usuario" SortExpression="Usuario" HeaderStyle-CssClass="hidden-xs" />
            <asp:BoundField DataField="Nascimento" HeaderText="Nascimento" SortExpression="Nascimento" HeaderStyle-CssClass="hidden-xs" />
            
        </Columns>
    </asp:GridView>
    <hr />
    <hr />
    <asp:Label ID="Label4" runat="server" Text="Histórico de troca de mensagens" Visible="False" Font-Bold="True" Font-Overline="False" Font-Size="Large"></asp:Label>
    <asp:Table ID="TableMensagens" runat="server"></asp:Table>
    <hr />
    <asp:Image ID="Image1" runat="server" />
    <asp:Panel ID="Panel1" runat="server"></asp:Panel>
</asp:Content>
