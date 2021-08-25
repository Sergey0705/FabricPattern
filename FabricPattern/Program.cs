using HrAPI;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FabricPattern
{
    public enum WorkerType
    {
        Manager,
        HeadOfDepartment,
        Director
    }
    class Program
    {
        static void Main(string[] args)
        {
            List<IWorker> workers = new List<IWorker>();

            CreateWorkers(workers);

            Console.WriteLine($"Общая зарплата с премиями: {workers.Sum(w => w.Salary)}"); 

            Console.ReadKey();
        }

        public static void CreateWorkers(List<IWorker> workers)
        {
            IWorker manager = WorkerFactory.GetWorkerInstance(WorkerType.Manager, 1, "Michail", "Ivanov", 50000);
            workers.Add(manager);

            IWorker headOfDepartment = WorkerFactory.GetWorkerInstance(WorkerType.HeadOfDepartment, 2, "Ivan", "Petrov", 100000);
            workers.Add(headOfDepartment);

            IWorker director = WorkerFactory.GetWorkerInstance(WorkerType.Director, 3, "Petr", "Sidorov", 300000);
            workers.Add(director);
        }
    }

    public class Manager:Worker
    {
        public override double Salary { get => base.Salary + (base.Salary * 0.20);}
    }

    public class HeadOfDepartment : Worker
    {
        public override double Salary { get => base.Salary + (base.Salary * 0.25); }
    }

    public class Director : Worker
    {
        public override double Salary { get => base.Salary + (base.Salary * 0.30); }
    }

    public static class WorkerFactory
    {
        public static IWorker GetWorkerInstance(WorkerType workerType, int id, string firstName, string lastName, double salary)
        {
            IWorker worker = null;

            switch (workerType)
            {
                case WorkerType.Manager:
                    worker = FactoryPattern<IWorker, Manager>.GetInstanse();
                    break;
                case WorkerType.HeadOfDepartment:
                    worker = FactoryPattern<IWorker, HeadOfDepartment>.GetInstanse();
                    break;
                case WorkerType.Director:
                    worker = FactoryPattern<IWorker, Director>.GetInstanse();
                    break;
                default:
                    break;
            }

            if (worker != null)
            {
                worker.Id = id;
                worker.FirstName = firstName;
                worker.LastName = lastName;
                worker.Salary = salary;
            }

            return worker;
        }
    }
}
