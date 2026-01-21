using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MvvmBasics.Model
{
    public class ToDoData
    {
        public int Id { get;private set; }
        public string Content { get; set; }
        private static int idGenerator = 1;
        public ToDoData(string content)
        {
            Id = idGenerator++;
            Content = content;
        }
    }
}
