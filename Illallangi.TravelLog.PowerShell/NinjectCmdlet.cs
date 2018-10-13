using System.Management.Automation;
using Ninject;
using Ninject.Modules;

namespace Illallangi.TravelLog
{
    public abstract class NinjectCmdlet<TModule> : PSCmdlet where TModule: INinjectModule, new()
    {
        private StandardKernel Kernel { get; } = new StandardKernel(new TModule());

        protected T Get<T>()
        {
            return Kernel.Get<T>();
        }
    }
}