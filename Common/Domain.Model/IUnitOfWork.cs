using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FirstPopCoffee.Common.Domain.Model {
    public interface IUnitOfWork {
        void Commit();
        void Rollback();
    }
}
