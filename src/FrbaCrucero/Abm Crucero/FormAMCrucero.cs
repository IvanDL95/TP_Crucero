using FrbaCrucero.ABMCrucero;
using MiLibreria;
using MiLibreria.Modelo;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Data.SqlClient;
using System.Drawing;
using System.Globalization;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace FrbaCrucero.ABMCrucero
{
    public partial class FormAmCrucero : Form
    {
        String IDCrucero;
        Crucero cruceroModificado = new Crucero();
        int cantCabinas = 0;
        public FormAmCrucero(String IDCrucero, FormCrucero fr)
        {
            InitializeComponent();
            this.IDCrucero = IDCrucero;
            dgv_cabinas.EditingControlShowing += dgv_cabinas_EditingControlShowing;
            dgv_cabinas.CellValidating += dgv_cabinas_CellValidating;
            dgv_cabinas.CellEndEdit += dgv_cabinas_CellEndEdit;
            //Cargar Tser de BD
            CargarComboServicio();
            //Cargar Fabricante de BD
            CargarComboFabricante();

            if (!String.IsNullOrEmpty(IDCrucero))
            {
                //Modificar
                Crucero crucero = new Crucero();

                //Obtener Crucero
                SqlDataReader reader = CruceroFunc.ObtenerCrucero(IDCrucero);

                crucero = CruceroFunc.ObtenerCruceroDesdeUnReader(reader);

                
                //Llenar textos
                txt_id.Text = crucero.id.Trim();
                txt_modelo.Text = crucero.mod.Trim();
                cmb_fabricante.SelectedIndex = crucero.fab_id - 1;
                cmb_servicio.SelectedIndex = crucero.tser_id - 1;


                DataTable cabinacrucero = Cabina_crucerofunc.ObtenerCabinaCrucero(this.IDCrucero);

                //Se carga combo Tipo Cabina de la fila
                CargarComboTipoCabina();

                this.cantCabinas = cabinacrucero.Rows.Count;
                //Se agragan las filas necesarias          
                for (Int32 j = 0; j < cabinacrucero.Rows.Count; j++)
                {
                    DataGridViewRow rowCab = (DataGridViewRow)dgv_cabinas.Rows[0].Clone();
                    dgv_cabinas.Rows.Add(rowCab);
                }


                    //Se agregan los datos en las filas
                for (Int32 i = 0; i < cabinacrucero.Rows.Count; i++)
                {
                    dgv_cabinas.Rows[i].Cells[0].Value = cabinacrucero.Rows[i]["cc_piso"].ToString();
                    dgv_cabinas.Rows[i].Cells[1].Value = cabinacrucero.Rows[i]["cc_nro"].ToString().Trim();
                    SqlDataReader readerTipo = Cabina_crucerofunc.ObtenerDescTipo(Convert.ToInt32(cabinacrucero.Rows[i]["cc_tcab_id"]));
                    if (readerTipo.HasRows)
                    {
                        while (readerTipo.Read())
                        {
                            dgv_cabinas.Rows[i].Cells[2].Value = readerTipo.GetString(0);
                        }
                    }
                }
               
                this.cruceroModificado.id = crucero.id.Trim();
                this.cruceroModificado.mod = crucero.mod.Trim();
                this.cruceroModificado.tser_id = crucero.tser_id;
                this.cruceroModificado.fab_id = crucero.fab_id;

                //Dejar identificación como grisado
                txt_id.ReadOnly = true;
            }
            else
                CargarComboTipoCabina();

        }

        private void CargarComboTipoCabina()
        {
            SqlDataReader reader = Cabina_crucerofunc.ObtenerTipos();
            DataGridViewComboBoxColumn comboTipo = (DataGridViewComboBoxColumn)dgv_cabinas.Columns["colTipoCabina"];
            if (reader.HasRows)
            {
                while (reader.Read())
                {
                    //Se cargan los Tipos Cabina de la fila 
                    comboTipo.Items.Add(reader.GetString(1));
                }
                DataGridViewComboBoxCell celltipo = (DataGridViewComboBoxCell)(dgv_cabinas.Rows[0].Cells[2]);
                celltipo.Value = comboTipo.Items[0];
            }
            reader.Close();
        }


        private void btAceptar_Click(object sender, EventArgs e)
        {
            ejecutar();
        }

        private void btCancelar_Click(object sender, EventArgs e)
        {
            this.Close();
        }


        private void CargarComboServicio()
        {
            SqlDataReader reader = TipoServicioFunc.ObtenerTipoServicio();

            if (reader.HasRows)
            {
                while (reader.Read())
                {
                    Tipo_Servicio tipo = new Tipo_Servicio();
                    tipo.id = Convert.ToInt32(reader.GetDecimal(0));
                    tipo.desc = reader.GetString(1);
                    ComboboxItem item = new ComboboxItem();
                    item.Text = tipo.desc;
                    item.Value = tipo;
                    cmb_servicio.Items.Add(item);
                }
            }
            reader.Close();
        }

        private void CargarComboFabricante()
        {
            SqlDataReader reader = FabricanteFunc.ObtenerFabricante();

            if (reader.HasRows)
            {
                while (reader.Read())
                {
                    Fabricante fabricante = new Fabricante();
                    fabricante.id = Convert.ToInt32(reader.GetDecimal(0));
                    fabricante.desc = reader.GetString(1);
                    ComboboxItem item = new ComboboxItem();
                    item.Text = fabricante.desc;
                    item.Value = fabricante;
                    cmb_fabricante.Items.Add(item);
                }
            }
            reader.Close();
        }


        private void ValidacionesIniciales()
        {
            txt_modelo.MaxLength = 50;
            txt_id.MaxLength = 30;
        }

        private void dgv_cabinas_EditingControlShowing(object sender, DataGridViewEditingControlShowingEventArgs e)
        {
            //e.Control.KeyPress -= new KeyPressEventHandler(Column1_KeyPress);
            e.Control.KeyPress -= new KeyPressEventHandler(Column2_KeyPress);
            e.Control.KeyPress -= new KeyPressEventHandler(Column3_KeyPress);
            if (dgv_cabinas.CurrentCell.ColumnIndex == 0)
            {
                TextBox tb = e.Control as TextBox;
                if (tb != null)
                {
                    tb.MaxLength = 5;
                    //tb.CharacterCasing = CharacterCasing.Upper; 
                    tb.KeyPress += new KeyPressEventHandler(Column2_KeyPress);
                }
            }
            if (dgv_cabinas.CurrentCell.ColumnIndex == 1)
            {
                TextBox tb = e.Control as TextBox;
                if (tb != null)
                {
                    tb.MaxLength = 5;
                    tb.KeyPress += new KeyPressEventHandler(Column3_KeyPress);
                }
            }
            /*if (dgv_cabinas.CurrentCell.ColumnIndex == 2)
            {
                TextBox tb = e.Control as TextBox;
                if (tb != null)
                {
                    tb.MaxLength = 10;
                    tb.KeyPress += new KeyPressEventHandler(Column1_KeyPress);                             
                }
            }*/
        }

        private void Column1_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (!char.IsControl(e.KeyChar) && !char.IsDigit(e.KeyChar) && e.KeyChar != '.')
            {
                e.Handled = true;
            }
        }

        private void Column2_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (!char.IsControl(e.KeyChar) && !char.IsDigit(e.KeyChar))
            {
                e.Handled = true;
            }
        }

        private void Column3_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (!char.IsControl(e.KeyChar) && !char.IsDigit(e.KeyChar))
            {
                e.Handled = true;
            }
        }

        private void dgv_cabinas_CellValidating(object sender, DataGridViewCellValidatingEventArgs e)
        {
            string columnName = this.dgv_cabinas.Columns[e.ColumnIndex].Name;


                if (columnName.Equals("colPiso"))
                {
                    // Check if the input is empty
                    if (string.IsNullOrEmpty(e.FormattedValue.ToString()))
                    {
                        this.dgv_cabinas.Rows[e.RowIndex].ErrorText = "La columna Piso está vacía";
                        e.Cancel = true;
                    }
                }
                if (columnName.Equals("colNumero"))
                {
                    // Check if the input is empty
                    if (string.IsNullOrEmpty(e.FormattedValue.ToString()))
                    {
                        this.dgv_cabinas.Rows[e.RowIndex].ErrorText = "La columna Cantidad está vacía";
                        e.Cancel = true;
                    }
                }
        }

        private void dgv_cabinas_CellEndEdit(object sender, DataGridViewCellEventArgs e)
        {
            this.dgv_cabinas.Rows[e.RowIndex].ErrorText = string.Empty;
        }

        private void dgv_fecha_Column1_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (!char.IsControl(e.KeyChar) && !char.IsLetter(e.KeyChar))
            {
                e.Handled = true;
            }
        }

        private void dgv_fecha_Column2_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (!char.IsControl(e.KeyChar) && !char.IsDigit(e.KeyChar) && e.KeyChar != ':')
            {
                e.Handled = true;
            }
        }

        private void dgv_ubicacion_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            
        }


        private void ejecutar()
        {
            RegexUtilities util = new RegexUtilities();
            if (ValidarCamposVacios())
                MessageBox.Show("Debe completar todos los campos");
            else if (ValidarTipoCabinaVacio())
            {
            }
            else if (ValidaPisoNumeroTipo())
                MessageBox.Show("Piso, numero y tipo de cabina repetido");
            else
            {
                if (String.IsNullOrEmpty(this.IDCrucero))
                {
                    //Validar ID
                    if (!CruceroFunc.EsValidoIdCrucero(this.txt_id.Text.Trim()))
                    {
                        MessageBox.Show("La identificación ya existe");
                    }
                    else
                    {
                        //Crear crucero
                        Crucero crucero = new Crucero();
                        Tipo_Servicio tser = new Tipo_Servicio();
                        Fabricante fab = new Fabricante();
                        ComboboxItem item = new ComboboxItem();
                        item = (ComboboxItem)cmb_fabricante.SelectedItem;
                        fab = (Fabricante)item.Value;
                        crucero.fab_id = fab.id;
                        item = (ComboboxItem)cmb_servicio.SelectedItem;
                        tser = (Tipo_Servicio)item.Value;
                        crucero.tser_id = tser.id;
                        crucero.mod = txt_modelo.Text.Trim();
                        crucero.id = txt_id.Text.Trim();
                        CruceroFunc.CrearCrucero(crucero);

                        for (int l = 0; l < this.dgv_cabinas.Rows.Count - 1; l++)
                        {
                            Cabinas_Crucero cabinaCrucero = new Cabinas_Crucero();
                            cabinaCrucero.cru_id = txt_id.Text.Trim();
                            cabinaCrucero.piso = Convert.ToInt32(dgv_cabinas.Rows[l].Cells["colPiso"].Value);
                            cabinaCrucero.numero = Convert.ToInt32(dgv_cabinas.Rows[l].Cells["colNumero"].Value);
                            cabinaCrucero.tcab_id = Cabina_crucerofunc.ObtenerIDTipo(Convert.ToString(dgv_cabinas.Rows[l].Cells["colTipoCabina"].Value));
                            Cabina_crucerofunc.CrearCabinaCrucero(cabinaCrucero);
                        }

                        MessageBox.Show("Crucero creado");
                        this.Close();
                    }
                }
                else
                {
                    //Modificar crucero
                    Crucero crucero = new Crucero();
                    Tipo_Servicio tser = new Tipo_Servicio();
                    Fabricante fab = new Fabricante();
                    ComboboxItem item = new ComboboxItem();
                    item = (ComboboxItem)cmb_fabricante.SelectedItem;
                    fab = (Fabricante)item.Value;
                    crucero.fab_id = fab.id;                                       
                    item = (ComboboxItem)cmb_servicio.SelectedItem;
                    tser = (Tipo_Servicio)item.Value;
                    crucero.tser_id = tser.id;
                    crucero.mod = txt_modelo.Text.Trim();
                    crucero.id = txt_id.Text.Trim();

                    CruceroFunc.ModificarCrucero(crucero);

                    //Cabinas del crucero
                    for (int l = 0; l < this.cantCabinas; l++)
                    {
                        Cabinas_Crucero cabinaCrucero = new Cabinas_Crucero();
                        cabinaCrucero.cru_id = txt_id.Text.Trim();
                        cabinaCrucero.piso = Convert.ToInt32(dgv_cabinas.Rows[l].Cells["colPiso"].Value);
                        cabinaCrucero.numero = Convert.ToInt32(dgv_cabinas.Rows[l].Cells["colNumero"].Value);
                        cabinaCrucero.tcab_id = Cabina_crucerofunc.ObtenerIDTipo(Convert.ToString(dgv_cabinas.Rows[l].Cells["colTipoCabina"].Value));
                        cabinaCrucero.id = Convert.ToInt32(dgv_cabinas.Rows[l].Cells["ColId"].Value);
                        Cabina_crucerofunc.ModificarCabinaCrucero(cabinaCrucero);

                    }
                    for (int l2 = this.cantCabinas; l2 < this.dgv_cabinas.Rows.Count - 1; l2++)
                    {
                        Cabinas_Crucero cabinaCrucero = new Cabinas_Crucero();
                        cabinaCrucero.cru_id = txt_id.Text.Trim();
                        cabinaCrucero.piso = Convert.ToInt32(dgv_cabinas.Rows[l2].Cells["colPiso"].Value);
                        cabinaCrucero.numero = Convert.ToInt32(dgv_cabinas.Rows[l2].Cells["colNumero"].Value);
                        cabinaCrucero.tcab_id = Cabina_crucerofunc.ObtenerIDTipo(Convert.ToString(dgv_cabinas.Rows[l2].Cells["colTipoCabina"].Value));
                        Cabina_crucerofunc.ModificarCabinaCrucero(cabinaCrucero);
                    }

                    MessageBox.Show("Crucero modificado");
                    this.Close();
                }
            }
        }

        private bool ValidarTipoCabinaVacio()
        {

            if (dgv_cabinas.Rows.Count < 2)
            {
                MessageBox.Show("Debe agregar al menos una cantidad de cabinas");
                return true;
            }
            else
            {
                for (int j = 0; j < this.dgv_cabinas.Rows.Count - 1; j++)
                {
                    if (string.IsNullOrEmpty(Convert.ToString(dgv_cabinas.Rows[j].Cells["colPiso"].Value))
                        || string.IsNullOrEmpty(Convert.ToString(dgv_cabinas.Rows[j].Cells["colNumero"].Value))
                        || string.IsNullOrEmpty(Convert.ToString(dgv_cabinas.Rows[j].Cells["colTipoCabina"].Value)))
                    {
                        MessageBox.Show("Debe completar todos los campos de la cantidad de cabinas");
                        return true;
                    }
                }
                

            }
            return false;
        }

        private bool ValidarCamposVacios()
        {
            if (string.IsNullOrEmpty(cmb_servicio.Text) || string.IsNullOrEmpty(cmb_fabricante.Text) || txt_id.Text == "" || txt_modelo.Text == "")
                return true;
            return false;
        }



        private bool ValidaPisoNumeroTipo()
        {
            //Busca Piso y Tipo repetido

            for (int j = 0; j < this.dgv_cabinas.Rows.Count - 1; j++)
            {
                String piso;
                String numero;
                String tipo;
                piso = Convert.ToString(dgv_cabinas.Rows[j].Cells["colPiso"].Value);
                numero = Convert.ToString(dgv_cabinas.Rows[j].Cells["colNumero"].Value);
                tipo = Convert.ToString(dgv_cabinas.Rows[j].Cells["colTipoCabina"].Value);
                if (buscarPisoNumeroTipo(piso, numero, tipo, j))
                    return true;
            }
            
            return false;
        }

        //Busca Piso y Tipo repetido
        private bool buscarPisoNumeroTipo(String piso,String numero, String tipo, int numFila)
        {
            for (int j = 0; j < this.dgv_cabinas.Rows.Count - 1; j++)
            {
                if (j != numFila)
                {
                    String pisoBusca;
                    String numeroBusca;
                    String tipoBusca;
                    pisoBusca = Convert.ToString(dgv_cabinas.Rows[j].Cells["colPiso"].Value);
                    numeroBusca = Convert.ToString(dgv_cabinas.Rows[j].Cells["colNumero"].Value);
                    tipoBusca = Convert.ToString(dgv_cabinas.Rows[j].Cells["colTipoCabina"].Value);
                    if (String.Equals(piso, pisoBusca) && String.Equals(numero, numeroBusca) && String.Equals(tipo, tipoBusca))
                    {                  
                        return true;
                    }
                }
            }
            return false;
        }

    }

}
