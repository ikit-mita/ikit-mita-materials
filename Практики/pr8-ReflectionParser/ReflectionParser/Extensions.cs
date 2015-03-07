using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ReflectionParser
{
    public static class Extensions
    {
        public static void MinMax<T>(this IEnumerable<T> source, out T min, out T max) 
            where T : IComparable<T>
        {
            min = source.First();
            max = source.First();



            foreach (var item in source)
            {
                if(item.CompareTo(min) < 0)
                {
                    min = item;
                }
                if (item.CompareTo(max) > 0)
                {
                    max = item;
                }
            }
        }
    }
}
