using System.Collections.Generic;
using ChoosingBot.Entitys;
using ChoosingBot.Models;

namespace ChoosingBot.Service
{
    public class HelpReply : Reply
    {
        public HelpReply(SqliteContext context) : base(context) {}
        public override void Do(string[] message, ref List<MessageModel> replyMessages)
        {
            replyMessages.Add(new MessageModel() { type = "text", text = "請根據格式輸入：" });
            replyMessages.Add(new MessageModel() { type = "text", text = "取得午餐：[lunch] [數字(DayOfWeek)]=null" });
            replyMessages.Add(new MessageModel() { type = "text", text = "維護餐廳：[add|update|delete] [餐廳名稱] (add|update)[吳興街=1|美食街=2]" });
            replyMessages.Add(new MessageModel() { type = "text", text = "重新取得當日午餐：[retry]" });
            replyMessages.Add(new MessageModel() { type = "text", text = "清空紀錄：[clean]" });
        }
    }
}