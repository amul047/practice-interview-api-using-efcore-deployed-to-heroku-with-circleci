using System.Collections.Generic;
using PrepPeered.Api.Data;

namespace PrepPeered.Api.Entities
{
    public class Interview : ReportableEntity
    {
        public virtual Person Interviewee { get; set; }

        public virtual Person Interviewer { get; set; }

        public virtual IEnumerable<Question> Questions { get; set; }

        public virtual Feedback OverallFeedback { get; set; }
    }
}