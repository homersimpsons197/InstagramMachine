using System;
using System.Collections.Generic;
using System.Drawing;
using System.Drawing.Drawing2D;
using System.Drawing.Imaging;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace InstagramMachine
{
    internal class ImgResizer
    {

        UserControl2 uc2;
       
        public void ImageResize(String path)
        {
            String[] ext = { ".jpg", ".jpeg", ".png" };
            String[] imgArray = Directory.GetFiles(path, "*.*")
                .Where(f => ext.Contains(System.IO.Path.GetExtension(f).ToLower())).ToArray();
            int nb = 0;

            for (int i = 0; i < imgArray.Length; i++)
            {
                Image imgPhoto = Image.FromFile(String.Format(@"{0}", imgArray[i]));
                Bitmap image = ResizeImage(imgPhoto, 512, 512);
                Directory.CreateDirectory(path + "\\resizedImg");
                image.Save(String.Format(@"{0}" + "\\resizedImg\\" + nb + ".jpeg", path));
                image.Dispose();
                imgPhoto.Dispose();
                File.Delete(imgArray[i]);
                nb++;
            }
            ResizedImg(path);
        }

        public void ResizedImg(String path)
        {
            String[] resizedArray = Directory.GetFiles(String.Format("{0}\\resizedImg", path));            

            File.WriteAllLines(String.Format(@"{0}\resizedImg\imgPath.txt", path), resizedArray);
        }

        public static Bitmap ResizeImage(Image image, int width, int height)
        {
            var destRect = new Rectangle(0, 0, width, height);
            var destImage = new Bitmap(width, height);

            destImage.SetResolution(image.HorizontalResolution, image.VerticalResolution);

            using (var graphics = Graphics.FromImage(destImage))
            {
                graphics.CompositingMode = CompositingMode.SourceCopy;
                graphics.CompositingQuality = CompositingQuality.HighQuality;
                graphics.InterpolationMode = InterpolationMode.HighQualityBicubic;
                graphics.SmoothingMode = SmoothingMode.HighQuality;
                graphics.PixelOffsetMode = PixelOffsetMode.HighQuality;

                using (var wrapMode = new ImageAttributes())
                {
                    wrapMode.SetWrapMode(WrapMode.TileFlipXY);
                    graphics.DrawImage(image, destRect, 0, 0, image.Width, image.Height, GraphicsUnit.Pixel, wrapMode);
                }
            }
            return destImage;
        }
    }
}
