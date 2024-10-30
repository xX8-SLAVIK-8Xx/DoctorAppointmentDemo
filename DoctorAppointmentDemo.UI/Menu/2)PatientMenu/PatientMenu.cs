using Hospital.UI.Menu._0_Configuration;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Hospital.Services.Menu.PatientMenu
{
    public class PatientMenu
    {
        public static void PatientMenu_ () 
        {
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
                            break;
                        case button_on_3_elements.second_menu_item:
                            break;
                        case button_on_3_elements.third_menu_item:
                            break;
                        default:
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
}
