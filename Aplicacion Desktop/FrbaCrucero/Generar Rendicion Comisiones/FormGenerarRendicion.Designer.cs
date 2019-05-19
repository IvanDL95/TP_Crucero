namespace FrbaCrucero.Generar_Rendicion_Comisiones
{
    partial class FormGenerarRendicion
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
            this.label4 = new System.Windows.Forms.Label();
            this.dgv_listado = new System.Windows.Forms.DataGridView();
            this.btRendir = new System.Windows.Forms.Button();
            this.btAgregar = new System.Windows.Forms.Button();
            ((System.ComponentModel.ISupportInitialize)(this.dgv_listado)).BeginInit();
            this.SuspendLayout();
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Font = new System.Drawing.Font("Microsoft Sans Serif", 20.25F, ((System.Drawing.FontStyle)((System.Drawing.FontStyle.Bold | System.Drawing.FontStyle.Underline))), System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label4.Location = new System.Drawing.Point(196, 25);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(441, 31);
            this.label4.TabIndex = 103;
            this.label4.Text = "Generar rendición de comisiones";
            // 
            // dgv_listado
            // 
            this.dgv_listado.AllowUserToAddRows = false;
            this.dgv_listado.AllowUserToDeleteRows = false;
            this.dgv_listado.AllowUserToResizeColumns = false;
            this.dgv_listado.AllowUserToResizeRows = false;
            this.dgv_listado.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgv_listado.Location = new System.Drawing.Point(43, 77);
            this.dgv_listado.Name = "dgv_listado";
            this.dgv_listado.ReadOnly = true;
            this.dgv_listado.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.dgv_listado.Size = new System.Drawing.Size(744, 243);
            this.dgv_listado.TabIndex = 104;
            // 
            // btRendir
            // 
            this.btRendir.Location = new System.Drawing.Point(486, 348);
            this.btRendir.Name = "btRendir";
            this.btRendir.Size = new System.Drawing.Size(75, 23);
            this.btRendir.TabIndex = 105;
            this.btRendir.Text = "Rendir";
            this.btRendir.UseVisualStyleBackColor = true;
            this.btRendir.Click += new System.EventHandler(this.btRendir_Click);
            // 
            // btAgregar
            // 
            this.btAgregar.Location = new System.Drawing.Point(202, 348);
            this.btAgregar.Name = "btAgregar";
            this.btAgregar.Size = new System.Drawing.Size(140, 23);
            this.btAgregar.TabIndex = 106;
            this.btAgregar.Text = "Agregar Compra";
            this.btAgregar.UseVisualStyleBackColor = true;
            this.btAgregar.Click += new System.EventHandler(this.btAgregar_Click);
            // 
            // FormGenerarRendicion
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(830, 383);
            this.Controls.Add(this.btAgregar);
            this.Controls.Add(this.btRendir);
            this.Controls.Add(this.dgv_listado);
            this.Controls.Add(this.label4);
            this.Name = "FormGenerarRendicion";
            this.Text = "Generar rendición de comisiones";
            ((System.ComponentModel.ISupportInitialize)(this.dgv_listado)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.DataGridView dgv_listado;
        private System.Windows.Forms.Button btRendir;
        private System.Windows.Forms.Button btAgregar;
    }
}