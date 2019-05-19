namespace FrbaCrucero
{
    partial class ABMUsuario
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
            this.btNuevo = new System.Windows.Forms.Button();
            this.btBorrar = new System.Windows.Forms.Button();
            this.dgv_listado = new System.Windows.Forms.DataGridView();
            this.label1 = new System.Windows.Forms.Label();
            this.btHabilitar = new System.Windows.Forms.Button();
            ((System.ComponentModel.ISupportInitialize)(this.dgv_listado)).BeginInit();
            this.SuspendLayout();
            // 
            // btNuevo
            // 
            this.btNuevo.Location = new System.Drawing.Point(40, 298);
            this.btNuevo.Name = "btNuevo";
            this.btNuevo.Size = new System.Drawing.Size(75, 23);
            this.btNuevo.TabIndex = 130;
            this.btNuevo.Text = "Nuevo";
            this.btNuevo.UseVisualStyleBackColor = true;
            this.btNuevo.Click += new System.EventHandler(this.btNuevo_Click);
            // 
            // btBorrar
            // 
            this.btBorrar.Location = new System.Drawing.Point(354, 298);
            this.btBorrar.Name = "btBorrar";
            this.btBorrar.Size = new System.Drawing.Size(75, 23);
            this.btBorrar.TabIndex = 129;
            this.btBorrar.Text = "Borrar";
            this.btBorrar.UseVisualStyleBackColor = true;
            this.btBorrar.Click += new System.EventHandler(this.btBorrar_Click);
            // 
            // dgv_listado
            // 
            this.dgv_listado.AllowUserToAddRows = false;
            this.dgv_listado.AllowUserToDeleteRows = false;
            this.dgv_listado.AllowUserToResizeColumns = false;
            this.dgv_listado.AllowUserToResizeRows = false;
            this.dgv_listado.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgv_listado.Location = new System.Drawing.Point(16, 81);
            this.dgv_listado.MultiSelect = false;
            this.dgv_listado.Name = "dgv_listado";
            this.dgv_listado.ReadOnly = true;
            this.dgv_listado.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.dgv_listado.Size = new System.Drawing.Size(432, 185);
            this.dgv_listado.TabIndex = 127;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Microsoft Sans Serif", 20.25F, ((System.Drawing.FontStyle)((System.Drawing.FontStyle.Bold | System.Drawing.FontStyle.Underline))), System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.Location = new System.Drawing.Point(160, 20);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(130, 31);
            this.label1.TabIndex = 126;
            this.label1.Text = "Usuarios";
            // 
            // btHabilitar
            // 
            this.btHabilitar.Location = new System.Drawing.Point(196, 298);
            this.btHabilitar.Name = "btHabilitar";
            this.btHabilitar.Size = new System.Drawing.Size(75, 23);
            this.btHabilitar.TabIndex = 131;
            this.btHabilitar.Text = "Habilitar";
            this.btHabilitar.UseVisualStyleBackColor = true;
            this.btHabilitar.Click += new System.EventHandler(this.btHabilitar_Click);
            // 
            // ABMUsuario
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(463, 341);
            this.Controls.Add(this.btHabilitar);
            this.Controls.Add(this.btNuevo);
            this.Controls.Add(this.btBorrar);
            this.Controls.Add(this.dgv_listado);
            this.Controls.Add(this.label1);
            this.Name = "ABMUsuario";
            this.Text = "ABMUsuario";
            ((System.ComponentModel.ISupportInitialize)(this.dgv_listado)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Button btNuevo;
        private System.Windows.Forms.Button btBorrar;
        private System.Windows.Forms.DataGridView dgv_listado;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Button btHabilitar;
    }
}