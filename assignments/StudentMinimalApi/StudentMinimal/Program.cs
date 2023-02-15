using System.ComponentModel.DataAnnotations;
using Microsoft.AspNetCore.Http.HttpResults;
using Microsoft.AspNetCore.Mvc.ModelBinding;
using Microsoft.EntityFrameworkCore;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

builder.Services.AddDbContext<StudentContext>(options => options.UseInMemoryDatabase("Students"));
var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseHttpsRedirection();
app.MapGet("/all", (StudentContext s) => s.Students.ToList());
app.MapGet("/studentById", (StudentContext s,int rollNo) => s.Students.Where(x=>x.RollNo==rollNo));
app.MapPost("/insert",(StudentContext s, Student stu) =>
{
    s.Add(stu);
    s.SaveChanges();
    return Results.Ok(stu);
});
app.MapPut("update", (StudentContext s, Student stu, int rollno) =>
{
    var studenttoUpdate = s.Students.Where(x => x.RollNo == rollno).FirstOrDefault();
    studenttoUpdate.Name=stu.Name;
    studenttoUpdate.Grade=stu.Grade;
    s.SaveChanges();
    return Results.Ok(studenttoUpdate);

});
app.MapDelete("delete", (StudentContext s, int rollno) =>
{
    var studenttoDelete = s.Students.Where(x => x.RollNo == rollno).FirstOrDefault();
    s.Remove(studenttoDelete);
    s.SaveChanges();
    return Results.Ok(studenttoDelete);
});

app.Run();

class Student
{
    [Key]
    public int RollNo { get; set; }
    public string Name { get; set; }
    public string Grade { get; set; }
}

class StudentContext : DbContext
{
    public StudentContext(DbContextOptions options):base(options)
    {

    }
    public DbSet<Student> Students { get;set; }

}
