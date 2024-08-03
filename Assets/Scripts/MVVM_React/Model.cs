using UnityEngine;

namespace MVVM_React
{
    public class Model
    {
        private int _intValue;
        private string _stringValue = string.Empty;

        public void IntValueChange(int newValue)
        {
            if (IsValidateIntValue(newValue))
                _intValue = newValue;
        }

        public void StringValueChange(string newValue)
        {
            if (IsValidateStringValue(newValue))
                _stringValue = newValue;
        }

        private bool IsValidateIntValue(int newValue) =>
            Mathf.Abs(newValue - _intValue) == 0 || Mathf.Abs(newValue - _intValue) == 1;

        private bool IsValidateStringValue(string newValue) =>
            Mathf.Abs(newValue.Length - _stringValue.Length) > -2 ||
            Mathf.Abs(newValue.Length - _stringValue.Length) < 2;
    }
}