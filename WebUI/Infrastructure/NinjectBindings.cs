using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using FirstPopCoffee.Common.Domain.Model;
using FirstPopCoffee.Common.Events;
using FirstPopCoffee.RoastPlanning.Application;
using FirstPopCoffee.RoastPlanning.Domain.Model;
using Ninject.Modules;
using WebUI.ReadModel;

namespace WebUI.Infrastructure
{
    public class NinjectBindings : NinjectModule
    {
        public override void Load()
        {
            Bind<FakeBus>().ToMethod(ctx =>
            {
                var bus = new FakeBus();
                var storage = new EventStore(bus);
                var repo = new EventSourcedRepository<RoastSchedule>(storage);
                var roastPlanningContext = new RoastPlanningContext();
                bus.RegisterHandler<CreateNewRoastScheduleCommand>(
                    new CreateNewRoastScheduleCommandHandler(repo).Handle);
                bus.RegisterHandler<ChooseRoastDaysForRoastScheduleCommand>(
                    new ChooseRoastDaysForRoastScheduleCommandHandler(repo).Handle);
                bus.RegisterHandler<RoastScheduleCreatedEvent>(
                    new RoastScheduleView(roastPlanningContext).Handle);
                return bus;
            }).InSingletonScope();

            // need to send RoastScheduleContext.RoastSchedules DbSet as argument
            Bind<IRoastPlanningReadModel>().To<FakeRoastPlanningReadModel>().InSingletonScope();
        }
    }
}