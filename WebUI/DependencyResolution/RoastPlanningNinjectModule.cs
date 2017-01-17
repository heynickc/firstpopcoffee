using System;
using System.Collections.Generic;
using FirstPopCoffee.Common.Domain.Model;
using FirstPopCoffee.Common.Events;
using FirstPopCoffee.RoastPlanning.Application;
using FirstPopCoffee.RoastPlanning.Domain.Model;
using Ninject;
using Ninject.Extensions.Factory;
using Ninject.Modules;
using WebUI.Infrastructure;
using WebUI.Models;
using WebUI.ReadModel;

namespace WebUI.DependencyResolution
{
    public class RoastPlanningNinjectModule : NinjectModule
    {
        public override void Load()
        {
            Bind<IEventStore>().To<EventStore>();
            Bind<IRepository<RoastSchedule>>().To<EventSourcedRepository<RoastSchedule>>();

            //need to send RoastScheduleContext.RoastSchedules DbSet as argument
            Bind<FakeDbSet<RoastScheduleViewModel>>().ToSelf().InSingletonScope();                                                                                                                                                               
            Bind<IRoastPlanningContext>().To<RoastPlanningContext>();
            Bind<IRoastPlanningReadModel>().To<FakeRoastPlanningReadModel>();

            Bind<IEventPublisher, ICommandSender>().To<FakeBus>()
                .InSingletonScope()
                .OnActivation(bus =>
                    {
                        bus.RegisterHandler<CreateNewRoastScheduleCommand>(
                            new RoastScheduleCommandHandlers(Kernel.Get<IRepository<RoastSchedule>>()).Handle);
                        bus.RegisterHandler<ChooseRoastDaysForRoastScheduleCommand>(
                            new RoastScheduleCommandHandlers(Kernel.Get<IRepository<RoastSchedule>>()).Handle);
                        bus.RegisterHandler<RoastScheduleCreatedEvent>(
                            new RoastScheduleView(Kernel.Get<IRoastPlanningContext>()).Handle);
                    });
        }
    }
}