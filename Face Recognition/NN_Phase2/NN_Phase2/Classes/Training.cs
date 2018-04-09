using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace NN_Phase2.Classes
{
    class Training
    {
        #region variables
        private List<double[]> featers;
        private int num;
        private double _eta;
        List<neoron> neo;

        internal List<neoron> Neo
        {
            get { return neo; }
            set { neo = value; }
        }
        private int _ebock;
        private int num_classes;

        public int Num_classes
        {
            get { return num_classes; }
            set { num_classes = value; }
        }
        private List<Output> outputs;

        /// <summary>
        /// LMS Components
        /// </summary>
        /// <param name="images"></param>
        /// <param name="n"></param>
        /// <param name="eta"></param>
        /// <param name="eboch"></param>
        /// 

        private double w_thresh;
        private double mse_thresh;
        private double[] weight;

        public double[] Weight
        {
            get { return weight; }
            set { weight = value; }
        }
        private int[] desierd;
        #endregion

        public Training(List<double[]> images , int n , double eta ,int eboch , double w_th , double mse)
        {
            featers = images;
            num_classes = featers.Count / 3;
            num = n;
            neo = new List<neoron>(num);
            outputs = new List<Output>();
            _eta = eta;
            _ebock = eboch;
            w_thresh = w_th;
            mse_thresh = mse;
            int b = num *(int) num_classes;
            weight = new double[b];
            desierd = new int[num_classes];
            init_NN_Centroids();
            calc_k_means();
            update_centroid();
            calc_variance();
            play();
        }

        private void init_NN_Centroids()
        {
            int count = 0;
            for (int i = 0; i < num; i++)
            {
                if (count == 14)
                {
                    count = 0;
                }
                neoron n = new neoron();
                n.Centroid = featers[count];
                count++;
                Neo.Add(n); 
            }

            for (int j = 0; j < Num_classes; j++)
            {
                Output op = new Output();
                outputs.Add(op);
            }

            for (int x = 0; x < Weight.Length; x++)
            {
                Random rand = new Random();
                Weight[x] = rand.Next(1,100);
            }

        }

        private void update_centroid()
        {
            int count =0;
            double[] result = new double[900];
            bool ok = false;
            while (count < 100)
            {
                for (int i = 0; i < Neo.Count; i++)
                {
                    for (int j = 0; j < Neo[i].Mylist.Count; j++)
                    {
                        result = calc_sum((featers[Neo[i].Mylist[j]]) , result);
                    }
                    for (int S = 0; S < result.Length; S++)
                    {
                        result[S] = result[S] / Neo[i].Mylist.Count;
                    }
                    if (result == Neo[i].Centroid)
                    {
                        ok = true;
                        break;
                    }
                    Neo[i].Centroid = result;
                }
                if (ok)
                {
                    break;
                }
                count++;
                calc_k_means();
            }
        }

        private double []calc_sum(double[] sam , double[]res)
        {
            double []result = new double[900];
            for (int i = 0; i < sam.Length; i++)
            {
                result[i] = sam[i]+res[i];
            }
            return result;
        }

        private void calc_k_means()
        {
            double[] arr = new double[Neo.Count];
            for (int i = 0; i < featers.Count; i++)
            {
                for (int j = 0; j < Neo.Count; j++)
                {
                    arr[j] = calc_sumition(Neo[j].Centroid, featers[i]);
                }
                Neo[getmin(arr)].Mylist.Add(i);
            }
            double d;
        }

        private double calc_sumition(double[] arr1, double[] arr2)
        {
            double result = 0;
            for (int i = 0; i < arr1.Length; i++)
            {
                result += (Math.Abs(arr1[i] - arr2[i]));
            }
            return result;
        }

        private int getmin(double[] arr1)
        {
            double min = 100000;
            int index = 0;
            for (int i = 0; i < arr1.Length; i++)
            {
                if (arr1[i] < min)
                {
                    min = arr1[i];
                    index = i;
                }
            }
            return index;
        }

        private void calc_variance()
        {
            double result = 0;
            for (int i = 0; i < Neo.Count; i++)
            {
                for (int j = 0; j < Neo[i].Mylist.Count; j++)
                {
                    result += calc_sumition(Neo[i].Centroid, featers[Neo[i].Mylist[j]]);
                }
                Neo[i].Variance = (result / Neo[i].Mylist.Count);
            }
            double g;
        }

        private void make_desired(int k)
        {
            int num_index = k / 3;
            for (int i = 0; i < desierd.Length; i++)
            {
                if (i == num_index)
                {
                    desierd[i] = 1;

                }
                else
                {
                    desierd[i] = 0;
                }
            }
        }

        private void play()
        {
            double fai = 0;
            double[] one_feater;
            double[] eroooor_for_mean = new double[outputs.Count]; ;
            double[] msii = new double[_ebock]; ;
            for (int i = 0; i < _ebock; i++)
            {
                for (int j = 0; j < featers.Count; j++)
                {
                    one_feater = featers[j];
                    for (int x = 0; x < Neo.Count; x++)
                    {
                        double result = 0;
                        for (int y = 0; y < Neo[x].Centroid.Length; y++)
                        {
                            result += (Math.Abs((one_feater[y] - Neo[x].Centroid[y])));
                        }
                        result = -1 *Math.Pow(result,2);
                        fai =Math.Exp( (result) / (2 * Math.Pow(Neo[x].Variance, 2)) );
                        Neo[x].Center = fai;
                    }

                    int count =0;

                    for (int z = 0; z < Num_classes; z++)
                    {
                        outputs[z].Value = 0;
                        for (int a = 0; a < Neo.Count; a++)
                        {
                            outputs[z].Value += Weight[count] * Neo[a].Center;
                            count++;
                        }
                    }
                    make_desired(j);
                    for (int s = 0; s < outputs.Count; s++)
                    {
                        outputs[s].Error = desierd[s] - outputs[s].Value;
                        eroooor_for_mean[s] = outputs[s].Error;
                    }

                    count = 0;
                    double w_norm = 0;
                    for (int z = 0; z < Num_classes; z++)
                    {
                        for (int a = 0; a < Neo.Count; a++)
                        {
                            w_norm += outputs[z].Error * _eta * Neo[a].Center;
                            Weight[count] = Weight[count] + outputs[z].Error*_eta*Neo[a].Center;
                            count++;
                        }
                    }

                    if (w_norm > w_thresh && j > 10)
                        break;
                }
                msii[i] = mean(eroooor_for_mean);
                if (msii[i] < mse_thresh)
                    break;
            }



        }

        public double mean(double[] datanew)
        {
            //double sum = 0;

            double squ = 0;


            for (int i = 0; i < datanew.Length; i++)
            {
                squ += Math.Pow(datanew[i], 2);
                //nateg[i] -= arr[i];


            }

            return (double)squ / datanew.Length;

        }

    }
}
