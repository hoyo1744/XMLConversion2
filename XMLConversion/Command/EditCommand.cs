using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Input;

namespace XMLConversion.Command
{
    public class EditCommand
    {

        public static RoutedUICommand editCommand;

        static EditCommand()
        {
            InputGestureCollection editInputs= new InputGestureCollection();
            editInputs.Add(new KeyGesture(Key.F, ModifierKeys.Alt));
            editCommand= new RoutedUICommand("Edit", "Edit", typeof(EditCommand), editInputs);
        }

    }
}
