using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RA.Dto
{
    /// <summary>
    /// Типы работ
    /// </summary>
    public class TypeOfWorkDto
    {
        /// <summary>
        /// Номер типа работы
        /// </summary>
        public int WorkID { get; set; }
        /// <summary>
        /// Название типа работы
        /// </summary>
        public string Name { get; set; }
    }
}
