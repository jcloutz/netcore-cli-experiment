using System;

namespace CLITaskRunner.Core
{
    abstract public class Enumeration : IComparable
    {
        private readonly int _value;
        private readonly string _displayName;

        protected Enumeration() { }

        protected Enumeration(int value, string displayName)
        {
            _value = value;
            _displayName = displayName;
        }

        public int Value => _value;

        public string DisplayName => _displayName;

        public int GetHashCode()
        {
            return _value.GetHashCode();
        }
        
        public int CompareTo(object other)
        {
            return Value.CompareTo(((Enumeration) other).Value);
        }
    }
}