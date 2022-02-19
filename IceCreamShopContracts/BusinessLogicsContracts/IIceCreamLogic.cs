using IceCreamShopContracts.BindingModels;
using IceCreamShopContracts.ViewModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace IceCreamShopContracts.BusinessLogicsContracts
{
    public interface IIceCreamLogic
    {
        List<IceCreamViewModel> Read(IceCreamBindingModel model);
        void CreateOrUpdate(IceCreamBindingModel model);
        void Delete(IceCreamBindingModel model);

    }
}
