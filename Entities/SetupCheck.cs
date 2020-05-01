using PrepPeered.Api.Data;

namespace PrepPeered.Api.Entities
{
    public class SetupCheck : ReportableEntity
    {
        public Person Interviewee { get; set; }

        public bool IsVideoOn { get; set; }

        public bool IsAudioOn { get; set; }

        public bool IsVideoLagging { get; set; }

        public bool IsPersonInCorrectPosition { get; set; }

        public bool HasSufficientLighting { get; set; }
    }
}