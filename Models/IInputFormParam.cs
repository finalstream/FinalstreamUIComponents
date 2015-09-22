using System.Collections.Generic;

namespace FinalstreamUIComponents.Models
{
    /// <summary>
    /// 
    /// </summary>
    public interface IInputFormParam
    {
        
        /// <summary>
        /// 変更したかどうかを取得します。
        /// </summary>
        bool IsModify { get; }

        InputType InputType { get; }

        /// <summary>
        /// タイトルを取得または設定します。
        /// </summary>
        string Title { get; set; }

        /// <summary>
        /// 値を取得または設定します。
        /// </summary>
        object Value { get; set; }

        IEnumerable<object> Values { get; set; }
    }
}