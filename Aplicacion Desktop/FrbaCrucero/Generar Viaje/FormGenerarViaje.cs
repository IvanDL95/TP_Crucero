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

namespace FrbaCrucero.Generar_publicacion
{
    public partial class FormGenerarViaje : Form
    {
        String user;
        Int32 IdUsuario;
        public FormGenerarViaje(String user, bool esAdm)
        {
            InitializeComponent();

            if (esAdm)
            {
                MessageBox.Show("El usuario Admin no puede generar publicaciones");
                this.Close();
            }
            else
            {

                this.user = user;
                this.IdUsuario = User.ObtenerIDUsuario(this.user);
                dgv_ubicacion.EditingControlShowing += dgv_ubicacion_EditingControlShowing;
                dgv_ubicacion.CellValidating += dgv_ubicacion_CellValidating;
                dgv_ubicacion.CellEndEdit += dgv_ubicacion_CellEndEdit;
                dgv_fecha.EditingControlShowing += dgv_fecha_EditingControlShowing;
                dgv_fecha.CellValidating += dgv_fecha_CellValidating;
                dgv_fecha.CellEndEdit += dgv_fecha_CellEndEdit;

                //Cargar Rubro de BD
                CargarComboRubro();
                //Cargar Grado de BD
                CargarComboGrado();
                //Cargar Tipos de BD
                CargarComboTipoUbicacion();
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
                DataGridViewComboBoxCell celltipo = (DataGridViewComboBoxCell)(dgv_ubicacion.Rows[0].Cells[3]);
                celltipo.Value = comboTipo.Items[0];
            }
            reader.Close();
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
            if (dgv_ubicacion.CurrentCell.ColumnIndex == 0)
            {
                TextBox tb = e.Control as TextBox;
                if (tb != null)
                {
                    tb.MaxLength = 5;
                    tb.CharacterCasing = CharacterCasing.Upper; 
                    tb.KeyPress += new KeyPressEventHandler(Column2_KeyPress);
                }
            }
            if (dgv_ubicacion.CurrentCell.ColumnIndex == 1)
            {
                TextBox tb = e.Control as TextBox;
                if (tb != null)
                {
                    tb.MaxLength = 5;
                    tb.KeyPress += new KeyPressEventHandler(Column3_KeyPress);
                }
            }
            if (dgv_ubicacion.CurrentCell.ColumnIndex == 2)
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

        private bool ValidarFechas()
        {
            for (int j = 0; j < this.dgv_fecha.Rows.Count - 1; j++)
            {
                String fecha;
                String hora;
                DateTime fechaHora;
                fecha = Convert.ToString(dgv_fecha.Rows[j].Cells["colFecha"].Value);
                hora = Convert.ToString(dgv_fecha.Rows[j].Cells["colHora"].Value);
                String fechaHorastr = String.Concat(fecha, " ", hora);
                String format = "g";
                CultureInfo provider = new CultureInfo("fr-FR");
                fechaHora = DateTime.ParseExact(fechaHorastr, format, provider);

                if (ABMPublicacion.EsValidoFechaPublicacionAlta(txt_desc.Text, fechaHora))
                {
                    MessageBox.Show(String.Format("La publicacion {0} con Fecha y hora {1} ya existe", txt_desc.Text, fechaHorastr));
                    return true;
                }
            }

            return false;
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
            else if (ValidaFechaHoraIncremental())
            {
            }
            else if (ValidaFechaHoraUnica())
            {
            }
            else if (ValidaFechaSistema())
            {
            }
            else if (ValidarFechas()) //Comprobar fechas
            {
            }
            else
            {          
                //Crear Direccion
                Direccion direccion = new Direccion(txt_calle.Text, txt_numero.Text, txt_piso.Text, txt_departamento.Text, txt_cp.Text, txt_tel.Text, txt_mail.Text, txt_localidad.Text);
                Adress.CrearDireccion(direccion);
                int idDireccion = Adress.ObtenerIDDireccion(txt_calle.Text, txt_numero.Text, txt_piso.Text, txt_departamento.Text, txt_cp.Text, txt_tel.Text, txt_mail.Text, txt_localidad.Text);

                DateTime fechaSistema = DataBase.ObtenerFechaSistema();

                //Guardar publicacion
                for (int j = 0; j < this.dgv_fecha.Rows.Count - 1; j++)
                {
                    //Crear publicacion por fecha
                    Publicacion publicacion = new Publicacion();
                    Grado grado = new Grado();
                    Rubro rubro = new Rubro();
                    String fecha;
                    String hora;
                    DateTime fechaHora;
                    fecha = Convert.ToString(dgv_fecha.Rows[j].Cells["colFecha"].Value);
                    hora = Convert.ToString(dgv_fecha.Rows[j].Cells["colHora"].Value);
                    String fechaHorastr = String.Concat(fecha, " ", hora);
                    String format = "g";
                    CultureInfo provider = new CultureInfo("fr-FR");
                    fechaHora = DateTime.ParseExact(fechaHorastr, format, provider);
                    publicacion.pub_fecha_espec = fechaHora;




                    //Fecha de publicación sólo si se publica
                    if (string.Compare(estado, "Publicada") == 0)
                        publicacion.pub_fecha_pub = fechaSistema;
                    ComboboxItem item = new ComboboxItem();
                    item = (ComboboxItem)cmb_grado.SelectedItem;
                    grado = (Grado)item.Value;
                    publicacion.pub_grado = grado.gra_id;
                    item = (ComboboxItem)cmb_rubro.SelectedItem;
                    rubro = (Rubro)item.Value;
                    publicacion.pub_rubro = rubro.rub_id;
                    publicacion.pub_estado = estado;
                    publicacion.pub_desc = txt_desc.Text;
                    publicacion.pub_dir = idDireccion;
                    publicacion.pub_usu = this.IdUsuario;

                    ABMPublicacion.CrearPublicacion(publicacion);
                    int idPublicacion = ABMPublicacion.ObtenerIDPublicacion(publicacion);
                    //Guardar ubicaciones
                    //Sin numerar
                    if (checkBox1.Checked)
                    {
                        for (int k = 0; k < this.dgv_ubicacion.Rows.Count - 1; k++)
                        {
                            Ubicacion ubicacion = new Ubicacion();
                            ubicacion.ubi_precio = Convert.ToDecimal(dgv_ubicacion.Rows[k].Cells["colPrecio"].Value, CultureInfo.InvariantCulture);
                            ubicacion.ubi_tipo = ABMUbicacion.ObtenerIDTipo(Convert.ToString(dgv_ubicacion.Rows[k].Cells["colTipoUbicacion"].Value));
                            ubicacion.ubi_pub = idPublicacion;
                            ubicacion.ubi_sin_numerar = true;
                            ABMUbicacion.CrearUbicacionSinNumerar(ubicacion);
                        }
                    }
                    else
                    {
                        //Numeradas
                        for (int l = 0; l < this.dgv_ubicacion.Rows.Count - 1; l++)
                        {
                            Ubicacion ubicacion = new Ubicacion();
                            ubicacion.ubi_fila = Convert.ToString(dgv_ubicacion.Rows[l].Cells["colFila"].Value);
                            ubicacion.ubi_asiento = Convert.ToString(dgv_ubicacion.Rows[l].Cells["colAsiento"].Value);
                            ubicacion.ubi_precio = Convert.ToDecimal(dgv_ubicacion.Rows[l].Cells["colPrecio"].Value, CultureInfo.InvariantCulture);
                            ubicacion.ubi_tipo = ABMUbicacion.ObtenerIDTipo(Convert.ToString(dgv_ubicacion.Rows[l].Cells["colTipoUbicacion"].Value));
                            ubicacion.ubi_pub = idPublicacion;
                            ubicacion.ubi_sin_numerar = false;
                            ABMUbicacion.CrearUbicacion(ubicacion);

                        }
                    }

                }
                MessageBox.Show("Publicación creada");
                this.Close();
            }
        }

        private bool ValidaFechaSistema()
        {
            
            //Compara Fecha y Hora con Fecha Sistema
            for (int j = 0; j < this.dgv_fecha.Rows.Count - 1; j++)
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

            if (dgv_fecha.Rows.Count < 2)
            {
                MessageBox.Show("Debe agregar al menos una fecha");
                return true;
            }
            else
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
            if (dgv_fecha.Rows.Count == 2)
            {
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
