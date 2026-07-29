using System.Collections.Generic;

class Student
{
    public int RollNumber;
    public string Name;
    public Dictionary<string, int> Marks = new Dictionary<string, int>();

    public Student(int rollNumber, string name)
    {
        RollNumber = rollNumber;
        Name = name;
    }

    public void AddMark(string subject, int mark)
    {
        Marks[subject] = mark;
    }

    public int GetTotal()
    {
        int total = 0;
        foreach (var mark in Marks.Values)
        {
            total += mark;
        }
        return total;
    }

    public double GetPercentage()
    {
        return (double)GetTotal() / Marks.Count;
    }

    public string GetGrade()
    {
        double percentage = GetPercentage();
        if (percentage >= 90) return "A+";
        else if (percentage >= 75) return "A";
        else if (percentage >= 60) return "B";
        else if (percentage >= 40) return "C";
        else return "Fail";
    }

    public void ShowResult()
    {
        Console.WriteLine($"\nRoll No: {RollNumber}, Name: {Name}");
        foreach (var subject in Marks)
        {
            Console.WriteLine($"  {subject.Key}: {subject.Value}");
        }
        Console.WriteLine($"Total: {GetTotal()}, Percentage: {GetPercentage():F2}%, Grade: {GetGrade()}");
    }
}

class Program
{
    static void Main()
    {
        Student s1 = new Student(101, "Sushma");
        s1.AddMark("Math", 95);
        s1.AddMark("Science", 88);
        s1.AddMark("English", 79);

        Student s2 = new Student(102, "Amit");
        s2.AddMark("Math", 55);
        s2.AddMark("Science", 40);
        s2.AddMark("English", 35);

        s1.ShowResult();
        s2.ShowResult();
    }
}