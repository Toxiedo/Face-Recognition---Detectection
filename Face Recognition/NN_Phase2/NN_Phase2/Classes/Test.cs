using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace NN_Phase2.Classes
{
    class Test
    {
        private double[] weight;
        private double eta;
        private List<neoron> neo;
        private double[] featers;
        private int num;
        private int index;

        public int Index
        {
            get { return index; }
            set { index = value; }
        }

        public Test(List<neoron> ne, double[] feater, double et, double[] weigh , int num_class)
        {
            weight = weigh;
            eta = et;
            featers = feater;
            neo = ne;
            num = num_class;
            play();
        }

        private void play()
        {
            double[] values = new double[num];
            double fai;
            for (int x = 0; x < neo.Count; x++)
            {
                double result = 0;
                for (int y = 0; y < neo[x].Centroid.Length; y++)
                {
                    result += (Math.Pow((featers[y] - neo[x].Centroid[y]), 2));
                }
                result = -1 * result;
                fai = (result) / (2 * Math.Pow(neo[x].Variance, 2));
                neo[x].R = fai;
            }
            int count = 0;
            for (int z = 0; z < num; z++)
            {
                //outputs[z].Value = 0;
                for (int a = 0; a < neo.Count; a++)
                {
                    values[z] += weight[count] * neo[a].R;
                    count++;
                }
            }
            
            double max = 0;
            for (int i = 0; i < values.Length; i++)
            {
                if (max < values[i])
                {
                    max = values[i];
                    Index = i;
                }
            }

        }

    }
}
