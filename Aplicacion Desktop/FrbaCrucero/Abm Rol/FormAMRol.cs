using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using MiLibreria.Modelo;
using MiLibreria;

namespace FrbaCrucero.AbmRol
{
    public partial class FormAMRol : Form
    {
        private static BindingList<Funcion> funcionesAgregadas = new BindingList<Funcion>();
        private static BindingList<Funcion> funcionesNoAgregadas = new BindingList<Funcion>();

        private Rol rol;

        public FormAMRol(Rol unRol, bool esAlta, Boolean habilitado)
        {
            InitializeComponent();

            funcionesAgregadas.Clear();
            funcionesNoAgregadas.Clear();

            rol = unRol;

            txt_nombre.Text = rol.nombre;
            txt_nombre.Enabled = false;
            

            if (esAlta)
            {
                chk_habilitado.Visible = false;
                chk_habilitado.Checked = habilitado;

                List<Funcion> funciones = Function.ObtenerFunciones();

                foreach (Funcion item in funciones)
                {
                    funcionesNoAgregadas.Add(item);
                }

                lst_funciones_no_agregadas.DataSource = funcionesNoAgregadas;
                lst_funciones_no_agregadas.DisplayMember = "NOMBRE";

                lst_funciones_agregadas.DataSource = funcionesAgregadas;
                lst_funciones_agregadas.DisplayMember = "Nombre";
            }
            else
            {
                if (habilitado) chk_habilitado.Checked = true;
                else chk_habilitado.Checked = false;


                List<Funcion> fadd = Function.ObtenerFuncionesPorRol(rol.id);

                foreach (Funcion item in fadd)
                {
                    funcionesAgregadas.Add(item);
                }

                lst_funciones_agregadas.DataSource = funcionesAgregadas;
                lst_funciones_agregadas.DisplayMember = "Nombre";

                List<Funcion> fNotadd = Function.ObtenerFuncionesNoAsignadasPorRol(rol.id);

                foreach (Funcion item in fNotadd)
                {
                    funcionesNoAgregadas.Add(item);
                }
            
                lst_funciones_no_agregadas.DataSource = funcionesNoAgregadas;
                lst_funciones_no_agregadas.DisplayMember = "Nombre";
            }
            

        }

        private void btn_agregar_Click(object sender, EventArgs e)
        {
            Funcion itemSeleccionado = (Funcion) lst_funciones_no_agregadas.Items[lst_funciones_no_agregadas.SelectedIndex];
            funcionesAgregadas.Add(itemSeleccionado);
            funcionesNoAgregadas.Remove(itemSeleccionado);

            Role.AgregarFuncionalidad(rol, itemSeleccionado);

        }

        private void btn_quitar_Click(object sender, EventArgs e)
        {
            Funcion itemSeleccionado = (Funcion)lst_funciones_agregadas.Items[lst_funciones_agregadas.SelectedIndex];
            funcionesNoAgregadas.Add(itemSeleccionado);
            funcionesAgregadas.Remove(itemSeleccionado);

            Role.QuitarFuncionalidad(rol, itemSeleccionado);
        }

        private void btn_cambiar_nombre_Click(object sender, EventArgs e)
        {
            txt_nombre.Enabled = true;
        }

        private void aceptarToolStripMenuItem_Click(object sender, EventArgs e)
        {

        }

        private void volverToolStripMenuItem_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void btAceptar_Click(object sender, EventArgs e)
        {
            Boolean habilitado = chk_habilitado.Checked;

            String nuevoNombre = txt_nombre.Text.Trim();
            Role.ActualizarNombre(rol.id, nuevoNombre, habilitado);

            this.Close();
        }



    }
}
