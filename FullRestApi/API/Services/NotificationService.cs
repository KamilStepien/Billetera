using FullRESTAPI.Context;
using FullRESTAPI.Models.Notifications;
using FullRESTAPI.Models.Users;
using FullRESTAPI.Models.EFModels;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace FullRESTAPI.Services
{
    public interface INotificationService
    {
        public IEnumerable<NotificationModel> GetAll(int id);
        public void ActiveNotyfication(ActiveNotificationModel model);
        public void DeactiveNotification(int  id);
    }
    public class NotificationService : INotificationService
    {
        private ApplicationDBContex _applicationDBContex;

        public NotificationService(ApplicationDBContex applicationDBContex)
        {
            _applicationDBContex = applicationDBContex;
        }

        public void ActiveNotyfication(ActiveNotificationModel model)
        { 
            if (model == null)
                throw new ArgumentException("The object entering the function is null");
           
            var user = _applicationDBContex.Users.FirstOrDefault(x => x.ID == model.UserId);

            if (user == null)
                throw new ArgumentException("User id is wrong ");

            var notificationList = _applicationDBContex.NotificationLists.FirstOrDefault(x => x.ID == model.NotificationListId );
            
            if (notificationList == null)
                throw new ArgumentException("The notification id don't exist ");


            var notyfication = _applicationDBContex
                .Notifications
                .FirstOrDefault(x => x.User.ID == model.UserId && x.NotificationLists.ID == model.NotificationListId);

            if (notyfication == null)
            {
                _applicationDBContex.Notifications.Add(new EFNotification
                {
                    IsDisplay = true,
                    User = user,
                    NotificationLists = notificationList
                });
            }
            else
            {
                notyfication.IsDisplay = true;
            }

            _applicationDBContex.SaveChanges();

        }

        public void DeactiveNotification(int id)
        {
            var notification = _applicationDBContex.Notifications.FirstOrDefault(x => x.ID == id);

            if (notification == null)
                throw new ArgumentException("The notification id don't exist ");

            notification.IsDisplay = false;
            _applicationDBContex.SaveChanges();

        }

        public IEnumerable<NotificationModel> GetAll(int id)
        {
            if (id == 0)
                return null;

            List<NotificationModel> notyfications = new List<NotificationModel>();

            _applicationDBContex.Notifications
                .Include(x => x.NotificationLists)
                .Where(y => y.User.ID == id && y.IsDisplay == true)
                .ToList()
                .ForEach(x =>
                {
                    notyfications.Add(new NotificationModel
                    {
                        Description = x.NotificationLists.Description,
                        Title = x.NotificationLists.Title,
                        Id = x.ID
                    }) ;
                }
                );

            return notyfications;


        }
    }
}
