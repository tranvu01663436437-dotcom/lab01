using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Lab01_03A
{
    public class Teacher : Person
    {
        private string address;

        public string Address { get => address; set => address = value; }

        public Teacher() : base() { }

        // (1) Constructor có gọi base
        public Teacher(string id, string fullname, string address)
            : base(id, fullname)
        {
            this.Address = address;
        }

        // (2) Ghi đè phương thức Input
        public override void Input()
        {
            Console.WriteLine("--- Nhập thông tin Giáo viên ---");
            base.Input(); // Gọi Input của Person (nhập Id, Fullname)

            Console.Write("Nhập địa chỉ: ");
            Address = Console.ReadLine();
        }

        // (3) Ghi đè phương thức Output
        public override void Output()
        {
            base.Output(); // Gọi Output của Person (xuất ID, Name)

            // Sử dụng String Interpolation
            Console.WriteLine($" - Địa chỉ:{this.Address}");
        }
    }
}
