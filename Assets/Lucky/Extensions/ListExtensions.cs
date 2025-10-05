using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using Random = UnityEngine.Random;

namespace Lucky.Extensions
{
    public static class ListExtensions
    {
        public static T Choice<T>(this List<T> lst)
        {
            return lst[Random.Range(0, lst.Count)];
        }

        public static void Shuffle<T>(this List<T> lst)
        {
            for (int i = 0; i < lst.Count - 1; i++)
            {
                int j = Random.Range(i, lst.Count);
                (lst[i], lst[j]) = (lst[j], lst[i]);
            }
        }

        // public static void Extend<T>(this List<T> lst, List<T> newList)
        // {
        //     foreach (var item in newList)
        //     {
        //         lst.Add(item);
        //     }
        // }

        public static T Pop<T>(this List<T> lst, int idx = -1)
        {
            if (idx < 0)
                idx = lst.Count + idx;
            T retval = lst[idx];
            lst.RemoveAt(idx);
            return retval;
        }

        public static T ClosestValue<T>(this List<T> lst, Func<T, float> getter, T defaultValue)
        {
            if (lst.Count == 0)
                return defaultValue;
            T res = lst[0];
            for (int i = 1; i < lst.Count; i++)
            {
                if (getter(lst[i]) < getter(res))
                    res = lst[i];
            }

            return res;
        }


        public static string ToReadableString(this IList lst, int tables = 0, bool withCounts = true)
        {
            string res = "";
            if (withCounts)
                res += $"{new string('\t', tables)}Count={lst.Count}\n";
            res += $"{new string('\t', tables + 1)}[\n  {string.Join(", \n  ", lst.Cast<object>().Select(item => item.ToString()))}\n]";
            return res;
            ;
        }
    }
}