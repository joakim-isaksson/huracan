using System.Collections.Generic;
using UnityEngine;

namespace Util
{
    public class ListUtils
    {
        /// <summary>
        /// Shuffle given list using Fisher–Yates algorithm
        /// </summary>
        /// <param name="list">List to be shuffled</param>
        public static void Shuffle<T>(IList<T> list)
        {
            var n = list.Count;
            while (n > 1)
            {
                n--;
                var k = Random.Range(0, n + 1);
                var value = list[k];
                list[k] = list[n];
                list[n] = value;
            }
        }
    }
}