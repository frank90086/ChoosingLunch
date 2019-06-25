using System.Collections.Generic;
using ChoosingBot.Entitys;
using ChoosingBot.Extensions;
using ChoosingBot.Models;

namespace ChoosingBot.Service
{
    public class MessageLineEvent : LineEvent
    {
        public MessageLineEvent(SqliteContext context) : base(context) {}
        public override void Do(string[] message, ref List<MessageModel> replyMessages)
        {
            var actionReply = ReflectionObject.GenericReflectionWithParm<Reply>($"{message[0].FirstCharToUpper()}Reply", new object[]{_context});
            actionReply.Do(message, ref replyMessages);
        }
    }
}