using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Configuration;
using RA.DataAccess.Entities;

namespace RA.DataAccess
{
    /// <summary>
    /// Описание действий с объектом Работодатель в базе
    /// </summary>
    public interface IEmployerDao
    {
        /// <summary>
        /// Получить работодателя
        /// </summary>
        /// <param name="EmployerID">Номер работодателя</param>
        /// <returns></returns>
        Employer Get(int EmployerID);
        /// <summary>
        /// Получить всех работодателей
        /// </summary>
        /// <returns></returns>
        IList<Employer> GetAll();
        /// <summary>
        /// Добавить работодателя
        /// </summary>
        /// <param name="employer">Работодатель</param>
        void Add(Employer employer);
        /// <summary>
        /// Изменить работодателя
        /// </summary>
        /// <param name="employer">Работодатель</param>
        void Update(Employer employer);
        /// <summary>
        /// Удалить работодателя
        /// </summary>
        /// <param name="EmployerID">Номер работодателя</param>
        void Delete(int EmployerID);
        IList<Employer> Load();
    }
}
