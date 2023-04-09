using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TaoMap
{
    internal class Program
    {
        static void Main(string[] args)
        {
            string[,] map = {
            {"*", ".", ".", "."},
            {".", ".", ".", "."},
            {".", "*", ".", "."},
            {".", ".", ".", "."}
            };
            int hang=map.GetLength(0);
            int cot=map.GetLength(1);
            string[,] mapAo = new string[hang,cot];
            for (int y = 0; y < hang; y++)
            {
                for(int x = 0; x < cot; x++)
                {
                    string giatri = map[y,x];
                    if (giatri.Equals("*"))
                    {
                        mapAo[y, x] = "*";
                    }
                    else
                    {
                        int[,] mapnho = {{ y - 1, x - 1 }, { y - 1, x}, { y - 1, x + 1},
                        { y, x - 1}, { y, x + 1},
                        { y + 1, x - 1}, { y + 1, x}, { y + 1, x + 1} };
                        int min = 0;
                        int length = mapnho.GetLength(0);
                        for (int i = 0; i < length; i++)
                        {
                            int xnho = mapnho[i, 1];
                            int ynho = mapnho[i, 0];
                            bool ktmap = xnho < 0
                                    || xnho == cot
                                    || ynho < 0
                                    || ynho == hang;
                            if (ktmap)
                            {
                                continue;
                            }
                            bool ktmin = map[ynho, xnho].Equals("*");
                            if (ktmin)
                            {
                                min++;
                            }
                        }
                        mapAo[y, x] = min.ToString();
                    }
                }
            }
            for (int y= 0; y < hang; y++)
            {
                Console.WriteLine("\n");
                for (int x = 0; x < cot; x++)
                {
                    String soMin = mapAo[y, x];
                    Console.Write(soMin);
                }
            }
            Console.ReadLine();
            
        }
    }
}
