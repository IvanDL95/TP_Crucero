namespace FrbaCrucero.Editar_Publicacion
{
    partial class FormListarPublicacion
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
            this.components = new System.ComponentModel.Container();
            this.dgv_listado = new System.Windows.Forms.DataGridView();
            this.errorProvider = new System.Windows.Forms.ErrorProvider(this.components);
            this.btModificar = new System.Windows.Forms.Button();
            this.btPublicar = new System.Windows.Forms.Button();
            this.btFinalizar = new System.Windows.Forms.Button();
            this.label2 = new System.Windows.Forms.Label();
            ((System.ComponentModel.ISupportInitialize)(this.dgv_listado)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.errorProvider)).BeginInit();
            this.SuspendLayout();
            // 
            // dgv_listado
            // 
            this.dgv_listado.AllowUserToAddRows = false;
            this.dgv_listado.AllowUserToDeleteRows = false;
            this.dgv_listado.AllowUserToResizeColumns = false;
            this.dgv_listado.AllowUserToResizeRows = false;
            this.dgv_listado.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.Fill;
            this.dgv_listado.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgv_listado.Location = new System.Drawing.Point(71, 103);
            this.dgv_listado.Name = "dgv_listado";
            this.dgv_listado.ReadOnly = true;
            this.dgv_listado.RowHeadersVisible = false;
            this.dgv_listado.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.dgv_listado.Size = new System.Drawing.Size(548, 249);
            this.dgv_listado.TabIndex = 25;
            // 
            // errorProvider
            // 
            this.errorProvider.ContainerControl = this;
            // 
            // btModificar
            // 
            this.btModificar.Location = new System.Drawing.Point(170, 392);
            this.btModificar.Name = "btModificar";
            this.btModificar.Size = new System.Drawing.Size(75, 23);
            this.btModificar.TabIndex = 26;
            this.btModificar.Text = "Modificar";
            this.btModificar.UseVisualStyleBackColor = true;
            this.btModificar.Click += new System.EventHandler(this.btModificar_Click);
            // 
            // btPublicar
            // 
            this.btPublicar.Location = new System.Drawing.Point(304, 392);
            this.btPublicar.Name = "btPublicar";
            this.btPublicar.Size = new System.Drawing.Size(75, 23);
            this.btPublicar.TabIndex = 27;
            this.btPublicar.Text = "Publicar";
            this.btPublicar.UseVisualStyleBackColor = true;
            this.btPublicar.Click += new System.EventHandler(this.btPublicar_Click);
            // 
            // btFinalizar
            // 
            this.btFinalizar.Location = new System.Drawing.Point(438, 392);
            this.btFinalizar.Name = "btFinalizar";
            this.btFinalizar.Size = new System.Drawing.Size(75, 23);
            this.btFinalizar.TabIndex = 28;
            this.btFinalizar.Text = "Finalizar";
            this.btFinalizar.UseVisualStyleBackColor = true;
            this.btFinalizar.Click += new System.EventHandler(this.btFinalizar_Click);
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Font = new System.Drawing.Font("Microsoft Sans Serif", 20.25F, ((System.Drawing.FontStyle)((System.Drawing.FontStyle.Bold | System.Drawing.FontStyle.Underline))), System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label2.Location = new System.Drawing.Point(220, 46);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(245, 31);
            this.label2.TabIndex = 102;
            this.label2.Text = "Listar Publicación";
            // 
            // FormListarPublicacion
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(687, 427);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.btFinalizar);
            this.Controls.Add(this.btPublicar);
            this.Controls.Add(this.btModificar);
            this.Controls.Add(this.dgv_listado);
            this.Name = "FormListarPublicacion";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Listar Publicacion";
            ((System.ComponentModel.ISupportInitialize)(this.dgv_listado)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.errorProvider)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        public System.Windows.Forms.DataGridView dgv_listado;
        private System.Windows.Forms.ErrorProvider errorProvider;
        private System.Windows.Forms.Button btFinalizar;
        private System.Windows.Forms.Button btPublicar;
        private System.Windows.Forms.Button btModificar;
        private System.Windows.Forms.Label label2;
    }
}