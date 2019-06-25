using System;
using System.Collections.Generic;
using System.Linq;
using ChoosingBot.Entitys;
using ChoosingBot.Enums;
using ChoosingBot.Interface;
using ChoosingBot.Models;

namespace ChoosingBot.Service
{
    public class DeleteReply : Reply
    {
        public DeleteReply(SqliteContext context) : base(context) {}
        public override void Do(string[] message, ref List<MessageModel> replyMessages)
        {
            replyMessages.Add(new MessageModel(){
                type = "text",
                text = delete(message)
            });
        }

        private string delete(string[] message)
        {
            if (message.Count() < 1)
                return "請根據格式輸入：[delete] [餐廳名稱]";

            string restaurantName = message[1];
            using (_context)
            {
                try
                {
                    RestaurantList restaurant = _context.RestaurantLists.FirstOrDefault(x => x.RestaurantName == restaurantName);
                    if (restaurant == null)
                        return "無此餐廳";
                    _context.RestaurantLists.Remove(restaurant);
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