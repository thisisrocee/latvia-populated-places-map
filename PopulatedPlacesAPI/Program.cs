using PopulatedPlacesAPI.Data;
using PopulatedPlacesAPI.Data.Interfaces;
using PopulatedPlacesAPI.Services;
using PopulatedPlacesAPI.Services.Interfaces;

var builder = WebApplication.CreateBuilder(args);


builder.Services.AddControllers();
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();
builder.Services.AddScoped<IParsingService, ParsingService>();
builder.Services.AddScoped<ICsvParser, CsvParser>();
builder.Services.AddScoped<IDataDownloader, DataDownloader>();
builder.Services.AddScoped<IDataExtractor, DataExtractor>();

builder.Services.AddHttpContextAccessor();

builder.Services.AddCors(options =>
{
    options.AddPolicy("AllowOrigin", build =>
        build.AllowAnyOrigin()
            .AllowAnyMethod()
            .AllowAnyHeader());
});

var app = builder.Build();

if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseCors("AllowOrigin");

app.UseHttpsRedirection();

app.UseAuthorization();

app.MapControllers();

app.Run();