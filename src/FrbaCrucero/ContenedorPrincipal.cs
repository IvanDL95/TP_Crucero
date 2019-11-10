﻿using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Collections;
using System.Data.SqlClient;
using MiLibreria;
using FrbaCrucero.Listados;
using FrbaCrucero.ABMCrucero;
using FrbaCrucero.Generar_viaje;
using FrbaCrucero.AbmRecorrido;
using FrbaCrucero.ABMPuerto;

namespace FrbaCrucero
{
    public partial class ContenedorPrincipal : Form
    {
        public int id { get; set; }
        public int id_rol { get; set; }
        public String usuario { get; set; }

        private int childFormNumber = 0;
        public const int ADMINISTRADOR = 1;
        ArrayList funcionalidades = new ArrayList();


        public ContenedorPrincipal(int id, String usuario, int rol, Boolean primerInicio, bool iniciado)
        {
            InitializeComponent();
            inicializar(id, usuario, rol, primerInicio, iniciado);
            
            //cambiar menu por rol
        }

        public void inicializar(int id, String usuario, int rol, Boolean primerInicio, bool iniciado)
        {
            this.id = id;
            this.id_rol = rol;
            this.usuario = usuario;
            this.cerrarSesionToolStripMenuItem.Available = true;
            this.cambiarClienteToolStripMenuItem.Available = true;
            this.aBMToolStripMenuItem.Available = false;
            this.aBMRolToolStripMenuItem.Available = false;
            this.accionesToolStripMenuItem.Available = false;
            this.comprarReservarViajeToolStripMenuItem.Available = false;
            this.pagoReservaToolStripMenuItem.Available = false;
            this.registroToolStripMenuItem.Available = false;
            this.generarViajeToolStripMenuItem.Available = false;
            this.listadoToolStripMenuItem.Available = false;
            this.estadísticoToolStripMenuItem.Available = false;
            this.aBMPuertoToolStripMenuItem.Available = false;
            this.aBMRecorridoToolStripMenuItem.Available = false;

            if (rol == 2) //Cliente
                this.cerrarSesionToolStripMenuItem.Available = false;      
            
            CambiarMenu(rol);
        }


        private int ObtenerFuncionalidades(int rol)
        {
            List<SqlParameter> parametros = new List<SqlParameter>();
            parametros.Add(new SqlParameter("@ID_ROL", rol));
            SqlDataReader reader = DataBase.ObtenerUnDataReader("TROLLS.OBTENER_FUNCIONALIDADES_ROL", DataBase.Tipos.StoredProcedure, parametros);

            if (reader.HasRows)
            {
                while (reader.Read())
                {
                    int fun = Convert.ToInt32(reader.GetValue(0));
                    this.funcionalidades.Add(fun);
                }
            }

            reader.Close();
            return id;

        }

        private void CambiarMenu(int rol)
        {
            //Buscar funcionalidades correspodientes a ese rol de la base
            funcionalidades.Clear();
            ObtenerFuncionalidades(rol);

            //Recorrer las funcionalidades
            foreach (int i in this.funcionalidades)
            {
                //Definir en el menu que puede utilizarse segun funcionalidades

                switch (i)
                {

                    case 1:
                        this.aBMToolStripMenuItem.Available = true;
                        this.aBMRolToolStripMenuItem.Available = true;
                        break;

                    case 4:
                        this.aBMToolStripMenuItem.Available = true;
                        this.aBMCruceroToolStripMenuItem.Available = true;
                        break;

                    case 2:
                        this.aBMToolStripMenuItem.Available = true;
                        this.aBMPuertoToolStripMenuItem.Available = true;
                        break;

                    case 3:
                        this.aBMToolStripMenuItem.Available = true;
                        this.aBMRecorridoToolStripMenuItem.Available = true;
                        break;

                    case 5:
                        this.registroToolStripMenuItem.Available = true;
                        this.generarViajeToolStripMenuItem.Available = true;
                        break;

                    case 6:
                        this.accionesToolStripMenuItem.Available = true;
                        this.comprarReservarViajeToolStripMenuItem.Available = true;
                        break;

                    case 7:
                        this.accionesToolStripMenuItem.Available = true;
                        this.pagoReservaToolStripMenuItem.Available = true;
                        break;

                    case 8:
                        this.listadoToolStripMenuItem.Available = true;
                        this.estadísticoToolStripMenuItem.Available = true;
                        break;

                    default: break;
                }

            }
        }


        private void ExitToolsStripMenuItem_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void CascadeToolStripMenuItem_Click(object sender, EventArgs e)
        {
            LayoutMdi(MdiLayout.Cascade);
        }

        private void TileVerticalToolStripMenuItem_Click(object sender, EventArgs e)
        {
            LayoutMdi(MdiLayout.TileVertical);
        }

        private void TileHorizontalToolStripMenuItem_Click(object sender, EventArgs e)
        {
            LayoutMdi(MdiLayout.TileHorizontal);
        }

        private void ArrangeIconsToolStripMenuItem_Click(object sender, EventArgs e)
        {
            LayoutMdi(MdiLayout.ArrangeIcons);
        }

        private void CloseAllToolStripMenuItem_Click(object sender, EventArgs e)
        {
            foreach (Form childForm in MdiChildren)
            {
                childForm.Close();
            }
        }

        private void aBMRolToolStripMenuItem_Click(object sender, EventArgs e)
        {
            AbmRol.FormRol fr = new AbmRol.FormRol();
            this.Hide();
            if (!fr.IsDisposed)
            fr.ShowDialog();
            this.Show();
        }

        private void comprarReservarViajeToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Compra_Reservar.FormCompraReservar fr = new Compra_Reservar.FormCompraReservar();
            this.Hide();
            if (!fr.IsDisposed)
                fr.ShowDialog();
            this.Show();
        }

        private void pagoReservaToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Pago_Reserva.PagoReserva fr = new Pago_Reserva.PagoReserva();
            this.Hide();
            if (!fr.IsDisposed)
                fr.ShowDialog();
            this.Show();
        }

        private void generarViajeToolStripMenuItem_Click(object sender, EventArgs e)
        {
            FormGenerarViaje fr = new FormGenerarViaje();
                this.Hide();
                if (!fr.IsDisposed)
                    fr.ShowDialog();
                this.Show();            
        }

        private void estadísticoToolStripMenuItem_Click(object sender, EventArgs e)
        {
            FormListadoEstadistico fr = new FormListadoEstadistico();
            this.Hide();
            if (!fr.IsDisposed)
                fr.ShowDialog();
            this.Show();
        }

        private void cerrarSesionToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Login fr = new Login(this);
            this.Hide();
            fr.ShowDialog();
            this.Close();
        }

        private void aBMPuertoToolStripMenuItem_Click(object sender, EventArgs e)
        {
            ABMPuertoForm fr = new ABMPuertoForm();
            this.Hide();
            if (!fr.IsDisposed)
                fr.ShowDialog();
            this.Show();
        }

        private void aBMRecorridoToolStripMenuItem_Click(object sender, EventArgs e)
        {
            FormRecorrido fr = new FormRecorrido();
            this.Hide();
            if (!fr.IsDisposed)
            fr.ShowDialog();
            this.Show();
        }

        private void aBMCruceroToolStripMenuItem_Click(object sender, EventArgs e)
        {
            FormCrucero fr = new FormCrucero();
            this.Hide();
            if (!fr.IsDisposed)
            fr.ShowDialog();
            this.Show();
        }

        private void ContenedorPrincipal_Load(object sender, EventArgs e)
        {
            if (this.id_rol == 1)
            { //Es admin
                CompraFunc.CancelarReserva();
                CruceroFunc.HabilitarCrucero();
            }

        }

        private void cambiarClienteToolStripMenuItem_Click(object sender, EventArgs e)
        {
            PantallaIncial fr = new PantallaIncial(null,null);
            this.Hide();
            if (!fr.IsDisposed)
            fr.ShowDialog();
            this.Close();
        }

    }
}