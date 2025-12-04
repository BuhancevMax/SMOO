namespace TASK_STUDENTS;

public class CourseManager
{
    public Course[] Courses { get; set; } = new Course[0];
    public void RemoveCourse(Course course)
    {
        int index = -1;
        for (int i = 0; i < Courses.Length; i++) // поиск курса
        {
            if (Courses[i].Equals(course))
            {
                index = i;
                break;
            }
        }
        if (index == -1)
        {
            Console.WriteLine("Курс не найден!");
            return;
        }

        Course[] temp = new Course[Courses.Length - 1]; // изменение массива
        for (int i = 0, j = 0; i < Courses.Length; i++)
        {
            if (i != index)
            {
                temp[j++] = course;
            }
        }

        Courses = temp;
        Console.WriteLine("Курс удалён!");
    }
    public void AddCourse(Course course)
    {
        Course[] temp = new Course[Courses.Length + 1];
        for (int i = 0; i < Courses.Length; i++)
        {
            temp[i] = Courses[i]; 
        }
        temp[Courses.Length] = course;
        Courses = temp;
    }
    public void ShowCourses()
    {
        if (Courses.Length == 0)
        {
            Console.WriteLine("Курса нет в списке!");
            return;
        }
        foreach (var course in Courses)
        {
            Console.WriteLine(course);
        }
    }
}