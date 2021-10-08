using Autofac;
using Autofac.Extras.DynamicProxy;
using Business.Abstract;
using Business.Concrete;
using Castle.DynamicProxy;
using Core.Utilities.İnterceptors;
using Core.Utilities.Security.JWT;
using DataAccess.Abstract;
using DataAccess.Concrete;
using DataAccess.Concrete.EntityFramework;
using Microsoft.AspNetCore.Http;
using System;
using System.Collections.Generic;
using System.Text;

namespace Business.DependencyResolvers.Autofac
{
    public class AutofacBusinessModule : Module
    {
        protected override void Load(ContainerBuilder builder)
        {        
                       
            builder.RegisterType<CustomerManager>().As<ICustomerService>().SingleInstance();
            builder.RegisterType<EfCustomerDal>().As<ICustomerDal>().SingleInstance();

            builder.RegisterType<UserManager>().As<IUserService>().SingleInstance();
            builder.RegisterType<EfUserDal>().As<IUserDal>().SingleInstance();

            builder.RegisterType<FaultInfoManager>().As<IFaultInfoService>().SingleInstance();
            builder.RegisterType<EfFaultInfoDal>().As<IFaultInfoDal>().SingleInstance();

            builder.RegisterType<MadeProcessManager>().As<IMadeProcessService>().SingleInstance();
            builder.RegisterType<EfMadeProcessDal>().As<IMadeProcessDal>().SingleInstance();

            builder.RegisterType<MaterialUsedManager>().As<IMaterialUsedService>().SingleInstance();
            builder.RegisterType<EfMaterialUsedDal>().As<IMaterialUsedDal>().SingleInstance();

            builder.RegisterType<ProcessControlManager>().As<IProcessControlService>().SingleInstance();
            builder.RegisterType<EfProcessControlDal>().As<IProcessControlDal>().SingleInstance();

            builder.RegisterType<ProductInfoManager>().As<IProductInfoService>().SingleInstance();
            builder.RegisterType<EfProductInfoDal>().As<IProductInfoDal>().SingleInstance();

            builder.RegisterType<StateControlManager>().As<IStateControlService>().SingleInstance();
            builder.RegisterType<EfStateControlDal>().As<IStateControlDal>().SingleInstance();

            var assembly = System.Reflection.Assembly.GetExecutingAssembly();

            builder.RegisterAssemblyTypes(assembly).AsImplementedInterfaces()
                .EnableInterfaceInterceptors(new ProxyGenerationOptions()
                {
                    Selector = new AspectInterceptorSelector()//Sınıflara Asbectleri var mı 
                }).SingleInstance();
        }
    }
}
