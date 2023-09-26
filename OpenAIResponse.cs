namespace test.openAI.api
{
    public class OpenAIResponse
    {
        public OpenAIResponse(string question) {
            Question = question;
        }
        public string Question {get; set;}
    }
}
