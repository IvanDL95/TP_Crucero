namespace FrbaCrucero.ABMCrucero
{
    partial class FormAmCrucero
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
            this.txt_id = new System.Windows.Forms.TextBox();
            this.dgv_cabinas = new System.Windows.Forms.DataGridView();
            this.label4 = new System.Windows.Forms.Label();
            this.btAceptar = new System.Windows.Forms.Button();
            this.label5 = new System.Windows.Forms.Label();
            this.cmb_servicio = new System.Windows.Forms.ComboBox();
            this.label6 = new System.Windows.Forms.Label();
            this.cmb_fabricante = new System.Windows.Forms.ComboBox();
            this.txt_modelo = new System.Windows.Forms.TextBox();
            this.label14 = new System.Windows.Forms.Label();
            this.btCancelar = new System.Windows.Forms.Button();
            this.colPiso = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.colCantidad = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.colTipoCabina = new System.Windows.Forms.DataGridViewComboBoxColumn();
            ((System.ComponentModel.ISupportInitialize)(this.dgv_cabinas)).BeginInit();
            this.SuspendLayout();
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Font = new System.Drawing.Font("Microsoft Sans Serif", 20.25F, ((System.Drawing.FontStyle)((System.Drawing.FontStyle.Bold | System.Drawing.FontStyle.Underline))), System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label2.Location = new System.Drawing.Point(296, 9);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(168, 31);
            this.label2.TabIndex = 101;
            this.label2.Text = "AM Crucero";
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(64, 81);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(73, 13);
            this.label1.TabIndex = 102;
            this.label1.Text = "Identificacion:";
            // 
            // txt_id
            // 
            this.txt_id.Location = new System.Drawing.Point(165, 78);
            this.txt_id.Name = "txt_id";
            this.txt_id.Size = new System.Drawing.Size(185, 20);
            this.txt_id.TabIndex = 104;
            // 
            // dgv_cabinas
            // 
            this.dgv_cabinas.AllowUserToDeleteRows = false;
            this.dgv_cabinas.AllowUserToResizeColumns = false;
            this.dgv_cabinas.AllowUserToResizeRows = false;
            this.dgv_cabinas.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.Fill;
            this.dgv_cabinas.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgv_cabinas.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.colPiso,
            this.colCantidad,
            this.colTipoCabina});
            this.dgv_cabinas.Location = new System.Drawing.Point(64, 165);
            this.dgv_cabinas.Name = "dgv_cabinas";
            this.dgv_cabinas.Size = new System.Drawing.Size(614, 249);
            this.dgv_cabinas.TabIndex = 106;
            this.dgv_cabinas.CellContentClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.dgv_ubicacion_CellContentClick);
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(64, 139);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(48, 13);
            this.label4.TabIndex = 107;
            this.label4.Text = "Cabinas:";
            // 
            // btAceptar
            // 
            this.btAceptar.Location = new System.Drawing.Point(264, 423);
            this.btAceptar.Name = "btAceptar";
            this.btAceptar.Size = new System.Drawing.Size(75, 23);
            this.btAceptar.TabIndex = 109;
            this.btAceptar.Text = "Aceptar";
            this.btAceptar.UseVisualStyleBackColor = true;
            this.btAceptar.Click += new System.EventHandler(this.btAceptar_Click);
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Location = new System.Drawing.Point(392, 81);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(72, 13);
            this.label5.TabIndex = 111;
            this.label5.Text = "Tipo Servicio:";
            // 
            // cmb_servicio
            // 
            this.cmb_servicio.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cmb_servicio.FormattingEnabled = true;
            this.cmb_servicio.Location = new System.Drawing.Point(493, 78);
            this.cmb_servicio.Name = "cmb_servicio";
            this.cmb_servicio.Size = new System.Drawing.Size(185, 21);
            this.cmb_servicio.TabIndex = 112;
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Location = new System.Drawing.Point(392, 116);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(40, 13);
            this.label6.TabIndex = 113;
            this.label6.Text = "Marca:";
            // 
            // cmb_fabricante
            // 
            this.cmb_fabricante.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cmb_fabricante.FormattingEnabled = true;
            this.cmb_fabricante.Location = new System.Drawing.Point(493, 113);
            this.cmb_fabricante.Name = "cmb_fabricante";
            this.cmb_fabricante.Size = new System.Drawing.Size(185, 21);
            this.cmb_fabricante.TabIndex = 114;
            // 
            // txt_modelo
            // 
            this.txt_modelo.Location = new System.Drawing.Point(165, 106);
            this.txt_modelo.Name = "txt_modelo";
            this.txt_modelo.Size = new System.Drawing.Size(185, 20);
            this.txt_modelo.TabIndex = 123;
            // 
            // label14
            // 
            this.label14.AutoSize = true;
            this.label14.Location = new System.Drawing.Point(64, 113);
            this.label14.Name = "label14";
            this.label14.Size = new System.Drawing.Size(45, 13);
            this.label14.TabIndex = 115;
            this.label14.Text = "Modelo:";
            // 
            // btCancelar
            // 
            this.btCancelar.Location = new System.Drawing.Point(407, 423);
            this.btCancelar.Name = "btCancelar";
            this.btCancelar.Size = new System.Drawing.Size(75, 23);
            this.btCancelar.TabIndex = 131;
            this.btCancelar.Text = "Cancelar";
            this.btCancelar.UseVisualStyleBackColor = true;
            this.btCancelar.Click += new System.EventHandler(this.btCancelar_Click);
            // 
            // colPiso
            // 
            this.colPiso.HeaderText = "Piso";
            this.colPiso.Name = "colPiso";
            // 
            // colCantidad
            // 
            this.colCantidad.HeaderText = "Cantidad";
            this.colCantidad.Name = "colCantidad";
            // 
            // colTipoCabina
            // 
            this.colTipoCabina.HeaderText = "TipoCabina";
            this.colTipoCabina.Name = "colTipoCabina";
            this.colTipoCabina.Resizable = System.Windows.Forms.DataGridViewTriState.True;
            // 
            // FormAmCrucero
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(746, 468);
            this.Controls.Add(this.btCancelar);
            this.Controls.Add(this.txt_modelo);
            this.Controls.Add(this.label14);
            this.Controls.Add(this.cmb_fabricante);
            this.Controls.Add(this.label6);
            this.Controls.Add(this.cmb_servicio);
            this.Controls.Add(this.label5);
            this.Controls.Add(this.btAceptar);
            this.Controls.Add(this.label4);
            this.Controls.Add(this.dgv_cabinas);
            this.Controls.Add(this.txt_id);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.label2);
            this.Name = "FormAmCrucero";
            this.Text = "AM Crucero";
            ((System.ComponentModel.ISupportInitialize)(this.dgv_cabinas)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.TextBox txt_id;
        public System.Windows.Forms.DataGridView dgv_cabinas;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.Button btAceptar;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.ComboBox cmb_servicio;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.ComboBox cmb_fabricante;
        private System.Windows.Forms.TextBox txt_modelo;
        private System.Windows.Forms.Label label14;
        private System.Windows.Forms.Button btCancelar;
        private System.Windows.Forms.DataGridViewTextBoxColumn colPiso;
        private System.Windows.Forms.DataGridViewTextBoxColumn colCantidad;
        private System.Windows.Forms.DataGridViewComboBoxColumn colTipoCabina;
    }
}