namespace FrbaCrucero.Generar_viaje
{
    partial class FormGenerarViaje
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
            this.btGenerar = new System.Windows.Forms.Button();
            this.txt_hlleg = new System.Windows.Forms.TextBox();
            this.txt_flleg = new System.Windows.Forms.TextBox();
            this.txt_hsal = new System.Windows.Forms.TextBox();
            this.txt_fsal = new System.Windows.Forms.TextBox();
            this.label10 = new System.Windows.Forms.Label();
            this.label9 = new System.Windows.Forms.Label();
            this.label11 = new System.Windows.Forms.Label();
            this.label14 = new System.Windows.Forms.Label();
            this.btCancelar = new System.Windows.Forms.Button();
            this.btBuscar = new System.Windows.Forms.Button();
            this.dgv_listado = new System.Windows.Forms.DataGridView();
            this.label1 = new System.Windows.Forms.Label();
            this.dgv_listado2 = new System.Windows.Forms.DataGridView();
            this.label3 = new System.Windows.Forms.Label();
            this.label4 = new System.Windows.Forms.Label();
            this.txt_puerto_desde = new System.Windows.Forms.TextBox();
            this.txt_puerto_hasta = new System.Windows.Forms.TextBox();
            this.label5 = new System.Windows.Forms.Label();
            this.btBuscarRecorrido = new System.Windows.Forms.Button();
            ((System.ComponentModel.ISupportInitialize)(this.dgv_listado)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.dgv_listado2)).BeginInit();
            this.SuspendLayout();
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Font = new System.Drawing.Font("Microsoft Sans Serif", 20.25F, ((System.Drawing.FontStyle)((System.Drawing.FontStyle.Bold | System.Drawing.FontStyle.Underline))), System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label2.Location = new System.Drawing.Point(320, 9);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(193, 31);
            this.label2.TabIndex = 101;
            this.label2.Text = "Generar Viaje";
            // 
            // btGenerar
            // 
            this.btGenerar.Location = new System.Drawing.Point(297, 653);
            this.btGenerar.Name = "btGenerar";
            this.btGenerar.Size = new System.Drawing.Size(75, 23);
            this.btGenerar.TabIndex = 109;
            this.btGenerar.Text = "Generar";
            this.btGenerar.UseVisualStyleBackColor = true;
            this.btGenerar.Click += new System.EventHandler(this.btGenerar_Viaje_Click);
            // 
            // txt_hlleg
            // 
            this.txt_hlleg.Location = new System.Drawing.Point(469, 91);
            this.txt_hlleg.Name = "txt_hlleg";
            this.txt_hlleg.Size = new System.Drawing.Size(185, 20);
            this.txt_hlleg.TabIndex = 130;
            // 
            // txt_flleg
            // 
            this.txt_flleg.Location = new System.Drawing.Point(154, 91);
            this.txt_flleg.Name = "txt_flleg";
            this.txt_flleg.Size = new System.Drawing.Size(185, 20);
            this.txt_flleg.TabIndex = 129;
            // 
            // txt_hsal
            // 
            this.txt_hsal.Location = new System.Drawing.Point(469, 65);
            this.txt_hsal.Name = "txt_hsal";
            this.txt_hsal.Size = new System.Drawing.Size(185, 20);
            this.txt_hsal.TabIndex = 126;
            // 
            // txt_fsal
            // 
            this.txt_fsal.Location = new System.Drawing.Point(154, 65);
            this.txt_fsal.Name = "txt_fsal";
            this.txt_fsal.Size = new System.Drawing.Size(185, 20);
            this.txt_fsal.TabIndex = 123;
            // 
            // label10
            // 
            this.label10.AutoSize = true;
            this.label10.Location = new System.Drawing.Point(368, 98);
            this.label10.Name = "label10";
            this.label10.Size = new System.Drawing.Size(70, 13);
            this.label10.TabIndex = 122;
            this.label10.Text = "Hora llegada:";
            // 
            // label9
            // 
            this.label9.AutoSize = true;
            this.label9.Location = new System.Drawing.Point(53, 98);
            this.label9.Name = "label9";
            this.label9.Size = new System.Drawing.Size(77, 13);
            this.label9.TabIndex = 121;
            this.label9.Text = "Fecha llegada:";
            // 
            // label11
            // 
            this.label11.AutoSize = true;
            this.label11.Location = new System.Drawing.Point(368, 72);
            this.label11.Name = "label11";
            this.label11.Size = new System.Drawing.Size(63, 13);
            this.label11.TabIndex = 118;
            this.label11.Text = "Hora salida:";
            // 
            // label14
            // 
            this.label14.AutoSize = true;
            this.label14.Location = new System.Drawing.Point(53, 72);
            this.label14.Name = "label14";
            this.label14.Size = new System.Drawing.Size(70, 13);
            this.label14.TabIndex = 115;
            this.label14.Text = "Fecha salida:";
            // 
            // btCancelar
            // 
            this.btCancelar.Location = new System.Drawing.Point(451, 653);
            this.btCancelar.Name = "btCancelar";
            this.btCancelar.Size = new System.Drawing.Size(75, 23);
            this.btCancelar.TabIndex = 131;
            this.btCancelar.Text = "Cancelar";
            this.btCancelar.UseVisualStyleBackColor = true;
            this.btCancelar.Click += new System.EventHandler(this.button1_Click);
            // 
            // btBuscar
            // 
            this.btBuscar.Location = new System.Drawing.Point(690, 65);
            this.btBuscar.Name = "btBuscar";
            this.btBuscar.Size = new System.Drawing.Size(80, 46);
            this.btBuscar.TabIndex = 132;
            this.btBuscar.Text = "Buscar crucero";
            this.btBuscar.UseVisualStyleBackColor = true;
            this.btBuscar.Click += new System.EventHandler(this.btBuscar_Click);
            // 
            // dgv_listado
            // 
            this.dgv_listado.AllowUserToAddRows = false;
            this.dgv_listado.AllowUserToDeleteRows = false;
            this.dgv_listado.AllowUserToResizeColumns = false;
            this.dgv_listado.AllowUserToResizeRows = false;
            this.dgv_listado.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.Fill;
            this.dgv_listado.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgv_listado.Location = new System.Drawing.Point(56, 156);
            this.dgv_listado.Name = "dgv_listado";
            this.dgv_listado.ReadOnly = true;
            this.dgv_listado.RowHeadersVisible = false;
            this.dgv_listado.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.dgv_listado.Size = new System.Drawing.Size(714, 197);
            this.dgv_listado.TabIndex = 133;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(56, 370);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(85, 13);
            this.label1.TabIndex = 134;
            this.label1.Text = "Elegir Recorrido:";
            // 
            // dgv_listado2
            // 
            this.dgv_listado2.AllowUserToAddRows = false;
            this.dgv_listado2.AllowUserToDeleteRows = false;
            this.dgv_listado2.AllowUserToResizeColumns = false;
            this.dgv_listado2.AllowUserToResizeRows = false;
            this.dgv_listado2.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.Fill;
            this.dgv_listado2.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgv_listado2.Location = new System.Drawing.Point(56, 434);
            this.dgv_listado2.Name = "dgv_listado2";
            this.dgv_listado2.ReadOnly = true;
            this.dgv_listado2.RowHeadersVisible = false;
            this.dgv_listado2.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.dgv_listado2.Size = new System.Drawing.Size(714, 197);
            this.dgv_listado2.TabIndex = 135;
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(56, 128);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(76, 13);
            this.label3.TabIndex = 136;
            this.label3.Text = "Elegir Crucero:";
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(58, 402);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(75, 13);
            this.label4.TabIndex = 137;
            this.label4.Text = "Puerto Desde:";
            // 
            // txt_puerto_desde
            // 
            this.txt_puerto_desde.Location = new System.Drawing.Point(154, 399);
            this.txt_puerto_desde.Name = "txt_puerto_desde";
            this.txt_puerto_desde.Size = new System.Drawing.Size(185, 20);
            this.txt_puerto_desde.TabIndex = 138;
            // 
            // txt_puerto_hasta
            // 
            this.txt_puerto_hasta.Location = new System.Drawing.Point(449, 399);
            this.txt_puerto_hasta.Name = "txt_puerto_hasta";
            this.txt_puerto_hasta.Size = new System.Drawing.Size(205, 20);
            this.txt_puerto_hasta.TabIndex = 140;
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Location = new System.Drawing.Point(368, 402);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(72, 13);
            this.label5.TabIndex = 139;
            this.label5.Text = "Puerto Hasta:";
            // 
            // btBuscarRecorrido
            // 
            this.btBuscarRecorrido.Location = new System.Drawing.Point(690, 373);
            this.btBuscarRecorrido.Name = "btBuscarRecorrido";
            this.btBuscarRecorrido.Size = new System.Drawing.Size(80, 46);
            this.btBuscarRecorrido.TabIndex = 141;
            this.btBuscarRecorrido.Text = "Buscar recorrido";
            this.btBuscarRecorrido.UseVisualStyleBackColor = true;
            this.btBuscarRecorrido.Click += new System.EventHandler(this.btBuscarRecorrido_Click);
            // 
            // FormGenerarViaje
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(825, 688);
            this.Controls.Add(this.btBuscarRecorrido);
            this.Controls.Add(this.txt_puerto_hasta);
            this.Controls.Add(this.label5);
            this.Controls.Add(this.txt_puerto_desde);
            this.Controls.Add(this.label4);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.dgv_listado2);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.dgv_listado);
            this.Controls.Add(this.btBuscar);
            this.Controls.Add(this.btCancelar);
            this.Controls.Add(this.txt_hlleg);
            this.Controls.Add(this.txt_flleg);
            this.Controls.Add(this.txt_hsal);
            this.Controls.Add(this.txt_fsal);
            this.Controls.Add(this.label10);
            this.Controls.Add(this.label9);
            this.Controls.Add(this.label11);
            this.Controls.Add(this.label14);
            this.Controls.Add(this.btGenerar);
            this.Controls.Add(this.label2);
            this.Name = "FormGenerarViaje";
            this.Text = "Generar Viaje";
            ((System.ComponentModel.ISupportInitialize)(this.dgv_listado)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.dgv_listado2)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Button btGenerar;
        private System.Windows.Forms.TextBox txt_hlleg;
        private System.Windows.Forms.TextBox txt_flleg;
        private System.Windows.Forms.TextBox txt_hsal;
        private System.Windows.Forms.TextBox txt_fsal;
        private System.Windows.Forms.Label label10;
        private System.Windows.Forms.Label label9;
        private System.Windows.Forms.Label label11;
        private System.Windows.Forms.Label label14;
        private System.Windows.Forms.Button btCancelar;
        private System.Windows.Forms.Button btBuscar;
        public System.Windows.Forms.DataGridView dgv_listado;
        private System.Windows.Forms.Label label1;
        public System.Windows.Forms.DataGridView dgv_listado2;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.TextBox txt_puerto_desde;
        private System.Windows.Forms.TextBox txt_puerto_hasta;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.Button btBuscarRecorrido;
    }
}