
namespace FootballMatchProject
{
    partial class window
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
            this.label_ballheader = new System.Windows.Forms.Label();
            this.label_chosen = new System.Windows.Forms.Label();
            this.label_teamsheader = new System.Windows.Forms.Label();
            this.label_matchesheader = new System.Windows.Forms.Label();
            this.button_ball = new System.Windows.Forms.Button();
            this.button_skip = new System.Windows.Forms.Button();
            this.button_reset = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // label_ballheader
            // 
            this.label_ballheader.AutoSize = true;
            this.label_ballheader.Font = new System.Drawing.Font("Microsoft Sans Serif", 15F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label_ballheader.Location = new System.Drawing.Point(661, 348);
            this.label_ballheader.Name = "label_ballheader";
            this.label_ballheader.Size = new System.Drawing.Size(129, 25);
            this.label_ballheader.TabIndex = 0;
            this.label_ballheader.Text = "Chosen Ball";
            this.label_ballheader.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // label_chosen
            // 
            this.label_chosen.AutoSize = true;
            this.label_chosen.Font = new System.Drawing.Font("Microsoft Sans Serif", 20F);
            this.label_chosen.Location = new System.Drawing.Point(685, 387);
            this.label_chosen.Name = "label_chosen";
            this.label_chosen.Size = new System.Drawing.Size(79, 31);
            this.label_chosen.TabIndex = 1;
            this.label_chosen.Text = "None";
            this.label_chosen.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // label_teamsheader
            // 
            this.label_teamsheader.AutoSize = true;
            this.label_teamsheader.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label_teamsheader.Location = new System.Drawing.Point(13, 13);
            this.label_teamsheader.Name = "label_teamsheader";
            this.label_teamsheader.Size = new System.Drawing.Size(100, 13);
            this.label_teamsheader.TabIndex = 2;
            this.label_teamsheader.Text = "Available Teams";
            // 
            // label_matchesheader
            // 
            this.label_matchesheader.AutoSize = true;
            this.label_matchesheader.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label_matchesheader.Location = new System.Drawing.Point(265, 13);
            this.label_matchesheader.Name = "label_matchesheader";
            this.label_matchesheader.Size = new System.Drawing.Size(55, 13);
            this.label_matchesheader.TabIndex = 3;
            this.label_matchesheader.Text = "Matches";
            // 
            // button_ball
            // 
            this.button_ball.Font = new System.Drawing.Font("Microsoft Sans Serif", 14.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.button_ball.Location = new System.Drawing.Point(638, 12);
            this.button_ball.Name = "button_ball";
            this.button_ball.Size = new System.Drawing.Size(150, 41);
            this.button_ball.TabIndex = 4;
            this.button_ball.Text = "Draw Next Ball";
            this.button_ball.UseVisualStyleBackColor = true;
            this.button_ball.Click += new System.EventHandler(this.button_ball_Click);
            // 
            // button_skip
            // 
            this.button_skip.Font = new System.Drawing.Font("Microsoft Sans Serif", 14.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.button_skip.Location = new System.Drawing.Point(638, 59);
            this.button_skip.Name = "button_skip";
            this.button_skip.Size = new System.Drawing.Size(150, 41);
            this.button_skip.TabIndex = 5;
            this.button_skip.Text = "Skip To End";
            this.button_skip.UseVisualStyleBackColor = true;
            // 
            // button_reset
            // 
            this.button_reset.Font = new System.Drawing.Font("Microsoft Sans Serif", 14.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.button_reset.Location = new System.Drawing.Point(638, 106);
            this.button_reset.Name = "button_reset";
            this.button_reset.Size = new System.Drawing.Size(150, 41);
            this.button_reset.TabIndex = 6;
            this.button_reset.Text = "Reset";
            this.button_reset.UseVisualStyleBackColor = true;
            this.button_reset.Click += new System.EventHandler(this.button_reset_Click);
            // 
            // window
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(800, 450);
            this.Controls.Add(this.button_reset);
            this.Controls.Add(this.button_skip);
            this.Controls.Add(this.button_ball);
            this.Controls.Add(this.label_matchesheader);
            this.Controls.Add(this.label_teamsheader);
            this.Controls.Add(this.label_chosen);
            this.Controls.Add(this.label_ballheader);
            this.Name = "window";
            this.Text = "The Ball Selector";
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label label_ballheader;
        private System.Windows.Forms.Label label_chosen;
        private System.Windows.Forms.Label label_teamsheader;
        private System.Windows.Forms.Label label_matchesheader;
        private System.Windows.Forms.Button button_ball;
        private System.Windows.Forms.Button button_skip;
        private System.Windows.Forms.Button button_reset;
    }
}

