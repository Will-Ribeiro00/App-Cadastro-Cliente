using AppCliente_R.Repositorios.ClienteRepositorio;
using AppCliente_R.Repositorios.DataBase_Context;
using AppCliente_R.UseCases.Menu;
using AppCliente_R.Util;
using AppCliente_R.View.Menu;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;

namespace AppCliente_R.Services.ServiceProvider
{
    public class Services
    {
        public static IServiceProvider ConfigureServices()
        {
            var conexao = "DATA SOURCE=localhost:1521/xepdb1;TNS_ADMIN=C:\\Users\\willi\\Oracle\\network\\admin;PERSIST SECURITY INFO=True;USER ID=APPCLIENTE;PASSWORD=010203";
            var service = new ServiceCollection().AddDbContext<ClienteDbContext>(options =>
                                options.UseOracle(conexao));

            service.AddScoped<ClienteRepositorio>();

            service.AddScoped<Validacoes>();

            service.AddScoped<MenuView>();
            service.AddScoped<MenuUseCase>();

            return service.BuildServiceProvider();
        }
    }
}


