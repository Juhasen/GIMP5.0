using AForge.Imaging;
using AForge.Imaging.Filters;
using System;
using System.Drawing;
using System.Drawing.Drawing2D;
using System.IO;
using System.Windows.Forms;

namespace GIMP5._0
{
    public partial class MainForm : Form
    {
        #region Fields
        private Bitmap currentImage;
        private Color drawColor = Color.Red;
        private int drawThickness = 3;
        private bool isDrawingEnabled = false;
        private bool isDrawing = false;
        private Point lastPoint;
        #endregion

        #region Initialization
        /// <summary>
        /// Main form constructor
        /// </summary>
        public MainForm()
        {
            InitializeComponent();
            this.Load += MainForm_Load;
        }

        /// <summary>
        /// Handles form load event
        /// </summary>
        private void MainForm_Load(object sender, EventArgs e)
        {
            // Register PictureBox event handlers
            pictureBox.MouseDown += PictureBox_MouseDown;
            pictureBox.MouseMove += PictureBox_MouseMove;
            pictureBox.MouseUp += PictureBox_MouseUp;

            // Initialize drawing controls
            InitializeDrawingControls();
        }

        /// <summary>
        /// Initializes drawing controls with default values
        /// </summary>
        private void InitializeDrawingControls()
        {
            // Configure thickness control
            ThicknessNumericUpDown.Minimum = 1;
            ThicknessNumericUpDown.Maximum = 40;
            ThicknessNumericUpDown.Value = drawThickness;
            ThicknessNumericUpDown.ValueChanged += ThicknessNumericUpDown_ValueChanged;

            // Set initial color preview
            colorPreview.BackColor = drawColor;
        }
        #endregion

        #region Image Manipulation Methods
        /// <summary>
        /// Loads an image from file
        /// </summary>
        /// <param name="filePath">Path to the image file</param>
        private void OpenImage(string filePath)
        {
            currentImage = new Bitmap(filePath);
            DisplayImage(currentImage);
        }

        /// <summary>
        /// Saves the current image to file
        /// </summary>
        /// <param name="filePath">Path where the image should be saved</param>
        private void SaveImage(string filePath)
        {
            currentImage.Save(filePath, System.Drawing.Imaging.ImageFormat.Jpeg);
        }

        /// <summary>
        /// Displays an image in the picture box
        /// </summary>
        /// <param name="image">Image to display</param>
        private void DisplayImage(Bitmap image)
        {
            if (image != null)
            {
                pictureBox.Image = image;
                pictureBox.SizeMode = PictureBoxSizeMode.Zoom;
            }
        }

        /// <summary>
        /// Checks if the image is grayscale
        /// </summary>
        /// <param name="image">Image to check</param>
        /// <returns>True if the image is grayscale, false otherwise</returns>
        private bool IsGrayscale(Bitmap image)
        {
            for (int y = 0; y < image.Height; y++)
            {
                for (int x = 0; x < image.Width; x++)
                {
                    Color pixelColor = image.GetPixel(x, y);
                    if (pixelColor.R != pixelColor.G || pixelColor.G != pixelColor.B)
                    {
                        return false;
                    }
                }
            }
            return true;
        }

        /// <summary>
        /// Converts the current image to grayscale
        /// </summary>
        private void ConvertToGrayscale()
        {
            // Check if the image is already grayscale
            if (IsGrayscale(currentImage))
            {
                MessageBox.Show("The image is already grayscale.");
                return;
            }

            Grayscale grayscaleFilter = new Grayscale(0.2125, 0.7154, 0.0721);
            currentImage = grayscaleFilter.Apply(currentImage);
            DisplayImage(currentImage);
        }

        /// <summary>
        /// Applies edge detection to the current image
        /// </summary>
        private void ApplyEdgeDetection()
        {
            if (!IsGrayscale(currentImage))
            {
                ConvertToGrayscale();
            }
            SobelEdgeDetector edgeFilter = new SobelEdgeDetector();
            currentImage = edgeFilter.Apply(currentImage);
            DisplayImage(currentImage);
        }
        #endregion

        #region Drawing Methods
        /// <summary>
        /// Converts mouse coordinates to image coordinates considering zoom level
        /// </summary>
        /// <param name="mousePoint">Mouse coordinates</param>
        /// <returns>Corresponding image coordinates</returns>
        private Point ConvertToImageCoordinates(Point mousePoint)
        {
            if (currentImage == null || pictureBox.Image == null)
                return mousePoint;

            // Calculate zoom factor
            float zoomX = (float)pictureBox.Width / pictureBox.Image.Width;
            float zoomY = (float)pictureBox.Height / pictureBox.Image.Height;
            float zoom = Math.Min(zoomX, zoomY);

            // Calculate the top-left corner of the image within the PictureBox
            float imageX = (pictureBox.Width - (pictureBox.Image.Width * zoom)) / 2;
            float imageY = (pictureBox.Height - (pictureBox.Image.Height * zoom)) / 2;

            // Convert mouse coordinates to image coordinates
            int x = (int)((mousePoint.X - imageX) / zoom);
            int y = (int)((mousePoint.Y - imageY) / zoom);

            // Ensure coordinates are within image bounds
            x = Math.Max(0, Math.Min(currentImage.Width - 1, x));
            y = Math.Max(0, Math.Min(currentImage.Height - 1, y));

            return new Point(x, y);
        }

        /// <summary>
        /// Handles mouse down event on the picture box
        /// </summary>
        private void PictureBox_MouseDown(object sender, MouseEventArgs e)
        {
            if (isDrawingEnabled && e.Button == MouseButtons.Left)
            {
                isDrawing = true;
                lastPoint = ConvertToImageCoordinates(e.Location);
            }
        }

        /// <summary>
        /// Handles mouse move event on the picture box
        /// </summary>
        private void PictureBox_MouseMove(object sender, MouseEventArgs e)
        {
            if (isDrawingEnabled && isDrawing)
            {
                Point currentPoint = ConvertToImageCoordinates(e.Location);

                using (Graphics g = Graphics.FromImage(currentImage))
                {
                    using (Pen pen = new Pen(drawColor, drawThickness))
                    {
                        pen.StartCap = LineCap.Round;
                        pen.EndCap = LineCap.Round;
                        g.DrawLine(pen, lastPoint, currentPoint);
                    }
                }

                // Update the last point for the next segment
                lastPoint = currentPoint;

                // Update the display immediately
                pictureBox.Invalidate();
            }
        }

        /// <summary>
        /// Handles mouse up event on the picture box
        /// </summary>
        private void PictureBox_MouseUp(object sender, MouseEventArgs e)
        {
            if (isDrawingEnabled && isDrawing)
            {
                isDrawing = false;
            }
        }
        #endregion

        #region Event Handlers
        /// <summary>
        /// Handles draw button click
        /// </summary>
        private void DrawButton_Click(object sender, EventArgs e)
        {
            if (currentImage == null)
            {
                MessageBox.Show("Please open an image first.");
                return;
            }

            if (IsGrayscale(currentImage))
            {
                MessageBox.Show("Cannot draw on grayscale images.");
                return;
            }

            isDrawingEnabled = !isDrawingEnabled;

            DrawBox.Visible = isDrawingEnabled;
            pictureBox.Cursor = isDrawingEnabled ? Cursors.Cross : Cursors.Default;
        }

       

        /// <summary>
        /// Handles color picker button click
        /// </summary>
        private void PickColorButton_Click(object sender, EventArgs e)
        {
            using (ColorDialog colorDialog = new ColorDialog())
            {
                if (colorDialog.ShowDialog() == DialogResult.OK)
                {
                    drawColor = colorDialog.Color;
                    colorPreview.BackColor = drawColor;
                }
            }
        }

        /// <summary>
        /// Handles thickness control value change
        /// </summary>
        private void ThicknessNumericUpDown_ValueChanged(object sender, EventArgs e)
        {
            drawThickness = (int)ThicknessNumericUpDown.Value;
        }

        /// <summary>
        /// Handles open button click
        /// </summary>
        private void OpenButton_Click(object sender, EventArgs e)
        {
            using (OpenFileDialog openFileDialog = new OpenFileDialog())
            {
                openFileDialog.Filter = "JPEG Image|*.jpg";
                if (openFileDialog.ShowDialog() == DialogResult.OK)
                {
                    OpenImage(openFileDialog.FileName);
                }
            }
        }

        /// <summary>
        /// Handles save button click
        /// </summary>
        private void SaveButton_Click(object sender, EventArgs e)
        {
            using (SaveFileDialog saveFileDialog = new SaveFileDialog())
            {
                saveFileDialog.Filter = "JPEG Image|*.jpg";
                if (saveFileDialog.ShowDialog() == DialogResult.OK)
                {
                    SaveImage(saveFileDialog.FileName);
                }
            }
        }

        /// <summary>
        /// Handles grayscale button click
        /// </summary>
        private void GrayscaleButton_Click(object sender, EventArgs e)
        {
            if (currentImage != null)
            {
                if (isDrawingEnabled)
                {
                    MessageBox.Show("Cannot apply filter while drawing mode is active.");
                    return;
                }
                ConvertToGrayscale();
            }
            else
            {
                MessageBox.Show("Please open an image first.");
            }
        }

        /// <summary>
        /// Handles edge detection button click
        /// </summary>
        private void EdgeDetectButton_Click(object sender, EventArgs e)
        {
            if (currentImage != null)
            {
                if (isDrawingEnabled)
                {
                    MessageBox.Show("Cannot apply filter while drawing mode is active.");
                    return;
                }
                ApplyEdgeDetection();
            }
            else
            {
                MessageBox.Show("Please open an image first.");
            }
        }
        #endregion
    }
}