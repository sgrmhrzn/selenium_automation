using System;
using System.Threading;

namespace SeleniumDotNet
{
    public class Program
    {
        private static void Main(string[] args)
        {
            //for (int i = 0; i < 3; i++)
            //{
                SeleniumTest seleniumTest = new SeleniumTest();

                seleniumTest.SetupTest();

                seleniumTest.TheBingSearchTest();

                seleniumTest.MyTestCleanup();

                Thread.Sleep(1000);

            Console.ReadLine();
            //}
        }
    }
}
