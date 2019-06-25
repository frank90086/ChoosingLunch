using System;
using System.Collections.Generic;
using System.Linq;
using ChoosingBot.Entitys;
using ChoosingBot.Interface;
using ChoosingBot.Models;

namespace ChoosingBot.Service
{
    public abstract class Reply : IReply
    {
        internal readonly SqliteContext _context;
        public Reply(SqliteContext context)
        {
            _context = context;
        }
        public abstract void Do(string[] message, ref List<MessageModel> replyMessages);

        internal string GetRestaurantName()
        {
            List<string> RList = _context.RestaurantLists.Select(x => x.RestaurantName).ToList();
            List<string> EatedList = _context.EatedLists.Select(x => x.Restaurant).ToList();
            Random rm = new Random();
            foreach (string str in EatedList)
            {
                RList.Remove(str);
            }
            string final = RList[rm.Next(0, RList.Count)];
            return final;
        }
    }
}