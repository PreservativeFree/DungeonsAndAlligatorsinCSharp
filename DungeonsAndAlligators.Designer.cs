namespace DungeonsAndAlligators
{
    partial class DungeonForm
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
            this.DungeonFloor = new System.Windows.Forms.PictureBox();
            this.theTracker = new System.Windows.Forms.Label();
            this.RevealTraps = new System.Windows.Forms.Label();
            this.treasureTracker = new System.Windows.Forms.Label();
            this.deathNoticeLabel = new System.Windows.Forms.Label();
            ((System.ComponentModel.ISupportInitialize)(this.DungeonFloor)).BeginInit();
            this.SuspendLayout();
            // 
            // DungeonFloor
            // 
            this.DungeonFloor.BackColor = System.Drawing.Color.Transparent;
            this.DungeonFloor.Location = new System.Drawing.Point(0, 0);
            this.DungeonFloor.Name = "DungeonFloor";
            this.DungeonFloor.Size = new System.Drawing.Size(600, 600);
            this.DungeonFloor.TabIndex = 0;
            this.DungeonFloor.TabStop = false;
            this.DungeonFloor.Paint += new System.Windows.Forms.PaintEventHandler(this.DungeonFloor_Paint);
            // 
            // theTracker
            // 
            this.theTracker.AutoSize = true;
            this.theTracker.Location = new System.Drawing.Point(634, 29);
            this.theTracker.Name = "theTracker";
            this.theTracker.Size = new System.Drawing.Size(93, 13);
            this.theTracker.TabIndex = 1;
            this.theTracker.Text = "Challenger Status:";
            // 
            // RevealTraps
            // 
            this.RevealTraps.AutoSize = true;
            this.RevealTraps.Location = new System.Drawing.Point(637, 218);
            this.RevealTraps.Name = "RevealTraps";
            this.RevealTraps.Size = new System.Drawing.Size(78, 13);
            this.RevealTraps.TabIndex = 2;
            this.RevealTraps.Text = "Trap Locations";
            // 
            // treasureTracker
            // 
            this.treasureTracker.AutoSize = true;
            this.treasureTracker.Location = new System.Drawing.Point(637, 356);
            this.treasureTracker.Name = "treasureTracker";
            this.treasureTracker.Size = new System.Drawing.Size(87, 13);
            this.treasureTracker.TabIndex = 3;
            this.treasureTracker.Text = "Treasures Found";
            // 
            // deathNoticeLabel
            // 
            this.deathNoticeLabel.AutoSize = true;
            this.deathNoticeLabel.Location = new System.Drawing.Point(637, 125);
            this.deathNoticeLabel.Name = "deathNoticeLabel";
            this.deathNoticeLabel.Size = new System.Drawing.Size(94, 13);
            this.deathNoticeLabel.TabIndex = 4;
            this.deathNoticeLabel.Text = "Challenger Health:";
            // 
            // DungeonForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1023, 600);
            this.Controls.Add(this.deathNoticeLabel);
            this.Controls.Add(this.treasureTracker);
            this.Controls.Add(this.RevealTraps);
            this.Controls.Add(this.theTracker);
            this.Controls.Add(this.DungeonFloor);
            this.Name = "DungeonForm";
            this.Text = "Dungeons and Alligators";
            this.Load += new System.EventHandler(this.DungeonForm_Load);
            this.Paint += new System.Windows.Forms.PaintEventHandler(this.DungeonForm_Paint);
            this.KeyDown += new System.Windows.Forms.KeyEventHandler(this.DungeonForm_KeyDown);
            this.KeyUp += new System.Windows.Forms.KeyEventHandler(this.DungeonForm_KeyUp);
            ((System.ComponentModel.ISupportInitialize)(this.DungeonFloor)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.PictureBox DungeonFloor;
        private System.Windows.Forms.Label theTracker;
        private System.Windows.Forms.Label RevealTraps;
        private System.Windows.Forms.Label treasureTracker;
        private System.Windows.Forms.Label deathNoticeLabel;
    }
}

