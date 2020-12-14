using System;

namespace Lab4
{
    class Program
    {
        public static void Error()
        {
            Console.ForegroundColor = ConsoleColor.Red;
            Console.WriteLine("Error");
            Console.ResetColor();
        }
        static void Main(string[] args)
        {
            while (true)
            {
                try
                {
                    Console.WriteLine("Введите размерность массива...");
                    var array = CreateRandomArray(Convert.ToInt32(Console.ReadLine()));
                    ShowArray(array);
                    Console.WriteLine("Набор операций:\n 1.Удалить нечетные элементы \n 2.Заменить элемент \n 3.Сдвинуть циклически на... \n 4.Найти элемент, равный среднему арифметическому элементов массива");

                    while (true)
                    {
                        var action = Console.ReadLine();
                        switch (action)
                        {
                            case "1":
                                var newArray = DeleteUnevenElementInArray(array);
                                ShowArray(newArray);
                                break;
                            case "2":
                                Console.WriteLine("Введите номер элемента...");
                                var elementNum = Convert.ToInt32(Console.ReadLine());
                                Console.WriteLine("Введите число...");
                                var element = Convert.ToInt32(Console.ReadLine());
                                var newArray2 = AddElement(array, elementNum, element);
                                ShowArray(newArray2);
                                break;
                            case "3":
                                Console.WriteLine("Введите число...");
                                var countElement = Convert.ToInt32(Console.ReadLine());
                                var newArray3 = CyclicShift(array, countElement);
                                ShowArray(newArray3);
                                break;
                            case "4":
                                var findingElement = FindElement(array);
                                if (findingElement == 0)
                                    Console.WriteLine("Такого элемента нет");
                                else
                                    Console.WriteLine($"Среднее арифметическое равно {findingElement}");
                                break;
                        }
                        Console.WriteLine();
                    }
                }
                catch
                {
                    Error();
                }
            }
        }

        public static int[] CreateRandomArray(int n)
        {
            var array = new int[n];
            Random random = new Random();

            for (int i = 0; i < n; i++)
            {
                array[i] = random.Next(0, 10);
            }

            return array;
        }

        public static void ShowArray(int[] array)
        {
            for (int i = 0; i < array.Length; i++)
            {
                Console.WriteLine($"{i} - {array[i]}");
            }
        }

        public static int[] DeleteUnevenElementInArray(int[] array)
        {
            var j = 0;
            var newArray = new int[FindCountUnevenElementInArray(array)];

            for (int i = 0; i < array.Length; i++)
            {
                if (array[i] % 2 == 0)
                {
                    newArray[j] = array[i];
                    j++;
                }
            }

            return newArray;
        }

        public static int FindCountUnevenElementInArray(int[] array)
        {
            var count = 0;

            for (int i = 0; i < array.Length; i++)
            {
                if (array[i] % 2 == 0)
                {
                    count++;
                }
            }

            return count;
        }

        public static int[] AddElement(int[] array, int elementNumber, int element)
        {
            var newArray = new int[array.Length + 1];
            var j = 0;
            for (int i = 0; i < array.Length; i++)
            {
                if (i == elementNumber)
                {
                    newArray[j] = element;
                    newArray[j + 1] = array[i];
                    j = j + 2;
                }
                else
                {
                    newArray[j] = array[i];
                    j++;
                }
            }

            return newArray;
        }

        public static int[] CyclicShift(int[] array, int countElement)
        {
            for (int j = 0; j < countElement; j++)
            {

                if (array.Length > 1)
                {
                    var tmp = array[array.Length - 1];

                    for (var i = array.Length - 1; i != 0; --i) array[i] = array[i - 1];

                    array[0] = tmp;
                }
            }
            return array;

        }

        public static int FindElement(int[] array)
        {
            int sumElement = 0;
            for (int i = 0; i < array.Length; i++)
            {
                sumElement += array[i];
            }

            int arithmeticMean = sumElement / array.Length;
            int elenetnt = 0;
            for(int i = 0; i<array.Length;i++)
            {
                if (arithmeticMean == array[i])
                    elenetnt = array[i];
            }
            return elenetnt;
        }
    }
}
