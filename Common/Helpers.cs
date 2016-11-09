using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Input;

namespace Common
{
    public class InputHelpers
    {
        public static bool IsValidDigitKey(Key key)
        {
            bool b;
            switch (key)
            {
                case Key.Back: b = true; break;
                case Key.D0: b = true; break;
                case Key.D1: b = true; break;
                case Key.D2: b = true; break;
                case Key.D3: b = true; break;
                case Key.D4: b = true; break;
                case Key.D5: b = true; break;
                case Key.D6: b = true; break;
                case Key.D7: b = true; break;
                case Key.D8: b = true; break;
                case Key.D9: b = true; break;
                case Key.NumPad0:
                case Key.NumPad1:
                case Key.NumPad2:
                case Key.NumPad3:
                case Key.NumPad4:
                case Key.NumPad5:
                case Key.NumPad6:
                case Key.NumPad7:
                case Key.NumPad8:
                case Key.NumPad9: b = true; break;
                case Key.OemPeriod: b = true; break;
                case Key.Decimal: b = true;
                    break;
                default:
                    b = false;break;
            }
            return b;
        }
    }
}
