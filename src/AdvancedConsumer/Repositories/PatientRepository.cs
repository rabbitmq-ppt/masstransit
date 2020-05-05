using System;
using System.Collections.Generic;
using System.Text;

namespace AdvancedConsumer.Repositories
{
    internal class PatientRepository : IRepository
    {
        public void DoSomething()
        {
            Console.WriteLine("DoSomething in PatientRepository");
        }
    }
}
