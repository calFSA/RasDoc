using Microsoft.AspNetCore.Mvc;
using System;

namespace MatrizDeRastreabilidade.API.Helpers
{
    public class BaseControllerHelper : ControllerBase
    {
        protected readonly IServiceProvider _serviceProvider;

        public BaseControllerHelper(IServiceProvider serviceProvider)
        {
            _serviceProvider = serviceProvider;
        }
    }
}
