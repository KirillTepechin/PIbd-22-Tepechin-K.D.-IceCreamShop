using IceCreamShopContracts.BindingModels;
using IceCreamShopContracts.ViewModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace IceCreamShopContracts.StorageContracts
{
    public interface IIceCreamStorage
    {
        List<IceCreamViewModel> GetFullList();
        List<IceCreamViewModel> GetFilteredList(IceCreamBindingModel model);
        IceCreamViewModel GetElement(IceCreamBindingModel model);
        void Insert(IceCreamBindingModel model);
        void Update(IceCreamBindingModel model);
        void Delete(IceCreamBindingModel model);

    }
}
