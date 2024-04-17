using System;

class TestClass
{
    static void Main(string[] args)
    {
        int[] arr = { 2, 4, 6, 1, 1, 10, 15, 0, -2, -10 };
        arr = quickSort(arr, 0, arr.Length - 1);
        Console.WriteLine(string.Join(", ", arr));
    }

    private static int[] quickSort(int[] arr, int start, int end)
    {
        if (start < end)
        {
            int ind = part(arr, start, end);

            quickSort(arr, start, ind - 1);
            quickSort(arr, ind + 1, end);
        }

        return arr;
    }

    private static int part(int[] arr, int start, int end)
    {
        int elem = arr[end];
        int bound = start - 1;

        for (int i = start; i < end; i++)
        {
            if (arr[i] < elem)
            {
                bound++;
                (arr[bound], arr[i]) = (arr[i], arr[bound]);
            }
        }

        (arr[bound + 1], arr[end]) = (arr[end], arr[bound + 1]);
        return bound + 1;
    }
}