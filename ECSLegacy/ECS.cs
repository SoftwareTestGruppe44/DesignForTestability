namespace ECSLegacy
{
    public class ECS
    {
        private int _thresholdHeater;
        private int _thresholdWindow;
        private readonly ITempSensor _tempSensor;
        private readonly IHeater _heater;
        private readonly IWindow _window;


        public ECS(int thrHeater, int thrWindow, ITempSensor tempSensor, IHeater heater, IWindow window)
        {
            SetThreshold(thrHeater);
            _thresholdWindow = thrWindow;
            _tempSensor = tempSensor;
            _heater = heater;
            _window = window;
        }

        public void Regulate()
        {
            var t = _tempSensor.GetTemp();
            if (t < _thresholdHeater && !_window.WindowOpen)
            {
                _heater.TurnOn();
            }
            else
            {
                _heater.TurnOff();
            }

            if (t > _thresholdWindow)
            {
                _heater.TurnOff();
                _window.Open();
            }
            else
                _window.Close();
                
        }

        public void SetThreshold(int thrHeater)
        {
            _thresholdHeater = thrHeater;
        }

        public int GetThreshold()
        {
            return _thresholdHeater;
        }

        public int GetCurTemp()
        {
            return _tempSensor.GetTemp();
        }

        public bool RunSelfTest()
        {
            return _tempSensor.RunSelfTest() && _heater.RunSelfTest();
        }
    }
}