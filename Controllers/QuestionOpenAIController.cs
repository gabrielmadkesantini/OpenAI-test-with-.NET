using Microsoft.AspNetCore.Mvc;
using test.openAI.api.Models;
using System.Text.Json;
using System.Text;
using test.openAI.api.Models.OutputChatGPTModel;
using System.Net;
using System.ComponentModel.DataAnnotations;
using System;

namespace test.openAI.api.Controllers
{

    [ApiController]
    [Route("api")]
    public class QuestionOpenAIController : ControllerBase
    {
        private readonly HttpClient _httpClient;

        public QuestionOpenAIController(HttpClient httpClient)
        {

            var proxy = new WebProxy();

            Console.WriteLine(proxy.Credentials);
         
             var httpClientHandler = new HttpClientHandler
             {
                 Proxy = proxy,
             };

            //httpClientHandler.ServerCertificateCustomValidationCallback = HttpClientHandler.DangerousAcceptAnyServerCertificateValidator;



            _httpClient = new HttpClient(httpClientHandler);
        }

        [HttpPost("question")]
        public async Task<IActionResult> Post([FromBody] BodyRequest text)
        {

            DotNetEnv.Env.Load();

                var question = new InputChatGPTModel(text.userProposal);
                Console.Write(text);

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
                
                var chatAnswer = responseObject!.choices.First();
                return Ok(value: chatAnswer.message.content);

            }
           
        }

    
    }

