namespace FrbaCrucero.AbmCliente
{
    partial class FormMCliente
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
            this.txt_tarj = new FrbaCrucero.NumericTextBox();
            this.cmb_tipo_doc = new System.Windows.Forms.ComboBox();
            this.tarj = new System.Windows.Forms.Label();
            this.fechaNac = new System.Windows.Forms.DateTimePicker();
            this.txt_cuil = new FrbaCrucero.NumericTextBox();
            this.txt_nro_doc = new FrbaCrucero.NumericTextBox();
            this.txt_apellido = new System.Windows.Forms.TextBox();
            this.txt_nombre = new System.Windows.Forms.TextBox();
            this.label7 = new System.Windows.Forms.Label();
            this.label5 = new System.Windows.Forms.Label();
            this.label4 = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.label1 = new System.Windows.Forms.Label();
            this.txt_localidad = new System.Windows.Forms.TextBox();
            this.txt_mail = new System.Windows.Forms.TextBox();
            this.txt_tel = new FrbaCrucero.NumericTextBox();
            this.txt_cp = new System.Windows.Forms.TextBox();
            this.txt_departamento = new System.Windows.Forms.TextBox();
            this.txt_piso = new FrbaCrucero.NumericTextBox();
            this.txt_numero = new FrbaCrucero.NumericTextBox();
            this.txt_calle = new System.Windows.Forms.TextBox();
            this.label10 = new System.Windows.Forms.Label();
            this.label9 = new System.Windows.Forms.Label();
            this.label8 = new System.Windows.Forms.Label();
            this.label6 = new System.Windows.Forms.Label();
            this.label11 = new System.Windows.Forms.Label();
            this.label12 = new System.Windows.Forms.Label();
            this.label13 = new System.Windows.Forms.Label();
            this.label14 = new System.Windows.Forms.Label();
            this.label15 = new System.Windows.Forms.Label();
            this.btAceptar = new System.Windows.Forms.Button();
            this.btCancelar = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // txt_tarj
            // 
            this.txt_tarj.Location = new System.Drawing.Point(217, 201);
            this.txt_tarj.Name = "txt_tarj";
            this.txt_tarj.Size = new System.Drawing.Size(185, 20);
            this.txt_tarj.TabIndex = 62;
            // 
            // cmb_tipo_doc
            // 
            this.cmb_tipo_doc.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cmb_tipo_doc.FormattingEnabled = true;
            this.cmb_tipo_doc.Location = new System.Drawing.Point(217, 139);
            this.cmb_tipo_doc.Name = "cmb_tipo_doc";
            this.cmb_tipo_doc.Size = new System.Drawing.Size(185, 21);
            this.cmb_tipo_doc.TabIndex = 61;
            // 
            // tarj
            // 
            this.tarj.AutoSize = true;
            this.tarj.Location = new System.Drawing.Point(114, 204);
            this.tarj.Name = "tarj";
            this.tarj.Size = new System.Drawing.Size(55, 13);
            this.tarj.TabIndex = 60;
            this.tarj.Text = "N° Tarjeta";
            // 
            // fechaNac
            // 
            this.fechaNac.Location = new System.Drawing.Point(217, 269);
            this.fechaNac.MaxDate = new System.DateTime(2006, 12, 31, 0, 0, 0, 0);
            this.fechaNac.Name = "fechaNac";
            this.fechaNac.Size = new System.Drawing.Size(200, 20);
            this.fechaNac.TabIndex = 59;
            this.fechaNac.Value = new System.DateTime(2006, 12, 31, 0, 0, 0, 0);
            // 
            // txt_cuil
            // 
            this.txt_cuil.Location = new System.Drawing.Point(217, 234);
            this.txt_cuil.Name = "txt_cuil";
            this.txt_cuil.Size = new System.Drawing.Size(185, 20);
            this.txt_cuil.TabIndex = 58;
            // 
            // txt_nro_doc
            // 
            this.txt_nro_doc.Location = new System.Drawing.Point(217, 168);
            this.txt_nro_doc.Name = "txt_nro_doc";
            this.txt_nro_doc.Size = new System.Drawing.Size(185, 20);
            this.txt_nro_doc.TabIndex = 57;
            // 
            // txt_apellido
            // 
            this.txt_apellido.Location = new System.Drawing.Point(217, 109);
            this.txt_apellido.Name = "txt_apellido";
            this.txt_apellido.Size = new System.Drawing.Size(185, 20);
            this.txt_apellido.TabIndex = 56;
            // 
            // txt_nombre
            // 
            this.txt_nombre.Location = new System.Drawing.Point(217, 78);
            this.txt_nombre.Name = "txt_nombre";
            this.txt_nombre.Size = new System.Drawing.Size(185, 20);
            this.txt_nombre.TabIndex = 55;
            // 
            // label7
            // 
            this.label7.AutoSize = true;
            this.label7.Location = new System.Drawing.Point(114, 272);
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size(93, 13);
            this.label7.TabIndex = 54;
            this.label7.Text = "Fecha Nacimiento";
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Location = new System.Drawing.Point(114, 237);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(31, 13);
            this.label5.TabIndex = 53;
            this.label5.Text = "CUIL";
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(114, 171);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(77, 13);
            this.label4.TabIndex = 52;
            this.label4.Text = "N° Documento";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(114, 142);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(86, 13);
            this.label3.TabIndex = 51;
            this.label3.Text = "Tipo Documento";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(114, 112);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(44, 13);
            this.label2.TabIndex = 50;
            this.label2.Text = "Apellido";
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(114, 81);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(44, 13);
            this.label1.TabIndex = 49;
            this.label1.Text = "Nombre";
            // 
            // txt_localidad
            // 
            this.txt_localidad.Location = new System.Drawing.Point(217, 481);
            this.txt_localidad.Name = "txt_localidad";
            this.txt_localidad.Size = new System.Drawing.Size(185, 20);
            this.txt_localidad.TabIndex = 78;
            // 
            // txt_mail
            // 
            this.txt_mail.Location = new System.Drawing.Point(217, 455);
            this.txt_mail.Name = "txt_mail";
            this.txt_mail.Size = new System.Drawing.Size(185, 20);
            this.txt_mail.TabIndex = 77;
            // 
            // txt_tel
            // 
            this.txt_tel.Location = new System.Drawing.Point(217, 429);
            this.txt_tel.Name = "txt_tel";
            this.txt_tel.Size = new System.Drawing.Size(185, 20);
            this.txt_tel.TabIndex = 76;
            // 
            // txt_cp
            // 
            this.txt_cp.Location = new System.Drawing.Point(217, 403);
            this.txt_cp.Name = "txt_cp";
            this.txt_cp.Size = new System.Drawing.Size(185, 20);
            this.txt_cp.TabIndex = 75;
            // 
            // txt_departamento
            // 
            this.txt_departamento.Location = new System.Drawing.Point(217, 377);
            this.txt_departamento.Name = "txt_departamento";
            this.txt_departamento.Size = new System.Drawing.Size(185, 20);
            this.txt_departamento.TabIndex = 74;
            // 
            // txt_piso
            // 
            this.txt_piso.Location = new System.Drawing.Point(217, 351);
            this.txt_piso.Name = "txt_piso";
            this.txt_piso.Size = new System.Drawing.Size(185, 20);
            this.txt_piso.TabIndex = 73;
            // 
            // txt_numero
            // 
            this.txt_numero.Location = new System.Drawing.Point(217, 325);
            this.txt_numero.Name = "txt_numero";
            this.txt_numero.Size = new System.Drawing.Size(185, 20);
            this.txt_numero.TabIndex = 72;
            // 
            // txt_calle
            // 
            this.txt_calle.Location = new System.Drawing.Point(217, 299);
            this.txt_calle.Name = "txt_calle";
            this.txt_calle.Size = new System.Drawing.Size(185, 20);
            this.txt_calle.TabIndex = 71;
            // 
            // label10
            // 
            this.label10.AutoSize = true;
            this.label10.Location = new System.Drawing.Point(116, 488);
            this.label10.Name = "label10";
            this.label10.Size = new System.Drawing.Size(56, 13);
            this.label10.TabIndex = 70;
            this.label10.Text = "Localidad:";
            // 
            // label9
            // 
            this.label9.AutoSize = true;
            this.label9.Location = new System.Drawing.Point(116, 462);
            this.label9.Name = "label9";
            this.label9.Size = new System.Drawing.Size(38, 13);
            this.label9.TabIndex = 69;
            this.label9.Text = "E-mail:";
            // 
            // label8
            // 
            this.label8.AutoSize = true;
            this.label8.Location = new System.Drawing.Point(116, 436);
            this.label8.Name = "label8";
            this.label8.Size = new System.Drawing.Size(52, 13);
            this.label8.TabIndex = 68;
            this.label8.Text = "Teléfono:";
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Location = new System.Drawing.Point(116, 410);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(75, 13);
            this.label6.TabIndex = 67;
            this.label6.Text = "Codigo Postal:";
            // 
            // label11
            // 
            this.label11.AutoSize = true;
            this.label11.Location = new System.Drawing.Point(116, 384);
            this.label11.Name = "label11";
            this.label11.Size = new System.Drawing.Size(77, 13);
            this.label11.TabIndex = 66;
            this.label11.Text = "Departamento:";
            // 
            // label12
            // 
            this.label12.AutoSize = true;
            this.label12.Location = new System.Drawing.Point(116, 358);
            this.label12.Name = "label12";
            this.label12.Size = new System.Drawing.Size(30, 13);
            this.label12.TabIndex = 65;
            this.label12.Text = "Piso:";
            // 
            // label13
            // 
            this.label13.AutoSize = true;
            this.label13.Location = new System.Drawing.Point(116, 332);
            this.label13.Name = "label13";
            this.label13.Size = new System.Drawing.Size(47, 13);
            this.label13.TabIndex = 64;
            this.label13.Text = "Numero:";
            // 
            // label14
            // 
            this.label14.AutoSize = true;
            this.label14.Location = new System.Drawing.Point(116, 306);
            this.label14.Name = "label14";
            this.label14.Size = new System.Drawing.Size(33, 13);
            this.label14.TabIndex = 63;
            this.label14.Text = "Calle:";
            // 
            // label15
            // 
            this.label15.AutoSize = true;
            this.label15.Font = new System.Drawing.Font("Microsoft Sans Serif", 20.25F, ((System.Drawing.FontStyle)((System.Drawing.FontStyle.Bold | System.Drawing.FontStyle.Underline))), System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label15.Location = new System.Drawing.Point(174, 22);
            this.label15.Name = "label15";
            this.label15.Size = new System.Drawing.Size(175, 31);
            this.label15.TabIndex = 79;
            this.label15.Text = "ABM Cliente";
            // 
            // btAceptar
            // 
            this.btAceptar.Location = new System.Drawing.Point(156, 534);
            this.btAceptar.Name = "btAceptar";
            this.btAceptar.Size = new System.Drawing.Size(75, 23);
            this.btAceptar.TabIndex = 80;
            this.btAceptar.Text = "Aceptar";
            this.btAceptar.UseVisualStyleBackColor = true;
            this.btAceptar.Click += new System.EventHandler(this.btAceptar_Click);
            // 
            // btCancelar
            // 
            this.btCancelar.Location = new System.Drawing.Point(285, 534);
            this.btCancelar.Name = "btCancelar";
            this.btCancelar.Size = new System.Drawing.Size(75, 23);
            this.btCancelar.TabIndex = 81;
            this.btCancelar.Text = "Cancelar";
            this.btCancelar.UseVisualStyleBackColor = true;
            this.btCancelar.Click += new System.EventHandler(this.btCancelar_Click);
            // 
            // FormMCliente
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(526, 569);
            this.Controls.Add(this.btCancelar);
            this.Controls.Add(this.btAceptar);
            this.Controls.Add(this.label15);
            this.Controls.Add(this.txt_localidad);
            this.Controls.Add(this.txt_mail);
            this.Controls.Add(this.txt_tel);
            this.Controls.Add(this.txt_cp);
            this.Controls.Add(this.txt_departamento);
            this.Controls.Add(this.txt_piso);
            this.Controls.Add(this.txt_numero);
            this.Controls.Add(this.txt_calle);
            this.Controls.Add(this.label10);
            this.Controls.Add(this.label9);
            this.Controls.Add(this.label8);
            this.Controls.Add(this.label6);
            this.Controls.Add(this.label11);
            this.Controls.Add(this.label12);
            this.Controls.Add(this.label13);
            this.Controls.Add(this.label14);
            this.Controls.Add(this.txt_tarj);
            this.Controls.Add(this.cmb_tipo_doc);
            this.Controls.Add(this.tarj);
            this.Controls.Add(this.fechaNac);
            this.Controls.Add(this.txt_cuil);
            this.Controls.Add(this.txt_nro_doc);
            this.Controls.Add(this.txt_apellido);
            this.Controls.Add(this.txt_nombre);
            this.Controls.Add(this.label7);
            this.Controls.Add(this.label5);
            this.Controls.Add(this.label4);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.label1);
            this.Name = "FormMCliente";
            this.Text = "ABM Cliente";
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private NumericTextBox txt_tarj;
        private System.Windows.Forms.ComboBox cmb_tipo_doc;
        private System.Windows.Forms.Label tarj;
        private System.Windows.Forms.DateTimePicker fechaNac;
        private NumericTextBox txt_cuil;
        private NumericTextBox txt_nro_doc;
        private System.Windows.Forms.TextBox txt_apellido;
        private System.Windows.Forms.TextBox txt_nombre;
        private System.Windows.Forms.Label label7;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.TextBox txt_localidad;
        private System.Windows.Forms.TextBox txt_mail;
        private NumericTextBox txt_tel;
        private System.Windows.Forms.TextBox txt_cp;
        private System.Windows.Forms.TextBox txt_departamento;
        private NumericTextBox txt_piso;
        private NumericTextBox txt_numero;
        private System.Windows.Forms.TextBox txt_calle;
        private System.Windows.Forms.Label label10;
        private System.Windows.Forms.Label label9;
        private System.Windows.Forms.Label label8;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.Label label11;
        private System.Windows.Forms.Label label12;
        private System.Windows.Forms.Label label13;
        private System.Windows.Forms.Label label14;
        private System.Windows.Forms.Label label15;
        private System.Windows.Forms.Button btAceptar;
        private System.Windows.Forms.Button btCancelar;
    }
}