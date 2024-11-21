# Chat With Neil

**Chat With Neil** is a web-based application that simulates engaging conversations with Neil deGrasse Tyson, the renowned astrophysicist. Using advanced AI models, the chatbot provides insightful, in-character responses to user inputs.

![ChatBot Screenshot](https://raw.githubusercontent.com/Smileybob72801/ChatBot/refs/heads/master/Screenshot.png)

## Features

- 🌌 **Immersive Interaction:** Speak to a virtual Neil deGrasse Tyson, who responds with accurate, insightful, and often humorous commentary about science, the universe, and more.
- 🧠 **AI-Powered Responses:** Leverages large language models like Meta's Llama for dynamic and natural conversations.
- 🚀 **Real-Time Communication:** Displays user messages and responses in an intuitive chat interface.
- 🔧 **Configurable:** Easily switch AI models by updating the `SubmitInput` method.

## Technologies Used

- **Blazor Server** for creating the chat application's front-end.
- **C#** for back-end logic and API integrations.
- **Groq API** for connecting to AI models.
- **HTML/CSS** for the chat interface.

## How It Works

1. **User Input:** Users type their messages into the text area and press "Submit."
2. **AI Model Selection:** The app sends the user's message to the API, prefixed with an instruction to roleplay Neil deGrasse Tyson.
3. **API Communication:** A request is made to the Groq API using `ApiReaderService` to retrieve a response.
4. **Display Response:** The user request and the chatbot's completion is displayed similar to a text conversation.

## Getting Started

### Prerequisites

- **.NET SDK** 8.0 or later.
- An API key for Groq's OpenAI-compatible service. Set this as an environment variable named `GROQ_API_KEY`.

### Installation

1. Clone the repository:  
   ```bash
   git clone https://github.com/YourUsername/ChatBot.git
   cd ChatBot
   ```

2. Configure the environment variable:  
   On Windows:  
   ```cmd
   setx GROQ_API_KEY "your-api-key-here"
   ```

   On macOS/Linux:  
   ```bash
   export GROQ_API_KEY="your-api-key-here"
   ```

3. Run the application:  
   ```bash
   dotnet run
   ```

### API Integration

The app connects to Groq's OpenAI-compatible API at `https://api.groq.com/`. Ensure you have a valid API key with access to the necessary endpoints.

## Future Enhancements

- 🤝 **Multiple Characters:** Allow users to choose from other notable scientists or celebrities for interactions.
- 📖 **Context Memory:** Add conversation history persistence for more coherent and context-aware discussions.
- 🎨 **Custom Themes:** Enable users to personalize the chat interface with different visual themes.

## Acknowledgments

This chatbot application is inspired by the public persona of Neil deGrasse Tyson.
