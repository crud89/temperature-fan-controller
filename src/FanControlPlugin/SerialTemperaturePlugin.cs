using FanControl.Plugins;

namespace FanControl.SerialTemperaturePlugin
{
    public class SerialTemperaturePlugin : IPlugin
    {
        public string Name => "FanControl.SerialTemperatureSensor";

        private TemperatureReader reader;

        public void Close()
        {
            reader.Dispose();
            reader = null;
        }

        public void Initialize()
        {
            // TODO: Read from config file.
            reader = new TemperatureReader("COM3");
        }

        public void Load(IPluginSensorsContainer container)
        {
            if (reader != null)
                container.TempSensors.Add(new SerialTemperatureSensor(reader));
        }
    }
}
