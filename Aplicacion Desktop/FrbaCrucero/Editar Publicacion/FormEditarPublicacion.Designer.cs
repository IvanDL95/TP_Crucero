namespace FrbaCrucero.Editar_Publicacion
{
    partial class FormEditarPublicacion
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.label2 = new System.Windows.Forms.Label();
            this.label1 = new System.Windows.Forms.Label();
            this.txt_desc = new System.Windows.Forms.TextBox();
            this.label3 = new System.Windows.Forms.Label();
            this.dgv_ubicacion = new System.Windows.Forms.DataGridView();
            this.label4 = new System.Windows.Forms.Label();
            this.checkBox1 = new System.Windows.Forms.CheckBox();
            this.btBorrador = new System.Windows.Forms.Button();
            this.dgv_fecha = new System.Windows.Forms.DataGridView();
            this.colFecha = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.colHora = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.label5 = new System.Windows.Forms.Label();
            this.cmb_rubro = new System.Windows.Forms.ComboBox();
            this.label6 = new System.Windows.Forms.Label();
            this.cmb_grado = new System.Windows.Forms.ComboBox();
            this.txt_localidad = new System.Windows.Forms.TextBox();
            this.txt_mail = new System.Windows.Forms.TextBox();
            this.txt_cp = new System.Windows.Forms.TextBox();
            this.txt_departamento = new System.Windows.Forms.TextBox();
            this.txt_calle = new System.Windows.Forms.TextBox();
            this.label10 = new System.Windows.Forms.Label();
            this.label9 = new System.Windows.Forms.Label();
            this.label8 = new System.Windows.Forms.Label();
            this.label7 = new System.Windows.Forms.Label();
            this.label11 = new System.Windows.Forms.Label();
            this.label12 = new System.Windows.Forms.Label();
            this.label13 = new System.Windows.Forms.Label();
            this.label14 = new System.Windows.Forms.Label();
            this.btPublicar = new System.Windows.Forms.Button();
            this.txt_tel = new FrbaCrucero.NumericTextBox();
            this.txt_piso = new FrbaCrucero.NumericTextBox();
            this.txt_numero = new FrbaCrucero.NumericTextBox();
            this.id = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.colFila = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.colAsiento = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.colPrecio = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.colTipoUbicacion = new System.Windows.Forms.DataGridViewComboBoxColumn();
            ((System.ComponentModel.ISupportInitialize)(this.dgv_ubicacion)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.dgv_fecha)).BeginInit();
            this.SuspendLayout();
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Font = new System.Drawing.Font("Microsoft Sans Serif", 20.25F, ((System.Drawing.FontStyle)((System.Drawing.FontStyle.Bold | System.Drawing.FontStyle.Underline))), System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label2.Location = new System.Drawing.Point(238, 9);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(249, 31);
            this.label2.TabIndex = 101;
            this.label2.Text = "Editar Publicación";
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(61, 81);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(66, 13);
            this.label1.TabIndex = 102;
            this.label1.Text = "Descripcion:";
            // 
            // txt_desc
            // 
            this.txt_desc.Location = new System.Drawing.Point(130, 78);
            this.txt_desc.Name = "txt_desc";
            this.txt_desc.Size = new System.Drawing.Size(232, 20);
            this.txt_desc.TabIndex = 104;
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(61, 117);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(151, 13);
            this.label3.TabIndex = 105;
            this.label3.Text = "Fecha y hora del Espectaculo:";
            // 
            // dgv_ubicacion
            // 
            this.dgv_ubicacion.AllowUserToDeleteRows = false;
            this.dgv_ubicacion.AllowUserToResizeColumns = false;
            this.dgv_ubicacion.AllowUserToResizeRows = false;
            this.dgv_ubicacion.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.Fill;
            this.dgv_ubicacion.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgv_ubicacion.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.id,
            this.colFila,
            this.colAsiento,
            this.colPrecio,
            this.colTipoUbicacion});
            this.dgv_ubicacion.Location = new System.Drawing.Point(64, 359);
            this.dgv_ubicacion.Name = "dgv_ubicacion";
            this.dgv_ubicacion.Size = new System.Drawing.Size(614, 249);
            this.dgv_ubicacion.TabIndex = 106;
            this.dgv_ubicacion.CellContentClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.dgv_ubicacion_CellContentClick);
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(61, 334);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(69, 13);
            this.label4.TabIndex = 107;
            this.label4.Text = "Ubicaciones:";
            // 
            // checkBox1
            // 
            this.checkBox1.AutoSize = true;
            this.checkBox1.Location = new System.Drawing.Point(148, 333);
            this.checkBox1.Name = "checkBox1";
            this.checkBox1.Size = new System.Drawing.Size(142, 17);
            this.checkBox1.TabIndex = 108;
            this.checkBox1.Text = "Ubicaciones sin numerar";
            this.checkBox1.UseVisualStyleBackColor = true;
            this.checkBox1.CheckedChanged += new System.EventHandler(this.checkBox1_CheckedChanged);
            // 
            // btBorrador
            // 
            this.btBorrador.Location = new System.Drawing.Point(253, 617);
            this.btBorrador.Name = "btBorrador";
            this.btBorrador.Size = new System.Drawing.Size(75, 23);
            this.btBorrador.TabIndex = 109;
            this.btBorrador.Text = "Borrador";
            this.btBorrador.UseVisualStyleBackColor = true;
            this.btBorrador.Click += new System.EventHandler(this.btBorrador_Click);
            // 
            // dgv_fecha
            // 
            this.dgv_fecha.AllowUserToDeleteRows = false;
            this.dgv_fecha.AllowUserToResizeColumns = false;
            this.dgv_fecha.AllowUserToResizeRows = false;
            this.dgv_fecha.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.Fill;
            this.dgv_fecha.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgv_fecha.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.colFecha,
            this.colHora});
            this.dgv_fecha.Location = new System.Drawing.Point(64, 142);
            this.dgv_fecha.Name = "dgv_fecha";
            this.dgv_fecha.Size = new System.Drawing.Size(298, 176);
            this.dgv_fecha.TabIndex = 110;
            // 
            // colFecha
            // 
            this.colFecha.HeaderText = "Fecha";
            this.colFecha.Name = "colFecha";
            // 
            // colHora
            // 
            this.colHora.HeaderText = "Hora";
            this.colHora.Name = "colHora";
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Location = new System.Drawing.Point(392, 81);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(39, 13);
            this.label5.TabIndex = 111;
            this.label5.Text = "Rubro:";
            // 
            // cmb_rubro
            // 
            this.cmb_rubro.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cmb_rubro.FormattingEnabled = true;
            this.cmb_rubro.Location = new System.Drawing.Point(493, 78);
            this.cmb_rubro.Name = "cmb_rubro";
            this.cmb_rubro.Size = new System.Drawing.Size(185, 21);
            this.cmb_rubro.TabIndex = 112;
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Location = new System.Drawing.Point(392, 116);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(39, 13);
            this.label6.TabIndex = 113;
            this.label6.Text = "Grado:";
            // 
            // cmb_grado
            // 
            this.cmb_grado.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cmb_grado.FormattingEnabled = true;
            this.cmb_grado.Location = new System.Drawing.Point(493, 113);
            this.cmb_grado.Name = "cmb_grado";
            this.cmb_grado.Size = new System.Drawing.Size(185, 21);
            this.cmb_grado.TabIndex = 114;
            // 
            // txt_localidad
            // 
            this.txt_localidad.Location = new System.Drawing.Point(493, 324);
            this.txt_localidad.Name = "txt_localidad";
            this.txt_localidad.Size = new System.Drawing.Size(185, 20);
            this.txt_localidad.TabIndex = 130;
            // 
            // txt_mail
            // 
            this.txt_mail.Location = new System.Drawing.Point(493, 298);
            this.txt_mail.Name = "txt_mail";
            this.txt_mail.Size = new System.Drawing.Size(185, 20);
            this.txt_mail.TabIndex = 129;
            // 
            // txt_cp
            // 
            this.txt_cp.Location = new System.Drawing.Point(493, 246);
            this.txt_cp.Name = "txt_cp";
            this.txt_cp.Size = new System.Drawing.Size(185, 20);
            this.txt_cp.TabIndex = 127;
            // 
            // txt_departamento
            // 
            this.txt_departamento.Location = new System.Drawing.Point(493, 220);
            this.txt_departamento.Name = "txt_departamento";
            this.txt_departamento.Size = new System.Drawing.Size(185, 20);
            this.txt_departamento.TabIndex = 126;
            // 
            // txt_calle
            // 
            this.txt_calle.Location = new System.Drawing.Point(493, 142);
            this.txt_calle.Name = "txt_calle";
            this.txt_calle.Size = new System.Drawing.Size(185, 20);
            this.txt_calle.TabIndex = 123;
            // 
            // label10
            // 
            this.label10.AutoSize = true;
            this.label10.Location = new System.Drawing.Point(392, 331);
            this.label10.Name = "label10";
            this.label10.Size = new System.Drawing.Size(56, 13);
            this.label10.TabIndex = 122;
            this.label10.Text = "Localidad:";
            // 
            // label9
            // 
            this.label9.AutoSize = true;
            this.label9.Location = new System.Drawing.Point(392, 305);
            this.label9.Name = "label9";
            this.label9.Size = new System.Drawing.Size(38, 13);
            this.label9.TabIndex = 121;
            this.label9.Text = "E-mail:";
            // 
            // label8
            // 
            this.label8.AutoSize = true;
            this.label8.Location = new System.Drawing.Point(392, 279);
            this.label8.Name = "label8";
            this.label8.Size = new System.Drawing.Size(52, 13);
            this.label8.TabIndex = 120;
            this.label8.Text = "Teléfono:";
            // 
            // label7
            // 
            this.label7.AutoSize = true;
            this.label7.Location = new System.Drawing.Point(392, 253);
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size(75, 13);
            this.label7.TabIndex = 119;
            this.label7.Text = "Codigo Postal:";
            // 
            // label11
            // 
            this.label11.AutoSize = true;
            this.label11.Location = new System.Drawing.Point(392, 227);
            this.label11.Name = "label11";
            this.label11.Size = new System.Drawing.Size(77, 13);
            this.label11.TabIndex = 118;
            this.label11.Text = "Departamento:";
            // 
            // label12
            // 
            this.label12.AutoSize = true;
            this.label12.Location = new System.Drawing.Point(392, 201);
            this.label12.Name = "label12";
            this.label12.Size = new System.Drawing.Size(30, 13);
            this.label12.TabIndex = 117;
            this.label12.Text = "Piso:";
            // 
            // label13
            // 
            this.label13.AutoSize = true;
            this.label13.Location = new System.Drawing.Point(392, 175);
            this.label13.Name = "label13";
            this.label13.Size = new System.Drawing.Size(47, 13);
            this.label13.TabIndex = 116;
            this.label13.Text = "Numero:";
            // 
            // label14
            // 
            this.label14.AutoSize = true;
            this.label14.Location = new System.Drawing.Point(392, 149);
            this.label14.Name = "label14";
            this.label14.Size = new System.Drawing.Size(33, 13);
            this.label14.TabIndex = 115;
            this.label14.Text = "Calle:";
            // 
            // btPublicar
            // 
            this.btPublicar.Location = new System.Drawing.Point(426, 617);
            this.btPublicar.Name = "btPublicar";
            this.btPublicar.Size = new System.Drawing.Size(75, 23);
            this.btPublicar.TabIndex = 131;
            this.btPublicar.Text = "Publicar";
            this.btPublicar.UseVisualStyleBackColor = true;
            this.btPublicar.Click += new System.EventHandler(this.button1_Click);
            // 
            // txt_tel
            // 
            this.txt_tel.Location = new System.Drawing.Point(493, 272);
            this.txt_tel.Name = "txt_tel";
            this.txt_tel.Size = new System.Drawing.Size(185, 20);
            this.txt_tel.TabIndex = 128;
            // 
            // txt_piso
            // 
            this.txt_piso.Location = new System.Drawing.Point(493, 194);
            this.txt_piso.Name = "txt_piso";
            this.txt_piso.Size = new System.Drawing.Size(185, 20);
            this.txt_piso.TabIndex = 125;
            // 
            // txt_numero
            // 
            this.txt_numero.Location = new System.Drawing.Point(493, 168);
            this.txt_numero.Name = "txt_numero";
            this.txt_numero.Size = new System.Drawing.Size(185, 20);
            this.txt_numero.TabIndex = 124;
            // 
            // id
            // 
            this.id.HeaderText = "id";
            this.id.Name = "id";
            this.id.Visible = false;
            // 
            // colFila
            // 
            this.colFila.HeaderText = "Fila";
            this.colFila.Name = "colFila";
            // 
            // colAsiento
            // 
            this.colAsiento.HeaderText = "Asiento";
            this.colAsiento.Name = "colAsiento";
            // 
            // colPrecio
            // 
            this.colPrecio.HeaderText = "Precio";
            this.colPrecio.Name = "colPrecio";
            // 
            // colTipoUbicacion
            // 
            this.colTipoUbicacion.HeaderText = "TipoUbicacion";
            this.colTipoUbicacion.Name = "colTipoUbicacion";
            this.colTipoUbicacion.Resizable = System.Windows.Forms.DataGridViewTriState.True;
            // 
            // FormEditarPublicacion
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(746, 652);
            this.Controls.Add(this.btPublicar);
            this.Controls.Add(this.txt_localidad);
            this.Controls.Add(this.txt_mail);
            this.Controls.Add(this.txt_tel);
            this.Controls.Add(this.txt_cp);
            this.Controls.Add(this.txt_departamento);
            this.Controls.Add(this.txt_piso);
            this.Controls.Add(this.txt_numero);
            this.Controls.Add(this.txt_calle);
            this.Controls.Add(this.label10);
            this.Controls.Add(this.label9);
            this.Controls.Add(this.label8);
            this.Controls.Add(this.label7);
            this.Controls.Add(this.label11);
            this.Controls.Add(this.label12);
            this.Controls.Add(this.label13);
            this.Controls.Add(this.label14);
            this.Controls.Add(this.cmb_grado);
            this.Controls.Add(this.label6);
            this.Controls.Add(this.cmb_rubro);
            this.Controls.Add(this.label5);
            this.Controls.Add(this.dgv_fecha);
            this.Controls.Add(this.btBorrador);
            this.Controls.Add(this.checkBox1);
            this.Controls.Add(this.label4);
            this.Controls.Add(this.dgv_ubicacion);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.txt_desc);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.label2);
            this.Name = "FormEditarPublicacion";
            this.Text = "Editar Publicación";
            ((System.ComponentModel.ISupportInitialize)(this.dgv_ubicacion)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.dgv_fecha)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.TextBox txt_desc;
        private System.Windows.Forms.Label label3;
        public System.Windows.Forms.DataGridView dgv_ubicacion;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.CheckBox checkBox1;
        private System.Windows.Forms.Button btBorrador;
        public System.Windows.Forms.DataGridView dgv_fecha;
        private System.Windows.Forms.DataGridViewTextBoxColumn colFecha;
        private System.Windows.Forms.DataGridViewTextBoxColumn colHora;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.ComboBox cmb_rubro;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.ComboBox cmb_grado;
        private System.Windows.Forms.TextBox txt_localidad;
        private System.Windows.Forms.TextBox txt_mail;
        private NumericTextBox txt_tel;
        private System.Windows.Forms.TextBox txt_cp;
        private System.Windows.Forms.TextBox txt_departamento;
        private NumericTextBox txt_piso;
        private NumericTextBox txt_numero;
        private System.Windows.Forms.TextBox txt_calle;
        private System.Windows.Forms.Label label10;
        private System.Windows.Forms.Label label9;
        private System.Windows.Forms.Label label8;
        private System.Windows.Forms.Label label7;
        private System.Windows.Forms.Label label11;
        private System.Windows.Forms.Label label12;
        private System.Windows.Forms.Label label13;
        private System.Windows.Forms.Label label14;
        private System.Windows.Forms.Button btPublicar;
        private System.Windows.Forms.DataGridViewTextBoxColumn id;
        private System.Windows.Forms.DataGridViewTextBoxColumn colFila;
        private System.Windows.Forms.DataGridViewTextBoxColumn colAsiento;
        private System.Windows.Forms.DataGridViewTextBoxColumn colPrecio;
        private System.Windows.Forms.DataGridViewComboBoxColumn colTipoUbicacion;
    }
}