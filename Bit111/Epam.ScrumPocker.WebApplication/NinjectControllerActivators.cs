using Ninject;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Http.Controllers;
using System.Web.Http.Dispatcher;
using System.Web.Mvc;

namespace Epam.ScrumPocker.WebApplication
{
    // for "simple" controllers
    public class NinjectControllerActivators: IControllerActivator
    {
        private IKernel _kernel;

        public NinjectControllerActivators(IKernel kernel)
        {
            _kernel = kernel;
        }

        public IController Create(System.Web.Routing.RequestContext requestContext, Type controllerType)
        {
            return (IController)_kernel.Get(controllerType);
        }
    }

    // for ApiControllers
    public class NinjectHttpControllerActivator : IHttpControllerActivator
    {
        private IKernel _kernel;

        public NinjectHttpControllerActivator(IKernel kernel)
        {
            _kernel = kernel;
        }

        public IHttpController Create(System.Net.Http.HttpRequestMessage request, HttpControllerDescriptor controllerDescriptor, Type controllerType)
        {
            return (IHttpController)_kernel.Get(controllerType);
        }
    }
}