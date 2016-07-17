using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConsoleApplication1
{
    class Program
    {
        static void Main(string[] args)
        {
            #region 

////看到这个屏幕的同学请在群里跟我发消息,谢谢
            //Print(0);

            //Console.WriteLine("hello world");

            #endregion

            for (int i = 1; i < 10; i++)
            {
                for (int j = 1; j < i; j++)
                {
                    Console.Write("{0}*{1}={2}\t",j,i,i*j);
                }
                Console.Write("\n");
            }
            
        }


        //static void Print(int i)
        //{
        //    Console.WriteLine(i);
        //    if(i<3)
        //    {
        //        Print(++i);
        //    }
        //    Console.WriteLine(i);
        //}
    }
}
