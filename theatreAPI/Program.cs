using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Microsoft.Identity.Client.Extensions.Msal;
using System.Data.SqlTypes;
using theatreAPI.Connection;
using theatreAPI.Models; 

var builder = WebApplication.CreateBuilder(args);

builder.Services.AddDbContext<TypeOfStoringDb>(options =>
{
    options.UseSqlServer(builder.Configuration.GetConnectionString("ConnectionSqlServer"));
});

builder.Services.AddDbContext<ReceptionWaysDb>(options =>
{
    options.UseSqlServer(builder.Configuration.GetConnectionString("ConnectionSqlServer"));
});

builder.Services.AddDbContext<WorkTechniqueDb>(options =>
{
    options.UseSqlServer(builder.Configuration.GetConnectionString("ConnectionSqlServer"));
});

builder.Services.AddDbContext<StorageDb>(options =>
{
    options.UseSqlServer(builder.Configuration.GetConnectionString("ConnectionSqlServer"));
});

builder.Services.AddDbContext<PositionDb>(options =>
{
    options.UseSqlServer(builder.Configuration.GetConnectionString("ConnectionSqlServer"));
});

builder.Services.AddControllers();
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

var app = builder.Build();

if (app.Environment.IsDevelopment())
{
    using var scope = app.Services.CreateScope();
    var db = scope.ServiceProvider.GetRequiredService<TypeOfStoringDb>();
    db.Database.EnsureCreated();

    app.UseSwagger();
    app.UseSwaggerUI();
}

// TYPE OF STORING

app.MapGet("/typesStoring", async (TypeOfStoringDb db) => await db.TypesOfStoring.ToListAsync());

app.MapGet("/typesStoring/{id}", async (int id, TypeOfStoringDb db) =>
    await db.TypesOfStoring.FirstOrDefaultAsync(t => t.Id == id) is TypeOfStoring typeStore
    ? Results.Ok(typeStore)
    : Results.NotFound());

app.MapPost("/typesStoring", async ([FromBody] TypeOfStoring typeStore, TypeOfStoringDb db) =>
    {
       db.TypesOfStoring.Add(typeStore);
       await db.SaveChangesAsync();

       return Results.Created($"/typesStoring/{typeStore.Id}", typeStore);
    });

app.MapPut("/typesStoring", async ([FromBody] TypeOfStoring typeStore, TypeOfStoringDb db) =>
    {
        var typeStoreFromDb = await db.TypesOfStoring.FindAsync(new object[] {typeStore.Id});

        if (typeStoreFromDb == null) return Results.NotFound();

        typeStoreFromDb.NameTypeOfStoring = typeStore.NameTypeOfStoring;

        await db.SaveChangesAsync();
        return Results.NoContent();
    });

app.MapDelete("/typesStoring/{id}", async (int id, TypeOfStoringDb db) =>
    {
        var typeStoreFromDb = await db.TypesOfStoring.FindAsync(new object[] {id});

        if (typeStoreFromDb == null) return Results.NotFound();

        db.TypesOfStoring.Remove(typeStoreFromDb);
        await db.SaveChangesAsync();
        return Results.NoContent();
    });

// RECEPTION WAY

app.MapGet("/receptWays", async (ReceptionWaysDb db) => await db.ReceptionWay.ToListAsync());

app.MapGet("/receptWays/{id}", async (int id, ReceptionWaysDb db) =>
    await db.ReceptionWay.FirstOrDefaultAsync(t => t.Id == id) is ReceptionWays receptWay
    ? Results.Ok(receptWay)
    : Results.NotFound());

app.MapPost("/receptWays", async ([FromBody] ReceptionWays receptWay, ReceptionWaysDb db) =>
{
    db.ReceptionWay.Add(receptWay);
    await db.SaveChangesAsync();

    return Results.Created($"/receptWays/{receptWay.Id}", receptWay);
});

app.MapPut("/receptWays", async ([FromBody] ReceptionWays receptWay, ReceptionWaysDb db) =>
{
    var receptWayFromDb = await db.ReceptionWay.FindAsync(new object[] { receptWay.Id });

    if (receptWayFromDb == null) return Results.NotFound();

    receptWayFromDb.NameReceptionWay = receptWay.NameReceptionWay;

    await db.SaveChangesAsync();
    return Results.NoContent();
});

app.MapDelete("/receptWays/{id}", async (int id, ReceptionWaysDb db) =>
{
    var receptWayFromDb = await db.ReceptionWay.FindAsync(new object[] { id });

    if (receptWayFromDb == null) return Results.NotFound();

    db.ReceptionWay.Remove(receptWayFromDb);
    await db.SaveChangesAsync();
    return Results.NoContent();
});

// WORK TECHNIQUES

app.MapGet("/worksTech", async (WorkTechniqueDb db) => await db.WorkTechniques.ToListAsync());

app.MapGet("/worksTech/{id}", async (int id, WorkTechniqueDb db) =>
    await db.WorkTechniques.FirstOrDefaultAsync(t => t.Id == id) is WorkTechnique receptWay
    ? Results.Ok(receptWay)
    : Results.NotFound());

app.MapPost("/worksTech", async ([FromBody] WorkTechnique workTech, WorkTechniqueDb db) =>
{
    db.WorkTechniques.Add(workTech);
    await db.SaveChangesAsync();

    return Results.Created($"/worksTech/{workTech.Id}", workTech);
});

app.MapPut("/worksTech", async ([FromBody] WorkTechnique workTech, WorkTechniqueDb db) =>
{
    var workTechFromDb = await db.WorkTechniques.FindAsync(new object[] { workTech.Id });

    if (workTechFromDb == null) return Results.NotFound();

    workTechFromDb.NameTechnique = workTech.NameTechnique;

    await db.SaveChangesAsync();
    return Results.NoContent();
});

app.MapDelete("/worksTech/{id}", async (int id, WorkTechniqueDb db) =>
{
    var workTechFromDb = await db.WorkTechniques.FindAsync(new object[] { id });

    if (workTechFromDb == null) return Results.NotFound();

    db.WorkTechniques.Remove(workTechFromDb);
    await db.SaveChangesAsync();
    return Results.NoContent();
});

// STORAGES

app.MapGet("/storages", async (StorageDb db) => await db.Storages.ToListAsync());

app.MapGet("/storages/{id}", async (int id, StorageDb db) =>
    await db.Storages.FirstOrDefaultAsync(s => s.Id == id) is StoragePlaces storage
    ? Results.Ok(storage)
    : Results.NotFound());

app.MapPost("/storages", async ([FromBody] StoragePlaces storage, StorageDb db) =>
{
    db.Storages.Add(storage);
    await db.SaveChangesAsync();

    return Results.Created($"/storages/{storage.Id}", storage);
});

app.MapPut("/storages", async ([FromBody] StoragePlaces storage, StorageDb db) =>
{
    var storagesFromDb = await db.Storages.FindAsync(new object[] { storage.Id });

    if (storagesFromDb == null) return Results.NotFound();

    storagesFromDb.AmountOfPlaces = storage.AmountOfPlaces;

    await db.SaveChangesAsync();
    return Results.NoContent();
});

app.MapDelete("/storages/{id}", async (int id, StorageDb db) =>
{
    var storagesFromDb = await db.Storages.FindAsync(new object[] { id });

    if (storagesFromDb == null) return Results.NotFound();

    db.Storages.Remove(storagesFromDb);
    await db.SaveChangesAsync();
    return Results.NoContent();
});

// POSITIONS

app.MapGet("/positions", async (PositionDb db) => await db.Positions.ToListAsync());

app.MapGet("/positions/{id}", async (int id, PositionDb db) =>
    await db.Positions.FirstOrDefaultAsync(t => t.Id == id) is Position receptWay
    ? Results.Ok(receptWay)
    : Results.NotFound());

app.MapPost("/positions", async ([FromBody] Position posit, PositionDb db) =>
{
    db.Positions.Add(posit);
    await db.SaveChangesAsync();

    return Results.Created($"/positions/{posit.Id}", posit);
});

app.MapPut("/positions", async ([FromBody] Position posit, PositionDb db) =>
{
    var positFromDb = await db.Positions.FindAsync(new object[] { posit.Id });

    if (positFromDb == null) return Results.NotFound();

    positFromDb.NamePosition = posit.NamePosition;
    positFromDb.Salary = posit.Salary;

    await db.SaveChangesAsync();
    return Results.NoContent();
});

app.MapDelete("/positions/{id}", async (int id, PositionDb db) =>
{
    var positFromDb = await db.Positions.FindAsync(new object[] { id });

    if (positFromDb == null) return Results.NotFound();

    db.Positions.Remove(positFromDb);
    await db.SaveChangesAsync();
    return Results.NoContent();
});

app.UseAuthorization();

app.MapControllers();

app.Run();