using Lib.Enum;
using System;

namespace Lib
{
    [Serializable]
    public class Response
    {
        /// <summary>
        /// Данные результата обработки сервера
        /// </summary>
        public ResponseStatus Status;
        public string StatusText = "";

        /// <summary>
        /// Данные ответа сервера
        /// </summary>
        public object Body;

    }
}
