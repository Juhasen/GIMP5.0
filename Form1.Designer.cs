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
            colorDialog = new ColorDialog();
            DrawBox = new GroupBox();
            ThicknessNumericUpDown = new NumericUpDown();
            colorPreviewLabel = new Label();
            colorPreview = new Panel();
            ThicknessLabel = new Label();
            PickColorButton = new Button();
            ((System.ComponentModel.ISupportInitialize)pictureBox).BeginInit();
            Tools.SuspendLayout();
            DrawBox.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)ThicknessNumericUpDown).BeginInit();
            SuspendLayout();
            // 
            // pictureBox
            // 
            pictureBox.Location = new Point(243, 71);
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
            Tools.Size = new Size(1496, 25);
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
            DrawLineButton.Click += DrawButton_Click;
            // 
            // colorDialog
            // 
            colorDialog.Color = Color.DimGray;
            // 
            // DrawBox
            // 
            DrawBox.BackColor = SystemColors.ControlLight;
            DrawBox.Controls.Add(ThicknessNumericUpDown);
            DrawBox.Controls.Add(colorPreviewLabel);
            DrawBox.Controls.Add(colorPreview);
            DrawBox.Controls.Add(ThicknessLabel);
            DrawBox.Controls.Add(PickColorButton);
            DrawBox.Location = new Point(12, 28);
            DrawBox.Name = "DrawBox";
            DrawBox.Size = new Size(156, 198);
            DrawBox.TabIndex = 2;
            DrawBox.TabStop = false;
            DrawBox.Text = "DrawBox";
            DrawBox.Visible = false;
            // 
            // ThicknessNumericUpDown
            // 
            ThicknessNumericUpDown.Font = new Font("Segoe UI", 13F);
            ThicknessNumericUpDown.Location = new Point(57, 154);
            ThicknessNumericUpDown.Maximum = new decimal(new int[] { 10, 0, 0, 0 });
            ThicknessNumericUpDown.Minimum = new decimal(new int[] { 1, 0, 0, 0 });
            ThicknessNumericUpDown.Name = "ThicknessNumericUpDown";
            ThicknessNumericUpDown.Size = new Size(42, 31);
            ThicknessNumericUpDown.TabIndex = 4;
            ThicknessNumericUpDown.Value = new decimal(new int[] { 3, 0, 0, 0 });
            // 
            // colorPreviewLabel
            // 
            colorPreviewLabel.AutoSize = true;
            colorPreviewLabel.Font = new Font("Segoe UI", 12F);
            colorPreviewLabel.Location = new Point(30, 69);
            colorPreviewLabel.Name = "colorPreviewLabel";
            colorPreviewLabel.Size = new Size(51, 21);
            colorPreviewLabel.TabIndex = 0;
            colorPreviewLabel.Text = "Color:";
            // 
            // colorPreview
            // 
            colorPreview.BorderStyle = BorderStyle.Fixed3D;
            colorPreview.Location = new Point(87, 61);
            colorPreview.Name = "colorPreview";
            colorPreview.Size = new Size(26, 29);
            colorPreview.TabIndex = 3;
            // 
            // ThicknessLabel
            // 
            ThicknessLabel.AutoSize = true;
            ThicknessLabel.Font = new Font("Segoe UI", 13F);
            ThicknessLabel.Location = new Point(35, 126);
            ThicknessLabel.Name = "ThicknessLabel";
            ThicknessLabel.Size = new Size(87, 25);
            ThicknessLabel.TabIndex = 2;
            ThicknessLabel.Text = "Thickness";
            // 
            // PickColorButton
            // 
            PickColorButton.BackColor = SystemColors.Menu;
            PickColorButton.Font = new Font("Segoe UI", 10F);
            PickColorButton.Location = new Point(30, 22);
            PickColorButton.Name = "PickColorButton";
            PickColorButton.Size = new Size(92, 33);
            PickColorButton.TabIndex = 0;
            PickColorButton.Text = "Pick color";
            PickColorButton.UseVisualStyleBackColor = false;
            PickColorButton.Click += PickColorButton_Click;
            // 
            // MainForm
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            BackColor = SystemColors.Desktop;
            ClientSize = new Size(1496, 795);
            Controls.Add(DrawBox);
            Controls.Add(Tools);
            Controls.Add(pictureBox);
            Name = "MainForm";
            Text = "GIMP 5.0";
            ((System.ComponentModel.ISupportInitialize)pictureBox).EndInit();
            Tools.ResumeLayout(false);
            Tools.PerformLayout();
            DrawBox.ResumeLayout(false);
            DrawBox.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)ThicknessNumericUpDown).EndInit();
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
        private ColorDialog colorDialog;
        private GroupBox DrawBox;
        private Button PickColorButton;
        private Label ThicknessLabel;
        private Label colorPreviewLabel;
        private Panel colorPreview;
        private NumericUpDown ThicknessNumericUpDown;
    }
}
