<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="WebFormMensagem.aspx.cs" Inherits="AEHOOOOOOO.WebFormMensagem" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title></title>
</head>
<body>
    <form id="form1" runat="server">
    <div>
       <asp:Panel ID="Panel1" runat="server"></asp:Panel>
        Mensagem:<asp:TextBox ID="TextBox1" runat="server" TextMode="MultiLine" Rows="3"></asp:TextBox>
        <br />
        <asp:Button ID="Button1" runat="server" Text="Enviar" OnClick="Button1_Click" />
    </div>
    </form>
</body>
</html>
