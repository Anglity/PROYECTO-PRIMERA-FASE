namespace proyecto
{
    partial class fnotificaciones
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
            this.listBoxNotificaciones = new System.Windows.Forms.ListView();
            this.SuspendLayout();
            // 
            // listBoxNotificaciones
            // 
            this.listBoxNotificaciones.HideSelection = false;
            this.listBoxNotificaciones.Location = new System.Drawing.Point(12, 23);
            this.listBoxNotificaciones.Name = "listBoxNotificaciones";
            this.listBoxNotificaciones.Size = new System.Drawing.Size(374, 560);
            this.listBoxNotificaciones.TabIndex = 0;
            this.listBoxNotificaciones.UseCompatibleStateImageBehavior = false;
            // 
            // fnotificaciones
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(398, 595);
            this.Controls.Add(this.listBoxNotificaciones);
            this.Name = "fnotificaciones";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "fnotificaciones";
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.ListView listBoxNotificaciones;
    }
}