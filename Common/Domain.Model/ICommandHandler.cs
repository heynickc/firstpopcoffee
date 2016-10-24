using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Common.Domain.Model {
    public interface ICommandHandler<TCommand> where TCommand : Message {
        void Handle(TCommand message);
    }
}
