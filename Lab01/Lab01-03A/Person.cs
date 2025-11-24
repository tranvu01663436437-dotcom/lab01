using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Lab01_03A
{
    public class Person
    {
            
    private string id;
        private string fullname;

        // Properties
        public string Id { get => id; set => id = value; }
        public string Fullname { get => fullname; set => fullname = value; }

        // Constructor mặc định
        public Person() { }

        // Constructor đầy đủ tham số
        public Person(string id, string fullname)
        {
            this.Id = id;
            this.Fullname = fullname;
        }

        // Phương thức nhập liệu chung
        public virtual void Input() // (1)
        {
            Console.Write("Nhập mã: ");
            Id = Console.ReadLine();
            Console.Write("Nhập họ và tên: ");
            Fullname = Console.ReadLine();
        }

        // Phương thức xuất thông tin chung (Dùng String Interpolation)
        public virtual void Output() // (2)
        {
            // Sử dụng String Interpolation để tránh lỗi dấu
            Console.Write($"ID:{this.Id} - Name:{this.Fullname}");
        }

    }
}
