using System;
using System.Collections.Generic;
using System.Web.Http.Dependencies;
using Unity;
using Unity.Exceptions;

namespace EndProject.IoC.Unity
{
    public class UnityResolve : IDependencyResolver

    {
    protected IUnityContainer container;

    //teste merge
    public UnityResolve(IUnityContainer container)
    {
        if (container == null)
            throw new ArgumentNullException("container");
        this.container = container;
    }

    public object GetService(Type serviceType)
    {
        try
        {
            return container.Resolve(serviceType);
        }
        catch (ResolutionFailedException ex)
        {
            return null;
        }
    }

    public IEnumerable<object> GetServices(Type serviceType)
    {
        try
        {
            return container.ResolveAll(serviceType);
        }
        catch (ResolutionFailedException)
        {
            return new List<object>();
        }
    }

    public IDependencyScope BeginScope()
    {
        var child = container.CreateChildContainer();
        return new UnityResolve(child);
    }

    public void Dispose()
    {
        container.Dispose();
    }
    }
}
