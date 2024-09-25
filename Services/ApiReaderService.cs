using Microsoft.AspNetCore.Mvc.TagHelpers;
using Microsoft.AspNetCore.Razor.TagHelpers;
using Microsoft.Extensions.Http;
using System.Runtime.CompilerServices;
using System.Net.Http.Json;
using Microsoft.Extensions.Configuration.EnvironmentVariables;
using Microsoft.AspNetCore.Mvc;

namespace ChatBot.Services
{
	public interface IApiReaderService
	{
		Task<string?> GetChatResponseAsync(string userMesage, string languageModel);
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
        public async Task<string?> GetChatResponseAsync(string userMessage, string languageModel)
		{
			var requestBody = new
			{
				messages = new[]
				{
					new { role = "user", content = userMessage }
				},
				model = languageModel,
			};

			HttpResponseMessage response = await _client.PostAsJsonAsync(
				"v1/chat", requestBody);

			response.EnsureSuccessStatusCode();

			ResponseModel? result = await response.Content.ReadFromJsonAsync<ResponseModel>();

			if (result is null ||
				result.Choices is null ||
				result.Choices.Count == 0)
			{
				throw new InvalidOperationException("No response from API.");
			}

			return result.Choices.First().Message?.Content;
		}
	}

	public class ResponseModel
	{
		public List<Choice>? Choices { get; set; }
	}

	public class Choice
	{
		public Message? Message { get; set; }
	}

	public class Message
	{
		public string? Content { get; set; }
	}
}
