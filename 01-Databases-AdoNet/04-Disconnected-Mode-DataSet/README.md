# 04. Незв'язний режим: DataSet та SqlDataAdapter

## 📌 Огляд модуля
Архітектура незв'язного режиму (Disconnected Mode): кешування даних у пам'яті через DataSet і DataTable.

---

## 🔑 Ключові концепції та технології
- **DataSet**
- **DataTable**
- **SqlDataAdapter**
- **SqlCommandBuilder**
- **DataRowState**
- **Offline Data Caching**

---

## 📂 Структура проєкту
Код даного модуля містить вихідні проєкти C#, рішення Visual Studio (`.sln`), конфігурації та допоміжні SQL-скрипти створення БД.

---

## 🚀 Як запустити
1. Відкрийте файл рішення (`.sln`) у **Visual Studio** або **JetBrains Rider**.
2. Якщо в модулі присутній `.sql` файл, виконайте його в **SQL Server Management Studio (SSMS)** або Visual Studio SQL Object Explorer для створення необхідних таблиць та тестових даних.
3. Перевірте та за потреби відкоригуйте рядок підключення (`connectionString`) у файлі конфігурації (`App.config` або `appsettings.json`).
4. Запустіть проєкт (`F5` або `dotnet run`).
