using System.Web;
using eUseControl.Domain.Entities.User;

namespace eUseControl.Web.Extensions
{
    public static class HttpContextExtensions
    {
        public static UProfileData GetMySessionObject(this HttpContext current)
        {
            return (UProfileData)current?.Session["__SessionObject"];
        }

        public static void SetMySessionObject(this HttpContext current, UProfileData profile)
        {
            current.Session.Add("__SessionObject", profile);
        }
    }
}