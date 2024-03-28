
using SharpDX.DirectInput;
using System.Windows.Forms;

namespace FingerTrainer
{
    public partial class MainForm : Form
    {
        private CustomJoystick leftJoystick = new CustomJoystick();
        private CustomJoystick rightJoystick = new CustomJoystick();

        private Circle leftCircle = new Circle();
        private Circle rightCircle = new Circle();

        private double averageTaskAcomplishTimeSeconds = 0;
        private bool isTrainingStarted = false;

        private bool isLeftMatched = true;
        private bool isRightMatched = true;

        private int panelSize = 400;
        private DateTime timeStarted = DateTime.MinValue;

        public MainForm()
        {
            InitializeComponent();

            this.panel1.Paint += new PaintEventHandler(panel1_Paint);
            this.panel2.Paint += new PaintEventHandler(panel2_Paint);

            panel1.Size = new Size(panelSize, panelSize);
            panel2.Size = new Size(panelSize, panelSize);

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
                label2.Text = $"Found Device: {deviceInstance.InstanceName}";
                label2.ForeColor = Color.Green;

                if (deviceInstance.InstanceName.ToLowerInvariant().Contains("RadioMaster TX12".ToLowerInvariant()))
                {
                    joystickGuid = deviceInstance.InstanceGuid;
                    break;
                }
            }

            if (joystickGuid == Guid.Empty)
            {
                Console.WriteLine();
                label2.Text = $"Device not found.";
                label2.ForeColor = Color.Red;
                return;
            }

            Task.Run(() =>
            {
                // Instantiate the joystick
                using (var joystick = new Joystick(directInput, joystickGuid))
                {
                    // Acquire the joystick
                    joystick.Acquire();

                    // Poll for current state
                    while (true)
                    {
                        joystick.Poll();
                        var state = joystick.GetCurrentState();

                        if (rightJoystick.UpdateValues(state.X, state.Y))
                        {
                            panel1.Invoke(Refresh);
                        }
                        if (leftJoystick.UpdateValues(state.RotationX, state.Z))
                        {
                            panel2.Invoke(Refresh);
                        }

                        Thread.Sleep(10); // Adjust polling rate as needed
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
            var coords = PaintPanel(e, leftJoystick, panel1, leftCircle);
            if (leftCircle.IsPointInside(coords.Item1, coords.Item2))
            {
                isLeftMatched = true;
            }
        }

        private void panel2_Paint(object? sender, PaintEventArgs e)
        {
            var coords = PaintPanel(e, rightJoystick, panel2, rightCircle);
            if (rightCircle.IsPointInside(coords.Item1, coords.Item2))
            {
                isRightMatched = true;
            }
        }

        private (double, double) PaintPanel(PaintEventArgs e, CustomJoystick joystick, CustomPanel panel, Circle circle)
        {
            Graphics g = e.Graphics;

            // Set the color and width of the border
            Color borderColor = Color.Blue; // This can be any color
            float borderWidth = 5; // This can be adjusted to your preference

            using (Pen pen = new Pen(borderColor, borderWidth))
            {
                // Drawing the border inside the panel bounds
                // Note: Drawing inside to avoid clipping issues
                Rectangle rect = new Rectangle(0, 0, panel.Width - 1, panel.Height - 1);

                e.Graphics.DrawRectangle(pen, rect);
            }

            int centerX = panel.Width / 2;
            int centerY = panel.Height / 2;
            var halfSize = centerX;

            var normalizedValues = joystick.GetNormalizedValues();
            var xJoyPosition = normalizedValues.Item1 * halfSize;
            var yJoyPosition = normalizedValues.Item2 * halfSize;

            var convertedCoordinates = ConvertCoordinates(centerX, centerY, xJoyPosition, yJoyPosition);

            Brush centerBrush = new SolidBrush(Color.Red);

            // Size of the center point (as a small circle or square)
            int centerSize = 5; // Adjust the size as needed

            // Draw the center point. To draw it as a small circle:
            g.FillEllipse(centerBrush, (float)convertedCoordinates.Item1, (float)convertedCoordinates.Item2, centerSize, centerSize);

            if (circle.X != 0 && circle.Y != 0)
            {
                g.DrawEllipse(new Pen(Color.Green, 2), circle.X, circle.Y, (float)circle.Radius, (float)circle.Radius);
            }

            return convertedCoordinates;
        }

        private void button1_Click(object sender, EventArgs e)
        {
            isTrainingStarted = true;
            var rnd = new Random();
            timeStarted = DateTime.Now;
            isLeftMatched = isRightMatched = true;

            Task.Run(async () =>
            {
                do
                {
                    if (isLeftMatched && isRightMatched)
                    {
                        isRightMatched = isLeftMatched = false;

                        var timeToFinish = DateTime.Now - timeStarted;
                        averageTaskAcomplishTimeSeconds = (averageTaskAcomplishTimeSeconds + timeToFinish.Seconds) / 2;

                        int diametr = (int)panelSize / (int)(5 * level.Value);

                        var x = rnd.Next(diametr, panelSize - diametr);
                        var y = rnd.Next(diametr, panelSize - diametr);

                        leftCircle.Radius = diametr / 2;
                        leftCircle.X = x;
                        leftCircle.Y = y;

                        x = rnd.Next(diametr, panelSize - diametr);
                        y = rnd.Next(diametr, panelSize - diametr);

                        rightCircle.Radius = diametr / 2;
                        rightCircle.X = x;
                        rightCircle.Y = y;

                        timeStarted = DateTime.Now;

                        richTextBox1.Invoke(() => richTextBox1.Text = $"Average response time is: {averageTaskAcomplishTimeSeconds} seconds");
                    }

                    if (!isTrainingStarted)
                    {
                        return;
                    }

                    await Task.Delay(10);
                }
                while (true);
            });
        }

        private void button2_Click(object sender, EventArgs e)
        {
            isTrainingStarted = false;
        }
    }
}
