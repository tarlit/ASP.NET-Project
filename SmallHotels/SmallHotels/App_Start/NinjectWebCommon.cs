[assembly: WebActivatorEx.PreApplicationStartMethod(typeof(SmallHotels.App_Start.NinjectWebCommon), "Start")]
[assembly: WebActivatorEx.ApplicationShutdownMethodAttribute(typeof(SmallHotels.App_Start.NinjectWebCommon), "Stop")]

namespace SmallHotels.App_Start
{
    using System;
    using System.Web;

    using Microsoft.Web.Infrastructure.DynamicModuleHelper;

    using Ninject;
    using Ninject.Web.Common;
    using Common.Contracts;
    using Common;
    using DataServices.Contracts;
    using DataServices;
    using Data.Contracts;
    using Data.EfDbSetWrappers;
    using Data;

    public static class NinjectWebCommon 
    {
        private static readonly Bootstrapper bootstrapper = new Bootstrapper();

        /// <summary>
        /// Starts the application
        /// </summary>
        public static void Start() 
        {
            DynamicModuleUtility.RegisterModule(typeof(OnePerRequestHttpModule));
            DynamicModuleUtility.RegisterModule(typeof(NinjectHttpModule));
            bootstrapper.Initialize(CreateKernel);
        }
        
        /// <summary>
        /// Stops the application.
        /// </summary>
        public static void Stop()
        {
            bootstrapper.ShutDown();
        }
        
        /// <summary>
        /// Creates the kernel that will manage your application.
        /// </summary>
        /// <returns>The created kernel.</returns>
        private static IKernel CreateKernel()
        {
            var kernel = new StandardKernel();
            try
            {
                kernel.Bind<Func<IKernel>>().ToMethod(ctx => () => new Bootstrapper().Kernel);
                kernel.Bind<IHttpModule>().To<HttpApplicationInitializationHttpModule>();

                RegisterServices(kernel);
                return kernel;
            }
            catch
            {
                kernel.Dispose();
                throw;
            }
        }

        /// <summary>
        /// Load your modules or register your services here!
        /// </summary>
        /// <param name="kernel">The kernel.</param>
        private static void RegisterServices(IKernel kernel)
        {
            // kernel.Bind<IEfDbSetWrapper<T>>().To<EfDbSetWrapper<T>>().InRequestScope();
            kernel.Bind<IDbContextSaveChanges>().To<SmallHotelsContext>().InRequestScope();

            kernel.Bind<IMappingService>().To<MappingService>();

            //kernel.Bind<IUserService>().To<UserService>();
            kernel.Bind<IUserInfoService>().To<UserInfoService>();
            kernel.Bind<IRegionService>().To<RegionService>();
            kernel.Bind<IHotelService>().To<HotelService>();
            kernel.Bind<ICartService>().To<CartService>();
            kernel.Bind<IBookRoomService>().To<BookRoomService>();
            kernel.Bind<IUtilitiesService>().To<UtilitiesService>();

            //kernel.Bind<IRegionFactory>().ToFactory().InSingletonScope();
            //kernel.Bind<ICommentFactory>().ToFactory().InSingletonScope();
            //kernel.Bind<ILikeFactory>().ToFactory().InSingletonScope();
            //kernel.Bind<IHotelFactory>().ToFactory().InSingletonScope();
            //kernel.Bind<IRoomFactory>().ToFactory().InSingletonScope();
            //kernel.Bind<IBookRoomFactory>().ToFactory().InSingletonScope();
        }        
    }
}
