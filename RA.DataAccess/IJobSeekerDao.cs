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
    /// Описание действий с объектом Соискателей в базе
    /// </summary>
    public interface IJobSeekerDao
    {
        /// <summary>
        /// Получить соискателя
        /// </summary>
        /// <param name="SeekerID">Номер соискателя</param>
        /// <returns></returns>
        JobSeeker Get(int SeekerID);
        /// <summary>
        /// Получить всех соискателей
        /// </summary>
        /// <returns></returns>
        IList<JobSeeker> GetAll();
        /// <summary>
        /// Добавить соискателя
        /// </summary>
        /// <param name="seeker">Соискателей</param>
        void Add(JobSeeker seeker);
        /// <summary>
        /// Изменить соискателя
        /// </summary>
        /// <param name="seeker">Соискатель</param>
        void Update(JobSeeker seeker);
        /// <summary>
        /// Удалить соискателя
        /// </summary>
        /// <param name="SeekerID">Номер соискателя</param>
        void Delete(int SeekerID);
        IList<JobSeeker> Load();
        IList<JobSeeker> SearchSeekers(string FirstName, string SecondName, string TypeOfWork);
    }
}
