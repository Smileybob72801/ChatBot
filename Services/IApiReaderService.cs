namespace ChatBot.Services
{
    public interface IApiReaderService
    {
        Task<string?> GetChatResponseAsync(string userMesage, string languageModel);
    }
}
