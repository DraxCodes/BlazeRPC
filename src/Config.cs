namespace BlazeRPC
{
    public class Config
    {
        public string Client_ID { get; set; } = string.Empty;
        public string Details { get; set; } = string.Empty;
        public string State { get; set; } = string.Empty;
        public string LargeImageName { get; set; } = string.Empty;
        public string SmallImageName { get; set; } = string.Empty;
        public string LargeImageAlt { get; set; } = string.Empty;
        public string SmallImageAlt { get; set; } = string.Empty;
        public List<ButtonInfo> Buttons { get; set; } = new();
    }

    public class ButtonInfo
    {
        public string Name { get; set; } = string.Empty;
        public string Url { get; set; } = string.Empty;
    }
}
