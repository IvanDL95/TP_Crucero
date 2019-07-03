namespace FrbaCrucero.ABMCrucero
{
    partial class FormBajaDefinitivaCrucero 
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
            this.errorProvider = new System.Windows.Forms.ErrorProvider(this.components);
            this.label4 = new System.Windows.Forms.Label();
            this.button1 = new System.Windows.Forms.Button();
            this.button2 = new System.Windows.Forms.Button();
            this.rbCancelar = new System.Windows.Forms.RadioButton();
            this.rbBuscarReemplazo = new System.Windows.Forms.RadioButton();
            this.rbAltaReemplazo = new System.Windows.Forms.RadioButton();
            this.txt_id = new System.Windows.Forms.TextBox();
            ((System.ComponentModel.ISupportInitialize)(this.errorProvider)).BeginInit();
            this.SuspendLayout();
            // 
            // errorProvider
            // 
            this.errorProvider.ContainerControl = this;
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Font = new System.Drawing.Font("Microsoft Sans Serif", 20.25F, ((System.Drawing.FontStyle)((System.Drawing.FontStyle.Bold | System.Drawing.FontStyle.Underline))), System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label4.Location = new System.Drawing.Point(87, 9);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(198, 31);
            this.label4.TabIndex = 123;
            this.label4.Text = "Baja definitiva";
            // 
            // button1
            // 
            this.button1.Location = new System.Drawing.Point(61, 187);
            this.button1.Name = "button1";
            this.button1.Size = new System.Drawing.Size(75, 23);
            this.button1.TabIndex = 124;
            this.button1.Text = "Aceptar";
            this.button1.UseVisualStyleBackColor = true;
            this.button1.Click += new System.EventHandler(this.button1_Click);
            // 
            // button2
            // 
            this.button2.Location = new System.Drawing.Point(393, 190);
            this.button2.Name = "button2";
            this.button2.Size = new System.Drawing.Size(75, 23);
            this.button2.TabIndex = 125;
            this.button2.Text = "Cancelar";
            this.button2.UseVisualStyleBackColor = true;
            this.button2.Click += new System.EventHandler(this.button2_Click);
            // 
            // rbCancelar
            // 
            this.rbCancelar.AutoSize = true;
            this.rbCancelar.Checked = true;
            this.rbCancelar.Location = new System.Drawing.Point(61, 81);
            this.rbCancelar.Name = "rbCancelar";
            this.rbCancelar.Size = new System.Drawing.Size(142, 17);
            this.rbCancelar.TabIndex = 128;
            this.rbCancelar.TabStop = true;
            this.rbCancelar.Text = "Cancelar todos los viajes";
            this.rbCancelar.UseVisualStyleBackColor = true;
            // 
            // rbBuscarReemplazo
            // 
            this.rbBuscarReemplazo.AutoSize = true;
            this.rbBuscarReemplazo.Location = new System.Drawing.Point(61, 105);
            this.rbBuscarReemplazo.Name = "rbBuscarReemplazo";
            this.rbBuscarReemplazo.Size = new System.Drawing.Size(148, 17);
            this.rbBuscarReemplazo.TabIndex = 129;
            this.rbBuscarReemplazo.Text = "Buscar crucero reemplazo";
            this.rbBuscarReemplazo.UseVisualStyleBackColor = true;
            // 
            // rbAltaReemplazo
            // 
            this.rbAltaReemplazo.AutoSize = true;
            this.rbAltaReemplazo.Location = new System.Drawing.Point(61, 129);
            this.rbAltaReemplazo.Name = "rbAltaReemplazo";
            this.rbAltaReemplazo.Size = new System.Drawing.Size(282, 17);
            this.rbAltaReemplazo.TabIndex = 130;
            this.rbAltaReemplazo.TabStop = true;
            this.rbAltaReemplazo.Text = "Dar de alta un nuevo crucero como reemplazo con ID:";
            this.rbAltaReemplazo.UseVisualStyleBackColor = true;
            // 
            // txt_id
            // 
            this.txt_id.Location = new System.Drawing.Point(350, 129);
            this.txt_id.Name = "txt_id";
            this.txt_id.Size = new System.Drawing.Size(118, 20);
            this.txt_id.TabIndex = 131;
            // 
            // FormBajaDefinitivaCrucero
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(536, 225);
            this.Controls.Add(this.txt_id);
            this.Controls.Add(this.rbAltaReemplazo);
            this.Controls.Add(this.rbBuscarReemplazo);
            this.Controls.Add(this.rbCancelar);
            this.Controls.Add(this.button2);
            this.Controls.Add(this.button1);
            this.Controls.Add(this.label4);
            this.Name = "FormBajaDefinitivaCrucero";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "ABM Crucero";
            ((System.ComponentModel.ISupportInitialize)(this.errorProvider)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.ErrorProvider errorProvider;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.Button button2;
        private System.Windows.Forms.Button button1;
        private System.Windows.Forms.RadioButton rbBuscarReemplazo;
        private System.Windows.Forms.RadioButton rbCancelar;
        private System.Windows.Forms.RadioButton rbAltaReemplazo;
        private System.Windows.Forms.TextBox txt_id;
    }
}