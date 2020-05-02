using System.Collections.Generic;
using PrepPeered.Api.Data;

namespace PrepPeered.Api.Entities
{
    public class Dashboard : Entity
    {
        public virtual IEnumerable<Review> Reviews { get; set; }

        public virtual Person MyDetails { get; set; }

        public virtual SetupCheck LastSetupCheck { get; set; }
    }
}