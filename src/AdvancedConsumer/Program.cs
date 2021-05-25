using AdvancedConsumer.DI;
using Castle.Windsor;
using GreenPipes;
using MassTransit;
using System;

namespace AdvancedConsumer
{
    class Program
    {
        static void Main(string[] args)
        {
            var container = new WindsorContainer();
            container.Install(new ConsumerInstaller());

            Console.WriteLine("[Advanced Consumer]");
            var busControl = container.Resolve<IBusControl>();

            busControl.Start();

            Console.ReadLine();

            busControl.Stop();
        }
    }
}
