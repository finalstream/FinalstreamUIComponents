# FinalstreamUIComponents

[![Build status](https://ci.appveyor.com/api/projects/status/c3uuqwr1d0q4c444?svg=true)](https://ci.appveyor.com/project/finalstream/finalstreamuicomponents)　[![NuGet](https://img.shields.io/nuget/v/FinalstreamUIComponents.svg?style=plastic)](https://www.nuget.org/packages/FinalstreamUIComponents/)　[![GitHub license](https://img.shields.io/github/license/finalstream/FinalstreamUIComponents.svg)](https://github.com/finalstream/FinalstreamUIComponents/blob/master/LICENSE)

WPF向けのUIコンポーネントです。  
[Livet](https://github.com/ugaya40/Livet)を使用させていただいており、MVVM向けに作成しております。

今後、Finalstreamのアプリケーションと共に精錬していく予定です。

## 主な機能
WPFのUIまわりのヘルパー的な機能を提供します。

###Behaviors
* ファイルのドラッグ＆ドロップ
* 左クリックでコンテキストメニューを開く
* テキストボックスのプレースホルダー（プレースホルダー文字色変更可能）

###Controls
* 入力フォーム作成支援（ラベルと入力コントロール(TextBox, ComboBox, ListBox, ReadOnly)のセット）  
![image](https://cloud.githubusercontent.com/assets/3516444/12699512/2ef2dd28-c801-11e5-8f92-bc09324d456a.png)

* NumericUpDownコントロール  
![image](https://cloud.githubusercontent.com/assets/3516444/12699508/f5a02a80-c800-11e5-9ec6-63e8e73e05e9.png)

* クリアアイコン付きのテキストボックス  
![image](https://cloud.githubusercontent.com/assets/3516444/12699497/88dc7eda-c800-11e5-89bf-fdfd46c73b6f.png)

* 追加削除可能なリストボックス  
![image](https://cloud.githubusercontent.com/assets/3516444/12699507/e244f29a-c800-11e5-8b54-8f586d13758c.png)

###Converters
* BoolToVisibilityConverter
* NullVisibilityConverter
* StringIsNullOrEmptyVisibilityConverter
* StringIsNullOrEmptyFontBoldConverter（ある値が入ってたらフォントを太くする）


###Commands
* CancelableDataGridSortingCommand（DataGridのヘッダクリックソートのサイクルをASC→DESC→NONEにする）
