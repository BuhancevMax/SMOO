
namespace TASK_STUDENTS;

internal class Program
{
    static void Main(string[] args)
    {
        CourseManager courseManager = new CourseManager();
        courseManager.AddCourse(new Course( "АТП", "Виктория Бельская"));
        courseManager.AddCourse(new Course("Вышмат", "Ирина Григорьевна"));
        courseManager.AddCourse(new Course("АСД", "Валерий Николаевич"));

        StudentsManager studentsManager = new StudentsManager();
        studentsManager.AddStudent(Student.CreateStudentInput(courseManager));
        studentsManager.ShowStudents();

    }
}