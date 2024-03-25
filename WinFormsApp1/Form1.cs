
using SharpDX.DirectInput;

namespace WinFormsApp1
{
    public partial class Form1 : Form
    {
        private CustomJoystick leftJoystick = new CustomJoystick();
        private CustomJoystick rightJoystick = new CustomJoystick();

        public Form1()
        {
            InitializeComponent();

            this.panel1.Paint += new PaintEventHandler(panel1_Paint);
            this.panel2.Paint += new PaintEventHandler(panel2_Paint);

            Init();
        }

        private void Init()
        {
            // Initialize DirectInput
            var directInput = new DirectInput();

            // Find the RadioMaster TX12 device (assuming it's connected and recognized as a joystick)
            var joystickGuid = Guid.Empty;
            foreach (var deviceInstance in directInput.GetDevices(DeviceType.FirstPerson, DeviceEnumerationFlags.AllDevices))
            {
                Console.WriteLine($"Found Device: {deviceInstance.InstanceName}");
                if (deviceInstance.InstanceName.ToLowerInvariant().Contains("RadioMaster TX12".ToLowerInvariant()))
                {
                    joystickGuid = deviceInstance.InstanceGuid;
                    break;
                }
            }

            if (joystickGuid == Guid.Empty)
            {
                Console.WriteLine("RadioMaster TX12 not found.");
                return;
            }

            Task.Run(() =>
            {
                // Instantiate the joystick
                using (var joystick = new Joystick(directInput, joystickGuid))
                {
                    Console.WriteLine("RadioMaster TX12 found, initializing...");

                    // Acquire the joystick
                    joystick.Acquire();

                    // Poll for current state
                    while (true)
                    {
                        joystick.Poll();
                        var state = joystick.GetCurrentState();

                        rightJoystick.UpdateValues(state.X, state.Y);
                        leftJoystick.UpdateValues(state.RotationX, state.Z);

                        panel1.Invoke(Refresh);
                        panel2.Invoke(Refresh);

                        Thread.Sleep(100); // Adjust polling rate as needed
                    }
                }
            });
        }

        public (double, double) ConvertCoordinates(double circleCenterX, double circleCenterY, double pointX, double pointY)
        {
            // Calculate new coordinates
            double newX = pointX + circleCenterX;
            double newY = circleCenterY - pointY;

            return (newX, newY);
        }

        private void panel1_Paint(object? sender, PaintEventArgs e)
        {
            Graphics g = e.Graphics;

            // Set the pen for drawing
            Pen pen = new Pen(Color.Blue, 2);

            // Calculate the position and size for the circle to be centered
            int diameter = Math.Min(panel1.Width, panel1.Height) - 10; // Subtract a little so the circle fits inside
            int radius = diameter / 2;
            int x = (panel1.Width - diameter) / 2;
            int y = (panel1.Height - diameter) / 2;

            // Draw the circle
            g.DrawEllipse(pen, x, y, diameter, diameter);

            var normalizedValues = leftJoystick.GetNormalizedValues();
            var xJoyPosition = normalizedValues.Item1 * radius;
            var yJoyPosition = normalizedValues.Item2 * radius;

            // Calculate the center point of the circle
            int centerX = x + diameter / 2;
            int centerY = y + diameter / 2;

            var convertedCoordinates = ConvertCoordinates(centerX, centerY, xJoyPosition, yJoyPosition);

            Brush centerBrush = new SolidBrush(Color.Red);

            // Size of the center point (as a small circle or square)
            int centerSize = 5; // Adjust the size as needed

            // Draw the center point. To draw it as a small circle:
            g.FillEllipse(centerBrush, (float)convertedCoordinates.Item1, (float)convertedCoordinates.Item2, centerSize, centerSize);
        }

        private void panel2_Paint(object? sender, PaintEventArgs e)
        {
            Graphics g = e.Graphics;

            // Set the pen for drawing
            Pen pen = new Pen(Color.Blue, 2);

            // Calculate the position and size for the circle to be centered
            int diameter = Math.Min(panel1.Width, panel1.Height) - 10; // Subtract a little so the circle fits inside
            int radius = diameter / 2;
            int x = (panel1.Width - diameter) / 2;
            int y = (panel1.Height - diameter) / 2;

            // Draw the circle
            g.DrawEllipse(pen, x, y, diameter, diameter);
            // Calculate the center point of the circle
            int centerX = x + diameter / 2;
            int centerY = y + diameter / 2;

            var normalizedValues = rightJoystick.GetNormalizedValues();
            var xJoyPosition = normalizedValues.Item1 * radius;
            var yJoyPosition = normalizedValues.Item2 * radius;

            var convertedCoordinates = ConvertCoordinates(centerX, centerY, xJoyPosition, yJoyPosition);

            Brush centerBrush = new SolidBrush(Color.Red);

            // Size of the center point (as a small circle or square)
            int centerSize = 5; // Adjust the size as needed

            // Draw the center point. To draw it as a small circle:
            g.FillEllipse(centerBrush, (float)convertedCoordinates.Item1, (float)convertedCoordinates.Item2, centerSize, centerSize);
        }

        private void startToolStripMenuItem_Click(object sender, EventArgs e)
        {

        }

        private void stopToolStripMenuItem_Click(object sender, EventArgs e)
        {

        }
    }
}
