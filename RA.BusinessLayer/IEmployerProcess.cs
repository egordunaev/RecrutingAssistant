using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using RA.Dto;

namespace RA.BusinessLayer
{
    /// <summary>
    /// Декларация действий с Работодателем
    /// </summary>
    public interface IEmployerProcess
    {
        /// <summary>
        /// Возвращает список работодателей
        /// </summary>
        /// <returns></returns>
        IList<EmployerDto> GetList();
        /// <summary>
        /// Возвращает работодателя по номеру
        /// </summary>
        /// <param name="EmployerID">Номер работодателя</param>
        /// <returns></returns>
        EmployerDto Get(int EmployerID);
        /// <summary>
        /// Добавляет работодателя
        /// </summary>
        /// <param name="employer">Работодатель</param>
        void Add(EmployerDto employer);
        /// <summary>
        /// Изменяет работодателя
        /// </summary>
        /// <param name="employer">Работодатель</param>
        void Update(EmployerDto employer);
        /// <summary>
        /// Удалить работодателя
        /// </summary>
        /// <param name="EmployerID">Номер работодателя</param>
        void Delete(int EmployerID);
        IList<EmployerDto> SearchEmployer(string Name, string TypeOfWork);
    }
}
