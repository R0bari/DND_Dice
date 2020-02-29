using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DND_Dice
{
    class Program
    {
        public static void DetermineDices(List<int> diceSide, List<int> diceCount, List<int> resultValues)
        {
            //  Remove impossible dice counts.
            for (int i = 0; i < resultValues.Count; ++i)
            {
                if (resultValues[i] > diceSide[diceSide.Count - 1] * diceCount[0])
                {
                    diceCount.RemoveAt(0);
                    --i;
                }
            }
            //  Remove impossible counts of dice sides.
            for (int i = 0; i < resultValues.Count; ++i)
            {
                if (resultValues[i] > diceSide[0] * diceCount[0])
                {
                    diceSide.RemoveAt(0);
                    --i;
                }
            }
        }
        static void Main()
        {
            List<int> diceCount = new List<int>() { 1, 2, 3, 4, 5 };
            List<int> diceSide = new List<int>() { 2, 4, 6, 8, 10, 12 };
            List<int> resultValues = new List<int>() { 8, 11, 23, 4, 12, 15, 13, 39, 3, 7, 14, 5, 13 };

            DetermineDices(diceSide, diceCount, resultValues);

            Console.WriteLine("Values:");
            foreach (var elem in resultValues)
            {
                Console.Write(elem + " ");
            }
            Console.WriteLine();

            if (diceCount.Count == 0 || diceSide.Count == 0)
            {
                Console.WriteLine("The situation impossible.");
                return;
            }
            else
            {
                for (int i = 0; i < diceCount.Count; ++i)
                {
                    for (int j = 0; j < diceSide.Count; ++j)
                    {
                        Console.Write(diceCount[i] + "d" + diceSide[j] + " ");
                    }
                }
                Console.WriteLine();
            }
        }
    }
}
