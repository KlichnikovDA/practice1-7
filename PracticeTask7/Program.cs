using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PracticeTask7
{
    class Program
    {
        // Печать найденной комбинации
        static public void PrintCombination(ushort[] Comb)
        {
            for (ushort i = 0; i < Comb.Length; i++)
                Console.Write("{0} ", Comb[i]);
            Console.WriteLine();
        }

        // Проверка, есть ли еще возможные комбинации
        static public bool ThereAreOtherOptions(ushort[] Comb, ushort MaxValue)
        {
            // Логический флаг
            bool ok = true;
            // Вспомогательная переменная для прохода по массиву
            int i = 0;
            while (ok && i < Comb.Length)
                if (Comb[i] == MaxValue - Comb.Length + ++i)
                    ok = true;
                else
                    ok = false;

            return !ok;
        }

        // Генерация следующей комбинации
        static public void MakeNextCombination(ushort[] Comb, ushort MaxValue)
        {
            // Вспомогательная переменная для прохода по массиву
            int i = Comb.Length - 1;
            while (Comb[i] == MaxValue - Comb.Length + 1 + i)
                i--;
            Comb[i]++;
            for (i = i + 1; i < Comb.Length; i++)
                Comb[i] = (ushort)(Comb[i - 1] + 1);
        }

        static void Main(string[] args)
        {
            // Количество элементов
            ushort N;
            // Длина сочетаний
            ushort K;
            // Флаг правильности ввода
            bool ok;

            // Ввод количества элементов
            do
            {
                Console.WriteLine("Введите количество элементов для сочетаний:");
                ok = UInt16.TryParse(Console.ReadLine(), out N) && N > 0;
                if (!ok)
                    Console.WriteLine("Требуется ввести натуральное число.");
            } while (!ok);
            // Ввод длины сочетаний
            do
            {
                Console.WriteLine("Введите длину сочетаний - от 1 до {0}:", N);
                ok = UInt16.TryParse(Console.ReadLine(), out K) && K > 0 && K <= N;
                if (!ok)
                    Console.WriteLine("Требуется ввести натуральное число от 1 до {0}.", N);
            } while (!ok);

            // Максиммальный возможный элемент
            ushort Max = (ushort)(N-1);
            // Массив для представления сочетания
            ushort[] Combination = new ushort[K];
            for (ushort i = 0; i < K; i++)
                Combination[i] = i;
            Console.WriteLine("Возможные сочетания без повторений:");
            PrintCombination(Combination);
            while (ThereAreOtherOptions(Combination, Max))
            {
                MakeNextCombination(Combination, Max);
                PrintCombination(Combination);
            }

            Console.WriteLine("Нажмите любую клавишу...");
            Console.ReadKey();
        }
    }
}