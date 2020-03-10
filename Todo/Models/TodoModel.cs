using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Todo.Models
{
    class TodoModel
    {
        private bool _isDone;
        private string _text;
        public DateTime CreationDateTime { get; set; } = DateTime.Now; //текущая дата в время
        public bool IsDone
        {
            get { return _isDone;}
            set { _isDone = value; }
        }
        public string Text
        {
            get { return _text; }
            set { _text = value; }
        }
    }
}