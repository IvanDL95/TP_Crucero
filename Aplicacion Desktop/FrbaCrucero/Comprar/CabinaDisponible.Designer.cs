namespace FrbaCrucero.Compra_Entrada
{
    partial class UbicacionDisponible
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
            this.cmb_tipo = new System.Windows.Forms.ComboBox();
            this.label7 = new System.Windows.Forms.Label();
            this.dgv_ubicacion = new System.Windows.Forms.DataGridView();
            this.id = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.colPiso = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.colNumero = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.colPrecio = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.colTipoCabina = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.cab_via_id = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.btComprar = new System.Windows.Forms.Button();
            this.btAgregarUbicacion = new System.Windows.Forms.Button();
            this.label6 = new System.Windows.Forms.Label();
            this.btUbicDisponibles = new System.Windows.Forms.Button();
            ((System.ComponentModel.ISupportInitialize)(this.dgv_ubicacion)).BeginInit();
            this.SuspendLayout();
            // 
            // cmb_tipo
            // 
            this.cmb_tipo.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cmb_tipo.FormattingEnabled = true;
            this.cmb_tipo.Location = new System.Drawing.Point(147, 29);
            this.cmb_tipo.Name = "cmb_tipo";
            this.cmb_tipo.Size = new System.Drawing.Size(133, 21);
            this.cmb_tipo.TabIndex = 125;
            // 
            // label7
            // 
            this.label7.AutoSize = true;
            this.label7.Location = new System.Drawing.Point(49, 32);
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size(67, 13);
            this.label7.TabIndex = 124;
            this.label7.Text = "Tipo Cabina:";
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
            this.colPiso,
            this.colNumero,
            this.colPrecio,
            this.colTipoCabina,
            this.cab_via_id});
            this.dgv_ubicacion.Location = new System.Drawing.Point(22, 102);
            this.dgv_ubicacion.MultiSelect = false;
            this.dgv_ubicacion.Name = "dgv_ubicacion";
            this.dgv_ubicacion.ReadOnly = true;
            this.dgv_ubicacion.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.dgv_ubicacion.Size = new System.Drawing.Size(523, 336);
            this.dgv_ubicacion.TabIndex = 123;
            // 
            // id
            // 
            this.id.HeaderText = "id";
            this.id.Name = "id";
            this.id.ReadOnly = true;
            this.id.Visible = false;
            // 
            // colPiso
            // 
            this.colPiso.HeaderText = "Piso";
            this.colPiso.Name = "colPiso";
            this.colPiso.ReadOnly = true;
            // 
            // colNumero
            // 
            this.colNumero.HeaderText = "Numero";
            this.colNumero.Name = "colNumero";
            this.colNumero.ReadOnly = true;
            // 
            // colPrecio
            // 
            this.colPrecio.HeaderText = "Precio";
            this.colPrecio.Name = "colPrecio";
            this.colPrecio.ReadOnly = true;
            // 
            // colTipoCabina
            // 
            this.colTipoCabina.HeaderText = "TipoCabina";
            this.colTipoCabina.Name = "colTipoCabina";
            this.colTipoCabina.ReadOnly = true;
            this.colTipoCabina.Resizable = System.Windows.Forms.DataGridViewTriState.True;
            this.colTipoCabina.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.NotSortable;
            this.colTipoCabina.Visible = false;
            // 
            // cab_via_id
            // 
            this.cab_via_id.HeaderText = "cab_via_id";
            this.cab_via_id.Name = "cab_via_id";
            this.cab_via_id.ReadOnly = true;
            this.cab_via_id.Visible = false;
            // 
            // btComprar
            // 
            this.btComprar.Location = new System.Drawing.Point(193, 511);
            this.btComprar.Name = "btComprar";
            this.btComprar.Size = new System.Drawing.Size(162, 23);
            this.btComprar.TabIndex = 122;
            this.btComprar.Text = "Finalizar Comprar/Reserva";
            this.btComprar.UseVisualStyleBackColor = true;
            this.btComprar.Click += new System.EventHandler(this.btComprar_Click);
            // 
            // btAgregarUbicacion
            // 
            this.btAgregarUbicacion.Location = new System.Drawing.Point(193, 464);
            this.btAgregarUbicacion.Name = "btAgregarUbicacion";
            this.btAgregarUbicacion.Size = new System.Drawing.Size(162, 23);
            this.btAgregarUbicacion.TabIndex = 121;
            this.btAgregarUbicacion.Text = "Agregar a la compra/reserva";
            this.btAgregarUbicacion.UseVisualStyleBackColor = true;
            this.btAgregarUbicacion.Click += new System.EventHandler(this.btAgregarUbicacion_Click);
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Location = new System.Drawing.Point(219, 76);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(103, 13);
            this.label6.TabIndex = 120;
            this.label6.Text = "Cabinas disponibles:";
            // 
            // btUbicDisponibles
            // 
            this.btUbicDisponibles.Location = new System.Drawing.Point(368, 27);
            this.btUbicDisponibles.Name = "btUbicDisponibles";
            this.btUbicDisponibles.Size = new System.Drawing.Size(75, 23);
            this.btUbicDisponibles.TabIndex = 126;
            this.btUbicDisponibles.Text = "Seleccionar";
            this.btUbicDisponibles.UseVisualStyleBackColor = true;
            this.btUbicDisponibles.Click += new System.EventHandler(this.btUbicDisponibles_Click);
            // 
            // UbicacionDisponible
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(569, 546);
            this.Controls.Add(this.btUbicDisponibles);
            this.Controls.Add(this.cmb_tipo);
            this.Controls.Add(this.label7);
            this.Controls.Add(this.dgv_ubicacion);
            this.Controls.Add(this.btComprar);
            this.Controls.Add(this.btAgregarUbicacion);
            this.Controls.Add(this.label6);
            this.Name = "UbicacionDisponible";
            this.Text = "Cabina Disponible";
            ((System.ComponentModel.ISupportInitialize)(this.dgv_ubicacion)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.ComboBox cmb_tipo;
        private System.Windows.Forms.Label label7;
        public System.Windows.Forms.DataGridView dgv_ubicacion;
        private System.Windows.Forms.Button btComprar;
        private System.Windows.Forms.Button btAgregarUbicacion;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.Button btUbicDisponibles;
        private System.Windows.Forms.DataGridViewTextBoxColumn id;
        private System.Windows.Forms.DataGridViewTextBoxColumn colPiso;
        private System.Windows.Forms.DataGridViewTextBoxColumn colNumero;
        private System.Windows.Forms.DataGridViewTextBoxColumn colPrecio;
        private System.Windows.Forms.DataGridViewTextBoxColumn colTipoCabina;
        private System.Windows.Forms.DataGridViewTextBoxColumn cab_via_id;
    }
}