using MyStore.API.Filters;
using MyStore.Infrasctructure;
using MyStore.Infrasctructure.DataAccess;
using MyStore.Infrasctructure.Extensions;
using MyStore.Infrasctructure.Migration;
using MyStore.Infrasctructure.Seed;
using MyStore.Application;
using System.Reflection;
using System.Threading.Tasks;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
builder.Services.AddControllers();
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();
builder.Services.AddMvc(options => options.Filters.Add(typeof(ExceptionFilter)));
builder.Services.AddInfrastructure(builder.Configuration);
builder.Services.AddApplication(builder.Configuration);

//builder.Services.AddMediatR(options =>
//{ 
//    options.RegisterServicesFromAssemblies(typeof(MyStore.Application.DependencyInjectionExtension).Assembly);
//});

var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseHttpsRedirection();

app.UseAuthorization();

app.MapControllers(); 
await MigrateDatabase();
app.Run();
async Task MigrateDatabase()
{
    using (var scope = app.Services.CreateScope())
    {
        var services = scope.ServiceProvider;

        
        var connectionString = builder.Configuration.ConnectionString();
        DatabaseMigration.Migrate(connectionString, services);

        var context = services.GetRequiredService<AppDbContext>();
        
        var mongoContext = services.GetRequiredService<MongoDbContext>();
        await MongoSeedData.SeedAsync(context,mongoContext);
    }
}