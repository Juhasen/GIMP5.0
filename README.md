# Image Processing Application - GIMP5.0

## Description
This application is designed for reading, displaying, filtering, and basic editing of image files. It features a scalable GUI, including a resizable and maximizable window.

## Features
- **GUI Application**: A user-friendly graphical interface with menu and toolbar.
- **Image Loading & Saving**: Supports reading and saving images in JPG format.
- **Image Display**: Loads and displays an image in the main application window while maintaining the original aspect ratio.
- **Filtering Options**: Provides various image processing filters such as:
  - Grayscale conversion
  - Thresholding
  - Edge detection
  - Other filters using AForge.NET
- **Basic Image Editing**: Allows users to draw lines on the image with customizable color and thickness.
- **Preservation of Edits**: Ensures that the applied filters and drawn lines are saved when exporting the image.

## Technologies Used
- **C#** for application development
- **Windows Forms** for GUI design
- **AForge.NET** for image processing and filtering

## Installation
1. Clone this repository:
   ```sh
   git clone https://github.com/Juhasen/GIMP5.0.git
   ```
2. Open the project in Visual Studio.
3. Build and run the application.

## Usage
1. Open an image file (JPG format) using the menu or toolbar.
2. Apply filters or edit the image using the available tools.
3. Save the processed image while retaining all modifications.

## Author
Krystian Juszczyk

