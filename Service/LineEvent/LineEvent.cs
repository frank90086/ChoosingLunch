using System.Collections.Generic;
using ChoosingBot.Entitys;
using ChoosingBot.Interface;
using ChoosingBot.Models;

namespace ChoosingBot.Service
{
    public abstract class LineEvent : ILineEvent
    {
        internal readonly SqliteContext _context;
        public LineEvent(SqliteContext context)
        {
            _context = context;
        }
        public abstract void Do(EventModel model, ref List<MessageModel> replyMessages);
    }
}