namespace FingerTrainer
{
    public class CustomJoystick
    {
        private int maxValueX = 65400;
        private int minValueX = 0;

        private int maxValueY = 65400;
        private int minValueY = 0;

        private double normalizedX;
        private double normalizedY;

        private int lastXValue = 0;
        private int lastYValue = 0;

        public bool UpdateValues(int x, int y)
        {
            if(lastXValue==x && lastYValue == y)
            {
                return false;
            }

            lastXValue = x;
            lastYValue = y;

            var middleX = (maxValueX - minValueX) / 2;
            normalizedX = (double)(x - middleX) / middleX;

            var middleY = (maxValueY - minValueY) / 2;
            normalizedY = (double)(y - middleY) / middleY;

            return true;
        }

        public Tuple<double, double> GetNormalizedValues()
        {
            return new Tuple<double, double>(normalizedX, normalizedY);
        }
    }
}
