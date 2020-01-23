namespace SirHurtAPI_Demo_App
{
    partial class MainForm
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
            this.scriptBox = new System.Windows.Forms.RichTextBox();
            this.InjectBtn = new System.Windows.Forms.Button();
            this.Clear = new System.Windows.Forms.Button();
            this.Execute = new System.Windows.Forms.Button();
            this.EFF = new System.Windows.Forms.Button();
            this.oof123 = new System.Windows.Forms.Button();
            this.injectedstring = new System.Windows.Forms.Label();
            this.InjectedCheck = new System.Windows.Forms.Timer(this.components);
            this.AutoIJEx = new System.Windows.Forms.Button();
            this.button1 = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // scriptBox
            // 
            this.scriptBox.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.scriptBox.Location = new System.Drawing.Point(1, 28);
            this.scriptBox.Name = "scriptBox";
            this.scriptBox.Size = new System.Drawing.Size(798, 390);
            this.scriptBox.TabIndex = 0;
            this.scriptBox.Text = "--This is an app using SirHurtAPI.\n";
            // 
            // InjectBtn
            // 
            this.InjectBtn.Location = new System.Drawing.Point(12, 424);
            this.InjectBtn.Name = "InjectBtn";
            this.InjectBtn.Size = new System.Drawing.Size(75, 23);
            this.InjectBtn.TabIndex = 1;
            this.InjectBtn.Text = "Inject";
            this.InjectBtn.UseVisualStyleBackColor = true;
            this.InjectBtn.Click += new System.EventHandler(this.InjectBtn_Click);
            // 
            // Clear
            // 
            this.Clear.Location = new System.Drawing.Point(713, 424);
            this.Clear.Name = "Clear";
            this.Clear.Size = new System.Drawing.Size(75, 23);
            this.Clear.TabIndex = 2;
            this.Clear.Text = "Clear";
            this.Clear.UseVisualStyleBackColor = true;
            this.Clear.Click += new System.EventHandler(this.Clear_Click);
            // 
            // Execute
            // 
            this.Execute.Location = new System.Drawing.Point(230, 424);
            this.Execute.Name = "Execute";
            this.Execute.Size = new System.Drawing.Size(242, 23);
            this.Execute.TabIndex = 3;
            this.Execute.Text = "Execute";
            this.Execute.UseVisualStyleBackColor = true;
            this.Execute.Click += new System.EventHandler(this.Execute_Click);
            // 
            // EFF
            // 
            this.EFF.Location = new System.Drawing.Point(478, 424);
            this.EFF.Name = "EFF";
            this.EFF.Size = new System.Drawing.Size(229, 23);
            this.EFF.TabIndex = 4;
            this.EFF.Text = "Execute from file";
            this.EFF.UseVisualStyleBackColor = true;
            this.EFF.Click += new System.EventHandler(this.EFF_Click);
            // 
            // oof123
            // 
            this.oof123.Location = new System.Drawing.Point(1, 2);
            this.oof123.Name = "oof123";
            this.oof123.Size = new System.Drawing.Size(367, 23);
            this.oof123.TabIndex = 5;
            this.oof123.Text = "Auto Inject: False";
            this.oof123.UseVisualStyleBackColor = true;
            this.oof123.Click += new System.EventHandler(this.oof123_Click);
            // 
            // injectedstring
            // 
            this.injectedstring.AutoSize = true;
            this.injectedstring.Location = new System.Drawing.Point(726, 7);
            this.injectedstring.Name = "injectedstring";
            this.injectedstring.Size = new System.Drawing.Size(73, 13);
            this.injectedstring.TabIndex = 6;
            this.injectedstring.Text = "Injected: false";
            // 
            // InjectedCheck
            // 
            this.InjectedCheck.Enabled = true;
            this.InjectedCheck.Tick += new System.EventHandler(this.InjectedCheck_Tick);
            // 
            // AutoIJEx
            // 
            this.AutoIJEx.Location = new System.Drawing.Point(374, 2);
            this.AutoIJEx.Name = "AutoIJEx";
            this.AutoIJEx.Size = new System.Drawing.Size(346, 23);
            this.AutoIJEx.TabIndex = 7;
            this.AutoIJEx.Text = "Auto Inject [Experimental]: False";
            this.AutoIJEx.UseVisualStyleBackColor = true;
            this.AutoIJEx.Click += new System.EventHandler(this.AutoIJEx_Click);
            // 
            // button1
            // 
            this.button1.Location = new System.Drawing.Point(93, 424);
            this.button1.Name = "button1";
            this.button1.Size = new System.Drawing.Size(131, 23);
            this.button1.TabIndex = 8;
            this.button1.Text = "Inject [Experimental]";
            this.button1.UseVisualStyleBackColor = true;
            this.button1.Click += new System.EventHandler(this.button1_Click);
            // 
            // MainForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(800, 450);
            this.Controls.Add(this.button1);
            this.Controls.Add(this.AutoIJEx);
            this.Controls.Add(this.injectedstring);
            this.Controls.Add(this.oof123);
            this.Controls.Add(this.EFF);
            this.Controls.Add(this.Execute);
            this.Controls.Add(this.Clear);
            this.Controls.Add(this.InjectBtn);
            this.Controls.Add(this.scriptBox);
            this.MaximizeBox = false;
            this.Name = "MainForm";
            this.Text = "SirHurtAPI Demo Application";
            this.FormClosing += new System.Windows.Forms.FormClosingEventHandler(this.MainForm_FormClosing);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.RichTextBox scriptBox;
        private System.Windows.Forms.Button InjectBtn;
        private System.Windows.Forms.Button Clear;
        private System.Windows.Forms.Button Execute;
        private System.Windows.Forms.Button EFF;
        private System.Windows.Forms.Button oof123;
        private System.Windows.Forms.Label injectedstring;
        private System.Windows.Forms.Timer InjectedCheck;
        private System.Windows.Forms.Button AutoIJEx;
        private System.Windows.Forms.Button button1;
    }
}

