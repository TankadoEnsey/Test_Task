using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Test_Task
{
    class Program
    {
        static void Main(string[] args)
        {
            if (args.Length == 0)
            {
                Console.WriteLine("Необходимо указать одну из команд");
                Console.ReadKey(false);
                return;
            }

            IEmployeeManager manager = new EmploeeManager("file.json");

            switch (args.First())
            {
                case "-add":
                    {
                        if (args.Length != 4)
                        {
                            Console.WriteLine("Недостаточное количество аргументов");
                            break;
                        }
                        if (args[1].Split(':').First() != "FirstName")
                        {
                            Console.WriteLine("Неверный параметр");
                            break;
                        }
                        if (args[2].Split(':').First() != "LastName")
                        {
                            Console.WriteLine("Неверный параметр");
                            break;
                        }
                        if (args[3].Split(':').First() != "Salary")
                        {
                            Console.WriteLine("Неверный параметр");
                            break;
                        }

                        try
                        {
                            string firstName = args[1].Split(':').Last();
                            string lastName = args[2].Split(':').Last();
                            decimal salary = decimal.Parse(args[3].Split(':').Last());
                            manager.Add(new Employee() { FirstName = firstName, LastName = lastName, SalaryPerHour = salary });
                        }
                        catch (Exception)
                        {
                            Console.WriteLine("Не удалось добавить сотрудника");
                        }
                        break;
                    }

                case "-update":
                    {
                        if (args.Length != 3)
                        {
                            Console.WriteLine("Недостаточное количество аргументов");
                            break;
                        }
                        if (args[1].Split(':').First() != "Id")
                        {
                            Console.WriteLine("Неверный параметр");
                            break;
                        }
                        if (args[2].Split(':').First() != "FirstName")
                        {
                            Console.WriteLine("Неверный параметр");
                            break;
                        }

                        try
                        {
                            string firstName = args[2].Split(':').Last();
                            int id = int.Parse(args[1].Split(':').Last());
                            manager.Update(id, firstName);
                        }
                        catch (Exception)
                        {
                            Console.WriteLine("Не удалось обновить сотрудника");
                        }
                        break;
                    }

                case "-get":
                    {
                        if (args.Length != 2)
                        {
                            Console.WriteLine("Недостаточное количество аргументов");
                            break;
                        }
                        if (args[1].Split(':').First() != "Id")
                        {
                            Console.WriteLine("Неверный параметр");
                            break;
                        }


                        try
                        {
                            int id = int.Parse(args[1].Split(':').Last());
                            var employee = manager.Get(id);

                            if (employee != null)
                            {
                                Console.WriteLine(employee.ToString());
                            }
                            else
                            {
                                Console.WriteLine("Такого сотрудника не существует");
                            }
                        }
                        catch (Exception)
                        {
                            Console.WriteLine("Не удалось получить сотрудника");
                        }
                        break;
                    }

                case "-delete":
                    {
                        if (args.Length != 2)
                        {
                            Console.WriteLine("Недостаточное количество аргументов");
                            break;
                        }
                        if (args[1].Split(':').First() != "Id")
                        {
                            Console.WriteLine("Неверный параметр");
                            break;
                        }


                        try
                        {
                            int id = int.Parse(args[1].Split(':').Last());
                            manager.Delete(id);
                        }
                        catch (Exception)
                        {
                            Console.WriteLine("Не удалось удалить сотрудника");
                        }
                        break;
                    }
                case "-getall":
                    {
                        if (args.Length != 1)
                        {
                            Console.WriteLine("Недостаточное количество аргументов");
                            break;
                        }

                        try
                        {
                            var employees = manager.GetAll();

                            if (employees.Count != 0)
                            {
                                for (int i = 0; i < employees.Count; i++)
                                {
                                    Console.WriteLine(employees[i].ToString());
                                }
                            }
                            else
                            {
                                Console.WriteLine("Список сотрудников пуст");
                            }
                        }
                        catch (Exception)
                        {
                            Console.WriteLine("Не удалось получить сотрудника");
                        }
                        break;
                    }
                default:
                    {
                        Console.WriteLine("Такой команды не существует");
                        break;
                    }
            }

            Console.ReadKey(false);
        }
    }
}
