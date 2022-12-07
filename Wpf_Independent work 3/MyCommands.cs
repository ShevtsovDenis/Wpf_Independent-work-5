using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Input;

namespace Wpf_Independent_work_3
{
    class MyCommands
    {
        public static RoutedUICommand Exit { get; set; }//свойство, которое и является командой

        static MyCommands()//статический метод для инициализации команды
        {
            InputGestureCollection inputs = new InputGestureCollection();//создаем экземпляр коллекции для быстрых клавиш
            inputs.Add(new KeyGesture(Key.T, ModifierKeys.Control, "Ctrl+T"));//добавляем в коллекцию необходимое сочетание клавиш
            Exit = new RoutedUICommand("Закрыть", "Exit", typeof(MyCommands), inputs);//для инициализации используется конструктор класса RoutedUICommand
        }

    }
}
