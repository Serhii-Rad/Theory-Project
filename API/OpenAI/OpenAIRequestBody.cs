using Newtonsoft.Json;

namespace API.OpenAI
{
    public class OpenAIRequestBody
    {
        [JsonProperty("model")]
        public string Model { get; set; } = "text-davinci-003";

        /// <summary>
        /// Request text
        /// </summary>
        [JsonProperty("prompt")]
        public string Prompt { get; set; }

        /// <summary>
        /// The maximum number of tokens to generate in the completion.
        /// </summary>
        [JsonProperty("max_tokens")]
        public int Max_tokens { get; set; } = 200;

        /// <summary>
        /// What sampling temperature to use. Higher values means the model will take more risks. 
        /// Try 0.9 for more creative applications, and 0 (argmax sampling) for ones with a well-defined answer.
        /// We generally recommend altering this or top_p but not both.
        /// </summary>
        [JsonProperty("temperature")]
        public float Temperature { get; set; } = 0;

        /// <summary>
        /// An alternative to sampling with temperature, called nucleus sampling, where the model considers the results of the tokens with top_p probability mass. 
        /// So 0.1 means only the tokens comprising the top 10% probability mass are considered.
        /// </summary>
        [JsonProperty("top_p")]
        public float Top_p { get; set; } = 1;

        /// <summary>
        /// How many completions to generate for each prompt.
        /// Note: Because this parameter generates many completions, it can quickly consume your token quota.
        /// Use carefully and ensure that you have reasonable settings for max_tokens and stop.
        /// </summary>
        [JsonProperty("n")]
        public int N { get; set; } = 1;

        /// <summary>
        /// Whether to stream back partial progress. 
        /// If set, tokens will be sent as data-only server-sent events as they become available, with the stream terminated by a data: [DONE] message.
        /// </summary>
        [JsonProperty("stream")]
        public bool Stream { get; set; } = false;

        /// <summary>
        /// nclude the log probabilities on the logprobs most likely tokens, as well the chosen tokens. 
        /// For example, if logprobs is 5, the API will return a list of the 5 most likely tokens. 
        /// The API will always return the logprob of the sampled token, so there may be up to logprobs+1 elements in the response.
        /// The maximum value for logprobs is 5. If you need more than this, please contact us through our Help center and describe your use case.
        /// </summary>
        [JsonProperty("logprobs")]
        public object? Logprobs { get; set; }

        /// <summary>
        /// Up to 4 sequences where the API will stop generating further tokens. The returned text will not contain the stop sequence.
        /// </summary>
        [JsonProperty("stop")]
        public string Stop { get; set; } = @"\n";

        ///// <summary>
        ///// The suffix that comes after a completion of inserted text.
        ///// </summary>
        //[JsonProperty("suffix")]
        //public string? Suffix { get; set; }

        ///// <summary>
        ///// Echo back the prompt in addition to the completion
        ///// </summary>
        //[JsonProperty("echo")]
        //public bool? Echo { get; set; }

        ///// <summary>
        ///// A unique identifier representing your end-user, which can help OpenAI to monitor and detect abuse
        ///// </summary>
        //[JsonProperty("user")]
        //public string? User { get; set; } 
    }
}
