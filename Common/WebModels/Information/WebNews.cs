using System;

namespace InteractiveWebsite.Common.WebModels.Information
{
    public class WebNews
    {
        public int Id { get; set; }
        public string? Author { get; set; }
        public string Content { get; set; } = string.Empty;
        public DateTime Date { get; set; }
    }
}
