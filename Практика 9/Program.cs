using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Практика_9
{
    class Point
    {
        public int data;
        public Point next, pred;
        public Point()
        {
            data = 0;
            next = null;
            pred = null;
        }
        public Point(int d)
        {
            data = d;
            next = null;
            pred = null;
        }
        public override string ToString()
        {
            return data + " ";
        }
    }
    class Program
    {
        static Point MakePoint(int d)
        {
            Point p = new Point(d);
            return p;
        }
        static Point MakeList(int size) //добавление в начало
        {
            Random rnd = new Random();
            int info = rnd.Next(-11, 11);
            Console.WriteLine("The element {0} is adding...",
            info);
            Point beg = MakePoint(info);
            for (int i = 1; i < size; i++)
            {
                info = rnd.Next(-11, 11);
                Console.WriteLine("The element {0} isadding...", info);
                Point p = MakePoint(info);
                p.next = beg;
                beg.pred = p;
                beg = p;
            }
            return beg;
        }
        static void ShowList(Point beg)
        {
            if (beg == null)
            {
                Console.WriteLine("The List is empty");
                return;
            }
            Point p = beg;
            while (p != null)
            {
                Console.Write(p);
                p = p.next;
            }
            Console.WriteLine();
        }
        static void poisk(Point beg, out int min, out int max)
        {
            max = 0;
            min = 0;
            //проверка наличия элементов в списке
            if (beg == null)
            {
                Console.WriteLine("The List is empty");
            }
            Point p = beg;
            while (p != null)
            {
                if (p.data < 0) max = max + p.data;
                if (p.data > 0) min = min + p.data;
                p = p.next;//переход к следующему элементу
            }
            Console.WriteLine("Сумма отицательных элементов="+max);
            Console.WriteLine("Сумма положительных элементоа="+min);
        }

        static Point AddPoint(Point beg, int number)
        {
            Random rnd = new Random();
            int info = rnd.Next(10, 100);
            Console.WriteLine("The element {0} is adding...", info);
            Point NewPoint = MakePoint(info);
            if (beg == null)//список пустой
            {
                beg = MakePoint(rnd.Next(10, 100));
                return beg;
            }
            if (number == 1) //добавление в начало списка
            {
                NewPoint.next = beg;
                beg.pred = NewPoint;
                beg = NewPoint;
                return beg;
            }
            Point p = beg;
            for (int i = 1; i < number - 1 && p != null; i++) p = p.next;
            if (p == null)
            {
                Console.WriteLine("Error! The size of List less than Number");
                return beg;
            }

            NewPoint.next = p.next;
            NewPoint.pred = p;
            p.next = NewPoint;
            if (NewPoint.next != null)//не последний
                NewPoint.next.pred = NewPoint;
            return beg;
        }

        static void Main(string[] args)
        {
            //Создаю список 
            
                bool ok = false;
                int size = 0;
                Point beg = null;
                Console.WriteLine("Введите количество элемнтов списка");
                do
                {
                    ok = Int32.TryParse(Console.ReadLine(),out  size);
                } while (!ok);
                beg = MakeList(size);
                ShowList(beg);
            poisk(beg, out int min, out int max);
            Console.Read();
            

        }
    }
}
