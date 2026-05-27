using API;
using Microsoft.EntityFrameworkCore;

var builder = WebApplication.CreateBuilder(args);
builder.Services.AddDbContext<TodoDB>(opt => opt.UseInMemoryDatabase("TodoList"));
builder.Services.AddDatabaseDeveloperPageExceptionFilter();

var app = builder.Build();

//app.MapGet("/", () => "Hello World!");
app.MapGet("/todoitems", async (TodoDB db) => await db.Tasklist.ToListAsync());
app.MapGet("/todoitems/complete", async (TodoDB db) => await db.Tasklist.Where(t => t.DONE).ToListAsync());
app.MapGet
	(
	"todoitems/{id}",
	async (int id, TodoDB db) => 
	await db.Tasklist.FindAsync(id) is TODO todo ? Results.Ok(todo) : Results.NotFound()
	);

app.MapPost
	(
		"/todoitems",
		async (TODO todo, TodoDB db) =>
		{ 
			db.Tasklist.Add(todo);
			await db.SaveChangesAsync();
			return Results.Created($"/todoitems/{todo.ID}", todo);
		}
	);

app.MapPut
	(
		"/todoitems/{id}",
		async (int id, TODO inputTask, TodoDB db) =>
		{ 
			TODO? todo = await db.Tasklist.FindAsync(id);
			if(todo is null)return Results.NotFound();

			todo.Name = inputTask.Name;
			todo.DONE = inputTask.DONE;

			await db.SaveChangesAsync();
			return Results.NoContent();
		}
	);

app.MapDelete
	(
		"/todoitems/{id}",
		async (int id, TodoDB db) =>
		{
			if (await db.Tasklist.FindAsync(id) is TODO todo)
			{ 
				db.Tasklist.Remove(todo);
				await db.SaveChangesAsync();
				return  Results.NoContent() ;
			}
			return Results.NotFound();
		}
	);

app.MapPatch
	(
		"todoitems/{id}",
		async(int id, TodoPatchDto inputTodo, TodoDB db) =>
		{
			TODO todo = await db.Tasklist.FindAsync(id);
			if (todo is null) return Results.NotFound();

			if(inputTodo.Name is not null) todo.Name = inputTodo.Name;
			if(inputTodo.DONE is not null) todo.DONE = inputTodo.DONE.Value;

			await db.SaveChangesAsync();
			return Results.NoContent();
		}
	);

app.Run();
