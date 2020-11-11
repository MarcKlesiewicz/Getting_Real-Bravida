using System;
using System.Collections.Generic;
using System.Text;

namespace GettingReal
{
    class Menu
    {
        public enum MenuItems
        {
            Entrepriseoversigt,
            Aftalesedler
        };

        public MenuItems Menuitem = MenuItems.Entrepriseoversigt;
        Overskrifter overskrift = new Overskrifter();

        
        public void Show()
        {
            Console.Clear();
            switch (Menuitem)
            {
                case MenuItems.Entrepriseoversigt:
                    overskrift.PrintEntrepriseOversigt();
                    break;
                case MenuItems.Aftalesedler:
                    overskrift.PrintAftalesedler();
                    break;
                default:
                    throw new ArgumentOutOfRangeException();
            }
        }

        public int SelectMenuItem(string value)
        {
            
            if (int.TryParse(value, out  int result) || result != 0)
            {
                
                
                return result;
            }

            return 0;

        }

    }
}
