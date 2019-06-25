using ChoosingBot.Entitys;
using ChoosingBot.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Net.Http.Headers;
using System.Threading.Tasks;
using Newtonsoft.Json;
using Microsoft.AspNetCore.Mvc;
using ChoosingBot.Extensions;
using ChoosingBot.Service;
using Microsoft.Extensions.Configuration;
using System.Text;

namespace ChoosingBot.Controllers
{
    public class LineBotController
    {
        private readonly SqliteContext _context;
        private readonly IConfiguration _config;
        HttpClient _httpClient;
        string _lineBaseUrl = "https://api.line.me/v2/bot/message/";
        string _avgleListBaseUrl = "https://api.avgle.com/v1/videos/";
        string _avgleSearchBaseUrl = "https://api.avgle.com/v1/search/";

        public LineBotController(SqliteContext context, IConfiguration config)
        {
            _context = context;
            _config = config;
        }

        [HttpPost]
        public async Task Post([FromBody]ReceiveMessageApiModel content)
        {
            List<MessageModel> replyMessages = new List<MessageModel>();
            EventModel receiveEvent = content.events?.FirstOrDefault();
            string replyToken = receiveEvent.replyToken;

            string[] message = receiveEvent.message.text.Split(' ');

            var lineEvent = ReflectionObject.GenericReflectionWithParm<LineEvent>($"{receiveEvent.type.FirstCharToUpper()}LineEvent", new object[]{_context});
            lineEvent.Do(message, ref replyMessages);

            await ResponseLine(replyToken, replyMessages);
        }

        private async Task ResponseLine(string replyToken, List<MessageModel> replyMessages)
        {
            ReplyMessageApiModel model = new ReplyMessageApiModel() { replyToken = replyToken, messages = replyMessages };
            var jsonInString = JsonConvert.SerializeObject(model);
            _httpClient = new HttpClient();
            _httpClient.BaseAddress = new Uri(_lineBaseUrl);
            _httpClient.DefaultRequestHeaders.Accept.Clear();
            _httpClient.DefaultRequestHeaders.Authorization = new AuthenticationHeaderValue("Bearer", _config["ChannelToken:Default"]);

            HttpResponseMessage response = await _httpClient.PostAsync("reply", new StringContent(jsonInString, Encoding.UTF8, "application/json"));
        }
    }
}
