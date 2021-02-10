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
        IEnumerable<ShoppingListElementModel> GetAll(int userId);
        ShoppingListElementModel Add(ShopingListElementAddModel model);
        void Delete(int id);
        void SetSequence(ShoppingListElementModel[] model);
    
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

            var user = _applicationDBContex.Users.FirstOrDefault(x => x.ID == model.UserId);

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
                Id = shoppingElementList.ID 
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

        public IEnumerable<ShoppingListElementModel> GetAll(int  userId)
        {
            if (userId == 0)
                return null;

            List<ShoppingListElementModel> shoppingListElements = new List<ShoppingListElementModel>();

            _applicationDBContex.ShoppingElements
                .Where(x => x.User.ID == userId)
                .OrderBy(x=> x.Sequence)
                .ToList()
                .ForEach(x =>
                {
                    shoppingListElements.Add(new ShoppingListElementModel
                    {
                        Id = x.ID,
                        Description = x.Description,
                        Sequence = x.Sequence
                    }) ;
                });


            return shoppingListElements;

        }

        public void SetSequence(ShoppingListElementModel[] model)
        {
            if (model == null)
                throw new ArgumentException("The object entering the function is null");
            
            for(int i = 0; i< model.Length; i++)
            {
                var shoppingElementList = _applicationDBContex.ShoppingElements.FirstOrDefault(x => x.ID == model[i].Id );
                if (shoppingElementList == null)
                    throw new ArgumentException("Can't  delete this shoppingElementList because don't exist ");
                shoppingElementList.Sequence = i;
            }
            _applicationDBContex.SaveChanges();
        }
    }
}
