using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SprintHuating
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("Bitte geben Sie den Wert des Moduls m ein:");
            double m = Convert.ToInt32(Console.ReadLine());
            Console.WriteLine("Bitte geben Sie den Wert des Teilkraisdurchmessers d ein:");
            double d = Convert.ToInt32(Console.ReadLine());
            double c = 0.167 * m ;
            double z = d / m;
            double db = m * z * Math.Cos(20);
            Console.WriteLine("Zahnfußhöhe hf:" + (m + c));
            Console.WriteLine("Zahnkopfhöhe ha:" + (m));
            Console.WriteLine("Teilung p:" + (Math.PI*m) );
            Console.WriteLine("Fußkreisdurchmesser df:" + (d-2*(m+c)));
            Console.WriteLine("Grundkriesdurchmesser db:" +(db));
            Console.ReadLine();

        }
    }
}
