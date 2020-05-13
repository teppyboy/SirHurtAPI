namespace SirHurtAPI
{
    internal partial class ScriptHub
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
            this.ScriptLstBox = new System.Windows.Forms.ListBox();
            this.previewImg = new System.Windows.Forms.PictureBox();
            this.previewTxt = new System.Windows.Forms.RichTextBox();
            this.exec = new System.Windows.Forms.Button();
            ((System.ComponentModel.ISupportInitialize)(this.previewImg)).BeginInit();
            this.SuspendLayout();
            // 
            // ScriptLstBox
            // 
            this.ScriptLstBox.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(30)))), ((int)(((byte)(30)))), ((int)(((byte)(30)))));
            this.ScriptLstBox.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.ScriptLstBox.ForeColor = System.Drawing.Color.White;
            this.ScriptLstBox.FormattingEnabled = true;
            this.ScriptLstBox.Location = new System.Drawing.Point(12, 12);
            this.ScriptLstBox.Name = "ScriptLstBox";
            this.ScriptLstBox.Size = new System.Drawing.Size(180, 403);
            this.ScriptLstBox.TabIndex = 0;
            this.ScriptLstBox.SelectedIndexChanged += new System.EventHandler(this.ScriptLstBox_SelectedIndexChanged);
            // 
            // previewImg
            // 
            this.previewImg.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(30)))), ((int)(((byte)(30)))), ((int)(((byte)(30)))));
            this.previewImg.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Zoom;
            this.previewImg.ErrorImage = global::SirHurtAPI.Properties.Resources.asshurt2;
            this.previewImg.Image = global::SirHurtAPI.Properties.Resources.asshurt2;
            this.previewImg.InitialImage = global::SirHurtAPI.Properties.Resources.asshurt2;
            this.previewImg.Location = new System.Drawing.Point(198, 12);
            this.previewImg.Name = "previewImg";
            this.previewImg.Size = new System.Drawing.Size(590, 280);
            this.previewImg.SizeMode = System.Windows.Forms.PictureBoxSizeMode.Zoom;
            this.previewImg.TabIndex = 1;
            this.previewImg.TabStop = false;
            // 
            // previewTxt
            // 
            this.previewTxt.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(30)))), ((int)(((byte)(30)))), ((int)(((byte)(30)))));
            this.previewTxt.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.previewTxt.ForeColor = System.Drawing.Color.White;
            this.previewTxt.Location = new System.Drawing.Point(198, 298);
            this.previewTxt.Name = "previewTxt";
            this.previewTxt.ReadOnly = true;
            this.previewTxt.ScrollBars = System.Windows.Forms.RichTextBoxScrollBars.None;
            this.previewTxt.Size = new System.Drawing.Size(590, 117);
            this.previewTxt.TabIndex = 2;
            this.previewTxt.Text = "";
            // 
            // exec
            // 
            this.exec.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(30)))), ((int)(((byte)(30)))), ((int)(((byte)(30)))));
            this.exec.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.exec.ForeColor = System.Drawing.Color.White;
            this.exec.Location = new System.Drawing.Point(12, 421);
            this.exec.Name = "exec";
            this.exec.Size = new System.Drawing.Size(776, 23);
            this.exec.TabIndex = 3;
            this.exec.Text = "Execute";
            this.exec.UseVisualStyleBackColor = false;
            this.exec.Click += new System.EventHandler(this.exec_Click);
            // 
            // ScriptHub
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(40)))), ((int)(((byte)(40)))), ((int)(((byte)(40)))));
            this.ClientSize = new System.Drawing.Size(800, 450);
            this.Controls.Add(this.ScriptLstBox);
            this.Controls.Add(this.exec);
            this.Controls.Add(this.previewTxt);
            this.Controls.Add(this.previewImg);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
            this.MaximizeBox = false;
            this.Name = "ScriptHub";
            this.Text = "SirHurtAPI - Script Hub";
            ((System.ComponentModel.ISupportInitialize)(this.previewImg)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.ListBox ScriptLstBox;
        private System.Windows.Forms.PictureBox previewImg;
        private System.Windows.Forms.RichTextBox previewTxt;
        private System.Windows.Forms.Button exec;
    }
}