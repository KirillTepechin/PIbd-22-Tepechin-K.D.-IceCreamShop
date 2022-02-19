using IceCreamShopContracts.BindingModels;
using IceCreamShopContracts.ViewModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace IceCreamShopContracts.StorageContracts
{
    public interface IIngredientStorage
    {
        List<IngredientViewModel> GetFullList();
        List<IngredientViewModel> GetFilteredList(IngredientBindingModel model);
        IngredientViewModel GetElement(IngredientBindingModel model);
        void Insert(IngredientBindingModel model);
        void Update(IngredientBindingModel model);
        void Delete(IngredientBindingModel model);
    }
}
