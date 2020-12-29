using System;
using System.Collections.Generic;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GlobussoftTechnologies.ChatlistUIModule.Utilities
{
    public static class Utilities
    {
        public static byte[] ImageToByte(string path)
        {
            Image image = Image.FromFile(path, true);
            using (MemoryStream ms = new MemoryStream())
            {
                // Convert Image to byte[]
                image.Save(ms, System.Drawing.Imaging.ImageFormat.Jpeg);
                byte[] imageBytes = ms.ToArray();
                return imageBytes;
            }
        }

        //public Image Base64ToImage(string base64String)
        public static Image ByteToImage(byte[] imageBytes)
        {
            // Convert byte[] to Image
            MemoryStream ms = new MemoryStream(imageBytes, 0, imageBytes.Length);
            ms.Write(imageBytes, 0, imageBytes.Length);
            Image image = new System.Drawing.Bitmap(ms);
            return image;
        }
    }
}
