using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Newtonsoft.Json;
using Todo.Models;

namespace Todo.Services
{
    class FileIOService
    {
        private readonly string Path; // файл в который будет сохраняться информация
        public FileIOService(string path) // конструктор данной переменной
        {
            Path = path;
        }
        public BindingList<TodoModel> LoadData() //метод загрузки из файла
        {
            var fileExist = File.Exists(Path); // вначале идет проверка создан ли файл, если нет
            if (!fileExist)
            {
                File.CreateText(Path).Dispose(); // то мы его создаем, а затем создаем новый список, пока пустой
                return new BindingList<TodoModel>();
            }

            using (var reader = File.OpenText(Path)) // если файл создан, то считываем его, дестерилизуем и на выходе получаем fileText
            {
                var fileText = reader.ReadToEnd();
                return JsonConvert.DeserializeObject<BindingList<TodoModel>>(fileText);
            }
        }
        public void SaveData(BindingList<TodoModel> todoData) // метод сохранения в файл
        {
            using (StreamWriter writer = File.CreateText(Path))
            {
                string output = JsonConvert.SerializeObject(todoData);
                writer.Write(output);
            }
        }
    }
}