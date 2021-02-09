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
        JarModel Add(JarAddEditModel model);
        JarModel Edit(JarAddEditModel model);
        void Delete(int id);
        void EndJar(int  id);


    }


    public class JarsService : IJarService
    {
        private ApplicationDBContex _applicationDBContex;

        public JarsService(ApplicationDBContex applicationDBContex)
        {
            _applicationDBContex = applicationDBContex;
        }

        public JarModel Add(JarAddEditModel model)
        {
            if (model == null)
                throw new ArgumentException("The object entering the function is null");

            var user = _applicationDBContex.Users.FirstOrDefault(x => x.ID == model.UserID);

            if (user == null)
                throw new ArgumentException("User id is wrong ");

            var jar = new EFJars
            {
                User = user,
                Aim = model.Aim,
                CreateDate = DateTime.Now,
                CurrentMoney = model.CurrentMoney,
                EndDate = model.EndDate,
                Name = model.Name,
                State = JarState.inProgress
            };

            _applicationDBContex.Jars.Add(jar);
            _applicationDBContex.SaveChanges();

            return new JarModel
            {
                ID = jar.ID,
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

        public JarModel Edit(JarAddEditModel model)
        {

            if (model == null)
                throw new ArgumentException("The object entering the function is null");

            var user = _applicationDBContex.Users.FirstOrDefault(x => x.ID == model.UserID);

            if (user == null)
                throw new ArgumentException("User id is wrong ");

            var jar = _applicationDBContex.Jars.FirstOrDefault(x => x.User.ID == model.UserID && x.ID == model.ID);

            if (jar == null)
                throw new ArgumentException("Can't  edit this jar because don't exist ");

            jar.Aim = model.Aim;
            jar.CurrentMoney = model.CurrentMoney;
            jar.EndDate = model.EndDate;
            jar.Name = model.Name;

            _applicationDBContex.SaveChanges();

            return new JarModel
            {
                ID = jar.ID,
                State = jar.State,
                Aim = jar.Aim,
                CreateDate = jar.CreateDate,
                CurrentMoney = jar.CurrentMoney,
                EndDate = jar.EndDate,
                Name = jar.Name
            };

        }

        public void EndJar(int  id)
        {
          

            var jar = _applicationDBContex.Jars.FirstOrDefault(x =>  x.ID == id );

            if (jar == null)
                throw new ArgumentException("Can't  end this jar because don't exist ");

            if (jar.Aim > jar.CurrentMoney)
                jar.State = JarState.Reached;
            else
                jar.State = JarState.Reached;

            jar.EndDate = DateTime.Now;

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
                        ID = x.ID,
                        Aim = x.Aim,
                        CreateDate = x.CreateDate,
                        EndDate = x.EndDate,
                        CurrentMoney = x.CurrentMoney,
                        Name = x.Name,
                        State =x.State
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
                ID = jar.ID,
                Aim = jar.Aim,
                CreateDate = jar.CreateDate,
                EndDate = jar.EndDate,
                Name = jar.Name,
                CurrentMoney = jar.CurrentMoney,
                State = jar.State
            };


        }
    }
}
