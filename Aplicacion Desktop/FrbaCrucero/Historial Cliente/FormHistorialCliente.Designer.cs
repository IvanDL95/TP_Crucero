namespace FrbaCrucero.Historial_Cliente
{
    partial class FormHistorialCliente
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
            this.txtDisplayPageNo = new System.Windows.Forms.Label();
            this.btnLastPage = new System.Windows.Forms.Button();
            this.btnPreviousPage = new System.Windows.Forms.Button();
            this.btnNextPage = new System.Windows.Forms.Button();
            this.btnFirstPage = new System.Windows.Forms.Button();
            this.dgv_compras = new System.Windows.Forms.DataGridView();
            this.label4 = new System.Windows.Forms.Label();
            ((System.ComponentModel.ISupportInitialize)(this.dgv_compras)).BeginInit();
            this.SuspendLayout();
            // 
            // txtDisplayPageNo
            // 
            this.txtDisplayPageNo.AutoSize = true;
            this.txtDisplayPageNo.Location = new System.Drawing.Point(317, 330);
            this.txtDisplayPageNo.Name = "txtDisplayPageNo";
            this.txtDisplayPageNo.Size = new System.Drawing.Size(40, 13);
            this.txtDisplayPageNo.TabIndex = 126;
            this.txtDisplayPageNo.Text = "Página";
            // 
            // btnLastPage
            // 
            this.btnLastPage.Location = new System.Drawing.Point(592, 325);
            this.btnLastPage.Name = "btnLastPage";
            this.btnLastPage.Size = new System.Drawing.Size(75, 23);
            this.btnLastPage.TabIndex = 124;
            this.btnLastPage.Text = "Última pag";
            this.btnLastPage.UseVisualStyleBackColor = true;
            this.btnLastPage.Click += new System.EventHandler(this.btnLastPage_Click);
            // 
            // btnPreviousPage
            // 
            this.btnPreviousPage.Location = new System.Drawing.Point(184, 326);
            this.btnPreviousPage.Name = "btnPreviousPage";
            this.btnPreviousPage.Size = new System.Drawing.Size(75, 23);
            this.btnPreviousPage.TabIndex = 123;
            this.btnPreviousPage.Text = "Anterior";
            this.btnPreviousPage.UseVisualStyleBackColor = true;
            this.btnPreviousPage.Click += new System.EventHandler(this.btnPreviousPage_Click);
            // 
            // btnNextPage
            // 
            this.btnNextPage.Location = new System.Drawing.Point(458, 326);
            this.btnNextPage.Name = "btnNextPage";
            this.btnNextPage.Size = new System.Drawing.Size(75, 23);
            this.btnNextPage.TabIndex = 122;
            this.btnNextPage.Text = "Siguiente";
            this.btnNextPage.UseVisualStyleBackColor = true;
            this.btnNextPage.Click += new System.EventHandler(this.btnNextPage_Click);
            // 
            // btnFirstPage
            // 
            this.btnFirstPage.Location = new System.Drawing.Point(76, 325);
            this.btnFirstPage.Name = "btnFirstPage";
            this.btnFirstPage.Size = new System.Drawing.Size(75, 23);
            this.btnFirstPage.TabIndex = 121;
            this.btnFirstPage.Text = "Primera pag";
            this.btnFirstPage.UseVisualStyleBackColor = true;
            this.btnFirstPage.Click += new System.EventHandler(this.btnFirstPage_Click);
            // 
            // dgv_compras
            // 
            this.dgv_compras.AllowUserToAddRows = false;
            this.dgv_compras.AllowUserToDeleteRows = false;
            this.dgv_compras.AllowUserToResizeColumns = false;
            this.dgv_compras.AllowUserToResizeRows = false;
            this.dgv_compras.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgv_compras.Location = new System.Drawing.Point(12, 58);
            this.dgv_compras.MultiSelect = false;
            this.dgv_compras.Name = "dgv_compras";
            this.dgv_compras.ReadOnly = true;
            this.dgv_compras.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.dgv_compras.Size = new System.Drawing.Size(743, 243);
            this.dgv_compras.TabIndex = 120;
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Font = new System.Drawing.Font("Microsoft Sans Serif", 20.25F, ((System.Drawing.FontStyle)((System.Drawing.FontStyle.Bold | System.Drawing.FontStyle.Underline))), System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label4.Location = new System.Drawing.Point(251, 9);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(222, 31);
            this.label4.TabIndex = 119;
            this.label4.Text = "Historial Cliente";
            // 
            // FormHistorialCliente
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(768, 370);
            this.Controls.Add(this.txtDisplayPageNo);
            this.Controls.Add(this.btnLastPage);
            this.Controls.Add(this.btnPreviousPage);
            this.Controls.Add(this.btnNextPage);
            this.Controls.Add(this.btnFirstPage);
            this.Controls.Add(this.dgv_compras);
            this.Controls.Add(this.label4);
            this.Name = "FormHistorialCliente";
            this.Text = "Historial Cliente";
            ((System.ComponentModel.ISupportInitialize)(this.dgv_compras)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label txtDisplayPageNo;
        private System.Windows.Forms.Button btnLastPage;
        private System.Windows.Forms.Button btnPreviousPage;
        private System.Windows.Forms.Button btnNextPage;
        private System.Windows.Forms.Button btnFirstPage;
        private System.Windows.Forms.DataGridView dgv_compras;
        private System.Windows.Forms.Label label4;
    }
}