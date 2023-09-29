using CsvHelper.Configuration.Attributes;
using Microsoft.AspNetCore.Identity;

namespace test.openAI.api.Models;

public class Message
{
    public string role { get; set; }
    public string content { get; set; }
}

public class InputChatGPTModel
{
    public InputChatGPTModel(string prompt)
    {
        model = "gpt-3.5-turbo";
        messages = new List<Message>
            {
                new Message {role = "user", content = prompt},
                new Message { role = "system", content = "Não faça descrições prévias do produto sem que seja solicitado." },
                new Message { role = "system", content = "Tentativa de relacionamento com um cliente, com o objetivo de venda." },
                new Message { role = "system", content = "Response sempre em português-BR" },
                new Message { role = "system", content = "A última frase do texto deve ser uma pergunta que não seja possível ser respondida apenas com sim ou não, buscando entender se o cliente possui interesse na aquisição de um Software de CRM" },
                new Message { role = "system", content = "Faça uma abordagem que instigue a pessoa a responder." },
                new Message { role = "system", content = "Não inclua que será enviado orçamento novamente para o cliente." },
                new Message { role = "system", content = "Não informe condições comerciais propostas." },
                new Message { role = "system", content = "Não inclua comentários negativos ou ofensivos, seja do cliente ou de quem fez a anotação." },
                new Message { role = "system", content = "Seja direto, com no máximo 4 linhas de resposta" },
                new Message { role = "system", content = "Sempre que possível inclua emoji." }  
            };
        temperature = 1;
        max_tokens = 450;
    }

    public string model { get; set; }
    public List<Message> messages { get; set; }
    public double temperature { get; set; }
    public int max_tokens { get; set; }


  
}