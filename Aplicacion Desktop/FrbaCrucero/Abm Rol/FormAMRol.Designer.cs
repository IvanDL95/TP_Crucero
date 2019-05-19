namespace FrbaCrucero.AbmRol
{
    partial class FormAMRol
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(FormAMRol));
            this.lst_funciones_no_agregadas = new System.Windows.Forms.ListBox();
            this.lst_funciones_agregadas = new System.Windows.Forms.ListBox();
            this.label1 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.btn_agregar = new System.Windows.Forms.Button();
            this.btn_quitar = new System.Windows.Forms.Button();
            this.label3 = new System.Windows.Forms.Label();
            this.txt_nombre = new System.Windows.Forms.TextBox();
            this.btn_cambiar_nombre = new System.Windows.Forms.Button();
            this.chk_habilitado = new System.Windows.Forms.CheckBox();
            this.btAceptar = new System.Windows.Forms.Button();
            this.label4 = new System.Windows.Forms.Label();
            this.SuspendLayout();
            // 
            // lst_funciones_no_agregadas
            // 
            this.lst_funciones_no_agregadas.FormattingEnabled = true;
            this.lst_funciones_no_agregadas.Location = new System.Drawing.Point(19, 147);
            this.lst_funciones_no_agregadas.Name = "lst_funciones_no_agregadas";
            this.lst_funciones_no_agregadas.Size = new System.Drawing.Size(228, 264);
            this.lst_funciones_no_agregadas.TabIndex = 0;
            // 
            // lst_funciones_agregadas
            // 
            this.lst_funciones_agregadas.FormattingEnabled = true;
            this.lst_funciones_agregadas.Location = new System.Drawing.Point(354, 147);
            this.lst_funciones_agregadas.Name = "lst_funciones_agregadas";
            this.lst_funciones_agregadas.Size = new System.Drawing.Size(228, 264);
            this.lst_funciones_agregadas.TabIndex = 1;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(89, 121);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(78, 13);
            this.label1.TabIndex = 2;
            this.label1.Text = "DISPONIBLES";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(428, 121);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(70, 13);
            this.label2.TabIndex = 3;
            this.label2.Text = "ASIGNADOS";
            // 
            // btn_agregar
            // 
            this.btn_agregar.Image = ((System.Drawing.Image)(resources.GetObject("btn_agregar.Image")));
            this.btn_agregar.Location = new System.Drawing.Point(264, 195);
            this.btn_agregar.Name = "btn_agregar";
            this.btn_agregar.Size = new System.Drawing.Size(75, 33);
            this.btn_agregar.TabIndex = 4;
            this.btn_agregar.UseVisualStyleBackColor = true;
            this.btn_agregar.Click += new System.EventHandler(this.btn_agregar_Click);
            // 
            // btn_quitar
            // 
            this.btn_quitar.Image = ((System.Drawing.Image)(resources.GetObject("btn_quitar.Image")));
            this.btn_quitar.Location = new System.Drawing.Point(264, 308);
            this.btn_quitar.Name = "btn_quitar";
            this.btn_quitar.Size = new System.Drawing.Size(75, 33);
            this.btn_quitar.TabIndex = 5;
            this.btn_quitar.UseVisualStyleBackColor = true;
            this.btn_quitar.Click += new System.EventHandler(this.btn_quitar_Click);
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(136, 67);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(47, 13);
            this.label3.TabIndex = 7;
            this.label3.Text = "Nombre:";
            // 
            // txt_nombre
            // 
            this.txt_nombre.Location = new System.Drawing.Point(189, 64);
            this.txt_nombre.Name = "txt_nombre";
            this.txt_nombre.Size = new System.Drawing.Size(221, 20);
            this.txt_nombre.TabIndex = 1;
            // 
            // btn_cambiar_nombre
            // 
            this.btn_cambiar_nombre.Location = new System.Drawing.Point(457, 64);
            this.btn_cambiar_nombre.Name = "btn_cambiar_nombre";
            this.btn_cambiar_nombre.Size = new System.Drawing.Size(96, 23);
            this.btn_cambiar_nombre.TabIndex = 8;
            this.btn_cambiar_nombre.Text = "Cambiar Nombre";
            this.btn_cambiar_nombre.UseVisualStyleBackColor = true;
            this.btn_cambiar_nombre.Click += new System.EventHandler(this.btn_cambiar_nombre_Click);
            // 
            // chk_habilitado
            // 
            this.chk_habilitado.AutoSize = true;
            this.chk_habilitado.Location = new System.Drawing.Point(259, 90);
            this.chk_habilitado.Name = "chk_habilitado";
            this.chk_habilitado.Size = new System.Drawing.Size(73, 17);
            this.chk_habilitado.TabIndex = 9;
            this.chk_habilitado.Text = "Habilitado";
            this.chk_habilitado.UseVisualStyleBackColor = true;
            // 
            // btAceptar
            // 
            this.btAceptar.Location = new System.Drawing.Point(264, 428);
            this.btAceptar.Name = "btAceptar";
            this.btAceptar.Size = new System.Drawing.Size(75, 23);
            this.btAceptar.TabIndex = 10;
            this.btAceptar.Text = "Aceptar";
            this.btAceptar.UseVisualStyleBackColor = true;
            this.btAceptar.Click += new System.EventHandler(this.btAceptar_Click);
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Font = new System.Drawing.Font("Microsoft Sans Serif", 20.25F, ((System.Drawing.FontStyle)((System.Drawing.FontStyle.Bold | System.Drawing.FontStyle.Underline))), System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label4.Location = new System.Drawing.Point(151, 9);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(305, 31);
            this.label4.TabIndex = 124;
            this.label4.Text = "Administrar Funciones";
            // 
            // FormAMRol
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(599, 463);
            this.Controls.Add(this.label4);
            this.Controls.Add(this.btAceptar);
            this.Controls.Add(this.chk_habilitado);
            this.Controls.Add(this.btn_cambiar_nombre);
            this.Controls.Add(this.txt_nombre);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.btn_quitar);
            this.Controls.Add(this.btn_agregar);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.lst_funciones_agregadas);
            this.Controls.Add(this.lst_funciones_no_agregadas);
            this.Name = "FormAMRol";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Administrar Funciones";
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.ListBox lst_funciones_no_agregadas;
        private System.Windows.Forms.ListBox lst_funciones_agregadas;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Button btn_agregar;
        private System.Windows.Forms.Button btn_quitar;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.TextBox txt_nombre;
        private System.Windows.Forms.Button btn_cambiar_nombre;
        private System.Windows.Forms.CheckBox chk_habilitado;
        private System.Windows.Forms.Button btAceptar;
        private System.Windows.Forms.Label label4;
    }
}