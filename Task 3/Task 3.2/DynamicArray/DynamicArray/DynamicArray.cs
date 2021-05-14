namespace MyCollections
{
    using System;
    using System.Collections;
    using System.Collections.Generic;
    using System.Linq;

    public class DynamicArray<T> : IEnumerable<T>, IEnumerable, ICloneable
    {
        // Fields
        private const int InitialSize = 8;

        private int size;

        private T[] items;

        // Constructors
        public DynamicArray() : this(InitialSize) { }

        public DynamicArray(int capacity)
        {
            this.size = 0;
            this.items = new T[capacity];
        }

        public DynamicArray(IEnumerable<T> collection) : this(collection.Count())
        {
            this.size = collection.Count();
            foreach (var item in collection)
            {
                this.Add(item);
            }
        }

        // Properties

        /// <summary>
        /// Size of touched elements.
        /// </summary>
        public int Length
        {
            get => this.size;
        }

        /// <summary>
        /// Actual collection size.
        /// </summary>
        public int Capacity
        {
            get => this.items.Length;
            set
            {
                int currentCapacity = this.items.Length;
                if (value < 0) throw new ArgumentException(nameof(value));

                if (value == currentCapacity)
                {
                    return;
                }

                if (value == 0)
                {
                    this.items = new T[0];
                    return;
                }

                T[] newArray = new T[value];
                int lengthToCopy = (value < currentCapacity) ? value : this.size;

                Array.Copy(this.items, 0, newArray, 0, lengthToCopy);
                this.items = newArray;
            }
        }

        // Indexers
        public T this[int index]
        {
            get 
            {
                if (index < 0 || index >= this.size) throw new ArgumentOutOfRangeException(nameof(index));
                return this.items[index];
            }

            set
            {
                if (index < 0 || index >= this.size) throw new ArgumentOutOfRangeException(nameof(index));
                this.items[index] = value;
            }
        }

        // Methods
        public void Add(T item)
        {
            if (this.size == this.items.Count())
            {
                this.RecalculateCapacity(this.size + 1);
            }

            this.items[this.size++] = item;
        }

        public void AddRange(IEnumerable<T> collection) => this.InsertRange(this.size, collection);

        public void Insert(int index, T item)
        {
            this.RecalculateCapacity(this.size + 1);

            Array.Copy(this.items, index, this.items, index + 1, this.size - index);
            this.items[index] = item;

            this.size++;
        }

        public void InsertRange(int index, IEnumerable<T> collection)
        {
            if (index < 0 || index > this.size) throw new ArgumentOutOfRangeException(nameof(index));

            int rangeLength = collection.Count();
            this.RecalculateCapacity(this.size + rangeLength);

            Array.Copy(this.items, index, this.items, index + rangeLength, this.size - index);
            Array.Copy(collection.ToArray(), 0, this.items, index, rangeLength);

            this.size += rangeLength;
        }

        public T Find(Predicate<T> match)
        {
            int index = this.FindIndex(match);
            return (index != -1) ? this.items[index] : default;
        }

        public T FindLast(Predicate<T> match)
        {
            int index = this.FindLastIndex(match);
            return (index != -1) ? this.items[index] : default;
        }

        public int FindIndex(Predicate<T> match) => this.FindIndex(0, this.size, match);

        public int FindIndex(int startIndex, Predicate<T> match) => this.FindIndex(startIndex, this.size - startIndex, match);

        public int FindIndex(int startIndex, int count, Predicate<T> match)
        {
            if (startIndex < 0 || startIndex >= this.size) throw new ArgumentOutOfRangeException(nameof(startIndex));
            int endIndex = startIndex + count - 1;
            if (endIndex < 0 || endIndex >= this.size) throw new ArgumentOutOfRangeException(nameof(endIndex));
            if (match == null) throw new ArgumentNullException(nameof(match));

            for (int i = startIndex; i < endIndex; i++)
            {
                if (match.Invoke(this.items[i])) return i;
            }

            return -1;
        }

        public int FindLastIndex(Predicate<T> match) => this.FindIndex(0, this.size, match);

        public int FindLastIndex(int startIndex, Predicate<T> match) => this.FindIndex(startIndex, this.size - startIndex, match);

        public int FindLastIndex(int startIndex, int count, Predicate<T> match)
        {
            if (startIndex < 0 || startIndex >= this.size) throw new ArgumentOutOfRangeException(nameof(startIndex));
            int endIndex = startIndex + count - 1;
            if (endIndex < 0 || endIndex >= this.size) throw new ArgumentOutOfRangeException(nameof(endIndex));
            if (match == null) throw new ArgumentNullException(nameof(match));

            for (int i = endIndex; i >= startIndex; i--)
            {
                if (match.Invoke(this.items[i])) return i;
            }

            return -1;
        }

        public int IndexOf(T item, int startIndex, int count) => this.FindIndex(startIndex, count, arrayItem => arrayItem.Equals(item));

        public int IndexOf(T item, int startIndex) => this.IndexOf(item, startIndex, this.size);

        public int IndexOf(T item) => this.IndexOf(item, 0, this.size);

        public int LastIndexOf(T item, int startIndex, int count) => this.FindLastIndex(startIndex, count, arrayItem => arrayItem.Equals(item));

        public int LastIndexOf(T item, int startIndex) => this.LastIndexOf(item, startIndex, this.size);

        public int LastIndexOf(T item) => this.LastIndexOf(item, 0, this.size);

        public bool Remove(T item)
        {
            int index = this.IndexOf(item);

            if (index != -1)
            {
                this.RemoveAt(index);
                return true;
            }
            else
            {
                return false;
            }
        }

        public void RemoveAt(int index)
        {
            if (index < 0 || index >= this.size) throw new ArgumentOutOfRangeException(nameof(index));

            Array.Copy(this.items, index + 1, this.items, index, this.size - index);

            this.size--;
        }

        public T[] ToArray()
        {
            return this.items.Clone() as T[];
        }

        #region IEnumerable<T> Implementation
        public IEnumerator<T> GetEnumerator()
        {
            for (int i = 0; i < this.size; i++)
            {
                yield return this.items[i];
            }
        }

        IEnumerator IEnumerable.GetEnumerator()
        {
            return this.GetEnumerator();
        }
        #endregion IEnumerable<T> Implementation

        #region ICloneable
        public object Clone()
        {
            return this.MemberwiseClone();
        }
        #endregion ICloneable

        private void RecalculateCapacity(int newSize)
        {
            int currentCapacity = this.items.Length;
            if (currentCapacity >= newSize)
            {
                return;
            }

            int newCapacity = currentCapacity;
            while (newCapacity < newSize)
            {
                newCapacity *= 2;
            }

            this.Capacity = newCapacity;
        }
    }
}