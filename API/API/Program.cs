using API;
using Microsoft.EntityFrameworkCore;

var builder = WebApplication.CreateBuilder(args);
builder.Services.AddDbContext<TodoDB>(opt => opt.UseInMemoryDatabase("TodoList"));
builder.Services.AddDatabaseDeveloperPageExceptionFilter();

WebApplication app = builder.Build();

//app.MapGet("/", () => "Hello World!");

RouteGroupBuilder todoitems = app.MapGroup("/todoitems");

todoitems.MapGet("/", async (TodoDB db) => await db.Tasklist.ToListAsync());
todoitems.MapGet("/complete", async (TodoDB db) => await db.Tasklist.Where(t => t.DONE).ToListAsync());
todoitems.MapGet
	(
	"/{id}",
	async (int id, TodoDB db) => 
	await db.Tasklist.FindAsync(id) is TODO todo ? Results.Ok(todo) : Results.NotFound()
	);

todoitems.MapPost
	(
		"/",
		async (TODO todo, TodoDB db) =>
		{ 
			db.Tasklist.Add(todo);
			await db.SaveChangesAsync();
			return Results.Created($"/todoitems/{todo.ID}", todo);
		}
	);

todoitems.MapPut
	(
		"/{id}",
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

todoitems.MapDelete
	(
		"/{id}",
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

todoitems.MapPatch
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
