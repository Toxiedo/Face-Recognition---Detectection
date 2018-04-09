using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace NN_Phase2.Phase1
{
    class Hidden_Layer
    {
        #region variables
        private double[] sigma;

        public double[] Sigma
        {
            get { return sigma; }
            set { sigma = value; }
        }
        private double[] q_v;
        private double[] Y_h;

        public double[] Y_h1
        {
            get { return Y_h; }
            set { Y_h = value; }
        }
        public double[] Q_v
        {
            get { return q_v; }
            set { q_v = value; }
        }
        private double num_neorons;
        private double[] y;

        public double[] Y
        {
            get { return y; }
            set { y = value; }
        }
        private double[] value_neorons;

        public double[] Value_neorons
        {
            get { return value_neorons; }
            set { value_neorons = value; }
        }
        private double[] weights;

        public double[] Weights
        {
            get { return weights; }
            set { weights = value; }
        }

        private double [] wei;

        public double[] Wei
        {
            get { return wei; }
            set { wei = value; }
        }
        
        #endregion

        public Hidden_Layer(int num_hid_delwa2ty , int num_neo_ellyba3doh  , double num , int kol_hid_neorons , int num_class)
        {
            num_neorons = num;
            Random rand = new Random();
            value_neorons = new double[(int)num_neorons];
            if (num_hid_delwa2ty == 0)
            {
                wei = new double[(int)num_neorons * 900];
                
                for (int i = 0; i < wei.Length; i++)
                {
                    wei[i] = rand.Next(1, 100);
                }
                weights = new double[(int)num_neorons * num_neo_ellyba3doh];
                for (int i = 0; i < weights.Length; i++)
                {
                    weights[i] = rand.Next(1, 100);
                }
            }

            else if (num_hid_delwa2ty == kol_hid_neorons-1)
            {
                weights = new double[num_class * (int)num_neo_ellyba3doh];
                for (int i = 0; i < weights.Length; i++)
                {
                    weights[i] = rand.Next(1, 100);
                }
            }

            else
            {
                weights = new double[(int)num_neorons * num_neo_ellyba3doh];
                for (int i = 0; i < weights.Length; i++)
                {
                    weights[i] = rand.Next(1, 100);
                }
            }
        }

        public void calc_neorons_value(double [] weights_now , double []values )
        {
            int count = 0;
            for (int i = 0; i < this.value_neorons.Length; i++)
            {
                for (int j = 0; j < values.Length; j++)
                {
                    value_neorons[i] = weights_now[count] * values[j];
                    count++;
                }
            }
        }

        public void Caculate_Sigma(int num_hidden)
        {

        }


    }
}
