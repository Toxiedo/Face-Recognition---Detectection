using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace NN_Phase2.Classes
{
    class Output
    {
        private double error;

        public double Error
        {
            get { return error; }
            set { error = value; }
        }

        private double value;

        public double Value
        {
            get { return this.value; }
            set { this.value = value; }
        }

        public Output()
        {
        }
    }
}
