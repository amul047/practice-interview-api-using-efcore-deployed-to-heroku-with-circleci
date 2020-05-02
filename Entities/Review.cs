using System.Collections.Generic;
using PrepPeered.Api.Data;

namespace PrepPeered.Api.Entities
{
    public class Review : Entity
    {
        public virtual IEnumerable<Interview> Interviews { get; set; }

        public virtual IEnumerable<Tip> Tips { get; set; }
    }
}