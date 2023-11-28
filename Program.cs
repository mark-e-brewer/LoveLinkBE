using LoveLink.Models;
using Microsoft.EntityFrameworkCore;
using System.Text.Json.Serialization;
using Microsoft.AspNetCore.Http.Json;
using LoveLink;
using Microsoft.AspNetCore.Builder;
using System.Runtime.CompilerServices;
using System.Net;
using LoveLink.DTOs;
using Microsoft.AspNetCore.Mvc;

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

builder.Services.AddControllers().AddJsonOptions(options =>
{
    options.JsonSerializerOptions.WriteIndented = true;
    options.JsonSerializerOptions.PropertyNameCaseInsensitive = true;
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
//GET all MyMoods
app.MapGet("/myMoods", (LoveLinkDbContext db) => 
{
    return db.MyMoods.ToList();
});
//POST a MyMood to a User by Id
app.MapPost("/user/{userId}/mymood/{moodId}", async (LoveLinkDbContext db, int userId, int moodId) =>
{
    // Find the user and mood based on the provided IDs
    var user = await db.Users.FindAsync(userId);
    var mood = await db.MyMoods.FindAsync(moodId);

    // Check if the user and mood exist
    if (user == null || mood == null)
    {
        return Results.NotFound("User or mood not found");
    }

    // Attach the mood to the user
    user.MyMood = mood;

    // Save changes to the database
    await db.SaveChangesAsync();

    return Results.Ok();
});
//GET User with MyMood DTO
app.MapGet("/userWithMyMood/{userId}", async (int userId, [FromServices] LoveLinkDbContext dbContext) =>
{
    var userWithMyMood = await dbContext.Users
        .Include(u => u.MyMood)
        .Where(u => u.Id == userId)
        .Select(u => new MyMoodUserDto
        {
            UserId = u.Id,
            UserName = u.Name,
            MyMood = new MyMoodDto
            {
                MyMoodId = u.MyMood.Id,
                MoodName = u.MyMood.Mood
            }
        })
        .FirstOrDefaultAsync();

    if (userWithMyMood == null)
    {
        return Results.NotFound();
    }

    return Results.Ok(userWithMyMood);
});


app.Run();