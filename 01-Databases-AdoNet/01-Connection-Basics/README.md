# 01. Підключення до БД (Connection Basics)

## 📌 Огляд модуля
Базове підключення до MS SQL Server за допомогою SqlConnection та ConnectionStrings.

---

## 🔑 Ключові концепції та технології
- **SqlConnection**
- **ConnectionString**
- **StateChange event**
- **Connection pooling**
- **Try-catch-finally vs using**

---

## 📂 Структура проєкту
Код даного модуля містить вихідні проєкти C#, рішення Visual Studio (`.sln`), конфігурації та допоміжні SQL-скрипти створення БД.

---

## 🚀 Як запустити
1. Відкрийте файл рішення (`.sln`) у **Visual Studio** або **JetBrains Rider**.
2. Якщо в модулі присутній `.sql` файл, виконайте його в **SQL Server Management Studio (SSMS)** або Visual Studio SQL Object Explorer для створення необхідних таблиць та тестових даних.
3. Перевірте та за потреби відкоригуйте рядок підключення (`connectionString`) у файлі конфігурації (`App.config` або `appsettings.json`).
4. Запустіть проєкт (`F5` або `dotnet run`).
