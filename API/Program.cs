using API;
using API.OpenAI;
using Newtonsoft.Json;

#region OpenAI api test 

APIHelper.Token = "Bearer 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";
APIHelper.EndPoint = "https://api.openai.com/v1";

Task task1 = Task.Run(() => APIHelper.PostRequest("/completions", "{\r\n    \"model\": \"text-davinci-003\", \r\n    \"prompt\": \"What is life\", \r\n    \"max_tokens\": 200\r\n}"));
task1.Wait();

OpenAIRequestBody requestBody = new OpenAIRequestBody() { Prompt = "Should you fire employees who do not match the company's values?", Temperature = 0.9f, Max_tokens = 500 };
var response = APIHelper.GetJsonObject<OpenAIResponseBody>(() => APIHelper.PostRequest("/completions", requestBody));
Console.WriteLine(response.Choices.FirstOrDefault().Text);
Console.ReadLine();
#endregion
