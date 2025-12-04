using TASK_STUDENTS.Enums;

namespace TASK_STUDENTS;

public class Student
{
    public string Name { get; set; }
    public string Surname { get; set; }
    public Course[] Courses { get; set; }
    public Specialities Speciality { get; set; }
    
    public Student(string name, string surname, Course[] courses, Specialities speciality)
    {
        Name = name;
        Surname = surname;
        Courses = courses;
        Speciality = speciality;
    }
    
    public static Student CreateStudentInput(CourseManager catalog)
    {
        Console.Write("Введите имя студента: ");
        string? name = Console.ReadLine();

        Console.Write("Введите фамилию студента: ");
        string? surname = Console.ReadLine();

        Console.WriteLine("Выберите курсы (введите номера через запятую):");
        for (int i = 0; i < catalog.Courses.Length; i++)
            Console.WriteLine($"{i + 1}. {catalog.Courses[i]}");

        Console.Write("Ваш выбор: "); // выбор курсов
        string? input = Console.ReadLine();
        string[] parts = input.Split(',');
        
        int сount = 0;
        for (int i = 0; i < parts.Length; i++) 
        {
            if (int.TryParse(parts[i].Trim(), out int index) && index >= 1 && index <= catalog.Courses.Length)
            {
                сount++; // подсчёт сколько индексов ввёл пользователь
            }
        }
        
        Course[] selectedCourses = new Course[сount];
        int j = 0;
        for (int i = 0; i < parts.Length; i++)
        {
            if (int.TryParse(parts[i].Trim(), out int index) && index >= 1 && index <= catalog.Courses.Length)
            {
                selectedCourses[j] = catalog.Courses[index - 1];
                j++;
            }
        }

        Console.WriteLine("Выберите специальность:");
        foreach (int i in Enum.GetValues(typeof(Specialities)))
            Console.WriteLine($"{i} - {Enum.GetName(typeof(Specialities), i)}");

        int specialtyNum;
        while (!int.TryParse(Console.ReadLine(), out specialtyNum) || !Enum.IsDefined(typeof(Specialities), specialtyNum))
            Console.Write("Ошибка. Попробуйте еще раз: ");

        return new Student(name, surname, selectedCourses.ToArray(), (Specialities)specialtyNum);
    }
    
    public override string ToString()
    {
        string coursesInfo = "";
        foreach (var course in Courses)
        {
            coursesInfo += $"{course}\n";
        }
        return $"Студент: {Name} {Surname}\nКурсы: {coursesInfo}\nСпециализация: {Speciality}\n";
    }
    public override bool Equals(object obj)
    {
        if (obj is Student student)
        {
            return Name == student.Name && Surname == student.Surname;
        }
        return false;
    }

    public override int GetHashCode()
    {
        return HashCode.Combine(Name, Surname, Courses, Speciality);
    }
    public static bool CanBeGrouped(Student a, Student b) // можно ли в группу (нельзя с одной и той же специализацией)
    {
        if (a.Speciality == b.Speciality)
            return false;

        int commonCount = 0;
        foreach (var courseA in a.Courses)
        {
            foreach (var courseB in b.Courses)
            {
                if (courseA.Equals(courseB))
                {
                    commonCount++;
                    break;
                }
            }
        }

        return commonCount >= 3;
    }
}