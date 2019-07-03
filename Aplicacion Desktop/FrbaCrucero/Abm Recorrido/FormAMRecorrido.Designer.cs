namespace FrbaCrucero.ABMRecorrido
{
    partial class FormAmRecorrido
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
            this.dgv_tramos = new System.Windows.Forms.DataGridView();
            this.colPuertoSalida = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.colPuertoDestino = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.colPrecioBase = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.label4 = new System.Windows.Forms.Label();
            this.btAceptar = new System.Windows.Forms.Button();
            this.btEliminar = new System.Windows.Forms.Button();
            this.btCancelar = new System.Windows.Forms.Button();
            this.label5 = new System.Windows.Forms.Label();
            this.cmb_puertoSalida = new System.Windows.Forms.ComboBox();
            this.label6 = new System.Windows.Forms.Label();
            this.cmb_puertoDestino = new System.Windows.Forms.ComboBox();
            this.label7 = new System.Windows.Forms.Label();
            this.txt_id = new FrbaCrucero.NumericTextBox();
            this.label14 = new System.Windows.Forms.Label();
            ((System.ComponentModel.ISupportInitialize)(this.dgv_tramos)).BeginInit();
            this.SuspendLayout();
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Font = new System.Drawing.Font("Microsoft Sans Serif", 20.25F, ((System.Drawing.FontStyle)((System.Drawing.FontStyle.Bold | System.Drawing.FontStyle.Underline))), System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label2.Location = new System.Drawing.Point(450, 9);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(191, 31);
            this.label2.TabIndex = 101;
            this.label2.Text = "AM Recorrido";
            // 
            // dgv_tramos
            // 
            this.dgv_tramos.AllowUserToDeleteRows = false;
            this.dgv_tramos.AllowUserToResizeColumns = false;
            this.dgv_tramos.AllowUserToResizeRows = false;
            this.dgv_tramos.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.Fill;
            this.dgv_tramos.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgv_tramos.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.colPuertoSalida,
            this.colPuertoDestino,
            this.colPrecioBase});
            this.dgv_tramos.Location = new System.Drawing.Point(64, 145);
            this.dgv_tramos.Name = "dgv_tramos";
            this.dgv_tramos.Size = new System.Drawing.Size(946, 269);
            this.dgv_tramos.TabIndex = 106;
            // 
            // colPuertoSalida
            // 
            this.colPuertoSalida.HeaderText = "Puerto Salida";
            this.colPuertoSalida.Name = "colPuertoSalida";
            // 
            // colPuertoDestino
            // 
            this.colPuertoDestino.HeaderText = "Puerto Destino";
            this.colPuertoDestino.Name = "colPuertoDestino";
            // 
            // colPrecioBase
            // 
            this.colPrecioBase.HeaderText = "Precio Tramo";
            this.colPrecioBase.Name = "colPrecioBase";
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Font = new System.Drawing.Font("Microsoft Sans Serif", 15F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label4.Location = new System.Drawing.Point(492, 6);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(79, 25);
            this.label4.TabIndex = 107;
            this.label4.Text = "Tramos";
            // 
            // btAceptar
            // 
            this.btAceptar.Location = new System.Drawing.Point(184, 420);
            this.btAceptar.Name = "btAceptar";
            this.btAceptar.Size = new System.Drawing.Size(75, 23);
            this.btAceptar.TabIndex = 109;
            this.btAceptar.Text = "Aceptar";
            this.btAceptar.UseVisualStyleBackColor = true;
            this.btAceptar.Click += new System.EventHandler(this.btAceptar_Click);
            // 
            // btEliminar
            // 
            this.btEliminar.Location = new System.Drawing.Point(497, 420);
            this.btEliminar.Name = "btEliminar";
            this.btEliminar.Size = new System.Drawing.Size(75, 23);
            this.btEliminar.TabIndex = 110;
            this.btEliminar.Text = "Eliminar";
            this.btEliminar.UseVisualStyleBackColor = true;
            this.btEliminar.Click += new System.EventHandler(this.btEliminar_Click);
            // 
            // btCancelar
            // 
            this.btCancelar.Location = new System.Drawing.Point(812, 420);
            this.btCancelar.Name = "btCancelar";
            this.btCancelar.Size = new System.Drawing.Size(75, 23);
            this.btCancelar.TabIndex = 131;
            this.btCancelar.Text = "Cancelar";
            this.btCancelar.UseVisualStyleBackColor = true;
            this.btCancelar.Click += new System.EventHandler(this.btCancelar_Click);
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Location = new System.Drawing.Point(61, 18);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(73, 13);
            this.label5.TabIndex = 111;
            this.label5.Text = "Puerto Salida:";
            // 
            // cmb_puertoSalida
            // 
            this.cmb_puertoSalida.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cmb_puertoSalida.FormattingEnabled = true;
            this.cmb_puertoSalida.Location = new System.Drawing.Point(140, 15);
            this.cmb_puertoSalida.Name = "cmb_puertoSalida";
            this.cmb_puertoSalida.Size = new System.Drawing.Size(250, 21);
            this.cmb_puertoSalida.TabIndex = 112;
            this.cmb_puertoSalida.SelectedIndexChanged += new System.EventHandler(this.cmb_puertoSalida_SelectedIndexChanged);
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Location = new System.Drawing.Point(672, 18);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(82, 13);
            this.label6.TabIndex = 113;
            this.label6.Text = "Puerto Llegada:";
            // 
            // cmb_puertoDestino
            // 
            this.cmb_puertoDestino.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cmb_puertoDestino.FormattingEnabled = true;
            this.cmb_puertoDestino.Location = new System.Drawing.Point(760, 15);
            this.cmb_puertoDestino.Name = "cmb_puertoDestino";
            this.cmb_puertoDestino.Size = new System.Drawing.Size(250, 21);
            this.cmb_puertoDestino.TabIndex = 114;
            this.cmb_puertoDestino.SelectedIndexChanged += new System.EventHandler(this.cmb_puertoDestino_SelectedIndexChanged);
            // 
            // label7
            // 
            this.label7.AutoSize = true;
            this.label7.Location = new System.Drawing.Point(322, 83);
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size(68, 13);
            this.label7.TabIndex = 133;
            this.label7.Text = "Id Recorrido:";
            // 
            // txt_id
            // 
            this.txt_id.Location = new System.Drawing.Point(396, 80);
            this.txt_id.Name = "txt_id";
            this.txt_id.Size = new System.Drawing.Size(274, 20);
            this.txt_id.TabIndex = 132;
            // 
            // label14
            // 
            this.label14.Location = new System.Drawing.Point(0, 0);
            this.label14.Name = "label14";
            this.label14.Size = new System.Drawing.Size(100, 23);
            this.label14.TabIndex = 0;
            // 
            // FormAmRecorrido
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1091, 450);
            this.Controls.Add(this.btAceptar);
            this.Controls.Add(this.btCancelar);
            this.Controls.Add(this.btEliminar);
            this.Controls.Add(this.txt_id);
            this.Controls.Add(this.label7);
            this.Controls.Add(this.cmb_puertoDestino);
            this.Controls.Add(this.label6);
            this.Controls.Add(this.cmb_puertoSalida);
            this.Controls.Add(this.label5);
            this.Controls.Add(this.label4);
            this.Controls.Add(this.dgv_tramos);
            this.Name = "FormAmRecorrido";
            this.Text = "AM Recorrido";
            this.Load += new System.EventHandler(this.FormAmRecorrido_Load);
            ((System.ComponentModel.ISupportInitialize)(this.dgv_tramos)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label label2;
        public System.Windows.Forms.DataGridView dgv_tramos;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.Button btAceptar;
        private System.Windows.Forms.Button btEliminar;
        private System.Windows.Forms.Button btCancelar;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.ComboBox cmb_puertoSalida;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.ComboBox cmb_puertoDestino;
        private System.Windows.Forms.Label label7;
        private NumericTextBox txt_id;
        private System.Windows.Forms.Label label14; 
        private System.Windows.Forms.DataGridViewTextBoxColumn colPuertoSalida;
        private System.Windows.Forms.DataGridViewTextBoxColumn colPuertoDestino;
        private System.Windows.Forms.DataGridViewComboBoxColumn colTipoCabina;
        private System.Windows.Forms.DataGridViewTextBoxColumn colPrecioBase;
    }
}