using Ninject.MockingKernel.Moq;

namespace Specifications
{
    public static class IntegrationTestsMockingKernel
    {
        public static MoqMockingKernel Create(FakeDataContext dataContext)
        {
            var integrationTestsBindings = new IntegrationTestsBindings(dataContext);
            var kernel = new MoqMockingKernel();
            kernel = integrationTestsBindings.Load(kernel);
            return kernel;
        }
    }
}