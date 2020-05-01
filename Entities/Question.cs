using PrepPeered.Api.Data;

namespace PrepPeered.Api.Entities
{
    public class Question : ReportableEntity
    {
        public Feedback Feedback { get; set; }
    }
}