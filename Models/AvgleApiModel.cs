using System.Collections.Generic;

namespace ChoosingBot.Models
{
    public class AvgleApiModel
    {
        public bool success { get; set; }
        public AvResponse response { get; set; }
    }

    public class AvResponse
    {
        public bool has_more { get; set; }
        public int total_videos { get; set; }
        public int current_offset { get; set; }
        public int limit { get; set; }
        public List<AvVideo> videos { get; set; }
    }

    public class AvVideo
    {
        public string vid { get; set; }
        public string uid { get; set; }
        public string title { get; set; }
        public string keyword { get; set; }
        public string channel { get; set; }
        public double duration { get; set; }
        public double framerate { get; set; }
        public bool hd { get; set; }
        public int addtime { get; set; }
        public int viewnumber { get; set; }
        public int likes { get; set; }
        public int dislikes { get; set; }
        public string video_url { get; set; }
        public string embedded_url { get; set; }
        public string preview_url { get; set; }
        public string preview_video_url { get; set; }
    }
}