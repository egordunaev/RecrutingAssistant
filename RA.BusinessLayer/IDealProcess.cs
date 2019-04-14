using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using RA.Dto;

namespace RA.BusinessLayer
{
    /// <summary>
    /// Декларация действий по работе со Сделками
    /// </summary>
    public interface IDealProcess
    {
        /// <summary>
        /// Возвращает список сделок
        /// </summary>
        /// <returns></returns>
        IList<DealDto> GetList();
        /// <summary>
        /// Возвращает сделку по номеру
        /// </summary>
        /// <param name="DealID">Номер сделки</param>
        /// <returns></returns>
        DealDto Get(int DealID);
        /// <summary>
        /// Добавляет сделку
        /// </summary>
        /// <param name="deal">Сделка</param>
        void Add(DealDto deal);
        /// <summary>
        /// Изменяет сделку
        /// </summary>
        /// <param name="deal">Сделка</param>
        void Update(DealDto deal);
        /// <summary>
        /// Удаляет сделку
        /// </summary>
        /// <param name="DealID">Номер сделки</param>
        void Delete(int DealID);
    }
}
