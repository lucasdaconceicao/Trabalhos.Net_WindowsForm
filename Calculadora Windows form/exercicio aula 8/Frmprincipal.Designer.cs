namespace exercicio_aula_8
{
    partial class Frmprincipal
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
            this.txtnum = new System.Windows.Forms.TextBox();
            this.btnclick = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // txtnum
            // 
            this.txtnum.Location = new System.Drawing.Point(12, 21);
            this.txtnum.Name = "txtnum";
            this.txtnum.Size = new System.Drawing.Size(150, 20);
            this.txtnum.TabIndex = 4;
            // 
            // btnclick
            // 
            this.btnclick.Location = new System.Drawing.Point(166, 209);
            this.btnclick.Name = "btnclick";
            this.btnclick.Size = new System.Drawing.Size(106, 40);
            this.btnclick.TabIndex = 3;
            this.btnclick.Text = "click";
            this.btnclick.UseVisualStyleBackColor = true;
            this.btnclick.Click += new System.EventHandler(this.btnclick_Click);
            // 
            // Frmprincipal
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(284, 261);
            this.Controls.Add(this.txtnum);
            this.Controls.Add(this.btnclick);
            this.Name = "Frmprincipal";
            this.Text = "Passagem de parametro";
            this.Load += new System.EventHandler(this.Frmprincipal_Load);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.TextBox txtnum;
        private System.Windows.Forms.Button btnclick;
    }
}