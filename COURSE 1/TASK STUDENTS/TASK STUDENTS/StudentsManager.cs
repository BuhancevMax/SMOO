namespace TASK_STUDENTS;

public class StudentsManager
{
    private Student[] Students { get; set; } = new Student[0];
    
    public void RemoveStudent(Student student)
    {
        int index = -1;
        for (int i = 0; i < Students.Length; i++) // поиск студента
        {
            if (Students[i].Equals(student))
            {
                index = i;
                break;
            }
        }
        if (index == -1)
        {
            Console.WriteLine("Студент не найден!");
            return;
        }

        Student[] temp = new Student[Students.Length - 1]; // изменение массива
        for (int i = 0, j = 0; i < Students.Length; i++)
        {
            if (i != index)
            {
                temp[j++] = student;
            }
        }

        Students = temp;
        Console.WriteLine("Студент удалён!");
    }
    public void AddStudent(Student student)
    {
        Student[] temp = new Student[Students.Length + 1];
        for (int i = 0; i < Students.Length; i++)
        {
            temp[i] = Students[i]; 
        }
        temp[Students.Length] = student;
        Students = temp;
    }
    public void ShowStudents()
    {
        if (Students.Length == 0)
        {
            Console.WriteLine("Студентов нет в списке!");
            return;
        }
        foreach (var student in Students)
        {
            Console.WriteLine(student);
        }
    }
    
}