using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public static class Extensions
{
    public static T[] DequeueMultiple<T>(this Queue<T> queue, int amount)
    {
        T[] values = new T[amount];
        for (int i = 0; i < amount; i++)
            values[i] = queue.Dequeue();
        return values;
    }

    public static void ShuffleList<T>(this IList<T> list)
    {
        int n = list.Count;

        System.Random rng = new System.Random();
        while (n > 1)
        {
            n--;
            int k = rng.Next(n + 1);
            T value = list[k];
            list[k] = list[n];
            list[n] = value;
        }
    }
}
