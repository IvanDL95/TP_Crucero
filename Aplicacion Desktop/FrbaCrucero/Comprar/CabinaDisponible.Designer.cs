namespace FrbaCrucero.Compra_Reservar
{
    partial class CabinaDisponible
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
            this.lb_tipo = new System.Windows.Forms.Label();
            this.dgv_cabina = new System.Windows.Forms.DataGridView();
            this.btComprarReservar = new System.Windows.Forms.Button();
            this.btAgregarCabina = new System.Windows.Forms.Button();
            this.lb_cab_disp = new System.Windows.Forms.Label();
            this.btCabDisponibles = new System.Windows.Forms.Button();
            this.bt_mp = new System.Windows.Forms.Button();
            this.cmb_mp = new System.Windows.Forms.ComboBox();
            this.lb_mp = new System.Windows.Forms.Label();
            this.lb_cuota = new System.Windows.Forms.Label();
            this.cmb_cuota = new System.Windows.Forms.ComboBox();
            this.lb_selec = new System.Windows.Forms.Label();
            this.bt_cuota = new System.Windows.Forms.Button();
            this.colTipoCabina = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.colPiso = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.colNumero = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.colPrecio = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.cab_via_id = new System.Windows.Forms.DataGridViewTextBoxColumn();
            ((System.ComponentModel.ISupportInitialize)(this.dgv_cabina)).BeginInit();
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
            // lb_tipo
            // 
            this.lb_tipo.AutoSize = true;
            this.lb_tipo.Location = new System.Drawing.Point(49, 32);
            this.lb_tipo.Name = "lb_tipo";
            this.lb_tipo.Size = new System.Drawing.Size(67, 13);
            this.lb_tipo.TabIndex = 124;
            this.lb_tipo.Text = "Tipo Cabina:";
            // 
            // dgv_cabina
            // 
            this.dgv_cabina.AllowUserToDeleteRows = false;
            this.dgv_cabina.AllowUserToResizeColumns = false;
            this.dgv_cabina.AllowUserToResizeRows = false;
            this.dgv_cabina.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.Fill;
            this.dgv_cabina.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgv_cabina.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.colTipoCabina,
            this.colPiso,
            this.colNumero,
            this.colPrecio,
            this.cab_via_id});
            this.dgv_cabina.Location = new System.Drawing.Point(22, 102);
            this.dgv_cabina.MultiSelect = false;
            this.dgv_cabina.Name = "dgv_cabina";
            this.dgv_cabina.ReadOnly = true;
            this.dgv_cabina.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.dgv_cabina.Size = new System.Drawing.Size(523, 336);
            this.dgv_cabina.TabIndex = 123;
            // 
            // btComprarReservar
            // 
            this.btComprarReservar.Location = new System.Drawing.Point(193, 511);
            this.btComprarReservar.Name = "btComprarReservar";
            this.btComprarReservar.Size = new System.Drawing.Size(162, 23);
            this.btComprarReservar.TabIndex = 122;
            this.btComprarReservar.Text = "Finalizar Comprar/Reserva";
            this.btComprarReservar.UseVisualStyleBackColor = true;
            this.btComprarReservar.Click += new System.EventHandler(this.btComprar_Click);
            // 
            // btAgregarCabina
            // 
            this.btAgregarCabina.Location = new System.Drawing.Point(193, 464);
            this.btAgregarCabina.Name = "btAgregarCabina";
            this.btAgregarCabina.Size = new System.Drawing.Size(162, 23);
            this.btAgregarCabina.TabIndex = 121;
            this.btAgregarCabina.Text = "Agregar a la compra/reserva";
            this.btAgregarCabina.UseVisualStyleBackColor = true;
            this.btAgregarCabina.Click += new System.EventHandler(this.btAgregarCabina_Click);
            // 
            // lb_cab_disp
            // 
            this.lb_cab_disp.AutoSize = true;
            this.lb_cab_disp.Location = new System.Drawing.Point(219, 76);
            this.lb_cab_disp.Name = "lb_cab_disp";
            this.lb_cab_disp.Size = new System.Drawing.Size(103, 13);
            this.lb_cab_disp.TabIndex = 120;
            this.lb_cab_disp.Text = "Cabinas disponibles:";
            // 
            // btCabDisponibles
            // 
            this.btCabDisponibles.Location = new System.Drawing.Point(368, 27);
            this.btCabDisponibles.Name = "btCabDisponibles";
            this.btCabDisponibles.Size = new System.Drawing.Size(75, 23);
            this.btCabDisponibles.TabIndex = 126;
            this.btCabDisponibles.Text = "Seleccionar";
            this.btCabDisponibles.UseVisualStyleBackColor = true;
            this.btCabDisponibles.Click += new System.EventHandler(this.btCabDisponibles_Click);
            // 
            // bt_mp
            // 
            this.bt_mp.Location = new System.Drawing.Point(368, 574);
            this.bt_mp.Name = "bt_mp";
            this.bt_mp.Size = new System.Drawing.Size(75, 23);
            this.bt_mp.TabIndex = 129;
            this.bt_mp.Text = "Seleccionar";
            this.bt_mp.UseVisualStyleBackColor = true;
            this.bt_mp.Visible = false;
            this.bt_mp.Click += new System.EventHandler(this.bt_mp_Click);
            // 
            // cmb_mp
            // 
            this.cmb_mp.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cmb_mp.FormattingEnabled = true;
            this.cmb_mp.Location = new System.Drawing.Point(147, 576);
            this.cmb_mp.Name = "cmb_mp";
            this.cmb_mp.Size = new System.Drawing.Size(133, 21);
            this.cmb_mp.TabIndex = 128;
            this.cmb_mp.Visible = false;
            // 
            // lb_mp
            // 
            this.lb_mp.AutoSize = true;
            this.lb_mp.Location = new System.Drawing.Point(49, 579);
            this.lb_mp.Name = "lb_mp";
            this.lb_mp.Size = new System.Drawing.Size(81, 13);
            this.lb_mp.TabIndex = 127;
            this.lb_mp.Text = "Medio de pago:";
            this.lb_mp.Visible = false;
            // 
            // lb_cuota
            // 
            this.lb_cuota.AutoSize = true;
            this.lb_cuota.Location = new System.Drawing.Point(49, 607);
            this.lb_cuota.Name = "lb_cuota";
            this.lb_cuota.Size = new System.Drawing.Size(43, 13);
            this.lb_cuota.TabIndex = 130;
            this.lb_cuota.Text = "Cuotas:";
            this.lb_cuota.Visible = false;
            // 
            // cmb_cuota
            // 
            this.cmb_cuota.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cmb_cuota.FormattingEnabled = true;
            this.cmb_cuota.Items.AddRange(new object[] {
            "1",
            "3",
            "6",
            "12"});
            this.cmb_cuota.Location = new System.Drawing.Point(147, 604);
            this.cmb_cuota.Name = "cmb_cuota";
            this.cmb_cuota.Size = new System.Drawing.Size(133, 21);
            this.cmb_cuota.TabIndex = 131;
            this.cmb_cuota.Visible = false;
            // 
            // lb_selec
            // 
            this.lb_selec.AutoSize = true;
            this.lb_selec.Location = new System.Drawing.Point(49, 548);
            this.lb_selec.Name = "lb_selec";
            this.lb_selec.Size = new System.Drawing.Size(136, 13);
            this.lb_selec.TabIndex = 132;
            this.lb_selec.Text = "Seleccione medio de pago:";
            this.lb_selec.Visible = false;
            // 
            // bt_cuota
            // 
            this.bt_cuota.Location = new System.Drawing.Point(368, 602);
            this.bt_cuota.Name = "bt_cuota";
            this.bt_cuota.Size = new System.Drawing.Size(75, 23);
            this.bt_cuota.TabIndex = 133;
            this.bt_cuota.Text = "Seleccionar";
            this.bt_cuota.UseVisualStyleBackColor = true;
            this.bt_cuota.Visible = false;
            this.bt_cuota.Click += new System.EventHandler(this.bt_cuota_Click);
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
            // cab_via_id
            // 
            this.cab_via_id.HeaderText = "cab_via_id";
            this.cab_via_id.Name = "cab_via_id";
            this.cab_via_id.ReadOnly = true;
            this.cab_via_id.Visible = false;
            // 
            // CabinaDisponible
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(569, 638);
            this.Controls.Add(this.bt_cuota);
            this.Controls.Add(this.lb_selec);
            this.Controls.Add(this.cmb_cuota);
            this.Controls.Add(this.lb_cuota);
            this.Controls.Add(this.bt_mp);
            this.Controls.Add(this.cmb_mp);
            this.Controls.Add(this.lb_mp);
            this.Controls.Add(this.btCabDisponibles);
            this.Controls.Add(this.cmb_tipo);
            this.Controls.Add(this.lb_tipo);
            this.Controls.Add(this.dgv_cabina);
            this.Controls.Add(this.btComprarReservar);
            this.Controls.Add(this.btAgregarCabina);
            this.Controls.Add(this.lb_cab_disp);
            this.Name = "CabinaDisponible";
            this.Text = "Cabina Disponible";
            ((System.ComponentModel.ISupportInitialize)(this.dgv_cabina)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.ComboBox cmb_tipo;
        private System.Windows.Forms.Label lb_tipo;
        public System.Windows.Forms.DataGridView dgv_cabina;
        private System.Windows.Forms.Button btComprarReservar;
        private System.Windows.Forms.Button btAgregarCabina;
        private System.Windows.Forms.Label lb_cab_disp;
        private System.Windows.Forms.Button btCabDisponibles;
        private System.Windows.Forms.Button bt_mp;
        private System.Windows.Forms.ComboBox cmb_mp;
        private System.Windows.Forms.Label lb_mp;
        private System.Windows.Forms.Label lb_cuota;
        private System.Windows.Forms.ComboBox cmb_cuota;
        private System.Windows.Forms.Label lb_selec;
        private System.Windows.Forms.Button bt_cuota;
        private System.Windows.Forms.DataGridViewTextBoxColumn colTipoCabina;
        private System.Windows.Forms.DataGridViewTextBoxColumn colPiso;
        private System.Windows.Forms.DataGridViewTextBoxColumn colNumero;
        private System.Windows.Forms.DataGridViewTextBoxColumn colPrecio;
        private System.Windows.Forms.DataGridViewTextBoxColumn cab_via_id;
    }
}