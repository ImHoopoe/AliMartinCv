using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Drawing;
using System.Drawing.Imaging;

namespace AliMartinCv.Core.Convertors
{
    public class ImageConvertor
    {

        public static void ResizeAndSaveImage(string sourceImagePath, string destinationFolderPath, int width, int height)
        {
            // Load the original image
            using (var image = new Bitmap(sourceImagePath))
            {
                // Create a new bitmap with the desired dimensions
                using (var newImage = new Bitmap(width, height))
                {
                    // Create a graphics object from the new image
                    using (var graphics = Graphics.FromImage(newImage))
                    {
                        // Draw the original image onto the new image with the new dimensions
                        graphics.DrawImage(image, 0, 0, width, height);
                    }

                    //// Ensure the destination folder exists
                    //Directory.CreateDirectory(destinationFolderPath);

                    //// Construct the destination file path
                    
                    string destinationFilePath = Path.Combine(destinationFolderPath);

                    // Save the resized image to the destination folder
                    newImage.Save(destinationFilePath, ImageFormat.Jpeg);
                }
            }
        }
    }




}

