using System;
using System.Diagnostics;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO;
using System.Diagnostics;
using System.Threading;
using System.Reflection;

namespace _15
{
    class Program
    {

        static void Main(string[] args)
        {
            // ~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~1 З А Д А Н И Е  ~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~
            using (StreamWriter sw = new StreamWriter(@"C:\Users\Admin\Desktop\ооп\15\15\15\First.txt"))
            {
                foreach (var Process in Process.GetProcesses())
                {
                    Console.WriteLine("Имя: " + Process.ProcessName);
                    Console.WriteLine("ID: " + Process.Id);
                    Console.WriteLine("Приоритет: " + Process.BasePriority);
                    sw.WriteLine("Имя: " + Process.ProcessName);
                    sw.WriteLine("ID: " + Process.Id);
                    sw.WriteLine("Приоритет: " + Process.BasePriority);
                    try
                    {
                        Console.WriteLine("Начало работы: " + Process.StartTime);
                        sw.WriteLine("Начало работы: " + Process.StartTime);
                    }
                    catch (Exception ex)
                    {
                        Console.WriteLine(ex.Message);
                        sw.WriteLine(ex.Message);
                    }
                    Console.WriteLine("~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~");
                }
            }

            // ~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~2 З А Д А Н И Е  ~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~
            using (StreamWriter sw = new StreamWriter(@"C:\Users\Admin\Desktop\ооп\15\15\15\Second.txt"))
            {
                var appDomain = AppDomain.CurrentDomain;
                sw.WriteLine("Имя: " + appDomain.FriendlyName);
                sw.WriteLine();
                sw.WriteLine("Конфигурация: " + appDomain.SetupInformation.ToString());
                sw.WriteLine();
                sw.WriteLine("Сборки:");
                Console.WriteLine("Имя: " + appDomain.FriendlyName);
                Console.WriteLine();
                Console.WriteLine("Конфигурация: " + appDomain.SetupInformation.ToString());
                Console.WriteLine();
                Console.WriteLine("Сборки:");
                foreach (var l in appDomain.GetAssemblies())
                {
                    Console.WriteLine(l);
                    sw.WriteLine(l);
                }
            }
            //AppDomain newDomain = AppDomain.CreateDomain("New");
            //newDomain.Load(new AssemblyName("15"));
            //Console.WriteLine("Name of the new domain: " + newDomain.FriendlyName + "\nAssamblies of new domain:");
            //foreach (Assembly a in newDomain.GetAssemblies())
            //{
            //    Console.WriteLine(a.GetName().Name);
            //}
            ////Выгрузить домен
            //AppDomain.Unload(newDomain);
            //Console.WriteLine("\nPress any key\n");
            //Console.ReadKey();
            //~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~3 З А Д А Н И Е  ~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~

            using (StreamWriter sw = new StreamWriter(@"C:\Users\Admin\Desktop\ооп\15\15\15\Therd.txt"))
            {
                Console.WriteLine("Введите n");
                Mutex mutex = new Mutex();
                int numers = Convert.ToInt32(Console.ReadLine());
                Thread NumbersThread = new Thread(new ParameterizedThreadStart(WriteNums));
                NumbersThread.Start(numers);

                Thread.Sleep(2000);

                mutex.WaitOne();
                // приостанавливает выполнение потока до тех пор, пока не будет получен мьютекс mutexObj.
                Console.WriteLine("Приоритет:   " + NumbersThread.Priority);
                sw.WriteLine("Приоритет:   " + NumbersThread.Priority);
                Console.WriteLine("ID потока:   " + NumbersThread.ManagedThreadId);
                sw.WriteLine("ID потока:   " + NumbersThread.ManagedThreadId);
                Thread.Sleep(1000);

                mutex.ReleaseMutex();
                //После выполнения всех действий, когда мьютекс больше не нужен, поток освобождает его с помощью метода
                Thread.Sleep(2000);

                void WriteNums(object number)
                {
                    int num = (int)number;
                    for (int i = 0; i < num; i++)
                    {
                        Console.WriteLine(i);
                        sw.WriteLine(i);
                        Thread.Sleep(500);

                    }
                }
            }
            // ~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~4 З А Д А Н И Е  ~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~
            Console.WriteLine("Выводятся четные и нечетные:");
            i();
            Thread.Sleep(4000);

            Console.WriteLine("\nОчередно(четное,нечетное):");
            ii();
            Thread.Sleep(4000);
            // ~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~5 З А Д А Н И Е  ~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~
            object obj = new object();
            Console.WriteLine("\nНажмите на любую кнопку для останова");
            TimerCallback time = new TimerCallback(PushNumber);
            Timer timer = new Timer(time, 0, 0, 1000);
            Console.ReadLine();

        }
        public static void PushNumber(object obj)
            {
                Random num = new Random();
                Console.WriteLine(num.Next());
            }
            public static void i()
            {
                object locker = new object();
                Thread Ch_Thread = new Thread(new ThreadStart(Chot));
                Thread Nech_Thread = new Thread(new ThreadStart(Nechot));
                
                Ch_Thread.Start();
                Nech_Thread.Start();
            
                void Chot()
                {
                    lock (locker)
                    {
                        for (int i = 1; i < 10; i++)
                        {
                            if (i % 2 == 0)
                            {
                                Console.WriteLine(i + " четное");
                                Thread.Sleep(500);
                            }
                        }
                    }
                }

                void Nechot()
                {
                    lock (locker)
                    {
                        for (int i = 1; i < 10; i++)
                        {
                            if (i % 2 != 0)
                            {
                                Console.WriteLine(i + " нечетное");
                                Thread.Sleep(250);
                            }
                        }
                    }
                }

                
            }

            public static void ii()
            {
                Mutex mutex = new Mutex();///организ. критич секцию для неск запросов

                Thread Nech_Thread = new Thread(new ThreadStart(Nechot));
                Thread Ch_Thread = new Thread(new ThreadStart(Chot));
                Ch_Thread.Start();
                Nech_Thread.Start();
                

                void Nechot()
                {
                    for (int i = 1; i < 10; i++)
                    {
                        mutex.WaitOne();///вход в крит. секцию

                        if (i % 2 != 0)
                        {
                            Console.WriteLine(i + " нечетное");
                            Thread.Sleep(250);
                        }
                        mutex.ReleaseMutex();///выход из нее
                    }
                }

                void Chot()
                {
                    for (int i = 1; i < 10; i++)
                    {
                        mutex.WaitOne();

                        if (i % 2 == 0)
                        {
                            Console.WriteLine(i + " четное");
                            Thread.Sleep(500);
                        }
                        mutex.ReleaseMutex();
                    }
                }
            }
        }
    }


