using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using Newtonsoft.Json;


namespace Test_Task
{
    /// <summary>
    ///  класс реализующий интерфейс управления списком сотрудников 
    /// </summary>
    public class EmploeeManager : IEmployeeManager 
    {  
        /// <summary>
        /// Поле для хранения пути для файла
        /// </summary>
        private readonly string _fileName; 

        public EmploeeManager(string fileName)
        {
            _fileName = fileName;

        }
        /// <summary>
        /// Метод добавления нового сотрудника
        /// </summary>
        /// <param name="employee"></param>
        public void Add(Employee employee)
        {
            try
            {
                var emps = GetAll();
                int lastId = 0;
                if (emps.Count != 0) 
                {
                    lastId = emps.Last().Id;
                }
                employee.Id = ++lastId;
                emps.Add(employee);
                string json = JsonConvert.SerializeObject(emps, Formatting.Indented);
                File.WriteAllText(_fileName, json);
            }
            catch (Exception)
            {

                throw;
            }
           
        }
        /// <summary>
        /// Метод удаления сотрудника
        /// </summary>
        /// <param name="id"></param>
        public void Delete(int id)
        {
            try
            {
                var emps = GetAll();
                Employee employee = emps.Where(e => e.Id == id).FirstOrDefault();
                emps.Remove(employee);
                string json = JsonConvert.SerializeObject(emps, Formatting.Indented);
                File.WriteAllText(_fileName, json);
            }
            catch (Exception)
            {

                throw;
            }
        }
        /// <summary>
        /// Метод поиска сотрудника
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        public Employee Get(int id)
        {
            try
            {
                var emps = GetAll();
                return emps.Where(e => e.Id == id).FirstOrDefault();
            }
            catch (Exception)
            {

                return null;
            }
        }
        /// <summary>
        /// Метод для вывода всех сотрудников
        /// </summary>
        /// <returns></returns>
        public List<Employee> GetAll()
        {
            try
            {
                List<Employee> employees = JsonConvert.DeserializeObject<List<Employee>>(File.ReadAllText(_fileName));
                return employees;
            }
            catch (Exception)
            {
                return new List<Employee>();
            }
        }
        /// <summary>
        /// Метод для обновления сотрудников
        /// </summary>
        /// <param name="id"></param>
        /// <param name="firstName"></param>
        public void Update(int id, string firstName)
        {
            try
            {
                var emps = GetAll();
                int employeeIdx = emps.FindIndex(e => e.Id == id);
                emps[employeeIdx].FirstName = firstName;
                string json = JsonConvert.SerializeObject(emps, Formatting.Indented);
                File.WriteAllText(_fileName, json);
            }
            catch (Exception)
            {

                throw;
            }
        }

    }
}
