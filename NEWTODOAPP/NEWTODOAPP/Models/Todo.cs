using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace NEWTODOAPP.Models
{
    public class Todo
    {
        public int TodoId { get; set; }
        public string Title { get; set; }
        public string Status { get; set; }
    }
}

//outerHTML: "<div class=\"todo_block\" id=\"Done\">\n                    <strong>Done</strong>\n                <div class=\"ToDoList\" draggable=\"true\" id=\"TodoIdundefined\"><div class=\"todo\"><input class=\"text\" type=\"text\" readonly=\"readonly\"></div><div class=\"actions\"><button class=\"edit\">Edit</button><button class=\"delete\">X</button></div></div></div>"
