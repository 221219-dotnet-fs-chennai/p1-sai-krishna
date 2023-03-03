using System.CodeDom.Compiler;
using System.Collections.Generic;
using System.Collections;
using System.ComponentModel;
using System.Diagnostics.CodeAnalysis;
using System.Globalization;
using System.IO;
using System.Linq;
using System.Reflection;
using System.Runtime.Serialization;
using System.Text.RegularExpressions;
using System.Text;
using System;
using System.Diagnostics.Contracts;
using System.Xml.Serialization;

class Result
{
    public static void MergeArrays(int[] A,int n,int[] B,int m)
    {
        int[] c = new int[m + n];

        for(int i = 0; i <n; i++)
        {
            c[i] = A[i];
        }
        for (int i = 0; i < m; i++)
        {
            c[i+n] = B[i];
        }
        for (int i = 0; i < n+m; i++)
        {
            Console.WriteLine(c[i]);
        }
    }

    public static void removeDuplicates(int[] A, int n)
    {
        Dictionary<int, int> count = new Dictionary<int, int>();
        foreach (int ele in A)
        {
            if (count.ContainsKey(ele))
            {
                count[ele]++;
            }
            else
            {
                count.Add(ele, 1);
            }
        }
        int[] newArray = new int[count.Count];
        int i = 0;
        foreach (var d in count)
        {
            newArray[i] = d.Key;
            i++;
        }

        foreach (int ele in newArray)
        {
            Console.WriteLine(ele);
        }
    }
    public static void frequency(int N,int[] A)
    {
        Dictionary<int, int> count = new Dictionary<int, int>();
        foreach (int ele in A)
        {
            if (count.ContainsKey(ele))
            {
                count[ele]++;
            }
            else
            {
                count.Add(ele, 1);
            }
        }
        foreach(KeyValuePair<int,int> d in count)
        {
            Console.WriteLine($"element {d.Key} : {d.Value}");
        }
    }
    public static void addTwoElements(int N, int[] A, int X)
    {
        for(int i = 0; i < N; i++)
        {
            for(int j = 0; j < N; j++)
            {
                if (i != j)
                {
                    if (A[i] + A[j] == X)
                    {
                        Console.WriteLine($"[{i},{j}]");
                    }
                }
            }
        }
    }

    public  static void minMax(int N, int[] A)
    {
        int min = int.MaxValue;
        int max = int.MinValue;
        for(int i = 0; i < N; i++)
        {
            if (A[i] > max)
            {
                max = A[i];
            }
            else if (A[i] < min)
            {
                min = A[i];
            }
            else
            {
                continue;
            }
        }
        Console.WriteLine($"Maximum:{max}  Minimum:{min}");
    }

    public static void searchIndex(int N, int[] A, int X)
    {
        for(int i=0;i<N;i++)
        {
            if (A[i] == X)
            {
                Console.WriteLine(i);
                return;
            }
        }
        for(int i=0;i<N-1; i++)
        {
            if (A[i+1]>X && A[i]<X)
            {
                Console.WriteLine(i+1);
            }
        }
    }
    public static void thirdlargest(int n, int[] A)
    {
        Array.Sort(A);
        Console.WriteLine(A[n-3]);

    }

    public static void rotateArray(int n, int[] A,int d)
    {

        for (int j = 0; j < d; j++)
        {
            int temp = A[0];
            for (int i = 1; i < n; i++)
            {
                A[i - 1] = A[i];
            }
            A[n - 1] = temp;

          
        }

        foreach (int ele in A)
        {
            Console.Write($"{ele}  ");
        }

    }

    public static void maxProduct(int n, int[] A)
    {
        int max = int.MinValue;
        int a=0, b=0, c = 0;
        for(int i = 0; i < n; i++)
        {
            for(int j = i+1; j < n; j++)
            {
                for(int k =j+1; k < n; k++)
                {
                    if ((A[i] * A[j] * A[k]) > max)
                    {
                        max = A[i] * A[j] * A[k];
                        a = A[i];
                        b = A[j];
                        c = A[k];
                    }
                }
            }
        }
        Console.WriteLine($"[{a},{b},{c}]");
    }

}

class Solution
{
    public static void Main(string[] args)
    {
        
       
        Console.WriteLine("Enter length of Array A");
        int n=Convert.ToInt32( Console.ReadLine());
        int[] A = new int[n];
        Console.WriteLine("Enter the Elemennts");
        for (int i = 0; i < n; i++)
        {
            A[i]= Convert.ToInt32(Console.ReadLine());
        }

        //Console.WriteLine("Enter length of Array B");
        //int m = Convert.ToInt32(Console.ReadLine());
        //int[] B = new int[n];
        //Console.WriteLine("Enter the Elemennts");
        //for (int i = 0; i < m; i++)
        //{
        //    B[i] = Convert.ToInt32(Console.ReadLine());
        //}

        //Result.MergeArrays(A, n, B, m);
        //Result.removeDuplicates(A, n);
        //Result.frequency(n, A);

        //Console.Write("Enter the target :");
        //int X = Convert.ToInt32(Console.ReadLine());
        //Result.addTwoElements(n, A, X);

        //Result.minMax(n, A);

        //Console.Write("Enter the target :");
        //int X1 = Convert.ToInt32(Console.ReadLine());
        //Result.searchIndex(n, A, X1);

        //Result.thirdlargest(n, A);

        //Console.Write("Enter the target :");
        //int d = Convert.ToInt32(Console.ReadLine());
        //Result.rotateArray(n, A, d);

        //Result.maxProduct(n, A);
    }


}
