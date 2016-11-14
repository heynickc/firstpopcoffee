using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;

namespace FirstPopCoffee.Common.Domain.Model {

    // https://github.com/tpierrain/Value
    /// <summary>
    ///     Base class for any Value Type (i.e. the 'Value Object' oxymoron of DDD).
    ///     All you have to do is to implement the abstract methods: <see cref="EquatableByValue{T}.GetAllAttributesToBeUsedForEquality"/>
    /// </summary>
    /// <typeparam name="T">Domain type to be 'turned' into a Value Type.</typeparam>
    public abstract class ValueObject<T> : EquatableByValue<T> where T : class {
    }

    /// <summary>
    /// Support a by-Value Equality and Unicity.
    /// </summary>
    /// <remarks>This latest implementation has been inspired from Scott Millett's book (Patterns, Principles, and Practices of Domain-Driven Design).</remarks>
    /// <typeparam name="T"></typeparam>
    public abstract class EquatableByValue<T> : IEquatable<T> where T : class {
        private const int undefined = -1;

        private volatile int hashCode = undefined;

        public static bool operator ==(EquatableByValue<T> x, EquatableByValue<T> y) {
            if (ReferenceEquals(x, null) && ReferenceEquals(y, null)) {
                return true;
            }

            if (ReferenceEquals(x, null) || ReferenceEquals(y, null)) {
                return false;
            }

            return x.Equals(y);
        }

        public static bool operator !=(EquatableByValue<T> x, EquatableByValue<T> y) {
            return !(x == y);
        }

        public bool Equals(T other) {
            var otherEquatable = other as EquatableByValue<T>;
            if (otherEquatable == null) {
                return false;
            }

            return this.GetAllAttributesToBeUsedForEquality().SequenceEqual(otherEquatable.GetAllAttributesToBeUsedForEquality());
        }

        public override bool Equals(object obj) {
            if (obj == null) {
                return false;
            }

            var other = obj as T;

            if (ReferenceEquals(other, null)) {
                return false;
            }

            return this.Equals(other);
        }

        public override int GetHashCode() {
            return this.GetHashCodeImpl();
        }

        protected abstract IEnumerable<object> GetAllAttributesToBeUsedForEquality();

        protected virtual void ResetHashCode() {
            this.hashCode = undefined;
        }

        private int GetHashCodeImpl() {
            if (this.hashCode == undefined) {
                var code = 0;

                foreach (var attribute in this.GetAllAttributesToBeUsedForEquality()) {
                    code = (code * 397) ^ (attribute == null ? 0 : attribute.GetHashCode());
                }

                this.hashCode = code;
            }

            return this.hashCode;
        }
    }

    /// <summary>
    ///     A list with equality based on its content and not on the list's reference 
    ///     (i.e.: 2 different instances containing the same items in the same order will be equals).
    /// </summary>
    /// <remarks>This type is not thread-safe (for hashcode updates).</remarks>
    /// <typeparam name="T">Type of the listed items.</typeparam>
    public class ListByValue<T> : EquatableByValue<ListByValue<T>>, IList<T> {
        private readonly IList<T> list;

        public ListByValue() : this(new List<T>()) {
        }

        public ListByValue(IList<T> list) {
            this.list = list;
        }

        public int Count => this.list.Count;

        public bool IsReadOnly => ((ICollection<T>) this.list).IsReadOnly;

        public T this[int index] {
            get { return this.list[index]; }
            set {
                this.ResetHashCode();
                this.list[index] = value;
            }
        }

        public void Add(T item) {
            this.ResetHashCode();
            this.list.Add(item);
        }

        public void Clear() {
            this.ResetHashCode();
            this.list.Clear();
        }

        public bool Contains(T item) {
            return this.list.Contains(item);
        }

        public void CopyTo(T[] array, int arrayIndex) {
            this.list.CopyTo(array, arrayIndex);
        }

        public IEnumerator<T> GetEnumerator() {
            return this.list.GetEnumerator();
        }

        public int IndexOf(T item) {
            return this.list.IndexOf(item);
        }

        public void Insert(int index, T item) {
            this.ResetHashCode();
            this.list.Insert(index, item);
        }

        public bool Remove(T item) {
            this.ResetHashCode();
            return this.list.Remove(item);
        }

        public void RemoveAt(int index) {
            this.ResetHashCode();
            this.list.RemoveAt(index);
        }

        IEnumerator IEnumerable.GetEnumerator() {
            return ((IEnumerable) this.list).GetEnumerator();
        }

        protected override IEnumerable<object> GetAllAttributesToBeUsedForEquality() {
            return (IEnumerable<object>) this.list;
        }
    }

    /// <summary>
    ///     A Set with equality based on its content and not on the Set's reference 
    ///     (i.e.: 2 different instances containing the same items will be equals whatever their storage order).
    /// </summary>
    /// <remarks>This type is not thread-safe (for hashcode updates).</remarks>
    /// <typeparam name="T">Type of the listed items.</typeparam>
    public class SetByValue<T> : ISet<T> {
        private readonly ISet<T> hashSet;

        private int? hashCode;

        public SetByValue(ISet<T> hashSet) {
            this.hashSet = hashSet;
        }

        public SetByValue() : this(new HashSet<T>()) {
        }

        public int Count => this.hashSet.Count;

        public bool IsReadOnly => this.hashSet.IsReadOnly;

        public void Add(T item) {
            this.ResetHashCode();
            this.hashSet.Add(item);
        }

        public void Clear() {
            this.ResetHashCode();
            this.hashSet.Clear();
        }

        public bool Contains(T item) {
            return this.hashSet.Contains(item);
        }

        public void CopyTo(T[] array, int arrayIndex) {
            this.hashSet.CopyTo(array, arrayIndex);
        }

        public override bool Equals(object obj) {
            var other = obj as SetByValue<T>;
            if (other == null) {
                return false;
            }

            return this.hashSet.SetEquals(other);
        }

        public void ExceptWith(IEnumerable<T> other) {
            this.ResetHashCode();
            this.hashSet.ExceptWith(other);
        }

        public IEnumerator<T> GetEnumerator() {
            return this.hashSet.GetEnumerator();
        }

        public override int GetHashCode() {
            if (this.hashCode == null) {
                var code = 0;

                // Two instances with same elements added in different order must return the same hashcode
                // Let's compute and sort hashcodes of all elements (always in the same order)
                var sortedHashCodes = new SortedSet<int>();
                foreach (var element in this.hashSet) {
                    sortedHashCodes.Add(element.GetHashCode());
                }

                foreach (var elementHashCode in sortedHashCodes) {
                    code = (code * 397) ^ elementHashCode;
                }

                // Cache the result in a field
                this.hashCode = code;
            }

            return this.hashCode.Value;
        }

        public void IntersectWith(IEnumerable<T> other) {
            this.ResetHashCode();
            this.hashSet.IntersectWith(other);
        }

        public bool IsProperSubsetOf(IEnumerable<T> other) {
            return this.hashSet.IsProperSubsetOf(other);
        }

        public bool IsProperSupersetOf(IEnumerable<T> other) {
            return this.hashSet.IsProperSupersetOf(other);
        }

        public bool IsSubsetOf(IEnumerable<T> other) {
            return this.hashSet.IsSubsetOf(other);
        }

        public bool IsSupersetOf(IEnumerable<T> other) {
            return this.hashSet.IsSupersetOf(other);
        }

        public bool Overlaps(IEnumerable<T> other) {
            return this.hashSet.Overlaps(other);
        }

        public bool Remove(T item) {
            this.ResetHashCode();
            return this.hashSet.Remove(item);
        }

        public bool SetEquals(IEnumerable<T> other) {
            return this.hashSet.SetEquals(other);
        }

        public void SymmetricExceptWith(IEnumerable<T> other) {
            this.ResetHashCode();
            this.hashSet.SymmetricExceptWith(other);
        }

        public void UnionWith(IEnumerable<T> other) {
            this.ResetHashCode();
            this.hashSet.UnionWith(other);
        }

        bool ISet<T>.Add(T item) {
            this.ResetHashCode();
            return this.hashSet.Add(item);
        }

        IEnumerator IEnumerable.GetEnumerator() {
            return ((IEnumerable) this.hashSet).GetEnumerator();
        }

        protected virtual void ResetHashCode() {
            this.hashCode = null;
        }
    }
}
