using System.Collections.Generic;
using PrepPeered.Api.Data;

namespace PrepPeered.Api.Entities
{
    public class Interview : ReportableEntity
    {
        public Person Interviewee { get; set; }

        public Person Interviewer { get; set; }

        public IEnumerable<Question> Questions { get; set; }

        public Feedback OverallFeedback { get; set; }
    }
}