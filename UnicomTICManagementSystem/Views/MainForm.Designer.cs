namespace UnicomTICManagementSystem.Views
{
    partial class MainForm
    {
        private System.ComponentModel.IContainer components = null;

        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        private void InitializeComponent()
        {
            this.SuspendLayout();
            // 
            // MainForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(9F, 20F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;

            // Set background color for main content area
            this.BackColor = System.Drawing.Color.WhiteSmoke;

            // Window size
            this.ClientSize = new System.Drawing.Size(1200, 700);
            this.Font = new System.Drawing.Font("Segoe UI", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            this.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.Name = "MainForm";

            // Custom title
            this.Text = "Unicom TIC Dashboard";

            // Optional: icon (add your own .ico file to resources and assign it here)
            // this.Icon = Properties.Resources.AppIcon;

            // Call load event
            this.Load += new System.EventHandler(this.MainForm_Load);

            this.ResumeLayout(false);
        }

        #endregion
    }
}
