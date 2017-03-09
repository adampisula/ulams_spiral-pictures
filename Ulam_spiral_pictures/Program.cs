using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Data;
using System.Threading.Tasks;
using System.Drawing;
using System.Drawing.Imaging;

namespace Ulam_spiral_pictures
{
    class Program
    {
        static int size;
        static int times;

        static void Main(string[] args)
        {
            size = Convert.ToInt32(Console.ReadLine());
            int x = 0;
            int y = 0;
            Color coln = Color.White;
            Color colp = Color.Black;

            Bitmap bmp = new Bitmap(size + 1, size + 1);

            if (size % 2 == 0)
            {
                x = bmp.Size.Width / 2;
                y = bmp.Size.Height / 2;
            }
            else if (size % 2 != 0)
            {
                x = (bmp.Size.Width + 1) / 2;
                y = (bmp.Size.Height + 1) / 2;
            }

            bmp.SetPixel(x, y, coln);

            bool ru = false;
            times = 1;

            //write_progress(times);

            for (int i = 1; i < size; i++)
            {
                if (ru == true)
                {
                    for (int j = 0; j < i; j++)
                    {
                        x -= 1;
                        times++;
                        if (Calc.Prime(times) == true)
                            bmp.SetPixel(x, y, colp);
                        else
                            bmp.SetPixel(x, y, coln);
                        //write_progress(times);
                    }

                    for (int k = 0; k < i; k++)
                    {
                        y += 1;
                        times++;
                        if (Calc.Prime(times) == true)
                            bmp.SetPixel(x, y, colp);
                        else
                            bmp.SetPixel(x, y, coln);
                        //write_progress(times);
                    }

                    ru = false;
                }
                else
                {
                    for (int j = 0; j < i; j++)
                    {
                        x += 1;
                        times++;
                        if (Calc.Prime(times) == true)
                            bmp.SetPixel(x, y, colp);
                        else
                            bmp.SetPixel(x, y, coln);
                        //write_progress(times);
                    }

                    for (int k = 0; k < i; k++)
                    {
                        y -= 1;
                        times++;
                        if (Calc.Prime(times) == true)
                            bmp.SetPixel(x, y, colp);
                        else
                            bmp.SetPixel(x, y, coln);
                        //write_progress(times);
                    }

                    ru = true;
                }
            }
            if (size % 2 != 0)
            {
                for (int i = 0; i < size - 1; i++)
                {
                    x += 1;
                    times++;
                    if (Calc.Prime(times) == true)
                        bmp.SetPixel(x, y, colp);
                    else
                        bmp.SetPixel(x, y, coln);
                    //write_progress(times);
                }
            }
            else
            {
                for (int i = 0; i < size - 1; i++)
                {
                    x -= 1;
                    times++;
                    if (Calc.Prime(times) == true)
                        bmp.SetPixel(x, y, colp);
                    else
                        bmp.SetPixel(x, y, coln);
                    //write_progress(times);
                }
            }

            bmp.Save("ulam_spiral_" + DateTime.Now.Day.ToString() + '-' + DateTime.Now.Month.ToString() + '-' + DateTime.Now.Year.ToString() + '_' + DateTime.Now.Hour.ToString() + '-' + DateTime.Now.Minute.ToString() + '-' + DateTime.Now.Second.ToString() + ".png", ImageFormat.Png);
        }

        static void write_progress(int times)
        {
            Console.Clear();
            Console.WriteLine(times.ToString() + '/' + (size * size).ToString());
            Console.WriteLine((times / size * 100).ToString() + '%');
        }
    }
    class Calc
    {
        public static bool Prime(decimal a)
        {
            if (a == 2)
                return true;

            bool p = false;
            decimal n = 0;
            int x = 0;

            if (a % 2 != 0)
            {
                n = (a + 1) / 2;
            }
            else
            {
                return false;
            }

            for (decimal i = 2; i < n + 1; i++)
            {
                x = Convert.ToInt32(a % i);

                if (x == 0)
                {
                    p = false;
                    break;
                }
                else
                {
                    p = true;
                    continue;
                }
            }

            return p;
        }

        public static bool Perfect(decimal a)
        {
            List<decimal> dividors = new List<decimal>();
            decimal sum = 0;

            if (a % 2 == 0)
            {
                for (int i = 1; i < a / 2 + 1; i++)
                {
                    if (a % i == 0)
                    {
                        dividors.Add(i);
                    }
                    else
                    {
                        continue;
                    }
                }

                for (int j = 0; j < dividors.Count; j++)
                {
                    sum += dividors[j];
                }

                dividors.Clear();

                if (sum == a)
                {
                    return true;
                }
                else
                {
                    return false;
                }
            }
            else
            {
                return false;
            }
        }

        public static decimal Factorial(decimal a)
        {
            if (a <= 0)
                return 1;
            return a * Factorial(a - 1);
        }

        public static decimal Power(decimal a, decimal b)
        {
            decimal result = 1;

            for (int i = 0; i < b; i++)
                result *= a;

            return result;
        }
    }

}

