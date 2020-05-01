using PrepPeered.Api.Data;

namespace PrepPeered.Api.Entities
{
    public class Feedback : ReportableEntity
    {
        public int Rating { get; set; }

        public int Comment { get; set; }
    }
}