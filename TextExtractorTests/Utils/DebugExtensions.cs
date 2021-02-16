using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace TextExtractorTests.Utils
{
    public static class DebugExtensions
    {
        public static string ToDebugString<TKey, TValue>(this IDictionary<TKey, TValue> dictionary)
        {
            return "{" + string.Join(",", dictionary.Select(kv => kv.Key + "=" + ValueToDebugString(kv.Value) ).ToArray()) + "}";
        }

        public static string ValueToDebugString(object value)
        {
            return (value is IEnumerable<string>) ? string.Join(" - ", (IEnumerable<string>)value) : value.ToString();
        }
    }
}
