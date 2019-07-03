namespace FrbaCrucero.Compra_Entrada
{
    partial class FormCompraEntradas
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
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.cmb_pue_hasta = new System.Windows.Forms.ComboBox();
            this.cmb_pue_desde = new System.Windows.Forms.ComboBox();
            this.label1 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.rb_reserva = new System.Windows.Forms.RadioButton();
            this.rb_compra = new System.Windows.Forms.RadioButton();
            this.dtpHasta = new System.Windows.Forms.DateTimePicker();
            this.dtpDe = new System.Windows.Forms.DateTimePicker();
            this.label5 = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.label4 = new System.Windows.Forms.Label();
            this.dgv_publicacion = new System.Windows.Forms.DataGridView();
            this.btUbicDisponibles = new System.Windows.Forms.Button();
            this.bt_buscar = new System.Windows.Forms.Button();
            this.groupBox1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgv_publicacion)).BeginInit();
            this.SuspendLayout();
            // 
            // groupBox1
            // 
            this.groupBox1.Controls.Add(this.cmb_pue_hasta);
            this.groupBox1.Controls.Add(this.cmb_pue_desde);
            this.groupBox1.Controls.Add(this.label1);
            this.groupBox1.Controls.Add(this.label2);
            this.groupBox1.Controls.Add(this.rb_reserva);
            this.groupBox1.Controls.Add(this.rb_compra);
            this.groupBox1.Controls.Add(this.dtpHasta);
            this.groupBox1.Controls.Add(this.dtpDe);
            this.groupBox1.Controls.Add(this.label5);
            this.groupBox1.Controls.Add(this.label3);
            this.groupBox1.Location = new System.Drawing.Point(38, 74);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(692, 91);
            this.groupBox1.TabIndex = 29;
            this.groupBox1.TabStop = false;
            // 
            // cmb_pue_hasta
            // 
            this.cmb_pue_hasta.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cmb_pue_hasta.FormattingEnabled = true;
            this.cmb_pue_hasta.Location = new System.Drawing.Point(405, 57);
            this.cmb_pue_hasta.Name = "cmb_pue_hasta";
            this.cmb_pue_hasta.Size = new System.Drawing.Size(185, 21);
            this.cmb_pue_hasta.TabIndex = 118;
            // 
            // cmb_pue_desde
            // 
            this.cmb_pue_desde.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cmb_pue_desde.FormattingEnabled = true;
            this.cmb_pue_desde.Location = new System.Drawing.Point(405, 29);
            this.cmb_pue_desde.Name = "cmb_pue_desde";
            this.cmb_pue_desde.Size = new System.Drawing.Size(185, 21);
            this.cmb_pue_desde.TabIndex = 117;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(324, 34);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(75, 13);
            this.label1.TabIndex = 110;
            this.label1.Text = "Puerto Origen:";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(324, 57);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(80, 13);
            this.label2.TabIndex = 109;
            this.label2.Text = "Puerto Destino:";
            // 
            // rb_reserva
            // 
            this.rb_reserva.AutoSize = true;
            this.rb_reserva.Location = new System.Drawing.Point(612, 54);
            this.rb_reserva.Name = "rb_reserva";
            this.rb_reserva.Size = new System.Drawing.Size(65, 17);
            this.rb_reserva.TabIndex = 108;
            this.rb_reserva.Text = "Reserva";
            this.rb_reserva.UseVisualStyleBackColor = true;
            // 
            // rb_compra
            // 
            this.rb_compra.AutoSize = true;
            this.rb_compra.Checked = true;
            this.rb_compra.Location = new System.Drawing.Point(612, 30);
            this.rb_compra.Name = "rb_compra";
            this.rb_compra.Size = new System.Drawing.Size(61, 17);
            this.rb_compra.TabIndex = 107;
            this.rb_compra.TabStop = true;
            this.rb_compra.Text = "Compra";
            this.rb_compra.UseVisualStyleBackColor = true;
            // 
            // dtpHasta
            // 
            this.dtpHasta.Location = new System.Drawing.Point(90, 54);
            this.dtpHasta.Name = "dtpHasta";
            this.dtpHasta.Size = new System.Drawing.Size(200, 20);
            this.dtpHasta.TabIndex = 105;
            this.dtpHasta.ValueChanged += new System.EventHandler(this.dtpHasta_ValueChanged);
            // 
            // dtpDe
            // 
            this.dtpDe.Location = new System.Drawing.Point(90, 28);
            this.dtpDe.Name = "dtpDe";
            this.dtpDe.Size = new System.Drawing.Size(200, 20);
            this.dtpDe.TabIndex = 104;
            this.dtpDe.Value = new System.DateTime(2018, 1, 1, 0, 0, 0, 0);
            this.dtpDe.ValueChanged += new System.EventHandler(this.dtpDe_ValueChanged);
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Location = new System.Drawing.Point(15, 34);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(70, 13);
            this.label5.TabIndex = 9;
            this.label5.Text = "Fecha salida:";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(15, 60);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(77, 13);
            this.label3.TabIndex = 6;
            this.label3.Text = "Fecha llegada:";
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Font = new System.Drawing.Font("Microsoft Sans Serif", 20.25F, ((System.Drawing.FontStyle)((System.Drawing.FontStyle.Bold | System.Drawing.FontStyle.Underline))), System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label4.Location = new System.Drawing.Point(208, 9);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(253, 31);
            this.label4.TabIndex = 102;
            this.label4.Text = "Comprar Reservar";
            // 
            // dgv_publicacion
            // 
            this.dgv_publicacion.AllowUserToAddRows = false;
            this.dgv_publicacion.AllowUserToDeleteRows = false;
            this.dgv_publicacion.AllowUserToResizeColumns = false;
            this.dgv_publicacion.AllowUserToResizeRows = false;
            this.dgv_publicacion.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgv_publicacion.Location = new System.Drawing.Point(38, 256);
            this.dgv_publicacion.MultiSelect = false;
            this.dgv_publicacion.Name = "dgv_publicacion";
            this.dgv_publicacion.ReadOnly = true;
            this.dgv_publicacion.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.dgv_publicacion.Size = new System.Drawing.Size(614, 243);
            this.dgv_publicacion.TabIndex = 103;
            // 
            // btUbicDisponibles
            // 
            this.btUbicDisponibles.Location = new System.Drawing.Point(670, 355);
            this.btUbicDisponibles.Name = "btUbicDisponibles";
            this.btUbicDisponibles.Size = new System.Drawing.Size(74, 51);
            this.btUbicDisponibles.TabIndex = 116;
            this.btUbicDisponibles.Text = "Ver cabinas disponbies";
            this.btUbicDisponibles.UseVisualStyleBackColor = true;
            this.btUbicDisponibles.Click += new System.EventHandler(this.btUbicDisponibles_Click);
            // 
            // bt_buscar
            // 
            this.bt_buscar.Location = new System.Drawing.Point(308, 199);
            this.bt_buscar.Name = "bt_buscar";
            this.bt_buscar.Size = new System.Drawing.Size(75, 23);
            this.bt_buscar.TabIndex = 117;
            this.bt_buscar.Text = "Buscar";
            this.bt_buscar.UseVisualStyleBackColor = true;
            this.bt_buscar.Click += new System.EventHandler(this.bt_buscar_Click);
            // 
            // FormCompraEntradas
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(758, 528);
            this.Controls.Add(this.bt_buscar);
            this.Controls.Add(this.btUbicDisponibles);
            this.Controls.Add(this.dgv_publicacion);
            this.Controls.Add(this.label4);
            this.Controls.Add(this.groupBox1);
            this.Name = "FormCompraEntradas";
            this.Text = "Comprar";
            this.groupBox1.ResumeLayout(false);
            this.groupBox1.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgv_publicacion)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.DateTimePicker dtpHasta;
        private System.Windows.Forms.DateTimePicker dtpDe;
        private System.Windows.Forms.DataGridView dgv_publicacion;
        private System.Windows.Forms.Button btUbicDisponibles;
        private System.Windows.Forms.RadioButton rb_reserva;
        private System.Windows.Forms.RadioButton rb_compra;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.ComboBox cmb_pue_hasta;
        private System.Windows.Forms.ComboBox cmb_pue_desde;
        private System.Windows.Forms.Button bt_buscar;
    }
}