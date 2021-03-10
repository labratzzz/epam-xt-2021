using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OkayOkayProgramming
{
    class CustomString : IComparable, ICloneable
    {
        private char[] _storage;

        public int Length { get => _storage.Length; }

        private CustomString(int length)
        {
            _storage = new char[length];
        }
        public CustomString()
        {
            _storage = new char[0];
        }
        public CustomString(string value)
        {
            _storage = new char[value.Length];
            for (int i = 0; i < _storage.Length; i++) _storage[i] = value[i];
        }
        public CustomString(char value, int length)
        {
            _storage = new char[length];
            for (int i = 0; i < _storage.Length; i++) _storage[i] = value;
        }

        public char this[int index]
        {
            get => (index < 0 || index >= _storage.Length) ? throw new IndexOutOfRangeException(nameof(index)) : _storage[index];
            set => _storage[(index < 0 || index >= _storage.Length) ? throw new IndexOutOfRangeException(nameof(index)) : index] = value;
        }

        //Interfaces
        public int CompareTo(object value) { }
        public object Clone() { }

        //Instruments
        public CustomString Insert(int startIndex, string value)
        {
            if (startIndex < 0 || startIndex >= _storage.Length) throw new IndexOutOfRangeException(nameof(startIndex));
            if (value == null) throw new ArgumentNullException(nameof(value));
        }
        public CustomString Replace(char oldChar, char newChar) { }
        public CustomString Replace(string oldStr, string newStr) { }
        public CustomString Replace(CustomString oldStr, CustomString newStr) { }

        public bool Contains(char value) => (IndexOf(value) != -1) ? true : false;
        public int IndexOf(char value, int startIndex, int count)
        {
            if (startIndex < 0 || startIndex >= _storage.Length) throw new IndexOutOfRangeException();
            int endIndex = startIndex + count - 1;
            if (endIndex < 0 || endIndex >= _storage.Length) throw new IndexOutOfRangeException();

            for (int i = endIndex; i >- startIndex; i--) if (value == _storage[i]) return i;
            return -1;
        }
        public int IndexOf(char value, int startIndex) => IndexOf(value, startIndex, this._storage.Length);
        public int IndexOf(char value) => IndexOf(value, 0, this._storage.Length);
        public int LastIndexOf(char value, int startIndex) => IndexOf(value, startIndex, this._storage.Length);
        public int LastIndexOf(char value) => IndexOf(value, 0, this._storage.Length);
        public int LastIndexOf(char value, int startIndex, int count)
        {
            if (startIndex < 0 || startIndex >= _storage.Length) throw new IndexOutOfRangeException();
            int endIndex = startIndex + count;
            if (endIndex < 0 || endIndex >= _storage.Length) throw new IndexOutOfRangeException();

            for (int i = startIndex; i < endIndex; i++) if (value == _storage[i]) return i;
            return -1;
        }

        public static CustomString Concat(CustomString val1, CustomString val2)
        {
            int length =  val1._storage.Length + val2._storage.Length;
            CustomString result = new CustomString(length);
            for (int i = 0; i < val1._storage.Length; i++) result._storage[i] = val1._storage[i];
            for (int i = val1._storage.Length; i < length; i++) result._storage[i] = val2._storage[i - val1._storage.Length];
            return result;
        }
        public static CustomString Concat(CustomString val1, string val2)
        {
            int length = val1._storage.Length + val2.Length;
            CustomString result = new CustomString(length);
            for (int i = 0; i < val1._storage.Length; i++) result._storage[i] = val1._storage[i];
            for (int i = val1._storage.Length; i < length; i++) result._storage[i] = val2[i - val1._storage.Length];
            return result;
        }
        public static CustomString Concat(string val1, CustomString val2)
        {
            int length = val1.Length + val2._storage.Length;
            CustomString result = new CustomString(length);
            for (int i = 0; i < val1.Length; i++) result._storage[i] = val1[i];
            for (int i = val1.Length; i < length; i++) result._storage[i] = val2[i - val1.Length];
            return result;
        }
        public static CustomString Concat(CustomString val1, object val2) => CustomString.Concat(val1, val2.ToString());
        public static CustomString Concat(object val1, CustomString val2) => CustomString.Concat(val1.ToString(), val2);

        public static CustomString operator +(CustomString val1, CustomString val2) => CustomString.Concat(val1, val2);
        public static CustomString operator +(CustomString val1, string val2) => CustomString.Concat(val1, val2);
        public static CustomString operator +(string val1, CustomString val2) => CustomString.Concat(val1, val2);
        public static CustomString operator +(CustomString val1, object val2) => CustomString.Concat(val1, val2.ToString());
        public static CustomString operator +(object val1, CustomString val2) => CustomString.Concat(val1.ToString(), val2);


        public override bool Equals(object obj)
        {
            string s;
            return base.Equals(obj);
        }
        public override string ToString()
        {
            return new String(_storage);
        }
    }
}
