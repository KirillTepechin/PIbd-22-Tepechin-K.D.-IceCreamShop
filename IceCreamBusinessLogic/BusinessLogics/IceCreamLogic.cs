using IceCreamShopContracts.BindingModels;
using IceCreamShopContracts.BusinessLogicsContracts;
using IceCreamShopContracts.StorageContracts;
using IceCreamShopContracts.ViewModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace IceCreamShopBusinessLogic.BusinessLogics
{
    public class IceCreamLogic : IIceCreamLogic
    {
        private readonly IIceCreamStorage _iceCreamStorage;
        public IceCreamLogic(IIceCreamStorage iceCreamStorage)
        {
            _iceCreamStorage = iceCreamStorage;
        }
        public void CreateOrUpdate(IceCreamBindingModel model)
        {
            var icecream = _iceCreamStorage.GetElement(new IceCreamBindingModel { IceCreamName = model.IceCreamName });
            if (icecream != null && icecream.Id != model.Id)
            {
                throw new Exception("Такое мороженое уже есть");
            }
            if (model.Id.HasValue)
            {
                _iceCreamStorage.Update(model);
            }
            else
            {
                _iceCreamStorage.Insert(model);
            }
        }

        public void Delete(IceCreamBindingModel model)
        {
            var element = _iceCreamStorage.GetElement(new IceCreamBindingModel { Id = model.Id });
            if (element == null)
            {
                throw new Exception("Элемент не найден");
            }
            _iceCreamStorage.Delete(model);
        }

        public List<IceCreamViewModel> Read(IceCreamBindingModel model)
        {
            if (model == null)
            {
                return _iceCreamStorage.GetFullList();
            }
            if (model.Id.HasValue)
            {
                return new List<IceCreamViewModel> { _iceCreamStorage.GetElement(model) };
            }
            return _iceCreamStorage.GetFilteredList(model);
        }
    }
}
