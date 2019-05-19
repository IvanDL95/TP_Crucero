namespace FrbaCrucero.Abm_Grado
{
    partial class ABMGrado
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
            this.label1 = new System.Windows.Forms.Label();
            this.dgv_grado = new System.Windows.Forms.DataGridView();
            this.btModificar = new System.Windows.Forms.Button();
            this.btBorrar = new System.Windows.Forms.Button();
            this.btNuevo = new System.Windows.Forms.Button();
            ((System.ComponentModel.ISupportInitialize)(this.dgv_grado)).BeginInit();
            this.SuspendLayout();
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Microsoft Sans Serif", 20.25F, ((System.Drawing.FontStyle)((System.Drawing.FontStyle.Bold | System.Drawing.FontStyle.Underline))), System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.Location = new System.Drawing.Point(160, 24);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(163, 31);
            this.label1.TabIndex = 121;
            this.label1.Text = "ABM Grado";
            // 
            // dgv_grado
            // 
            this.dgv_grado.AllowUserToAddRows = false;
            this.dgv_grado.AllowUserToDeleteRows = false;
            this.dgv_grado.AllowUserToResizeColumns = false;
            this.dgv_grado.AllowUserToResizeRows = false;
            this.dgv_grado.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgv_grado.Location = new System.Drawing.Point(20, 96);
            this.dgv_grado.MultiSelect = false;
            this.dgv_grado.Name = "dgv_grado";
            this.dgv_grado.ReadOnly = true;
            this.dgv_grado.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.dgv_grado.Size = new System.Drawing.Size(432, 185);
            this.dgv_grado.TabIndex = 122;
            // 
            // btModificar
            // 
            this.btModificar.Location = new System.Drawing.Point(200, 313);
            this.btModificar.Name = "btModificar";
            this.btModificar.Size = new System.Drawing.Size(75, 23);
            this.btModificar.TabIndex = 123;
            this.btModificar.Text = "Modificar";
            this.btModificar.UseVisualStyleBackColor = true;
            this.btModificar.Click += new System.EventHandler(this.btModificar_Click);
            // 
            // btBorrar
            // 
            this.btBorrar.Location = new System.Drawing.Point(358, 313);
            this.btBorrar.Name = "btBorrar";
            this.btBorrar.Size = new System.Drawing.Size(75, 23);
            this.btBorrar.TabIndex = 124;
            this.btBorrar.Text = "Borrar";
            this.btBorrar.UseVisualStyleBackColor = true;
            this.btBorrar.Click += new System.EventHandler(this.btBorrar_Click);
            // 
            // btNuevo
            // 
            this.btNuevo.Location = new System.Drawing.Point(44, 313);
            this.btNuevo.Name = "btNuevo";
            this.btNuevo.Size = new System.Drawing.Size(75, 23);
            this.btNuevo.TabIndex = 125;
            this.btNuevo.Text = "Nuevo";
            this.btNuevo.UseVisualStyleBackColor = true;
            this.btNuevo.Click += new System.EventHandler(this.btNuevo_Click);
            // 
            // ABMGrado
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(475, 363);
            this.Controls.Add(this.btNuevo);
            this.Controls.Add(this.btBorrar);
            this.Controls.Add(this.btModificar);
            this.Controls.Add(this.dgv_grado);
            this.Controls.Add(this.label1);
            this.Name = "ABMGrado";
            this.Text = "ABM Grado";
            ((System.ComponentModel.ISupportInitialize)(this.dgv_grado)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.DataGridView dgv_grado;
        private System.Windows.Forms.Button btModificar;
        private System.Windows.Forms.Button btBorrar;
        private System.Windows.Forms.Button btNuevo;
    }
}