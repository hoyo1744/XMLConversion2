using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Input;

namespace XMLConversion.Command
{
    public class FormatCommand
    {
        public static RoutedUICommand formatCommand;

        static FormatCommand()
        {
            InputGestureCollection formatInputs = new InputGestureCollection();
            formatInputs.Add(new KeyGesture(Key.O, ModifierKeys.Alt));
            formatCommand = new RoutedUICommand("Format", "Format", typeof(EditCommand), formatInputs);
        }
    }
}
