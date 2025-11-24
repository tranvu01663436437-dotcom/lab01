using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Lab01_03
{
    internal class Student
    {
        
            private string studentID;
            private string fullName;
            private float averageScore;
            private string faculty;

            public string StudentID { get => studentID; set => studentID = value; }
            public string FullName { get => fullName; set => fullName = value; }
            public float AverageScore
            {
                get => averageScore;
                set => averageScore = value;
            }
            public string Faculty { get => faculty; set => faculty = value; }

            public Student() { }

            public Student(string studentID, string fullName, float averageScore, string faculty)
            {
                this.studentID = studentID;
                this.fullName = fullName;
                this.averageScore = averageScore;
                this.faculty = faculty;
            }

            public void Input()
            {
                Console.Write("Nhap MSSV: ");
                StudentID = Console.ReadLine();

                Console.Write("Nhap ho ten sinh vien: ");
                FullName = Console.ReadLine();

                float score;
                while (true)
                {
                    Console.Write("Nhap diem TB: ");
                    if (float.TryParse(Console.ReadLine(), out score) && score >= 0 && score <= 10)
                    {
                        AverageScore = score;
                        break;
                    }
                    else
                    {
                        Console.WriteLine("Diem khong hop le. Vui long nhap lai (0-10).");
                    }
                }

                Console.Write("Nhap Khoa: ");
                Faculty = Console.ReadLine();
            }

            public void Show()
            {
                Console.WriteLine("MSSV:{0}  Ho Ten:{1}  Khoa:{2}  DiemTB:{3}",
                    this.StudentID, this.FullName, this.Faculty, this.AverageScore);
            }
        
    }
}
