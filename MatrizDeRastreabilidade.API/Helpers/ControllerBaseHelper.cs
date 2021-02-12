using Microsoft.AspNetCore.Mvc;
using System;

namespace MatrizDeRastreabilidade.API.Helpers
{
    public class ControllerBaseHelper : ControllerBase
    {
        protected readonly IServiceProvider _serviceProvider;

        public ControllerBaseHelper(IServiceProvider serviceProvider)
        {
            _serviceProvider = serviceProvider;
        }
    }
}
