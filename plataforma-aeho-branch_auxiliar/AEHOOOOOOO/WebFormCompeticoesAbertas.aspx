<%@ Page Title=" Competicoes Abertas " Language="C#" MasterPageFile="~/MasterAno.Master" AutoEventWireup="true" CodeBehind="WebFormCompeticoesAbertas.aspx.cs" Inherits="AEHOOOOOOO.WebFormCompeticoesAbertas1" %>
<%@ MasterType virtualPath="~/MasterAno.Master" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <asp:Table ID="Table1" runat="server"></asp:Table>
    <asp:ObjectDataSource runat="server" ID="ObjectDataSource1" SelectMethod="Select" TypeName="AEHOOOOOOO.DAL.DALCompeticao">
        <SelectParameters>
            <asp:SessionParameter SessionField="status_competicao" Name="status" Type="Int32"></asp:SessionParameter>
        </SelectParameters>
    </asp:ObjectDataSource>
</asp:Content>
