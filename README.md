# How to use?

## Download dependencies
  - Make sure you're in your project repository
  - Run the following command in your terminal:
      `dotnet restore`


## Prerequisites for Using the OpenAI API
  - Copy a new ".env" file using the following command in your terminal:
      `cp .env.example .env`
  - Now you can add your OpenAI API key to the constant variable in the .env file.

## Postman Configuration
  - Use the POST method.
  - Use the following URL: 
        https://localhost:7275/api/question
  - Change the body format to raw - JSON.
  - Use the following body in your request:
      ```json
      {
          "text": "Here will be your question for chatGPT to answer."
      }


        
        
