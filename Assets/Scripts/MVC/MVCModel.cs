using System;

namespace MVC
{
    public class MVCModel
    {
        public event Action<int> IntValueChanged;
        public event Action<string> StringValueChanged;

        public int IntValue { get; private set; }
        private string _stringValue = string.Empty;
        
        public void IntValueChange(int newValue)
        {
            IntValue = newValue;
            IntValueChanged?.Invoke(IntValue);
        }

        public void StringValueChange(string newValue)
        {
            _stringValue = newValue;
            StringValueChanged?.Invoke(_stringValue);
        }
    }
}