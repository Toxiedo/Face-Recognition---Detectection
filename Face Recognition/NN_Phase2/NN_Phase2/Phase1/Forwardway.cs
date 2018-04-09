using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace NN_Phase2.Phase1
{
    class Forwardway
    {
        public static void forwrad(ref List<Hidden_Layer> HL , double[]samples , ref List<Output>outputs)
        {
            for (int i = 0; i < HL.Count; i++)
            {
                if (i == 0)
                {
                    int count=0;
                    for (int S = 0; S < HL[i].Value_neorons.Length; S++)
                    {
                        for (int B = 0; B < samples.Length; B++)
                        {
                            HL[i].Value_neorons[S] += samples[B] * HL[i].Wei[count];
                            count++;
                        }
                    }
                    count = 0;
                    for (int j = 0; j < HL[i + 1].Value_neorons.Length; j++)
                    {
                        for (int B = 0; B < HL[i].Value_neorons.Length; B++)
                        {
                            HL[i + 1].Value_neorons[j] += HL[i].Weights[count] * HL[i].Value_neorons[B];
                            count++;
                        }
                    }
                }
                else if (i == HL.Count - 1)
                {
                    int count = 0;
                    for (int S = 0; S < outputs.Count; S++)
                    {
                        for (int B = 0; B < HL[i].Value_neorons.Length; B++)
                        {
                            outputs[S].Value += HL[i].Value_neorons[B] * HL[i].Weights[count];
                            count++;
                        }
                    }
                }
                else
                {
                    int count =0;
                    for (int j = 0; j < HL[i+1].Value_neorons.Length; j++)
                    {
                        for (int B = 0; B < HL[i].Value_neorons.Length; B++)
                        {
                            HL[i + 1].Value_neorons[j] += HL[i].Weights[count] * HL[i].Value_neorons[B];
                            count++;
                        }
                    }
                }
            }
        }

        public static void update_weights(ref List<Hidden_Layer> HL, double[] samples, ref List<Output> outputs , double eta)
        {
            for (int i = HL.Count - 1; i >= 0; i--)
            {

                if (i == 0)
                {
                    int count = 0;
                    for (int j = 0; j < HL[i + 1].Value_neorons.Length; j++)
                    {
                        for (int B = 0; B < HL[i].Value_neorons.Length; B++)
                        {
                            HL[i].Weights[count] = HL[i].Weights[count] + eta * HL[i + 1].Sigma[j] * HL[i].Y_h1[B];
                            count++;
                        }
                    }
                    count = 0;               
                    for (int S = 0; S < HL[i].Value_neorons.Length; S++)
                    {
                        for (int B = 0; B < samples.Length; B++)
                        {
                            HL[i].Wei[count] = HL[i].Wei[count] + eta * HL[i].Sigma[S] * samples[B];
                            count++;
                        }
                    }
                    
                }
                else if (i == HL.Count - 1)
                {
                    int count = 0;
                    for (int S = 0; S < outputs.Count; S++)
                    {
                        for (int B = 0; B < HL[i].Value_neorons.Length; B++)
                        {
                            HL[i].Weights[count] = HL[i].Weights[count] + eta * outputs[S].Sigma * HL[i].Y_h1[B]; 
                            count++;
                        }
                    }
                }
                else
                {
                    int count = 0;
                    for (int j = 0; j < HL[i + 1].Value_neorons.Length; j++)
                    {
                        for (int B = 0; B < HL[i].Value_neorons.Length; B++)
                        {
                            HL[i].Weights[count] = HL[i].Weights[count] + eta * HL[i+1].Sigma[j] * HL[i].Y_h1[B];
                            count++;
                        }
                    }
                }

            }
        }


        public static double[] forwrad_for_test(List<Hidden_Layer> HL, double[] samples, List<Output> outputs)
        {
            double[] res = new double[outputs.Count];
            for (int i = 0; i < HL.Count; i++)
            {
                if (i == 0)
                {
                    int count = 0;
                    for (int S = 0; S < HL[i].Value_neorons.Length; S++)
                    {
                        for (int B = 0; B < samples.Length; B++)
                        {
                            HL[i].Value_neorons[S] += samples[B] * HL[i].Wei[count];
                            count++;
                        }
                    }
                    count = 0;
                    for (int j = 0; j < HL[i + 1].Value_neorons.Length; j++)
                    {
                        for (int B = 0; B < HL[i].Value_neorons.Length; B++)
                        {
                            HL[i + 1].Value_neorons[j] += HL[i].Weights[count] * HL[i].Value_neorons[B];
                            count++;
                        }
                    }
                }
                else if (i == HL.Count - 1)
                {
                    int count = 0;
                    for (int S = 0; S < outputs.Count; S++)
                    {
                        for (int B = 0; B < HL[i].Value_neorons.Length; B++)
                        {
                            outputs[S].Value += HL[i].Value_neorons[B] * HL[i].Weights[count];
                            
                            count++;
                        }
                        res[S] = outputs[S].Value;
                    }
                }
                else
                {
                    int count = 0;
                    for (int j = 0; j < HL[i + 1].Value_neorons.Length; j++)
                    {
                        for (int B = 0; B < HL[i].Value_neorons.Length; B++)
                        {
                            HL[i + 1].Value_neorons[j] += HL[i].Weights[count] * HL[i].Value_neorons[B];
                            count++;
                        }
                    }
                }
            }
            return res;
        }



    }
}
