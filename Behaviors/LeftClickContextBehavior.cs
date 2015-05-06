using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;

namespace FinalstreamUIComponents.Behaviors
{
    /// <summary>
    /// 左クリックでコンテキストメニューを表示するビヘイビアを表します。
    /// </summary>
    /// <remarks>Reference http://brianseekford.com/wordpress/?p=422</remarks>
    public static class LeftClickContextBehavior
    {

        private static void OnHandleEnabledChanged(DependencyObject d, DependencyPropertyChangedEventArgs e)
        {
            var ele = d as Button;
            if (ele != null)
            {
                ele.Click -= OnClick;
                if (e.NewValue != null && ((bool)e.NewValue))
                {
                    ele.Click += OnClick;
                }
            }
        }

        public static readonly DependencyProperty EnabledProperty
            = DependencyProperty.RegisterAttached("Enabled", typeof(bool), typeof(LeftClickContextBehavior),
                                                  new FrameworkPropertyMetadata(false,
                                                                                new PropertyChangedCallback(
                                                                                    OnHandleEnabledChanged)));
        public static bool GetEnabled(DependencyObject dependencyObj)
        {
            if (dependencyObj == null)
                throw new ArgumentNullException("dependencyObj");

            return (bool)dependencyObj.GetValue(EnabledProperty);
        }

        public static void SetEnabled(DependencyObject dependencyObj, bool value)
        {
            if (dependencyObj == null)
                throw new ArgumentNullException("dependencyObj");

            dependencyObj.SetValue(EnabledProperty, value);
        }

        private static void OnClick(object sender, RoutedEventArgs e)
        {
            var ele = sender as Button;
            var originalSender = e.OriginalSource as DependencyObject;
            var logicalSender = e.OriginalSource as FrameworkElement;
            var logicalSource = e.Source as FrameworkElement;

            if (ele == null || originalSender == null || sender == null || logicalSource == null || logicalSender == null)
                return;

            if (logicalSource.DataContext != logicalSender.DataContext)
                return;

            var dependencyObject = sender as DependencyObject;
            if (dependencyObject == null)
                return;

            if (ele.ContextMenu != null)
            {
                ele.ContextMenu.PlacementTarget = ele;
                ele.ContextMenu.IsOpen = true;
            }
        }

    } 
}
