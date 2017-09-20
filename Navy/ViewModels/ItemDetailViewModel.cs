using FinetunerApp.Models;

namespace FinetunerApp.ViewModels
{
    public class ItemDetailViewModel : BaseViewModel
    {
        public Item Item { get; set; }
        public ItemDetailViewModel(Item item = null)
        {
            Title = item.Text;
            Item = item;
        }

        int quantity = 1;
        public int Quantity
        {
            get { return quantity; }
            set { SetObservableProperty(ref quantity, value); }
        }
    }
}