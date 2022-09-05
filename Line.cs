using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LinesCrossings
{
    internal class Line
    {
        private int _k;
        private int _b;
        public int Kcoef
        {
            get { return _k; }
            init { _k = value; }
        }
        public int Bcoef
        {
            get { return _b; }
            init { _b = value; }
        }
        public Line(int k, int b)
        {     
            Kcoef = k;
            Bcoef = b;
        }

        public int FIndY(int x) => Kcoef * x + Bcoef;
        
      
        public static double[] GetCross(Line a, Line b)
        {
            var result = new double[2];
            if (a.Kcoef != b.Kcoef)
            {
                result[0] = (double)(b.Bcoef - a.Bcoef) / (double)(a.Kcoef - b.Kcoef);
                result[1] = (a.Kcoef * result[0] + a.Bcoef);
            }
            else
                if (a.Kcoef == b.Kcoef && a.Bcoef == b.Bcoef)
            {

                result[0] = double.MinValue;
                result[1] = double.MinValue;

            }
            else
            {

                result[0] = double.MaxValue;
                result[1] = double.MaxValue;

            }
            return result;

        }
    }
}
