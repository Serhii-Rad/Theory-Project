using Newtonsoft.Json;

namespace API.OpenAI
{
    public class OpenAIResponseBody
    {
        [JsonProperty("id")]
        public string? Id { get; set; }

        [JsonProperty("object")]
        public string? Object { get; set; }

        [JsonProperty("created")]
        public int Created { get; set; }

        [JsonProperty("model")]
        public string? Model { get; set; }

        [JsonProperty("choices")]
        public List<Choice>? Choices { get; set; }

        [JsonProperty("usage")]
        public Usage? Usage { get; set; }
    }

    public class Choice
    {
        [JsonProperty("text")]
        public string? Text { get; set; }

        [JsonProperty("index")]
        public int Index { get; set; }

        [JsonProperty("logprobs")]
        public object? Logprobs { get; set; }

        [JsonProperty("finish_reason")]
        public string? FinishReason { get; set; }
    }

    public class Usage
    {
        [JsonProperty("prompt_tokens")]
        public int? Prompt_tokens { get; set; }

        [JsonProperty("completion_tokens")]
        public int? Completion_tokens { get; set; }

        [JsonProperty("total_tokens")]
        public int? Total_tokens { get; set; }
    }
}
