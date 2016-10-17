using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Common.Domain.Model;

namespace RoastPlanning.Domain.Model {
    public class RoastScheduleId : Identity {
        public RoastScheduleId()
            : base() {           
        }

        public RoastScheduleId(string id)
            : base(id) {            
        }
    }
}
