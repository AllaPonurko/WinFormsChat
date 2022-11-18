using Lib.Enum;
using System;
using System.Threading.Tasks;

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

        public static explicit operator Response(Task v)
        {
            throw new NotImplementedException();
        }
    }
}
