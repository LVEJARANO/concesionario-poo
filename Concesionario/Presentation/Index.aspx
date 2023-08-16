<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="Index.aspx.cs" Inherits="Presentation.Index" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
<meta http-equiv="Content-Type" content="text/html; charset=utf-8"/>
    <title></title>
</head>
<body>
    <form id="form1" runat="server">
        <div>
            <a href="Index.aspx">Inicio</a>
            <a href="WFTaxi.aspx">Gestión Taxi</a><br />
            <asp:TextBox ID="txtIdVehiculo" runat="server"></asp:TextBox>
            <asp:TextBox ID="txtMarca" runat="server"></asp:TextBox>
            <asp:TextBox ID="txtPlaca" runat="server"></asp:TextBox>
            <asp:TextBox ID="txtModelo" runat="server"></asp:TextBox>
            <asp:Button ID="BtnGuardar" runat="server" Text="Guardar" OnClick="BtnGuardar_Click" /><br />
            <asp:Button ID="BtnActualizar" runat="server" Text="Actualizar" OnClick="BtnActualizar_Click" /><br />
            <asp:Label ID="LblMensaje" runat="server" Text=""></asp:Label>
            <asp:GridView ID="GVVehiculos" runat="server" OnSelectedIndexChanged="GVVehiculos_SelectedIndexChanged" DataKeyNames="idVehiculo" OnRowDeleting="GVVehiculos_RowDeleting">
                <Columns>
                    <asp:CommandField ShowSelectButton="True" />
                    <asp:CommandField ShowDeleteButton="True" />
                </Columns>
            </asp:GridView>
        </div>
    </form>
</body>
</html>
