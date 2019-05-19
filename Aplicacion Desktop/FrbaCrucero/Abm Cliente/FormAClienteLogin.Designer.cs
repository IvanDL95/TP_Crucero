namespace FrbaCrucero.AbmCliente
{
    partial class FormAbmClienteLogin
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
            this.label12 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.label4 = new System.Windows.Forms.Label();
            this.label5 = new System.Windows.Forms.Label();
            this.label7 = new System.Windows.Forms.Label();
            this.txt_nombre = new System.Windows.Forms.TextBox();
            this.txt_apellido = new System.Windows.Forms.TextBox();
            this.txt_nro_doc = new FrbaCrucero.NumericTextBox();
            this.txt_cuil = new FrbaCrucero.NumericTextBox();
            this.button1 = new System.Windows.Forms.Button();
            this.button2 = new System.Windows.Forms.Button();
            this.fechaNac = new System.Windows.Forms.DateTimePicker();
            this.tarj = new System.Windows.Forms.Label();
            this.cmb_tipo_doc = new System.Windows.Forms.ComboBox();
            this.txt_tarj = new FrbaCrucero.NumericTextBox();
            this.SuspendLayout();
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(51, 62);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(44, 13);
            this.label1.TabIndex = 0;
            this.label1.Text = "Nombre";
            // 
            // label12
            // 
            this.label12.AutoSize = true;
            this.label12.Font = new System.Drawing.Font("Microsoft Sans Serif", 20.25F, ((System.Drawing.FontStyle)((System.Drawing.FontStyle.Bold | System.Drawing.FontStyle.Underline))), System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label12.Location = new System.Drawing.Point(107, 9);
            this.label12.Name = "label12";
            this.label12.Size = new System.Drawing.Size(165, 31);
            this.label12.TabIndex = 26;
            this.label12.Text = "Alta Cliente";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(51, 93);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(44, 13);
            this.label2.TabIndex = 27;
            this.label2.Text = "Apellido";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(51, 123);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(86, 13);
            this.label3.TabIndex = 28;
            this.label3.Text = "Tipo Documento";
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(51, 152);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(77, 13);
            this.label4.TabIndex = 29;
            this.label4.Text = "N° Documento";
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Location = new System.Drawing.Point(51, 218);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(31, 13);
            this.label5.TabIndex = 30;
            this.label5.Text = "CUIL";
            // 
            // label7
            // 
            this.label7.AutoSize = true;
            this.label7.Location = new System.Drawing.Point(51, 253);
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size(93, 13);
            this.label7.TabIndex = 32;
            this.label7.Text = "Fecha Nacimiento";
            // 
            // txt_nombre
            // 
            this.txt_nombre.Location = new System.Drawing.Point(154, 59);
            this.txt_nombre.Name = "txt_nombre";
            this.txt_nombre.Size = new System.Drawing.Size(185, 20);
            this.txt_nombre.TabIndex = 34;
            // 
            // txt_apellido
            // 
            this.txt_apellido.Location = new System.Drawing.Point(154, 90);
            this.txt_apellido.Name = "txt_apellido";
            this.txt_apellido.Size = new System.Drawing.Size(185, 20);
            this.txt_apellido.TabIndex = 35;
            // 
            // txt_nro_doc
            // 
            this.txt_nro_doc.Location = new System.Drawing.Point(154, 149);
            this.txt_nro_doc.Name = "txt_nro_doc";
            this.txt_nro_doc.Size = new System.Drawing.Size(185, 20);
            this.txt_nro_doc.TabIndex = 37;
            // 
            // txt_cuil
            // 
            this.txt_cuil.Location = new System.Drawing.Point(154, 215);
            this.txt_cuil.Name = "txt_cuil";
            this.txt_cuil.Size = new System.Drawing.Size(185, 20);
            this.txt_cuil.TabIndex = 38;
            // 
            // button1
            // 
            this.button1.Location = new System.Drawing.Point(99, 287);
            this.button1.Name = "button1";
            this.button1.Size = new System.Drawing.Size(75, 23);
            this.button1.TabIndex = 42;
            this.button1.Text = "Aceptar";
            this.button1.UseVisualStyleBackColor = true;
            this.button1.Click += new System.EventHandler(this.button1_Click);
            // 
            // button2
            // 
            this.button2.Location = new System.Drawing.Point(229, 287);
            this.button2.Name = "button2";
            this.button2.Size = new System.Drawing.Size(75, 23);
            this.button2.TabIndex = 43;
            this.button2.Text = "Cancelar";
            this.button2.UseVisualStyleBackColor = true;
            this.button2.Click += new System.EventHandler(this.button2_Click);
            // 
            // fechaNac
            // 
            this.fechaNac.Location = new System.Drawing.Point(154, 250);
            this.fechaNac.MaxDate = new System.DateTime(2006, 12, 31, 0, 0, 0, 0);
            this.fechaNac.Name = "fechaNac";
            this.fechaNac.Size = new System.Drawing.Size(200, 20);
            this.fechaNac.TabIndex = 44;
            this.fechaNac.Value = new System.DateTime(2006, 12, 31, 0, 0, 0, 0);
            // 
            // tarj
            // 
            this.tarj.AutoSize = true;
            this.tarj.Location = new System.Drawing.Point(51, 185);
            this.tarj.Name = "tarj";
            this.tarj.Size = new System.Drawing.Size(55, 13);
            this.tarj.TabIndex = 45;
            this.tarj.Text = "N° Tarjeta";
            // 
            // cmb_tipo_doc
            // 
            this.cmb_tipo_doc.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cmb_tipo_doc.FormattingEnabled = true;
            this.cmb_tipo_doc.Location = new System.Drawing.Point(154, 120);
            this.cmb_tipo_doc.Name = "cmb_tipo_doc";
            this.cmb_tipo_doc.Size = new System.Drawing.Size(185, 21);
            this.cmb_tipo_doc.TabIndex = 47;
            // 
            // txt_tarj
            // 
            this.txt_tarj.Location = new System.Drawing.Point(154, 182);
            this.txt_tarj.Name = "txt_tarj";
            this.txt_tarj.Size = new System.Drawing.Size(185, 20);
            this.txt_tarj.TabIndex = 48;
            // 
            // FormAbmCliente
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(395, 324);
            this.Controls.Add(this.txt_tarj);
            this.Controls.Add(this.cmb_tipo_doc);
            this.Controls.Add(this.tarj);
            this.Controls.Add(this.fechaNac);
            this.Controls.Add(this.button2);
            this.Controls.Add(this.button1);
            this.Controls.Add(this.txt_cuil);
            this.Controls.Add(this.txt_nro_doc);
            this.Controls.Add(this.txt_apellido);
            this.Controls.Add(this.txt_nombre);
            this.Controls.Add(this.label7);
            this.Controls.Add(this.label5);
            this.Controls.Add(this.label4);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.label12);
            this.Controls.Add(this.label1);
            this.Name = "FormAbmCliente";
            this.Text = "Alta Cliente";
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label12;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.Label label7;
        private System.Windows.Forms.TextBox txt_nombre;
        private System.Windows.Forms.TextBox txt_apellido;
        private System.Windows.Forms.Button button1;
        private System.Windows.Forms.Button button2;
        private System.Windows.Forms.DateTimePicker fechaNac;
        private System.Windows.Forms.Label tarj;
        private System.Windows.Forms.ComboBox cmb_tipo_doc;
        private NumericTextBox txt_nro_doc;
        private NumericTextBox txt_cuil;
        private NumericTextBox txt_tarj;
    }
}