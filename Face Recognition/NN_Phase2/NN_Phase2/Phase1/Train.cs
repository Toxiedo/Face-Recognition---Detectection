using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace NN_Phase2.Phase1
{
    class Train
    {
        #region variables
        public List<Hidden_Layer> H_Ls = new List<Hidden_Layer>();
        double num_classes, num_hiddens;
        private double temp;
        public List<Output> outputs = new List<Output>();
        private double eboch;
        private List<double[]> images;
        private double eta_now;
        #endregion

        public Train(List<double[]> samples, double eta, double n_hiddens, int ebochs , double st_neo)
        {
            num_classes = samples.Count / 3;
            num_hiddens = n_hiddens;
            temp = st_neo;
            eboch = ebochs;
            images = samples;
            eta_now = eta;
            calc_hiddens_random();
            calc_outputs();
            play();
        }

        public void calc_hiddens_random()
        {
            Random rand = new Random();
            double sec = rand.Next(1,10);
            for (int i = 0; i < num_hiddens; i++)
            {
                double first = rand.Next(1,10);
                Hidden_Layer hd;
                if (i == 49)
                {

                    hd = new Hidden_Layer(i, (int)5, temp, (int)num_hiddens, (int)num_classes);
                }
                else
                {

                    hd = new Hidden_Layer(i, (int)first, temp, (int)num_hiddens, (int)num_classes);
                }
                temp = first;
                H_Ls.Add(hd);
            }
        }

        public void calc_outputs()
        {
            for (int i = 0; i < num_classes; i++)
            {
                Output ou = new Output();
                outputs.Add(ou);
            }
        }

        public void play()
        {

            for (int i = 0; i <eboch ; i++)
            {
                for (int j = 0; j < images.Count; j++)
                {
                    Forwardway.forwrad(ref H_Ls, images[j], ref outputs);
                    Backword.Calculate_Sigma(j, ref outputs);
                    Backword.Calculate_sigma_hiddens(ref H_Ls, images[j], ref outputs);
                    Forwardway.update_weights(ref H_Ls, images[j], ref outputs , eta_now);
                }
            }

        }
    }
}
