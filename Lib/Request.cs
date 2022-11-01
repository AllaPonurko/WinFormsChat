using Lib.Enum;
using System;
using System.Collections.Generic;
using System.Text;

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
    }
}
