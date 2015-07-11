using System;
using System.Reflection;
using System.Windows;
using System.Windows.Input;
using System.Windows.Interactivity;

namespace FinalstreamUIComponents.Commands
{
    /// <summary>
    /// EventをEventArg付きで処理するためのトリガーアクションを表します。
    /// </summary>
    public class InteractiveCommandAction : TriggerAction<DependencyObject>
    {
        public static readonly DependencyProperty CommandProperty =
            DependencyProperty.Register("Command", typeof (ICommand), typeof (InteractiveCommandAction),
                new UIPropertyMetadata(null));

        private string _commandName;

        public string CommandName
        {
            get
            {
                ReadPreamble();
                return _commandName;
            }
            set
            {
                if (CommandName != value)
                {
                    WritePreamble();
                    _commandName = value;
                    WritePostscript();
                }
            }
        }

        public ICommand Command
        {
            get { return (ICommand) GetValue(CommandProperty); }
            set { SetValue(CommandProperty, value); }
        }

        protected override void Invoke(object parameter)
        {
            if (AssociatedObject != null)
            {
                var command = ResolveCommand();
                if ((command != null) && command.CanExecute(parameter))
                {
                    command.Execute(parameter);
                }
            }
        }

        private ICommand ResolveCommand()
        {
            ICommand command = null;
            if (Command != null)
            {
                return Command;
            }
            if (AssociatedObject != null)
            {
                foreach (
                    var info in AssociatedObject.GetType().GetProperties(BindingFlags.Public | BindingFlags.Instance))
                {
                    if (typeof (ICommand).IsAssignableFrom(info.PropertyType) &&
                        string.Equals(info.Name, CommandName, StringComparison.Ordinal))
                    {
                        command = (ICommand) info.GetValue(AssociatedObject, null);
                    }
                }
            }
            return command;
        }
    }
}