namespace FinetunerApp.Models
{
    public class Item : BaseDataObject
    {
        string text = string.Empty;
        public string Text
        {
            get { return text; }
            set { SetObservableProperty(ref text, value); }
        }

        string description = string.Empty;
        public string Description
        {
            get { return description; }
            set { SetObservableProperty(ref description, value); }
        }
    }
}
