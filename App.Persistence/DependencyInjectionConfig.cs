using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using App.Domain.Interfaces.Repositories;
using App.Persistence.Repositories;
using Microsoft.Extensions.DependencyInjection;

namespace App.Persistence
{
    // Faz para relacionar a Interface com os métodos
    public class DependencyInjectionConfig 
    {
        public static void Inject(IServiceCollection services)
        {
            // Chamará a Interface e não os métodos em si
            services.AddScoped(typeof(IRepositoryBase<>), typeof(RepositoryBase<>));
        }
    }
}
