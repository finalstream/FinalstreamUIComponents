using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Livet;

namespace FinalstreamUIComponents.Models
{
    public class InputParam : NotificationObject, IInputFormParam
    {
        private bool _isModify;

        public bool IsModify { get { return _isModify; }}

        public virtual InputType InputType
        {
            get { return InputType.String; }
        }

        #region Key変更通知プロパティ

        private string _title;

        public string Title
        {
            get { return _title; }
            set
            {
                if (_title == value) return;
                _title = value;
                RaisePropertyChanged();
            }
        }

        #endregion

        #region Value変更通知プロパティ

        private object _value;

        public object Value
        {
            get { return _value; }
            set
            {
                if (_value == value) return;
                _value = value;
                _isModify = true;
                RaisePropertyChanged();
            }
        }

        #endregion

        #region Values変更通知プロパティ

        private IEnumerable<object> _values;

        public IEnumerable<object> Values
        {
            get { return _values; }
            set
            {
                if (_values == value) return;
                _values = value;
                RaisePropertyChanged();
            }
        }

        #endregion

        /// <summary>
        /// 新しいインスタンスを初期化します。
        /// </summary>
        /// <param name="title"></param>
        /// <param name="value"></param>
        public InputParam(string title, object value)
        {
            _title = title;
            _value = value;
        }

        /// <summary>
        /// 新しいインスタンスを初期化します。
        /// </summary>
        /// <param name="title"></param>
        /// <param name="value"></param>
        public InputParam(string title, IEnumerable<string> values)
        {
            _title = title;
            _values = values;
        }

        /// <summary>
        /// 新しいインスタンスを初期化します。
        /// </summary>
        /// <param name="title"></param>
        /// <param name="value"></param>
        /// <param name="values"></param>
        /// <remarks>コンボボックスを表示する際に使用します。</remarks>
        protected InputParam(string title, object value, IEnumerable<string> values)
        {
            _title = title;
            _value = value;
            _values = values;
        }
    }
}
