using Hospital.UI.Menu._0_Configuration;
using MyDoctorAppointment.Domain.Entities;
using MyDoctorAppointment.Domain.Enums;
using MyDoctorAppointment.Service.Interfaces;
using MyDoctorAppointment.Service.Services;
using MyDoctorAppointment.Data.Configuration;
using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Numerics;
using System.Reflection;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Channels;
using System.Threading.Tasks;
using System.Xml;
using System.Xml.Linq;
using System.Xml.Serialization;


namespace DoctorAppointmentDemo.Service.Services
{
    public class DoctorMenu
    {                       
        public/* readonly*/ IDoctorService _doctorService { get; }
        public DoctorMenu()
        {
            _doctorService = new DoctorService();
        }
        public virtual void ShowMenuRequestData()
        {
            Color.ColorWhite();

            var reader = File.ReadAllLines(ConstantMenuFilePath.RequestDataTxt);
            DoctorTypes[] daysArray = (DoctorTypes[])Enum.GetValues(typeof(DoctorTypes));
            const int CursorPositionLeft = 18;
            string DoctorTypesString = ("|5|Тип доктора    |              |");//   :(  с этим надо поработать :( 

            foreach (var item in reader)
            {
                Console.WriteLine(item);
                if (item == DoctorTypesString)
                {
                    foreach (var items in daysArray)
                    {
                        Console.Write($"| |{(int)items} {items}");
                        Console.SetCursorPosition(CursorPositionLeft, Console.CursorTop++);
                        Console.WriteLine("|              |");
                    }
                }
            }
        }
        public virtual Doctor RequestData()
        {
            while (true)
            {
                int CursorPositionTop = 3;
                const int CursorPositionLeft = 20;    
                
                const string MistakeTxt = "Ошибка       |                                          ";
                const string DeleteMistakeTxt = "             |                                                    ";

                const string RegexName = @"^[a-zA-Zа-яА-ЯёЁ]{1,13}$";
                const string RegexSurname= @"^[a-zA-Zа-яА-ЯёЁ]{1,13}$";
                const string RegexPhone  = @"^\+?\d{10,12}$";
                const string RegexEmail  = @"^[\w-\.]+@gmail\.com$";
                var DoctorTypesArray = (DoctorTypes[])Enum.GetValues(typeof(DoctorTypes));
                var MaxDoctors = DoctorTypesArray.Length;
                const int ExperienceMax = 70;
                const int ExperienceMin = 0;
                const decimal SalaryMin = 0;
                const decimal SalaryMax = 20000;
                //Doctor(Name, Surname, Phone, Email, DoctorType, Experience, Salary);


                ShowMenuRequestData();

                // Ввод имени с проверкой 
                string Name;
                do
                {
                    Console.SetCursorPosition(CursorPositionLeft, CursorPositionTop);
                    Name = Console.ReadLine();
                    if (!Regex.IsMatch(Name, RegexName))
                    {
                        Console.SetCursorPosition(CursorPositionLeft, CursorPositionTop);
                        Console.Write(MistakeTxt);
                        Console.ReadKey();
                        Console.SetCursorPosition(CursorPositionLeft, CursorPositionTop);
                        Console.WriteLine(DeleteMistakeTxt);
                    }
                } while (!Regex.IsMatch(Name, RegexName));
                CursorPositionTop++;
                // Ввод фамилии с проверкой
                string Surname;
                do
                {
                    Console.SetCursorPosition(CursorPositionLeft, CursorPositionTop);
                    Surname = Console.ReadLine();
                    if (!Regex.IsMatch(Surname, RegexSurname))
                    {
                        Console.SetCursorPosition(CursorPositionLeft, CursorPositionTop);
                        Console.Write(MistakeTxt);
                        Console.ReadKey();
                        Console.SetCursorPosition(CursorPositionLeft, CursorPositionTop);
                        Console.WriteLine(DeleteMistakeTxt);
                    }
                } while (!Regex.IsMatch(Surname, RegexName));
                CursorPositionTop++;
                // Ввод телефона с проверкой
                string Phone;
                do
                {
                    Console.SetCursorPosition(CursorPositionLeft, CursorPositionTop);
                    Phone = Console.ReadLine();
                    if (!Regex.IsMatch(Phone, RegexPhone))
                    {
                        Console.SetCursorPosition(CursorPositionLeft, CursorPositionTop);
                        Console.Write(MistakeTxt);
                        Console.ReadKey();
                        Console.SetCursorPosition(CursorPositionLeft, CursorPositionTop);
                        Console.WriteLine(DeleteMistakeTxt);
                    }
                } while (!Regex.IsMatch(Phone, RegexPhone));
                CursorPositionTop++;

                // Ввод email с проверкой
                string Email;
                do
                {
                    Console.SetCursorPosition(CursorPositionLeft, CursorPositionTop);
                    Email = Console.ReadLine();
                    if (!Regex.IsMatch(Email, RegexEmail))
                    {
                        Console.SetCursorPosition(CursorPositionLeft, CursorPositionTop);
                        Console.Write(MistakeTxt);
                        Console.ReadKey();
                        Console.SetCursorPosition(CursorPositionLeft, CursorPositionTop);
                        Console.WriteLine(DeleteMistakeTxt);
                    }
                } while (!Regex.IsMatch(Email, RegexEmail));
                CursorPositionTop++;

                // Ввод типа врача
                DoctorTypes DoctorType;
                do
                {
                    Console.SetCursorPosition(CursorPositionLeft, CursorPositionTop);
                    if (!byte.TryParse(Console.ReadLine(), out byte DoctorTypeValue) || DoctorTypeValue < 0 || DoctorTypeValue > MaxDoctors)
                    {
                        Console.SetCursorPosition(CursorPositionLeft, CursorPositionTop);
                        Console.Write(MistakeTxt);
                        Console.ReadKey();
                        Console.SetCursorPosition(CursorPositionLeft, CursorPositionTop);
                        Console.WriteLine(DeleteMistakeTxt);
                        continue;
                    }
                    DoctorType = (DoctorTypes)DoctorTypeValue;
                    break; // Успешный ввод
                } while (true);
                CursorPositionTop += 5;

                // Ввод опыта с проверкой
                byte Experience;
                do
                {
                    Console.SetCursorPosition(CursorPositionLeft, CursorPositionTop);
                    if (!byte.TryParse(Console.ReadLine(), out Experience) || Experience < ExperienceMin || Experience > ExperienceMax)
                    {
                        Console.SetCursorPosition(CursorPositionLeft, CursorPositionTop);
                        Console.Write(MistakeTxt);
                        Console.ReadKey();
                        Console.SetCursorPosition(CursorPositionLeft, CursorPositionTop);
                        Console.WriteLine(DeleteMistakeTxt);
                    }
                    else
                    {
                        break; // Успешный ввод
                    }
                } while (true);
                CursorPositionTop++;

                // Ввод зарплаты с проверкой
                decimal Salary;
                do
                {
                    Console.SetCursorPosition(CursorPositionLeft, CursorPositionTop); ;
                    string salaryInput = Console.ReadLine();
                    if (string.IsNullOrEmpty(salaryInput))
                    {
                        Salary = 0; // Значение по умолчанию
                        break;
                    }
                    if (!decimal.TryParse(salaryInput, out Salary) || Salary < SalaryMin || Salary > SalaryMax)
                    {
                        Console.SetCursorPosition(CursorPositionLeft, CursorPositionTop);
                        Console.Write(MistakeTxt);
                        Console.ReadKey();
                        Console.SetCursorPosition(CursorPositionLeft, CursorPositionTop);
                        Console.WriteLine(DeleteMistakeTxt);
                    }
                    else
                    {
                        break; // Успешный ввод
                    }
                } while (true);
                CursorPositionTop++;

                ////ПРОВЕРКА
                //string Name = "Иван";
                //string Surname = "Иванович";
                //string Phone = "0974672857";
                //string Email = "e@gmail.com";
                //DoctorTypes DoctorType = DoctorTypes.FamilyDoctor;
                //byte Experience = 20;
                //decimal Salary = 200;
                return new Doctor(Name, Surname, Phone, Email, DoctorType, Experience, Salary);

            }
        }
        public virtual void ShowAllDoctorsInList()
        {
            Console.WriteLine("Все врачи в формате Xml : В даный момен в разработке : ");//Список врачей на данный момент:
            Console.WriteLine("Все врачи в формате json: ");//Список врачей на данный момент:
            var docs = _doctorService.GetAll();
            foreach (var doc in docs)
            {
                Console.WriteLine("| |______________________________________________________");
                Console.WriteLine("| | Id" + doc.Id);
                Console.WriteLine("| |______________________________________________________");
                Console.WriteLine("| | Name       :" + doc.Name);
                Console.WriteLine("| | Surname    :" + doc.Surname);
                Console.WriteLine("| | Phone      :" + doc.Phone);
                Console.WriteLine("| | Email      :" + doc.Email);
                Console.WriteLine("| | DoctorType :" + doc.DoctorType);
                Console.WriteLine("| | xperience  :" + doc.Experience);
                Console.WriteLine("| | Salary     :" + doc.Salary);
                Console.WriteLine("| |______________________________________________________");

            }

        }
        public virtual void DeletoDoctorsShow()
        {
            Console.WriteLine("| |Удалить из формата xml : В даный момен в разработке   ");
            Console.WriteLine("| |______________________________________________________");

            Console.WriteLine("| |______________________________________________________");
            Console.WriteLine("| |Удалить из формата json ");
            Console.WriteLine("| |______________________________________________________");
            var docs = _doctorService.GetAll();
            foreach (var doc in docs)
            {
                Console.WriteLine("| |______________________________________________________");
                Console.WriteLine("| | Id   :" + doc.Id +" Name :" + doc.Name);
                Console.WriteLine("| |______________________________________________________");               
            }
           
        }
        public virtual bool DeletoDoctors(int id)
        {
            return _doctorService.Delete(id);
        }
        public virtual void Save(Doctor doctor)
        {
            while (true)
            {
                Color.ColorWhite();
                try
                {
                    Console.WriteLine("Сохранить в формате \n" +
                                      "1)json \n" +
                                      "2)xml");
                    var button = (button_on_2_elements)Convert.ToByte(Console.ReadLine());
                    switch (button)
                    {
                        case button_on_2_elements.first_menu_item://save to json
                            Console.WriteLine("доктор сохранен");
                            _doctorService.Create(doctor);
                            return;
                        case button_on_2_elements.second_menu_item://save to xml                                                                   
                            SaveDoctorToXml(doctor,Constants.AppSettingsPathXml);
                            return;
                        default:
                            continue;
                    }
                }
                catch
                {
                    continue;
                }
               
            }
        }

        

        public void SaveDoctorToXml(Doctor doctor, string filePath)
        {
            // Проверяем, существует ли файл
            bool fileExists = File.Exists(filePath);

            // Используем FileStream в блоке using
            using (FileStream fs = new FileStream(filePath, fileExists ? FileMode.Open : FileMode.Create, FileAccess.Write))
            {
                fs.Seek(0, SeekOrigin.End);  // Устанавливаем курсор в конец файла для дозаписи

                using (XmlWriter writer = XmlWriter.Create(fs, new XmlWriterSettings { Indent = true, OmitXmlDeclaration = fileExists }))
                {
                    if (!fileExists)
                    {
                        writer.WriteStartDocument();
                        writer.WriteStartElement("doctors");  // Корневой элемент, если файл создается заново
                    }
                    else
                    {
                        fs.SetLength(fs.Length - 10); // Убираем закрывающий тег </doctors> для дозаписи новых докторов
                    }

                    writer.WriteStartElement("doctor");

                    writer.WriteElementString("Id", doctor.Id.ToString());
                    writer.WriteElementString("Name", doctor.Name);
                    writer.WriteElementString("Surname", doctor.Surname);
                    writer.WriteElementString("Phone", doctor.Phone);
                    writer.WriteElementString("Email", doctor.Email);
                    writer.WriteElementString("DoctorType", doctor.DoctorType.ToString());
                    writer.WriteElementString("Experience", doctor.Experience.ToString());
                    writer.WriteElementString("Salary", doctor.Salary.ToString());
                    writer.WriteElementString("CreatedAt", doctor.CreatedAt.ToString());
                    writer.WriteElementString("UpdatedAt", doctor.UpdatedAt.ToString());

                    writer.WriteEndElement();
                    if (!fileExists)
                    {
                        writer.WriteEndElement();  // Закрываем корневой элемент
                        writer.WriteEndDocument();
                    }
                    else
                    {
                        writer.WriteRaw("</doctors>");  // Добавляем закрывающий тег </doctors> обратно после дозаписи
                    }
                }
            }

            Console.WriteLine($"Доктор добавлен в файл: {filePath}");
        }



    }
}
