using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using RA.Dto;

namespace RA.BusinessLayer
{
    /// <summary>
    /// Декларация действий над Типами работ
    /// </summary>
    public interface ITypeOfWorkProcess
    {
        /// <summary>
        /// Возвращает список работ
        /// </summary>
        /// <returns></returns>
        IList<TypeOfWorkDto> GetList();
        /// <summary>
        /// Возвращает тип работы
        /// </summary>
        /// <param name="WorkID">Номер типа работы</param>
        /// <returns></returns>
        TypeOfWorkDto Get(int WorkID);
        /// <summary>
        /// Добавляет тип работы
        /// </summary>
        /// <param name="workDto">Тип работы</param>
        void Add(TypeOfWorkDto workDto);
        /// <summary>
        /// Изменяет тип работы
        /// </summary>
        /// <param name="workDto">Тип работы</param>
        void Update(TypeOfWorkDto workDto);
        /// <summary>
        /// Удаляет тип работы
        /// </summary>
        /// <param name="WorkID">Номер типа работы</param>
        void Delete(int WorkID);
    }
}
