using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO;
using GTA;
using GTA.Native;
using GTA.Math;
using System.Windows.Forms;
using System.Drawing;
using System.Runtime.ExceptionServices;
using System.Drawing.Printing;
using System.Linq.Expressions;
using LemonUI;


namespace iMenu
{
    public class Main : Script
    {
        private Menu iMenu;
        Main()
        {
            
            Interval = 5;
            AddMainEvents();
        }

        public void AddMainEvents()
        {
            Tick += Main_OnTick;
            KeyDown += Main_OnKeyDown;
        }

        public void RemoveMainEvents()
        {
            Tick -= Main_OnTick;
            KeyDown -= Main_OnKeyDown;
        }

        private void Main_OnTick(object sender, EventArgs e)
        {
           
            if (Game.IsControlEnabled(0, GTA.Control.Phone) && Game.IsControlJustPressed(0, GTA.Control.Phone))
            {
                if (iMenu == null)
                {
                    iMenu = new Menu(this);
                }
            }
        }

        private void Main_OnKeyDown(object sender, KeyEventArgs e)
        {
            
        }
    }

    public class Menu : Script
    {

        private String WallpaperPath;

        private List<Item> Items;
        private Point PhoneScreenStartPosition;

        #region LemonUI
        private LemonUI.ObjectPool LemonUIPool;
        private bool bEnableLeemonUI;
        #endregion
        public Menu(Main MainHandle)
        {
            MainHandle.RemoveMainEvents();

            WallpaperPath = "./Scripts/iMenu/Wallpapers/Anonymous.png";

            Items  = new List<Item>();
            PhoneScreenStartPosition = new Point(1024, 900);

            bEnableLeemonUI = false;

            Interval = 5;
            Tick += Menu_OnTick;
            KeyDown += Menu_OnKeyDown;
        }

        private void Menu_OnKeyDown(object sender, KeyEventArgs e)
        {
            
        }

        private void Menu_OnTick(object sender, EventArgs e)
        {
            UI.DrawTexture(WallpaperPath, 0, 0, 1, PhoneScreenStartPosition, new Size(300, 370));
        }

        private void AddItem(Item item) 
        {
            Items.Add(item);
        }

        private void RemoveItem(Item item)
        {
            Items.Remove(item);
        }

        private void HandleLeemonUIPool()
        {
            if (bEnableLeemonUI)
            {
                LemonUIPool.Process();
            }
        }
    }


    public class Item
    {
        public string Name;
        public string IconPath;
        private Point Position;
        public Item(string name, string iconPath)
        {
            Name = name;
            IconPath = iconPath;
        }

        public void SetItemPosition(Point position) 
        {
            Position = position;
        }
    }

}
