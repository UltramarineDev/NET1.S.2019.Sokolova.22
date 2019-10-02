using XMLGenerator.DAL;
using XMLGenerator.DAL.Interface;
using Ninject;
using XMLGenerator.BLL;
using XMLGenerator.BLL.Interface;

namespace DependencyResolver
{
    public static class ResolverModule
    {
        public static void ConfigurateResolverConsole(this IKernel kernel)
        {
            kernel.Bind<IConverter>().To<XMLConverter>();
            kernel.Bind<IDataReader>().To<TXTReader>().InSingletonScope();
        }
    }
}
