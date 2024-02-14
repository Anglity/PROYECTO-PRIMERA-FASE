namespace proyecto
{
    partial class fplanificacion
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
            this.BtnMostrarRecetas_Click = new FontAwesome.Sharp.IconButton();
            this.iconButton1 = new FontAwesome.Sharp.IconButton();
            this.SuspendLayout();
            // 
            // BtnMostrarRecetas_Click
            // 
            this.BtnMostrarRecetas_Click.IconChar = FontAwesome.Sharp.IconChar.None;
            this.BtnMostrarRecetas_Click.IconColor = System.Drawing.Color.Black;
            this.BtnMostrarRecetas_Click.IconFont = FontAwesome.Sharp.IconFont.Auto;
            this.BtnMostrarRecetas_Click.Location = new System.Drawing.Point(12, 359);
            this.BtnMostrarRecetas_Click.Name = "BtnMostrarRecetas_Click";
            this.BtnMostrarRecetas_Click.Size = new System.Drawing.Size(79, 42);
            this.BtnMostrarRecetas_Click.TabIndex = 0;
            this.BtnMostrarRecetas_Click.Text = "agregar";
            this.BtnMostrarRecetas_Click.UseVisualStyleBackColor = true;
            this.BtnMostrarRecetas_Click.Click += new System.EventHandler(this.BtnMostrarRecetas_Click_Click);
            // 
            // iconButton1
            // 
            this.iconButton1.IconChar = FontAwesome.Sharp.IconChar.None;
            this.iconButton1.IconColor = System.Drawing.Color.Black;
            this.iconButton1.IconFont = FontAwesome.Sharp.IconFont.Auto;
            this.iconButton1.Location = new System.Drawing.Point(97, 359);
            this.iconButton1.Name = "iconButton1";
            this.iconButton1.Size = new System.Drawing.Size(79, 42);
            this.iconButton1.TabIndex = 1;
            this.iconButton1.Text = "Eliminar";
            this.iconButton1.UseVisualStyleBackColor = true;
            this.iconButton1.Click += new System.EventHandler(this.iconButton1_Click);
            // 
            // fplanificacion
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1324, 604);
            this.Controls.Add(this.iconButton1);
            this.Controls.Add(this.BtnMostrarRecetas_Click);
            this.Name = "fplanificacion";
            this.Text = "fplanificacion";
            this.ResumeLayout(false);

        }

        #endregion

        private FontAwesome.Sharp.IconButton BtnMostrarRecetas_Click;
        private FontAwesome.Sharp.IconButton iconButton1;
    }
}