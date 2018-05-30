using Moq;
using Ninject;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using BookStore.Domain.Abstract;
using BookStore.Domain.Entities;
using BookStore.Domain.Concrete;
using System.Configuration;
using BookStore.WebUI.Infrastructure.Abstract;
using BookStore.WebUI.Infrastructure.Concrete;

namespace BookStore.WebUI.Infrastructure
{

    public class NinjectDependencyResolver : IDependencyResolver
    {
        private IKernel kernel;
        public NinjectDependencyResolver(IKernel kernelParam)
        {
            kernel = kernelParam;
            AddBindings();
        }

        
        public object GetService(Type serviceType)
        {
            return kernel.TryGet(serviceType);
        }

        public IEnumerable<object> GetServices(Type serviceType)
        {
            return kernel.GetAll(serviceType);
        }
        private void AddBindings()
        {

            //We Add Binding Here 

            //Mock<IBookRepository> mock = new Mock<IBookRepository>();
            //mock.Setup(b => b.Books).Returns(
            //    new List<Book> { new Book {Title="SQL Server DB",Price=50M },
            //                     new Book {Title="Asp.Net Mvc 5",Price=90M },
            //                     new Book { Title="Web Client",Price=87M} }
            //    );

            EmailSettings emailSettings = new EmailSettings
            {
                WriteAsFile = bool.Parse(ConfigurationManager.AppSettings["Email.WriteAsFile"] ?? "false")
            };


            kernel.Bind<IBookRepository>().To<EFBookRepository>();
            kernel.Bind<IAuthProvider>().To<FormsAuthProvider>();

            kernel.Bind<IOrderProcessor>().To<EmailOrderProcessor>()
            .WithConstructorArgument("setting", emailSettings);
        }

    }
}