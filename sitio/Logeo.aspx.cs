using EntidadesCompartidas;
using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

public partial class Logeo : System.Web.UI.Page
{
    protected void Page_Load(object sender, EventArgs e)
    {
        lblError.Text = "";
        if (!IsPostBack)
            LimpiarFormularioInicioSesion();
    }

    protected void LimpiarFormularioInicioSesion()
    {
        txtNombreCompleto.Text = "";
        txtNombreUsuario.Text = "";
        txtPwd.Text = "";
        InisiarSession.Visible = true;

        Registrarse.Visible = false;
        txtNombreCompleto.Visible = false;
        btnSesion.Visible = false;
        btnRegistro.Visible = true;
    }
    protected void LimpiarFormularioRegistro()
    {
        InisiarSession.Attributes.Add("style", "padding: 15px 20px !important;");
        Registrarse.Attributes.Add("style", "padding: 15px 20px !important;");
        Limpiar.Attributes.Add("style", "padding: 15px 20px !important;");

        txtNombreCompleto.Text = "";
        txtNombreUsuario.Text = "";
        txtPwd.Text = "";
        InisiarSession.Visible = false;

        Registrarse.Visible = true;
        txtNombreCompleto.Visible = true;
        btnSesion.Visible = true;
        btnRegistro.Visible = false;
    }

    protected void IniciarSesion_Click(object sender, EventArgs e)
    {
        lblError.Text = "";

        try
        {
            Usuarios usuario = new Usuarios(txtNombreUsuario.Text, txtPwd.Text, txtNombreCompleto.Text);
            var logueo = Logica.LogicaUsuarios.LogeoUsuario(usuario);

            if (logueo == 1)
            {
            }
            else
            {
            }
        }
        catch (Exception ex)
        {
            LimpiarFormularioInicioSesion();
            btnRegistro.Visible = true;
            lblError.ForeColor = Color.Red;
            lblError.Text = ex.Message;
        }
    }
    protected void LimpiarFormulario_Click(object sender, EventArgs e)
    {
        LimpiarFormularioInicioSesion();
    }
    protected void Registrarse_Click(object sender, EventArgs e)
    {
        lblError.Text = "";

        try
        {
            if (txtNombreCompleto.Text.Trim() == "")
            {
                throw new Exception("El nombre no puede estar vacio.");
            }

            Usuarios nuevoUsuario = new Usuarios(txtNombreUsuario.Text, txtPwd.Text, txtNombreCompleto.Text);

            var registrado = Logica.LogicaUsuarios.AgregarUsuario(nuevoUsuario);

            if (registrado == 1)
            {
                lblError.ForeColor = Color.Green;
                lblError.Text = "Usuario registrado exitosamente";
            }
        }
        catch (Exception ex)
        {
            LimpiarFormularioRegistro();
            lblError.ForeColor = Color.Red;
            lblError.Text = ex.Message;
        }

    }
    protected void OpcRegistro_Click(object sender, EventArgs e)
    {
        Titulo.Text = "Registrarse";
        LimpiarFormularioRegistro();
    }
    protected void OpcIinicioSesion_Click(object sender, EventArgs e)
    {
        Titulo.Text = "Iniciar Sesion";
        LimpiarFormularioInicioSesion();
    }

}