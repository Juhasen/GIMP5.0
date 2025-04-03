using AForge.Imaging;
using AForge.Imaging.Filters;
using System;
using System.Drawing;
using System.IO;
using System.Windows.Forms;

namespace GIMP5._0
{
    public partial class MainForm : Form
    {
        private Bitmap currentImage;

        public MainForm()
        {
            InitializeComponent();
        }


        // Wczytanie pliku JPG
        private void OpenImage(string filePath)
        {
            currentImage = new Bitmap(filePath);
            DisplayImage(currentImage);
        }

        // Wy�wietlanie obrazu w PictureBox
        private void DisplayImage(Bitmap image)
        {
            pictureBox.Image = image;
            pictureBox.SizeMode = PictureBoxSizeMode.Zoom;
        }

        // Zapisanie pliku JPG
        private void SaveImage(string filePath)
        {
            currentImage.Save(filePath, System.Drawing.Imaging.ImageFormat.Jpeg);
        }

        // Konwersja do poziom�w szaro�ci
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

        // Konwersja do poziom�w szaro�ci
        private void ConvertToGrayscale()
        {
            // Sprawdzenie, czy obraz jest ju� w skali szaro�ci
            if (IsGrayscale(currentImage))
            {
                MessageBox.Show("Obraz jest ju� w skali szaro�ci.");
                return;
            }

            Grayscale grayscaleFilter = new Grayscale(0.2125, 0.7154, 0.0721);
            currentImage = grayscaleFilter.Apply(currentImage);
            DisplayImage(currentImage);
        }

        // Wykrywanie kraw�dzi
        private void ApplyEdgeDetection()
        {
            SobelEdgeDetector edgeFilter = new SobelEdgeDetector();
            currentImage = edgeFilter.Apply(currentImage);
            DisplayImage(currentImage);
        }

        // Rysowanie linii
        private void DrawLine(Point start, Point end, Color color, int thickness)
        {
            using (Graphics g = Graphics.FromImage(currentImage))
            {
                using (Pen pen = new Pen(color, thickness))
                {
                    g.DrawLine(pen, start, end);
                }
            }
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

        // Przycisk do konwersji na szaro��
        private void GrayscaleButton_Click(object sender, EventArgs e)
        {
            if (currentImage != null)
            {
                ConvertToGrayscale();
            }
            else
            {
                MessageBox.Show("Prosz� najpierw otworzy� obraz.");
            }
        }

        // Przycisk do wykrywania kraw�dzi
        private void EdgeDetectButton_Click(object sender, EventArgs e)
        {
            if (currentImage != null)
            {
                ApplyEdgeDetection();
            }
            else
            {
                MessageBox.Show("Prosz� najpierw otworzy� obraz.");
            }
        }

        // Przycisk do rysowania linii
        private void DrawLineButton_Click(object sender, EventArgs e)
        {
            if (currentImage != null)
            {
                // Przyk�ad rysowania linii
                Point start = new Point(50, 50);
                Point end = new Point(200, 200);
                Color color = Color.Red;
                int thickness = 3;
                DrawLine(start, end, color, thickness);
            }
            else
            {
                MessageBox.Show("Prosz� najpierw otworzy� obraz.");
            }
        }

    
    }
}
