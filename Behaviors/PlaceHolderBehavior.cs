using System;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Interactivity;
using System.Windows.Media;
using FinalstreamCommons.Utils;

namespace FinalstreamUIComponents.Behaviors
{
    /// <summary>
    /// プレースホルダーを表示するビヘイビアを表します。
    /// </summary>
    /// <typeparam name="T"></typeparam>
    public abstract class PlaceHolderBehaviorBase<T> : Behavior<T> where T : Control
    {

        #region OnForegroundChangedイベント

        // Event object
        public event EventHandler ForegroundChanged;

        protected virtual void OnForegroundChanged(EventArgs e)
        {
            var handler = this.ForegroundChanged;
            if (handler != null)
            {
                handler(this, e);
            }
        }

        #endregion

        public String Placeholder
        {
            get { return (String)GetValue(PlaceholderProperty); }
            set { SetValue(PlaceholderProperty, value); }
        }

        public static readonly DependencyProperty PlaceholderProperty =
            DependencyProperty.Register("Placeholder", typeof(String), typeof(PlaceHolderBehaviorBase<T>));

        public SolidColorBrush Foreground
        {
            get { return (SolidColorBrush)GetValue(ForegroundProperty); }
            set {
                SetValue(ForegroundProperty, value);
            }
        }

        public static readonly DependencyProperty ForegroundProperty =
            DependencyProperty.Register("Foreground", typeof(SolidColorBrush), typeof(PlaceHolderBehaviorBase<T>), new FrameworkPropertyMetadata(
                (o, args) =>
                {
                    var b = o as TextBoxPlaceholderBehavior;
                    if (b!=null) b.OnForegroundChanged(EventArgs.Empty);
                }));

        protected abstract String GetContent(T control);

        //protected Brush defaultBackground;

        protected override void OnAttached()
        {
            base.OnAttached();
            this.AssociatedObject.Initialized += this.OnInitialized;
            this.AssociatedObject.GotFocus += this.OnGotFocus;
            this.AssociatedObject.LostFocus += this.OnLostFocus;
        }

        protected override void OnDetaching()
        {
            base.OnDetaching();
            this.AssociatedObject.Initialized -= this.OnInitialized;
            this.AssociatedObject.GotFocus -= this.OnGotFocus;
            this.AssociatedObject.LostFocus -= this.OnLostFocus;
        }

        private void OnInitialized(Object sender, EventArgs e)
        {
            var control = sender as T;
            if (control == null)
            {
                return;
            }

            this.ForegroundChanged += (o, args) =>
            {
                // 文字色が変わったら再描画
                OnLostFocus(this.AssociatedObject, new EventArgs());
            };

            //this.defaultBackground = control.Background;
            control.Background = this.CreateVisualBrush(this.Placeholder);
        }

        private void OnGotFocus(Object sender, RoutedEventArgs e)
        {
            var control = sender as T;
            if (control == null)
            {
                return;
            }
            control.Background = this.CreateVisualBrush("");
            //control.Background = this.defaultBackground;
        }

        private void OnLostFocus(Object sender, EventArgs e)
        {
            var control = sender as T;
            if (control == null)
            {
                return;
            }
            var content = this.GetContent(control);
            if (String.IsNullOrEmpty(content) == false)
            {
                return;
            }
            control.Background = this.CreateVisualBrush(this.Placeholder);
        }

        protected VisualBrush CreateVisualBrush(string placeHolder)
        {
            var visual = new Label
            {
                Content = placeHolder,
                Padding = new Thickness(5, 1, 1, 1),
                Foreground = this.Foreground == null ? new SolidColorBrush(Colors.LightGray) : new SolidColorBrush(ColorUtils.GetReverseColor(this.Foreground.Color, 125)),
                HorizontalAlignment = HorizontalAlignment.Left,
                VerticalAlignment = VerticalAlignment.Center,
            };

            return new VisualBrush(visual)
            {
                Stretch = Stretch.None,
                TileMode = TileMode.None,
                AlignmentX = AlignmentX.Left,
                AlignmentY = AlignmentY.Center,
            };
        }
    }

    public class TextBoxPlaceholderBehavior : PlaceHolderBehaviorBase<TextBox>
    {
        protected override void OnAttached()
        {
            base.OnAttached();
            this.AssociatedObject.TextChanged += OnTextChanged;
        }

        protected override void OnDetaching()
        {
            base.OnDetaching();
            this.AssociatedObject.TextChanged -= OnTextChanged;
        }

        private void OnTextChanged(object sender, TextChangedEventArgs e)
        {
            var control = sender as TextBox;
            if (control == null)
            {
                return;
            }

            var content = this.GetContent(control);
            if (String.IsNullOrEmpty(content) == false)
            {
                control.Background = this.CreateVisualBrush("");
            }

            //if (control.IsFocused == false)
            //{
            //    //control.Background = this.Background;
            //}
        }

        protected override string GetContent(TextBox control)
        {
            return control.Text;
        }
    }

    public class ComboBoxPlaceholderBehavior : PlaceHolderBehaviorBase<ComboBox>
    {
        protected override string GetContent(ComboBox control)
        {
            return control.Text;
        }
    }
}