using System.Collections.Generic;

namespace ChoosingBot.Models
{
    public class ReplyMessageApiModel
    {
        public string replyToken { get; set; }
        public List<MessageModel> messages { get; set; }
    }
}