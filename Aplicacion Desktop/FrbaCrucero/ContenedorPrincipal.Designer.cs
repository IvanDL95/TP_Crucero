namespace FrbaCrucero
{
    partial class ContenedorPrincipal
    {
        /// <summary>
        /// Variable del diseñador requerida.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Limpiar los recursos que se estén utilizando.
        /// </summary>
        /// <param name="disposing">true si los recursos administrados se deben eliminar; false en caso contrario.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Código generado por el Diseñador de Windows Forms

        /// <summary>
        /// Método necesario para admitir el Diseñador. No se puede modificar
        /// el contenido del método con el editor de código.
        /// </summary>
        private void InitializeComponent()
        {
            this.components = new System.ComponentModel.Container();
            this.menuStrip = new System.Windows.Forms.MenuStrip();
            this.fileMenu = new System.Windows.Forms.ToolStripMenuItem();
            this.toolStripSeparator5 = new System.Windows.Forms.ToolStripSeparator();
            this.cerrarSesionToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.cambiarClienteToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.exitToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.aBMToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.aBMRolToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.aBMPuertoToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.aBMRecorridoToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.aBMCruceroToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.accionesToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.comprarReservarViajeToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.pagoReservaToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.registroToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.generarViajeToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.listadoToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.estadísticoToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.toolStrip = new System.Windows.Forms.ToolStrip();
            this.statusStrip = new System.Windows.Forms.StatusStrip();
            this.toolStripStatusLabel = new System.Windows.Forms.ToolStripStatusLabel();
            this.toolTip = new System.Windows.Forms.ToolTip(this.components);
            this.menuStrip.SuspendLayout();
            this.statusStrip.SuspendLayout();
            this.SuspendLayout();
            // 
            // menuStrip
            // 
            this.menuStrip.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.fileMenu,
            this.aBMToolStripMenuItem,
            this.accionesToolStripMenuItem,
            this.registroToolStripMenuItem,
            this.listadoToolStripMenuItem});
            this.menuStrip.Location = new System.Drawing.Point(0, 0);
            this.menuStrip.Name = "menuStrip";
            this.menuStrip.Size = new System.Drawing.Size(747, 24);
            this.menuStrip.TabIndex = 0;
            this.menuStrip.Text = "MenuStrip";
            // 
            // fileMenu
            // 
            this.fileMenu.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.toolStripSeparator5,
            this.cerrarSesionToolStripMenuItem,
            this.cambiarClienteToolStripMenuItem,
            this.exitToolStripMenuItem});
            this.fileMenu.ImageTransparentColor = System.Drawing.SystemColors.ActiveBorder;
            this.fileMenu.Name = "fileMenu";
            this.fileMenu.Size = new System.Drawing.Size(48, 20);
            this.fileMenu.Text = "&Inicio";
            // 
            // toolStripSeparator5
            // 
            this.toolStripSeparator5.Name = "toolStripSeparator5";
            this.toolStripSeparator5.Size = new System.Drawing.Size(149, 6);
            // 
            // cerrarSesionToolStripMenuItem
            // 
            this.cerrarSesionToolStripMenuItem.Name = "cerrarSesionToolStripMenuItem";
            this.cerrarSesionToolStripMenuItem.Size = new System.Drawing.Size(152, 22);
            this.cerrarSesionToolStripMenuItem.Text = "Cerrar Sesion";
            this.cerrarSesionToolStripMenuItem.Click += new System.EventHandler(this.cerrarSesionToolStripMenuItem_Click);
            // 
            // cambiarClienteToolStripMenuItem
            // 
            this.cambiarClienteToolStripMenuItem.Name = "cambiarClienteToolStripMenuItem";
            this.cambiarClienteToolStripMenuItem.Size = new System.Drawing.Size(152, 22);
            this.cambiarClienteToolStripMenuItem.Text = "Volver al inicio";
            this.cambiarClienteToolStripMenuItem.Click += new System.EventHandler(this.cambiarClienteToolStripMenuItem_Click);
            // 
            // exitToolStripMenuItem
            // 
            this.exitToolStripMenuItem.AccessibleRole = System.Windows.Forms.AccessibleRole.None;
            this.exitToolStripMenuItem.Name = "exitToolStripMenuItem";
            this.exitToolStripMenuItem.Size = new System.Drawing.Size(152, 22);
            this.exitToolStripMenuItem.Text = "&Salir";
            this.exitToolStripMenuItem.Click += new System.EventHandler(this.ExitToolsStripMenuItem_Click);
            // 
            // aBMToolStripMenuItem
            // 
            this.aBMToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.aBMRolToolStripMenuItem,
            this.aBMPuertoToolStripMenuItem,
            this.aBMRecorridoToolStripMenuItem,
            this.aBMCruceroToolStripMenuItem});
            this.aBMToolStripMenuItem.Name = "aBMToolStripMenuItem";
            this.aBMToolStripMenuItem.Size = new System.Drawing.Size(45, 20);
            this.aBMToolStripMenuItem.Text = "A&BM";
            // 
            // aBMRolToolStripMenuItem
            // 
            this.aBMRolToolStripMenuItem.Name = "aBMRolToolStripMenuItem";
            this.aBMRolToolStripMenuItem.Size = new System.Drawing.Size(154, 22);
            this.aBMRolToolStripMenuItem.Text = "ABM Rol";
            this.aBMRolToolStripMenuItem.Click += new System.EventHandler(this.aBMRolToolStripMenuItem_Click);
            // 
            // aBMPuertoToolStripMenuItem
            // 
            this.aBMPuertoToolStripMenuItem.Name = "aBMPuertoToolStripMenuItem";
            this.aBMPuertoToolStripMenuItem.Size = new System.Drawing.Size(154, 22);
            this.aBMPuertoToolStripMenuItem.Text = "ABM Puerto";
            this.aBMPuertoToolStripMenuItem.Click += new System.EventHandler(this.aBMPuertoToolStripMenuItem_Click);
            // 
            // aBMRecorridoToolStripMenuItem
            // 
            this.aBMRecorridoToolStripMenuItem.Name = "aBMRecorridoToolStripMenuItem";
            this.aBMRecorridoToolStripMenuItem.Size = new System.Drawing.Size(154, 22);
            this.aBMRecorridoToolStripMenuItem.Text = "ABM Recorrido";
            this.aBMRecorridoToolStripMenuItem.Click += new System.EventHandler(this.aBMRecorridoToolStripMenuItem_Click);
            // 
            // aBMCruceroToolStripMenuItem
            // 
            this.aBMCruceroToolStripMenuItem.Name = "aBMCruceroToolStripMenuItem";
            this.aBMCruceroToolStripMenuItem.Size = new System.Drawing.Size(154, 22);
            this.aBMCruceroToolStripMenuItem.Text = "ABM Crucero";
            this.aBMCruceroToolStripMenuItem.Click += new System.EventHandler(this.aBMCruceroToolStripMenuItem_Click);
            // 
            // accionesToolStripMenuItem
            // 
            this.accionesToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.comprarReservarViajeToolStripMenuItem,
            this.pagoReservaToolStripMenuItem});
            this.accionesToolStripMenuItem.Name = "accionesToolStripMenuItem";
            this.accionesToolStripMenuItem.Size = new System.Drawing.Size(67, 20);
            this.accionesToolStripMenuItem.Text = "A&cciones";
            // 
            // comprarReservarViajeToolStripMenuItem
            // 
            this.comprarReservarViajeToolStripMenuItem.Name = "comprarReservarViajeToolStripMenuItem";
            this.comprarReservarViajeToolStripMenuItem.Size = new System.Drawing.Size(225, 22);
            this.comprarReservarViajeToolStripMenuItem.Text = "Comprar y/o reserva de viaje";
            this.comprarReservarViajeToolStripMenuItem.Click += new System.EventHandler(this.comprarReservarViajeToolStripMenuItem_Click);
            // 
            // pagoReservaToolStripMenuItem
            // 
            this.pagoReservaToolStripMenuItem.Name = "pagoReservaToolStripMenuItem";
            this.pagoReservaToolStripMenuItem.Size = new System.Drawing.Size(225, 22);
            this.pagoReservaToolStripMenuItem.Text = "Pago de reserva";
            this.pagoReservaToolStripMenuItem.Click += new System.EventHandler(this.pagoReservaToolStripMenuItem_Click);
            // 
            // registroToolStripMenuItem
            // 
            this.registroToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.generarViajeToolStripMenuItem});
            this.registroToolStripMenuItem.Name = "registroToolStripMenuItem";
            this.registroToolStripMenuItem.Size = new System.Drawing.Size(44, 20);
            this.registroToolStripMenuItem.Text = "&Viaje";
            // 
            // generarViajeToolStripMenuItem
            // 
            this.generarViajeToolStripMenuItem.Name = "generarViajeToolStripMenuItem";
            this.generarViajeToolStripMenuItem.Size = new System.Drawing.Size(115, 22);
            this.generarViajeToolStripMenuItem.Text = "Generar";
            this.generarViajeToolStripMenuItem.Click += new System.EventHandler(this.generarViajeToolStripMenuItem_Click);
            // 
            // listadoToolStripMenuItem
            // 
            this.listadoToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.estadísticoToolStripMenuItem});
            this.listadoToolStripMenuItem.Name = "listadoToolStripMenuItem";
            this.listadoToolStripMenuItem.Size = new System.Drawing.Size(57, 20);
            this.listadoToolStripMenuItem.Text = "&Listado";
            // 
            // estadísticoToolStripMenuItem
            // 
            this.estadísticoToolStripMenuItem.Name = "estadísticoToolStripMenuItem";
            this.estadísticoToolStripMenuItem.Size = new System.Drawing.Size(130, 22);
            this.estadísticoToolStripMenuItem.Text = "Estadístico";
            this.estadísticoToolStripMenuItem.Click += new System.EventHandler(this.estadísticoToolStripMenuItem_Click);
            // 
            // toolStrip
            // 
            this.toolStrip.Location = new System.Drawing.Point(0, 24);
            this.toolStrip.Name = "toolStrip";
            this.toolStrip.Size = new System.Drawing.Size(747, 25);
            this.toolStrip.TabIndex = 1;
            this.toolStrip.Text = "ToolStrip";
            // 
            // statusStrip
            // 
            this.statusStrip.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.toolStripStatusLabel});
            this.statusStrip.Location = new System.Drawing.Point(0, 431);
            this.statusStrip.Name = "statusStrip";
            this.statusStrip.Size = new System.Drawing.Size(747, 22);
            this.statusStrip.TabIndex = 2;
            this.statusStrip.Text = "StatusStrip";
            // 
            // toolStripStatusLabel
            // 
            this.toolStripStatusLabel.Name = "toolStripStatusLabel";
            this.toolStripStatusLabel.Size = new System.Drawing.Size(42, 17);
            this.toolStripStatusLabel.Text = "Estado";
            // 
            // ContenedorPrincipal
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(747, 453);
            this.Controls.Add(this.statusStrip);
            this.Controls.Add(this.toolStrip);
            this.Controls.Add(this.menuStrip);
            this.IsMdiContainer = true;
            this.MainMenuStrip = this.menuStrip;
            this.Name = "ContenedorPrincipal";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "FRBA CRUCERO";
            this.WindowState = System.Windows.Forms.FormWindowState.Maximized;
            this.Load += new System.EventHandler(this.ContenedorPrincipal_Load);
            this.menuStrip.ResumeLayout(false);
            this.menuStrip.PerformLayout();
            this.statusStrip.ResumeLayout(false);
            this.statusStrip.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }
        #endregion


        private System.Windows.Forms.MenuStrip menuStrip;
        private System.Windows.Forms.ToolStrip toolStrip;
        private System.Windows.Forms.StatusStrip statusStrip;
        private System.Windows.Forms.ToolStripSeparator toolStripSeparator5;
        private System.Windows.Forms.ToolStripStatusLabel toolStripStatusLabel;
        private System.Windows.Forms.ToolStripMenuItem fileMenu;
        private System.Windows.Forms.ToolStripMenuItem exitToolStripMenuItem;
        private System.Windows.Forms.ToolTip toolTip;
        private System.Windows.Forms.ToolStripMenuItem aBMToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem aBMRolToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem accionesToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem comprarReservarViajeToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem pagoReservaToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem registroToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem generarViajeToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem listadoToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem estadísticoToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem aBMPuertoToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem aBMRecorridoToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem cerrarSesionToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem aBMCruceroToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem cambiarClienteToolStripMenuItem;
    }
}



