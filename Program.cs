using LoveLink.Models;
using Microsoft.EntityFrameworkCore;
using System.Text.Json.Serialization;
using Microsoft.AspNetCore.Http.Json;
using LoveLink;
using LoveLink.Utilities;
using Microsoft.AspNetCore.Builder;
using System.Runtime.CompilerServices;
using System.Net;
using LoveLink.DTOs;
using System.Linq;
using Microsoft.AspNetCore.Mvc;
using System.Net.Http.Json;
using System.Xml;
using System.Text.Json;

var builder = WebApplication.CreateBuilder(args);

builder.Services.AddControllers();
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

var MyAllowSpecificOrigins = "_myAllowSpecificOrigins";
//ADD CORS
builder.Services.AddCors(options =>
{
    options.AddPolicy(MyAllowSpecificOrigins,
        policy =>
        { 
            policy.WithOrigins("https://localhost:7205",
                                "http://localhost:3000",
                                "https://localhost:5145")
                                .AllowAnyHeader()
                                .AllowAnyOrigin()
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

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}
app.UseCors(MyAllowSpecificOrigins);

app.UseHttpsRedirection();

app.UseAuthentication();

app.UseAuthorization();

app.MapControllers();


//POST Partner Code
app.MapPost("/generatePartnerCode/{userid}", async (LoveLinkDbContext db, HttpContext context, int userid) =>
{
    int userId = userid;
    string partnerCode = LoveLinkDbContext.GenerateRandomCode();
    var user = await db.Users.FindAsync(userId);
    if (user != null)
    {
        user.PartnerCode = partnerCode;
        await db.SaveChangesAsync();
    }
    await context.Response.WriteAsync(partnerCode);
});
//FIND Matching Partner and attach needed info to both users
app.MapPost("/handlePartnerCode/{enteredCode}/{enteringUserId}", async (LoveLinkDbContext db, HttpContext context, string enteredCode, int enteringUserId) =>
{
    var enteringUser = await db.Users.FirstOrDefaultAsync(u => u.Id == enteringUserId);

    if (enteringUser != null)
    {
        var partnerUser = await db.Users.FirstOrDefaultAsync(u => u.PartnerCode == enteredCode);

        if (partnerUser != null)
        {

            enteringUser.PartnerUid = partnerUser.UID;
            enteringUser.PartnerId = partnerUser.Id;

            partnerUser.PartnerUid = enteringUser.UID;
            partnerUser.PartnerId = enteringUser.Id;

            enteringUser.PartnerCode = enteredCode;
            partnerUser.PartnerCode = enteredCode;

            await db.SaveChangesAsync();

            await context.Response.WriteAsync("Partner linking successful!");
        }
        else
        {
            await context.Response.WriteAsync("Invalid partner code. Please try again.");
        }
    }
    else
    {

        await context.Response.WriteAsync("Invalid user or partner code. Please try again.");
    }
});
//GET User by Id
app.MapGet("/user/{id}", async (LoveLinkDbContext db, int id) =>
{
    var user = await db.Users.FirstOrDefaultAsync(u => u.Id == id);
    return user;
});
//GET User from UID
app.MapGet("/checkuser/{uid}", async (LoveLinkDbContext db, string uid) =>
{
    var userExists = await db.Users.Where(x => x.UID == uid).FirstOrDefaultAsync();

    return userExists;
});
//CREATE a User
app.MapPost("/api/user", (LoveLinkDbContext db, User user) =>
{
    db.Users.Add(user);
    db.SaveChanges();
    return Results.Created($"/user/{user.Id}", user);
});
//GET UID from User Id
app.MapGet("/useruidFromId/{id}", (LoveLinkDbContext db, int id) => 
{
    var userExists = db.Users.Where(x => x.Id == id).FirstOrDefault();
    if (userExists == null)
    {
        return Results.StatusCode(400);
    }
    return Results.Ok(userExists.UID);
});
//GET All Users
app.MapGet("/users", (LoveLinkDbContext db) =>
{
    return db.Users.ToList();
});
//DELETE a User by Id
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
//UPDATE a User by Id
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
    existingUser.PartnerId = updatedUser.PartnerId;
    existingUser.PartnerUid = updatedUser.PartnerUid;
    existingUser.AnniversaryDate = updatedUser.AnniversaryDate;
    existingUser.PartnerCode = updatedUser.PartnerCode;

    db.SaveChanges();

    return Results.Ok(existingUser);
});
//UPDATE Profile Photo by userID
app.MapPut("/user/{id}/profile-photo", async (LoveLinkDbContext db, int id,[FromForm] IFormFile ProfilePhoto) =>
{
    var existingUser = await db.Users.Where(u => u.Id == id)
    .FirstOrDefaultAsync();

    if (existingUser == null)
    {
        return Results.NotFound("User not found");
    }

    existingUser.ProfilePhoto = FileUtility.SaveProfilePhoto(ProfilePhoto);

     await db.SaveChangesAsync();

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
//GET ALL of a Users Journals by User Id
app.MapGet("/alluserjournals/{id}", (LoveLinkDbContext db, int id) =>
{
    var user = db.Users
        .Include(u => u.Journals)
        .FirstOrDefault(u => u.Id == id);

    if (user == null)
    {
        return Results.NotFound(id);
    }

    var userDto = new UserDto
    {
        Id = user.Id,
        UID = user.UID,
        PartnerId = user.PartnerId,
        PartnerUid = user.PartnerUid,
        Journals = user.Journals.Select(j => new JournalDto
        {
            Id = j.Id,
            UserId = j.UserId,
            PartnerId = j.PartnerId,
            PartnerUid = j.PartnerUid,
            Name = j.Name,
            Entry = j.Entry,
            DateEntered = j.DateEntered,
            Visibility = j.Visibility,
            MoodTags = j.MoodTags // Assuming MoodTag is another DTO or model with similar structure
        }).ToList()
    };

    return Results.Ok(userDto);
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
//DELETE a Journal
app.MapDelete("/deletejournal/{journalId}", (LoveLinkDbContext db, int journalId) =>
{

    var journal = db.Journals.Find(journalId);

    if (journal == null)
    {
        return Results.NotFound("Journal not found");
    }

    db.Journals.Remove(journal);
    db.SaveChanges();

    return Results.Ok("Journal deleted successfully");
});
//GET Most Recent Journal
app.MapGet("/recentJournal/{id}", async (LoveLinkDbContext db, int id) =>
{
    var user = await db.Users
        .Include(u => u.Journals)
        .FirstOrDefaultAsync(u => u.Id == id);

    if (user == null)
    {
        return Results.NotFound();
    }

    var mostRecentJournal = user.Journals?
        .OrderByDescending(j => j.DateEntered)
        .Select(j => new
        {
            j.Id,
            j.UserId,
            j.PartnerId,
            j.PartnerUid,
            j.Name,
            j.Entry,
            j.DateEntered,
            j.Visibility,
            j.MoodTags
        })
        .FirstOrDefault();

    if (mostRecentJournal == null)
    {
        return Results.NotFound();
    }

    return Results.Ok(mostRecentJournal);
});

//MyMood Endpoints

app.MapPost("/createMyMood", async (LoveLinkDbContext db, MyMood myMood) => 
{
    db.MyMoods.Add(myMood); ;
    await db.SaveChangesAsync();
    return Results.Created($"/myMood/{myMood.Id}", myMood);
});

//GET all MyMoods
app.MapGet("/myMoods", (LoveLinkDbContext db) => 
{
    return db.MyMoods.ToList();
});
//POST a MyMood to a User by Id
app.MapPost("/user/{userId}/mymood/{moodId}", async (LoveLinkDbContext db, int userId, int moodId) =>
{
    Console.WriteLine($"Received request for userId: {userId}, moodId: {moodId}");

    var user = await db.Users.FindAsync(userId);
    var mood = await db.MyMoods.FindAsync(moodId);

    if (user == null || mood == null)
    {
        Console.WriteLine("User or mood not found");
        return Results.NotFound("User or mood not found");
    }
    user.MyMood = mood;
    await db.SaveChangesAsync();

    Console.WriteLine("User's mood updated successfully");
    return Results.Ok(new { });
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
            MyMood = u.MyMood != null
                ? new MyMoodDto
                {
                    MyMoodId = u.MyMood.Id,
                    MoodName = u.MyMood.Mood
                }
                : null
        })
        .FirstOrDefaultAsync();

    if (userWithMyMood == null)
    {
        return Results.NotFound();
    }

    return Results.Ok(userWithMyMood);
});
//REMOVE MyMood from User by Id
app.MapDelete("/removemymood/{userId}", async (LoveLinkDbContext db, int userId) =>
{
        var user = await db.Users
            .Include(u => u.MyMood)
            .FirstOrDefaultAsync(u => u.Id == userId);

        if (user == null)
        {
            return Results.NotFound($"User with ID {userId} not found.");
        }

        user.MyMood = null;

        await db.SaveChangesAsync();

        return Results.NoContent();
});

//MoodTag Endpoints

//GET all MoodTags
app.MapGet("/allMoodTags", (LoveLinkDbContext db) =>
{
    return db.MoodTags.ToList();
});

//POST SINGLE MoodTags to an existing Journal
app.MapPost("/attachmoodtags/{journalId}/{moodTagId}", (LoveLinkDbContext db, int journalId, int moodTagId) =>
{

    var journal = db.Journals.Find(journalId);
    var moodTag = db.MoodTags.Find(moodTagId);

    if (journal == null || moodTag == null)
    {
        return Results.NotFound("Journal or MoodTag not found");
    }

    var existingRelation = db.JournalMoodTags
        .Any(jmt => jmt.JournalId == journalId && jmt.MoodTagId == moodTagId);

    if (!existingRelation)
    {

        var journalMoodTag = new JournalMoodTag
        {
            JournalId = journalId,
            MoodTagId = moodTagId
        };

        db.JournalMoodTags.Add(journalMoodTag);
        db.SaveChanges();

        return Results.Ok("MoodTag attached to Journal successfully");
    }

    return Results.Ok("Relationship already exists"); ;
});
//GET Journal with MoodTags
app.MapGet("/journalwithmoodtags/{journalId}", (LoveLinkDbContext db, int journalId) =>
{
    var journalWithMoodTags = db.Journals
        .Where(j => j.Id == journalId)
        .Include(j => j.MoodTags)
        .Select(j => new JournalWithMoodTagsDTO
        {
            Id = j.Id,
            UserId = j.UserId,
            PartnerId = j.PartnerId,
            PartnerUid = j.PartnerUid,
            Name = j.Name,
            Entry = j.Entry,
            DateEntered = j.DateEntered,
            Visibility = j.Visibility,
            MoodTags = j.MoodTags.Select(mt => new MoodTagDTO
            {
                Id = mt.Id,
                Name = mt.Name,
                Description = mt.Description
            }).ToList()
        })
        .FirstOrDefault();

    if (journalWithMoodTags == null)
    {
        return Results.NotFound(journalId);
    }

    return Results.Ok(journalWithMoodTags);
});
//UPDATE MoodTags Associated with Journal
app.MapPut("/editmoodtags/{journalId}", (LoveLinkDbContext db, int journalId, MoodTagIds tagIds) =>
{
    var journal = db.Journals
        .Include(j => j.MoodTags)
        .FirstOrDefault(j => j.Id == journalId);

    if (journal == null)
    {
        return Results.NotFound("Journal not found");
    }

    journal.MoodTags.Clear();

    foreach (var moodTagId in tagIds.TagIds)
    {
        var moodTag = db.MoodTags.Find(moodTagId);
        if (moodTag != null)
        {
            journal.MoodTags.Add(moodTag);
        }
    }

    db.SaveChanges();

    return Results.Ok("MoodTags updated successfully");
});
//POST MULTIPLE MoodTags to a Journal
app.MapPost("/attachmanymoodtags/{journalId}", (LoveLinkDbContext db, int journalId, MoodTagIds tagIds) =>
{
    var journal = db.Journals
    .Include(j => j.MoodTags)
    .FirstOrDefault(j => j.Id == journalId);

    if (journal == null)
    {
        return Results.NotFound("Journal not found");
    }

    foreach (var moodTagId in tagIds.TagIds)
    {
        var moodTag = db.MoodTags.Find(moodTagId);
        if (moodTag != null)
        {
            journal.MoodTags.Add(moodTag);
        }
    }

    db.SaveChanges();

    return Results.Ok("MoodTags attached to Journal successfully");
});

app.MapPost("/createMoodTag", async (LoveLinkDbContext db, MoodTag moodTag) => 
{
    db.MoodTags.Add(moodTag); ;
    await db.SaveChangesAsync();
    return Results.Created($"/moodTag/{moodTag.Id}", moodTag);
});

//NOTIFICATIONS ENDPOINTS BELLOW
app.MapGet("/userNotifs/{id}", async (LoveLinkDbContext db, int id) =>
{
    var notifications = await db.Notifications
        .Where(n => n.ReceivingUserId == id)
        .OrderByDescending(n => n.DateSet) //New to Old
        .ToListAsync();

    return notifications;
});
//DELETE Notifications
app.MapDelete("/deleteNotif/{notificationId}", async (LoveLinkDbContext db, int notificationId) =>
{
    var notification = await db.Notifications
        .Where(n => n.Id == notificationId)
        .FirstOrDefaultAsync();

    if (notification != null)
    {
        db.Notifications.Remove(notification);
        await db.SaveChangesAsync();

        return Results.Ok();
    }
    else
    {
        return Results.NotFound();
    }
});
//Set Unviewed Notifications to Viewed
app.MapPut("/setNotifsViewed", async (LoveLinkDbContext db, HttpRequest request) =>
{
    try
    {
        using (var streamReader = new StreamReader(request.Body))
        {
            var json = await streamReader.ReadToEndAsync();
            var options = new JsonSerializerOptions
            {
                PropertyNameCaseInsensitive = true,
                Converters = { new JsonStringEnumConverter() }
            };

            var notificationListDto = JsonSerializer.Deserialize<NotificationListDTO>(json, options);

            if (notificationListDto != null && notificationListDto.Notifications != null && notificationListDto.Notifications.Count > 0)
            {
                foreach (var notifDto in notificationListDto.Notifications)
                {
                    var notifObj = new Notification
                    {
                        Id = notifDto.Id,
                        SourceUserId = notifDto.SourceUserId,
                        SourceUserName = notifDto.SourceUserName,
                        ReceivingUserId = notifDto.ReceivingUserId,
                        ReceivingUserName = notifDto.ReceivingUserName,
                        Title = notifDto.Title,
                        DateSet = notifDto.DateSet,
                        Viewed = true,
                        LinkToSource = notifDto.LinkToSource,
                    };

                    db.Notifications.Update(notifObj);
                }

                await db.SaveChangesAsync();

                return Results.Ok("Notifications marked as viewed.");
            }
            else
            {
                return Results.BadRequest("Invalid request body.");
            }
        }
    }
    catch (Exception ex)
    {
        return Results.BadRequest($"Error updating notifications: {ex.Message}");
    }
});
//GET unviewed notifications
app.MapGet("/unviewedNotifs/{id}", (LoveLinkDbContext db, int id) =>
{
    try
    {
        var unviewedNotifications = db.Notifications
            .Where(notification => notification.ReceivingUserId == id && (notification.Viewed == null || notification.Viewed == false))
            .ToList();

        var unviewedNotificationDtos = unviewedNotifications
            .Select(notification => new NotificationDTO
            {
                Id = notification.Id,
                SourceUserId = notification.SourceUserId,
                SourceUserName = notification.SourceUserName,
                ReceivingUserId = notification.ReceivingUserId,
                ReceivingUserName = notification.ReceivingUserName,
                Title = notification.Title,
                DateSet = notification.DateSet,
                Viewed = notification.Viewed,
                LinkToSource = notification.LinkToSource
            })
            .ToList();

        return Results.Ok(unviewedNotificationDtos);
    }
    catch (Exception ex)
    {
        return Results.BadRequest($"Error retrieving unviewed notifications: {ex.Message}");
    }
});


app.Run();