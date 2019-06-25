using System.Collections.Generic;
using ChoosingBot.Entitys;
using ChoosingBot.Extensions;
using ChoosingBot.Models;

namespace ChoosingBot.Service
{
    public class PostbackLineEvent : LineEvent
    {
        public PostbackLineEvent(SqliteContext context) : base(context) {}
        public override void Do(EventModel model, ref List<MessageModel> replyMessages)
        {
            var message = model.postback.data.Split('&');
            var actionReply = ReflectionObject.GenericReflectionWithParm<Reply>($"{message[0].FirstCharToUpper()}Reply", new object[]{_context});
            actionReply.Do(message, ref replyMessages);
        }
    }
}