using System.Collections.Generic;
using PrepPeered.Api.Data;

namespace PrepPeered.Api.Entities
{
    public class Review : Entity
    {
        public IEnumerable<Interview> Interviews { get; set; }

        public IEnumerable<Reminder> Reminders { get; set; }
    }
}