using FrbaCrucero.AbmRecorrido;
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

namespace FrbaCrucero.ABMRecorrido
{
    public partial class FormAmRecorrido : Form
    {
        int IDRecorrido;
        Recorrido recorridoModificado = new Recorrido();
        int cantTramos = 0;
        public FormAmRecorrido(int IDRecorrido, FormRecorrido fr)
        {
            InitializeComponent();
            this.IDRecorrido = IDRecorrido;
            dgv_tramos.EditingControlShowing += dgv_tramos_EditingControlShowing;
            dgv_tramos.CellValidating += dgv_tramos_CellValidating;
            dgv_tramos.CellEndEdit += dgv_tramos_CellEndEdit;
            dgv_tramos.AllowUserToAddRows = false;

            txt_id.ReadOnly = true;
            dgv_tramos.Columns["colId"].Visible = false;

            if (IDRecorrido != 0)
            {
                //Modificar
                Recorrido recorrido = new Recorrido();

                //Obtener recorrido
                SqlDataReader reader = RecorridoFunc.ObtenerRecorrido(IDRecorrido);

                recorrido = RecorridoFunc.ObtenerRecorridoDesdeUnReader(reader);


                //Llenar textos
                txt_id.Text = recorrido.rec_id.ToString();
                //cmb_puertoDestino.SelectedIndex = cmb_puertoDestino.SelectedIndex.Equals(recorrido.rec_pue_desde);
                //cmb_puertoSalida.SelectedIndex = PuertoFunc.ObtenerNombre(recorrido.rec_pue_hasta);


                DataTable tramo = TramoFunc.ObtenerTramos(this.IDRecorrido);

                //Se carga combo Tipo Cabina de la fila
                dgv_tramos.Rows.Add();
                CargarComboPuertoSalida();
                CargarComboPuertoDestino();

                this.cantTramos = tramo.Rows.Count;
                //Se agragan las filas necesarias          
                for (Int32 j = 0; j < this.cantTramos; j++)
                {
                    DataGridViewRow rowTram = (DataGridViewRow)dgv_tramos.Rows[0].Clone();
                    dgv_tramos.Rows.Add(rowTram);
                }

                Queue<Tramo> tramosList = new Queue<Tramo>();
                //Se agregan los datos en las filas
                for (Int32 i = 0; i < this.cantTramos; i++)
                {
                    Tramo nuevo_tram = new Tramo();
                    //dgv_tramos.Rows[i].Cells[0].Text =  i.ToString();
                    nuevo_tram.id = Convert.ToInt32(tramo.Rows[i]["tra_id"]);
                    nuevo_tram.salida = tramo.Rows[i]["tra_desde"].ToString().Trim();
                    nuevo_tram.destino = tramo.Rows[i]["tra_hasta"].ToString().Trim();
                    nuevo_tram.precio = Convert.ToDecimal(tramo.Rows[i]["tra_precio_base"]);
                    if (tramosList.Count != 0)
                    {
                        Tramo tramo_anterior = tramosList.Peek();
                        if (!String.Equals(tramo_anterior.destino, nuevo_tram.salida))
                        {
                            tramo_anterior = tramosList.Dequeue();
                            tramosList.Enqueue(nuevo_tram);
                            tramosList.Enqueue(tramo_anterior);
                        }
                    }
                    tramosList.Enqueue(nuevo_tram);
                }

                for (int j = 0; j < this.cantTramos; j++)
                {
                    Tramo nue_tramo = tramosList.Dequeue();
                    dgv_tramos.Rows[j].Cells["colId"].Value = nue_tramo.id.ToString();
                    dgv_tramos.Rows[j].Cells[0].Value = nue_tramo.salida.ToString().Trim();
                    dgv_tramos.Rows[j].Cells[1].Value = nue_tramo.destino.ToString().Trim();
                    dgv_tramos.Rows[j].Cells[2].Value = nue_tramo.precio.ToString();
                }

                this.recorridoModificado.rec_id = recorrido.rec_id;
                this.recorridoModificado.rec_pue_id_desde = recorrido.rec_pue_id_desde;
                this.recorridoModificado.rec_pue_id_hasta = recorrido.rec_pue_id_hasta;
                this.recorridoModificado.rec_estado = recorrido.rec_estado;

                //Dejar identificación como grisado
                DataTable pue_desde, pue_hasta;
                pue_desde = PuertoFunc.ObtenerPuerto((int)recorrido.rec_pue_id_desde);
                pue_hasta = PuertoFunc.ObtenerPuerto((int)recorrido.rec_pue_id_hasta);

                dgv_tramos.Rows.RemoveAt(this.cantTramos);

                numericTextBox1.Text = pue_desde.Rows[0]["pue_nombre"].ToString();
                numericTextBox1.ReadOnly = true;
                numericTextBox2.Text = pue_hasta.Rows[0]["pue_nombre"].ToString();
                numericTextBox2.ReadOnly = true;
                txt_id.ReadOnly = true;
            }
            else
            {
                txt_id.Text = "000000000";
                numericTextBox1.ReadOnly = true;
                numericTextBox2.ReadOnly = true;
                txt_id.ReadOnly = true;
                dgv_tramos.Rows.Add();
                //Cargar Puerto Desde
                CargarComboPuertoSalida();
                //Cargar Puerto Hasta
                CargarComboPuertoDestino();
            }
        }


        private void btAceptar_Click(object sender, EventArgs e)
        {
            ejecutar();
        }

        private void btEliminar_Click(object sender, EventArgs e)
        {
            //this.borrarTramo();
        }

        private void btCancelar_Click(object sender, EventArgs e)
        {
           // ejecutar("Publicada");
            this.Close();
        }


        private void CargarComboPuertoSalida()
        {
            SqlDataReader reader = PuertoFunc.ObtenerPuerto();

            if (reader.HasRows)
            {
                while (reader.Read())
                {
                    Puerto puerto = new Puerto();
                    puerto.id = Convert.ToInt32(reader.GetDecimal(0));
                    puerto.nombre = reader.GetString(1);
                    puerto.estado = reader.GetBoolean(2);
                    ComboboxItem item = new ComboboxItem();
                    item.Text = puerto.nombre;
                    item.Value = puerto;
                    cmb_puertoSalida.Items.Add(item);
                }
            }
            reader.Close();
        }

        private void CargarComboPuertoDestino()
        {
            SqlDataReader reader = PuertoFunc.ObtenerPuerto();

            if (reader.HasRows)
            {
                while (reader.Read())
                {
                    Puerto puerto = new Puerto();
                    puerto.id = Convert.ToInt32(reader.GetDecimal(0));
                    puerto.nombre = reader.GetString(1);
                    puerto.estado = reader.GetBoolean(2);
                    ComboboxItem item = new ComboboxItem();
                    item.Text = puerto.nombre;
                    item.Value = puerto;
                    cmb_puertoDestino.Items.Add(item);
                }
            }
            reader.Close();
        }


        private void ValidacionesIniciales()
        {
            //txt_modelo.MaxLength = 50;
            txt_id.MaxLength = 30;
        }

        private void dgv_tramos_EditingControlShowing(object sender, DataGridViewEditingControlShowingEventArgs e)
        {
            //e.Control.KeyPress -= new KeyPressEventHandler(Column1_KeyPress);
            e.Control.KeyPress -= new KeyPressEventHandler(Column2_KeyPress);
            e.Control.KeyPress -= new KeyPressEventHandler(Column3_KeyPress);
            if (dgv_tramos.CurrentCell.ColumnIndex == 0)
            {
                TextBox tb = e.Control as TextBox;
                if (tb != null)
                {
                    tb.MaxLength = 5;
                    //tb.CharacterCasing = CharacterCasing.Upper; 
                    tb.KeyPress += new KeyPressEventHandler(Column2_KeyPress);
                }
            }
            if (dgv_tramos.CurrentCell.ColumnIndex == 1)
            {
                TextBox tb = e.Control as TextBox;
                if (tb != null)
                {
                    tb.MaxLength = 5;
                    tb.KeyPress += new KeyPressEventHandler(Column3_KeyPress);
                }
            }
            /*if (dgv_tramos.CurrentCell.ColumnIndex == 2)
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

        private void dgv_tramos_CellValidating(object sender, DataGridViewCellValidatingEventArgs e)
        {
            string columnName = this.dgv_tramos.Columns[e.ColumnIndex].Name;


                if (columnName.Equals("colPiso"))
                {
                    // Check if the input is empty
                    if (string.IsNullOrEmpty(e.FormattedValue.ToString()))
                    {
                        this.dgv_tramos.Rows[e.RowIndex].ErrorText = "La columna Piso está vacía";
                        e.Cancel = true;
                    }
                }
                if (columnName.Equals("colCantidad"))
                {
                    // Check if the input is empty
                    if (string.IsNullOrEmpty(e.FormattedValue.ToString()))
                    {
                        this.dgv_tramos.Rows[e.RowIndex].ErrorText = "La columna Cantidad está vacía";
                        e.Cancel = true;
                    }
                }
        }

        private void dgv_tramos_CellEndEdit(object sender, DataGridViewCellEventArgs e)
        {
            this.dgv_tramos.Rows[e.RowIndex].ErrorText = string.Empty;
        }

        /*private void dgv_fecha_EditingControlShowing(object sender, DataGridViewEditingControlShowingEventArgs e)
        {
            e.Control.KeyPress -= new KeyPressEventHandler(dgv_fecha_Column1_KeyPress);
            e.Control.KeyPress -= new KeyPressEventHandler(dgv_fecha_Column2_KeyPress);
            if (dgv_fecha.CurrentCell.ColumnIndex == 0)
            {
                TextBox tb = e.Control as TextBox;
                if (tb != null)
                {
                    tb.MaxLength = 10;
                    tb.KeyPress += new KeyPressEventHandler(dgv_fecha_Column1_KeyPress);
                }
            }
            if (dgv_fecha.CurrentCell.ColumnIndex == 1)
            {
                TextBox tb = e.Control as TextBox;
                if (tb != null)
                {
                    tb.MaxLength = 5;
                    tb.KeyPress += new KeyPressEventHandler(dgv_fecha_Column2_KeyPress);
                }
            }
        }*/

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

        /*private void dgv_fecha_CellValidating(object sender, DataGridViewCellValidatingEventArgs e)
        {
            string columnName = this.dgv_fecha.Columns[e.ColumnIndex].Name;


            if (columnName.Equals("colFecha"))
            {
                // Check if the input is empty
                if (string.IsNullOrEmpty(e.FormattedValue.ToString()))
                {
                    this.dgv_fecha.Rows[e.RowIndex].ErrorText = "La columna Fecha está vacía";
                    e.Cancel = true;
                }
                else
                {
                    // Check if the input format is correct
                    Regex datePattern = new Regex("^[0-9]{2}([/][0-9]{2}([/][0-9]{4}))?$");
                    if (!datePattern.IsMatch(e.FormattedValue.ToString()))
                    {
                        this.dgv_fecha.Rows[e.RowIndex].ErrorText = "Formato incorrecto: \"DD/MM/AAAA\"";
                        e.Cancel = true;
                    }
                }
            }

            // Check for the column to validate
            if (columnName.Equals("colHora"))
            {
                // Check if the input is empty
                if (string.IsNullOrEmpty(e.FormattedValue.ToString()))
                {
                    this.dgv_fecha.Rows[e.RowIndex].ErrorText = "La columna Hora está vacía";
                    e.Cancel = true;
                }
                else
                {
                    // Check if the input format is correct
                    Regex datePattern = new Regex("^[0-9]{2}([:][0-9]{2})?$");
                    if (!datePattern.IsMatch(e.FormattedValue.ToString()))
                    {
                        this.dgv_fecha.Rows[e.RowIndex].ErrorText = "Formato incorrecto: \"HH:MM\"";
                        e.Cancel = true;
                    }
                }
            }
        }*/

        /*private void dgv_fecha_CellEndEdit(object sender, DataGridViewCellEventArgs e)
        {
            this.dgv_fecha.Rows[e.RowIndex].ErrorText = string.Empty;
        }*/


        /*private void dgv_ubicacion_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            
        }*/


        private void ejecutar()
        {
            RegexUtilities util = new RegexUtilities();
            if (ValidarCamposVacios())
                MessageBox.Show("Debe completar todos los campos");
            else if (false) //ValidarTipoUbicacionVacio()
            {
            }
            else if (false) //ValidaPisoTipo()
                MessageBox.Show("Piso y tipo de cabina repetido");
            else
            {
                if ((this.IDRecorrido == null || this.IDRecorrido == 0))
                {
                    //Validar ID
                    if (false)
                    {
                        MessageBox.Show("La identificación ya existe");
                    }
                    else
                    {
                        //Crear recorrido
                        Recorrido recorrido = new Recorrido();
                        List<Tramo> parametros = new List<Tramo>();
                        ComboboxItem item = new ComboboxItem();
                        item = (ComboboxItem)cmb_puertoSalida.SelectedItem;
                        Puerto pue_salida = (Puerto)item.Value;
                        recorrido.rec_pue_id_desde = pue_salida.id;
                        item = (ComboboxItem)cmb_puertoDestino.SelectedItem;
                        Puerto pue_destino = (Puerto)item.Value;
                        recorrido.rec_pue_id_hasta = pue_destino.id;
                        RecorridoFunc.CrearRecorrido(recorrido);

                        for (int l = 0; l < this.dgv_tramos.Rows.Count - 1; l++)
                        {
                            Tramo tramo = new Tramo();
                            tramo.id = Convert.ToInt32(dgv_tramos.Rows[3].Cells["tra_id"].Value);
                            tramo.salida = Convert.ToInt32(dgv_tramos.Rows[0].Cells["tra_desde"].Value);
                            tramo.destino = Convert.ToInt32(dgv_tramos.Rows[l].Cells["tra_hasta"].Value);
                            tramo.precio = Convert.ToInt32(dgv_tramos.Rows[2].Cells["tra_precio_base"].Value);
                            parametros.Add(tramo);
                            RecorridoFunc.InsertarRecorridoTramo(recorrido.rec_id, parametros);
                        }

                        MessageBox.Show("Recorrido creado");
                        this.Close();
                    }
                }
                else
                {
                    //Modificar crucero
                    Recorrido recorrido = new Recorrido();
                    List<Tramo> tramosList = new List<Tramo>();
                    ComboboxItem item = new ComboboxItem();
                    item = (ComboboxItem)cmb_puertoSalida.SelectedItem;
                    Puerto pue_salida = (Puerto)item.Value;
                    recorrido.rec_pue_id_desde = pue_salida.id;
                    item = (ComboboxItem)cmb_puertoDestino.SelectedItem;
                    Puerto pue_destino = (Puerto)item.Value;
                    recorrido.rec_pue_id_hasta = pue_destino.id;
                    recorrido.rec_estado = true;
                    RecorridoFunc.ModificarRecorrido(recorrido);
                    //Tramos del Recorrido
                    Int32 length = tramosList.Count;

                    for (int l = 0; l < length; l++)
                    {
                        Tramo tramo = new Tramo();
                        tramo.id = Convert.ToInt32(dgv_tramos.Rows[3].Cells["tra_id"].Value);
                        tramo.salida = Convert.ToInt32(dgv_tramos.Rows[0].Cells["tra_desde"].Value);
                        tramo.destino = Convert.ToInt32(dgv_tramos.Rows[l].Cells["tra_hasta"].Value);
                        tramo.precio = Convert.ToInt32(dgv_tramos.Rows[2].Cells["tra_precio_base"].Value);
                        tramosList.Add(tramo);
                        RecorridoFunc.ModificarRecorridoTramo(recorrido.rec_id, tramosList);

                    }
                    for (int l2 = length; l2 < this.dgv_tramos.Rows.Count - 1; l2++)
                    {
                        Tramo tramo = new Tramo();
                        tramo.id = Convert.ToInt32(dgv_tramos.Rows[3].Cells["tra_id"].Value);
                        tramo.salida = Convert.ToInt32(dgv_tramos.Rows[0].Cells["tra_desde"].Value);
                        tramo.destino = Convert.ToInt32(dgv_tramos.Rows[1].Cells["tra_hasta"].Value);
                        tramo.precio = Convert.ToInt32(dgv_tramos.Rows[2].Cells["tra_precio_base"].Value);
                        tramosList.Add(tramo);
                        RecorridoFunc.ModificarRecorridoTramo(recorrido.rec_id, tramosList);
                    }

                    MessageBox.Show("Recorrido modificado");
                    this.Close();
                }
            }
        }

        private bool ValidarTipoUbicacionVacio()
        {

            if (dgv_tramos.Rows.Count < 2)
            {
                MessageBox.Show("Debe agregar al menos una cantidad de cabinas");
                return true;
            }
            else
            {
                for (int j = 0; j < this.dgv_tramos.Rows.Count - 1; j++)
                {
                    if (string.IsNullOrEmpty(Convert.ToString(dgv_tramos.Rows[j].Cells["colPiso"].Value))
                        || string.IsNullOrEmpty(Convert.ToString(dgv_tramos.Rows[j].Cells["colCantidad"].Value))
                        || string.IsNullOrEmpty(Convert.ToString(dgv_tramos.Rows[j].Cells["colTipoCabina"].Value)))
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
            if (string.IsNullOrEmpty(cmb_puertoSalida.Text) || string.IsNullOrEmpty(cmb_puertoDestino.Text))
                return true;
            return false;
        }



        private bool ValidaPisoTipo()
        {
            //Busca Piso y Tipo repetido

            for (int j = 0; j < this.dgv_tramos.Rows.Count - 1; j++)
            {
                String piso;
                String tipo;
                piso = Convert.ToString(dgv_tramos.Rows[j].Cells["colPiso"].Value);
                tipo = Convert.ToString(dgv_tramos.Rows[j].Cells["colTipoCabina"].Value);
                if (buscarPisoTipo(piso, tipo, j))
                    return true;
            }
            
            return false;
        }

        //Busca Piso y Tipo repetido
        private bool buscarPisoTipo(String piso, String tipo, int numFila)
        {
            for (int j = 0; j < this.dgv_tramos.Rows.Count - 1; j++)
            {
                if (j != numFila)
                {
                    String pisoBusca;
                    String tipoBusca;
                    pisoBusca = Convert.ToString(dgv_tramos.Rows[j].Cells["colPiso"].Value);
                    tipoBusca = Convert.ToString(dgv_tramos.Rows[j].Cells["colTipoUbicacion"].Value);
                    if (String.Equals(piso, pisoBusca) && String.Equals(tipo, tipoBusca))
                    {                  
                        return true;
                    }
                }
            }
            return false;
        }

        private void label1_Click(object sender, EventArgs e)
        {

        }

        private void cmb_puertoSalida_SelectedIndexChanged(object sender, EventArgs e)
        {

        }

        private void cmb_puertoDestino_SelectedIndexChanged(object sender, EventArgs e)
        {

        }

        private void FormAmRecorrido_Load(object sender, EventArgs e)
        {

        }

        private void txt_id_TextChanged(object sender, EventArgs e)
        {

        }




    }

}
