using MyDoctorAppointment.Domain.Enums;
using System.Numerics;
using System.Xml.Linq;

namespace MyDoctorAppointment.Domain.Entities
{
    public class Doctor : UserBase
    {
        public DoctorTypes DoctorType { get; set; }

        public byte Experience { get; set; }

        public decimal Salary { get; set; }


        public Doctor(string Name, string Surname, string Phone, string Email, DoctorTypes DoctorType, byte Experience, decimal Salary )
        {
            base.Name = Name;
            base.Surname = Surname;
            base.Phone = Phone;
            base.Email = Email;
            this.DoctorType = DoctorType;
            this.Experience = Experience;
            this.Salary = Salary;
        }

    }
}
