using EF_Test;
using EF_Test.Models;
using System;

Console.WriteLine("Hello, World!");

using var db = new AppDbContext();

var department = new Department()
{
    Id = 1, 
    Name = "Computer Science",
    des = "CS"
};

db.Departments.Add(department);
db.SaveChanges();

Console.WriteLine("Department added successfully!");


var uniform = new Uniform()
{
    Name = "uniform 1",
    Created = DateTime.Now,
};

db.Uniforms.Add(uniform);
db.SaveChanges();

Console.WriteLine("Uniform added successfully!");