using Microsoft.Extensions.Logging;
using MVP.Views;

namespace MyEventsWF.PRESENTERS
{
    internal class MainMenuPresenter
    {
        private readonly IMainMenuView mainMenuView;
        private readonly IServiceProvider serviceProvider;
        private readonly ILogger<MainMenuPresenter> logger;

        public MainMenuPresenter(
            IMainMenuView mainMenuView,
            IServiceProvider serviceProvider,
            ILogger<MainMenuPresenter> logger)
        {
            this.mainMenuView = mainMenuView;
            this.serviceProvider = serviceProvider;
            this.logger = logger;

            this.mainMenuView.ShowGalleryView += ShowGalleryHandler;
            this.mainMenuView.ShowForumView += ShowForumHandler;
            this.mainMenuView.ShowAllEventsView += ShowAllEventsHandler;
            this.mainMenuView.ShowProfileView += ShowProfileHandler;
            this.mainMenuView.ShowCategoryView += ShowCategoryHandler;
            this.mainMenuView.ShowDetailsOfEventView += ShowDetailsHandler;
        }

        private void ShowGalleryHandler(object? sender, EventArgs e)
        {
            logger.LogInformation("MVP Presenter: відкриття галереї події о {Time}", DateTime.UtcNow);
        }

        private void ShowForumHandler(object? sender, EventArgs e)
        {
            logger.LogInformation("MVP Presenter: відкриття форуму події о {Time}", DateTime.UtcNow);
        }

        private void ShowAllEventsHandler(object? sender, EventArgs e)
        {
            logger.LogInformation("MVP Presenter: запит списку всіх подій о {Time}", DateTime.UtcNow);
        }

        private void ShowProfileHandler(object? sender, EventArgs e)
        {
            logger.LogInformation("MVP Presenter: перегляд профілю користувача о {Time}", DateTime.UtcNow);
        }

        private void ShowCategoryHandler(object? sender, EventArgs e)
        {
            logger.LogInformation("MVP Presenter: керування категоріями подій о {Time}", DateTime.UtcNow);
        }

        private void ShowDetailsHandler(object? sender, EventArgs e)
        {
            logger.LogInformation("MVP Presenter: детальна інформація про подію о {Time}", DateTime.UtcNow);
        }
    }
}
