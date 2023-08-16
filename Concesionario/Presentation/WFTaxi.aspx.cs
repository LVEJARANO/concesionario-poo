using Data.Model;
using Logic;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Text.RegularExpressions;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace Presentation
{
    public partial class WFTaxi : System.Web.UI.Page
    {
        TaxiLog objTaxLog = new TaxiLog();
        VehiculoLog objVehLog = new VehiculoLog();
        private int idTaxi;
        private int numPasajeros;
        private int fkVehiculo;
        private bool ejecuto = false;
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!Page.IsPostBack)
            {
                mostrarTaxis();
                llenarDDLVehiculos();
            }
        }
        private void mostrarTaxis()
        {
            List<Taxi> lista = objTaxLog.mostrarTaxis();
            GVTaxis.DataSource = lista;
            GVTaxis.DataBind();
        }
        private void llenarDDLVehiculos()
        {
            ddlVehiculo.DataSource = objVehLog.llenarDDLVehiculos();
            ddlVehiculo.DataValueField = "idVehiculo";
            ddlVehiculo.DataTextField = "placa";
            ddlVehiculo.DataBind();
            ddlVehiculo.Items.Insert(0, "Seleccione");
        }
        private void limpiarCampos()
        {
            txtIdTaxi.Text = "";
            txtNumPasajeros.Text = "";
            ddlVehiculo.SelectedIndex = 0;
        }

        protected void GVTaxis_RowDeleting(object sender, GridViewDeleteEventArgs e)
        {
            idTaxi = Convert.ToInt32(GVTaxis.DataKeys[e.RowIndex].Values[0]);
            ejecuto = objTaxLog.eliminarTaxi(idTaxi);

            if (ejecuto)
            {
                lblMensaje.Text = "El taxi se elimino exitosamente";
                GVTaxis.EditIndex = -1;
                mostrarTaxis();
            }
            else
            {
                lblMensaje.Text = "Error al eliminar el taxi";
            }
        }

        protected void GVTaxis_SelectedIndexChanged(object sender, EventArgs e)
        {
            //int idTaxi, string marca, string placa, int modelo,int numPasajeros, int idVehiculo
            txtIdTaxi.Text = GVTaxis.SelectedRow.Cells[2].Text;
            txtNumPasajeros.Text = GVTaxis.SelectedRow.Cells[3].Text;
            ddlVehiculo.SelectedValue = GVTaxis.SelectedRow.Cells[4].Text;      
        }

        protected void btnGuardar_Click(object sender, EventArgs e)
        {
            numPasajeros = int.Parse(txtNumPasajeros.Text);
            fkVehiculo = int.Parse(ddlVehiculo.SelectedValue.ToString());
            Taxi objTaxi = new Taxi(numPasajeros, fkVehiculo);
            ejecuto = objTaxLog.guardarTaxi(objTaxi);

            if (ejecuto)
            {
                lblMensaje.Text = "Se guardo";
                mostrarTaxis();
                limpiarCampos();
            }
            else
            {
                lblMensaje.Text = "No se guardo";
            }
        }

        protected void btnActualizar_Click(object sender, EventArgs e)
        {
            idTaxi = int.Parse(txtIdTaxi.Text);
            numPasajeros = int.Parse(txtNumPasajeros.Text);
            fkVehiculo = int.Parse(ddlVehiculo.SelectedValue.ToString());
            Taxi objTaxi = new Taxi(idTaxi,numPasajeros, fkVehiculo);
            ejecuto = objTaxLog.actualizarTaxi(objTaxi);

            if (ejecuto)
            {
                lblMensaje.Text = "Se actualizo";
                mostrarTaxis();
                limpiarCampos();
            }
            else
            {
                lblMensaje.Text = "No se actualizo";
            }
        }

        protected void GVTaxis_RowDataBound(object sender, GridViewRowEventArgs e)
        {
            if (e.Row.RowType == DataControlRowType.Header)
            {
                
                e.Row.Cells[5].Visible = false;//Oculta la cabecera del idVehiculo
                
            }
            if (e.Row.RowType == DataControlRowType.DataRow)
            {        
                e.Row.Cells[5].Visible = false;//Oculta la fila del idVehiculo    
            }
        }
    }
}