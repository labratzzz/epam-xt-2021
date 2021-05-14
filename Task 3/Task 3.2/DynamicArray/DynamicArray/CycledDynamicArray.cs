namespace MyCollections
{
    using System.Collections;
    using System.Collections.Generic;

    public class CycledDynamicArray<T> : DynamicArray<T>, IEnumerable<T>
    {
        // Constructors
        public CycledDynamicArray() : base() { }

        public CycledDynamicArray(int capacity) : base(capacity) { }

        public CycledDynamicArray(IEnumerable<T> collection) : base(collection) { }

        #region IEnumerable<T> Implementation
        public override IEnumerator<T> GetEnumerator()
        {
            int i = 0;

            while (true)
            {
                if (i == this.size)
                {
                    i = 0;
                }

                yield return this.items[i++];
            }
        }

        IEnumerator IEnumerable.GetEnumerator()
        {
            return this.GetEnumerator();
        }
        #endregion IEnumerable<T> Implementation
    }
}