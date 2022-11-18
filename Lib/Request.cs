using Lib.Enum;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace Lib
{
    [Serializable]
   public class Request
    {
            /// <summary>
            /// Команда, которую должен выполнить сервер
            /// </summary>
            public RequestCommand Command;

            /// <summary>
            /// Данные для работы сервера
            /// </summary>
            public object Body;

        public static explicit operator Request(Task<string> v)
        {
            throw new NotImplementedException();
        }
    }
}
