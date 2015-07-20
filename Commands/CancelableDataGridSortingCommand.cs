using System;
using System.ComponentModel;
using System.Windows.Controls;
using System.Windows.Data;

namespace FinalstreamUIComponents.Commands
{
    /// <summary>
    ///     キャンセル可能なソート処理を実装するSortingコマンドを表します。
    /// </summary>
    /// <remarks>DataGridのヘッダクリックのソートは昇順→降順のループなので昇順→降順→ソートなしのループになります。</remarks>
    public class CancelableDataGridSortingCommand : DelegateCommand<DataGridSortingEventArgs>
    {
        public CancelableDataGridSortingCommand(object source, Action afterAction = null) : base(args =>
        {
            var sortDirection = args.Column.SortDirection;
            if (sortDirection == ListSortDirection.Descending)
            {
                // 降順の次はソートを無効にする
                args.Column.SortDirection = null;
                args.Handled = true;
                var view = CollectionViewSource.GetDefaultView(source);
                view.SortDescriptions.Clear();
            }
            if (afterAction != null) afterAction.Invoke();
        })
        {
        }
    }
}