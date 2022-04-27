namespace PolymerMotionSimulationGUI
{
    public partial class SimulationGuiForm
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
            this.abort = new System.Windows.Forms.Button();
            this.suspend = new System.Windows.Forms.Button();
            this.resume = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // abort
            // 
            this.abort.Location = new System.Drawing.Point(13, 226);
            this.abort.Name = "abort";
            this.abort.Size = new System.Drawing.Size(75, 23);
            this.abort.TabIndex = 0;
            this.abort.Text = "abort";
            this.abort.UseVisualStyleBackColor = true;
            this.abort.Click += new System.EventHandler(this.Abort_Click);
            // 
            // suspend
            // 
            this.suspend.Location = new System.Drawing.Point(95, 225);
            this.suspend.Name = "suspend";
            this.suspend.Size = new System.Drawing.Size(75, 23);
            this.suspend.TabIndex = 1;
            this.suspend.Text = "suspend";
            this.suspend.UseVisualStyleBackColor = true;
            this.suspend.Click += new System.EventHandler(this.Suspend_Click);
            // 
            // resume
            // 
            this.resume.Location = new System.Drawing.Point(186, 224);
            this.resume.Name = "resume";
            this.resume.Size = new System.Drawing.Size(75, 23);
            this.resume.TabIndex = 2;
            this.resume.Text = "resume";
            this.resume.UseVisualStyleBackColor = true;
            this.resume.Click += new System.EventHandler(this.Resume_Click);
            // 
            // AnimateBall
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(284, 261);
            this.Controls.Add(this.resume);
            this.Controls.Add(this.suspend);
            this.Controls.Add(this.abort);
            this.Name = "AnimateBall";
            this.Text = "Form1";
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Button abort;
        private System.Windows.Forms.Button suspend;
        private System.Windows.Forms.Button resume;
    }
}

