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
    /// Описание действий с объектом Типы работ в базе
    /// </summary>
    public interface ITypeOfWorkDao
    {
        /// <summary>
        /// Получить тип работы
        /// </summary>
        /// <param name="WorkID">Номер типа работы</param>
        /// <returns></returns>
        TypeOfWork Get(int WorkID);
        /// <summary>
        /// Получить все типы работ
        /// </summary>
        /// <returns></returns>
        IList<TypeOfWork> GetAll();
        /// <summary>
        /// Добавить тип работы
        /// </summary>
        /// <param name="work">Тип работы</param>
        void Add(TypeOfWork work);
        /// <summary>
        /// Изменить тип работы
        /// </summary>
        /// <param name="work">Тип работы</param>
        void Update(TypeOfWork work);
        /// <summary>
        /// Удалить тип работы
        /// </summary>
        /// <param name="WorkID">Номер типа работы</param>
        void Delete(int WorkID);
        /// <summary>
        /// Загрузить тип работы
        /// </summary>
        /// <returns></returns>
        IList<TypeOfWork> Load();
        IList<TypeOfWork> SearchWork(string TypeOfWork);
    }
}
