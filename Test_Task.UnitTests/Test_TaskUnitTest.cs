using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Test_Task;

namespace Test_Task.UnitTests
{   /// <summary>
    /// Класс для тестирования
    /// </summary>
    [TestClass]
    public class Test_TaskUnitTest
    {   
        /// <summary>
        /// Экземпляр менеджера работы программы
        /// </summary>
        IEmployeeManager _manager;

        /// <summary>
        /// Проверка правельности работы методов в штатном режиме
        /// </summary>
        [TestMethod]
        public void AddEmployee()
        {
            _manager = new EmploeeManager("testfile.json");
            int before = _manager.GetAll().Count;
            _manager.Add(new Employee() { FirstName = "James", LastName = "Doe", SalaryPerHour = 120 });
            int after = _manager.GetAll().Count;

            Assert.AreNotEqual<int>(before, after);
        }

        /// <summary>
        /// Проверка файла на пустоту значения
        /// </summary>
        [ExpectedException(typeof(NullReferenceException))]
        [TestMethod]
        public void AddNullEmployee()
        {
            _manager = new EmploeeManager("testfile.json");
            int before = _manager.GetAll().Count;
            _manager.Add(null);
            int after = _manager.GetAll().Count;

            Assert.AreNotEqual<int>(before, after);
        }
        /// <summary>
        /// Проверка на пустоту файла обработки
        /// </summary>
        [ExpectedException(typeof(NullReferenceException))]
        [TestMethod]
        public void UseEmptyFileName()
        {
            _manager = new EmploeeManager("");
            int before = _manager.GetAll().Count;
            _manager.Add(null);
            int after = _manager.GetAll().Count;

            Assert.AreNotEqual<int>(before, after);
        }
    }
}
