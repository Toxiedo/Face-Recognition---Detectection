using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using NN_Phase2.Phase1;

namespace NN_Phase2.Phase1
{
    public partial class Phase1_FM : Form
    {
        public Phase1_FM()
        {
            InitializeComponent();
        }

        List<Bitmap> images;
        List<double[]> normalized_samples;
        double eta, n_hiddens, ebochs,st_neoron;
        Train tr;

        private void button1_Click(object sender, EventArgs e)
        {
            FolderBrowserDialog fd = new FolderBrowserDialog();

            List<double[]> samples = new List<double[]>();
            normalized_samples = new List<double[]>();
            if (fd.ShowDialog() == System.Windows.Forms.DialogResult.OK)
            {
                images = Classes.getimages.generateimage(fd.SelectedPath);
            }

            for (int i = 0; i < images.Count(); i++)
            {
                samples.Add(Classes.imageoperation.getimage(images[i]));
            }

            for (int j = 0; j < samples.Count; j++)
            {
                double[] result;
                Normlization nor = new Normlization(samples[j]);
                result = nor.Result;
                normalized_samples.Add(result);
            }
            double w;

        }

        private void button2_Click(object sender, EventArgs e)
        {
            eta = double.Parse(textBox2.Text);
            n_hiddens = double.Parse(textBox1.Text);
            ebochs = double.Parse(textBox3.Text);
            st_neoron = double.Parse(textBox4.Text);
            tr = new Train(normalized_samples, eta, n_hiddens, (int)ebochs , st_neoron);
            
        }

        private void button3_Click(object sender, EventArgs e)
        {
            OpenFileDialog openFileDialog1 = new OpenFileDialog();
            if (openFileDialog1.ShowDialog() == DialogResult.OK)
            {
                string OpenedFilePath = openFileDialog1.FileName;
                Bitmap im = new Bitmap(OpenedFilePath);
                Normlization nor = new Normlization(Classes.imageoperation.getimage(im));
                //Classes.Test te = new Classes.Test(tr.Neo, Classes.imageoperation.getimage(im), eta, tr.Weight, tr.Num_classes);
                Test ts = new Test(tr.H_Ls, tr.outputs,nor.Result);
                double max = double.MinValue;
                int indexer=0;
                for (int i = 0; i < ts.Result.Length; i++)
                {
                    if (max > ts.Result[i])
                    {
                        indexer = i;
                    }
                }
                label5.Text = indexer.ToString();
            }
        }

    }
}
