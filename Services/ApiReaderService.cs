using Microsoft.AspNetCore.Mvc.TagHelpers;
using Microsoft.AspNetCore.Razor.TagHelpers;
using Microsoft.Extensions.Http;
using System.Runtime.CompilerServices;
using System.Net.Http.Json;
using Microsoft.Extensions.Configuration.EnvironmentVariables;

namespace ChatBot.Services
{
	public interface IApiReaderService
	{
		Task<string> ReadAsync(string userMesage, string languageModel);
	}
	public class ApiReaderService : IApiReaderService
	{
		private readonly HttpClient _client;
		private readonly string _apiKey;

        public ApiReaderService()
        {
			_client = new HttpClient()
			{
				BaseAddress = new Uri("https://api.groqcloud.com/")
			};

			_apiKey = Environment.GetEnvironmentVariable("GROQ_API_KEY") ??
				throw new InvalidOperationException("API key not found.");

			_client.DefaultRequestHeaders.Add("Authorization", $"Bearer {_apiKey}");
		}
        public async Task<string> ReadAsync(string userMessage, string languageModel)
		{
			var requestBody = new
			{
				messages = new[]
				{
					new { role = "user", content = userMessage }
				},
				model = languageModel,
			};


		}
	}
}
