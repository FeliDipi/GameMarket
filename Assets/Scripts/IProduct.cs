namespace OneFrame.Market.Core
{
    public interface IProduct
    {
        public string ID {get; set;}
        public string Name {get; set;}
        public string Description {get; set;}
        public string Thumbnail {get; set;}
        public float Price {get; set;}
    }
}