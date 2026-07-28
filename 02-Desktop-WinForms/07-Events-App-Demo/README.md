# 14. Комплексний демо-застосунок органайзера подій (MyEventsWF)

> **Курс IT Step Academy**: Windows Forms & Бази даних  
> **Технологічний стек**: .NET 10, C# 13, Windows Forms, ADO.NET (Dapper), Entity Framework Core 9, Microsoft Generic Host, Dependency Injection, MVP (Model-View-Presenter).

---

## 📌 Огляд проекту

**MyEvents** — це завершений навчально-практичний десктопний застосунок для організації та моніторингу подій, конференцій, мітапів і фотозвітів. Проект демонструє передові інженерні практики розробки сучасного десктопного ПЗ на платформі .NET:

1. **Архітектура корпоративного рівня**:
   - **Microsoft Extensions Generic Host**: конфігурація через `appsettings.json`, логування через `ILogger`, повноцінний контейнер залежностей `IServiceProvider` (Dependency Injection).
   - **Подвійний рівень доступу до даних (DAL)**:
     - `MyEventsAdoNetDB`: швидкі низькорівневі запити через ADO.NET та **Dapper**, реалізація патернів Generic Repository та Unit of Work з транзакціями `IDbTransaction`.
     - `MyEventsEntityFrameworkDb`: сучасний ORM підхід через **EF Core 9**, міграції, зв'язки 1:1, 1:N та M:N (`CategoriesEvents`), відстеження змін `ChangeTracker`.
   - **Патерн MVP (Model-View-Presenter)**: відділення логіки відображення (форми, MDI-контейнер) від бізнес-правил та сервісів.

2. **Сучасний користувацький інтерфейс (UI)**:
   - **Безрамкове вікно (Borderless Form)**: кастомне перетягування через Win32 API (`SendMessage`, `ReleaseCapture`), інтерактивна зміна розмірів по краях через `WM_NCHITTEST`.
   - **Динамічна палітра тем (Flat Theme UI)**: автоматичний підбір акцентних кольорів при переходах між розділами меню.
   - **MDI-контейнер**: навігація через бокове меню з плавним вбудовуванням дочірніх форм (`ProfileForm`, `AllEventsForm`, `CategoryForm`, `GalleryForm`, `ForumForm`).
   - **Інтерактивна фотогалерея**: завантаження зображень у БД (BLOB / varbinary), стиснення та масштабування на льоту, відображення сітки прев'ю в `TableLayoutPanel`, виділення та видалення при наведенні миші.

---

## 🏗️ Структура рішення

```text
07-Events-App-Demo/
├── MyEventsWF.sln                       # Загальне рішення Visual Studio
├── MyEventsDb_Create_And_Seed.sql       # Повний SQL-скрипт створення БД та сідування
├── MyEventsWF/                          # Головний WinForms клієнт
│   ├── Program.cs                       # Точка входу: Generic Host, DI, Startup
│   ├── ThemeColor.cs                    # Керування кольоровими палітрами
│   ├── Forms/                           # Дочірні форми застосунку
│   │   ├── AllEventsForm.cs             # Пошук та перегляд подій
│   │   ├── CategoryForm.cs              # Керування категоріями
│   │   ├── DetaisOfEventForm.cs         # Деталі та параметри події
│   │   ├── ForumForm.cs                 # Форум та повідомлення
│   │   ├── GalleryForm.cs               # Галерея з завантаженням та обробкою фото
│   │   └── ProfileForm.cs               # Профіль користувача та налаштування
│   ├── PRESENTERS/                      # MVP Presenters
│   │   ├── MainMenuPresenter.cs         # Презентер головного меню
│   │   └── GalleryPresenter.cs          # Презентер фотогалереї
│   ├── VIEWS/                           # MVP Views та інтерфейси
│   │   ├── IMainMenuView.cs             # Контракт інтерфейсу головного меню
│   │   ├── MainMenuView.cs              # Реалізація форми головного меню (MDI)
│   │   └── IGalleryView.cs              # Контракт для фотогалереї
│   └── appsettings.json                 # Конфігурація рядків підключення та логування
├── MyEventsAdoNetDB/                    # DAL на базі ADO.NET та Dapper
│   ├── Entities/                        # Сутності даних
│   └── Repositories/                    # Репозиторії та Unit of Work
└── MyEventsEntityFrameworkDb/           # DAL на базі EF Core 9
    ├── DbContexts/                      # MyEventsDbContext
    ├── Entities/                        # EF Core модель сутностей
    └── Migrations/                      # Міграції бази даних
```

---

## 🚀 Швидкий запуск

### 1. Створення та ініціалізація бази даних
Відкрийте SQL Server Management Studio або Azure Data Studio та виконайте скрипт:
```sql
-- Знаходиться у корені модуля:
MyEventsDb_Create_And_Seed.sql
```
Скрипт створить базу `MyEventsDb`, всі 10 таблиць, індекси, зовнішні ключі та початкові дані (міста, ролі, тестові події #1, #2, #3, #11).

### 2. Перевірка рядка підключення
За замовчуванням у `appsettings.json` встановлено локальний SQL Server:
```json
"ConnectionStrings": {
  "MSSQLConnection": "Server=(localdb)\\mssqllocaldb;Database=MyEventsDb;Trusted_Connection=True;MultipleActiveResultSets=true;TrustServerCertificate=True"
}
```
Якщо ви використовуєте інший екземпляр (наприклад, `Server=.\SQLEXPRESS;...`), змініть значення у файлі.

### 3. Збірка та запуск
```bash
dotnet build
dotnet run --project MyEventsWF/MyEventsWF.csproj
```
