using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Web;
using eUseControl.Helpers;
using eUseControl.Domain.Entities.User.Login;
using eUseControl.Domain.Entities.User;
using eUseControl.Domain.Entities.User.Register;
using eUseControl.BusinessLogic.DbModel;
using System.ComponentModel.DataAnnotations;
using System.Data.Entity;

namespace eUseControl.BusinessLogic.Core
{
    public class UserApi
    {
        internal ULoginResp UserLoginAction(ULoginData data)
        {
            UsersDbTable result;
            var validate = new EmailAddressAttribute();
            if (validate.IsValid(data.Email))
            {
                var pass = LoginHelper.HashGen(data.Password);

                using (var db = new UserContext())
                {
                    result = db.Users.FirstOrDefault(u => u.Email == data.Email && u.Password == pass);
                }
                if (result == null)
                {
                    return new ULoginResp
                    {
                        Status = false,
                        StatusMsg = "Adresa de email sau parola este incorectă."
                    };
                }
                using (var up = new UserContext())
                {
                    result.PrivateIp = data.LoginIp;
                    result.LastLogin = data.LoginDateTime;
                    up.Entry(result).State = EntityState.Modified;
                    up.SaveChanges();
                }
            }
            return new ULoginResp { Status = true };
        }
        internal URegisterResp UserRegisterAction(URegisterData data)
        {
            UsersDbTable insert = new UsersDbTable
            {
                Name = data.Name,
                Surname = data.Surname,
                Email = data.Email,
                Password = LoginHelper.HashGen(data.Password),
                Level = Domain.Enums.URole.Subscriber,
                RegisterDate = DateTime.Now,
                UpdateRegisterDate = DateTime.Now
            };
            int result;
            using (var db = new UserContext())
            {
                db.Users.Add(insert);
                result = db.SaveChanges();
            }
            if (result == 0)
            {
                return new URegisterResp
                {
                    Status = false,
                    StatusMsg = "Datele nu au putut fi salvate."
                };
            }
            return new URegisterResp { Status = true };
        }
        internal HttpCookie Cookie(string loginCredential)
        {
            var apiCookie = new HttpCookie("tsud")
            {
                Value = CookieGenerator.Create(loginCredential)
            };

            using (var db = new UserContext())
            {
                SessionsDbTable curent;
                var validate = new EmailAddressAttribute();
                if (validate.IsValid(loginCredential))
                {
                    curent = (from e in db.Sessions where e.UserEmail == loginCredential select e).FirstOrDefault();
                }
                else
                {
                    curent = (from e in db.Sessions where e.UserEmail == loginCredential select e).FirstOrDefault();
                }

                if (curent != null)
                {
                    curent.CookieString = apiCookie.Value;
                    curent.ExpireTime = DateTime.Now.AddMinutes(60);
                    using (var up = new UserContext())
                    {
                        up.Entry(curent).State = EntityState.Modified;
                        up.SaveChanges();
                    }
                }
                else
                {
                    db.Sessions.Add(new SessionsDbTable
                    {
                        UserEmail = loginCredential,
                        CookieString = apiCookie.Value,
                        ExpireTime = DateTime.Now.AddMinutes(60)
                    });
                    db.SaveChanges();
                }
            }
            return apiCookie;
        }
        internal UProfileData UserCookie(string cookie)
        {
            SessionsDbTable session;
            UsersDbTable curentUser;

            using (var db = new UserContext())
            {
                session = db.Sessions.FirstOrDefault(s => s.CookieString == cookie && s.ExpireTime > DateTime.Now);
            }

            if (session == null) return null;
            using (var db = new UserContext())
            {
                var validate = new EmailAddressAttribute();
                if (validate.IsValid(session.UserEmail))
                {
                    curentUser = db.Users.FirstOrDefault(u => u.Email == session.UserEmail);
                }
                else
                {
                    curentUser = db.Users.FirstOrDefault(u => u.Email == session.UserEmail);
                }
            }

            if (curentUser == null) return null;
            var userprofile = new UProfileData
            {
                Id = curentUser.Id,
                Name = curentUser.Name,
                Surname = curentUser.Surname,
                Email = curentUser.Email,
                Level = curentUser.Level
            };

            return userprofile;
        }
    }
}
