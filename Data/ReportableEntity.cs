using System;

namespace PrepPeered.Api.Data
{
    public class ReportableEntity : Entity
    {
        public DateTime Created { get; set; }

        public DateTime Modified { get; set; }
    }
}