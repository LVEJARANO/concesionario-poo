<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="WFTaxi.aspx.cs" Inherits="Presentation.WFTaxi" %>

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
            <asp:TextBox ID="txtIdTaxi" runat="server"></asp:TextBox>
            <asp:TextBox ID="txtNumPasajeros" runat="server"></asp:TextBox>
            <asp:DropDownList ID="ddlVehiculo" runat="server"></asp:DropDownList>
            <asp:Label ID="lblMensaje" runat="server" Text=""></asp:Label><br />
            <asp:Button ID="btnGuardar" runat="server" Text="Guardar" OnClick="btnGuardar_Click" />
            <asp:Button ID="btnActualizar" runat="server" Text="Actualizar" OnClick="btnActualizar_Click" /><br />
            <asp:GridView ID="GVTaxis" runat="server" DataKeyNames="idTaxi" OnRowDataBound="GVTaxis_RowDataBound" OnRowDeleting="GVTaxis_RowDeleting" OnSelectedIndexChanged="GVTaxis_SelectedIndexChanged">
                <Columns>
                    <asp:CommandField ShowSelectButton="True" />
                    <asp:CommandField ShowDeleteButton="True" />
                </Columns>
            </asp:GridView>
        </div>
    </form>
</body>
</html>
