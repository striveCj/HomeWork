using System;
using System.Collections;
using System.Collections.Generic;
using System.Text;

namespace HomeWork_1.ListExtension
{
    public static class WhereExtension
    {
        public static List<T> JakeWhere<T>(this List<T> enumerable,Func<T,bool> func) {

            List<T> list = new List<T>();
            enumerable.ForEach(i =>
            {
                if (func.Invoke(i))
                {
                    list.Add(i);
                }
            });
            return list;
        }
    }
}
