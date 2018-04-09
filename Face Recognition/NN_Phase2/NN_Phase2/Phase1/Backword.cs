using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace NN_Phase2.Phase1
{
    class Backword
    {
        public static void Calculate_Sigma(int k, ref List<Output> outputs)
        {
            double[] desierd = new double[5];
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

            for (int i = 0; i < desierd.Length; i++)
            {
                outputs[i].calc_sigma((int)desierd[i]);
            }
        }

        public static void Calculate_sigma_hiddens(ref List<Hidden_Layer> HL, double[] samples, ref List<Output> outputs)
        {
            
            for (int i = 0; i <HL.Count; i++)
            {
                HL[i].Y_h1 = new double[HL[i].Value_neorons.Length];
                HL[i].Q_v = new double[HL[i].Value_neorons.Length];
                HL[i].Sigma = new double[HL[i].Value_neorons.Length];
                for (int j = 0; j < HL[i].Value_neorons.Length; j++)
			        {
			            double res;
                        res = Math.Exp(-1*HL[i].Value_neorons[j]);
                        HL[i].Y_h1[j] = 1/(1+res);
                        HL[i].Q_v[j] = (1-HL[i].Y_h1[j])*(1+HL[i].Y_h1[j]);
			        }

            }
            for (int i = HL.Count-1; i >=0; i--)
            {
                
                if (i == HL.Count - 1)
                {
                    int count = 0;
                    double res=0;
                    for (int S = 0; S < HL[i].Value_neorons.Length; S++)
                    {
                        res = 0;
                        for (int B = 0; B < outputs.Count; B++)
                        {
                             res += HL[i].Weights[count] * outputs[B].Sigma;
                            count++;
                        }
                        HL[i].Sigma[S] = HL[i].Q_v[S] * res;
                    }
                }
                else
                {
                    int count = 0;
                    double res = 0;
                    for (int S = 0; S < HL[i].Value_neorons.Length; S++)
                    {
                        res = 0;
                        for (int B = 0; B < HL[i + 1].Value_neorons.Length; B++)
                        {
                            res += HL[i].Weights[count] * HL[i + 1].Sigma[B];
                            count++;
                        }
                        HL[i].Sigma[S] = HL[i].Q_v[S] * res;
                    }
                }
            }


        }
    }
}
