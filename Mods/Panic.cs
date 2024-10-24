using StupidTemplate.Classes;
using StupidTemplate.Menu;
using StupidTemplate.Notifications;
using System;

namespace StupidTemplate.Mods
{
    internal class Panic
    {
        public static void PanicMod()
        {
            foreach (ButtonInfo[] buttonlist in Buttons.buttons)
            {
                foreach (ButtonInfo v in buttonlist)
                {
                    if (v.enabled)
                    {
                        Toggle(v.buttonText);
                    }
                }
            }
            NotifiLib.ClearAllNotifications();
        }

        private static void Toggle(string buttonText)
        {
            throw new NotImplementedException();
        }
    }
}
