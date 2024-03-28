namespace ConsoleApp16
{
    using System;
    using System.Text.Json.Serialization;
    using Newtonsoft.Json;
    using SharpDX.DirectInput;

    class Program
    {
        public class JoyValues
        {
            
        }
        static void Main(string[] args)
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
                    Console.SetCursorPosition(0, 0);
                    //Console.Write($"X: {state.X}, Y: {state.Y}, { state.RotationX },  {state.RotationY}"); // Example of reading the X and Y positions
                    
                    
                    Console.Write(JsonConvert.SerializeObject(state));

                    System.Threading.Thread.Sleep(1000); // Adjust polling rate as needed
                }
            }
        }
    }

}
