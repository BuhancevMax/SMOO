namespace TASK_STUDENTS;

public class Course
{
    
    public string NameOfCourse { get; set; }
    public string NameOfTeacher { get; set; }
    
    public Course(string nameOfCourse, string nameOfTeacher)
    {
        NameOfCourse = nameOfCourse;
        NameOfTeacher = nameOfTeacher;
    }
    
    public override string ToString()
    {
        return $"{NameOfCourse} - {NameOfTeacher}";
    }
    public override bool Equals(object obj)
    {
        if (obj is Course other)
        {
            return NameOfCourse == other.NameOfCourse &&
                   NameOfTeacher == other.NameOfTeacher;
        }
        return false;
    }

    public override int GetHashCode()
    {
        return HashCode.Combine(NameOfCourse, NameOfTeacher);
    }
}