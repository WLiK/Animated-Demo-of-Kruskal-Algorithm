using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace WpfApplication1
{
    class Coordinate
    {
        /// <summary>
        /// the seat of the Canvas
        /// </summary>
        protected int seat;

        /// <summary>
        /// the x figure of the coordinate
        /// </summary>
        protected double _x;

        /// <summary>
        /// the y figure of the coordinate
        /// </summary>
        protected double _y;

        public Coordinate(int s, double x, double y)
        {
            seat = s;
            _x = x;
            _y = y;
        }

        /// <summary>
        /// the Seat
        /// </summary>
        public int Seat
        {
            get
            {
                return seat;
            }
            set
            {
                seat = value;
            }
        }

        /// <summary>
        /// X
        /// </summary>
        public double X
        {
            get
            {
                return _x;
            }
            set
            {
                _x = value;
            }
        }

        /// <summary>
        /// Y
        /// </summary>
        public double Y
        {
            get
            {
                return _y;
            }
            set
            {
                _y = value;
            }
        }
    }
}
