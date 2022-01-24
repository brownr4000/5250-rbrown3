using System;

using Mine.Models;

namespace Mine.ViewModels
{
    /// <summary>
    /// The ItenReadViewModel class
    /// </summary>
    public class ItemReadViewModel : BaseViewModel
    {
        /// <summary>
        /// The Item method gets and sets the ItemModel
        /// </summary>
        public ItemModel Item { get; set; }

        /// <summary>
        /// The ItemReadViewModel Constructor
        /// </summary>
        /// <param name="item"></param>
        public ItemReadViewModel(ItemModel item = null)
        {
            Title = item?.Text;
            Item = item;
        }
    }
}
