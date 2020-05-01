using PrepPeered.Api.Data;

namespace PrepPeered.Api.Entities
{
    public class Person : ReportableEntity
    {
        public string Name { get; set; }

        public string LoginName { get; set; }

        public bool IsRegistered { get; set; }

        public Industry DesiredIndustry { get; set; }

        public SeniorityLevel DesiredSeniorityLevel { get; set; }
    }
}