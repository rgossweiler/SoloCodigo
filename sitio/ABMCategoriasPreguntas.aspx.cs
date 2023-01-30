using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

using EntidadesCompartidas;
using Logica;
using System.Drawing;

public partial class ABMCategoriasPreguntas : System.Web.UI.Page
{
    protected void Page_Load(object sender, EventArgs e)
    {
        lblError.Text = "";

        if (!IsPostBack)
            LimpioFormulario();
    }

    private void LimpioFormulario()
    {
        btnModificar.Enabled = false;
        btnEliminar.Enabled = false;
        btnAgregar.Enabled = false;
        btnBuscar.Enabled = true;

        txtCodigo.Text = "";
        txtCodigo.Enabled = true;
        txtNombreCodigo.Enabled = false;
        txtNombreCodigo.Text = "";
    }

    private void ActivoBotones(bool esAlta)
    {
        btnModificar.Enabled = !esAlta;
        btnEliminar.Enabled = !esAlta;
        btnAgregar.Enabled = esAlta;
        btnBuscar.Enabled = false;

        txtCodigo.Enabled = false;
        txtNombreCodigo.Enabled = true;
    }


    protected void btnAgregar_Click(object sender, EventArgs e)
    {

    }
    protected void btnModificar_Click(object sender, EventArgs e)
    {

    }
    protected void btnEliminar_Click(object sender, EventArgs e)
    {

    }
    protected void btnBuscar_Click(object sender, EventArgs e)
    {

    }
    protected void btnLimpiar_Click(object sender, EventArgs e)
    {
        LimpioFormulario();
    }
}