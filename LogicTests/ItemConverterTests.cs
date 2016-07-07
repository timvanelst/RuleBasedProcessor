using System;
using Domain;
using Logic;
using Ninject;
using Ninject.MockingKernel.Moq;
using NUnit.Framework;

namespace LogicTests
{
    [TestFixture]
    public class ItemConverterTests
    {
        private MoqMockingKernel kernel;

        [SetUp]
        public void TestSetup()
        {
            kernel = new MoqMockingKernel();

            kernel.Bind<IQueueItemHandler>().To<TimeStampQueueItemHandler>();
            kernel.Bind<IQueueItemHandler>().To<QueueItemWithTypeQueueItemHandler>();

            kernel.Bind<ITypeAdapter>().To<DefaultTypeAdapter>();
        }


        public IItemConverter GetSystemUnderTest()
        {
            return kernel.Get<ItemConverter>();
        }

        [Test]
        public void Create_sets_TimeStamp()
        {
            var queueItem = new QueueItem
            {
                TimeStamp = new DateTime(2016, 5, 18, 12, 1, 0)
            };
            var actualItem = GetSystemUnderTest().Create(queueItem);
            Assert.That(actualItem.TimeStamp, Is.EqualTo(queueItem.TimeStamp));
        }


        [TestCase("in", ItemType.In)]
        public void Create_sets_ItemType_for_QueueItem_with_ItemType(string inputType, ItemType expectedItemType)
        {
            var queueItem = new QueueItemWithType
            {
                Type = inputType
            };
            var actualItem = GetSystemUnderTest().Create(queueItem);
            Assert.That(actualItem.Type, Is.EqualTo(expectedItemType));
        }
    }
}
