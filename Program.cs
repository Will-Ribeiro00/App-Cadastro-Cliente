using AppCliente_R.Services.ServiceProvider;
using AppCliente_R.UseCases.Menu;
using Microsoft.Extensions.DependencyInjection;

var serverProvider = Services.ConfigureServices();

var menu = serverProvider.GetService<MenuUseCase>();

menu.Execute();
