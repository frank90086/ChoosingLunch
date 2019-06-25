using System.Collections.Generic;

namespace ChoosingBot.Models
{
    public class ReceiveMessageApiModel
    {
        public ReceiveMessageApiModel() { }
        public List<EventModel> events { get; set; }
    }

    public class EventModel
    {
        public string replyToken { get; set; }
        public string type { get; set; }
        public long timestamp { get; set; }
        public SourceModel source { get; set; }
        public MessageModel message { get; set; }
        public PostbackModel postback { get; set; }
    }

    public class SourceModel
    {
        public string type { get; set; }
        public string userId { get; set; }
        public string groupId { get; set; }
        public string teamId { get; set; }
        public string roomId { get; set; }
    }

    public class MessageModel
    {
        public string id { get; set; }
        public string type { get; set; }
        public string text { get; set; }
        public string altText { get; set; }
        public TemplateModel template { get; set; }
    }

    public class PostbackModel
    {
        public string data { get; set; }
    }

    public class TemplateModel
    {
        public string type { get; set; }
        public string thumbnailImageUrl { get; set; }
        public string imageAspectRatio { get; set; }
        public string imageSize { get; set; }
        public string imageBackgroundColor { get; set; }
        public string title { get; set; }
        public string text { get; set; }
        public ActionModel defaultAction { get; set; }
        public List<ActionModel> actions { get; set; }
        public List<ColumnsModel> columns { get; set; }
    }

    public class ActionModel
    {
        public string type { get; set; }
        public string label { get; set; }
        public string uri { get; set; }
        public string data { get; set; }
    }

    public class ColumnsModel
    {
        public string thumbnailImageUrl { get; set; }
        public string title { get; set; }
        public string text { get; set; }
        public List<ActionModel> actions { get; set; }
    }
}