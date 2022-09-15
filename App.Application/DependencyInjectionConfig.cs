using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using App.Application.Services;
using App.Domain.Interfaces.Application;
using Microsoft.Extensions.DependencyInjection;

namespace App.Application
{
    public class DependencyInjectionConfig
    {
        public static void Inject(IServiceCollection services) // Método
        {
            services.AddTransient<ICidadeService, CidadeService>();
            services.AddTransient<IPessoaService, PessoaService>();
        }
    }
}
