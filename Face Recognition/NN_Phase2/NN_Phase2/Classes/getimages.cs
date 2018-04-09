using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.IO;
using System.Drawing;

namespace NN_Phase2.Classes
{
    class getimages
    {

        public static List<Bitmap> generateimage(string path)
        {
            DirectoryInfo di = new DirectoryInfo(path);
            FileInfo[] files = di.GetFiles();
            List<Bitmap> images = new List<Bitmap>();
            for (int i = 0; i < files.Length; i++)
            {
                Bitmap image = new Bitmap(files[i].FullName);
                images.Add(image);
            }
            return images;
        }

    }
}
