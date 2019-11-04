using Newtonsoft.Json;

namespace SkillsWorkflow.HrLink.Dto
{
    public class DataResponseVersion
    {
        [JsonProperty("")]
        public string Version { get; set; }
    }

    public class LongText
    {
        [JsonProperty("TEXT")]
        public long Text { get; set; }
    }

    public class StringText
    {
        [JsonProperty("TEXT")]
        public string Text { get; set; }
    }
}
