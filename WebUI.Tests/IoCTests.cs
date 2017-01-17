using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using FirstPopCoffee.Common;
using FirstPopCoffee.Common.Domain.Model;
using FirstPopCoffee.Common.Events;
using FirstPopCoffee.RoastPlanning.Domain.Model;
using Ninject;
using Ninject.Extensions.Conventions;
using WebUI.DependencyResolution;
using WebUI.Infrastructure;
using WebUI.Models;
using WebUI.ReadModel;
using Xunit;
using Xunit.Abstractions;

namespace WebUI.Tests
{
    public class IoCTests
    {
        private readonly ITestOutputHelper _output;
        public IoCTests(ITestOutputHelper output)
        {
            _output = output;
        }

        [Fact]
        public void Bind_EventStore()
        {
            using (var kernel = new StandardKernel(new RoastPlanningNinjectModule()))
            {
                var eventStore = kernel.Get<IEventStore>();
                Assert.IsType<EventStore>(eventStore);
            }
        }

        [Fact]
        public void Bind_EventSourcedRepository()
        {
            using (var kernel = new StandardKernel(new RoastPlanningNinjectModule()))
            {
                var eventSourcedRepository = kernel.Get<EventSourcedRepository<RoastSchedule>>();
                Assert.IsType<EventSourcedRepository<RoastSchedule>>(eventSourcedRepository);
            }
        }

        [Fact]
        public void Bind_RoastPlanningContext()
        {
            using (var kernel = new StandardKernel(new RoastPlanningNinjectModule()))
            {
                var roastPlanningContext = kernel.Get<IRoastPlanningContext>();
                Assert.IsType<RoastPlanningContext>(roastPlanningContext);
            }
        }

        [Fact]
        public void Bind_RoastScheduleView()
        {
            using (var kernel = new StandardKernel(new RoastPlanningNinjectModule()))
            {
                var roastScheduleView = kernel.Get<RoastScheduleView>();
                Assert.IsType<RoastScheduleView>(roastScheduleView);
            }
        }

        [Fact]
        public void Bind_EventPublisherCommandSender()
        {
            using (var kernel = new StandardKernel(new RoastPlanningNinjectModule()))
            {
                var fakeBusAsPublisher = kernel.Get<IEventPublisher>();
                var fakeBusAsSender = kernel.Get<ICommandSender>();
                Assert.IsType<FakeBus>(fakeBusAsPublisher);
                Assert.IsType<FakeBus>(fakeBusAsSender);
            }
        }

        //[Fact]
        //public void Bind_FakeBus()
        //{
        //    using (var kernel = new StandardKernel(new RoastPlanningNinjectModule()))
        //    {
        //        var bus = kernel.Get<FakeBus>();
        //        Assert.IsType<FakeBus>(bus);
        //    }
        //}

        [Fact]
        public void Bind_RoastPlanningReadModel()
        {
            using (var kernel = new StandardKernel(new RoastPlanningNinjectModule()))
            {
                var readModel = kernel.Get<FakeRoastPlanningReadModel>();
                Assert.IsType<FakeRoastPlanningReadModel>(readModel);
            }
        }

        [Fact]
        public void RoastModelView_same_DbSet_as_RoastPlanningContext()
        {
            using (var kernel = new StandardKernel(new RoastPlanningNinjectModule()))
            {
                var readModelDbContext = kernel.Get<IRoastPlanningContext>();
                var readModel = kernel.Get<IRoastPlanningReadModel>();
                readModelDbContext.RoastSchedules.Add(new RoastScheduleViewModel(Guid.NewGuid(), DateTime.Now));

                Assert.Same(readModelDbContext.RoastSchedules, readModel.RoastSchedules);
                Assert.Equal(
                    readModel.RoastSchedules.ToList().Count, 
                    readModelDbContext.RoastSchedules.ToList().Count);
            }
        }

        [Fact]
        public void FakeBus_is_same_as_IEventPublisher_Binding()
        {
            using (var kernel = new StandardKernel(new RoastPlanningNinjectModule()))
            {
                var fakeBusAsPublisher = kernel.Get<IEventPublisher>();
                var fakeBusAsSender = kernel.Get<ICommandSender>();
                Assert.IsType<FakeBus>(fakeBusAsPublisher);
                Assert.IsType<FakeBus>(fakeBusAsSender);

                Assert.Same(fakeBusAsPublisher, fakeBusAsSender);
            }
        }
    }
}
