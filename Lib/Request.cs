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
            public  object Body;
       
        

        public static explicit operator string(Request request)
        {
         string str= request.Command.ToString()+" "+(string)request.Body;
            return str;
        }
        public static explicit operator Request(string str)
        { Request request = new Request();
            char ch = ' ';
            int indexOfChar = str.IndexOf(ch);
            string body=str.Substring(indexOfChar+1); 
            string command = str.Remove(indexOfChar, str.Length - indexOfChar);
            request.Body=body;
            //request.Command= command;
            return request;
        }
        
    }
}
