using System.Linq;
using Domain;
using Logic;
using Ninject;
using NUnit.Framework;
using TechTalk.SpecFlow;
using TechTalk.SpecFlow.Assist;

namespace Specifications
{
    [Binding]
    public sealed class ClockTimeQueueProcessorBindings
    {
        private FakeDataContext dataContext;

        [BeforeScenario]
        public void TestInit()
        {
            dataContext = new FakeDataContext();
        }

        private QueueProcessor GetSystemUnderTest()
        {
            var kernel = IntegrationTestsMockingKernel.Create(dataContext);
            return kernel.Get<QueueProcessor>();
        }

        [Given(@"de volgende kostenplaatsen staan geconfigureerd")]
        public void GegevenDeVolgendeKostenplaatsenStaanGeconfigureerd(Table table)
        {
            //var dtos = table.CreateSet<CostCenterDto>();
            //foreach (var costCenterDto in dtos)
            //{
            //    var costCenter = dataContext.GetOrCreateCostCenter(costCenterDto);
            //}
        }

        [Given(@"de volgende badges staan geconfigureerd")]
        public void GegevenDeVolgendeBadgesStaanGeconfigureerd(Table table)
        {
            //var dtos = table.CreateSet<BadgeUserDto>();
            //foreach (var badgeUserDto in dtos)
            //{
            //    var user = dataContext.GetOrCreateUser(badgeUserDto.Medewerker);

            //    var badgeUser = dataContext.CreateBadgeUser(user, badgeUserDto);
            //}
        }

        [Given(@"de volgende klokmomenten worden aangeboden")]
        public void GegevenDeVolgendeKlokmomentenWordenAangeboden(Table table)
        {
            var dtos = table.CreateSet<QueueItemDto>();
            foreach (var clockTimeQueueItemDto in dtos)
            {
                var clockTimeQueueItem = dataContext.CreateQueueItem(clockTimeQueueItemDto);
            }
        }

        [When(@"de kloktijden worden verwerkt")]
        public void AlsDeKloktijdenWordenVerwerkt()
        {
            GetSystemUnderTest().Process();
        }

        [Then(@"zijn er de volgende kloktijden")]
        public void DanZijnErDeVolgendeKloktijden(Table table)
        {
            var dtos = table.CreateSet<ItemDto>();
            foreach (var itemDto in dtos)
            {
                Assert.That(dataContext.Items.Select(qi => qi.TimeStamp), Contains.Item(itemDto.TimeStamp));
                if (itemDto.Type.HasValue())
                {
                    Assert.That(dataContext.Items.Select(i => i.Type.Value.ToString().ToLower()), Contains.Item(itemDto.Type.ToLower().Trim()));
                }
            }
        }
    }
}
