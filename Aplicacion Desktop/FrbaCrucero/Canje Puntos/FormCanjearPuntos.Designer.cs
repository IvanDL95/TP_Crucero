namespace FrbaCrucero.Canjear_Puntos
{
    partial class FormCanjearPuntos
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
            this.label4 = new System.Windows.Forms.Label();
            this.label1 = new System.Windows.Forms.Label();
            this.lbPuntos = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.lbVencimiento = new System.Windows.Forms.Label();
            this.dgv_premios = new System.Windows.Forms.DataGridView();
            this.label3 = new System.Windows.Forms.Label();
            this.btCanjear = new System.Windows.Forms.Button();
            ((System.ComponentModel.ISupportInitialize)(this.dgv_premios)).BeginInit();
            this.SuspendLayout();
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Font = new System.Drawing.Font("Microsoft Sans Serif", 20.25F, ((System.Drawing.FontStyle)((System.Drawing.FontStyle.Bold | System.Drawing.FontStyle.Underline))), System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label4.Location = new System.Drawing.Point(96, 9);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(215, 31);
            this.label4.TabIndex = 120;
            this.label4.Text = "Canjear Puntos";
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(33, 68);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(98, 13);
            this.label1.TabIndex = 121;
            this.label1.Text = "Puntos disponibles:";
            // 
            // lbPuntos
            // 
            this.lbPuntos.AutoSize = true;
            this.lbPuntos.Location = new System.Drawing.Point(137, 68);
            this.lbPuntos.Name = "lbPuntos";
            this.lbPuntos.Size = new System.Drawing.Size(13, 13);
            this.lbPuntos.TabIndex = 122;
            this.lbPuntos.Text = "0";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(202, 68);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(68, 13);
            this.label2.TabIndex = 123;
            this.label2.Text = "Vencimiento:";
            // 
            // lbVencimiento
            // 
            this.lbVencimiento.AutoSize = true;
            this.lbVencimiento.Location = new System.Drawing.Point(276, 68);
            this.lbVencimiento.Name = "lbVencimiento";
            this.lbVencimiento.Size = new System.Drawing.Size(0, 13);
            this.lbVencimiento.TabIndex = 124;
            // 
            // dgv_premios
            // 
            this.dgv_premios.AllowUserToAddRows = false;
            this.dgv_premios.AllowUserToDeleteRows = false;
            this.dgv_premios.AllowUserToResizeColumns = false;
            this.dgv_premios.AllowUserToResizeRows = false;
            this.dgv_premios.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgv_premios.Location = new System.Drawing.Point(36, 137);
            this.dgv_premios.MultiSelect = false;
            this.dgv_premios.Name = "dgv_premios";
            this.dgv_premios.ReadOnly = true;
            this.dgv_premios.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.dgv_premios.Size = new System.Drawing.Size(344, 145);
            this.dgv_premios.TabIndex = 125;
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(33, 110);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(102, 13);
            this.label3.TabIndex = 126;
            this.label3.Text = "Premios disponibles:";
            // 
            // btCanjear
            // 
            this.btCanjear.Location = new System.Drawing.Point(171, 298);
            this.btCanjear.Name = "btCanjear";
            this.btCanjear.Size = new System.Drawing.Size(75, 23);
            this.btCanjear.TabIndex = 127;
            this.btCanjear.Text = "Canjear";
            this.btCanjear.UseVisualStyleBackColor = true;
            this.btCanjear.Click += new System.EventHandler(this.btCanjear_Click);
            // 
            // FormCanjearPuntos
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(412, 333);
            this.Controls.Add(this.btCanjear);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.dgv_premios);
            this.Controls.Add(this.lbVencimiento);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.lbPuntos);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.label4);
            this.Name = "FormCanjearPuntos";
            this.Text = "Canjear Puntos";
            ((System.ComponentModel.ISupportInitialize)(this.dgv_premios)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label lbPuntos;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label lbVencimiento;
        private System.Windows.Forms.DataGridView dgv_premios;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Button btCanjear;
    }
}