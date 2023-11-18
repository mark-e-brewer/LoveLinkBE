using LoveLink.Models;
using Microsoft.EntityFrameworkCore;
using System.Text.Json.Serialization;
using Microsoft.AspNetCore.Http.Json;
using LoveLink;
using Microsoft.AspNetCore.Builder;
using System.Runtime.CompilerServices;
using System.Net;

var builder = WebApplication.CreateBuilder(args);

var MyAllowSpecificOrigins = "_myAllowSpecificOrigins";
//ADD CORS
builder.Services.AddCors(options =>
{
    options.AddPolicy(MyAllowSpecificOrigins,
        policy =>
        {
            policy.WithOrigins("https://localhost:7205",
                                "http://localhost:5145")
                                .AllowAnyHeader()
                                .AllowAnyMethod();
        });
});

// Add services to the container.
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

// allows passing datetimes without time zone data 
AppContext.SetSwitch("Npgsql.EnableLegacyTimestampBehavior", true);

// allows our api endpoints to access the database through Entity Framework Core
builder.Services.AddNpgsql<LoveLinkDbContext>(builder.Configuration["LoveLinkDbConnectionString"]);

// Set the JSON serializer options
builder.Services.Configure<JsonOptions>(options =>
{
    options.SerializerOptions.ReferenceHandler = ReferenceHandler.IgnoreCycles;
});

var app = builder.Build();

app.UseCors(MyAllowSpecificOrigins);

app.MapGet("/uservalidate/{uid}", (LoveLinkDbContext db, string uid) =>
{
    var userExists = db.Users.Where(x => x.UID == uid).FirstOrDefault();
    if (userExists == null)
    {
        return Results.StatusCode(204);
    }
    return Results.Ok(userExists);
});

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseHttpsRedirection();
//GET All Users
app.MapGet("/users", (LoveLinkDbContext db) =>
{
    return db.Users.ToList();
});
//GET User by Id
app.MapGet("/user/{id}", (LoveLinkDbContext db, int id) =>
{
    var user = db.Users.Where(u => u.Id == id);
    return user;
});

app.MapPost("/newUser", (LoveLinkDbContext db, User user) =>
{
    db.Users.Add(user);
    db.SaveChanges();
    return Results.Created($"/newUser/{user.Id}", user);

});

app.MapDelete("/user/{id}", (LoveLinkDbContext db, int id) =>
{

    var userToDelete = db.Users.Where(u => u.Id == id).FirstOrDefault();

    if (userToDelete == null)
    {
        return Results.NotFound("User not found");
    }

    db.Users.Remove(userToDelete);
    db.SaveChanges();
    return Results.Ok(userToDelete);
});

app.MapPut("/user/{id}", (LoveLinkDbContext db, int id, User updatedUser) =>
{
    var existingUser = db.Users.Where(u => u.Id == id).FirstOrDefault();

    if (existingUser == null)
    {
        return Results.NotFound("User not found");
    }

    existingUser.UID = updatedUser.UID;
    existingUser.Name = updatedUser.Name;
    existingUser.Age = updatedUser.Age;
    existingUser.Bio = updatedUser.Bio;
    existingUser.Gender = updatedUser.Gender;
    existingUser.ProfilePhoto = updatedUser.ProfilePhoto;
    existingUser.PartnerId = updatedUser.PartnerId;
    existingUser.PartnerUid = updatedUser.PartnerUid;
    existingUser.AnniversaryDate = updatedUser.AnniversaryDate;
    existingUser.PartnerCode = updatedUser.PartnerCode;


    db.SaveChanges();

    return Results.Ok(existingUser);
});


app.Run();
