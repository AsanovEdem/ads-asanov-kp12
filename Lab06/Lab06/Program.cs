using System;

namespace Lab06
{
    public class Queue
    {
        private int head, tail, capacity;
        private int[] queue;

        public Queue(int c)
        {
            head = tail = 0;
            capacity = c;
            queue = new int[capacity];
        }

        public int getCapacity()
        {
            return capacity;
        }
        public void queueEnqueue(int data)
        {
            if (capacity == tail)
            {
                Console.Write("\nЧерга повна\n");
                return;
            }
            else
            {
                queue[tail] = data;
                tail++;
            }
            return;
        }

        public void queueDequeue()
        {
            if (head == tail)
            {
                Console.Write("\nЧерга порожня\n");
                return;
            }

            else
            {
                for (int i = 0; i < tail - 1; i++)
                {
                    queue[i] = queue[i + 1];
                }

                if (tail < capacity)
                    queue[tail] = 0;

                tail--;
                Console.Write("\nЕлемент видалено\n");
            }
            return;
        }

        public void queueDisplay()
        {
            int i;
            if (head == tail)
            {
                Console.Write("\nЧерга порожня\n");
                return;
            }

            for (i = head; i < tail; i++)
            {
                Console.Write(" {0} <-- ", queue[i]);
            }
            return;
        }

        public void queueFront()
        {
            if (head == tail)
            {
                Console.Write("\nЧерга порожня\n");
                return;
            }
            Console.Write("\nГолова черги: {0} ", queue[head]);
            return;
        }

        public bool IsQueueFull()
        {
            if(head == tail && tail != 0) { return true; }
            return false;
        }
    }

    class Program
    {
        static Queue queue = new Queue(10);
        static void Main(string[] Args)
        {
            Console.OutputEncoding = System.Text.Encoding.Default;
            while (true)
            {
                Console.Clear();
                if (!Interface()) break;
            }
            Console.WriteLine("До черги потрапив елемент <0>, програма завершила роботу.");
        }
        static bool Interface()
        {
            Console.WriteLine($"Наразі черга місткістю {queue.getCapacity()}. Оберіть дію:");
            Console.WriteLine("1 - вивести поточну чергу\n" +
                              "2 - Вивести перший елемент в черзі\n" +
                              "3 - додати елемент до черги\n" +
                              "4 - Видалити елемент з черги.\n" +
                              "5 - Створити нову чергу");
            string input = Console.ReadLine();
            int choise = int.Parse(input);
            switch (choise)
            {
                case 1:
                    queue.queueDisplay();
                    break;
                case 2:
                    queue.queueFront();
                    break;
                case 3:
                    if (queue.IsQueueFull())
                    {
                        Console.WriteLine("Черга повна");
                        break;
                    }
                    Console.WriteLine("Введіть елемент, який бажаєте додати.");
                    try
                    {
                        int newElem = int.Parse(Console.ReadLine());
                        queue.queueEnqueue(newElem);

                    }
                    catch
                    {
                        Console.WriteLine("Ви ввели не ціле число!");
                    }
                    break;
                case 4:
                    queue.queueDequeue();
                    break;
                case 5:
                    Console.WriteLine("Введіть місткість черги, яку бажаєте створити.");
                    try
                    {
                        int capacity = int.Parse(Console.ReadLine());
                        queue = new Queue(capacity);

                    }
                    catch
                    {
                        Console.WriteLine("Ви ввели не ціле число!");
                    }
                    break;
                default:
                    Console.WriteLine("Довжина черги має бути цілим числом!");
                    break;
            }
            Console.WriteLine("\n\nНатисніть Enter для продовження...");
            Console.ReadLine();
            return true;
        }
    }
}