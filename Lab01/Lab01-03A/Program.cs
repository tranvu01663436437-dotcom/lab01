using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Lab01_03A
{

    internal class Program
    {
        static void Main(string[] args)
        {
            // Thiết lập UTF-8 để hiển thị tiếng Việt có dấu
            Console.OutputEncoding = System.Text.Encoding.UTF8;
            Console.InputEncoding = System.Text.Encoding.UTF8;

            List<Student> studentList = new List<Student>();
            List<Teacher> teacherList = new List<Teacher>();
            bool exit = false;

            while (!exit)
            {
                Console.WriteLine("\n=== MENU QUẢN LÝ NHÂN SỰ VÀ SINH VIÊN ===");
                Console.WriteLine("1. Thêm sinh viên");
                Console.WriteLine("2. Thêm giáo viên");
                Console.WriteLine("3. Xuất danh sách sinh viên");
                Console.WriteLine("4. Xuất danh sách giáo viên");
                Console.WriteLine("5. Số lượng từng danh sách");
                Console.WriteLine("6. SV khoa 'CNTT'");
                Console.WriteLine("7. GV có địa chỉ chứa 'Quận 9'");
                Console.WriteLine("8. SV DTB cao nhất khoa 'CNTT'");
                Console.WriteLine("9. Thống kê xếp loại sinh viên");
                Console.WriteLine("0. Thoát");
                Console.Write("Chọn chức năng (0-9): ");

                string choice = Console.ReadLine();

                switch (choice)
                {
                    case "1": AddStudent(studentList); break;
                    case "2": AddTeacher(teacherList); break;
                    case "3": DisplayStudentList(studentList); break;
                    case "4": DisplayTeacherList(teacherList); break;
                    case "5": DisplayListCounts(studentList, teacherList); break;
                    case "6": DisplayStudentsByFaculty(studentList, "CNTT"); break;
                    case "7": DisplayTeachersByAddress(teacherList, "Quận 9"); break;
                    case "8": DisplayHighestScoreStudentByFaculty(studentList, "CNTT"); break;
                    case "9": DisplayStudentRankingStatistics(studentList); break;
                    case "0": exit = true; Console.WriteLine("Kết thúc chương trình."); break;
                    default: Console.WriteLine("Lựa chọn không hợp lệ!"); break;
                }
                Console.WriteLine();
            }
        }
        // --- HÀM THÊM MỚI ---
        static void AddStudent(List<Student> studentList)
        {
            Student student = new Student();
            student.Input();
            studentList.Add(student);
            Console.WriteLine("Thêm sinh viên thành công!");
        }

        // Hàm thêm Giáo viên
        static void AddTeacher(List<Teacher> teacherList)
        {
            Teacher teacher = new Teacher();
            teacher.Input();
            teacherList.Add(teacher);
            Console.WriteLine("Thêm giáo viên thành công!");
        }

        // Hàm hiển thị danh sách Sinh viên
        static void DisplayStudentList(List<Student> studentList)
        {
            if (!studentList.Any()) { Console.WriteLine("Danh sách sinh viên rỗng."); return; }
            Console.WriteLine("\n=== DANH SÁCH SINH VIÊN ===");
            foreach (var s in studentList) { s.Output(); }
        }

        // Hàm hiển thị danh sách Giáo viên
        static void DisplayTeacherList(List<Teacher> teacherList)
        {
            if (!teacherList.Any()) { Console.WriteLine("Danh sách giáo viên rỗng."); return; }
            Console.WriteLine("\n=== DANH SÁCH GIÁO VIÊN ===");
            foreach (var t in teacherList) { t.Output(); }
        }

        // Chức năng 5
        static void DisplayListCounts(List<Student> studentList, List<Teacher> teacherList)
        {
            Console.WriteLine("=== SỐ LƯỢNG DANH SÁCH ===");
            Console.WriteLine($"Tổng số Sinh viên: {studentList.Count}");
            Console.WriteLine($"Tổng số Giáo viên: {teacherList.Count}");
        }

        // Chức năng 6
        static void DisplayStudentsByFaculty(List<Student> studentList, string faculty)
        {
            Console.WriteLine($"\n=== DANH SÁCH SV KHOA '{faculty}' ===");
            var result = studentList
                .Where(s => s.Faculty.Equals(faculty, StringComparison.OrdinalIgnoreCase))
                .ToList();
            DisplayStudentList(result);
        }

        // Chức năng 7
        static void DisplayTeachersByAddress(List<Teacher> teacherList, string keyword)
        {
            Console.WriteLine($"\n=== DANH SÁCH GV ĐỊA CHỈ CHỨA '{keyword}' ===");
            var result = teacherList
                .Where(t => t.Address.IndexOf(keyword, StringComparison.OrdinalIgnoreCase) >= 0)
                .ToList();
            DisplayTeacherList(result);
        }

        // Chức năng 8
        static void DisplayHighestScoreStudentByFaculty(List<Student> studentList, string faculty)
        {
            Console.WriteLine($"\n=== SV DTB CAO NHẤT KHOA '{faculty}' ===");
            var studentsInFaculty = studentList
                .Where(s => s.Faculty.Equals(faculty, StringComparison.OrdinalIgnoreCase));

            if (!studentsInFaculty.Any()) { Console.WriteLine($"Không có sinh viên khoa {faculty}"); return; }

            float maxScore = studentsInFaculty.Max(s => s.AverageScore);

            var result = studentsInFaculty
                .Where(s => s.AverageScore == maxScore)
                .ToList();
            DisplayStudentList(result);
        }

        // Chức năng 9
        static void DisplayStudentRankingStatistics(List<Student> studentList)
        {
            if (!studentList.Any()) { Console.WriteLine("Danh sách sinh viên rỗng, không thể thống kê!"); return; }

            Console.WriteLine("\n=== THỐNG KÊ XẾP LOẠI SINH VIÊN ===");

            var rankingStatistics = studentList
                .GroupBy(s => s.GetRanking())
                .OrderByDescending(g => g.Count());

            var allRankings = new List<string> { "Xuất sắc", "Giỏi", "Khá", "Trung bình", "Yếu", "Kém" };

            foreach (var rank in allRankings)
            {
                int count = rankingStatistics.FirstOrDefault(g => g.Key == rank)?.Count() ?? 0;
                Console.WriteLine($"- {rank,-12}: {count,3} sinh viên");
            }
        }
    }
}
