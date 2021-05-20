using System;
using System.Collections.Generic;

namespace TicketsSearch.Extensions
{
    public class MultiKeyDictionary<TValue> : Dictionary<Tuple<string, string>, TValue>, IDictionary<Tuple<string, string>, TValue>
    {
        public TValue this[string type, string key]
        {
            get {
                return base[Tuple.Create(type, key)];
            }
            set {
                base[Tuple.Create(type, key)] = value;
            }
        }

        public void Add(string type, string key, TValue value)
        {
            base.Add(Tuple.Create(type, key), value);
        }

    }
}
