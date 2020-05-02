using PrepPeered.Api.Data;

namespace PrepPeered.Api.Entities
{
    public class Question : ReportableEntity
    {
        public virtual Feedback Feedback { get; set; }
    }
}