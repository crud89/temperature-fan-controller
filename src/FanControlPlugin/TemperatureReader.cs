using System;
using System.Globalization;
using System.IO.Ports;

namespace FanControl.SerialTemperaturePlugin
{
    public class TemperatureReader : IDisposable
    {
        private SerialPort port;
        private bool disposed = false;

        public event EventHandler<float> TemperatureRead;

        public TemperatureReader(string portName)
        {
            port = new SerialPort(portName, 9600, Parity.None, 8, StopBits.One);
            port.DtrEnable = true;
            port.DataReceived += (sender, e) => TemperatureRead?.Invoke(this, Convert.ToSingle(port.ReadLine(), CultureInfo.InvariantCulture));
            port.Open();
        }

        ~TemperatureReader()
        {
            this.Dispose(false);
        }

        public void Dispose()
        {
            this.Dispose(true);
            GC.SuppressFinalize(this);
        }

        protected virtual void Dispose(bool disposing)
        {
            if (!disposed)
            {
                port.Close();
                disposed = true;
            }
        }
    }
}
