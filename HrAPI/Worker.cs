using System;
using System.Collections.Generic;
using System.Text;

namespace HrAPI
{
    public class Worker : IWorker
    {
        public int Id { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public virtual double Salary { get; set; }
    }
}
