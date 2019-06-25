using System;
using System.Collections.Generic;
using System.Linq;
using ChoosingBot.Entitys;
using ChoosingBot.Enums;
using ChoosingBot.Models;

namespace ChoosingBot.Service
{
    public class AddReply : Reply
    {
        public AddReply(SqliteContext context) : base(context) {}
        public override void Do(string[] message, ref List<MessageModel> replyMessages)
        {
            replyMessages.Add(new MessageModel(){
                type = "text",
                text = add(message)
            });
        }

        private string add(string[] message)
        {
            if (message.Count() < 2)
                return "請根據格式輸入：[add] [餐廳名稱] [吳興街=1|美食街=2]";

            string restaurantName = message[1];
            Area area = (Area)Enum.Parse(typeof(Area), message[2]);
            using (_context)
            {
                try
                {
                    RestaurantList restaurant = _context.RestaurantLists.FirstOrDefault(x => x.RestaurantName == restaurantName);
                    if (restaurant != null)
                        return "已有此餐廳";
                    _context.RestaurantLists.Add(new RestaurantList() { RestaurantName = restaurantName, Area = area });
                    _context.SaveChanges();
                    return "加入成功";
                }
                catch (Exception)
                {
                    return "加入失敗";
                }
            }
        }
    }
}