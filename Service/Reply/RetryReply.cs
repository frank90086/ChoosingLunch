using System;
using System.Collections.Generic;
using System.Linq;
using ChoosingBot.Entitys;
using ChoosingBot.Enums;
using ChoosingBot.Models;

namespace ChoosingBot.Service
{
    public class RetryReply : Reply
    {
        public RetryReply(SqliteContext context) : base(context) {}
        public override void Do(string[] message, ref List<MessageModel> replyMessages)
        {
            replyMessages.Add(new MessageModel(){
                type = "text",
                text = get()
            });
        }

        private string get()
        {
            string final;
            using (_context)
            {
                try
                {
                    WeekDay weekDay = (WeekDay)Enum.Parse(typeof(WeekDay), DateTime.Now.DayOfWeek.ToString());

                    EatedList Eated = _context.EatedLists.FirstOrDefault(x => x.WeekDay == weekDay);
                    final = GetRestaurantName();
                    if (Eated != null)
                        _context.EatedLists.Remove(Eated);
                    _context.EatedLists.Add(new EatedList() { WeekDay = weekDay, Restaurant = final });
                    _context.SaveChanges();
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