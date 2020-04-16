using System;
using System.IO;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GlucoseCalc
{
    class Program
    {

        static void Main(string[] args)
        {
            // Ratio adjusting. Convert to something that's saved ahead of time later.
            Console.WriteLine("Please input your glucose-to-insulin ratio.");
            int glucoseRatio = Convert.ToInt32(Console.ReadLine());
            Console.WriteLine("Please input your carbohydrate-to-insulin ratio.");
            int carbohydrateRatio = Convert.ToInt32(Console.ReadLine());

            // Asking for glucose and carbs.
            Console.WriteLine("Input your current glucose, please!");
            int patientGlucose = Convert.ToInt32(Console.ReadLine());
            Console.WriteLine("Write your desired glucose, please!");
            int desiredGlucose = Convert.ToInt32(Console.ReadLine());
            Console.WriteLine("Input the amount of carbohydrates you're about to eat!");
            int mealCarbs = Convert.ToInt32(Console.ReadLine());


            // The actual calculations are happening here.
            int preventOverdose = desiredGlucose / glucoseRatio;
            int glucoseUnits = patientGlucose / glucoseRatio - preventOverdose;
            int carbohydrateUnits = mealCarbs / carbohydrateRatio;
            int totalUnits = glucoseUnits + carbohydrateUnits;

            // Showing the results of the calculations to the user.
            Console.WriteLine("The total units of insulin you should take is: " + totalUnits);
            Console.ReadLine();
            Console.WriteLine("Would you like to [s]ave a log of this result, or [n]o?");

            ConsoleKeyInfo confirmation = Console.ReadKey();
            if (String.Equals(confirmation.Key.ToString(), "s", StringComparison.CurrentCultureIgnoreCase))
            {
                string time = DateTime.Now.ToString("yyyy-MM-dd_HH.mm.ss"); // clean, contains time and sortable
                using (FileStream fs = new FileStream($"C:\\Users\\ethan\\Documents\\Test Folder\\log-{time}.txt"
                        , FileMode.OpenOrCreate
                        , FileAccess.ReadWrite))
                {
                StreamWriter tw = new StreamWriter(fs);
                    tw.Write($"On {DateTime.Now}, I was {patientGlucose}, I ingested {mealCarbs}, and to counteract this, I took {totalUnits} units worth of insulin." + patientGlucose + mealCarbs + totalUnits);
                    tw.Flush();
                }
            }
        }
    }
}
