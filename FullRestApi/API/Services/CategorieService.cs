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
        IEnumerable<CategorieModel> GetAll(int userId);
        CategorieModel Add(CategorieAddModel model);       
        void  Delete (int id);
    }


    public class CategorieService : ICategorieService
    {

        private ApplicationDBContex _applicationDBContex;

        public CategorieService( ApplicationDBContex applicationDBContex)
        {
            _applicationDBContex = applicationDBContex;
        }


        public CategorieModel Add(CategorieAddModel model)
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

          

            return new CategorieModel
            {
                Id = efCategorieList.ID,
                Name = efCategorieList.Name,
                UserId = efCategorie.User.ID
            };

        }

        public void Delete(int  id)
        {

            var efCategorie = _applicationDBContex.Categories.Where(x => x.ID == id).First();
            
            if (efCategorie == null)
                throw new ArgumentException("Can't delete this categorie because don't exist ");


            var ele = _applicationDBContex.Categories.Remove(efCategorie);
            _applicationDBContex.SaveChanges();
           
           
        }

       

        public IEnumerable<CategorieModel> GetAll(int userId)
        {
            var user = _applicationDBContex.Users.FirstOrDefault(x => x.ID == userId);

            if (user == null)
                throw new ArgumentException("User id is wrong");

            List<CategorieModel> categories = new List<CategorieModel>();

            _applicationDBContex.Categories.Include(x => x.User).Include(y => y.CategoriesLists).Where(e => e.User.ID == userId).ToList().ForEach(e =>
            categories.Add(new CategorieModel
            {
                Id = e.ID,
                Name = e.CategoriesLists.Name,
                UserId = e.User.ID
            })
            );


            return categories;

        }
    }
}
