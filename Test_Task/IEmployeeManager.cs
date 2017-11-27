using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Test_Task
{   /// <summary>
    /// Интерфейс описывающий функциональность программы
    /// </summary>
    public interface IEmployeeManager 
    {  
        /// <summary>
        /// Метод добавления без реализации
        /// </summary>
        /// <param name="employee"></param>
        void Add(Employee employee);

        /// <summary>
        /// Метод обновления без реализации
        /// </summary>
        /// <param name="id"></param>
        /// <param name="firstName"></param>
        void Update(int id, string firstName);

        /// <summary>
        /// Метод поиска по id
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        Employee Get(int id);

        /// <summary>
        /// Метод  удаления без реализации
        /// </summary>
        /// <param name="id"></param>
        void Delete(int id);

        /// <summary>
        /// Вывод всех сотрудников без реализации
        /// </summary>
        /// <returns></returns>
        List<Employee> GetAll();

    }
}
