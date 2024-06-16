using AppCliente_R.View.Menu;

namespace AppCliente_R.UseCases.Menu
{
    public class MenuUseCase
    {
        private readonly MenuView _view;
        public MenuUseCase(MenuView view) => _view = view;

        public void Execute() => _view.ExibirMenu();
    }
}
