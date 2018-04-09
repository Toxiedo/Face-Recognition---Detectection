using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace NN_Phase2.Classes
{
    class neoron
    {
        #region variables
        private double variance;

        public double Variance
        {
            get { return variance; }
            set { variance = value; }
        }
        private double r;

        public double R
        {
            get { return r; }
            set { r = value; }
        }

        private double center;

        public double Center
        {
            get { return center; }
            set { center = value; }
        }

        private double[] centroid;

        public double[] Centroid
        {
            get { return centroid; }
            set { centroid = value; }
        }

        private List<int> mylist;

        public List<int> Mylist
        {
            get { return mylist; }
            set { mylist = value; }
        }

        #endregion

        public neoron()
        {
            mylist = new List<int>();
        }
    }
}
