
using DoctorAppointmentDemo.Service.Services;
using Hospital.Services.Menu.PatientMenu;
using Hospital.UI.Menu._0_Configuration;
using System.Diagnostics.Contracts;
using System.Drawing;
using System.Text;
using static System.Net.Mime.MediaTypeNames;



public class Menu
{  
    public static void FirstMenu()
    {
        while (true)
        {
            try
            {
                //настроить цвет фона 
                Color.ColorBlue();
                //чтение файла меню Txt
                var reader = File.ReadAllLines(ConstantMenuFilePath.MainMmenuTxt);               
                foreach (var item in reader) { Console.WriteLine(item);}
                //развилка 
                var button = (button_on_2_elements)Convert.ToInt16(Console.ReadLine());
                switch (button)
                {
                    case button_on_2_elements.first_menu_item:
                        Menu.MenuDoctor();
                        break;
                    case button_on_2_elements.second_menu_item:
                        Console.WriteLine("В даный момен в разработке :)");
                        Console.ReadLine();
                        // PatientMenu.PatientMenu_();
                        break;
                    default:
                        return;//выход из цикла                                             
                }                
            }
            catch 
            {
                continue;
            }
        }  
    }
    public static void MenuDoctor()
    {
        var menu = new DoctorMenu();
        while (true)
        {
            Color.ColorWhite();
            try
            {
                var reader = File.ReadAllLines(ConstantMenuFilePath.DoctorMenuFrontentTxt);
                foreach (var item in reader) { Console.WriteLine(item); }

                var button = (button_on_3_elements)Convert.ToInt16(Console.ReadLine());
                switch (button)
                {
                    case button_on_3_elements.first_menu_item:
                        //Зарегистрировать врача
                        //1)показать запрос
                        //menu.RequestData();
                        menu.Save(menu.RequestData());

                        break;
                    case button_on_3_elements.second_menu_item:
                        //Удалить врача из списка
                        menu.DeletoDoctorsShow();
                        Console.WriteLine("Укажи id");
                        var id = Convert.ToInt16(Console.ReadLine());
                        menu.DeletoDoctors(id);
                        break;
                    case button_on_3_elements.third_menu_item:
                        //Просмотреть всех врачей
                        menu.ShowAllDoctorsInList();
                        break;
                    default:
                        //Завершить работу ++
                        return;
                }
                Console.ReadLine();
            }
            catch
            {
                continue;
            }
        }
    }
}
