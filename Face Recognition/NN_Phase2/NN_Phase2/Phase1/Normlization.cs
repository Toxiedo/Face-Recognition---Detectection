using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace NN_Phase2.Phase1
{
    class Normlization
    {
        #region variables
        double[] data;
        double[] result;

        public double[] Result
        {
            get { return result; }
            set { result = value; }
        }
        #endregion

        public Normlization(double[] arr)
        {
            this.data = arr;
            norm(arr);
        }


        private void norm(double[] arr)
        {
            double mean, max;
            mean = get_mean(arr);
            max = get_max(arr);
            Result = new double[arr.Length];
            for (int i = 0; i < arr.Length; i++)
            {
                Result[i] = (arr[i] - mean) / max;
            }
        }

        private double get_mean(double[] arr)
        {
            double mean, count = 0;
            for (int i = 0; i < arr.Length; i++)
            {
                count += arr[i];
            }
            mean = count / arr.Length;
            return mean;
        }

        private double get_max(double[] arr)
        {
            double max = 0;
            for (int i = 0; i < arr.Length; i++)
            {
                max = Math.Max(max, arr[i]);
            }
            return max;
        }
    }
}
