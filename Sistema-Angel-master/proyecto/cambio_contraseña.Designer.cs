namespace proyecto
{
    partial class cambio_contraseña
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
            this.windowsUIButtonPanel1 = new DevExpress.XtraBars.Docking2010.WindowsUIButtonPanel();
            this.SuspendLayout();
            // 
            // windowsUIButtonPanel1
            // 
            this.windowsUIButtonPanel1.Buttons.AddRange(new DevExpress.XtraEditors.ButtonPanel.IBaseButton[] {
            new DevExpress.XtraBars.Docking2010.WindowsUIButton(),
            new DevExpress.XtraBars.Docking2010.WindowsUIButton()});
            this.windowsUIButtonPanel1.Location = new System.Drawing.Point(214, 155);
            this.windowsUIButtonPanel1.Name = "windowsUIButtonPanel1";
            this.windowsUIButtonPanel1.Size = new System.Drawing.Size(222, 128);
            this.windowsUIButtonPanel1.TabIndex = 0;
            this.windowsUIButtonPanel1.Text = "windowsUIButtonPanel1";
            // 
            // cambio_contraseña
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(800, 450);
            this.Controls.Add(this.windowsUIButtonPanel1);
            this.Name = "cambio_contraseña";
            this.Text = "cambio_contraseña";
            this.Load += new System.EventHandler(this.cambio_contraseña_Load);
            this.ResumeLayout(false);

        }

        #endregion

        private DevExpress.XtraBars.Docking2010.WindowsUIButtonPanel windowsUIButtonPanel1;
    }
}