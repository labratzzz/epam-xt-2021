namespace MyTools
{
    using System;

    public sealed class CustomString : ICloneable, IEquatable<CustomString>
    {
        // Fields
        private readonly char[] storage;

        // Constructors
        public CustomString()
        {
            this.storage = new char[0];
        }

        public CustomString(char[] value)
        {
            this.storage = new char[value.Length];
            for (int i = 0; i < this.storage.Length; i++)
            {
                this.storage[i] = value[i];
            }
        }

        public CustomString(string value)
        {
            this.storage = new char[value.Length];
            for (int i = 0; i < this.storage.Length; i++)
            {
                this.storage[i] = value[i];
            }
        }

        public CustomString(char value, int length)
        {
            this.storage = new char[length];
            for (int i = 0; i < this.storage.Length; i++)
            {
                this.storage[i] = value;
            }
        }

        private CustomString(int length)
        {
            this.storage = new char[length];
        }

        // Properties
        public static CustomString Empty { get => new CustomString(); }

        public int Length { get => this.storage.Length; }

        // Indexers
        public char this[int index]
        {
            get => this.storage[index];
            set => this.storage[index] = value;
        }

        // Methods
        // Static
        public static bool Equals(CustomString val1, CustomString val2)
        {
            if (val1.storage.Length != val2.storage.Length)
            {
                return false;
            }

            for (int i = 0; i < val2.storage.Length; i++)
            {
                if (val1[i] != val2[i]) return false;
            }

            return true;
        }

        public static CustomString Concat(CustomString val1, CustomString val2)
        {
            int length = val1.storage.Length + val2.storage.Length;
            CustomString result = new CustomString(length);

            for (int i = 0; i < val1.storage.Length; i++)
            {
                result.storage[i] = val1.storage[i];
            }

            for (int i = val1.storage.Length; i < length; i++)
            {
                result.storage[i] = val2.storage[i - val1.storage.Length];
            }

            return result;
        }

        public static CustomString Concat(CustomString val1, string val2)
        {
            int length = val1.storage.Length + val2.Length;
            CustomString result = new CustomString(length);

            for (int i = 0; i < val1.storage.Length; i++)
            {
                result.storage[i] = val1.storage[i];
            }

            for (int i = val1.storage.Length; i < length; i++)
            {
                result.storage[i] = val2[i - val1.storage.Length];
            }

            return result;
        }

        public static CustomString Concat(string val1, CustomString val2)
        {
            int length = val1.Length + val2.storage.Length;
            CustomString result = new CustomString(length);

            for (int i = 0; i < val1.Length; i++)
            {
                result.storage[i] = val1[i];
            }

            for (int i = val1.Length; i < length; i++)
            {
                result.storage[i] = val2[i - val1.Length];
            }

            return result;
        }

        public static CustomString Concat(CustomString val1, object val2) => CustomString.Concat(val1, val2.ToString());

        public static CustomString Concat(object val1, CustomString val2) => CustomString.Concat(val1.ToString(), val2);

        // Operators
        public static explicit operator CustomString(char[] value) => new CustomString(value);

        public static explicit operator char[](CustomString value) => value.ToCharArray();

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

        // Interfaces (implementations)
        public object Clone()
        {
            CustomString result = new CustomString(this.storage.Length);
            for (int i = 0; i < this.storage.Length; i++)
            {
                result.storage[i] = this.storage[i];
            }

            return result;
        }

        // Non-static
        public bool Equals(CustomString other)
        {
            if (this.storage.Length != other.storage.Length)
            {
                return false;
            }

            for (int i = 0; i < other.storage.Length; i++)
            {
                if (this[i] != other[i]) return false;
            }

            return true;
        }

        public override bool Equals(object obj) => (obj is CustomString) && this.Equals(obj as CustomString);

        public override string ToString()
        {
            return new string(this.storage);
        }

        public char[] ToCharArray() => this.storage; // TODO

        public CustomString Insert(int startIndex, string value)
        {
            if (startIndex < 0 || startIndex >= this.storage.Length) throw new IndexOutOfRangeException(nameof(startIndex));
            if (value is null) throw new ArgumentNullException(nameof(value));

            return this.Substring(0, startIndex) + (CustomString)value + this.Substring(startIndex, this.Length - startIndex);
        }

        public CustomString Insert(int startIndex, CustomString value)
        {
            if (startIndex < 0 || startIndex >= this.storage.Length) throw new IndexOutOfRangeException(nameof(startIndex));
            if (value is null) throw new ArgumentNullException(nameof(value));

            return this.Substring(0, startIndex) + value + this.Substring(startIndex, this.Length - startIndex);
        }

        public CustomString Replace(char oldChar, char newChar)
        {
            CustomString result = this.Clone() as CustomString;
            for (int i = 0; i < result.storage.Length; i++)
            {
                if (result.storage[i] == oldChar)
                {
                    result.storage[i] = newChar;
                }
            }

            return result;
        }

        public CustomString Substring(int startIndex) => this.Substring(startIndex, this.storage.Length - startIndex);

        public CustomString Substring(int startIndex, int length)
        {
            if (startIndex < 0 || startIndex >= this.storage.Length) throw new ArgumentOutOfRangeException(nameof(length));
            if (startIndex + length > this.storage.Length) throw new ArgumentOutOfRangeException(nameof(length));
            CustomString result = new CustomString(length);

            for (int i = 0; i < length; i++)
            {
                result[i] = this.storage[i + startIndex];
            }

            return result;
        }

        public bool Contains(char value) => (this.IndexOf(value) != -1);

        public bool Contains(string value)
        {
            if (value.Length == 0) 
            {
                return true;
            }

            if (value.Length == 1)
            {
                return this.Contains(value[0]);
            }

            if (value.Length > this.storage.Length)
            {
                return false;
            }

            if (value.Length == this.storage.Length)
            {
                return this == value;
            }

            int startIndex = 0;
            while (true)
            {
                startIndex = this.IndexOf(value[0], startIndex, this.storage.Length - startIndex);
                if (startIndex == -1) 
                {
                    return false;
                }

                if (startIndex + value.Length > this.Length)
                {
                    return false;
                }

                bool found = true;
                for (int j = 1; j < value.Length; j++)
                {
                    if (this.storage[j + startIndex] != value[j])
                    {
                        found = false;
                        break;
                    }
                }

                if (found)
                {
                    return true;
                }

                startIndex++;
            }
        }

        public int IndexOf(char value, int startIndex, int count)
        {
            if (startIndex < 0 || startIndex >= this.storage.Length) throw new IndexOutOfRangeException();
            int endIndex = startIndex + count - 1;
            if (endIndex < 0 || endIndex >= this.storage.Length) throw new IndexOutOfRangeException();

            for (int i = startIndex; i <= endIndex; i++)
            {
                if (value == this.storage[i])
                {
                    return i;
                }
            }

            return -1;
        }

        public int IndexOf(char value, int startIndex) => this.IndexOf(value, startIndex, this.storage.Length - startIndex);

        public int IndexOf(char value) => this.IndexOf(value, 0, this.storage.Length);

        public int LastIndexOf(char value, int startIndex, int count)
        {
            if (startIndex < 0 || startIndex >= this.storage.Length) throw new IndexOutOfRangeException();
            int endIndex = startIndex + count - 1;
            if (endIndex < 0 || endIndex >= this.storage.Length) throw new IndexOutOfRangeException();

            for (int i = endIndex; i >= startIndex; i--)
            {
                if (value == this.storage[i])
                {
                    return i;
                }
            }

            return -1;
        }

        public int LastIndexOf(char value, int startIndex) => this.LastIndexOf(value, startIndex, this.storage.Length - startIndex);

        public int LastIndexOf(char value) => this.LastIndexOf(value, 0, this.storage.Length);
    }
}