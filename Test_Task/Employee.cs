using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Test_Task
{   /// <summary>
    /// Класс описывающий сотрудников
    /// </summary>
    public class Employee 
    {   /// <summary>
        /// Свойство "Номер сотрудника"
        /// </summary>
        public int Id { get; set; }

        /// <summary>
        /// Свойство Имя сотрудника
        /// </summary>
        public string FirstName { get; set; }

        /// <summary>
        /// Свойство Фамилия сотрудника
        /// </summary>
        public string LastName { get; set; }

        /// <summary>
        /// Свойство оклад сотрудника по часам
        /// </summary>
        public decimal SalaryPerHour { get; set; }
        
        /// <summary>
        /// Перегруженный метод ToString для вывода сотрудников
        /// </summary>
        /// <returns></returns>
        public override string ToString() 
        {
            return $"Id={Id}, FirstName={FirstName}, LastName={LastName}, Salary={SalaryPerHour}";
        }
    }
}
