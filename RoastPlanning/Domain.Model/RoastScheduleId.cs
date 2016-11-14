using FirstPopCoffee.Common.Domain.Model;

namespace FirstPopCoffee.RoastPlanning.Domain.Model {
    public class RoastScheduleId : Identity {
        public RoastScheduleId()
            : base() {           
        }

        public RoastScheduleId(string id)
            : base(id) {            
        }
    }
}
