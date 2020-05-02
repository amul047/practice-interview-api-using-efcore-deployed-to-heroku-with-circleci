using PrepPeered.Api.Data;

namespace PrepPeered.Api.Entities
{
    public class Person : ReportableEntity
    {
        public string Name { get; set; }

        public string EmailAddress { get; set; }

        public bool IsRegistered { get; set; }

        public virtual Industry DesiredIndustry { get; set; }

        public virtual SeniorityLevel DesiredSeniorityLevel { get; set; }
    }
}