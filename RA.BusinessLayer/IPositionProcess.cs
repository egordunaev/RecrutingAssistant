using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using RA.Dto;

namespace RA.BusinessLayer
{
    /// <summary>
    /// Декларация действий над Вакансиями
    /// </summary>
    public interface IPositionProcess
    {
        /// <summary>
        /// Возвращает список вакансий
        /// </summary>
        /// <returns></returns>
        IList<PositionDto> GetList();
        /// <summary>
        /// Возвращает вакансию
        /// </summary>
        /// <param name="PositionID">Номер вакансии</param>
        /// <returns></returns>
        PositionDto Get(int PositionID);
        /// <summary>
        /// Добавляет новую вакансию
        /// </summary>
        /// <param name="position">Вакансия</param>
        void Add(PositionDto position);
        /// <summary>
        /// Изменяет вакансию
        /// </summary>
        /// <param name="position">Вакансия</param>
        void Update(PositionDto position);
        /// <summary>
        /// Удаляет вакансию
        /// </summary>
        /// <param name="PositionID">Номер вакансии</param>
        void Delete(int PositionID);
        IList<PositionDto> SearchPosition(string PositionName, string Employer);
    }
}
