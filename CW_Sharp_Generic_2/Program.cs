using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Text;
using System.Threading.Tasks;

namespace CW_Sharp_Generic_2
{
    public class Matrix1x2D<T> where T : struct
    {
        T[,] _matr;


        public T[,] Matr
        {
            get
            {
                return _matr;
            }
            set
            {
                _matr = value;
            }
        }
        public Matrix1x2D()
        {
            _matr = new T[4, 4];
        }
        public Matrix1x2D(T[,] matr)
        {
            _matr = matr;
        }
        private static T Add(T a, T b)
        {
            dynamic da = a;
            dynamic db = b;
            return da + db;
        }

        public T this[int indx0, int indx1]
        {
            get
            {
                return _matr[indx0, indx1];
            }
            set
            {
                _matr[indx0, indx1] = value;
            }
        }

        public static Matrix1x2D<T> operator+(Matrix1x2D<T> matr0, Matrix1x2D<T> matr1)
        {
            int x = 0;
            int y = 0;
            if (matr0.Matr.GetLength(0) > matr1.Matr.GetLength(0))
            {
                x = matr0.Matr.GetLength(0);
            }
            else
            {
                x = matr1.Matr.GetLength(0);
            }
            if (matr0.Matr.GetLength(1) >  matr1.Matr.GetLength(1))
            {
                y = matr0.Matr.GetLength(1);
            }
            else
            {
                y = matr1.Matr.GetLength(1);
            }
            Matrix1x2D<T> temp = new Matrix1x2D<T>(new T[x, y]);
            for (int i = 0; i < x; i++)
            {
                for (int j = 0; j < y; j++)
                {
                    if (i < matr0.Matr.GetLength(0))
                    {
                        if (j < matr0.Matr.GetLength (1))
                        {
                            temp[i, j] = Add(temp[i, j], matr0[i, j]);
                        }
                    }
                    if (i < matr1.Matr.GetLength(0))
                    {
                        if (j < matr1.Matr.GetLength(1))
                        {
                            temp[i, j] = Add(temp[i, j], matr1[i, j]);
                        }
                    }
                }
            }
            return temp;
        }
        public override string ToString()
        {
            string ret = "";
            for (int i = 0; i < _matr.GetLength(0); i++)
            {
                for (int j = 0; j < _matr.GetLength(1); j++)
                {
                    ret += _matr[i, j] + ", ";
                }
                ret += "\n";
            }
            return ret;
        }

    }
    internal class Program
    {
        static void Main(string[] args)
        {
            int[,] test0 = new int[4, 4];
            int[,] test1 = new int[8, 8];
            for (int i = 0; i < 8; i++)
            {
                for (int j = 0; j < 8; j++)
                {
                    if (i < 4)
                    {
                        if (j < 4)
                        {
                            test0[i, j] = 1;
                        }
                    }
                    test1[i, j] = 1;
                }
            }
            Matrix1x2D<int> a = new Matrix1x2D<int>(test0);
            Matrix1x2D<int> b = new Matrix1x2D<int>(test1);
            Console.WriteLine(a + b);
        }
    }
}
