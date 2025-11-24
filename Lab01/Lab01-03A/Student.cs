using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Lab01_03A
{
    public class Student : Person
    {
        private float averageScore;
        private string faculty;

        public float AverageScore { get => averageScore; set => averageScore = value; }
        public string Faculty { get => faculty; set => faculty = value; }

        public Student() : base() { }

        // (1) Constructor có gọi base
        public Student(string id, string fullname, float averageScore, string faculty)
            : base(id, fullname)
        {
            this.AverageScore = averageScore;
            this.Faculty = faculty;
        }

        // (2) Ghi đè phương thức Input
        public override void Input()
        {
            Console.WriteLine("--- Nhập thông tin Sinh viên ---");
            base.Input(); // Gọi Input của Person (nhập Id, Fullname)

            Console.Write("Nhập Khoa: ");
            Faculty = Console.ReadLine();

            // Thêm kiểm tra TryParse cho điểm TB
            float score;
            Console.Write("Nhập Điểm trung bình: ");
            while (!float.TryParse(Console.ReadLine(), out score) || score < 0 || score > 10)
            {
                Console.WriteLine("Điểm không hợp lệ (0-10). Vui lòng nhập lại.");
                Console.Write("Nhập Điểm trung bình: ");
            }
            AverageScore = score;
        }

        // (3) Ghi đè phương thức Output
        public override void Output()
        {
            base.Output(); // Gọi Output của Person (xuất ID, Name)

            // Sử dụng String Interpolation
            Console.WriteLine($" - Điểm TB:{this.AverageScore} - Khoa:{this.Faculty}");
        }

        // Thêm phương thức xếp loại cho các chức năng sau
        public string GetRanking()
        {
            if (AverageScore >= 9) return "Xuất sắc";
            if (AverageScore >= 8) return "Giỏi";
            if (AverageScore >= 7) return "Khá";
            if (AverageScore >= 5) return "Trung bình";
            if (AverageScore >= 4) return "Yếu";
            return "Kém";
        }
    }
}
