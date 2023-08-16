using Data.Model;
using Logic;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace Presentation
{
    public partial class Index : System.Web.UI.Page
    {
        VehiculoLog objVehLog = new VehiculoLog();
        private string marca;
        private string placa;
        private int modelo, idVehiculo;
        private bool ejecuto = false;
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!Page.IsPostBack)
            {
                mostrarVehiculos();
            }   
        }
        private void mostrarVehiculos()
        {
            List<Vehiculo> lista = objVehLog.mostrarVehiculos();
            GVVehiculos.DataSource = lista;
            GVVehiculos.DataBind();
        }
        private void limpiarCampos()
        {
            txtIdVehiculo.Text = "";
            txtMarca.Text = "";
            txtPlaca.Text = "";
            txtModelo.Text = "";
        }

        protected void BtnGuardar_Click(object sender, EventArgs e)
        {
            marca = txtMarca.Text;
            placa = txtPlaca.Text;
            modelo = int.Parse(txtModelo.Text);
            Vehiculo objVehiculo = new Vehiculo(marca,placa,modelo);
            ejecuto = objVehLog.guardarVehiculo(objVehiculo);

            if (ejecuto)
            {
                LblMensaje.Text = "Se guardo";
                mostrarVehiculos();
                limpiarCampos();
            }
            else
            {
                LblMensaje.Text = "No se guardo";
            }

        }

        protected void BtnActualizar_Click(object sender, EventArgs e)
        {
            idVehiculo = int.Parse(txtIdVehiculo.Text);
            marca = txtMarca.Text;
            placa = txtPlaca.Text;
            modelo = int.Parse(txtModelo.Text);
            Vehiculo objVehiculo = new Vehiculo(idVehiculo, marca, placa, modelo);
            ejecuto = objVehLog.actualizarVehiculo(objVehiculo);

            if (ejecuto)
            {
                LblMensaje.Text = "Se actualizo";
                mostrarVehiculos();
                limpiarCampos();
            }
            else
            {
                LblMensaje.Text = "No se actualizo";
            }
        }

        protected void GVVehiculos_SelectedIndexChanged(object sender, EventArgs e)
        {
            txtIdVehiculo.Text = GVVehiculos.SelectedRow.Cells[2].Text;
            txtMarca.Text = GVVehiculos.SelectedRow.Cells[3].Text;
            txtPlaca.Text = GVVehiculos.SelectedRow.Cells[4].Text;
            txtModelo.Text = GVVehiculos.SelectedRow.Cells[5].Text;
        }

        protected void GVVehiculos_RowDeleting(object sender, GridViewDeleteEventArgs e)
        {
            idVehiculo = Convert.ToInt32(GVVehiculos.DataKeys[e.RowIndex].Values[0]);
            ejecuto = objVehLog.eliminarVehiculo(idVehiculo);

            if (ejecuto)
            {
                LblMensaje.Text = "El vehiculo se elimino exitosamente";
                GVVehiculos.EditIndex = -1;
                mostrarVehiculos();
            }
            else
            {
                LblMensaje.Text = "Error al eliminar el vehiculo";
            }
            
        }
    }
}