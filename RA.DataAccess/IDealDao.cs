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
    /// Описание действий с объектом Сделок в базе
    /// </summary>
    public interface IDealDao
    {
        /// <summary>
        /// Получить сделку
        /// </summary>
        /// <param name="DealID">Номер сделки</param>
        /// <returns></returns>
        Deal Get(int DealID);
        /// <summary>
        /// Получить все сделки
        /// </summary>
        /// <returns></returns>
        IList<Deal> GetAll();
        /// <summary>
        /// Добавить новую сделку
        /// </summary>
        /// <param name="deal">Сделка</param>
        void Add(Deal deal);
        /// <summary>
        /// Изменить сделку
        /// </summary>
        /// <param name="deal">Сделка</param>
        void Update(Deal deal);
        /// <summary>
        /// Удалить сделку
        /// </summary>
        /// <param name="DealID">Номер сделки</param>
        void Delete(int DealID);
    }
}
