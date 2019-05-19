namespace FrbaCrucero.Compra_Entrada
{
    partial class FormCompraEntradas
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
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.label2 = new System.Windows.Forms.Label();
            this.dtpHasta = new System.Windows.Forms.DateTimePicker();
            this.dtpDe = new System.Windows.Forms.DateTimePicker();
            this.lb_rubro = new System.Windows.Forms.ListBox();
            this.label5 = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.label1 = new System.Windows.Forms.Label();
            this.txt_desc = new System.Windows.Forms.TextBox();
            this.label4 = new System.Windows.Forms.Label();
            this.dgv_publicacion = new System.Windows.Forms.DataGridView();
            this.btnFirstPage = new System.Windows.Forms.Button();
            this.btnNextPage = new System.Windows.Forms.Button();
            this.btnPreviousPage = new System.Windows.Forms.Button();
            this.btnLastPage = new System.Windows.Forms.Button();
            this.btnFillGrid = new System.Windows.Forms.Button();
            this.txtDisplayPageNo = new System.Windows.Forms.Label();
            this.btUbicDisponibles = new System.Windows.Forms.Button();
            this.groupBox1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgv_publicacion)).BeginInit();
            this.SuspendLayout();
            // 
            // groupBox1
            // 
            this.groupBox1.Controls.Add(this.label2);
            this.groupBox1.Controls.Add(this.dtpHasta);
            this.groupBox1.Controls.Add(this.dtpDe);
            this.groupBox1.Controls.Add(this.lb_rubro);
            this.groupBox1.Controls.Add(this.label5);
            this.groupBox1.Controls.Add(this.label3);
            this.groupBox1.Controls.Add(this.label1);
            this.groupBox1.Controls.Add(this.txt_desc);
            this.groupBox1.Location = new System.Drawing.Point(38, 79);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(614, 125);
            this.groupBox1.TabIndex = 29;
            this.groupBox1.TabStop = false;
            this.groupBox1.Text = "Filtros de búsqueda";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(309, 60);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(41, 13);
            this.label2.TabIndex = 106;
            this.label2.Text = "Rubros";
            // 
            // dtpHasta
            // 
            this.dtpHasta.Location = new System.Drawing.Point(81, 79);
            this.dtpHasta.Name = "dtpHasta";
            this.dtpHasta.Size = new System.Drawing.Size(200, 20);
            this.dtpHasta.TabIndex = 105;
            this.dtpHasta.ValueChanged += new System.EventHandler(this.dtpHasta_ValueChanged);
            // 
            // dtpDe
            // 
            this.dtpDe.Location = new System.Drawing.Point(81, 53);
            this.dtpDe.Name = "dtpDe";
            this.dtpDe.Size = new System.Drawing.Size(200, 20);
            this.dtpDe.TabIndex = 104;
            this.dtpDe.Value = new System.DateTime(2018, 1, 1, 0, 0, 0, 0);
            this.dtpDe.ValueChanged += new System.EventHandler(this.dtpDe_ValueChanged);
            // 
            // lb_rubro
            // 
            this.lb_rubro.FormattingEnabled = true;
            this.lb_rubro.Location = new System.Drawing.Point(371, 19);
            this.lb_rubro.Name = "lb_rubro";
            this.lb_rubro.SelectionMode = System.Windows.Forms.SelectionMode.MultiSimple;
            this.lb_rubro.Size = new System.Drawing.Size(220, 95);
            this.lb_rubro.TabIndex = 103;
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Location = new System.Drawing.Point(6, 59);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(55, 13);
            this.label5.TabIndex = 9;
            this.label5.Text = "Fecha de:";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(6, 85);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(69, 13);
            this.label3.TabIndex = 6;
            this.label3.Text = "Fecha hasta:";
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(6, 30);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(66, 13);
            this.label1.TabIndex = 4;
            this.label1.Text = "Descripcion:";
            // 
            // txt_desc
            // 
            this.txt_desc.Location = new System.Drawing.Point(81, 27);
            this.txt_desc.Name = "txt_desc";
            this.txt_desc.Size = new System.Drawing.Size(200, 20);
            this.txt_desc.TabIndex = 10;
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Font = new System.Drawing.Font("Microsoft Sans Serif", 20.25F, ((System.Drawing.FontStyle)((System.Drawing.FontStyle.Bold | System.Drawing.FontStyle.Underline))), System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label4.Location = new System.Drawing.Point(296, 9);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(126, 31);
            this.label4.TabIndex = 102;
            this.label4.Text = "Comprar";
            // 
            // dgv_publicacion
            // 
            this.dgv_publicacion.AllowUserToAddRows = false;
            this.dgv_publicacion.AllowUserToDeleteRows = false;
            this.dgv_publicacion.AllowUserToResizeColumns = false;
            this.dgv_publicacion.AllowUserToResizeRows = false;
            this.dgv_publicacion.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgv_publicacion.Location = new System.Drawing.Point(38, 256);
            this.dgv_publicacion.MultiSelect = false;
            this.dgv_publicacion.Name = "dgv_publicacion";
            this.dgv_publicacion.ReadOnly = true;
            this.dgv_publicacion.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.dgv_publicacion.Size = new System.Drawing.Size(614, 243);
            this.dgv_publicacion.TabIndex = 103;
            // 
            // btnFirstPage
            // 
            this.btnFirstPage.Location = new System.Drawing.Point(47, 524);
            this.btnFirstPage.Name = "btnFirstPage";
            this.btnFirstPage.Size = new System.Drawing.Size(75, 23);
            this.btnFirstPage.TabIndex = 104;
            this.btnFirstPage.Text = "Primera pag";
            this.btnFirstPage.UseVisualStyleBackColor = true;
            this.btnFirstPage.Click += new System.EventHandler(this.btnFirstPage_Click);
            // 
            // btnNextPage
            // 
            this.btnNextPage.Location = new System.Drawing.Point(429, 525);
            this.btnNextPage.Name = "btnNextPage";
            this.btnNextPage.Size = new System.Drawing.Size(75, 23);
            this.btnNextPage.TabIndex = 105;
            this.btnNextPage.Text = "Siguiente";
            this.btnNextPage.UseVisualStyleBackColor = true;
            this.btnNextPage.Click += new System.EventHandler(this.btnNextPage_Click);
            // 
            // btnPreviousPage
            // 
            this.btnPreviousPage.Location = new System.Drawing.Point(155, 525);
            this.btnPreviousPage.Name = "btnPreviousPage";
            this.btnPreviousPage.Size = new System.Drawing.Size(75, 23);
            this.btnPreviousPage.TabIndex = 106;
            this.btnPreviousPage.Text = "Anterior";
            this.btnPreviousPage.UseVisualStyleBackColor = true;
            this.btnPreviousPage.Click += new System.EventHandler(this.btnPreviousPage_Click);
            // 
            // btnLastPage
            // 
            this.btnLastPage.Location = new System.Drawing.Point(563, 524);
            this.btnLastPage.Name = "btnLastPage";
            this.btnLastPage.Size = new System.Drawing.Size(75, 23);
            this.btnLastPage.TabIndex = 107;
            this.btnLastPage.Text = "Última pag";
            this.btnLastPage.UseVisualStyleBackColor = true;
            this.btnLastPage.Click += new System.EventHandler(this.btnLastPage_Click);
            // 
            // btnFillGrid
            // 
            this.btnFillGrid.Location = new System.Drawing.Point(302, 210);
            this.btnFillGrid.Name = "btnFillGrid";
            this.btnFillGrid.Size = new System.Drawing.Size(75, 23);
            this.btnFillGrid.TabIndex = 108;
            this.btnFillGrid.Text = "Buscar";
            this.btnFillGrid.UseVisualStyleBackColor = true;
            this.btnFillGrid.Click += new System.EventHandler(this.btnFillGrid_Click);
            // 
            // txtDisplayPageNo
            // 
            this.txtDisplayPageNo.AutoSize = true;
            this.txtDisplayPageNo.Location = new System.Drawing.Point(288, 529);
            this.txtDisplayPageNo.Name = "txtDisplayPageNo";
            this.txtDisplayPageNo.Size = new System.Drawing.Size(40, 13);
            this.txtDisplayPageNo.TabIndex = 111;
            this.txtDisplayPageNo.Text = "Página";
            // 
            // btUbicDisponibles
            // 
            this.btUbicDisponibles.Location = new System.Drawing.Point(670, 355);
            this.btUbicDisponibles.Name = "btUbicDisponibles";
            this.btUbicDisponibles.Size = new System.Drawing.Size(74, 51);
            this.btUbicDisponibles.TabIndex = 116;
            this.btUbicDisponibles.Text = "Ver ubicaciones disponbies";
            this.btUbicDisponibles.UseVisualStyleBackColor = true;
            this.btUbicDisponibles.Click += new System.EventHandler(this.btUbicDisponibles_Click);
            // 
            // FormCompraEntradas
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(758, 586);
            this.Controls.Add(this.btUbicDisponibles);
            this.Controls.Add(this.txtDisplayPageNo);
            this.Controls.Add(this.btnFillGrid);
            this.Controls.Add(this.btnLastPage);
            this.Controls.Add(this.btnPreviousPage);
            this.Controls.Add(this.btnNextPage);
            this.Controls.Add(this.btnFirstPage);
            this.Controls.Add(this.dgv_publicacion);
            this.Controls.Add(this.label4);
            this.Controls.Add(this.groupBox1);
            this.Name = "FormCompraEntradas";
            this.Text = "Comprar";
            this.groupBox1.ResumeLayout(false);
            this.groupBox1.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgv_publicacion)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.TextBox txt_desc;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.DateTimePicker dtpHasta;
        private System.Windows.Forms.DateTimePicker dtpDe;
        private System.Windows.Forms.ListBox lb_rubro;
        private System.Windows.Forms.DataGridView dgv_publicacion;
        private System.Windows.Forms.Button btnFirstPage;
        private System.Windows.Forms.Button btnNextPage;
        private System.Windows.Forms.Button btnPreviousPage;
        private System.Windows.Forms.Button btnLastPage;
        private System.Windows.Forms.Button btnFillGrid; 
        private System.Windows.Forms.Label txtDisplayPageNo;
        private System.Windows.Forms.Button btUbicDisponibles;
    }
}