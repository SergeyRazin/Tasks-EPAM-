using Epam.ScrumPocker.Interfaces;
using Ninject;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Http;
using System.Web.Http.Dispatcher;
using System.Web.Mvc;

namespace Epam.ScrumPocker.WebApplication
{
    public class NinjectConfig
    {
        public static void Register(HttpConfiguration config)
        {
            IKernel _kernel = new StandardKernel();

            // dependencies here:
            _kernel.Bind<IRoomPool>().To<VotingRoomPoolStub>().InSingletonScope();
            _kernel.Bind<IUserStoryPool>().To<UserStoryPoolStub>().InSingletonScope();
            _kernel.Bind<INotificator>().To<MailNotificator>().InSingletonScope();
            _kernel.Bind<IUserPool>().To<UserPoolStub>().InSingletonScope();


            ControllerBuilder.Current.SetControllerFactory(new DefaultControllerFactory(
                new NinjectControllerActivators(_kernel)));

            GlobalConfiguration.Configuration.Services.Replace(typeof(IHttpControllerActivator),
                new NinjectHttpControllerActivator(_kernel));
        }
    }
}