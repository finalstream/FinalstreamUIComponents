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
* NumericUpDownコントロール
* 入力テキストWithラベルコントール

###Converters
* BoolToVisibilityConverter
* NullVisibilityConverter
* StringIsNullOrEmptyVisibilityConverter
* StringIsNullOrEmptyFontBoldConverter（ある値が入ってたらフォントを太くする）


###Commands
* CancelableDataGridSortingCommand（DataGridのヘッダクリックソートのサイクルをASC→DESC→NONEにする）
