using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace WpfApplication1
{
    class LineCoordinate
    {
        /// <summary>
        /// the start point(x1,y1) of the line 
        /// </summary>
        protected double x1;
        protected double y1;
        /// <summary>
        /// the stop point (x2,y2) of the line 
        /// </summary>
        protected double x2;
        protected double y2;

        /// <summary>
        /// Init the coordinates of the line
        /// </summary>
        /// <param name="_x1"></param>
        /// <param name="_y1"></param>
        /// <param name="_x2"></param>
        /// <param name="_y2"></param>

        public double X1
        {
            get
            {
                return x1;
            }
            set
            {
                x1 = value;
            }
        }

        public double Y1
        {
            get
            {
                return y1;
            }
            set
            {
                y1 = value;
            }
        }

        public double X2
        {
            get
            {
                return x2;
            }
            set
            {
                x2 = value;
            }
        }

        public double Y2
        {
            get
            {
                return y2;
            }
            set
            {
                y2 = value;
            }
        }
    }
}
