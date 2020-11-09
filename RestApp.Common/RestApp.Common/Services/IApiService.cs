﻿using RestApp.Common.Responses;
using System.Threading.Tasks;

namespace RestApp.Common.Services
{
    public interface IApiService
    {
        Task<Response> GetListAsync<T>(string urlBase, string servicePrefix, string controller);
    }

}
