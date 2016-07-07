using Logic;
using Ninject.MockingKernel.Moq;
using Ninject.Syntax;
using Repository;

namespace Specifications
{
    public class IntegrationTestsBindings
    {
        public IntegrationTestsBindings(FakeDataContext fakeDataContext)
        {
            this.DataContext = fakeDataContext;
        }

        private readonly FakeDataContext DataContext;
        private MoqMockingKernel kernel;

        public MoqMockingKernel Load(MoqMockingKernel kernel)
        {
            this.kernel = kernel;
            Bind<IDataContext>().ToConstant<FakeDataContext>(DataContext);
            Bind<IQueueItemHandler>().To<TimeStampQueueItemHandler>();
            Bind<IQueueItemHandler>().To<QueueItemWithTypeQueueItemHandler>();

            Bind<IQueueItemRepository>().To<QueueItemRepository>();

            Bind<IQueueManager>().To<QueueManager>();
            Bind<IQueueItemProcessor>().To<QueueItemProcessor>();
            Bind<IItemConverter>().To<ItemConverter>();
            Bind<IItemManager>().To<ItemManager>();
            Bind<ITypeAdapter>().To<DefaultTypeAdapter>();

            return kernel;
        }

        private IBindingToSyntax<T> Bind<T>()
        {
            return kernel.Bind<T>();
        }
    }
}