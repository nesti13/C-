using System;
using System.Collections.Concurrent;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;


namespace _16
{
    class Program
    {
        public static int cus = 1;
        static void Main(string[] args)
        {
            Ex1();
            Ex2();
            Ex3_Ex4();
            Ex5();
            Ex6();
            Ex7();
            Ex8();

        }
        static void Ex1()
        {
            Console.WriteLine("Задание 1");
                for (int i = 0; i < 5; i++)
                {
                    Stopwatch sw = new Stopwatch();
                    sw.Start();
                    Task task = new Task(() => Number());
                    task.Start();
                    Console.WriteLine($"ID: {task.Id}, Статус: {task.Status}");
                    task.Wait();
                    Console.WriteLine($"ID: {task.Id}, Статус: {task.Status}");
                    sw.Stop();
                    Console.WriteLine($"Пройденное время: {sw.Elapsed}ms");

                }
            Console.WriteLine("~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~");
        }
        static void Ex2()
        {
                Console.WriteLine("Задание 2");
                CancellationTokenSource CancellationToken = new CancellationTokenSource();
                //может возникнуть необходимость прервать выполняемую задачу
                CancellationToken Token = CancellationToken.Token;
                Task task = new Task(Number, Token);
                task.Start();
                CancellationToken.Cancel();
                if (Token.IsCancellationRequested)
                {
                    Console.WriteLine("Задача отменена");
                }
                Console.WriteLine("~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~");
        }
        static void Ex3_Ex4()
        {
            Console.WriteLine("Задание 3_4");
                Task<int> task3_1 = new Task<int>(() =>
                {  
                    int i = 0;
                    while (i < 5)
                    i += 1;
                    return i;
                });
                Task<int> task3_2 = new Task<int>(() =>
                 {
                    Random rnd = new Random();
                    return rnd.Next(1, 10);
                  });
                Task<string> task3_3 = new Task<string>(() =>
                {
                    return "Результат:";
                });
                task3_1.Start();
                task3_1.Wait();
                task3_2.Start();
                task3_2.Wait();
                task3_3.Start();
                task3_3.Wait();
                Task task3Result = new Task(() =>
                {
                    Console.WriteLine($"{task3_3.Result} {task3_1.Result} + {task3_2.Result} = {task3_1.Result + task3_2.Result}");
                });
                task3Result.Start();
                task3Result.Wait();

                Task task4_1 = Task.WhenAll(task3Result, task3_3, task3_2, task3_1).ContinueWith(t =>
                {
                    Console.WriteLine("Выполняется задача  №4_1");
                });
                //continuation task позволяют определить задачи,
                //которые выполняются после завершения других задач
                task4_1.Wait();
                Task<string> task4_2 = Task.Run(() =>
                {
                    return "Выполняется задача № 4_2";
                });

                var awaiter = task4_2.GetAwaiter();// получаем объект продолжения
                                               // что делать после окончания предшественника
                awaiter.OnCompleted(() =>
                {
                // получаем результат вычислений предшественника 
                string result = awaiter.GetResult();
                Console.WriteLine(result);
                });
             }
                
        static void Ex5()
        {
            //5
            int[] arr1 = new int[100000];
            int[] arr2 = new int[100000];

            Stopwatch sw1 = new Stopwatch();
            sw1.Start();
            Parallel.For(0,arr1.Length, t=>arr1[t]=t);
            sw1.Stop();
            Console.WriteLine($"Parallel for: {sw1.Elapsed}ms");

            Stopwatch sw2 = new Stopwatch();
            sw2.Start();
            for (int p = 0; p < arr2.Length; p++)
            {
                arr2[p] = p + 1;
            }
            sw2.Stop();
            Console.WriteLine($"Normal for: {sw2.Elapsed}ms");

            sw1.Restart();
            Parallel.ForEach(arr1, p => p = 1);
            Parallel.ForEach(arr2, p => p = 1);
            sw1.Stop();
            Console.WriteLine($"Parallel foreach: {sw1.Elapsed}ms");
            sw2.Restart();
            foreach (int item in arr2)
            {
                arr2[item] = item;
            }
            sw2.Stop();
            Console.WriteLine($"Normal foreach: {sw2.Elapsed}ms");

        }
        static void Ex6()
        {
            //6
            Parallel.Invoke//Выполняет все предоставленные действия,
                           //по возможности в параллельном режиме.
                (Display,
                () =>
                {
                    Console.WriteLine($"Выполняется задача {Task.CurrentId}");
                    Thread.Sleep(1000);
                },
            () => Factorial(3));
            Console.WriteLine();
        }
        static void Ex7()
        {
            //7
            BlockingCollection<string> bc = new BlockingCollection<string>(5);

            Task[] sellers = new Task[5]
            {
            new Task(() => { while (true) { Thread.Sleep(540); bc.Add("Тушь"); } }),
            new Task(() => { while (true) { Thread.Sleep(300); bc.Add("Помада"); } }),
            new Task(() => { while (true) { Thread.Sleep(100); bc.Add("Консилер"); } }),
            new Task(() => { while (true) { Thread.Sleep(150); bc.Add("Карандаш"); } }),
            new Task(() => { while (true) { Thread.Sleep(250); bc.Add("Крема"); } })
            };

            Task[] consumers = new Task[10]
            {
            new Task(() => { while (true) { Thread.Sleep(300); bc.Take(); } }),
            new Task(() => { while (true) { Thread.Sleep(500); bc.Take(); } }),
            new Task(() => { while (true) { Thread.Sleep(500); bc.Take(); } }),
            new Task(() => { while (true) { Thread.Sleep(400); bc.Take(); } }),
            new Task(() => { while (true) { Thread.Sleep(250); bc.Take(); } }),
            new Task(() => { while (true) { Thread.Sleep(300); bc.Take(); } }),
            new Task(() => { while (true) { Thread.Sleep(500); bc.Take(); } }),
            new Task(() => { while (true) { Thread.Sleep(500); bc.Take(); } }),
            new Task(() => { while (true) { Thread.Sleep(400); bc.Take(); } }),
            new Task(() => { while (true) { Thread.Sleep(250); bc.Take(); } })
            };

            foreach (var s in sellers)
                if (s.Status != TaskStatus.Running)
                    s.Start();

            foreach (var s in consumers)
                if (s.Status != TaskStatus.Running)
                    s.Start();

            int count = 1;

            for (int n = 0; n < 10; n++)
            {
                count = bc.Count;
                Thread.Sleep(500);
                Console.Clear();
                Console.WriteLine("Покупки");

                foreach (var s in bc)
                    Console.WriteLine(s);
            }
        }
        static void Ex8()
        {
            //8
            FactorialAsync();
        }
            static void Factorial(int num)
            {
            int result = 1;
            for (int i = 1; i <= num; i++)
                result *= i;

            Console.WriteLine($"Факториал числа {num} равен {result}");
            Console.WriteLine("~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~");
            }
            static void Display()
            {
                Console.WriteLine($"Выполняется задача {Task.CurrentId}");
                Thread.Sleep(2000);
            }
            static async void FactorialAsync()
            {
                Console.WriteLine("Начало метода FactorialAsync");// выполняется синхронно
            await Task.Run(() => Factorial(5)); // эта задача будет выполняться асинхронно
                Console.WriteLine("Конец метода FactorialAsync\n");

            }
            static void Number()
            {
                for (int i = 1; i < 5; i++)
                {
                    Console.WriteLine(i);
                    Thread.Sleep(200);
                }
            }
        }
    }


