<%@ Page Title="Competicoes Encerradas" Language="C#" MasterPageFile="~/MasterAno.Master" AutoEventWireup="true" CodeBehind="WebFormCompeticaoEncerrada.aspx.cs" Inherits="AEHOOOOOOO.WebFormCompeticaoEncerrada" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <asp:Table ID="Table1" runat="server"></asp:Table>
    <asp:ObjectDataSource ID="ObjectDataSource1" runat="server" SelectMethod="Select" TypeName="AEHOOOOOOO.DAL.DALCompeticao">
        <SelectParameters>
            <asp:SessionParameter SessionField="status_competicao" Name="status" Type="Int32"></asp:SessionParameter>
        </SelectParameters>
    </asp:ObjectDataSource>
</asp:Content>
