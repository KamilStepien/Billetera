using FullRESTAPI.Context;
using FullRESTAPI.Models.EFModels;
using FullRESTAPI.Models.ShoppingListElements;
using FullRESTAPI.Models.Users;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace FullRESTAPI.Services
{

    public interface IShoppingListElementService
    {
        IEnumerable<ShoppingListElementModel> GetAll(UserGetModel model);
        ShoppingListElementModel Add(ShopingListElementAddModel model);
        void Delete(int id);
    
    }


    public class ShoppingListElementService : IShoppingListElementService
    {

        private ApplicationDBContex _applicationDBContex;

        public ShoppingListElementService(ApplicationDBContex applicationDBContex)
        {
            _applicationDBContex = applicationDBContex;
        }



        public ShoppingListElementModel Add(ShopingListElementAddModel model)
        {
            if (model == null)
                throw new ArgumentException("The object entering the function is null");

            var user = _applicationDBContex.Users.FirstOrDefault(x => x.ID == model.UserID);

            if (user == null)
                throw new ArgumentException("User id is wrong ");

            var shoppingElementList = new EFShoppingElement
            {
                Description = model.Description,
                Sequence = model.Sequence,
                User = user
            };

            _applicationDBContex.ShoppingElements.Add(shoppingElementList);
            _applicationDBContex.SaveChanges();

            return new ShoppingListElementModel 
            { 
                Sequence = shoppingElementList.Sequence, 
                Description = shoppingElementList.Description, 
                ID = shoppingElementList.ID 
            };
        }

        public void Delete(int  id)
        {
           

            var shoppingElementList = _applicationDBContex.ShoppingElements.FirstOrDefault(x => x.ID == id);
            
            if (shoppingElementList == null)
                throw new ArgumentException("Can't  delete this shoppingElementList because don't exist ");

            _applicationDBContex.ShoppingElements.Remove(shoppingElementList);
            _applicationDBContex.SaveChanges();

        }

        public IEnumerable<ShoppingListElementModel> GetAll(UserGetModel model)
        {
            if (model.UserID == 0)
                return null;

            List<ShoppingListElementModel> shoppingListElements = new List<ShoppingListElementModel>();

            _applicationDBContex.ShoppingElements
                .Where(x => x.User.ID == model.UserID)
                .ToList()
                .ForEach(x =>
                {
                    shoppingListElements.Add(new ShoppingListElementModel
                    {
                        ID = x.ID,
                        Description = x.Description,
                        Sequence = x.Sequence
                    }) ;
                });


            return shoppingListElements;

        }
    }
}
