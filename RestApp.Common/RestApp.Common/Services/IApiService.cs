using RestApp.Common.Models;
using RestApp.Common.Request;
using RestApp.Common.Responses;
using System.Threading.Tasks;

namespace RestApp.Common.Services
{
    public interface IApiService
    {
        Task<Response> GetListAsync<T>(string urlBase, string servicePrefix, string controller);
        Task<Response> GetTokenAsync(string urlBase, string servicePrefix, string controller, TokenRequest request);
        Task<Response> PostQualificationAsync(string urlBase, string servicePrefix, string controller, QualificationRequest qualificationRequest, string token);
        Task<Response> RegisterUserAsync(string urlBase, string servicePrefix, string controller, UserRequest userRequest);
        Task<Response> ModifyUserAsync(string urlBase, string servicePrefix, string controller, UserRequest userRequest, string token);
        Task<Response> ChangePasswordAsync(string urlBase, string servicePrefix, string controller, ChangePasswordRequest changePasswordRequest, string token);
        Task<Response> GetTokenAsync(string urlBase, string servicePrefix, string controller, FacebookProfile request);
        Task<Response> GetListReservationsAsync<T>(string urlBase, string servicePrefix, string controller,string token);

    }

}
