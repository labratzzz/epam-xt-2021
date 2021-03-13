using System;

namespace MyTools
{
    public sealed class CustomString : ICloneable
    {
        //Fileds
        private char[] _storage;

        //Constructors
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

        //Properties
        public static CustomString Empty { get => new CustomString(); }
        public int Length { get => _storage.Length; }

        //Indexers
        public char this[int index]
        {
            get => (index < 0 || index >= _storage.Length) ? throw new IndexOutOfRangeException(nameof(index)) : _storage[index];
            set => _storage[(index < 0 || index >= _storage.Length) ? throw new IndexOutOfRangeException(nameof(index)) : index] = value;
        }

        //Interfaces (implementations)
        public object Clone()
        {
            CustomString result = new CustomString(this._storage.Length);
            for (int i = 0; i < this._storage.Length; i++)
            {
                result._storage[i] = _storage[i];
            }
            return result;
        }

        //Methods
        public static bool Equals(CustomString val1, CustomString val2)
        {
            if (val1._storage.Length != val2._storage.Length) return false;
            for (int i = 0; i < val2._storage.Length; i++)
            {
                if (val1[i] != val2[i]) return false;
            }
            return true;
        }
        public bool Equals(CustomString obj)
        {
            if (this._storage.Length != obj._storage.Length) return false;
            for (int i = 0; i < obj._storage.Length; i++)
            {
                if (this[i] != obj[i]) return false;
            }
            return true;
        }
        public override bool Equals(object obj) => (obj is CustomString) ? this.Equals(obj as CustomString) : false;
        public override string ToString()
        {
            return new string(_storage);
        }
        public char[] ToCharArray() => _storage;
        public CustomString Insert(int startIndex, string value)
        {
            if (startIndex < 0 || startIndex >= _storage.Length) throw new IndexOutOfRangeException(nameof(startIndex));
            if (value is null) throw new ArgumentNullException(nameof(value));
            return this.Substring(0, startIndex) + (CustomString)value + this.Substring(startIndex, this.Length - startIndex);
        }
        public CustomString Insert(int startIndex, CustomString value)
        {
            if (startIndex < 0 || startIndex >= _storage.Length) throw new IndexOutOfRangeException(nameof(startIndex));
            if (value is null) throw new ArgumentNullException(nameof(value));
            return this.Substring(0, startIndex) + value + this.Substring(startIndex, this.Length - startIndex);
        }
        public CustomString Replace(char oldChar, char newChar)
        {
            CustomString result = this.Clone() as CustomString;
            for (int i = 0; i < result._storage.Length; i++)
            {
                if (result._storage[i] == oldChar) result._storage[i] = newChar;
            }
            return result;
        }
        public CustomString Substring(int startIndex) => this.Substring(startIndex, this._storage.Length - startIndex);
        public CustomString Substring(int startIndex, int length)
        {
            if (startIndex < 0 || startIndex >= _storage.Length) throw new ArgumentOutOfRangeException(nameof(length));
            if (startIndex + length > this._storage.Length) throw new ArgumentOutOfRangeException(nameof(length));
            CustomString result = new CustomString(length);
            for (int i = 0; i < length; i++)
            {
                result[i] = this._storage[i + startIndex];
            }
            return result;
        }
        public bool Contains(char value) => (this.IndexOf(value) != -1) ? true : false;
        public bool Contains(string value)
        {
            if (value.Length == 0) return true;
            if (value.Length == 1) return this.Contains(value[0]);
            if (value.Length > this._storage.Length) return false;

            if (value.Length == this._storage.Length) return this == value;

            int startIndex = 0;
            while (true)
            {
                startIndex = this.IndexOf(value[0], startIndex, this._storage.Length - startIndex);
                if (startIndex == -1) return false;
                if (startIndex + value.Length > this.Length) return false;
                bool found = true;
                for (int j = 1; j < value.Length; j++)
                {
                    if (this._storage[j + startIndex] != value[j])
                    {
                        found = false;
                        break;
                    }
                }
                if (found) return true;
                startIndex++;
            }
        }
        public int IndexOf(char value, int startIndex, int count)
        {
            if (startIndex < 0 || startIndex >= _storage.Length) throw new IndexOutOfRangeException();
            int endIndex = startIndex + count - 1;
            if (endIndex < 0 || endIndex >= _storage.Length) throw new IndexOutOfRangeException();

            for (int i = startIndex; i <= endIndex; i++)
            {
                if (value == _storage[i]) return i;
            }
            return -1;
        }
        public int IndexOf(char value, int startIndex) => IndexOf(value, startIndex, this._storage.Length - startIndex);
        public int IndexOf(char value) => IndexOf(value, 0, this._storage.Length);
        public int LastIndexOf(char value, int startIndex, int count)
        {
            if (startIndex < 0 || startIndex >= _storage.Length) throw new IndexOutOfRangeException();
            int endIndex = startIndex + count - 1;
            if (endIndex < 0 || endIndex >= _storage.Length) throw new IndexOutOfRangeException();

            for (int i = endIndex; i >= startIndex; i--)
            {
                if (value == _storage[i]) return i;
            }
            return -1;
        }
        public int LastIndexOf(char value, int startIndex) => LastIndexOf(value, startIndex, this._storage.Length - startIndex);
        public int LastIndexOf(char value) => LastIndexOf(value, 0, this._storage.Length);

        public static CustomString Concat(CustomString val1, CustomString val2)
        {
            int length = val1._storage.Length + val2._storage.Length;
            CustomString result = new CustomString(length);
            for (int i = 0; i < val1._storage.Length; i++)
            {
                result._storage[i] = val1._storage[i];
            }
            for (int i = val1._storage.Length; i < length; i++)
            {
                result._storage[i] = val2._storage[i - val1._storage.Length];
            }
            return result;
        }
        public static CustomString Concat(CustomString val1, string val2)
        {
            int length = val1._storage.Length + val2.Length;
            CustomString result = new CustomString(length);
            for (int i = 0; i < val1._storage.Length; i++)
            {
                result._storage[i] = val1._storage[i];
            }
            for (int i = val1._storage.Length; i < length; i++)
            {
                result._storage[i] = val2[i - val1._storage.Length];
            }
            return result;
        }
        public static CustomString Concat(string val1, CustomString val2)
        {
            int length = val1.Length + val2._storage.Length;
            CustomString result = new CustomString(length);
            for (int i = 0; i < val1.Length; i++)
            {
                result._storage[i] = val1[i];
            }
            for (int i = val1.Length; i < length; i++)
            {
                result._storage[i] = val2[i - val1.Length];
            }
            return result;
        }
        public static CustomString Concat(CustomString val1, object val2) => CustomString.Concat(val1, val2.ToString());
        public static CustomString Concat(object val1, CustomString val2) => CustomString.Concat(val1.ToString(), val2);

        //Operators
        public static explicit operator CustomString(string value) => new CustomString(value);
        public static explicit operator string(CustomString value) => value.ToString();
        public static CustomString operator +(CustomString val1, CustomString val2) => CustomString.Concat(val1, val2);
        public static CustomString operator +(CustomString val1, string val2) => CustomString.Concat(val1, val2);
        public static CustomString operator +(string val1, CustomString val2) => CustomString.Concat(val1, val2);
        public static CustomString operator +(CustomString val1, object val2) => CustomString.Concat(val1, val2.ToString());
        public static CustomString operator +(object val1, CustomString val2) => CustomString.Concat(val1.ToString(), val2);
        public static bool operator ==(CustomString val1, string val2) => CustomString.Equals(val1, (CustomString)val2);
        public static bool operator !=(CustomString val1, string val2) => !CustomString.Equals(val1, (CustomString)val2);
        public static bool operator ==(CustomString val1, CustomString val2) => CustomString.Equals(val1, val2);
        public static bool operator !=(CustomString val1, CustomString val2) => !CustomString.Equals(val1, val2);
    }
}