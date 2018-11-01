<%@ Page Language="C#" AutoEventWireup="true" CodeFile="install-test.aspx.cs" Inherits="page_install_test_install_test" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <meta http-equiv="Content-Type" content="text/html; charset=utf-8" />
    <title></title>
</head>
<body>
    <form id="form1" runat="server">
        <div style="text-align: center">
            <asp:Button ID="btn" runat="server" Text="点击" OnClick="btn_Click" />
        </div>
        <div style="text-align: center">
            <asp:Label id="lbl" runat="server" ForeColor="#33cccc" Font-Size="Large"></asp:Label>
        </div>
    </form>
</body>
</html>
