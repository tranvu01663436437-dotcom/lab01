using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Lab01_03
{
    internal class Program
    {
        
        static void Main(string[] args)
        {
            List<Student> studentList = new List<Student>();
            bool exit = false;

            while (!exit)
            {
                Console.WriteLine("=== MENU ===");
                Console.WriteLine("1. Them sinh vien");
                Console.WriteLine("2. Hien thi danh sach sinh vien");
                Console.WriteLine("3. Sinh vien khoa CNTT");
                Console.WriteLine("4. Sinh vien co DTB >= 5");
                Console.WriteLine("5. Danh sach sap xep theo DTB tang dan");
                Console.WriteLine("6. SV khoa CNTT va DTB >= 5");
                Console.WriteLine("7. SV co DTB cao nhat khoa CNTT");
                Console.WriteLine("8. Thong ke xep loai");
                Console.WriteLine("9. Hien thi danh sach sinh vien theo dang bang"); // Chức năng mới 1
                Console.WriteLine("10. Tim sinh vien theo ten khoa (nhap tu ban phim)"); // Chức năng mới 2
                Console.WriteLine("0. Thoat");
                Console.Write("Chon chuc nang (0-10): ");

                string choice = Console.ReadLine();

                switch (choice)
                {
                    case "1":
                        AddStudent(studentList);
                        break;

                    case "2":
                        DisplayStudentList(studentList);
                        break;

                    case "3":
                        DisplayStudentsByFaculty(studentList, "CNTT");
                        break;

                    case "4":
                        DisplayStudentsWithHighAverageScore(studentList, 5);
                        break;

                    case "5":
                        SortStudentsByAverageScore(studentList);
                        break;

                    case "6":
                        DisplayStudentsByFacultyAndScore(studentList, "CNTT", 5);
                        break;

                    case "7":
                        DisplayStudentsWithHighestAverageScoreByFaculty(studentList, "CNTT");
                        break;

                    case "8":
                        DisplayStudentRankingStatistics(studentList);
                        break;

                    // Chức năng mới 1
                    case "9":
                        DisplayStudentListInTable(studentList);
                        break;

                    // Chức năng mới 2
                    case "10":
                        DisplayStudentsByFacultyInput(studentList);
                        break;

                    case "0":
                        exit = true;
                        Console.WriteLine("Ket thuc chuong trinh.");
                        break;

                    default:
                        Console.WriteLine("Lua chon khong hop le!");
                        break;
                }

                Console.WriteLine();
            }
        }
        static void AddStudent(List<Student> studentList)
        {
            Console.WriteLine("=== Nhap thong tin sinh vien ===");
            Student student = new Student();
            student.Input();
            studentList.Add(student);
            Console.WriteLine("Them sinh vien thanh cong!");
        }

        // Phương thức hiển thị danh sách sinh viên (dạng cũ)
        static void DisplayStudentList(List<Student> studentList)
        {
            if (studentList.Count == 0)
            {
                Console.WriteLine("Danh sach rong!");
                return;
            }

            Console.WriteLine("=== Danh sach sinh vien ===");
            foreach (Student student in studentList)
            {
                student.Show();
            }
        }

        // Phương thức hiển thị danh sách sinh viên theo Khoa
        static void DisplayStudentsByFaculty(List<Student> studentList, string faculty)
        {
            Console.WriteLine("=== Danh sach sinh vien thuoc khoa {0} ===", faculty);

            var result = studentList
                .Where(s => s.Faculty.Equals(faculty, StringComparison.OrdinalIgnoreCase))
                .ToList();

            DisplayStudentListInTable(result); // Dùng hàm hiển thị dạng bảng mới
        }

        // Phương thức hiển thị sinh viên có DTB cao
        static void DisplayStudentsWithHighAverageScore(List<Student> studentList, float minDTB)
        {
            Console.WriteLine("=== SV co DTB >= {0} ===", minDTB);

            var result = studentList
                .Where(s => s.AverageScore >= minDTB)
                .ToList();

            DisplayStudentListInTable(result); // Dùng hàm hiển thị dạng bảng mới
        }

        // Phương thức sắp xếp sinh viên theo DTB tăng dần
        static void SortStudentsByAverageScore(List<Student> studentList)
        {
            Console.WriteLine("=== Danh sach sap xep theo DTB tang dan ===");

            var result = studentList
                .OrderBy(s => s.AverageScore)
                .ToList();

            DisplayStudentListInTable(result); // Dùng hàm hiển thị dạng bảng mới
        }

        // Phương thức hiển thị sinh viên theo Khoa và điểm
        static void DisplayStudentsByFacultyAndScore(List<Student> studentList, string faculty, float minDTB)
        {
            Console.WriteLine("=== SV khoa {0} co DTB >= {1} ===", faculty, minDTB);

            var result = studentList
                .Where(s => s.AverageScore >= minDTB &&
                            s.Faculty.Equals(faculty, StringComparison.OrdinalIgnoreCase))
                .ToList();

            DisplayStudentListInTable(result); // Dùng hàm hiển thị dạng bảng mới
        }

        // Phương thức hiển thị sinh viên có DTB cao nhất theo Khoa
        static void DisplayStudentsWithHighestAverageScoreByFaculty(List<Student> studentList, string faculty)
        {
            Console.WriteLine("=== SV co DTB cao nhat thuoc khoa {0} ===", faculty);

            var students = studentList
                .Where(s => s.Faculty.Equals(faculty, StringComparison.OrdinalIgnoreCase));

            if (!students.Any())
            {
                Console.WriteLine("Khong co sinh vien khoa {0}", faculty);
                return;
            }

            float maxScore = students.Max(s => s.AverageScore);

            var result = students
                .Where(s => s.AverageScore == maxScore)
                .ToList();

            DisplayStudentListInTable(result); // Dùng hàm hiển thị dạng bảng mới
        }

        // Phương thức thống kê xếp loại sinh viên
        static void DisplayStudentRankingStatistics(List<Student> studentList)
        {
            Console.WriteLine("=== Thong ke xep loai sinh vien ===");

            var ranking = new Dictionary<string, int>()
            {
                { "Xuat sac", 0 }, // 9.0 - 10.0
                { "Gioi", 0 },     // 8.0 - 8.9
                { "Kha", 0 },      // 7.0 - 7.9
                { "Trung binh", 0 }, // 5.0 - 6.9
                { "Yeu", 0 },      // 4.0 - 4.9
                { "Kem", 0 }       // < 4.0
            };

            foreach (var s in studentList)
            {
                if (s.AverageScore >= 9 && s.AverageScore <= 10)
                    ranking["Xuat sac"]++;
                else if (s.AverageScore >= 8 && s.AverageScore < 9)
                    ranking["Gioi"]++;
                else if (s.AverageScore >= 7 && s.AverageScore < 8)
                    ranking["Kha"]++;
                else if (s.AverageScore >= 5 && s.AverageScore < 7)
                    ranking["Trung binh"]++;
                else if (s.AverageScore >= 4 && s.AverageScore < 5)
                    ranking["Yeu"]++;
                else
                    ranking["Kem"]++;
            }

            foreach (var item in ranking)
            {
                Console.WriteLine("{0}: {1} sinh vien", item.Key, item.Value);
            }
        }


        static void DisplayStudentListInTable(List<Student> studentList)
        {
            if (studentList.Count == 0)
            {
                Console.WriteLine("Danh sach rong!");
                return;
            }

            Console.WriteLine("=== Danh sach sinh vien (Dang bang) ===");

            // Định nghĩa độ rộng cột (đã giữ lại, nhưng được sử dụng trong string.Format)
            int idWidth = 10;
            int nameWidth = 25;
            int facultyWidth = 15;
            int scoreWidth = 10;

            // Chuỗi định dạng dùng chung (sử dụng chỉ mục 0, 1, 2, 3)
            string formatString = $"|{{0,-{idWidth}}}|{{1,-{nameWidth}}}|{{2,-{facultyWidth}}}|{{3,-{scoreWidth}}}|";

            // Dòng tiêu đề
            string header = string.Format(formatString, "MSSV", "HO TEN", "KHOA", "DIEM TB");
            string separator = new string('-', header.Length);

            Console.WriteLine(separator);
            Console.WriteLine(header);
            Console.WriteLine(separator);

            // Nội dung bảng
            foreach (Student student in studentList)
            {
                // Định dạng DTB với 2 chữ số thập phân
                string scoreFormatted = student.AverageScore.ToString("F2");

                string row = string.Format(formatString,
                    student.StudentID,
                    student.FullName,
                    student.Faculty,
                    scoreFormatted);

                Console.WriteLine(row);
            }

            Console.WriteLine(separator);
        }

        /// <summary>
        /// Chức năng 2: Lấy danh sách sinh viên theo tên Khoa nhập từ bàn phím
        /// </summary>
        static void DisplayStudentsByFacultyInput(List<Student> studentList)
        {
            Console.Write("Nhap ten Khoa can tim: ");
            string faculty = Console.ReadLine();

            if (string.IsNullOrWhiteSpace(faculty))
            {
                Console.WriteLine("Ten khoa khong duoc de trong!");
                return;
            }

            DisplayStudentsByFaculty(studentList, faculty);
        }
    }
}
