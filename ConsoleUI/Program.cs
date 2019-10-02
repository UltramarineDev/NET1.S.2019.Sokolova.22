using Ninject;
using XMLGenerator.BLL.Interface;
using DependencyResolver;
using System;

namespace ConsoleUI
{
    class Program
    {
        private static readonly IKernel resolver;

        static Program()
        {
            resolver = new StandardKernel();
            resolver.ConfigurateResolverConsole();
        }

        static void Main(string[] args)
        {
            var service = resolver.Get<IConverter>();
            var a = service.Convert();
            Console.WriteLine(a);
        }
    }
}

