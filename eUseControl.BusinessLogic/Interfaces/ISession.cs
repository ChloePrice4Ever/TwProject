using System.Web;
using eUseControl.Domain.Entities.User.Login;
using eUseControl.Domain.Entities.User.Register;
using eUseControl.Domain.Entities.User;

namespace eUseControl.BusinessLogic.Interfaces
{
    public interface ISession
    {
        ULoginResp UserLogin(ULoginData data);
        URegisterResp UserRegister(URegisterData data);
        HttpCookie GenCookie(string loginCredential);
        UProfileData GetUserByCookie(string apiCookieValue);
    }
}
