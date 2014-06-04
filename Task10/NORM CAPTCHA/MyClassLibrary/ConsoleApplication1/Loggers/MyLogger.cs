using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Configuration;

namespace ConsoleApplication1.Loggers
{
    class MyLogger
    {
        private void removeFirstLine(string path0)
        {
            //прочитать все содержимое файла , записать это содержимое в массив строк
            var rows = File.ReadAllLines(path0);
            var list = rows.ToList();

            //удалить первую строку 
            if(list.Count>0)
                list.RemoveAt(0);

            //записпть это содержимое в новый файл(старый удалить)
            File.WriteAllLines(path0,list.ToArray());
        }

        public void Error(string messge0)
        {
            //получить путь  из App.config
            var path = ConfigurationManager.AppSettings["Path"];

            //строка сообщения
            string message = string.Format("|ERROR| {0} {1:G}\n", DateTime.Now, messge0);

            //записать в файл по пути path строку message0
            File.AppendAllText(path, message);

            //если размер файла больше 10000 байт , удалить первую строку 
            while (new FileInfo(path).Length>10000)
            {
                removeFirstLine(path);
            }


        }
    }
}
