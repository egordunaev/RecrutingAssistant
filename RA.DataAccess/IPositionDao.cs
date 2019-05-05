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
    /// Описание действий с объектом Вакансии в базе
    /// </summary>
    public interface IPositionDao
    {
        /// <summary>
        /// Получить вакансию
        /// </summary>
        /// <param name="PositionID">Номер вакансии</param>
        /// <returns></returns>
        Position Get(int PositionID);
        /// <summary>
        /// Получить все вакансии
        /// </summary>
        /// <returns></returns>
        IList<Position> GetAll();
        /// <summary>
        /// Добавить вакансию
        /// </summary>
        /// <param name="position">Вакансия</param>
        void Add(Position position);
        /// <summary>
        /// Изменить вакансию
        /// </summary>
        /// <param name="position">Вакансия</param>
        void Update(Position position);
        /// <summary>
        /// Удалить вакансию
        /// </summary>
        /// <param name="PositionID">Номер вакансии</param>
        void Delete(int PositionID);
        IList<Position> Load();
        IList<Position> SearchPosition(string PositionName, string Employer);
    }
}
