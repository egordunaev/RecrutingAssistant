using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using RA.Dto;

namespace RA.BusinessLayer
{
    /// <summary>
    /// Декларация действий над Соискателем
    /// </summary>
    public interface IJobSeekerProcess
    {
        /// <summary>
        /// Возвращает список соискателей
        /// </summary>
        /// <returns></returns>
        IList<JobSeekerDto> GetList();
        /// <summary>
        /// Возвращает соискателя
        /// </summary>
        /// <param name="SeekerID">Номер соискателя</param>
        /// <returns></returns>
        JobSeekerDto Get(int SeekerID);
        /// <summary>
        /// Добавляет соискателя
        /// </summary>
        /// <param name="seekerDto">Соискатель</param>
        void Add(JobSeekerDto seekerDto);
        /// <summary>
        /// Изменяет соискателя
        /// </summary>
        /// <param name="seekerDto">Соискатель</param>
        void Update(JobSeekerDto seekerDto);
        /// <summary>
        /// Удаляет соискателя
        /// </summary>
        /// <param name="SeekerID">Номер соискателя</param>
        void Delete(int SeekerID);
    }
}
