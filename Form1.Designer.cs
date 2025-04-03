namespace GIMP5._0
{
    partial class MainForm
    {
        /// <summary>
        ///  Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        ///  Clean up any resources being used.
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
        ///  Required method for Designer support - do not modify
        ///  the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(MainForm));
            pictureBox = new PictureBox();
            Tools = new ToolStrip();
            OpenButton = new ToolStripButton();
            SaveButton = new ToolStripButton();
            GrayscaleButton = new ToolStripButton();
            EdgeDetectButton = new ToolStripButton();
            DrawLineButton = new ToolStripButton();
            ((System.ComponentModel.ISupportInitialize)pictureBox).BeginInit();
            Tools.SuspendLayout();
            SuspendLayout();
            // 
            // pictureBox
            // 
            pictureBox.Location = new Point(0, 28);
            pictureBox.Name = "pictureBox";
            pictureBox.Size = new Size(1199, 656);
            pictureBox.SizeMode = PictureBoxSizeMode.AutoSize;
            pictureBox.TabIndex = 0;
            pictureBox.TabStop = false;
            // 
            // Tools
            // 
            Tools.BackColor = SystemColors.Desktop;
            Tools.Items.AddRange(new ToolStripItem[] { OpenButton, SaveButton, GrayscaleButton, EdgeDetectButton, DrawLineButton });
            Tools.Location = new Point(0, 0);
            Tools.Name = "Tools";
            Tools.Size = new Size(1199, 25);
            Tools.TabIndex = 1;
            Tools.Text = "toolStrip1";
            // 
            // OpenButton
            // 
            OpenButton.AccessibleDescription = "";
            OpenButton.AccessibleName = "";
            OpenButton.BackColor = SystemColors.MenuBar;
            OpenButton.DisplayStyle = ToolStripItemDisplayStyle.Text;
            OpenButton.ImageTransparentColor = Color.Magenta;
            OpenButton.Margin = new Padding(0, 1, 5, 2);
            OpenButton.Name = "OpenButton";
            OpenButton.Size = new Size(40, 22);
            OpenButton.Tag = "";
            OpenButton.Text = "Open";
            OpenButton.Click += OpenButton_Click;
            // 
            // SaveButton
            // 
            SaveButton.BackColor = SystemColors.MenuBar;
            SaveButton.DisplayStyle = ToolStripItemDisplayStyle.Text;
            SaveButton.Image = (Image)resources.GetObject("SaveButton.Image");
            SaveButton.ImageTransparentColor = Color.Magenta;
            SaveButton.Margin = new Padding(0, 1, 5, 2);
            SaveButton.Name = "SaveButton";
            SaveButton.Size = new Size(35, 22);
            SaveButton.Text = "Save";
            SaveButton.Click += SaveButton_Click;
            // 
            // GrayscaleButton
            // 
            GrayscaleButton.BackColor = SystemColors.MenuBar;
            GrayscaleButton.DisplayStyle = ToolStripItemDisplayStyle.Text;
            GrayscaleButton.Image = (Image)resources.GetObject("GrayscaleButton.Image");
            GrayscaleButton.ImageTransparentColor = Color.Magenta;
            GrayscaleButton.Margin = new Padding(0, 1, 5, 2);
            GrayscaleButton.Name = "GrayscaleButton";
            GrayscaleButton.Size = new Size(61, 22);
            GrayscaleButton.Text = "Grayscale";
            GrayscaleButton.Click += GrayscaleButton_Click;
            // 
            // EdgeDetectButton
            // 
            EdgeDetectButton.BackColor = SystemColors.MenuBar;
            EdgeDetectButton.DisplayStyle = ToolStripItemDisplayStyle.Text;
            EdgeDetectButton.Image = (Image)resources.GetObject("EdgeDetectButton.Image");
            EdgeDetectButton.ImageTransparentColor = Color.Magenta;
            EdgeDetectButton.Margin = new Padding(0, 1, 5, 2);
            EdgeDetectButton.Name = "EdgeDetectButton";
            EdgeDetectButton.Size = new Size(79, 22);
            EdgeDetectButton.Text = "Detect edges";
            EdgeDetectButton.ToolTipText = "Detect Edges";
            EdgeDetectButton.Click += EdgeDetectButton_Click;
            // 
            // DrawLineButton
            // 
            DrawLineButton.BackColor = SystemColors.MenuBar;
            DrawLineButton.DisplayStyle = ToolStripItemDisplayStyle.Text;
            DrawLineButton.Image = (Image)resources.GetObject("DrawLineButton.Image");
            DrawLineButton.ImageTransparentColor = Color.Magenta;
            DrawLineButton.Margin = new Padding(0, 1, 5, 2);
            DrawLineButton.Name = "DrawLineButton";
            DrawLineButton.Size = new Size(38, 22);
            DrawLineButton.Text = "Draw";
            DrawLineButton.Click += DrawLineButton_Click;
            // 
            // MainForm
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            BackColor = SystemColors.Desktop;
            ClientSize = new Size(1199, 682);
            Controls.Add(Tools);
            Controls.Add(pictureBox);
            Name = "MainForm";
            Text = "GIMP 5.0";
            ((System.ComponentModel.ISupportInitialize)pictureBox).EndInit();
            Tools.ResumeLayout(false);
            Tools.PerformLayout();
            ResumeLayout(false);
            PerformLayout();
        }


        #endregion

        private PictureBox pictureBox;
        private ToolStrip Tools;
        private ToolStripButton OpenButton;
        private ToolStripButton SaveButton;
        private ToolStripButton GrayscaleButton;
        private ToolStripButton EdgeDetectButton;
        private ToolStripButton DrawLineButton;
    }
}
