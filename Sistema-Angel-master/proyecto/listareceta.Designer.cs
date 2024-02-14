namespace proyecto
{
    partial class listareceta
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
            this.checkedListBoxRecetas = new System.Windows.Forms.CheckedListBox();
            this.iconButton1 = new FontAwesome.Sharp.IconButton();
            this.SuspendLayout();
            // 
            // checkedListBoxRecetas
            // 
            this.checkedListBoxRecetas.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.checkedListBoxRecetas.FormattingEnabled = true;
            this.checkedListBoxRecetas.Location = new System.Drawing.Point(99, 26);
            this.checkedListBoxRecetas.Name = "checkedListBoxRecetas";
            this.checkedListBoxRecetas.Size = new System.Drawing.Size(353, 444);
            this.checkedListBoxRecetas.TabIndex = 0;
            // 
            // iconButton1
            // 
            this.iconButton1.IconChar = FontAwesome.Sharp.IconChar.None;
            this.iconButton1.IconColor = System.Drawing.Color.Black;
            this.iconButton1.IconFont = FontAwesome.Sharp.IconFont.Auto;
            this.iconButton1.Location = new System.Drawing.Point(226, 485);
            this.iconButton1.Name = "iconButton1";
            this.iconButton1.Size = new System.Drawing.Size(75, 23);
            this.iconButton1.TabIndex = 1;
            this.iconButton1.Text = "listo";
            this.iconButton1.UseVisualStyleBackColor = true;
            this.iconButton1.Click += new System.EventHandler(this.iconButton1_Click);
            // 
            // listareceta
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(546, 562);
            this.Controls.Add(this.iconButton1);
            this.Controls.Add(this.checkedListBoxRecetas);
            this.Name = "listareceta";
            this.Text = "listareceta";
            this.Load += new System.EventHandler(this.listareceta_Load);
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.CheckedListBox checkedListBoxRecetas;
        private FontAwesome.Sharp.IconButton iconButton1;
    }
}