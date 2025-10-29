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

class Result
{

    /*
     * Complete the 'missingNumbers' function below.
     *
     * The function is expected to return an INTEGER_ARRAY.
     * The function accepts following parameters:
     *  1. INTEGER_ARRAY arr
     *  2. INTEGER_ARRAY brr
     */

    public static List<int> missingNumbers(List<int> arr, List<int> brr)
    {
        Dictionary<int, int> freqArr = new Dictionary<int, int>();
        Dictionary<int, int> freqBrr = new Dictionary<int, int>();
    
    foreach (int num in arr)
    {
        if (freqArr.ContainsKey(num))
            freqArr[num]++;
        else
            freqArr[num] = 1;
    }
    
    foreach (int num in brr)
    {
        if (freqBrr.ContainsKey(num))
            freqBrr[num]++;
        else
            freqBrr[num] = 1;
    }
    
    List<int> missing = new List<int>();
    
    foreach (var kvp in freqBrr)
    {
        int num = kvp.Key;
        int countInBrr = kvp.Value;
        
        if (!freqArr.ContainsKey(num) || freqArr[num] < countInBrr)
        {
            missing.Add(num);
        }
    }
    
    missing.Sort();
    return missing;

    }

}

class Solution
{
    public static void Main(string[] args)
    {
        TextWriter textWriter = new StreamWriter(@System.Environment.GetEnvironmentVariable("OUTPUT_PATH"), true);

        int n = Convert.ToInt32(Console.ReadLine().Trim());

        List<int> arr = Console.ReadLine().TrimEnd().Split(' ').ToList().Select(arrTemp => Convert.ToInt32(arrTemp)).ToList();

        int m = Convert.ToInt32(Console.ReadLine().Trim());

        List<int> brr = Console.ReadLine().TrimEnd().Split(' ').ToList().Select(brrTemp => Convert.ToInt32(brrTemp)).ToList();

        List<int> result = Result.missingNumbers(arr, brr);

        textWriter.WriteLine(String.Join(" ", result));

        textWriter.Flush();
        textWriter.Close();
    }
}
