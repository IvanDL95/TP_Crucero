namespace FrbaCrucero.Listados
{
    partial class FormListadoEstadistico
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
            this.txt_anio = new FrbaCrucero.NumericTextBox();
            this.label4 = new System.Windows.Forms.Label();
            this.label1 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.cmbTrimestre = new System.Windows.Forms.ComboBox();
            this.label3 = new System.Windows.Forms.Label();
            this.cmbListado = new System.Windows.Forms.ComboBox();
            this.btSeleccionar = new System.Windows.Forms.Button();
            this.dgv_listado = new System.Windows.Forms.DataGridView();
            ((System.ComponentModel.ISupportInitialize)(this.dgv_listado)).BeginInit();
            this.SuspendLayout();
            // 
            // txt_anio
            // 
            this.txt_anio.Location = new System.Drawing.Point(47, 79);
            this.txt_anio.Name = "txt_anio";
            this.txt_anio.Size = new System.Drawing.Size(53, 20);
            this.txt_anio.TabIndex = 39;
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(12, 82);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(29, 13);
            this.label4.TabIndex = 38;
            this.label4.Text = "Año:";
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Microsoft Sans Serif", 20.25F, ((System.Drawing.FontStyle)((System.Drawing.FontStyle.Bold | System.Drawing.FontStyle.Underline))), System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.Location = new System.Drawing.Point(146, 9);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(261, 31);
            this.label1.TabIndex = 103;
            this.label1.Text = "Listado Estadístico";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(116, 82);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(53, 13);
            this.label2.TabIndex = 104;
            this.label2.Text = "Semestre:";
            // 
            // cmbTrimestre
            // 
            this.cmbTrimestre.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cmbTrimestre.FormattingEnabled = true;
            this.cmbTrimestre.Items.AddRange(new object[] {
            "Enero-Junio",
            "Julio-Diciembre"});
            this.cmbTrimestre.Location = new System.Drawing.Point(176, 77);
            this.cmbTrimestre.Name = "cmbTrimestre";
            this.cmbTrimestre.Size = new System.Drawing.Size(126, 21);
            this.cmbTrimestre.TabIndex = 105;
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(318, 82);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(44, 13);
            this.label3.TabIndex = 106;
            this.label3.Text = "Listado:";
            // 
            // cmbListado
            // 
            this.cmbListado.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cmbListado.FormattingEnabled = true;
            this.cmbListado.Items.AddRange(new object[] {
            "Listado 1",
            "Listado 2",
            "Listado 3"});
            this.cmbListado.Location = new System.Drawing.Point(368, 77);
            this.cmbListado.Name = "cmbListado";
            this.cmbListado.Size = new System.Drawing.Size(118, 21);
            this.cmbListado.TabIndex = 107;
            // 
            // btSeleccionar
            // 
            this.btSeleccionar.Location = new System.Drawing.Point(503, 75);
            this.btSeleccionar.Name = "btSeleccionar";
            this.btSeleccionar.Size = new System.Drawing.Size(75, 23);
            this.btSeleccionar.TabIndex = 108;
            this.btSeleccionar.Text = "Seleccionar";
            this.btSeleccionar.UseVisualStyleBackColor = true;
            this.btSeleccionar.Click += new System.EventHandler(this.btSeleccionar_Click);
            // 
            // dgv_listado
            // 
            this.dgv_listado.AllowUserToAddRows = false;
            this.dgv_listado.AllowUserToDeleteRows = false;
            this.dgv_listado.AllowUserToResizeColumns = false;
            this.dgv_listado.AllowUserToResizeRows = false;
            this.dgv_listado.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgv_listado.Location = new System.Drawing.Point(12, 118);
            this.dgv_listado.MultiSelect = false;
            this.dgv_listado.Name = "dgv_listado";
            this.dgv_listado.ReadOnly = true;
            this.dgv_listado.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.dgv_listado.Size = new System.Drawing.Size(566, 356);
            this.dgv_listado.TabIndex = 109;
            // 
            // FormListadoEstadistico
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(588, 486);
            this.Controls.Add(this.dgv_listado);
            this.Controls.Add(this.btSeleccionar);
            this.Controls.Add(this.cmbListado);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.cmbTrimestre);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.txt_anio);
            this.Controls.Add(this.label4);
            this.Name = "FormListadoEstadistico";
            this.Text = "Listado Estadistico";
            ((System.ComponentModel.ISupportInitialize)(this.dgv_listado)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private NumericTextBox txt_anio;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.ComboBox cmbTrimestre;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.ComboBox cmbListado;
        private System.Windows.Forms.Button btSeleccionar;
        private System.Windows.Forms.DataGridView dgv_listado;
    }
}