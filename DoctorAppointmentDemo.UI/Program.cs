using MyDoctorAppointment.Domain.Entities;
using MyDoctorAppointment.Service.Interfaces;
using MyDoctorAppointment.Service.Services;
using System.Drawing;

namespace MyDoctorAppointment
{
   

    public static class Program
    {
        public static void Main()
        {
            //var doctorAppointment = new DoctorAppointment();
            //doctorAppointment.Menu();
            Menu.FirstMenu();
            
            Color.ColorGreen();
            Console.WriteLine("DoctorAppointmentDemo.UI");

        }
    }
}