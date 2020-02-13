using Autofac;
using Autofac.Extras.DynamicProxy;
using Business.Abstract;
using Business.Concrete;
using Business.Providers;
using Castle.DynamicProxy;
using Core.Utilities.Interceptors;
using DataAccess.Abstract;
using DataAccess.Concrete;
using System;
using System.Collections.Generic;
using System.Text;

namespace Business.DependencyResolvers
{
    public class AutofacBusinessModule : Module
    {
        protected override void Load(ContainerBuilder builder)
        {
            builder.RegisterType<UserManager>().As<IUserService>();
            builder.RegisterType<EfUserDal>().As<IUserDal>();

            builder.RegisterType<AuthManager>().As<IAuthService>();

            builder.RegisterType<CustomerManager>().As<ICustomerService>();
            builder.RegisterType<EfCustomerDal>().As<ICustomerDal>();
            builder.RegisterType<EfCustomerUserDal>().As<ICustomerUserDal>();

            builder.RegisterType<RoleManager>().As<IRoleService>();
            builder.RegisterType<EfRoleDal>().As<IRoleDal>();

            builder.RegisterType<DataSheetManager>().As<IDataSheetService>();
            builder.RegisterType<EfDataSheetDal>().As<IDataSheetDal>();

            builder.RegisterType<FileManager>().As<IFileService>();
            builder.RegisterType<EfFileDal>().As<IFileDal>();

            builder.RegisterType<CommentManager>().As<ICommentService>();
            builder.RegisterType<EfCommentDal>().As<ICommentDal>();

            builder.RegisterType<SettingsManager>().As<ISettingsService>();
            builder.RegisterType<EfMailSettingDal>().As<IMailSettingDal>();

            builder.RegisterType<EfCountryDal>().As<ICountryDal>();
            builder.RegisterType<EfCityDal>().As<ICityDal>();
            builder.RegisterType<EfDistrictDal>().As<IDistrictDal>();

            builder.RegisterType<AddressManager>().As<IAddressService>();

            builder.RegisterType<UserPasswordChangeManager>().As<IUserPasswordChangeService>();
            builder.RegisterType<EfUserPasswordChangeDal>().As<IUserPasswordChangeDal>();

            builder.RegisterType<EmailProvider>().As<IEmailProvider>();

            var assembly = System.Reflection.Assembly.GetExecutingAssembly();
            builder.RegisterAssemblyTypes(assembly).AsImplementedInterfaces()
                .EnableInterfaceInterceptors(new ProxyGenerationOptions 
                { 
                    Selector = new AspectInterceptorSelector()
                }).SingleInstance();
        }
    }
}
