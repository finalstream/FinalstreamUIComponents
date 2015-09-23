using System.Collections.Generic;
using System.Linq;
using System.Windows.Controls;
using FinalstreamUIComponents.Models;
using FinalstreamUIComponents.ViewModels;

namespace FinalstreamUIComponents.Views
{
    /// <summary>
    /// InputFormContent.xaml の相互作用ロジック
    /// </summary>
    public partial class InputFormContent : UserControl
    {
        /// <summary>
        /// 新しいインスタンスを生成します。
        /// </summary>
        public InputFormContent()
        {
            InitializeComponent();
        }

        public Dictionary<string, IInputFormParam> InputParamDictionary { get { return _viewModel.InputParamDictionary; } }

        /// <summary>
        /// 変更があったかどうか
        /// </summary>
        public bool IsModify
        {
            get { return InputParamDictionary.Select(x => x.Value.IsModify).Any(x => x) && InputParamDictionary.All(x=>!string.IsNullOrEmpty(x.Value.Value.ToString())); }
        }

        private readonly InputFormContentViewModel _viewModel;

        public InputFormContent(string messge, Dictionary<string, IInputFormParam> paramDic)
            : this()
        {
            _viewModel = new InputFormContentViewModel();
            _viewModel.TitleWidth = 100;
            _viewModel.ValueMinWidth = 250;
            _viewModel.ValueMaxWidth = 450;
            _viewModel.ValueMaxHeight = 100;
            _viewModel.Message = messge;
            _viewModel.InputParamDictionary = paramDic;
            this.DataContext = _viewModel;
        }

        public double TitleWidth
        {
            set { _viewModel.TitleWidth = value; }
        }

        public double ValueMinWidth
        {
            set { _viewModel.ValueMinWidth = value; }
        }

        public double ValueMaxWidth
        {
            set { _viewModel.ValueMaxWidth = value; }
        }

        public double ValueMaxHeight
        {
            set { _viewModel.ValueMaxWidth = value; }
        }
    }
}
