using System;
using System.Collections.Generic;
using System.Text;

namespace HrAPI
{
    public interface IWorker
    {
        int Id { get; set; }
        string FirstName { get; set; }
        string LastName { get; set; }
        double Salary { get; set; }
    }
}
