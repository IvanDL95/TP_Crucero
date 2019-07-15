namespace FrbaCrucero.ABMRecorrido
{
    partial class FormAmRecorrido
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
            this.dgv_tramos = new System.Windows.Forms.DataGridView();
            this.colPuertoSalida = new System.Windows.Forms.DataGridViewComboBoxColumn();
            this.colPuertoDestino = new System.Windows.Forms.DataGridViewComboBoxColumn();
            this.colPrecioBase = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.colId = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.label4 = new System.Windows.Forms.Label();
            this.btAceptar = new System.Windows.Forms.Button();
            this.btEliminar = new System.Windows.Forms.Button();
            this.btCancelar = new System.Windows.Forms.Button();
            this.label7 = new System.Windows.Forms.Label();
            this.label14 = new System.Windows.Forms.Label();
            this.Agregar = new System.Windows.Forms.Button();
            this.label1 = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.label5 = new System.Windows.Forms.Label();
            this.numericTextBox2 = new FrbaCrucero.NumericTextBox();
            this.numericTextBox1 = new FrbaCrucero.NumericTextBox();
            this.txt_id = new System.Windows.Forms.TextBox();
            ((System.ComponentModel.ISupportInitialize)(this.dgv_tramos)).BeginInit();
            this.SuspendLayout();
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Font = new System.Drawing.Font("Microsoft Sans Serif", 20.25F, ((System.Drawing.FontStyle)((System.Drawing.FontStyle.Bold | System.Drawing.FontStyle.Underline))), System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label2.Location = new System.Drawing.Point(450, 9);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(191, 31);
            this.label2.TabIndex = 101;
            this.label2.Text = "AM Recorrido";
            // 
            // dgv_tramos
            // 
            this.dgv_tramos.AllowUserToDeleteRows = false;
            this.dgv_tramos.AllowUserToResizeColumns = false;
            this.dgv_tramos.AllowUserToResizeRows = false;
            this.dgv_tramos.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.Fill;
            this.dgv_tramos.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgv_tramos.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.colPuertoSalida,
            this.colPuertoDestino,
            this.colPrecioBase,
            this.colId});
            this.dgv_tramos.Location = new System.Drawing.Point(64, 145);
            this.dgv_tramos.Name = "dgv_tramos";
            this.dgv_tramos.Size = new System.Drawing.Size(848, 269);
            this.dgv_tramos.TabIndex = 106;
            // 
            // colPuertoSalida
            // 
            this.colPuertoSalida.HeaderText = "Puerto Salida";
            this.colPuertoSalida.Name = "colPuertoSalida";
            this.colPuertoSalida.Resizable = System.Windows.Forms.DataGridViewTriState.True;
            this.colPuertoSalida.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.Automatic;
            // 
            // colPuertoDestino
            // 
            this.colPuertoDestino.HeaderText = "Puerto Destino";
            this.colPuertoDestino.Name = "colPuertoDestino";
            this.colPuertoDestino.Resizable = System.Windows.Forms.DataGridViewTriState.True;
            this.colPuertoDestino.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.Automatic;
            // 
            // colPrecioBase
            // 
            this.colPrecioBase.HeaderText = "Precio Tramo";
            this.colPrecioBase.Name = "colPrecioBase";
            this.colPrecioBase.Resizable = System.Windows.Forms.DataGridViewTriState.True;
            // 
            // colId
            // 
            this.colId.HeaderText = "*";
            this.colId.Name = "colId";
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Font = new System.Drawing.Font("Microsoft Sans Serif", 20.25F, ((System.Drawing.FontStyle)((System.Drawing.FontStyle.Bold | System.Drawing.FontStyle.Underline))), System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label4.Location = new System.Drawing.Point(361, 9);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(255, 31);
            this.label4.TabIndex = 107;
            this.label4.Text = "Generar Recorrido";
            // 
            // btAceptar
            // 
            this.btAceptar.Location = new System.Drawing.Point(140, 420);
            this.btAceptar.Name = "btAceptar";
            this.btAceptar.Size = new System.Drawing.Size(75, 23);
            this.btAceptar.TabIndex = 109;
            this.btAceptar.Text = "Aceptar";
            this.btAceptar.UseVisualStyleBackColor = true;
            this.btAceptar.Click += new System.EventHandler(this.btAceptar_Click);
            // 
            // btEliminar
            // 
            this.btEliminar.Location = new System.Drawing.Point(597, 420);
            this.btEliminar.Name = "btEliminar";
            this.btEliminar.Size = new System.Drawing.Size(75, 23);
            this.btEliminar.TabIndex = 110;
            this.btEliminar.Text = "Eliminar";
            this.btEliminar.UseVisualStyleBackColor = true;
            this.btEliminar.Click += new System.EventHandler(this.btEliminar_Click);
            // 
            // btCancelar
            // 
            this.btCancelar.Location = new System.Drawing.Point(769, 420);
            this.btCancelar.Name = "btCancelar";
            this.btCancelar.Size = new System.Drawing.Size(75, 23);
            this.btCancelar.TabIndex = 131;
            this.btCancelar.Text = "Cancelar";
            this.btCancelar.UseVisualStyleBackColor = true;
            this.btCancelar.Click += new System.EventHandler(this.btCancelar_Click);
            // 
            // label7
            // 
            this.label7.AutoSize = true;
            this.label7.Location = new System.Drawing.Point(61, 48);
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size(92, 13);
            this.label7.TabIndex = 133;
            this.label7.Text = "Codigo Recorrido:";
            // 
            // label14
            // 
            this.label14.Location = new System.Drawing.Point(0, 0);
            this.label14.Name = "label14";
            this.label14.Size = new System.Drawing.Size(100, 23);
            this.label14.TabIndex = 0;
            // 
            // Agregar
            // 
            this.Agregar.Location = new System.Drawing.Point(367, 420);
            this.Agregar.Name = "Agregar";
            this.Agregar.Size = new System.Drawing.Size(75, 23);
            this.Agregar.TabIndex = 134;
            this.Agregar.Text = "Agregar";
            this.Agregar.UseVisualStyleBackColor = true;
            this.Agregar.Click += new System.EventHandler(this.Agregar_Click);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Microsoft Sans Serif", 14.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.Location = new System.Drawing.Point(424, 118);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(74, 24);
            this.label1.TabIndex = 137;
            this.label1.Text = "Tramos";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(550, 51);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(122, 13);
            this.label3.TabIndex = 138;
            this.label3.Text = "Puerto Salida Recorrido:";
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Location = new System.Drawing.Point(550, 77);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(131, 13);
            this.label5.TabIndex = 139;
            this.label5.Text = "Puerto Llegada Recorrido:";
            // 
            // numericTextBox2
            // 
            this.numericTextBox2.Location = new System.Drawing.Point(687, 74);
            this.numericTextBox2.Name = "numericTextBox2";
            this.numericTextBox2.Size = new System.Drawing.Size(225, 20);
            this.numericTextBox2.TabIndex = 136;
            // 
            // numericTextBox1
            // 
            this.numericTextBox1.Location = new System.Drawing.Point(687, 48);
            this.numericTextBox1.Name = "numericTextBox1";
            this.numericTextBox1.Size = new System.Drawing.Size(225, 20);
            this.numericTextBox1.TabIndex = 135;
            // 
            // txt_id
            // 
            this.txt_id.Location = new System.Drawing.Point(64, 65);
            this.txt_id.Name = "txt_id";
            this.txt_id.Size = new System.Drawing.Size(257, 20);
            this.txt_id.TabIndex = 140;
            // 
            // FormAmRecorrido
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1004, 450);
            this.Controls.Add(this.txt_id);
            this.Controls.Add(this.label5);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.numericTextBox2);
            this.Controls.Add(this.numericTextBox1);
            this.Controls.Add(this.Agregar);
            this.Controls.Add(this.btAceptar);
            this.Controls.Add(this.btCancelar);
            this.Controls.Add(this.btEliminar);
            this.Controls.Add(this.label7);
            this.Controls.Add(this.label4);
            this.Controls.Add(this.dgv_tramos);
            this.Name = "FormAmRecorrido";
            this.Text = "AM Recorrido";
            this.Load += new System.EventHandler(this.FormAmRecorrido_Load);
            ((System.ComponentModel.ISupportInitialize)(this.dgv_tramos)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label label2;
        public System.Windows.Forms.DataGridView dgv_tramos;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.Button btAceptar;
        private System.Windows.Forms.Button btEliminar;
        private System.Windows.Forms.Button btCancelar;
        private System.Windows.Forms.Label label7;
        private System.Windows.Forms.Label label14;
        private System.Windows.Forms.Button Agregar;
        private NumericTextBox numericTextBox1;
        private NumericTextBox numericTextBox2;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.DataGridViewComboBoxColumn colPuertoSalida;
        private System.Windows.Forms.DataGridViewComboBoxColumn colPuertoDestino;
        private System.Windows.Forms.DataGridViewTextBoxColumn colPrecioBase;
        private System.Windows.Forms.DataGridViewTextBoxColumn colId;
        private System.Windows.Forms.TextBox txt_id;
    }
}