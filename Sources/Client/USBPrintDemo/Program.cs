using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using Softland.Tools;

namespace USBPrintDemo
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine(
                USBPrinterHelper.SendFileToPrinter(
                    "HP Deskjet Ink Adv 2010 K010",
                    @"C:\Users\Hanklee\source\repos\Hanklee0518\IRAP.Winform\Sources\Client\USBPrintDemo\USBPrintHelper.cs"));
        }
    }
}
