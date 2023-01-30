<%@ Page Title="" Language="C#" MasterPageFile="~/MPAdministradores.master" AutoEventWireup="true" CodeFile="ABMCategoriasPreguntas.aspx.cs" Inherits="ABMCategoriasPreguntas" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" Runat="Server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" Runat="Server">
    <p>
        <br />
    </p>
    <p>
    </p>
    <body>
    <form id="form1" runat="server" 
    
        style="position: absolute; top: 149px; left: 199px; font-family: 'Bahnschrift Light SemiCondensed'; height: 359px; width: 992px;">
    <p style="background-color: #66CCFF; font-size: 50px; font-family: Haettenschweiler;" 
        align="center">
        MANTENIMIENTO CATEGORIAS PREGUNTAS</p>



        <br/>

    <table bgcolor="#E1E1E1" border="2" style="width:100%;" align="center">
        <tr>
            <td class="style14" style="font-weight: bold; font-family: 'Arial Black';" 
                align="center" bgcolor="#66CCFF">
&nbsp; CODIGO:</td>
            <td class="style15" align="left" colspan="2">
                <asp:TextBox ID="txtCodigo" runat="server"  
                    placeholder="Ingrese código de 3 letras"></asp:TextBox>
                &nbsp;
                <asp:Button ID="btnBuscar" CssClass="Boton" runat="server" Font-Bold="True" 
                    Text="BUSCAR" onclick="btnBuscar_Click" />
            </td>
        </tr>
        <tr>
            <td class="style14" style="font-weight: bold; font-family: 'Arial Black';" 
                align="center" bgcolor="#66CCFF">
                NOMBRE CÓDIGO:</td>
            <td class="style15" align="left" colspan="2">
                <asp:TextBox ID="txtNombreCodigo" runat="server"></asp:TextBox>
            </td>
        </tr>
        <tr>
            <td class="style14" align="center">
                <asp:Button ID="btnAgregar" CssClass="Boton" runat="server" Font-Bold="True" 
                    Text="AGREGAR" onclick="btnAgregar_Click" />
            </td>
            <td class="style15" align="center">
                <asp:Button ID="btnModificar" CssClass="Boton" runat="server" Font-Bold="True" 
                    Text="MODIFICAR" onclick="btnModificar_Click" />
            </td>
            <td class="style7" align="center">
                <asp:Button ID="btnEliminar" CssClass="Boton" runat="server" Font-Bold="True" 
                    Text="ELIMINAR" onclick="btnEliminar_Click" />
            </td>
        </tr>
        <tr>
            <td class="style9" align="center" colspan="3">
                <asp:Button ID="btnLimpiar" CssClass="Boton" runat="server" Font-Bold="True" 
                    Text="LIMPIAR" BorderColor="Black" BorderStyle="Groove" Width="270px" 
                    onclick="btnLimpiar_Click" />
            </td>
        </tr>
        <tr>
            <td class="style9" align="center" colspan="3">
                <asp:Label ID="lblError" runat="server"></asp:Label>
            </td>
        </tr>
    </table>

    <br/>
    <div style="margin-left: 200px">
        <table border="1" style="width: 29%;">
            <tr>
                <td class="style12">
                    <img border="1" class="style13" src="Imagenes/Home.jpg" /></td>
                <td bgcolor="#999999" style="color: #FFFFFF; font-weight: bold">
                    <asp:LinkButton ID="LinkButton1" runat="server" PostBackUrl="~/Default.aspx">HomePage</asp:LinkButton>
                </td>
            </tr>
        </table>
    </div>
    <br/><br/><br/>

    </form>

</body>
    </p>
    <p>
    </p>
    <p>
    </p>
    <p>
    </p>
    <p>
    </p>
    <p>
    </p>
    <p>
    </p>
    <p>
    </p>
    <p>
    </p>
    <p>
    </p>
    <p>
    </p>
    <p>
    </p>
    <p>
    </p>
</asp:Content>


