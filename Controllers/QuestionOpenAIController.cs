using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using OpenAI.Interfaces;
using OpenAI.ObjectModels;
using OpenAI.ObjectModels.RequestModels;
using OpenAI.ObjectModels.ResponseModels;
using OpenAI.Utilities.Embedding;
using test.openAI.api.Models;
using dotenv.net.Utilities;
using static test.openAI.api.OpenAIResponse;
using System.Net.Http.Headers;
using System.Text.Json;
using System.Text;
using test.openAI.api.Models.OutputChatGPTModel;
using System.Runtime.InteropServices;

namespace test.openAI.api.Controllers
{

    [ApiController]
    [Route("api")]
    public class QuestionOpenAIController : ControllerBase
    {
        private readonly HttpClient _httpClient;

        public QuestionOpenAIController(HttpClient httpClient)
        {
            _httpClient = httpClient;
        }

        [HttpPost("question")]
        public async Task<IActionResult> Post([FromBody] BodyRequest text)
        {

            DotNetEnv.Env.Load();

                var question = new InputChatGPTModel(text.response);
                Console.Write(text);

// Console.WriteLine(question.ReadAsString());
                var secretKey = Environment.GetEnvironmentVariable("OPENAI_API_KEY");



                _httpClient.DefaultRequestHeaders.Add("Authorization", $"Bearer {secretKey}");

                var requestBody = JsonSerializer.Serialize(question);


                var content = new StringContent(requestBody, Encoding.UTF8, "application/json");


                var completionResponse = await _httpClient.PostAsync("https://api.openai.com/v1/chat/completions", content);


               var responseBody = await completionResponse.Content.ReadAsStringAsync();
               var responseObject = JsonSerializer.Deserialize<OutputChatGPTModel>(responseBody, new JsonSerializerOptions
                {
                    PropertyNameCaseInsensitive = true
                });


                return Ok(responseObject.choices.First().message.content);

            }
           
        }

    
    }

