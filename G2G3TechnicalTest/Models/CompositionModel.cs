using G2G3TechnicalTest.Core.Models.POCO;
using System.Collections.Generic;

namespace G2G3TechnicalTest.Models
{
    public class CompositionModel
    {
        //Bringing the data together through to a singular point to display on one page for demo purposes
        //In a real app the data would be pulled from disperate sources
        public IEnumerable<BasketItem> BasketViewModel;
        public IEnumerable<Postage> Postage;
        public User UserViewModel;

        //Totalled sum for items in the basket
        public decimal BasketValue;

        //Paired up string with html symbol
        public string CurrencySymbol;

        public bool? BasketSavedSuccessfully;

        //User selection for postage selection
        public Postage SelectedPostageOption;
    }
}