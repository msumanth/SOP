using SOP.Core.Data;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Web.Mvc;

namespace SOP.Core.Repositpory
{
    public class UserDao
    {
        public bool CheckCredentials(string username, string password, ref int userId)
        {
            using (var context = new SOPEntities())
            {
                var user = context.SopUsers.Where(s => s.UserName == username && s.Password == password).FirstOrDefault();

                if (user != null)
                {
                    userId = user.Id;
                    return true;
                }
                return false;
            }
        }

        public SopUser GetUser(int id)
        {
            using (var context = new SOPEntities())
            {
                return context.SopUsers.Where(s => s.Id == id).FirstOrDefault();
            }
        }

        public int GetUserRole(int userId)
        {
            using (var context = new SOPEntities())
            {
                return context.SopUsers.Where(s => s.Id == userId).FirstOrDefault().RoleId;
            }
        }

        public SopUser SaveNewUser(SopUser user)
        {
            using (var context = new SOPEntities())
            {
                context.SopUsers.Add(user);
                context.SaveChanges();
                return user;
            }
        }

        public void DeleteUser(int id)
        {

        }

        public void EditUser(SopUser user)
        {

        }

        public IEnumerable<SelectListItem> GetAllSecretQuestions()
        {
            using (var context = new SOPEntities())
            {
                var allquestions = context.SecretQuestions.ToList();
                IEnumerable<SelectListItem> items = allquestions.Select(c => new SelectListItem
                {
                    Value = c.Id.ToString(),
                    Text = c.Question
                });
                return items;
            }

        }

        public IEnumerable<SelectListItem> GetAllUserRoles(bool isadmin)
        {
            using (var context = new SOPEntities())
            {
                var allroles = context.Roles.Where(r => r.Id != 1).ToList();
                if (!isadmin)
                    allroles = allroles.Where(r => r.Id != 2).ToList();
                IEnumerable<SelectListItem> items = allroles.Select(c => new SelectListItem
                {
                    Value = c.Id.ToString(),
                    Text = c.Role1
                });
                return items;
            }

        }
    }
}
