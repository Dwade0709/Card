using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Server.Db.DataModel
{
    public class BaseEntity : IEntity<long>, IAuditableEntity<long>
    {
        public long Id { get; set; }

        public DateTime CreatedOn { get; }

        public DateTime ModifiedOn { get; }
    }
}
