﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Windows.Controls;
using FinalstreamUIComponents.Models;
using Livet;

namespace FinalstreamUIComponents.ViewModels
{
    public class InputFormContentViewModel : ViewModel
    {
        /* コマンド、プロパティの定義にはそれぞれ 
         * 
         *  lvcom   : ViewModelCommand
         *  lvcomn  : ViewModelCommand(CanExecute無)
         *  llcom   : ListenerCommand(パラメータ有のコマンド)
         *  llcomn  : ListenerCommand(パラメータ有のコマンド・CanExecute無)
         *  lprop   : 変更通知プロパティ(.NET4.5ではlpropn)
         *  
         * を使用してください。
         * 
         * Modelが十分にリッチであるならコマンドにこだわる必要はありません。
         * View側のコードビハインドを使用しないMVVMパターンの実装を行う場合でも、ViewModelにメソッドを定義し、
         * LivetCallMethodActionなどから直接メソッドを呼び出してください。
         * 
         * ViewModelのコマンドを呼び出せるLivetのすべてのビヘイビア・トリガー・アクションは
         * 同様に直接ViewModelのメソッドを呼び出し可能です。
         */

        /* ViewModelからViewを操作したい場合は、View側のコードビハインド無で処理を行いたい場合は
         * Messengerプロパティからメッセージ(各種InteractionMessage)を発信する事を検討してください。
         */

        /* Modelからの変更通知などの各種イベントを受け取る場合は、PropertyChangedEventListenerや
         * CollectionChangedEventListenerを使うと便利です。各種ListenerはViewModelに定義されている
         * CompositeDisposableプロパティ(LivetCompositeDisposable型)に格納しておく事でイベント解放を容易に行えます。
         * 
         * ReactiveExtensionsなどを併用する場合は、ReactiveExtensionsのCompositeDisposableを
         * ViewModelのCompositeDisposableプロパティに格納しておくのを推奨します。
         * 
         * LivetのWindowテンプレートではViewのウィンドウが閉じる際にDataContextDisposeActionが動作するようになっており、
         * ViewModelのDisposeが呼ばれCompositeDisposableプロパティに格納されたすべてのIDisposable型のインスタンスが解放されます。
         * 
         * ViewModelを使いまわしたい時などは、ViewからDataContextDisposeActionを取り除くか、発動のタイミングをずらす事で対応可能です。
         */

        /* UIDispatcherを操作する場合は、DispatcherHelperのメソッドを操作してください。
         * UIDispatcher自体はApp.xaml.csでインスタンスを確保してあります。
         * 
         * LivetのViewModelではプロパティ変更通知(RaisePropertyChanged)やDispatcherCollectionを使ったコレクション変更通知は
         * 自動的にUIDispatcher上での通知に変換されます。変更通知に際してUIDispatcherを操作する必要はありません。
         */

        public void Initialize()
        {
            //TitleWidth = 100;
        }

        #region TitleWidth変更通知プロパティ

        private double _titleWidth;

        public double TitleWidth
        {
            get { return _titleWidth; }
            set
            {
                if (_titleWidth == value) return;
                _titleWidth = value;
                RaisePropertyChanged();
            }
        }

        #endregion

        #region ValueMinWidth変更通知プロパティ

        private double _valueMinWidth;

        public double ValueMinWidth
        {
            get { return _valueMinWidth; }
            set
            {
                if (_valueMinWidth == value) return;
                _valueMinWidth = value;
                RaisePropertyChanged();
            }
        }

        #endregion

        #region ValueMaxWidth変更通知プロパティ

        private double _valueMaxWidth;

        public double ValueMaxWidth
        {
            get { return _valueMaxWidth; }
            set
            {
                if (_valueMaxWidth == value) return;
                _valueMaxWidth = value;
                RaisePropertyChanged();
            }
        }

        #endregion

        #region ValueMaxHeight変更通知プロパティ

        private double _valueMaxHeight;

        public double ValueMaxHeight
        {
            get { return _valueMaxHeight; }
            set
            {
                if (_valueMaxHeight == value) return;
                _valueMaxHeight = value;
                RaisePropertyChanged();
            }
        }

        #endregion

        #region Message変更通知プロパティ

        private string _message;

        public string Message
        {
            get { return _message; }
            set
            {
                if (_message == value) return;
                _message = value;
                RaisePropertyChanged();
            }
        }

        #endregion

        #region InputParamDictionary変更通知プロパティ

        private Dictionary<string, IInputFormParam> _inputParamDictionary;



        public Dictionary<string, IInputFormParam> InputParamDictionary
        {
            get { return _inputParamDictionary; }
            set
            {
                if (_inputParamDictionary == value) return;
                _inputParamDictionary = value;
                RaisePropertyChanged();
            }
        }

        #endregion

    }
}
