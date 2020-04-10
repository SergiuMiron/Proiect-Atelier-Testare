using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace UnitTestProject1.PageObjects.AddTaskType
{
    public class AddTaskTypeBO
    {
        public string Name = "Test";
        public string NotifiedBeforeNr = "10";
        public string Owner { get; set; } = "Anthony Milan Nolan";
        public string EmailAddress = "anthony@orange.com";
        public string Description = "This is a description";
    }
}
