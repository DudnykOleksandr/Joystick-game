using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WinFormsApp1
{
    public class CustomJoystick
    {
        private int maxValueX = 65400;
        private int minValueX = 0;

        private int maxValueY = 65400;
        private int minValueY = 0;

        private double normalizedX;
        private double normalizedY;

        public void UpdateValues(int x, int y)
        {
            var middleX = (maxValueX - minValueX) / 2;
            normalizedX = (double)(x - middleX) / middleX;

            var middleY = (maxValueY - minValueY) / 2;
            normalizedY = (double)(y - middleY) / middleY;
        }

        public Tuple<double, double> GetNormalizedValues()
        {
            return new Tuple<double, double>(normalizedX, normalizedY);
        }


    }
}
