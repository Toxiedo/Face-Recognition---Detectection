using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;

namespace NN_Phase2.Classes
{
    public struct my_color
    {
        public int Red;
        public int Green;
        public int Blue;
    }

    class imageoperation
    {
        public static double[] getimage(Bitmap bitm)
        {
            //inputimage.Image = original_bm;
            my_color[,] image_buffer_;
            Bitmap original_bm;
            Bitmap myimage;
            //Resize bilinear;
            my_color[,] Buffer2D;
            int hei;
            int wie;
            double[] featers;
            original_bm = bitm;
            hei = original_bm.Height;
            wie = original_bm.Width;
            Buffer2D = new my_color[hei, wie];

            for (int i = 0; i < hei; i++)
            {
                for (int j = 0; j < wie; j++)
                {
                    Color clr = new Color();
                    clr = original_bm.GetPixel(j, i);
                    int o = clr.R;
                    int p = clr.G;
                    int q = clr.B;
                    Buffer2D[i, j] = new my_color();
                    Buffer2D[i, j].Red = o;
                    Buffer2D[i, j].Green = p;
                    Buffer2D[i, j].Blue = q;
                }
            }

            for (int i = 0; i < hei; i++)
            {
                for (int j = 0; j < wie; j++)
                {

                    Color clr;
                    double value = (Buffer2D[i, j].Red + Buffer2D[i, j].Green + Buffer2D[i, j].Blue) / 3;
                    Buffer2D[i, j].Red = (int)value;
                    Buffer2D[i, j].Green = (int)value;
                    Buffer2D[i, j].Blue = (int)value;

                    clr = Color.FromArgb((int)value, (int)value, (int)value);
                    original_bm.SetPixel(j, i, clr);
                }
            }
            image_buffer_ = new my_color[30, 30];
            for (int i = 0; i < 30; i++)
            {
                for (int j = 0; j < 30; j++)
                {
                    image_buffer_[i, j].Red = Buffer2D[i, j].Red;
                    image_buffer_[i, j].Green = Buffer2D[i, j].Green;
                    image_buffer_[i, j].Blue = Buffer2D[i, j].Blue;
                }
            }
            Bitmap b1 = new Bitmap(1, 900);
            int count = 0;
            featers = new double[900];
            for (int i = 0; i < image_buffer_.GetLength(1); i++)
            {
                for (int j = 0; j < image_buffer_.GetLength(0); j++)
                {
                    Color clr;
                    clr = Color.FromArgb(image_buffer_[i, j].Red, image_buffer_[i, j].Green, image_buffer_[i, j].Blue);
                    b1.SetPixel(0, count, clr);
                    featers[count] = image_buffer_[i, j].Red;
                    count++;
                }
            }

            return featers;
        }


    }
}
