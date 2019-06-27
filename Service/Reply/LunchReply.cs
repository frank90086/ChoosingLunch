using System;
using System.Collections.Generic;
using System.Linq;
using ChoosingBot.Entitys;
using ChoosingBot.Enums;
using ChoosingBot.Models;

namespace ChoosingBot.Service
{
    public class LunchReply : Reply
    {
        public LunchReply(SqliteContext context) : base(context) {}
        public override void Do(string[] message, ref List<MessageModel> replyMessages)
        {
            replyMessages.Add(new MessageModel(){
                type = "text",
                text = get(message)
            });
        }

        private string get(string[] message)
        {
            string final;
            int day = message.Count() > 1 ? int.Parse(message[1]) : 0;
            WeekDay weekDay = day > 0 ?
                (WeekDay)Enum.Parse(typeof(WeekDay), day.ToString()) :
                (WeekDay)Enum.Parse(typeof(WeekDay), DateTime.Now.DayOfWeek.ToString());
            using (_context)
            {
                try
                {
                    EatedList Eated = _context.EatedLists.FirstOrDefault(x => x.WeekDay == weekDay);
                    if (Eated == null)
                    {
                        final = GetRestaurantName();
                        _context.EatedLists.Add(new EatedList() { WeekDay = weekDay, Restaurant = final });
                        _context.SaveChanges();
                    }
                    else
                        final = Eated.Restaurant;
                    return final;
                }
                catch (Exception)
                {
                    return "取得失敗";
                }
            }
        }
    }
}