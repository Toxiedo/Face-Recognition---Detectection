using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;

namespace NN_Phase2
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }
        List<Bitmap> images;
        double eta;
        int num;
        int eboch;
        double w, ms;
        Classes.Training tr;
        private void button1_Click(object sender, EventArgs e)
        {
            FolderBrowserDialog fd = new FolderBrowserDialog();
            
            List<double[]> samples = new List<double[]>();
            if (fd.ShowDialog() == System.Windows.Forms.DialogResult.OK)
            {
                images = Classes.getimages.generateimage(fd.SelectedPath);                 
            }

            for (int i = 0; i < images.Count(); i++)
            {
                samples.Add(Classes.imageoperation.getimage(images[i]));
            }
            eta = double.Parse(textBox2.Text);
            num = int.Parse(textBox1.Text);
            eboch = int.Parse(textBox3.Text);
            w = double.Parse(textBox4.Text);
            ms = double.Parse(textBox5.Text);
            tr = new Classes.Training(samples, num, eta,eboch,w,ms);

        }

        private void button2_Click(object sender, EventArgs e)
        {
            
            OpenFileDialog openFileDialog1 = new OpenFileDialog();
            if (openFileDialog1.ShowDialog() == DialogResult.OK)
            {
                string OpenedFilePath = openFileDialog1.FileName;
                Bitmap im = new Bitmap(OpenedFilePath);
                Classes.Test te = new Classes.Test(tr.Neo, Classes.imageoperation.getimage(im), eta, tr.Weight, tr.Num_classes);
                label6.Text = te.Index.ToString();
            }
        }

        private void textBox1_TextChanged(object sender, EventArgs e)
        {

        }

        private void label1_Click(object sender, EventArgs e)
        {

        }

        private void label2_Click(object sender, EventArgs e)
        {

        }

        private void textBox2_TextChanged(object sender, EventArgs e)
        {

        }

        private void textBox3_TextChanged(object sender, EventArgs e)
        {

        }

        private void label3_Click(object sender, EventArgs e)
        {

        }
    }
}
