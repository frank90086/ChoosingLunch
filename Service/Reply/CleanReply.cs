using System;
using System.Collections.Generic;
using System.Linq;
using ChoosingBot.Entitys;
using ChoosingBot.Models;

namespace ChoosingBot.Service
{
    public class CleanReply : Reply
    {
        public CleanReply(SqliteContext context) : base(context) {}
        public override void Do(string[] message, ref List<MessageModel> replyMessages)
        {
            replyMessages.Add(new MessageModel(){
                type = "text",
                text = delete()
            });
        }

        private string delete()
        {
            using (_context)
            {
                try
                {
                    List<EatedList> EatedL = _context.EatedLists.ToList();
                    _context.EatedLists.RemoveRange(EatedL);
                    _context.SaveChanges();
                    return "刪除成功";
                }
                catch (Exception)
                {
                    return "刪除失敗";
                }
            }
        }
    }
}