using System;
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
using FrbaCrucero.Generar_Rendicion_Comisiones;
using FrbaCrucero.Listados;

namespace FrbaCrucero
{
    public partial class ContenedorPrincipal : Form
    {
        public int id { get; set; }
        public int id_rol { get; set; }
        public String usuario { get; set; }

        Boolean primerInicio;
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
            this.primerInicio = primerInicio;
            this.aBMToolStripMenuItem.Available = false;
            this.aBMRolToolStripMenuItem.Available = false;
            this.aBMClienteToolStripMenuItem.Available = false;
            this.verToolStripMenuItem.Available = false;
            this.historialClienteToolStripMenuItem.Available = false;
            this.accionesToolStripMenuItem.Available = false;
            this.comprarEntradaToolStripMenuItem.Available = false;
            this.canjearPuntosToolStripMenuItem.Available = false;
            this.registroToolStripMenuItem.Available = false;
            this.generarPublicacionToolStripMenuItem.Available = false;
            this.editarPublicacionToolStripMenuItem.Available = false;
            this.listadoToolStripMenuItem.Available = false;
            this.estadísticoToolStripMenuItem.Available = false;
            this.aBMEmpresaToolStripMenuItem.Available = false;
            this.aBMGradoToolStripMenuItem.Available = false;
            this.rendiciónToolStripMenuItem.Available = false;
            this.generarComisiónToolStripMenuItem.Available = false;
            this.cambiarPasswordToolStripMenuItem.Available = true;

            if (iniciado)
            //Cambiar pass
            if (this.primerInicio)
            {
                MessageBox.Show("Debe modificar su password");
                CambiarPass fr = new CambiarPass(this.usuario, this.primerInicio);
                this.Hide();
                if (!fr.IsDisposed)
                    fr.ShowDialog();
                this.Show();
                this.primerInicio = false;
            }
            

            
            CambiarMenu(rol);
        }


        private int ObtenerFuncionalidades(int rol)
        {
            List<SqlParameter> parametros = new List<SqlParameter>();
            parametros.Add(new SqlParameter("@ID_ROL", rol));
            SqlDataReader reader = DataBase.ObtenerUnDataReader("RJT.OBTENER_FUNCIONALIDADES_ROL", DataBase.Tipos.StoredProcedure, parametros);

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

                    case 2:
                        this.aBMToolStripMenuItem.Available = true;
                        this.aBMUsuarioToolStripMenuItem.Available = true;
                        break;

                    case 3:
                        this.aBMToolStripMenuItem.Available = true;
                        this.aBMClienteToolStripMenuItem.Available = true;
                        break;

                    case 4:
                        this.aBMToolStripMenuItem.Available = true;
                        this.aBMEmpresaToolStripMenuItem.Available = true;
                        break;

                    case 5:
                        this.aBMToolStripMenuItem.Available = true;
                        this.aBMGradoToolStripMenuItem.Available = true;
                        break;

                    case 6:
                        this.registroToolStripMenuItem.Available = true;
                        this.generarPublicacionToolStripMenuItem.Available = true;
                        break;

                    case 7:
                        this.registroToolStripMenuItem.Available = true;
                        this.editarPublicacionToolStripMenuItem.Available = true;
                        break;

                    case 8:
                        this.accionesToolStripMenuItem.Available = true;
                        this.comprarEntradaToolStripMenuItem.Available = true;
                        break;

                    case 9:
                        this.verToolStripMenuItem.Available = true;
                        this.historialClienteToolStripMenuItem.Available = true;
                        break;

                    case 10:
                        this.accionesToolStripMenuItem.Available = true;
                        this.canjearPuntosToolStripMenuItem.Available = true;
                        break;

                    case 11:
                        this.rendiciónToolStripMenuItem.Available = true;
                        this.generarComisiónToolStripMenuItem.Available = true;
                        break;

                    case 12:
                        this.listadoToolStripMenuItem.Available = true;
                        this.estadísticoToolStripMenuItem.Available = true;
                        break;

                    default: break;
                }

            }
        }

        private void ShowNewForm(object sender, EventArgs e)
        {
            Form childForm = new Form();
            childForm.MdiParent = this;
            childForm.Text = "Ventana " + childFormNumber++;
            childForm.Show();
        }

        private void OpenFile(object sender, EventArgs e)
        {
            OpenFileDialog openFileDialog = new OpenFileDialog();
            openFileDialog.InitialDirectory = Environment.GetFolderPath(Environment.SpecialFolder.Personal);
            openFileDialog.Filter = "Archivos de texto (*.txt)|*.txt|Todos los archivos (*.*)|*.*";
            if (openFileDialog.ShowDialog(this) == DialogResult.OK)
            {
                string FileName = openFileDialog.FileName;
            }
        }

        private void SaveAsToolStripMenuItem_Click(object sender, EventArgs e)
        {
            SaveFileDialog saveFileDialog = new SaveFileDialog();
            saveFileDialog.InitialDirectory = Environment.GetFolderPath(Environment.SpecialFolder.Personal);
            saveFileDialog.Filter = "Archivos de texto (*.txt)|*.txt|Todos los archivos (*.*)|*.*";
            if (saveFileDialog.ShowDialog(this) == DialogResult.OK)
            {
                string FileName = saveFileDialog.FileName;
            }
        }

        private void ExitToolsStripMenuItem_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void CutToolStripMenuItem_Click(object sender, EventArgs e)
        {
        }

        private void CopyToolStripMenuItem_Click(object sender, EventArgs e)
        {
        }

        private void PasteToolStripMenuItem_Click(object sender, EventArgs e)
        {
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
            fr.ShowDialog();
            this.Show();
        }

        private void aBMClienteToolStripMenuItem_Click(object sender, EventArgs e)
        {
            AbmCliente.FormCliente fr = new AbmCliente.FormCliente();
            this.Hide();
            fr.ShowDialog();
            this.Show();
        }

        private void historialClienteToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if (String.Compare(this.usuario, "admin") == 0)
            {
                Historial_Cliente.FormHistorialCliente fr = new Historial_Cliente.FormHistorialCliente(true, this.usuario);
                this.Hide();
                if (!fr.IsDisposed)
                fr.ShowDialog();
                this.Show();
            }
            else
            {
                Historial_Cliente.FormHistorialCliente fr = new Historial_Cliente.FormHistorialCliente(false, this.usuario);
                this.Hide();
                if (!fr.IsDisposed)
                fr.ShowDialog();
                this.Show();
            }  
        }

        private void comprarEntradaToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if (String.Compare(this.usuario, "admin") == 0)
            {
                Compra_Entrada.FormCompraEntradas fr = new Compra_Entrada.FormCompraEntradas(true, this.usuario);
                this.Hide();
                if (!fr.IsDisposed)
                fr.ShowDialog();
                this.Show();
            }
            else
            {
                Compra_Entrada.FormCompraEntradas fr2 = new Compra_Entrada.FormCompraEntradas(false, this.usuario);
                this.Hide();
                if (!fr2.IsDisposed)
                fr2.ShowDialog();
                this.Show();
            }
        }

        private void canjearPuntosToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if (String.Compare(this.usuario, "admin") == 0)
            {
                Canjear_Puntos.FormCanjearPuntos fr = new Canjear_Puntos.FormCanjearPuntos(this.usuario,true);
                this.Hide();
                if (!fr.IsDisposed)
                fr.ShowDialog();
                this.Show();
            }
            else
            {
                Canjear_Puntos.FormCanjearPuntos fr = new Canjear_Puntos.FormCanjearPuntos(this.usuario, false);
                this.Hide();
                if (!fr.IsDisposed)
                fr.ShowDialog();
                this.Show();
            }
        }

        private void generarPublicacionToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if (String.Compare(this.usuario, "admin") == 0)
            {
                Generar_Publicacion.FormGenerarPublicacion fr = new Generar_Publicacion.FormGenerarPublicacion(this.usuario,true);
                this.Hide();
                if (!fr.IsDisposed)
                    fr.ShowDialog();
                this.Show();
            }
            else
            {
                Generar_Publicacion.FormGenerarPublicacion fr = new Generar_Publicacion.FormGenerarPublicacion(this.usuario,false);
                this.Hide();
                if (!fr.IsDisposed)
                    fr.ShowDialog();
                this.Show();
            }
        }

        private void editarPublicacionToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if (String.Compare(this.usuario, "admin") == 0)
            {
                Editar_Publicacion.FormListarPublicacion fr = new Editar_Publicacion.FormListarPublicacion(this.usuario,true);
                this.Hide();
                if (!fr.IsDisposed)
                    fr.ShowDialog();
                this.Show();
            }
            else
            {
                Editar_Publicacion.FormListarPublicacion fr = new Editar_Publicacion.FormListarPublicacion(this.usuario,false);
                this.Hide();
                if (!fr.IsDisposed)
                    fr.ShowDialog();
                this.Show();
            }
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
            fr.Show();
        }

        private void aBMEmpresaToolStripMenuItem_Click(object sender, EventArgs e)
        {
            AbmEmpresa.FormEmpresa fr = new AbmEmpresa.FormEmpresa();
            this.Hide();
            fr.ShowDialog();
            this.Show();
        }

        private void aBMGradoToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Abm_Grado.ABMGrado fr = new Abm_Grado.ABMGrado();
            this.Hide();
            fr.ShowDialog();
            this.Show();
        }

        private void aBMUsuarioToolStripMenuItem_Click(object sender, EventArgs e)
        {
            ABMUsuario fr = new ABMUsuario();
            this.Hide();
            fr.ShowDialog();
            this.Show();
        }

        private void generarComisiónToolStripMenuItem_Click(object sender, EventArgs e)
        {
            FormGenerarRendicion fr = new FormGenerarRendicion(this);
            this.Hide();
            if (!fr.IsDisposed)
            fr.ShowDialog();
            this.Show();
        }

        private void cambiarPasswordToolStripMenuItem_Click(object sender, EventArgs e)
        {
            CambiarPass fr = new CambiarPass(this.usuario,false);
            this.Hide();
            if (!fr.IsDisposed)
                fr.ShowDialog();
            this.Show();
        }

        private void ContenedorPrincipal_Load(object sender, EventArgs e)
        {
            //Cambiar pass
            if (this.primerInicio)
            {
                MessageBox.Show("Debe modificar su password");
                CambiarPass fr = new CambiarPass(this.usuario, this.primerInicio);
                this.Hide();
                if (!fr.IsDisposed)
                    fr.ShowDialog();
                this.Show();
            }
            this.primerInicio = false;
        }

    }
}
