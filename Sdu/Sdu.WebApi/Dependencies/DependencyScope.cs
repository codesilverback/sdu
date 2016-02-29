using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Http.Dependencies;
using Castle.MicroKernel;
using Castle.MicroKernel.Lifestyle;

namespace Sdu.WebApi.Dependencies
{
     public class DependencyScope : IDependencyScope
        {
        //mainly stolen from here: http://www.macaalay.com/2014/08/27/using-castle-windsor-with-web-api-apicontroller/
        private readonly IKernel kernel;

            private readonly IDisposable disposable;

            public DependencyScope(IKernel kernel)
            {
                this.kernel = kernel;
                disposable = kernel.BeginScope();
            }

            public object GetService(Type type)
            {
                return kernel.HasComponent(type) ? kernel.Resolve(type) : null;
            }

            public IEnumerable<object> GetServices(Type type)
            {
                return kernel.ResolveAll(type).Cast<object>();
            }

            public void Dispose()
            {
                disposable.Dispose();
            }
        }
    
}