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
        String IDRecorrido;
        bool esModificar;
        Recorrido recorridoModificado = new Recorrido();
        Queue<Tramo> recorridoTramos = new Queue<Tramo>();
        int cantTramos = 0;
        public FormAmRecorrido(String IDRecorrido, FormRecorrido fr)
        {
            InitializeComponent();
            this.IDRecorrido = IDRecorrido;
            dgv_tramos.EditingControlShowing += dgv_tramos_EditingControlShowing;
            dgv_tramos.CellValidating += dgv_tramos_CellValidating;
            dgv_tramos.CellEndEdit += dgv_tramos_CellEndEdit;
            dgv_tramos.AllowUserToAddRows = false;

            txt_id.ReadOnly = true;
            dgv_tramos.Columns["colId"].Visible = false;

            if (!String.IsNullOrEmpty(IDRecorrido))
            {
                this.esModificar = true;
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
                Tramo tramo_inicial = new Tramo();
                int cont;
                for (cont = 0; true; cont++)
                {
                    tramo_inicial.salida = tramo.Rows[cont]["tra_desde"].ToString().Trim();
                    tramo_inicial.salida_id = Convert.ToInt32(PuertoFunc.ObtenerPuerto(tramo_inicial.salida).Rows[0]["pue_id"]);
                    if (tramo_inicial.salida_id == recorrido.rec_pue_id_desde)
                    {
                        tramo_inicial.id = Convert.ToInt32(tramo.Rows[cont]["tra_id"]);
                        tramo_inicial.destino = tramo.Rows[cont]["tra_hasta"].ToString().Trim();
                        tramo_inicial.precio = Convert.ToDecimal(tramo.Rows[cont]["tra_precio_base"]);
                        tramosList.Enqueue(tramo_inicial);
                        break;
                    }
                }

                for (int i = 0; i < this.cantTramos; i++)
                {
                    if (i == cont)
                        continue;

                    Tramo nuevo_tram = new Tramo();
                    //dgv_tramos.Rows[i].Cells[0].Text =  i.ToString();
                    nuevo_tram.id = Convert.ToInt32(tramo.Rows[i]["tra_id"]);
                    nuevo_tram.salida = tramo.Rows[i]["tra_desde"].ToString().Trim();
                    nuevo_tram.destino = tramo.Rows[i]["tra_hasta"].ToString().Trim();
                    nuevo_tram.precio = Convert.ToDecimal(tramo.Rows[i]["tra_precio_base"]);
                    tramosList.Enqueue(nuevo_tram);

                    /*
                    if (tramosList.Count > 1)
                    {
                        Tramo tramo_anterior = tramosList.Peek();
                        if (!String.Equals(tramo_anterior.destino, nuevo_tram.salida) && tramo_inicial.id != tramo_anterior.id)
                        {
                            tramo_anterior = tramosList.Dequeue();
                            tramosList.Enqueue(nuevo_tram);
                            tramosList.Enqueue(tramo_anterior);
                        }
                        else
                            tramosList.Enqueue(nuevo_tram);
                    }
                    else
                        tramosList.Enqueue(nuevo_tram);
                    */
                }

                //this.recorridoTramos = tramosList;

                Tramo primer_tramo = tramosList.Dequeue();
                dgv_tramos.Rows[0].Cells["colId"].Value = primer_tramo.id.ToString();
                dgv_tramos.Rows[0].Cells[0].Value = primer_tramo.salida.ToString().Trim();
                dgv_tramos.Rows[0].Cells[1].Value = primer_tramo.destino.ToString().Trim();
                dgv_tramos.Rows[0].Cells[2].Value = primer_tramo.precio.ToString();

                for (int j = 1; j < this.cantTramos; )
                {
                    Tramo nue_tramo = tramosList.Dequeue();
                    if (String.Equals(Convert.ToString(dgv_tramos.Rows[j-1].Cells[1].Value), nue_tramo.salida))
                    {
                        dgv_tramos.Rows[j].Cells["colId"].Value = nue_tramo.id.ToString();
                        dgv_tramos.Rows[j].Cells[0].Value = nue_tramo.salida.ToString().Trim();
                        dgv_tramos.Rows[j].Cells[1].Value = nue_tramo.destino.ToString().Trim();
                        dgv_tramos.Rows[j].Cells[2].Value = nue_tramo.precio.ToString();
                        j++;
                    }
                    else
                        tramosList.Enqueue(nue_tramo);
                }

                for (int j = 0; j < this.cantTramos; j++)
                {
                    Tramo nue_tramo = new Tramo();
                    nue_tramo.id = Convert.ToInt32(dgv_tramos.Rows[j].Cells["colId"].Value);
                    this.recorridoTramos.Enqueue(nue_tramo);
                }

                this.recorridoModificado.rec_id = recorrido.rec_id;
                this.recorridoModificado.rec_pue_id_desde = recorrido.rec_pue_id_desde;
                this.recorridoModificado.rec_pue_id_hasta = recorrido.rec_pue_id_hasta;
                this.recorridoModificado.rec_estado = recorrido.rec_estado;

                //MessageBox.Show(String.Format("Cantidad de tramos {0}", recorridoTramos.Count.ToString()));

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
                this.esModificar = false;
                txt_id.Text = "";
                txt_id.ReadOnly = false;
                numericTextBox1.ReadOnly = true;
                numericTextBox2.ReadOnly = true;               
                dgv_tramos.Rows.Add();
                //Cargar Puerto Desde
                CargarComboPuertoSalida();
                //Cargar Puerto Hasta
                CargarComboPuertoDestino();
            }
        }

        private Tramo obtenerTramo(int row)
        {
            Tramo tramo = new Tramo();
            tramo.id = Convert.ToInt32(dgv_tramos.Rows[row].Cells["colId"].Value);
            tramo.salida = Convert.ToString((dgv_tramos.Rows[row].Cells["colPuertoSalida"].Value));
            tramo.salida_id = Convert.ToInt32(PuertoFunc.ObtenerPuerto(tramo.salida).Rows[0]["pue_id"]);
            //MessageBox.Show(String.Format("salida {0}, salida_id {1}", tramo.salida, tramo.salida_id.ToString()));
            tramo.destino = Convert.ToString((dgv_tramos.Rows[row].Cells["colPuertoDestino"].Value));
            tramo.destino_id = Convert.ToInt32(PuertoFunc.ObtenerPuerto(tramo.destino).Rows[0]["pue_id"]);
            //MessageBox.Show(String.Format("destino {0}, destino_id {1}", tramo.destino, tramo.destino_id.ToString()));
            tramo.precio = Convert.ToDecimal(dgv_tramos.Rows[row].Cells["colPrecioBase"].Value);
            return tramo;
        }

        private void CargarComboPuertoSalida()
        {
            SqlDataReader reader = PuertoFunc.ObtenerPuerto();

            DataGridViewComboBoxColumn comboTipo = (DataGridViewComboBoxColumn)dgv_tramos.Columns["colPuertoSalida"];

            if (reader.HasRows)
            {
                while (reader.Read())
                {
                    Puerto puerto = new Puerto();
                    puerto.id = Convert.ToInt32(reader.GetDecimal(0));
                    puerto.nombre = reader.GetString(1);
                    //puerto.estado = reader.GetBoolean(2);
                    ComboboxItem item = new ComboboxItem();
                    item.Text = puerto.nombre;
                    item.Value = puerto;
                    comboTipo.Items.Add(puerto.nombre);
                }
                int currentRow = dgv_tramos.Rows.Count - 1;
                DataGridViewComboBoxCell celltipo = (DataGridViewComboBoxCell)(dgv_tramos.Rows[currentRow].Cells[0]);
                celltipo.Value = comboTipo.Items[0];
            }

            reader.Close();
        }

        private void CargarComboPuertoDestino()
        {
            SqlDataReader reader = PuertoFunc.ObtenerPuerto();

            DataGridViewComboBoxColumn comboTipo = (DataGridViewComboBoxColumn)dgv_tramos.Columns["colPuertoDestino"];

            if (reader.HasRows)
            {
                while (reader.Read())
                {
                    Puerto puerto = new Puerto();
                    puerto.id = Convert.ToInt32(reader.GetDecimal(0));
                    puerto.nombre = reader.GetString(1);
                    //puerto.estado = reader.GetBoolean(2);
                    ComboboxItem item = new ComboboxItem();
                    item.Text = puerto.nombre;
                    item.Value = puerto;
                    comboTipo.Items.Add(puerto.nombre);
                }
                int currentRow = dgv_tramos.Rows.Count - 1;
                DataGridViewComboBoxCell celltipo = (DataGridViewComboBoxCell)(dgv_tramos.Rows[currentRow].Cells[1]);
                celltipo.Value = comboTipo.Items[0];
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
            //e.Control.KeyPress -= new KeyPressEventHandler(Column2_KeyPress);
            e.Control.KeyPress -= new KeyPressEventHandler(Column3_KeyPress);
            if (dgv_tramos.CurrentCell.ColumnIndex == 2)
            {
                TextBox tb = e.Control as TextBox;
                if (tb != null)
                {
                    tb.MaxLength = 10;
                    tb.KeyPress += new KeyPressEventHandler(Column3_KeyPress);
                }
            }
        }

        private void Column3_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (!char.IsControl(e.KeyChar) && !char.IsDigit(e.KeyChar) && e.KeyChar != ',')
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


        private void ejecutar()
        {
            RegexUtilities util = new RegexUtilities();
            if (ValidarCamposVacios())
            {
                if (ValidarTramos())
                {
                    if (chequearSalidaYDestino())
                    {

                        if (!this.esModificar)
                        {
                            if(String.IsNullOrEmpty(txt_id.Text.Trim()))
                                MessageBox.Show("Completar codigo recorrido");
                            else if(!RecorridoFunc.EsValidoIdRecorrido(txt_id.Text.Trim()))
                                MessageBox.Show("El codigo recorrido ya existe");
                            else{

                            //Crear recorrido
                            Recorrido recorrido = new Recorrido();
                            List<Tramo> tramosList = new List<Tramo>();
                            int cantTramos = this.dgv_tramos.Rows.Count;

                            for (int l = 0; l < cantTramos; l++)
                            {
                                Tramo tramo = obtenerTramo(l);
                                int tra_id = TramoFunc.ValidarTramo(tramo);
                                tramo.id = tra_id;

                                if (l == 0)
                                    recorrido.rec_pue_id_desde = tramo.salida_id;
                                if (l + 1 == cantTramos)
                                    recorrido.rec_pue_id_hasta = tramo.destino_id;
                                tramosList.Add(tramo);
                            }

                            recorrido.rec_id = txt_id.Text.Trim();

                            RecorridoFunc.CrearRecorrido(recorrido);
                            RecorridoFunc.InsertarRecorridoTramo(recorrido.rec_id, tramosList);

                            MessageBox.Show("Recorrido creado");
                            this.Close();
                            }
                        }
                        else
                        {
                            //Modificar recorrido
                            List<Tramo> tramosList = new List<Tramo>();
                            //Tramos del Recorrido

                            int cantTramos = this.dgv_tramos.Rows.Count;

                            for (int l = 0; l < cantTramos; l++)
                            {
                                Tramo tramo = obtenerTramo(l);
                                int tra_id = TramoFunc.ValidarTramo(tramo);
                                tramo.id = tra_id;
                                tramosList.Add(tramo);

                                if (l == 0)
                                    this.recorridoModificado.rec_pue_id_desde = tramo.salida_id;
                                if (l + 1 == cantTramos)
                                    this.recorridoModificado.rec_pue_id_hasta = tramo.destino_id;
                            }
                            /*for (int l2 = this.cantTramos; l2 < this.dgv_tramos.Rows.Count; l2++)
                            {
                                Tramo tramo = obtenerTramo(l2);
                                int tra_id = TramoFunc.ValidarTramo(tramo);
                                tramo.id = tra_id;
                                tramosList.Add(tramo);

                                if (l2 + 1 == cantTramos)
                                    this.recorridoModificado.rec_pue_id_hasta = tramo.destino_id;
                            }*/
                            RecorridoFunc.BorrarRecorridoTramo(this.recorridoModificado.rec_id, this.recorridoTramos);
                            RecorridoFunc.ModificarRecorrido(this.recorridoModificado);
                            RecorridoFunc.ModificarRecorridoTramo(this.recorridoModificado.rec_id, tramosList);
                            MessageBox.Show("Recorrido modificado");
                            this.Close();
                        }
                    }
                }
            }
        }

        private bool ValidarCamposVacios()
        {

            if (dgv_tramos.Rows.Count < 1)
            {
                MessageBox.Show("Debe agregar al menos un tramo");
                return false;
            }
            else
            {
                for (int j = 0; j < this.dgv_tramos.Rows.Count; j++)
                {
                    if (string.IsNullOrEmpty(Convert.ToString(dgv_tramos.Rows[j].Cells["colPuertoSalida"].Value))
                        || string.IsNullOrEmpty(Convert.ToString(dgv_tramos.Rows[j].Cells["colPuertoDestino"].Value))
                        || string.IsNullOrEmpty(Convert.ToString(dgv_tramos.Rows[j].Cells["colPrecioBase"].Value)))
                    {
                        MessageBox.Show("Debe completar todos los campos de los tramos");
                        return false;
                    }
                }
            }
            return true;
        }

        private bool ValidarTramos()
        {
            if (dgv_tramos.Rows.Count < 2)
            {
                String pue_unico_desde = Convert.ToString(dgv_tramos.Rows[0].Cells["colPuertoSalida"].Value);
                String pue_unico_hasta = Convert.ToString(dgv_tramos.Rows[0].Cells["colPuertoDestino"].Value);
                if (String.Equals(pue_unico_desde, pue_unico_hasta))
                {
                    MessageBox.Show("Tramo inválido. Puerto de salida y de destino son iguales");
                    return false;
                }
                return true;
            }
            //Compara Puerto Destino de un tramo y Puerto Salida del siguiente 
            String pue_desde;
            String pue_hasta;
            String pue_hasta_anterior;

            for (int j = 1; j < this.dgv_tramos.Rows.Count; j++)
            {
                pue_desde = Convert.ToString(dgv_tramos.Rows[j].Cells["colPuertoSalida"].Value);
                pue_hasta = Convert.ToString(dgv_tramos.Rows[j].Cells["colPuertoDestino"].Value);
                pue_hasta_anterior = Convert.ToString(dgv_tramos.Rows[j - 1].Cells["colPuertoDestino"].Value);
                if (!String.Equals(pue_hasta_anterior, pue_desde))
                {
                    MessageBox.Show(String.Format("Tramo {0} inválido. Puerto de salida {1} no coincide con el destino del tramo anterior {2}", (j + 1).ToString(), pue_desde, pue_hasta_anterior));
                    return false;
                }
                if (String.Equals(pue_desde, pue_hasta))
                {
                    MessageBox.Show(String.Format("Tramo {0} inválido. Puerto de salida y de destino son iguales: {1}", (j + 1).ToString(), pue_hasta));
                    return false;
                }
            }
            return true;
        }

        //Busca Ciudad Origen repetida

        private bool chequearSalidaYDestino(/*String puertoSalida, String puertoDestino*/)
        {
            String ciudadOrigen = Convert.ToString(dgv_tramos.Rows[0].Cells["colPuertoSalida"].Value);
            for (int j = 1; j < this.dgv_tramos.Rows.Count - 1; j++)
            {
                    String otraCiudad;
                    otraCiudad = Convert.ToString(dgv_tramos.Rows[j].Cells["colPuertoDestino"].Value);
                    if (String.Equals(ciudadOrigen, otraCiudad))
                    {
                        MessageBox.Show(String.Format("El recorrido debe finalizar en el tramo {0} \n ya que vuelve a la ciudad de origen", j.ToString()));
                        return false;
                    }
                    for (int i = 0; i < this.dgv_tramos.Rows.Count; i++)
                    {
                        if (String.Equals(Convert.ToString(dgv_tramos.Rows[i].Cells["colPuertoDestino"].Value), Convert.ToString(dgv_tramos.Rows[j].Cells["colPuertoDestino"].Value))
                            && String.Equals(Convert.ToString(dgv_tramos.Rows[i].Cells["colPuertoSalida"].Value), Convert.ToString(dgv_tramos.Rows[j].Cells["colPuertoSalida"].Value))
                            && i != j)
                        {
                            MessageBox.Show(String.Format("Tramos {0} y {1} repetidos", (j+1).ToString(), (i+1).ToString()));
                            return false;
                        }
                             
                    }
            }
            return true;
        }

        private void FormAmRecorrido_Load(object sender, EventArgs e)
        {

        }

        private void Agregar_Click(object sender, EventArgs e)
        {
            dgv_tramos.Rows.Add();
            CargarComboPuertoSalida();
            CargarComboPuertoDestino();
        }

        private void btAceptar_Click(object sender, EventArgs e)
        {
            ejecutar();
        }

        private void btEliminar_Click(object sender, EventArgs e)
        {
            foreach (DataGridViewRow item in this.dgv_tramos.SelectedRows)
            {
                dgv_tramos.Rows.RemoveAt(item.Index);
            }
        }

        private void btCancelar_Click(object sender, EventArgs e)
        {
            // ejecutar("Publicada");
            this.Close();
        }

    }

}
