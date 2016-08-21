namespace VideoDownloader
{
    partial class Form1
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(Form1));
            this.tbEpisode0 = new System.Windows.Forms.TextBox();
            this.label1 = new System.Windows.Forms.Label();
            this.cbShow = new System.Windows.Forms.ComboBox();
            this.label2 = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.tbEpisodef = new System.Windows.Forms.TextBox();
            this.tbSaveLocation = new System.Windows.Forms.TextBox();
            this.label4 = new System.Windows.Forms.Label();
            this.btnStart = new System.Windows.Forms.Button();
            this.progressBar1 = new System.Windows.Forms.ProgressBar();
            this.lblProgress1 = new System.Windows.Forms.Label();
            this.lblProgress2 = new System.Windows.Forms.Label();
            this.progressBar2 = new System.Windows.Forms.ProgressBar();
            this.lblPercent2 = new System.Windows.Forms.Label();
            this.label5 = new System.Windows.Forms.Label();
            this.lblPercent1 = new System.Windows.Forms.Label();
            this.lblE0 = new System.Windows.Forms.Label();
            this.lblDash = new System.Windows.Forms.Label();
            this.lblEf = new System.Windows.Forms.Label();
            this.SuspendLayout();
            // 
            // tbEpisode0
            // 
            this.tbEpisode0.Location = new System.Drawing.Point(108, 40);
            this.tbEpisode0.Name = "tbEpisode0";
            this.tbEpisode0.Size = new System.Drawing.Size(45, 20);
            this.tbEpisode0.TabIndex = 0;
            this.tbEpisode0.Text = "1";
            this.tbEpisode0.Leave += new System.EventHandler(this.tbEpisode0_Leave);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(23, 16);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(70, 13);
            this.label1.TabIndex = 1;
            this.label1.Text = "Select Show:";
            // 
            // cbShow
            // 
            this.cbShow.FormattingEnabled = true;
            this.cbShow.Location = new System.Drawing.Point(108, 13);
            this.cbShow.Name = "cbShow";
            this.cbShow.Size = new System.Drawing.Size(229, 21);
            this.cbShow.TabIndex = 2;
            this.cbShow.SelectedIndexChanged += new System.EventHandler(this.cbShow_SelectionChangeCommited);
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(23, 43);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(53, 13);
            this.label2.TabIndex = 3;
            this.label2.Text = "Episodes:";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(160, 43);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(10, 13);
            this.label3.TabIndex = 4;
            this.label3.Text = "-";
            // 
            // tbEpisodef
            // 
            this.tbEpisodef.Location = new System.Drawing.Point(176, 40);
            this.tbEpisodef.Name = "tbEpisodef";
            this.tbEpisodef.Size = new System.Drawing.Size(47, 20);
            this.tbEpisodef.TabIndex = 5;
            this.tbEpisodef.Leave += new System.EventHandler(this.tbEpisodef_Leave);
            // 
            // tbSaveLocation
            // 
            this.tbSaveLocation.Location = new System.Drawing.Point(108, 67);
            this.tbSaveLocation.Name = "tbSaveLocation";
            this.tbSaveLocation.Size = new System.Drawing.Size(229, 20);
            this.tbSaveLocation.TabIndex = 6;
            this.tbSaveLocation.Text = "Z:/TV Shows/";
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(23, 70);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(79, 13);
            this.label4.TabIndex = 7;
            this.label4.Text = "Save Location:";
            // 
            // btnStart
            // 
            this.btnStart.Location = new System.Drawing.Point(148, 218);
            this.btnStart.Name = "btnStart";
            this.btnStart.Size = new System.Drawing.Size(75, 23);
            this.btnStart.TabIndex = 8;
            this.btnStart.Text = "Start";
            this.btnStart.UseVisualStyleBackColor = true;
            this.btnStart.Click += new System.EventHandler(this.button1_Click);
            // 
            // progressBar1
            // 
            this.progressBar1.Location = new System.Drawing.Point(26, 121);
            this.progressBar1.Name = "progressBar1";
            this.progressBar1.Size = new System.Drawing.Size(311, 23);
            this.progressBar1.TabIndex = 9;
            // 
            // lblProgress1
            // 
            this.lblProgress1.AutoSize = true;
            this.lblProgress1.Location = new System.Drawing.Point(26, 102);
            this.lblProgress1.Name = "lblProgress1";
            this.lblProgress1.Size = new System.Drawing.Size(0, 13);
            this.lblProgress1.TabIndex = 10;
            // 
            // lblProgress2
            // 
            this.lblProgress2.AutoSize = true;
            this.lblProgress2.Location = new System.Drawing.Point(26, 151);
            this.lblProgress2.Name = "lblProgress2";
            this.lblProgress2.Size = new System.Drawing.Size(0, 13);
            this.lblProgress2.TabIndex = 11;
            // 
            // progressBar2
            // 
            this.progressBar2.Location = new System.Drawing.Point(26, 168);
            this.progressBar2.Name = "progressBar2";
            this.progressBar2.Size = new System.Drawing.Size(311, 23);
            this.progressBar2.TabIndex = 12;
            // 
            // lblPercent2
            // 
            this.lblPercent2.AutoSize = true;
            this.lblPercent2.Location = new System.Drawing.Point(322, 151);
            this.lblPercent2.Name = "lblPercent2";
            this.lblPercent2.Size = new System.Drawing.Size(0, 13);
            this.lblPercent2.TabIndex = 13;
            this.lblPercent2.TextAlign = System.Drawing.ContentAlignment.TopRight;
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Location = new System.Drawing.Point(182, 120);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(0, 13);
            this.label5.TabIndex = 14;
            this.label5.TextAlign = System.Drawing.ContentAlignment.TopRight;
            // 
            // lblPercent1
            // 
            this.lblPercent1.AutoSize = true;
            this.lblPercent1.Location = new System.Drawing.Point(322, 102);
            this.lblPercent1.Name = "lblPercent1";
            this.lblPercent1.Size = new System.Drawing.Size(0, 13);
            this.lblPercent1.TabIndex = 15;
            this.lblPercent1.TextAlign = System.Drawing.ContentAlignment.TopRight;
            // 
            // lblE0
            // 
            this.lblE0.AutoSize = true;
            this.lblE0.Location = new System.Drawing.Point(230, 42);
            this.lblE0.Name = "lblE0";
            this.lblE0.Size = new System.Drawing.Size(0, 13);
            this.lblE0.TabIndex = 16;            
            // 
            // lblDash
            // 
            this.lblDash.AutoSize = true;
            this.lblDash.Location = new System.Drawing.Point(272, 42);
            this.lblDash.Name = "lblDash";
            this.lblDash.Size = new System.Drawing.Size(10, 13);
            this.lblDash.TabIndex = 17;
            this.lblDash.Text = "-";
            // 
            // lblEf
            // 
            this.lblEf.AutoSize = true;
            this.lblEf.Location = new System.Drawing.Point(289, 42);
            this.lblEf.Name = "lblEf";
            this.lblEf.Size = new System.Drawing.Size(0, 13);
            this.lblEf.TabIndex = 18;
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(364, 253);
            this.Controls.Add(this.lblEf);
            this.Controls.Add(this.lblDash);
            this.Controls.Add(this.lblE0);
            this.Controls.Add(this.lblPercent1);
            this.Controls.Add(this.label5);
            this.Controls.Add(this.lblPercent2);
            this.Controls.Add(this.progressBar2);
            this.Controls.Add(this.lblProgress2);
            this.Controls.Add(this.lblProgress1);
            this.Controls.Add(this.progressBar1);
            this.Controls.Add(this.btnStart);
            this.Controls.Add(this.label4);
            this.Controls.Add(this.tbSaveLocation);
            this.Controls.Add(this.tbEpisodef);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.cbShow);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.tbEpisode0);
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.Name = "Form1";
            this.Text = "Video Downloader";
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.TextBox tbEpisode0;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.ComboBox cbShow;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.TextBox tbEpisodef;
        private System.Windows.Forms.TextBox tbSaveLocation;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.Button btnStart;
        private System.Windows.Forms.ProgressBar progressBar1;
        private System.Windows.Forms.Label lblProgress1;
        private System.Windows.Forms.Label lblProgress2;
        private System.Windows.Forms.ProgressBar progressBar2;
        private System.Windows.Forms.Label lblPercent2;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.Label lblPercent1;
        private System.Windows.Forms.Label lblE0;
        private System.Windows.Forms.Label lblDash;
        private System.Windows.Forms.Label lblEf;
    }
}