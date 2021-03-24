using FullRESTAPI.Context;
using FullRESTAPI.Models.EFModels;
using FullRESTAPI.Models.Jars;
using FullRESTAPI.Models.Users;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace FullRESTAPI.Services
{

    public interface IJarService
    {
        IEnumerable<JarModel> GetAll(int userId);
        JarModel GetJar(int id);
        JarModel Add(JarAddModel model);
        JarModel Edit(JarEditModel model);
        void Delete(int id);
        void EndJar(JarEndModel  model);
        void AddMoneyToJar(JarAddMoneyModel model);


    }


    public class JarsService : IJarService
    {
        private ApplicationDBContex _applicationDBContex;

        public JarsService(ApplicationDBContex applicationDBContex)
        {
            _applicationDBContex = applicationDBContex;
        }

        public JarModel Add(JarAddModel model)
        {
            if (model == null)
                throw new ArgumentException("The object entering the function is null");

            var user = _applicationDBContex.Users.FirstOrDefault(x => x.ID == model.UserId);

            if (user == null)
                throw new ArgumentException("User id is wrong ");

            var jar = new EFJars
            {
                User = user,
                Aim = model.Aim,
                CreateDate = DateTime.Now,
                CurrentMoney = 0,
                EndDate = model.EndDate,
                Name = model.Name,
                State = JarState.inProgress
            };

            _applicationDBContex.Jars.Add(jar);
            _applicationDBContex.SaveChanges();

            return new JarModel
            {
                Id = jar.ID,
                State = jar.State,
                Aim = jar.Aim,
                CreateDate = jar.CreateDate,
                CurrentMoney = jar.CurrentMoney,
                EndDate = jar.EndDate,
                Name = jar.Name
            };

        }

        public void Delete(int id)
        {

            var jar = _applicationDBContex.Jars.FirstOrDefault(x => x.ID == id);
            
            if (jar == null)
                throw new ArgumentException("Can't  delete this jar because don't exist ");

            _applicationDBContex.Jars.Remove(jar);
            _applicationDBContex.SaveChanges();

        }

        public JarModel Edit(JarEditModel model)
        {

            if (model == null)
                throw new ArgumentException("The object entering the function is null");

            var user = _applicationDBContex.Users.FirstOrDefault(x => x.ID == model.UserId);

            if (user == null)
                throw new ArgumentException("User id is wrong ");

            var jar = _applicationDBContex.Jars.FirstOrDefault(x => x.User.ID == model.UserId && x.ID == model.Id);

            if (jar == null)
                throw new ArgumentException("Can't  edit this jar because don't exist ");

            jar.Aim = model.Aim;
            jar.EndDate = model.EndDate;
            jar.Name = model.Name;

            _applicationDBContex.SaveChanges();

            return new JarModel
            {
                Id = jar.ID,
                State = jar.State,
                Aim = jar.Aim,
                CreateDate = jar.CreateDate,
                CurrentMoney = jar.CurrentMoney,
                EndDate = jar.EndDate,
                Name = jar.Name,
                
            };

        }

        public void EndJar(JarEndModel model)
        {
           
            var jar = _applicationDBContex.Jars.FirstOrDefault(x =>  x.ID == model.Id );
            if (jar == null)
                throw new ArgumentException("Can't  end this jar because don't exist ");
            
            var user = _applicationDBContex.Users.FirstOrDefault(x => x.ID == model.UserId);
            if (user == null)
                throw new ArgumentException("User id is wrong ");

            if (jar.Aim > jar.CurrentMoney)
                jar.State = JarState.Reached;
            else
                jar.State = JarState.Reached;

            jar.EndDate = DateTime.Now;

            _applicationDBContex.Transactions.Add(new EFTransaction
            {
                Amount = jar.CurrentMoney,
                IsExpense = false,
                Titl = "Jar",
                CreateDate = DateTime.Now,
                User = user,
                Categorie = _applicationDBContex.Categories.FirstOrDefault(x => x.ID == 1)
            }); 

            _applicationDBContex.SaveChanges();

        }

        public void AddMoneyToJar(JarAddMoneyModel model)
        {
            if (model == null)
                throw new ArgumentException("The object entering the function is null");

            var jar = _applicationDBContex.Jars.FirstOrDefault(x => x.ID == model.JarId);
            if (jar == null)
                throw new ArgumentException("Can't  end this jar because don't exist ");

            jar.CurrentMoney += model.Money;
            _applicationDBContex.SaveChanges();

        }

        public IEnumerable<JarModel> GetAll(int  userId)
        {
            if (userId == 0)
                return null;

            List<JarModel> jars = new List<JarModel>();

            _applicationDBContex.Jars
                .Where(x => x.User.ID == userId)
                .ToList()
                .ForEach(x =>
                {
                    jars.Add(new JarModel
                    {
                        Id = x.ID,
                        Aim = x.Aim,
                        CreateDate = x.CreateDate,
                        EndDate = x.EndDate,
                        CurrentMoney = x.CurrentMoney,
                        Name = x.Name,
                        State =x.State,
                        ProcentFill = (x.CurrentMoney * 100) / x.Aim
                    });
                });


            return jars;
        }

        public JarModel GetJar(int id)
        {


            var jar = _applicationDBContex
                .Jars 
                .FirstOrDefault(y => y.ID == id);

            if (jar == null)
                throw new ArgumentException("Can't  get this jar because don't exist ");


            return new JarModel
            {
                Id = jar.ID,
                Aim = jar.Aim,
                CreateDate = jar.CreateDate,
                EndDate = jar.EndDate,
                Name = jar.Name,
                CurrentMoney = jar.CurrentMoney,
                State = jar.State,
                ProcentFill = (jar.CurrentMoney*100)/jar.Aim


            };


        }
    }
}
