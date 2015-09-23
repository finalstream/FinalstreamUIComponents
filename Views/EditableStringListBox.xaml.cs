using System;
using System.Collections.ObjectModel;
using System.ComponentModel;
using System.IO;
using System.Runtime.CompilerServices;
using System.Windows;
using System.Windows.Forms;
using UserControl = System.Windows.Controls.UserControl;

namespace FinalstreamUIComponents.Views
{
    /// <summary>
    /// EditableStringListBox.xaml の相互作用ロジック
    /// </summary>
    public partial class EditableStringListBox : UserControl, IDataErrorInfo
    {

        public enum ValidatorType
        {
            None,
            Directory
        }

        public EditableStringListBox()
        {
            InitializeComponent();

        }

        public static readonly DependencyProperty ValidatorProperty =
    DependencyProperty.Register(
        "Validator",
        typeof(ValidatorType),
        typeof(EditableStringListBox),
        new PropertyMetadata(ValidatorType.None));

        public ValidatorType Validator
        {
            get { return (ValidatorType)GetValue(ValidatorProperty); }
            set
            {
                SetValue(ValidatorProperty, value);
            }
        }

        #region AddString変更通知プロパティ

        private string _AddString;

        public string AddString
        {
            get { return _AddString; }
            set
            {
                if (_AddString == value) return;
                _AddString = value;
                OnPropertyChanged();
            }
        }

        #endregion

        public static readonly DependencyProperty ItemsSourceProperty =
    DependencyProperty.Register(
        "ItemsSource",
        typeof(Collection<string>),
        typeof(EditableStringListBox),
        new PropertyMetadata(null, PropertyChangedCallback));

        private static void PropertyChangedCallback(DependencyObject dependencyObject, DependencyPropertyChangedEventArgs dependencyPropertyChangedEventArgs)
        {
            var esl = dependencyObject as EditableStringListBox;
            if (esl == null) return;
            esl.OnPropertyChanged("ItemsSource");
        }

        public Collection<string> ItemsSource
        {
            get { return (Collection<string>)GetValue(ItemsSourceProperty); }
            set
            {
                SetValue(ItemsSourceProperty, value);
            }
        }

        public event PropertyChangedEventHandler PropertyChanged;

        protected virtual void OnPropertyChanged([CallerMemberName] string propertyName = null)
        {
            PropertyChangedEventHandler handler = PropertyChanged;
            if (handler != null) handler(this, new PropertyChangedEventArgs(propertyName));
        }

        public void Add()
        {
            if (string.IsNullOrEmpty(AddString) || ItemsSource.Contains(AddString)) return;
            ItemsSource.Add(AddString);
            AddTextBox.Clear();
        }

        public void Delete(string str)
        {
            ItemsSource.Remove(str);
        }

        public void SelectFolder()
        {
            //OpenFileDialogクラスのインスタンスを作成
            var fbd = new FolderBrowserDialog();

            fbd.ShowNewFolderButton = false;

            //ルートフォルダを指定する
            //デフォルトでDesktop
            fbd.RootFolder = Environment.SpecialFolder.Desktop;

            //ダイアログを表示する
            if (fbd.ShowDialog() == DialogResult.OK)
            {
                AddTextBox.Text = fbd.SelectedPath;
            }
        }

        public string this[string columnName]
        {
            get
            {
                if (columnName == "AddString")
                {
                    if (string.IsNullOrEmpty(AddString))
                    {
                        // empty
                        AddButton.IsEnabled = false;
                        return null;
                    }

                    if (ItemsSource.Contains(AddString))
                    {
                        AddButton.IsEnabled = false;
                        return "already exists";
                    }

                    if (Validator == ValidatorType.Directory)
                    {
                        var isValid = Directory.Exists(AddString);
                        AddButton.IsEnabled = isValid;
                        return !isValid ? "invalid" : null;
                    }

                }
                return null;
            }
        }

        public string Error
        {
            get { return null; }
        }
    }
}
