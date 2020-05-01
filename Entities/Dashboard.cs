using System.Collections.Generic;
using PrepPeered.Api.Data;

namespace PrepPeered.Api.Entities
{
    public class Dashboard : Entity
    {
        public IEnumerable<Review> Reviews { get; set; }

        public Person MyDetails { get; set; }

        public SetupCheck LastSetupCheck { get; set; }
    }
}