using FullRESTAPI.Context;
using FullRESTAPI.Models.Categories;
using FullRESTAPI.Models.EFModels;
using FullRESTAPI.Models.Transactions;
using FullRESTAPI.Models.Users;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace FullRESTAPI.Services
{
    public interface ITransactionService
    {

        IEnumerable<TransactionModel> GetAll( int userId);
        TransactionModel GetTransaction(int id);
        TransactionModel Add(TransactionAddModel model);
        TransactionModel Edit(TransactionEditModel model);
        void Delete(int id);


    }

    public class TransactionService : ITransactionService
    {

        private ApplicationDBContex _applicationDBContex;

        public TransactionService(ApplicationDBContex applicationDBContex)
        {
            _applicationDBContex = applicationDBContex;
        }

        public TransactionModel Add(TransactionAddModel model)
        {
            if (model == null)
                throw new ArgumentException("The object entering the function is null");

            var user = _applicationDBContex.Users.FirstOrDefault(x => x.ID == model.UserId);

            if (user == null)
                throw new ArgumentException("User id is wrong ");

            var categorie = _applicationDBContex.Categories.Include(x => x.User).Include(y => y.CategoriesLists).FirstOrDefault(z => z.ID == model.CategorieId);

            if (categorie == null)
                throw new ArgumentException("Categorie id is wrong ");


            var transaction = new EFTransaction
            {
                Amount = model.Amount,
                CreateDate = model.CreateDate,
                IsExpense = model.IsExpense,
                Titl = model.Title,
                Categorie = categorie,
                User = user

            };

            _applicationDBContex.Transactions.Add(transaction);

            _applicationDBContex.SaveChanges();

            return new TransactionModel 
            { 
                Id = transaction.ID,
                Amount = transaction.Amount,
                Title = transaction.Titl,
                CreateDate = transaction.CreateDate,
                IsExpense = transaction.IsExpense,
                Categorie = new CategorieForTransactionModel 
                {
                    Id = transaction.Categorie.ID,
                    Name = transaction.Categorie.CategoriesLists.Name
                }
            };
        }

        public void Delete(int id)
        {

            var transaction = _applicationDBContex.Transactions.FirstOrDefault(x => x.ID == id);

            if(transaction == null)
                throw new ArgumentException("Can't  delete this trasaction because don't exist ");

            _applicationDBContex.Transactions.Remove(transaction);
            _applicationDBContex.SaveChanges();

        }

        public TransactionModel Edit(TransactionEditModel model)
        {

            if (model == null)
                throw new ArgumentException("The object entering the function is null");

            var user = _applicationDBContex.Users.FirstOrDefault(x => x.ID == model.UserId);

            if (user == null)
                throw new ArgumentException("User id is wrong ");

            var categorie = _applicationDBContex.Categories.Include(x => x.User).Include(y => y.CategoriesLists).FirstOrDefault(z => z.ID == model.CategorieId);
            
            if (categorie == null)
                throw new ArgumentException("Categorie id is wrong ");

            var transaction = _applicationDBContex.Transactions.FirstOrDefault(x => x.User.ID == model.UserId && x.ID == model.Id);

            if (transaction == null)
                throw new ArgumentException("Can't  delete this trasaction because don't exist ");

            transaction.Amount = model.Amount;
            transaction.CreateDate = model.CreateDate;
            transaction.IsExpense = model.IsExpense;
            transaction.Titl = model.Title;
            transaction.Categorie = categorie;

            _applicationDBContex.SaveChanges();


            return new TransactionModel
            {
                Id = transaction.ID,
                Amount = transaction.Amount,
                Title = transaction.Titl,
                CreateDate = transaction.CreateDate,
                IsExpense = transaction.IsExpense,
                Categorie = new CategorieForTransactionModel
                {
                    Id = transaction.Categorie.ID,
                    Name = transaction.Categorie.CategoriesLists.Name
                }
            }; ;
        }

        public IEnumerable<TransactionModel> GetAll(int userId)
        {

            var user = _applicationDBContex.Users.FirstOrDefault(x => x.ID == userId);

            if (user == null )
                throw new ArgumentException("User id is wrong");

            List<TransactionModel> transactions = new List<TransactionModel>();
            _applicationDBContex.Transactions
               .Where(x => x.User.ID == userId)
               .Include(y => y.Categorie)
               .Include(z => z.Categorie.CategoriesLists)
                .OrderBy(d => d.CreateDate)
                .ToList()
                .ForEach(x =>
                    {
                        transactions.Add(new TransactionModel
                        {
                            Id = x.ID,
                            Amount = x.Amount,
                            CreateDate = x.CreateDate,
                            IsExpense = x.IsExpense,
                            Title = x.Titl,
                            Categorie = new CategorieForTransactionModel
                            {
                                Id = x.Categorie.ID,
                                Name = x.Categorie.CategoriesLists.Name
                            }

                        });
            });


            return transactions;
        }

        public TransactionModel GetTransaction(int id)
        {
            var transaction = _applicationDBContex
                .Transactions
                .Include(y => y.Categorie)
                .Include(z => z.Categorie.CategoriesLists)
                .FirstOrDefault(x => x.ID == id );

            if (transaction == null)
                throw new ArgumentException("Can't  get this trasaction because don't exist ");

            return new TransactionModel
            {
                Id = transaction.ID,
                Amount = transaction.Amount,
                CreateDate = transaction.CreateDate,
                IsExpense = transaction.IsExpense,
                Title = transaction.Titl,
                Categorie = new CategorieForTransactionModel
                {
                    Id = transaction.Categorie.ID,
                    Name = transaction.Categorie.CategoriesLists.Name
                }

            };


        }
    }
}
