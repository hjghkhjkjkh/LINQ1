using System;
using System.Collections.Generic;
using System.Linq;

class Program
{
    static void Main(string[] args)
    {
        // Tạo các đối tượng Department
        var departments = new List<Department>
        {
            new Department { Id = 1, Name = "HR", Description = "Human Resources Department" },
            new Department { Id = 2, Name = "IT", Description = "Information Technology Department" }
        };

        // Tạo các đối tượng Position
        var positions = new List<Position>
        {
            new Position { Id = 1, Name = "Manager", Description = "Managerial Position" },
            new Position { Id = 2, Name = "Developer", Description = "Software Developer Position" }
        };

        // Tạo các đối tượng Employee
        var employees = new List<Employee>
        {
            new Employee { Id = 1, Name = "John", Age = 30, PositionId = 1, DepartmentId = 1 },
            new Employee { Id = 2, Name = "Alice", Age = 25, PositionId = 2, DepartmentId = 2 }
        };

        Console.Write("Enter search keywords: ");
        string keyword = Console.ReadLine();

        Console.Write("Enter minimum age (press Enter to skip): ");
        string minAgeInput = Console.ReadLine();
        int? minAge = string.IsNullOrWhiteSpace(minAgeInput) ? null : (int?)int.Parse(minAgeInput);

        Console.Write("Enter maximum age (press Enter to skip): ");
        string maxAgeInput = Console.ReadLine();
        int? maxAge = string.IsNullOrWhiteSpace(maxAgeInput) ? null : (int?)int.Parse(maxAgeInput);

        Console.Write("Enter position (press Enter to skip): ");
        string positionKeyword = Console.ReadLine();

        Console.Write("Enter department (press Enter to skip): ");
        string departmentKeyword = Console.ReadLine();

        var result = employees
            .Where(e => string.IsNullOrWhiteSpace(keyword) || e.Name.Contains(keyword))
            .Where(e => !minAge.HasValue || e.Age >= minAge)
            .Where(e => !maxAge.HasValue || e.Age <= maxAge)
            .Where(e => string.IsNullOrWhiteSpace(positionKeyword) || positions.Any(p => p.Id == e.PositionId && p.Name.Contains(positionKeyword)))
            .Where(e => string.IsNullOrWhiteSpace(departmentKeyword) || departments.Any(d => d.Id == e.DepartmentId && d.Name.Contains(departmentKeyword)))
            .ToList();

        Console.WriteLine("Search results: ");
        foreach (var employee in result)
        {
            Console.WriteLine($"Name: {employee.Name}, Age: {employee.Age}");
        }
    }
}

class Department
{
    public int Id { get; set; }
    public string Name { get; set; }
    public string Description { get; set; }
}

class Position
{
    public int Id { get; set; }
    public string Name { get; set; }
    public string Description { get; set; }
}

class Employee
{
    public int Id { get; set; }
    public string Name { get; set; }
    public int Age { get; set; }
    public int PositionId { get; set; }
    public int DepartmentId { get; set; }
}
