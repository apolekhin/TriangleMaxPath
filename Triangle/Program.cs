using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Triangle
{
    class Program
    {

        static void Main(string[] args)
        {
            Console.WriteLine("Enter a path to txt file:");
            string path = Console.ReadLine();
            
            Console.WriteLine("Reading from: " + path);
            try
            {
                if (new System.IO.FileInfo(path).Length != 0)
                {
                    List<List<int>> arr = TxtToList(path);
                    Triangle.CalculatePath(arr);
                }
                else
                {
                    Console.WriteLine("File is empty");
                    Console.ReadLine();
                }
            }
            catch (System.IO.FileNotFoundException ex)
            {
                Console.WriteLine(ex.Message);
                Console.ReadLine();
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
                Console.ReadLine();
            }
        }

        public class Triangle
        {
            
            public static void CalculatePath(List<List<int>> arr)
            {
                /*Goes up from penultimate line, 
                 *replacing current cell with the max sum with its adjacent cells */
                int height = arr.Count;

                if (IsIsosceles(arr) && height > 1)
                {
                    for (int i = height - 2; i >= 0; i--)
                    {
                        for (int j = 0; j <= i; j++)
                        {
                            arr[i][j] += System.Math.Max(arr[i + 1][j], arr[i + 1][j + 1]);
                        }
                    }
                    Console.WriteLine("\nThe max sum path is: " + arr[0][0]);
                }
                else if (height == 1)
                {
                    Console.WriteLine("\nTriangle has only one number. The max sum path is: " + arr[0][0]);
                }
                else
                {
                    Console.WriteLine("The triangle is not suitable for this test");
                }
                Console.ReadLine();
            }

            public static bool IsIsosceles(List<List<int>> arr)
            {
                /*Checks, whether the triangle has appropriate shape.
                 *Line number must be equal to the ammount of values in it.*/
                int height = arr.Count;
                bool flag = true;

                for (int i = 0; i < height; i++)
                {
                    if (arr[i].Count != i + 1)
                    {
                        flag = false;
                        break;
                    }
                }
                return flag;
            }

        }

        public static List<List<int>> TxtToList( string path )
        {
            /*Reads txt file and populates list from it*/
            string[] input = System.IO.File.ReadAllLines(path);
            List<List<int>> triangle = new List<List<int>>();

            foreach (string line in input)
            {
                string[] values = line.Split(' ');
                int[] convertedItems = Array.ConvertAll<string, int>(values, int.Parse);
                triangle.Add(new List<int>(convertedItems));
            };
            return triangle;
        }

    }
}
