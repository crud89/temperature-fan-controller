using FanControl.Plugins;

namespace FanControl.SerialTemperaturePlugin
{
    public class SerialTemperatureSensor : IPluginSensor
    {
        private TemperatureReader reader;

        public SerialTemperatureSensor(TemperatureReader reader)
        {
            this.reader = reader;
            this.reader.TemperatureRead += (sender, value) => this.Value = value;
        }

        public string Id => Name;

        public string Name => "USB Temperature Sensor";

        public float? Value { get; private set; }

        public void Update()
        {
        }
    }
}
