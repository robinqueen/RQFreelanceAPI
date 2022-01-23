using RQFreelanceAPI.Repository;
using RQFreelanceAPI.Repository.Interfaces;

var builder = WebApplication.CreateBuilder(args);


builder.Services.AddSingleton<DapperContext>();
builder.Services.AddScoped<IHousingPropertyRepo, HousingPropertyRepo>();


// Add services to the container.

builder.Services.AddControllers();
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();


builder.Services.AddCors(opt =>
{
    opt.AddDefaultPolicy(builder =>
    {
        builder.AllowAnyOrigin()
            .AllowAnyHeader()
            .AllowAnyMethod();
    });
});

builder.Services.AddCors();

var app = builder.Build();

// Configure the HTTP request pipeline.
//if (app.Environment.IsDevelopment())
//{
    app.UseSwagger();
    app.UseSwaggerUI();
//}




app.UseCors(
        options => options.AllowAnyOrigin().AllowAnyMethod()
    );
app.UseHttpsRedirection();

app.UseAuthorization();

app.MapControllers();

app.Run();

app.UseDeveloperExceptionPage();
