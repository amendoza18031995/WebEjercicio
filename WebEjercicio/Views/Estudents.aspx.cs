using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace WebEjercicio.Views
{
    public partial class Estudents : System.Web.UI.Page
    {
        private RepositorioEstudiante rpEstudiante = new RepositorioEstudiante();

        protected void Page_Load(object sender, EventArgs e)
        {

            if (!IsPostBack)
            {
                var Estudiantes = rpEstudiante.ListarEstudiantes();

                ddlEstudiante.DataSource = Estudiantes;
                ddlEstudiante.DataTextField = "Nombre";
                ddlEstudiante.DataValueField = "IdEstudiante";
                ddlEstudiante.DataBind();
                ddlEstudiante.Items.Insert(0, "SELECCIONAR");


            }


        }

        public void CargarDatos()
        {
            int IdEst = Convert.ToInt32(ddlEstudiante.SelectedValue);
            int IdPer = Convert.ToInt32(ddlPeriodo.SelectedValue);
            int IdMat = Convert.ToInt32(ddlMateria.SelectedValue);

            var Resultado = rpEstudiante.ListarNotas(IdEst, IdPer, IdMat);
            if (Resultado.Rows.Count > 0)
            {
                gvNotas.DataSource = Resultado;
                gvNotas.DataBind();
            }
            else
            {
                gvNotas.DataSource = null;
                gvNotas.DataBind();
            }

        }

        protected void btnConsultar_Click(object sender, EventArgs e)
        {
            int IdEst = Convert.ToInt32(ddlEstudiante.SelectedValue);
            int IdPer = Convert.ToInt32(ddlPeriodo.SelectedValue);
            int IdMat = Convert.ToInt32(ddlMateria.SelectedValue);

            var Resultado = rpEstudiante.ListarNotas(IdEst, IdPer, IdMat);
            if(Resultado.Rows.Count > 0)
            {
                gvNotas.DataSource = Resultado;
                gvNotas.DataBind();
            }
            else
            {
                gvNotas.DataSource = null;
                gvNotas.DataBind();
            }

        }

        protected void ddlEstudiante_SelectedIndexChanged(object sender, EventArgs e)
        {
            var Periodo = rpEstudiante.ListarPeriodos();

            ddlPeriodo.DataSource = Periodo;
            ddlPeriodo.DataTextField = "Curso";
            ddlPeriodo.DataValueField = "IdPeriodo";
            ddlPeriodo.DataBind();
            ddlPeriodo.Items.Insert(0, "SELECCIONAR");
        }

        protected void ddlPeriodo_SelectedIndexChanged(object sender, EventArgs e)
        {
            var Periodo = rpEstudiante.ListarMaterias();

            ddlMateria.DataSource = Periodo;
            ddlMateria.DataTextField = "NombreMateria";
            ddlMateria.DataValueField = "IdMateria";
            ddlMateria.DataBind();
            ddlMateria.Items.Insert(0, "SELECCIONAR");
        }

        protected void btnAgregar_Click(object sender, EventArgs e)
        {
            UNota.Visible = true;
        }

        protected void lnkSave_Click(object sender, EventArgs e)
        {
            int IdEst = Convert.ToInt32(ddlEstudiante.SelectedValue);
            int IdPer = Convert.ToInt32(ddlPeriodo.SelectedValue);
            int IdMat = Convert.ToInt32(ddlMateria.SelectedValue);

            rpEstudiante.AdicionarRegistro(IdEst, IdPer, IdMat,Convert.ToDecimal(txtNota.Text));

            UNota.Visible = false;
            txtNota.Text = "";
            CargarDatos();
        }

        protected void gvNotas_RowCommand(object sender, GridViewCommandEventArgs e)
        {
            int IdEst = Convert.ToInt32(ddlEstudiante.SelectedValue);
            int IdPer = Convert.ToInt32(ddlPeriodo.SelectedValue);
            int IdMat = Convert.ToInt32(ddlMateria.SelectedValue);
            int rowIndex = Convert.ToInt32(e.CommandArgument) % gvNotas.PageSize;

            if (e.CommandName.Equals("Editar"))
            {
                Session["id"] = Convert.ToInt32(gvNotas.DataKeys[rowIndex].Values[0]);
                txtUpNota.Text = gvNotas.DataKeys[rowIndex].Values[1].ToString();

                System.Text.StringBuilder sbAEditarNota = new System.Text.StringBuilder();
                sbAEditarNota.Append(@"<script type='text/javascript'>");
                sbAEditarNota.Append("$('#EditarNota').modal('show');");
                sbAEditarNota.Append(@"</script>");
                ScriptManager.RegisterStartupScript(this, this.GetType(), "EditarNotaShowModalScript", sbAEditarNota.ToString(), false);
            }
            if (e.CommandName.Equals("Eliminar"))
            {
                int id = Convert.ToInt32(gvNotas.DataKeys[rowIndex].Values[0]);

                rpEstudiante.EliminarRegistro(id);
                CargarDatos();
            }
        }

        protected void lnkActualizar_Click(object sender, EventArgs e)
        {
            int id = Convert.ToInt32(Session["id"].ToString());

            rpEstudiante.ActualizarRegistro(id, Convert.ToDouble(txtUpNota.Text));

            CargarDatos();
        }
    }
}