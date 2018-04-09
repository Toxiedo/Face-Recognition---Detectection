using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace NN_Phase2.Phase1
{
    class Output
    {
        #region variables
        double value;

        public double Value
        {
            get { return this.value; }
            set { this.value = value; }
        }
        double sigma;

        public double Sigma
        {
            get { return sigma; }
            set { sigma = value; }
        }
        double error;

        public double Error
        {
            get { return error; }
            set { error = value; }
        }

        private double YK;

        public double YK1
        {
            get { return YK; }
            set { YK = value; }
        }

        private double f_dash_k;

        public double F_dash_k
        {
            get { return f_dash_k; }
            set { f_dash_k = value; }
        }
        #endregion

        public Output()
        {

        }

        public void calc_sigma(int num_classs)
        {
            double res = Math.Exp(-1*value);
            YK = 1 / (1 + res);
            f_dash_k = YK*(1 - YK);
            sigma = (num_classs - YK) * f_dash_k;
        }

        
    }
}
