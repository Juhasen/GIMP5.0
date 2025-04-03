using AForge.Imaging;
using AForge.Imaging.Filters;
using System;
using System.Drawing;
using System.IO;
using System.Windows.Forms;
using System.Drawing.Drawing2D;

namespace GIMP5._0
{
    public partial class MainForm : Form
    {
        private Bitmap currentImage;
        private Color drawColor = Color.Red;
        private int drawThickness = 3;
        private bool isDrawingEnabled = false;
        private bool isDrawing = false;
        private Point lastPoint;

        // Constructor
        public MainForm()
        {
            InitializeComponent();

            // Wire up events manually
            this.Load += MainForm_Load;
        }

        // Make sure the ThicknessNumericUpDown event is properly wired
        private void InitializeDrawingControls()
        {
            // This method should be called from your constructor or Form_Load
            ThicknessNumericUpDown.Minimum = 1;
            ThicknessNumericUpDown.Maximum = 20;
            ThicknessNumericUpDown.Value = drawThickness;
            ThicknessNumericUpDown.ValueChanged += ThicknessNumericUpDown_ValueChanged;

            // Make sure color preview is set
            colorPreview.BackColor = drawColor;
        }

        // Add this to your MainForm_Load method
        private void MainForm_Load(object sender, EventArgs e)
        {
            // Add event handlers for the PictureBox
            pictureBox.MouseDown += PictureBox_MouseDown;
            pictureBox.MouseMove += PictureBox_MouseMove;
            pictureBox.MouseUp += PictureBox_MouseUp;

            // Initialize drawing controls
            InitializeDrawingControls();
        }

        // Convert mouse coordinates to image coordinates when zoomed
        private Point ConvertToImageCoordinates(Point mousePoint)
        {
            if (currentImage == null || pictureBox.Image == null)
                return mousePoint;

            // Get the dimensions
            float zoomX = (float)pictureBox.Width / pictureBox.Image.Width;
            float zoomY = (float)pictureBox.Height / pictureBox.Image.Height;
            float zoom = Math.Min(zoomX, zoomY);

            // Calculate the top-left corner of the image within the PictureBox
            float imageX = (pictureBox.Width - (pictureBox.Image.Width * zoom)) / 2;
            float imageY = (pictureBox.Height - (pictureBox.Image.Height * zoom)) / 2;

            // Convert mouse coordinates to image coordinates
            int x = (int)((mousePoint.X - imageX) / zoom);
            int y = (int)((mousePoint.Y - imageY) / zoom);

            // Make sure we're within the bounds of the image
            x = Math.Max(0, Math.Min(currentImage.Width - 1, x));
            y = Math.Max(0, Math.Min(currentImage.Height - 1, y));

            return new Point(x, y);
        }

        // Draw button click handler
        private void DrawButton_Click(object sender, EventArgs e)
        {
            if (currentImage == null)
            {
                MessageBox.Show("Please open an image first.");
                return;
            }

            // Toggle drawing mode
            isDrawingEnabled = !isDrawingEnabled;

            // Update UI
            DrawBox.Visible = isDrawingEnabled;
            pictureBox.Cursor = isDrawingEnabled ? Cursors.Cross : Cursors.Default;

            // For debugging
            MessageBox.Show("Drawing mode " + (isDrawingEnabled ? "enabled" : "disabled"));
        }

        // Modified mouse handlers to use the coordinate conversion
        private void PictureBox_MouseDown(object sender, MouseEventArgs e)
        {
            if (isDrawingEnabled && e.Button == MouseButtons.Left)
            {
                isDrawing = true;
                lastPoint = ConvertToImageCoordinates(e.Location);
                Console.WriteLine($"Mouse down at converted point: {lastPoint}");
            }
        }

        private void PictureBox_MouseMove(object sender, MouseEventArgs e)
        {
            if (isDrawingEnabled && isDrawing)
            {
                Point currentPoint = ConvertToImageCoordinates(e.Location);

                using (Graphics g = Graphics.FromImage(currentImage))
                {
                    using (Pen pen = new Pen(drawColor, drawThickness))
                    {
                        pen.StartCap = System.Drawing.Drawing2D.LineCap.Round;
                        pen.EndCap = System.Drawing.Drawing2D.LineCap.Round;
                        g.DrawLine(pen, lastPoint, currentPoint);
                    }
                }

                // Update the last point for the next segment
                lastPoint = currentPoint;

                // Update the display - this will show changes immediately
                pictureBox.Invalidate();

                Console.WriteLine($"Drawing line to converted point: {currentPoint} with thickness: {drawThickness}");
            }
        }

        private void PictureBox_MouseUp(object sender, MouseEventArgs e)
        {
            if (isDrawingEnabled && isDrawing)
            {
                isDrawing = false;

                // For debugging
                Console.WriteLine("Mouse up - drawing complete");
            }
        }

        // Display image helper
        private void DisplayImage(Bitmap image)
        {
            if (image != null)
            {
                pictureBox.Image = image;
                pictureBox.SizeMode = PictureBoxSizeMode.Zoom;
            }
        }

        // Color picker button
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

        // Thickness change handler
        private void ThicknessNumericUpDown_ValueChanged(object sender, EventArgs e)
        {
            drawThickness = (int)ThicknessNumericUpDown.Value;
        }

        // Wczytanie pliku JPG
        private void OpenImage(string filePath)
        {
            currentImage = new Bitmap(filePath);
            DisplayImage(currentImage);
        }



        // Zapisanie pliku JPG
        private void SaveImage(string filePath)
        {
            currentImage.Save(filePath, System.Drawing.Imaging.ImageFormat.Jpeg);
        }

        // Konwersja do poziomów szarości
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

        // Konwersja do poziomów szarości
        private void ConvertToGrayscale()
        {
            // Sprawdzenie, czy obraz jest już w skali szarości
            if (IsGrayscale(currentImage))
            {
                MessageBox.Show("Obraz jest już w skali szarości.");
                return;
            }

            Grayscale grayscaleFilter = new Grayscale(0.2125, 0.7154, 0.0721);
            currentImage = grayscaleFilter.Apply(currentImage);
            DisplayImage(currentImage);
        }

        // Wykrywanie krawędzi
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


        // Przycisk do wczytania obrazu
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

        // Przycisk do zapisania obrazu
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

        // Przycisk do konwersji na szarość
        private void GrayscaleButton_Click(object sender, EventArgs e)
        {
            if (currentImage != null)
            {
                ConvertToGrayscale();
            }
            else
            {
                MessageBox.Show("Proszę najpierw otworzyć obraz.");
            }
        }

        // Przycisk do wykrywania krawędzi
        private void EdgeDetectButton_Click(object sender, EventArgs e)
        {
            if (currentImage != null)
            {
                ApplyEdgeDetection();
            }
            else
            {
                MessageBox.Show("Proszę najpierw otworzyć obraz.");
            }
        }



       
    }
}
