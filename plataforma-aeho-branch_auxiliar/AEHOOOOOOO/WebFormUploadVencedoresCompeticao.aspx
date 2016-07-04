 <%@ Page Title="" Language="C#" MasterPageFile="~/MasterOrganizador.Master" AutoEventWireup="true" CodeBehind="WebFormUploadVencedoresCompeticao.aspx.cs" Inherits="AEHOOOOOOO.WebFormUploadVencedoresCompeticao" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">

    <asp:Label ID="Label1" runat="server" Text="Upload de vencedores da competição"></asp:Label>
    <br />
    <br />
    Selecione a competição para qual você deseja upar o arquivo:<asp:DropDownList ID="DropDownList1" runat="server" AutoPostBack="True" ></asp:DropDownList>
    <hr />
    <asp:Label ID="Label5" runat="server" Text="Atletas da competição"></asp:Label>
    <br />
     <asp:TextBox ID="TextBox4" runat="server" Visible="False"></asp:TextBox>
     <asp:Button ID="Button2" runat="server" Text="Pesquisar" 
        OnClick="Button2_Click" CssClass="ls-btn" Visible="False"/>
    <hr />
    <br />
    <asp:GridView ID="GridView1" runat="server" AutoGenerateColumns="False"  OnRowCommand="GridView1_RowCommand" CssClass="ls-table ls-bg-header" AllowPaging="True">
        <Columns>
            <asp:BoundField DataField="Nome" HeaderText="Nome" SortExpression="Nome" />
            <asp:BoundField DataField="Usuario" HeaderText="Usuario" SortExpression="Usuario" />
            <asp:BoundField DataField="Nascimento" HeaderText="Nascimento" SortExpression="Nascimento" />
            <asp:ButtonField HeaderText="Primeiro Lugar" Text="Primeiro Lugar" CommandName="plugar" />
            <asp:ButtonField HeaderText="Segundo Lugar" Text="Segundo Lugar" CommandName="slugar" />
            <asp:ButtonField HeaderText="Terceiro Lugar" Text="Terceiro Lugar" CommandName="tlugar" />
        </Columns>
    </asp:GridView>
    <asp:Label ID="Label2" runat="server" Text="Primeiro lugar"></asp:Label><asp:TextBox ID="TextBox1" runat="server" ReadOnly="True"></asp:TextBox><br />
    <asp:Label ID="Label3" runat="server" Text="Segundo lugar"></asp:Label><asp:TextBox ID="TextBox2" runat="server" ReadOnly="True"></asp:TextBox><br />
    <asp:Label ID="Label4" runat="server" Text="Terceiro lugar"></asp:Label><asp:TextBox ID="TextBox3" runat="server" ReadOnly="True"></asp:TextBox><br />
    <asp:Button ID="Button1" runat="server" Text="Submeter" OnClick="Button1_Click" CssClass="ls-btn"/>

</asp:Content>


