using SistemaGerenciamentoNotas;

List<Student> studentsList = new List<Student>();

Console.WriteLine("--- STUDENT MANAGEMENT ---");
Console.Write("Select what you would like to do: \n" +
    "1 . Add a student\n" +
    "2 . Show all student and yours grades\n" +
    "3 . Calculate grade average of all students\n" +
    "4 . Search for a student's specific grade\n" +
    "5 . Exit\n");

bool userSelectValid = false;

int userOption = userSelect();

while (userOption != 5)
{
    switch (userOption)
    {
        case 1:
            addStudent();
            userOption = userSelect();
            break;
        case 2:
            showAllStudents();
            userOption = userSelect();
            break;
        case 3:
            calculateAverage();
            userOption = userSelect();
            break;
        case 4:
            searchStudent();
            userOption = userSelect();
            break;
    }
}

int userSelect()
{
    int userOption = 0;
    userSelectValid = false;
    while (userSelectValid != true)
    {
        try
        {
            Console.Write("\nSelect a option: ");
            userOption = Convert.ToInt16(Console.ReadLine());
            if (userOption < 1 || userOption > 5)
            {
                Console.WriteLine("Invalid option");
            }
            else
            {
                userSelectValid = true;
            }
        }
        catch
        {
            Console.WriteLine("Invalid option");
        }
    }
    return userOption;
}

void addStudent()
{
    Console.Write("Enter the student's name: ");
    string studentName = Console.ReadLine()!;
    foreach (Student students in studentsList)
    {
        if (studentName == students.getName())
        {
            Console.WriteLine("This student already exists");
            return;
        }
    }
    Console.Write("Enter the student's grade: ");
    double studentGrade = Convert.ToDouble(Console.ReadLine());
    Student student = new Student(studentName, studentGrade);
    studentsList.Add(student);
}

void showAllStudents()
{
    if (studentsList.Count == 0) {
        Console.WriteLine("There are no students");
        return;
    }

    foreach (Student student in studentsList)
    {
        Console.WriteLine(student.ToString());
    }
}

void calculateAverage()
{
    double average = 0;
    foreach (Student student in studentsList)
    {
        average += student.getGrade();
    }
    average /= studentsList.Count;
    Console.WriteLine("The student's grade average is " + average);
}

void searchStudent()
{
    Console.Write("Enter the student's name: ");
    string studentName = Console.ReadLine()!;
    foreach (Student student in studentsList)
    {
        if (student.getName() == studentName)
        {
            Console.WriteLine(student);
            return;
        }
    }
    Console.WriteLine("Student not found");
}