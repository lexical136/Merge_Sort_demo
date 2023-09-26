using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace merge_sort_demo
{
    internal class Program
    {
        static void Main(string[] args)
        {
            List<int> ar1 = new List<int> { -45, 72, -86, 16, -3, -98, -66, 90, -88, 57, 45, -84, -29, -12, -72, -95, -51, 73, 87, 4, 18, 68, -38, -60, 93, -91, -71, 30, 98, -10, -40, -35, -33, -19, -54, 47, -31, 77, -81, -85, 100, -46, -92, 22, 1, -20, -65, 89, 62, -44, -76, 11, -94, -74, 82, 8, 63, -17, 48, 81, -59, 25, -70, 37, -97, -100, 19, -64, -26, -27, -25, 71, 42, -73, 61, 69, -80, 58, -6, 26, -34, -47, 32, 29, 56, 86, -78, -39, 64, 2, -58, -69, -82, 3, -5, 91, -15, 53, 20, -7 };
            List<int> ar2 = mergeSplit(ar1);

            for (int i = 0; i < ar2.Count; i++)
            {
                Console.WriteLine(ar2[i]);
            }
        }

        static List<int> mergeSplit(List<int> inputAr)
        {
            if (inputAr.Count == 1)
            {
                return inputAr;
            }
            float mid = (float)inputAr.Count / 2;


            //Left List
            List<int> leftAr = new List<int>();
            leftAr = inputAr.GetRange(0, (int)Math.Floor(mid));

            //Right List
            List<int> rightAr = new List<int>();
            if (inputAr.Count % 2 == 0)
            {
                rightAr = inputAr.GetRange((int)Math.Ceiling(mid), (int)Math.Ceiling(mid));
            }
            else
            {
                rightAr = inputAr.GetRange((int)Math.Ceiling(mid) - 1, (int)Math.Ceiling(mid));
            }


            inputAr = mergeSort(mergeSplit(leftAr), mergeSplit(rightAr));
            //leftAr.AddRange(rightAr);

            return inputAr;
        }


        //Sorts 2 sorted arrays
        static List<int> mergeSort(List<int> x, List<int> y)
        {
            List<int> result = new List<int>();
            int index1 = 0;
            int index2 = 0;

            while (index1 < x.Count && index2 < y.Count)
            {
                if (index2 < y.Count && x[index1] > y[index2])
                {
                    result.Add(y[index2]);
                    index2++;
                }
                else
                {
                    result.Add(x[index1]);
                    index1++;
                }
            }

            //Add rest of x
            if (index1 != x.Count)
            {
                while (index1 < x.Count)
                {
                    result.Add(x[index1]);
                    index1++;
                }
            }
            //Add rest of y
            else
            {
                while (index2 < y.Count)
                {
                    result.Add(y[index2]);
                    index2++;
                }
            }

            return result;
        }
    }
}





