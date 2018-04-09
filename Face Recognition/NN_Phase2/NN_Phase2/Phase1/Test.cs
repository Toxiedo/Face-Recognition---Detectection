using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace NN_Phase2.Phase1
{
    class Test
    {
        #region variables
        List<Hidden_Layer> H_Ls = new List<Hidden_Layer>();
        List<Output> outputs = new List<Output>();
        double[] sample;
        private double[] result;

        public double[] Result
        {
            get { return result; }
            set { result = value; }
        }
        #endregion

        public Test(List<Hidden_Layer> H_L, List<Output> output, double[] samples)
        {
            H_Ls = H_L;
            outputs = output;
            sample = samples;
            play();
        }

        private void play()
        {
          result =  Forwardway.forwrad_for_test(H_Ls, sample, outputs);
        }
    }
}
