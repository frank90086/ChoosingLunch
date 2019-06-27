using System;
using System.Collections.Generic;
using System.Linq;
using ChoosingBot.Entitys;
using ChoosingBot.Enums;
using ChoosingBot.Models;

namespace ChoosingBot.Service
{
    public class TemplateReply : Reply
    {
        public TemplateReply(SqliteContext context) : base(context) {}
        public override void Do(string[] message, ref List<MessageModel> replyMessages)
        {
            replyMessages.Add(new MessageModel(){
                type = "template",
                altText = "test template function",
                template = add()
            });
        }

        private TemplateModel add()
        {
            return new TemplateModel()
            {
                type = "buttons",
                thumbnailImageUrl = "https://ppt.cc/fQ6vex",
                imageAspectRatio = "rectangle",
                imageSize = "cover",
                imageBackgroundColor = "#FFFFFF",
                title = "Button Template",
                text = "Please select",
                actions = new List<ActionModel>()
                {
                    new ActionModel()
                    {
                        type = "postback",
                        label = "取得午餐",
                        data = "lunch"
                    },
                    new ActionModel()
                    {
                        type = "postback",
                        label = "清空紀錄",
                        data = "clean"
                    },
                    new ActionModel()
                    {
                        type = "postback",
                        label = "重試",
                        data = "retry"
                    },
                    new ActionModel()
                    {
                        type = "postback",
                        label = "幫助",
                        data = "help"
                    }
                }
            };
        }
    }
}