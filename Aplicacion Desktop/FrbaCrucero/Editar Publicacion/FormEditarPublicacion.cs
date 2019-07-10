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

namespace FrbaCrucero.Editar_Publicacion
{
    public partial class FormEditarPublicacion : Form
    {
        FormListarPublicacion fr;
        Int32 idPublicacion;
        Publicacion publicacionBase = new Publicacion();
        Publicacion publicacionModificado = new Publicacion();
        Direccion direccionModificado = new Direccion();
        int cantUbicaciones;

        public FormEditarPublicacion(Int32 idPublicacion, FormListarPublicacion fr)
        {
            
            InitializeComponent();
            this.idPublicacion = idPublicacion;
            this.fr = fr;
            dgv_ubicacion.EditingControlShowing += dgv_ubicacion_EditingControlShowing;
            dgv_ubicacion.CellValidating += dgv_ubicacion_CellValidating;
            dgv_ubicacion.CellEndEdit += dgv_ubicacion_CellEndEdit;
            dgv_fecha.EditingControlShowing += dgv_fecha_EditingControlShowing;
            dgv_fecha.CellValidating += dgv_fecha_CellValidating;
            dgv_fecha.CellEndEdit += dgv_fecha_CellEndEdit;
            dgv_ubicacion.DataError += dgv_ubicacion_DataError;

            //Cargar Rubro de BD
            CargarComboRubro();
            //Cargar Grado de BD
            CargarComboGrado();

            Publicacion publicacion = new Publicacion();

            //Obtener Publicacion
            SqlDataReader reader = ABMPublicacion.ObtenerPublicacion(this.idPublicacion);
            publicacion = ABMPublicacion.ObtenerPublicacionDesdeUnReader(reader);
            //Obtener Direccion
            Direccion direccion = Adress.ObtenerDireccionDesdeUnReader(Adress.ObtenerDireccion(publicacion.pub_dir));            
            txt_calle.Text = direccion.Calle.Trim();
            txt_departamento.Text = direccion.Departamento.Trim();
            txt_piso.Text = direccion.Piso.Trim();
            txt_cp.Text = direccion.CodigoPostal.Trim();
            if (!String.IsNullOrEmpty(direccion.Localidad))
                txt_localidad.Text = direccion.Localidad.Trim();
            txt_numero.Text = direccion.Numero.Trim();
            if (!String.IsNullOrEmpty(direccion.Telefono))
                txt_tel.Text = direccion.Telefono.Trim();
            txt_mail.Text = direccion.Mail.Trim();
            //Llenar textos
            txt_desc.Text = publicacion.pub_desc.Trim();
            //Cargar fecha y hora
            DataGridViewRow rowFecha = (DataGridViewRow)dgv_fecha.Rows[0].Clone();
            rowFecha.Cells[0].Value = publicacion.pub_fecha_espec.ToString("dd/MM/yyyy");
            rowFecha.Cells[1].Value = publicacion.pub_fecha_espec.ToString("HH:mm");
            dgv_fecha.Rows.Add(rowFecha);

            //Cargar rubro
            cmb_rubro.SelectedIndex = publicacion.pub_rubro-1;
            //Cargar grado
            cmb_grado.SelectedIndex = publicacion.pub_grado-1;
            DataTable ubicaciones = ABMUbicacion.ObtenerUbicaciones(this.idPublicacion);        

            //Se carga combo Tipo Ubicacion de la fila
            CargarComboTipoUbicacion();

            this.cantUbicaciones = ubicaciones.Rows.Count;
            //Se agragan las filas necesarias          
            for (Int32 j = 0; j < ubicaciones.Rows.Count; j++)
            {
                DataGridViewRow rowUbic = (DataGridViewRow)dgv_ubicacion.Rows[0].Clone();
                dgv_ubicacion.Rows.Add(rowUbic);
            }

            //Ubicacion sin numerar?
            if (!Convert.ToBoolean(ubicaciones.Rows[0]["ubi_sin_numerar"]))
            {                            
                //Se agregan los datos en las filas
                for (Int32 i = 0; i < ubicaciones.Rows.Count; i++)
                {
                    dgv_ubicacion.Rows[i].Cells[0].Value = ubicaciones.Rows[i]["ubi_id"].ToString();
                    dgv_ubicacion.Rows[i].Cells[1].Value = ubicaciones.Rows[i]["ubi_fila"].ToString().Trim();
                    dgv_ubicacion.Rows[i].Cells[2].Value = ubicaciones.Rows[i]["ubi_asiento"].ToString().Trim();
                    dgv_ubicacion.Rows[i].Cells[3].Value = ubicaciones.Rows[i]["ubi_precio"].ToString().Replace(",", ".").Replace(".", ".");
                    SqlDataReader readerTipo = ABMUbicacion.ObtenerDescTipo(Convert.ToInt32(ubicaciones.Rows[i]["ubi_tipo"]));
                    if (readerTipo.HasRows)
                    {
                        while (readerTipo.Read())
                        {
                            dgv_ubicacion.Rows[i].Cells[4].Value = readerTipo.GetString(0);
                        }
                    }

                    
                }
            }
            else //Sin numerar
            {
                checkBox1.Checked = true;

                for (Int32 i = 0; i < ubicaciones.Rows.Count; i++)
                {                  
                    dgv_ubicacion.Rows[i].Cells[0].Value = ubicaciones.Rows[i]["ubi_id"].ToString();
                    dgv_ubicacion.Rows[i].Cells[3].Value = ubicaciones.Rows[i]["ubi_precio"].ToString().Replace(",", ".").Replace(".", ".");
                    SqlDataReader readerTipo = ABMUbicacion.ObtenerDescTipo(Convert.ToInt32(ubicaciones.Rows[i]["ubi_tipo"]));
                    if (readerTipo.HasRows)
                    {
                        while (readerTipo.Read())
                        {
                            dgv_ubicacion.Rows[i].Cells[4].Value = readerTipo.GetString(0);
                        }
                    }
                }
            }

            this.publicacionModificado.pub_desc = publicacion.pub_desc.Trim();
            this.publicacionModificado.pub_id = this.idPublicacion;
            this.publicacionModificado.pub_dir = publicacion.pub_dir;
            this.direccionModificado.Id = publicacion.pub_dir;
            this.direccionModificado = direccion;
            this.publicacionBase = publicacion;

            //Solo editar la fecha de espectaculo actual
            dgv_fecha.AllowUserToAddRows = false;
            dgv_ubicacion.AllowUserToAddRows = true;

        }

        private void CargarComboTipoUbicacion()
        {
            SqlDataReader reader = ABMUbicacion.ObtenerTipos();
            DataGridViewComboBoxColumn comboTipo = (DataGridViewComboBoxColumn)dgv_ubicacion.Columns["colTipoUbicacion"];
            if (reader.HasRows)
            {
                while (reader.Read())
                {
                    //Se cargan los Tipos Ubicacion de la fila 
                    comboTipo.Items.Add(reader.GetString(1));
                }
                DataGridViewComboBoxCell celltipo = (DataGridViewComboBoxCell)(dgv_ubicacion.Rows[0].Cells[4]);
                celltipo.Value = comboTipo.Items[0];
            }
            reader.Close();
        }

        private void dgv_ubicacion_DataError(object sender, DataGridViewDataErrorEventArgs anError)
        {

            MessageBox.Show("Error happened " + anError.Context.ToString());

            if (anError.Context == DataGridViewDataErrorContexts.Commit)
            {
                MessageBox.Show("Commit error");
            }
            if (anError.Context == DataGridViewDataErrorContexts.CurrentCellChange)
            {
                MessageBox.Show("Cell change");
            }
            if (anError.Context == DataGridViewDataErrorContexts.Parsing)
            {
                MessageBox.Show("parsing error");
            }
            if (anError.Context == DataGridViewDataErrorContexts.LeaveControl)
            {
                MessageBox.Show("leave control error");
            }

            if ((anError.Exception) is ConstraintException)
            {
                DataGridView view = (DataGridView)sender;
                view.Rows[anError.RowIndex].ErrorText = "an error";
                view.Rows[anError.RowIndex].Cells[anError.ColumnIndex].ErrorText = "an error";

                anError.ThrowException = false;
            }
        }

        private void btBorrador_Click(object sender, EventArgs e)
        {
            ejecutar("Borrador");
        }

        private void button1_Click(object sender, EventArgs e)
        {
            ejecutar("Publicada");
        }

        private void CargarComboGrado()
        {
            SqlDataReader reader = GradoFunc.ObtenerGrados();

            if (reader.HasRows)
            {
                while (reader.Read())
                {
                    Grado grado = new Grado();
                    grado.gra_id = Convert.ToInt32(reader.GetDecimal(0));
                    grado.gra_desc = reader.GetString(1);
                    ComboboxItem item = new ComboboxItem();
                    item.Text = grado.gra_desc;
                    item.Value = grado;
                    cmb_grado.Items.Add(item);
                }
            }
            reader.Close();
        }

        private void CargarComboRubro()
        {
            SqlDataReader reader = RubroFunc.ObtenerRubros();

            if (reader.HasRows)
            {
                while (reader.Read())
                {
                    Rubro rubro = new Rubro();
                    rubro.rub_id = Convert.ToInt32(reader.GetDecimal(0));
                    rubro.rub_desc = reader.GetString(1);
                    ComboboxItem item = new ComboboxItem();
                    item.Text = rubro.rub_desc;
                    item.Value = rubro;
                    cmb_rubro.Items.Add(item);
                }
            }
            reader.Close();
        }


        private void ValidacionesIniciales()
        {
            txt_calle.MaxLength = 70;
            txt_departamento.MaxLength = 2;
            txt_piso.MaxLength = 2;
            txt_cp.MaxLength = 4;
            txt_localidad.MaxLength = 50;
            txt_numero.MaxLength = 5;
            txt_tel.MaxLength = 18;
            txt_mail.MaxLength = 50;
            txt_desc.MaxLength = 400;
        }

        private void dgv_ubicacion_EditingControlShowing(object sender, DataGridViewEditingControlShowingEventArgs e)
        {
            e.Control.KeyPress -= new KeyPressEventHandler(Column1_KeyPress);
            e.Control.KeyPress -= new KeyPressEventHandler(Column2_KeyPress);
            e.Control.KeyPress -= new KeyPressEventHandler(Column3_KeyPress);
            if (dgv_ubicacion.CurrentCell.ColumnIndex == 1)
            {
                TextBox tb = e.Control as TextBox;
                if (tb != null)
                {
                    tb.MaxLength = 5;
                    tb.CharacterCasing = CharacterCasing.Upper; 
                    tb.KeyPress += new KeyPressEventHandler(Column2_KeyPress);
                }
            }
            if (dgv_ubicacion.CurrentCell.ColumnIndex == 2)
            {
                TextBox tb = e.Control as TextBox;
                if (tb != null)
                {
                    tb.MaxLength = 5;
                    tb.KeyPress += new KeyPressEventHandler(Column3_KeyPress);
                }
            }
            if (dgv_ubicacion.CurrentCell.ColumnIndex == 3)
            {
                TextBox tb = e.Control as TextBox;
                if (tb != null)
                {
                    tb.MaxLength = 10;
                    tb.KeyPress += new KeyPressEventHandler(Column1_KeyPress);                             
                }
            }
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
            if (!char.IsControl(e.KeyChar) && !char.IsLetter(e.KeyChar))
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

        private void dgv_ubicacion_CellValidating(object sender, DataGridViewCellValidatingEventArgs e)
        {
            string columnName = this.dgv_ubicacion.Columns[e.ColumnIndex].Name;

            if (!checkBox1.Checked)
            {
                if (columnName.Equals("colAsiento"))
                {
                    // Check if the input is empty
                    if (string.IsNullOrEmpty(e.FormattedValue.ToString()))
                    {
                        this.dgv_ubicacion.Rows[e.RowIndex].ErrorText = "La columna Asiento está vacía";
                        e.Cancel = true;
                    }
                }
                if (columnName.Equals("colFila"))
                {
                    // Check if the input is empty
                    if (string.IsNullOrEmpty(e.FormattedValue.ToString()))
                    {
                        this.dgv_ubicacion.Rows[e.RowIndex].ErrorText = "La columna Fila está vacía";
                        e.Cancel = true;
                    }
                }
            }

            // Check for the column to validate
            if (columnName.Equals("colPrecio"))
            {
                // Check if the input is empty
                if (string.IsNullOrEmpty(e.FormattedValue.ToString()))
                {
                    this.dgv_ubicacion.Rows[e.RowIndex].ErrorText = "La columna Precio está vacía";
                    e.Cancel = true;
                }
                else
                {
                    // Check if the input format is correct
                    Regex datePattern = new Regex("^[0-9]{1,10}([.][0-9]{1,2})?$");
                    if (!datePattern.IsMatch(e.FormattedValue.ToString()))
                    {
                        this.dgv_ubicacion.Rows[e.RowIndex].ErrorText = "Formato incorrecto: \"NNNNNNNN.DD\"";
                        e.Cancel = true;
                    }
                }
            }
        }

        private void dgv_ubicacion_CellEndEdit(object sender, DataGridViewCellEventArgs e)
        {
            this.dgv_ubicacion.Rows[e.RowIndex].ErrorText = string.Empty;
        }

        private void dgv_fecha_EditingControlShowing(object sender, DataGridViewEditingControlShowingEventArgs e)
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
        }

        private void dgv_fecha_Column1_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (!char.IsControl(e.KeyChar) && !char.IsDigit(e.KeyChar) && e.KeyChar != '/')
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

        private void dgv_fecha_CellValidating(object sender, DataGridViewCellValidatingEventArgs e)
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
        }

        private void dgv_fecha_CellEndEdit(object sender, DataGridViewCellEventArgs e)
        {
            this.dgv_fecha.Rows[e.RowIndex].ErrorText = string.Empty;
        }


        private void dgv_ubicacion_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            
        }

        private void checkBox1_CheckedChanged(object sender, EventArgs e)
        {
            if (checkBox1.Checked)
            {
                colFila.Visible = false;
                colAsiento.Visible = false;
            }
            else
            {
                colFila.Visible = true;
                colAsiento.Visible = true;
            }
        }

        private void ejecutar(string estado)
        {
            RegexUtilities util = new RegexUtilities();
            if (ValidarCamposVacios())
                MessageBox.Show("Debe completar todos los campos");
            //Validar mail   
            else if (!util.IsValidEmail(txt_mail.Text))
                MessageBox.Show("El Email ingresado no es válido");
            else if (ValidarTipoUbicacionVacio())
            {
            }
            else if (ValidaFilaAsiento())
                MessageBox.Show("Asiento y fila repetido");
            else if (ValidaFechaHoraUnica())
            {
            }
            else if (ValidaFechaSistema())
            {
            }
            else
            {
                String fecha;
                String hora;
                DateTime fechaHora;
                //La fecha/hora es unica
                fecha = Convert.ToString(dgv_fecha.Rows[0].Cells["colFecha"].Value);
                hora = Convert.ToString(dgv_fecha.Rows[0].Cells["colHora"].Value);
                String fechaHorastr = String.Concat(fecha, " ", hora);
                String format = "g";
                CultureInfo provider = new CultureInfo("fr-FR");
                fechaHora = DateTime.ParseExact(fechaHorastr, format, provider);
                publicacionModificado.pub_fecha_espec = fechaHora;

                if (ABMPublicacion.EsValidoFechaPublicacion(publicacionBase, txt_desc.Text, fechaHora))
                    MessageBox.Show(String.Format("La publicacion {0} con Fecha y hora {1} ya existe", txt_desc.Text, fechaHorastr));
                else
                {
                    //Modificar Direccion
                    Direccion direccion = new Direccion(txt_calle.Text, txt_numero.Text, txt_tel.Text, txt_mail.Text);
                    direccion.Id = publicacionBase.pub_dir;
                    Adress.ModificarDireccion(direccion);

                    //Guardar publicacion
                    Grado grado = new Grado();
                    Rubro rubro = new Rubro();
                    ComboboxItem item = new ComboboxItem();

                    DateTime fechaSistema = DataBase.ObtenerFechaSistema();
                    //Fecha de publicación sólo si se publica
                    if (string.Compare(estado, "Publicada") == 0)
                        publicacionModificado.pub_fecha_pub = fechaSistema;

                    item = (ComboboxItem)cmb_grado.SelectedItem;
                    grado = (Grado)item.Value;
                    publicacionModificado.pub_grado = grado.gra_id;
                    item = (ComboboxItem)cmb_rubro.SelectedItem;
                    rubro = (Rubro)item.Value;
                    publicacionModificado.pub_rubro = rubro.rub_id;
                    publicacionModificado.pub_estado = estado;
                    publicacionModificado.pub_desc = txt_desc.Text;

                    ABMPublicacion.ModificarPublicacion(publicacionModificado);
                    int idPublicacion = ABMPublicacion.ObtenerIDPublicacion(publicacionModificado);
                    //Guardar ubicaciones
                    //Sin numerar
                    if (checkBox1.Checked)
                    {
                        for (int k = 0; k < this.cantUbicaciones; k++)
                        {
                            Ubicacion ubicacion = new Ubicacion();
                            ubicacion.ubi_precio = Convert.ToDecimal(dgv_ubicacion.Rows[k].Cells["colPrecio"].Value, CultureInfo.InvariantCulture);
                            ubicacion.ubi_tipo = ABMUbicacion.ObtenerIDTipo(Convert.ToString(dgv_ubicacion.Rows[k].Cells["colTipoUbicacion"].Value));
                            ubicacion.ubi_pub = this.idPublicacion;
                            ubicacion.ubi_sin_numerar = true;
                            ubicacion.ubi_id = Convert.ToInt32(dgv_ubicacion.Rows[k].Cells["id"].Value);
                            ABMUbicacion.ModificarUbicacion(ubicacion);
                        }
                        for (int k2 = this.cantUbicaciones; k2 < this.dgv_ubicacion.Rows.Count - 1; k2++)
                        {
                            Ubicacion ubicacion = new Ubicacion();
                            ubicacion.ubi_precio = Convert.ToDecimal(dgv_ubicacion.Rows[k2].Cells["colPrecio"].Value, CultureInfo.InvariantCulture);
                            ubicacion.ubi_tipo = ABMUbicacion.ObtenerIDTipo(Convert.ToString(dgv_ubicacion.Rows[k2].Cells["colTipoUbicacion"].Value));
                            ubicacion.ubi_pub = this.idPublicacion;
                            ubicacion.ubi_sin_numerar = false;
                            ABMUbicacion.CrearUbicacionSinNumerar(ubicacion);
                        }

                    }
                    else
                    {
                        //Numeradas
                        for (int l = 0; l < this.cantUbicaciones; l++)
                        {
                            Ubicacion ubicacion = new Ubicacion();
                            ubicacion.ubi_fila = Convert.ToString(dgv_ubicacion.Rows[l].Cells["colFila"].Value);
                            ubicacion.ubi_asiento = Convert.ToString(dgv_ubicacion.Rows[l].Cells["colAsiento"].Value);
                            ubicacion.ubi_precio = Convert.ToDecimal(dgv_ubicacion.Rows[l].Cells["colPrecio"].Value, CultureInfo.InvariantCulture);
                            ubicacion.ubi_tipo = ABMUbicacion.ObtenerIDTipo(Convert.ToString(dgv_ubicacion.Rows[l].Cells["colTipoUbicacion"].Value));
                            ubicacion.ubi_pub = this.idPublicacion;
                            ubicacion.ubi_sin_numerar = false;
                            ubicacion.ubi_id = Convert.ToInt32(dgv_ubicacion.Rows[l].Cells["id"].Value);
                            ABMUbicacion.ModificarUbicacion(ubicacion);

                        }
                        for (int l2 = this.cantUbicaciones; l2 < this.dgv_ubicacion.Rows.Count - 1; l2++)
                        {
                            Ubicacion ubicacion = new Ubicacion();
                            ubicacion.ubi_fila = Convert.ToString(dgv_ubicacion.Rows[l2].Cells["colFila"].Value);
                            ubicacion.ubi_asiento = Convert.ToString(dgv_ubicacion.Rows[l2].Cells["colAsiento"].Value);
                            ubicacion.ubi_precio = Convert.ToDecimal(dgv_ubicacion.Rows[l2].Cells["colPrecio"].Value, CultureInfo.InvariantCulture);
                            ubicacion.ubi_tipo = ABMUbicacion.ObtenerIDTipo(Convert.ToString(dgv_ubicacion.Rows[l2].Cells["colTipoUbicacion"].Value));
                            ubicacion.ubi_pub = this.idPublicacion;
                            ubicacion.ubi_sin_numerar = false;
                            ABMUbicacion.CrearUbicacion(ubicacion);
                        }
                    }


                    MessageBox.Show("Publicación editada");
                    this.Close();
                }
            }
        }

        private bool ValidaFechaSistema()
        {
            
            //Compara Fecha y Hora con Fecha Sistema
            for (int j = 0; j < this.dgv_fecha.Rows.Count; j++)
            {
                String fecha;
                String hora;
                fecha = Convert.ToString(dgv_fecha.Rows[j].Cells["colFecha"].Value);
                hora = Convert.ToString(dgv_fecha.Rows[j].Cells["colHora"].Value);
                if (comparaFechaHoraSistema(fecha, hora, j))
                     return true;
            }
            return false;
        }

        private bool comparaFechaHoraSistema(String fecha, String hora, int numFila)
        {
            DateTime fechaSistema = DataBase.ObtenerFechaSistema();
            DateTime fechaHora = DateTime.Now;
            String fechaHorastr = String.Concat(fecha, " ", hora);
            String format = "g";
            CultureInfo provider = new CultureInfo("fr-FR");
            try
            {
                fechaHora = DateTime.ParseExact(fechaHorastr, format, provider);
            }
            catch (FormatException)
            {
                MessageBox.Show(String.Format("Fecha y hora invalida: {0}", fechaHorastr), "Error");
                return true;
            }
            if (DateTime.Compare(fechaSistema, fechaHora) > 0)
            {
                MessageBox.Show(String.Format("Fecha y hora {0} menor a Fecha de Sistema {1}", fechaHorastr, fechaSistema.ToString()));
                return true;
            }
            return false;
        }


        private bool ValidarTipoUbicacionVacio()
        {
            for (int j = 0; j < this.dgv_fecha.Rows.Count - 1; j++)
            {
                if (string.IsNullOrEmpty(Convert.ToString(dgv_fecha.Rows[j].Cells["colFecha"].Value))
                    || string.IsNullOrEmpty(Convert.ToString(dgv_fecha.Rows[j].Cells["colHora"].Value)))
                {
                    MessageBox.Show("Debe completar todos los campos de la fecha");
                    return true;
                }
            }
            

            if (dgv_ubicacion.Rows.Count < 2)
            {
                MessageBox.Show("Debe agregar al menos una ubicación");
                return true;
            }
            else
            {
                if (!checkBox1.Checked)
                {
                    for (int j = 0; j < this.dgv_ubicacion.Rows.Count - 1; j++)
                    {
                        if (string.IsNullOrEmpty(Convert.ToString(dgv_ubicacion.Rows[j].Cells["colFila"].Value))
                            || string.IsNullOrEmpty(Convert.ToString(dgv_ubicacion.Rows[j].Cells["colAsiento"].Value))
                            || string.IsNullOrEmpty(Convert.ToString(dgv_ubicacion.Rows[j].Cells["colPrecio"].Value))
                            || string.IsNullOrEmpty(Convert.ToString(dgv_ubicacion.Rows[j].Cells["colTipoUbicacion"].Value)))
                        {
                            MessageBox.Show("Debe completar todos los campos de la ubicacion");
                            return true;
                        }
                    }
                }
                else
                {
                    for (int j = 0; j < this.dgv_ubicacion.Rows.Count - 1; j++)
                    {
                        if (string.IsNullOrEmpty(Convert.ToString(dgv_ubicacion.Rows[j].Cells["colPrecio"].Value))
                            || string.IsNullOrEmpty(Convert.ToString(dgv_ubicacion.Rows[j].Cells["colTipoUbicacion"].Value)))
                        {
                            MessageBox.Show("Debe completar todos los campos de la ubicacion");
                            return true;
                        }
                    }

                }
            }
            return false;
        }

        private bool ValidarCamposVacios()
        {
            if (string.IsNullOrEmpty(cmb_rubro.Text) || string.IsNullOrEmpty(cmb_grado.Text) || txt_desc.Text == "" || txt_cp.Text == "" || txt_departamento.Text == "" || txt_localidad.Text == "" || txt_mail.Text == "" || txt_numero.Text == "" || txt_piso.Text == "" || txt_tel.Text == "")
                return true;
            return false;
        }

        private bool ValidaFilaAsiento()
        {
            //Busca Fila y Asiento repetido si no hay ubicaciones sin numerar
            if (!checkBox1.Checked)
            {
                for (int j = 0; j < this.dgv_ubicacion.Rows.Count - 1; j++)
                {
                    String asiento;
                    String fila;
                    asiento = Convert.ToString(dgv_ubicacion.Rows[j].Cells["colAsiento"].Value);
                    fila = Convert.ToString(dgv_ubicacion.Rows[j].Cells["colFila"].Value);
                    if (buscarAsientoFila(asiento, fila, j))
                        return true;
                }
            }
            return false;
        }

        private bool ValidaFechaHoraIncremental()
        {
            //Busca Fecha y Hora no incremental
            for (int j = 0; j < this.dgv_fecha.Rows.Count - 1; j++)
            {
                String fecha;
                String hora;
                fecha = Convert.ToString(dgv_fecha.Rows[j].Cells["colFecha"].Value);
                hora = Convert.ToString(dgv_fecha.Rows[j].Cells["colHora"].Value);
                if (j != this.dgv_fecha.Rows.Count - 2)
                    if (comparaFechaHoraSiguiente(fecha, hora, j))
                        return true;
            }
            return false;
        }

        private bool ValidaFechaHoraUnica()
        {
            //Fecha y hora es una sola, comprobar invalidez
                String fecha;
                String hora;
                String format = "g";
                CultureInfo provider = new CultureInfo("fr-FR");
                fecha = Convert.ToString(dgv_fecha.Rows[0].Cells["colFecha"].Value);
                hora = Convert.ToString(dgv_fecha.Rows[0].Cells["colHora"].Value);
                DateTime fechaHora = DateTime.Now;
                String fechaHorastr = String.Concat(fecha, " ", hora);
                try
                {
                    fechaHora = DateTime.ParseExact(fechaHorastr, format, provider);
                }
                catch (FormatException)
                {
                    MessageBox.Show(String.Format("Fecha y hora invalida: {0}", fechaHorastr), "Error");
                    return true;
                }
            
            return false;
        }


        //Busca Fila y Asiento repetido
        private bool buscarAsientoFila(String asiento, String fila, int numFila)
        {
            for (int j = 0; j < this.dgv_ubicacion.Rows.Count - 1; j++)
            {
                if (j != numFila)
                {
                    String asientoBusca;
                    String filaBusca;
                    asientoBusca = Convert.ToString(dgv_ubicacion.Rows[j].Cells["colAsiento"].Value);
                    filaBusca = Convert.ToString(dgv_ubicacion.Rows[j].Cells["colFila"].Value);
                    if (String.Equals(asiento, asientoBusca) && String.Equals(fila, filaBusca))
                    {                  
                        return true;
                    }
                }
            }
            return false;
        }

        private bool comparaFechaHoraSiguiente(String fecha, String hora, int numFila)
        {
            DateTime fechaHora=DateTime.Now;
            String fechaHorastr = String.Concat(fecha," ",hora);
            String format = "g";
            CultureInfo provider = new CultureInfo("fr-FR");
            try
            {
                fechaHora = DateTime.ParseExact(fechaHorastr, format, provider);
            }
            catch (FormatException)
            {
                MessageBox.Show(String.Format("Fecha y hora invalida: {0}", fechaHorastr), "Error");
                return true;
            }

            String fechaSiguiente;
            String horaSiguiente;
            fechaSiguiente = Convert.ToString(dgv_fecha.Rows[numFila + 1].Cells["colFecha"].Value);
            horaSiguiente = Convert.ToString(dgv_fecha.Rows[numFila + 1].Cells["colHora"].Value);
            DateTime fechaHoraSiguiente = DateTime.Now;                        
            String fechaHoraSiguientestr = String.Concat(fechaSiguiente, " ", horaSiguiente);
            try
            {
                fechaHoraSiguiente = DateTime.ParseExact(fechaHoraSiguientestr, format, provider);
            }
            catch (FormatException){
                MessageBox.Show(String.Format("Fecha y hora invalida: {0}", fechaHoraSiguientestr), "Error");
                return true;
            }

            if (DateTime.Compare(fechaHora, fechaHoraSiguiente) >= 0)
            {
                MessageBox.Show("Fecha y hora no incremental");
                return true;
            }       
            return false;
        }
    }

}
