using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using FullRESTAPI.Context;
using FullRESTAPI.Models.Categories;
using FullRESTAPI.Models.EFModels;
using FullRESTAPI.Models.Users;
using Microsoft.EntityFrameworkCore;

namespace FullRESTAPI.Services
{

    public interface ICategorieService
    {
        IEnumerable<CategorieModel> GetAll(UserGetModel model);
        CategorieModel Add(CategorieModel model);       
        void  Delete (CategorieDeleteModel model);
    }


    public class CategorieService : ICategorieService
    {

        private ApplicationDBContex _applicationDBContex;

        public CategorieService( ApplicationDBContex applicationDBContex)
        {
            _applicationDBContex = applicationDBContex;
        }


        public CategorieModel Add(CategorieModel model)
        {
            if (model == null)
                throw new ArgumentException("The object entering the function is null");

            var user = _applicationDBContex.Users.FirstOrDefault(x => x.ID == model.UserId);

            if(user == null)
                 throw new ArgumentException("User id is wrong ");


            EFCategorie efCategorie;
            EFCategoriesLists efCategorieList = _applicationDBContex.CategoriesLists.FirstOrDefault(x => x.Name == model.Name);
           
            if(efCategorieList == null)
            {
                efCategorieList = new EFCategoriesLists { Name = model.Name };
                _applicationDBContex.CategoriesLists.Add(efCategorieList);

            }

            efCategorie = new EFCategorie { CategoriesLists = efCategorieList, User = user };

            _applicationDBContex.Categories.Add(efCategorie);
            _applicationDBContex.SaveChanges();

            model.ID = efCategorieList.ID;

            return model;

        }

        public void Delete(CategorieDeleteModel model)
        {
            if (model == null)
                throw new ArgumentException("The object entering the function is null");

            var efCategorie = _applicationDBContex.Categories.Where(x => x.CategoriesLists.ID == model.ID && x.User.ID == model.UserID).First();
            
            if (efCategorie == null)
                throw new ArgumentException("Can't delete this categorie because don't exist ");


            var ele = _applicationDBContex.Categories.Remove(efCategorie);
            _applicationDBContex.SaveChanges();
           
           
        }

       

        public IEnumerable<CategorieModel> GetAll(UserGetModel model)
        {
            if (model.UserID == 0)
                return null;

            List<CategorieModel> categories = new List<CategorieModel>();

            _applicationDBContex.Categories.Include(x => x.User).Include(y => y.CategoriesLists).Where(e => e.User.ID == model.UserID).ToList().ForEach(e =>
            categories.Add(new CategorieModel
            {
                ID = e.CategoriesLists.ID,
                Name = e.CategoriesLists.Name,
                UserId = e.User.ID
            })
            );


            return categories;

        }
    }
}
