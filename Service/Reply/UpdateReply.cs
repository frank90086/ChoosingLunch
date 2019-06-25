using System;
using System.Collections.Generic;
using System.Linq;
using ChoosingBot.Entitys;
using ChoosingBot.Enums;
using ChoosingBot.Interface;
using ChoosingBot.Models;

namespace ChoosingBot.Service
{
    public class UpdateReply : Reply
    {
        public UpdateReply(SqliteContext context) : base(context) {}
        public override void Do(string[] message, ref List<MessageModel> replyMessages)
        {
            replyMessages.Add(new MessageModel(){
                type = "text",
                text = update(message)
            });
        }

        private string update(string[] message)
        {
            if (message.Count() < 2)
                return "請根據格式輸入：[update] [餐廳名稱] [吳興街=1|美食街=2]";

            string restaurantName = message[1];
            Area area = (Area)Enum.Parse(typeof(Area), message[2]);
            using (_context)
            {
                try
                {
                    RestaurantList restaurant = _context.RestaurantLists.FirstOrDefault(x => x.RestaurantName == restaurantName);
                    if (restaurant == null)
                        return "無此餐廳";
                    restaurant.RestaurantName = restaurantName;
                    restaurant.Area = area;
                    _context.SaveChanges();
                    return "修改成功";
                }
                catch (Exception)
                {
                    return "修改失敗";
                }
            }
        }
    }
}