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

//USER ENDPOINTS

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
//POST new User
app.MapPost("/newUser", (LoveLinkDbContext db, User user) =>
{
    db.Users.Add(user);
    db.SaveChanges();
    return Results.Created($"/newUser/{user.Id}", user);

});
//DELETE User
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
//UPDATE User
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
//GET User from UID
app.MapGet("/checkuserid/{uid}", (LoveLinkDbContext db, string uid) =>
{
    var user = db.Users.Where(x => x.UID == uid).ToList();
    if (uid == null)
    {
        return Results.NotFound();
    }
    else
    {
        return Results.Ok(user);
    }
});

//JOURNAL ENDPOINTS

//GET all of a Users PUBLIC Journals
app.MapGet("/userpublicjournals/{id}", (LoveLinkDbContext db, int id) =>
{
    var userPublicJournals = db.Users
        .Include(u => u.Journals.Where(j => j.Visibility == "Public"))
        .FirstOrDefault(u => u.Id == id);

    if (userPublicJournals == null)
    {
        return Results.NotFound(id);
    }

    return Results.Ok(userPublicJournals);
});
//GET all of a Users PRIVATE Journals
app.MapGet("/userprivatejournals/{id}", (LoveLinkDbContext db, int id) =>
{
    var userPrivateJournals = db.Users
        .Include(u => u.Journals.Where(j => j.Visibility == "Private"))
        .FirstOrDefault(u => u.Id == id);

    if (userPrivateJournals == null)
    {
        return Results.NotFound(id);
    }

    return Results.Ok(userPrivateJournals);
});
//GET ALL of a Users Journals
app.MapGet("/alluserjournals/{id}", (LoveLinkDbContext db, int id) =>
{
    var UserJournals = db.Users
    .Include(j => j.Journals)
    .FirstOrDefault(u => u.Id == id);

    if (UserJournals == null)
    {
        return Results.NotFound(id);
    }

    return Results.Ok(UserJournals);

});
//GET Journal by Id
app.MapGet("/journal/{id}", (LoveLinkDbContext db, int id) =>
{
    var journal = db.Journals.Where(j => j.Id == id);
    return journal;
});
//GET ALL Journals
app.MapGet("/alljournals", (LoveLinkDbContext db) => 
{
    return db.Journals.ToList();
});
//POST New Journal
app.MapPost("/newjournal", async (LoveLinkDbContext db, Journal journal) =>
{
    db.Journals.Add(journal); ;
    await db.SaveChangesAsync();
    return Results.Created($"/journal/{journal.Id}", journal);
});
//UPDATE Journal Entry
app.MapPut("/journal/{id}", (LoveLinkDbContext db, int id, Journal updatedJournal) =>
{
    var existingJournal = db.Journals.Where(j => j.Id == id).FirstOrDefault();

    if (existingJournal == null)
    {
        return Results.NotFound("Journal Entry not found");
    }

    existingJournal.UserId = updatedJournal.UserId;
    existingJournal.PartnerId = updatedJournal.PartnerId;
    existingJournal.PartnerUid = updatedJournal.PartnerUid;
    existingJournal.Name = updatedJournal.Name;
    existingJournal.Entry = updatedJournal.Entry;
    existingJournal.DateEntered = updatedJournal.DateEntered;
    existingJournal.Visibility = updatedJournal.Visibility;


    db.SaveChanges();

    return Results.Ok(existingJournal);
});

app.Run();