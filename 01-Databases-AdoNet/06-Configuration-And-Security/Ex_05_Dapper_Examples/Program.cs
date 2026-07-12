using Dapper;
using Ex_05_Dapper_Examples;
using System.Data;
using System.Data.SqlClient;
using System.Linq;

Console.OutputEncoding = System.Text.Encoding.UTF8;

SqlConnection db = new SqlConnection(@"Data Source=DESKTOP-TOMKA;Initial Catalog=BookStoreContext;Integrated Security=True;Connect Timeout=60;Encrypt=False;TrustServerCertificate=False;ApplicationIntent=ReadWrite;MultiSubnetFailover=False");

bool showMenu = true;
while (showMenu)
{
	showMenu = MainMenu();
}


bool MainMenu()
{
	Console.Clear();
	Console.Write("Please choose one of the following in the menu" + Environment.NewLine);
	Console.Write("\t [1] - Basic List Query" + Environment.NewLine);
	Console.Write("\t [2] - Map Column Names with Class Properties" + Environment.NewLine);
	Console.Write("\t [3] - Insert Data" + Environment.NewLine);
	Console.Write("\t [4] - Update Data" + Environment.NewLine);
	Console.Write("\t [5] - Delete Data" + Environment.NewLine);
	Console.Write("\t [6] - Retrieve Parent-Child Objects" + Environment.NewLine);
	Console.Write("\t [7] - Stored Procedures" + Environment.NewLine);
	Console.Write("\t [8] - Dynamic Parameters" + Environment.NewLine);
	Console.Write("\t [9] - IN Operator Support" + Environment.NewLine);
	Console.Write("\t [10] - Dynamic Objects" + Environment.NewLine);
	Console.Write("\t [11] - Multi Mapping" + Environment.NewLine);
	Console.Write("\t [0] - Exit" + Environment.NewLine);            
	Console.Write("Enter your choice: ");


	switch (Console.ReadLine())
	{
		case "1":
 			Console.Write("== START 01 ======================" + Environment.NewLine);
			var watch = System.Diagnostics.Stopwatch.StartNew();
				Basic_List_Query();
			watch.Stop();
			Console.WriteLine($"->> Execution Time: {watch.ElapsedMilliseconds} ms" + Environment.NewLine);
			Console.ReadKey();
			return true;
		case "2":
			Console.Write("==>> START 02======================" + Environment.NewLine);
			watch = System.Diagnostics.Stopwatch.StartNew();
				Map_Column_Names_with_Class_Properties();
			watch.Stop();
			Console.WriteLine($"->> Execution Time: {watch.ElapsedMilliseconds} ms" + Environment.NewLine);
			Console.ReadKey();
			return true;
		case "3":
			Console.Write("==>> START 03======================" + Environment.NewLine);
			watch = System.Diagnostics.Stopwatch.StartNew();
				Insert_Data();
			watch.Stop();
			Console.WriteLine($"->> Execution Time: {watch.ElapsedMilliseconds} ms" + Environment.NewLine);
			Console.ReadKey();
			return true;
		case "4":
			Console.Write("==>> START 04======================" + Environment.NewLine);
			watch = System.Diagnostics.Stopwatch.StartNew();
				Update_Data();
			watch.Stop();
			Console.WriteLine($"->> Execution Time: {watch.ElapsedMilliseconds} ms" + Environment.NewLine);
			Console.ReadKey();
			return true;
		case "5":
			Console.Write("==>> START 05======================" + Environment.NewLine);
			watch = System.Diagnostics.Stopwatch.StartNew();
				Delete_Data();
			watch.Stop();
			Console.WriteLine($"->> Execution Time: {watch.ElapsedMilliseconds} ms" + Environment.NewLine);
			Console.ReadKey();
			return true;
		case "6":
			Console.Write("==>> START 05======================" + Environment.NewLine);
			watch = System.Diagnostics.Stopwatch.StartNew();
				Retrieve_Parent_Child_Objects(1);
				Retrieve_Parent_Child_Objects(2);
			watch.Stop();
			Console.WriteLine($"->> Execution Time: {watch.ElapsedMilliseconds} ms" + Environment.NewLine);
			Console.ReadKey();
			return true;
		case "7":
			Console.Write("==>> START 05======================" + Environment.NewLine);
			watch = System.Diagnostics.Stopwatch.StartNew();
				Stored_Procedures(2);
				Stored_Procedures(3);
			watch.Stop();
			Console.WriteLine($"->> Execution Time: {watch.ElapsedMilliseconds} ms" + Environment.NewLine);
			Console.ReadKey();
			return true;
		case "8":
			Console.Write("==>> START 05======================" + Environment.NewLine);
			watch = System.Diagnostics.Stopwatch.StartNew();
			watch.Stop();
			Console.WriteLine($"->> Execution Time: {watch.ElapsedMilliseconds} ms" + Environment.NewLine);
			Console.ReadKey();
			return true;
		case "9":
			Console.Write("==>> START 05======================" + Environment.NewLine);
			watch = System.Diagnostics.Stopwatch.StartNew();
			IN_Operator_Support (1,3, 4);
			watch.Stop();
			Console.WriteLine($"->> Execution Time: {watch.ElapsedMilliseconds} ms" + Environment.NewLine);
			Console.ReadKey();
			return true;
		case "10":
			Console.Write("==>> START 05======================" + Environment.NewLine);
			watch = System.Diagnostics.Stopwatch.StartNew();
				Dynamic_Objects(1,2,4);
			watch.Stop();
			Console.WriteLine($"->> Execution Time: {watch.ElapsedMilliseconds} ms" + Environment.NewLine);
			Console.ReadKey();
			return true;
		case "11":
			Console.Write("==>> START 05======================" + Environment.NewLine);
			watch = System.Diagnostics.Stopwatch.StartNew();
				Multy_Mapping();
			watch.Stop();
			Console.WriteLine($"->> Execution Time: {watch.ElapsedMilliseconds} ms" + Environment.NewLine);
			Console.ReadKey();
			return true;
		case "0":
			return false;
		default:
			Console.Write("Incorrect choice. Please select valid choice.");
			return true;
	}
}


// --01--
async Task Basic_List_Query()
{
	IEnumerable<Author> authors = await db.QueryAsync<Author>("SELECT * FROM Authors");
	foreach (var author in authors)
	{
		Console.WriteLine(author.FirstName + " " + author.LastName);
	}
}

// -- 02--
async Task Map_Column_Names_with_Class_Properties()
{
	IEnumerable<Author> authors = await db.QueryAsync<Author>("SELECT FirstName, LastName FROM Authors");

	foreach (var author in authors)
	{
		Console.WriteLine(author.FirstName + " " + author.LastName);
	}
}

// -- 03--
async Task Insert_Data()
{
	Author author = new Author()
	{
		FirstName = "William",
		LastName = "Shakespeare"
	};
	string sqlQuery = "INSERT INTO Authors (FirstName, LastName) VALUES(@FirstName, @LastName)";
	int rowsAffected = await db.ExecuteAsync(sqlQuery, author);
	Console.WriteLine("Кількість всталених рядочків - " + rowsAffected);
	Console.WriteLine(author.FirstName + " " + author.LastName + " був вставлений у теблицю!");


	rowsAffected = db.Execute(sqlQuery,
			new[]
			{
				new {FirstName = "Emily", LastName = "Dickinson"},
				new {FirstName = "Leo", LastName = "Tolstoy"},
				new {FirstName = "Rabindranath", LastName = "Tagore"}
			}
		);
	Console.WriteLine(" " + Environment.NewLine);
	Console.WriteLine("Кількість всталених рядочків - " + rowsAffected);
	List<Author> authors = db.Query<Author>("SELECT * FROM Authors").ToList();

	foreach (var x in authors)
	{
		Console.WriteLine(x.FirstName + " " + x.LastName);
	}
}

// ---04---
async Task Update_Data()
{
	string sql = "UPDATE Books SET Category = @Category WHERE Id = @Id;";
	int rowsAffected = await db.ExecuteAsync(sql, new { Id = 3, Category = "Education" });
	Console.WriteLine("Кількість змынених рядочків - " + rowsAffected);

	rowsAffected = await db.ExecuteAsync (sql,
		new[]
		{
					new { Id = 4, Category = "Education" },
					new { Id = 5, Category = "Education" },
		}
	);
	Console.WriteLine("Кількість змінених рядочків - " + rowsAffected);

	List<Book> books = db.Query<Book>("SELECT * FROM Books").ToList();
	foreach (var book in books)
	{
		Console.WriteLine("Id: {0} \t Title: {1} \t  Category: {2}", book.Id, book.Title, book.Category);
	}
}

// ---05---
async Task Delete_Data()
{
	string sql = "DELETE FROM Authors WHERE Id = @Id;";
	int rowsAffected = await db.ExecuteAsync(sql, new { Id = 4 });

	rowsAffected = await db.ExecuteAsync(sql,
	new[]
	{
		new { Id = 20 },
		new { Id = 21 },
		new { Id = 22 }
	});

	List<Author> authors = db.Query<Author>("SELECT * FROM Authors").ToList();
	foreach (var author in authors)
	{
		Console.WriteLine(author.FirstName + " " + author.LastName);
	}
}

// --06--

async Task Retrieve_Parent_Child_Objects(int id)
{
	string sql =
		"SELECT * FROM Authors WHERE Id = @Id;" +
		"SELECT * FROM Books WHERE AuthorId = @Id;";

	var results = await db.QueryMultipleAsync(sql, new { Id = id });
	var author = results.Read<Author>().SingleOrDefault();
	var books = results.Read<Book>().ToList();

	if (author != null && books != null)
	{
		author.Books = books;

		Console.WriteLine(author.FirstName + " " + author.LastName);

		foreach (var book in author.Books)
		{
			Console.WriteLine("\t Title: {0} \t  Category: {1}", book.Title, book.Category);
		}
	}
}

// --07 --
async Task Stored_Procedures(int id)
{
	string sql = "GetAuthor";
	var results = db.QueryMultiple(sql, new { Id = id }, commandType: CommandType.StoredProcedure);

	var author = results.Read<Author>().SingleOrDefault();
	var books = results.Read<Book>().ToList();

	if (author != null && books != null)
	{
		author.Books = books;

		Console.WriteLine(author.FirstName + " " + author.LastName);

		foreach (var book in author.Books)
		{
			Console.WriteLine("\t Title: {0} \t  Category: {1}", book.Title, book.Category);
		}
	}

}

// -- 08--

async Task Dynamic_Parameters(int id) 
{
	string sql = "GetAuthor";
	var results = db.QueryMultiple(sql, new { Id = id }, commandType: CommandType.StoredProcedure);
	var author = results.Read<Author>().SingleOrDefault();
	var books = results.Read<Book>().ToList();

	if (author != null && books != null)
	{
		author.Books = books;
		Console.WriteLine(author.FirstName + " " + author.LastName);
		foreach (var book in author.Books)
		{
			Console.WriteLine("\t Title: {0} \t  Category: {1}", book.Title, book.Category);
		}
	}

	// з динамічними параметрами
	DynamicParameters parameter = new DynamicParameters();
	parameter.Add("@Id", id);

	var results_02 = db.QueryMultiple(sql, parameter, commandType: CommandType.StoredProcedure);
	var author_02 = results_02.Read<Author>().SingleOrDefault();
	var books_02 = results_02.Read<Book>().ToList();

	if (author_02 != null && books_02 != null)
	{
		author_02.Books = books_02;

		Console.WriteLine(author_02.FirstName + " " + author_02.LastName);

		foreach (var book in author_02.Books)
		{
			Console.WriteLine("\t Title: {0} \t  Category: {1}", book.Title, book.Category);
		}
	}
}

// --09--
async Task IN_Operator_Support(params int[] ids)
{
	List<Author> authors =
			db.Query<Author>("SELECT * FROM Authors WHERE Id IN @Ids", new { Ids = ids })
			.ToList();

	foreach (var author in authors)
	{
		Console.WriteLine(author.FirstName + " " + author.LastName);
	}
}

// --10--
async Task Dynamic_Objects(params int[] ids)
{
	List<Author> authors_01 =
		   db.Query<Author>("SELECT * FROM Authors WHERE Id IN @Ids", new { Ids = ids })
		   .ToList();

	foreach (var author in authors_01)
	{
		Console.WriteLine(author.FirstName + " " + author.LastName);
	}

	Console.WriteLine(" ");

	List<dynamic> authors =
			db.Query("SELECT * FROM Authors WHERE Id IN @Ids", new { Ids = ids })
			.ToList();

	foreach (var author in authors)
	{
		Console.WriteLine(author.FirstName + " " + author.LastName);
	}
}


//-- 11 --
async Task Multy_Mapping()
{
	string sql = "SELECT * FROM Authors A INNER JOIN Books B ON A.Id = B.AuthorId";
	var authorDictionary = new Dictionary<int, Author>();

	IEnumerable<Author> authors = await db.QueryAsync<Author, Book, Author>(
			sql,
			(author, book) =>
			{
				Author authorEntry;

				if (!authorDictionary.TryGetValue(author.Id, out authorEntry))
				{
					authorEntry = author;
					authorEntry.Books = new List<Book>();
					authorDictionary.Add(authorEntry.Id, authorEntry);
				}

				authorEntry.Books.Add(book);
				return authorEntry;
			},
			splitOn: "Id");

		authors.Distinct()
		.ToList();

	foreach (var author in authors)
	{
		Console.WriteLine(author.FirstName + " " + author.LastName);

		foreach (var book in author.Books)
		{
			Console.WriteLine("\t Title: {0} \t  Category: {1}", book.Title, book.Category);
		}
	}
}
