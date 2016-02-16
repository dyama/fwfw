# fwfw

fuwafuwa GUI tool kit for script environment.

* fwfw は Zenity ライクなコマンドラインから呼び出すことができる簡単な GUI ツールキットです。
  * Zenity との互換性はありません。
* .NET Framework のみを利用しているため、バイナリサイズが非常に小さくて済みます。
* 主に Windows 上で動作させることを目的とした、シェルスクリプトや mruby などの小さなスクリプト・ツールから呼び出すことを想定しています。
  * より複雑なことをしたい方は、Zenity の Windows 版か Tcl/Tk を利用する選択肢があります。;-)
    * さらに大規模なことをしたい方は、Qt や NW.js がおすすめです。

## Usage

    fwfw.exe [applet-name] [options] [arguments]

## Applets

### dialog ... ダイアログを表示する

#### オプション

* --type=[abortretryignore|ok|okcancel|retrycancel|yesno|yesnocancel] ... ボタンのタイプを指定します。
  * abortretryignore ... 「中止」「再試行」「無視」ボタンを表示します。
  * ok ... 「OK」ボタンのみを表示します。
  * okcancel ... 「OK」「キャンセル」ボタンを表示します。
  * retrycancel ... 「再試行」「キャンセル」ボタンを表示します。
  * yesno ... 「はい」「いいえ」ボタンを表示します。
  * yesnocancel ... 「はい」「いいえ」「キャンセル」ボタンを表示します。

* --icon=[asterisk|error|exclamation|hand|information|none|question|stop|warning] ... アイコンを指定します。
  * asterisk ...
  * error ...
  * exclamation ...
  * hand ...
  * information ...
  * none ...
  * question ...
  * stop ...
  * warning ...

* --caption="string" ... キャプションを指定します。
* --default=[1|2|3] ... デフォルトのボタンを指定します。

#### 引数

ダイアログに表示するテキストメッセージを指定します。複数の引数を渡すと改行します。

#### 結果

* 終了コード ... 常に 0 を返します。
* 標準出力 ...  ユーザーによってクリックされたボタン名が印字されます。

#### 例

    fwfw.exe dialog --caption="質問" --icon=question --type=yesno "処理を実行しますか？"
      => yes

###  openfile ... 「ファイルを開く」ダイアログを表示する

#### オプション

* --defaultext=".ext" ... デフォルトの拡張子を指定します。
* --filename="filename" ... デフォルトのファイル名を指定します。
* --filter="desc1|ext1|desc2|ext2|..." ... 拡張子フィルタを指定します。
* --title="string" ... タイトルバー文字列を指定します。
* --initialdir="path" ... 初期のディレクトリを指定します。
* --multiselect=[true|false] ... 複数のファイルを選択できるようにします。

#### 引数

なし

#### 結果

* 終了コード ... 常に 0 を返します。
* 標準出力 ... 選択されたファイルリストを改行区切りで印字します。

#### 例

    fwfw.exe openfile --filter="DXF file(*.dxf)|.dxf|テキストファイル(*.txt)|.txt" --title="選択してください。"
      => C:\\Windows\\Temp\\foobar.txt

### drawer ... 簡易プロッターを表示する

#### オプション

* --width=512 ... ウィンドウ(作画領域)の幅を指定します。
* --height=512 ... ウィンドウ(作画領域)の高さを指定します。
* --title="string" ... タイトル文字列を指定します。
* --pensize=1.0 ... ペンのサイズを指定します。
* --bgcolor=blue ... 背景色を指定します。
* --fgcolor=white ... 前景色を指定します。

#### 引数

なし

#### 結果

* 終了コード ... 常に 0 を返します。
* 標準出力 ... クリックした座標値のリストを改行で区切って印字します。

#### 例

    > type plot.txt
      0.0000   0.0000
    100.0000 100.0000
     50.0000  80.0000

    320.0000 160.0000
    240.0000 160.0000
    240.0000  80.0000

    > fwfw.exe drawer --bgcolor=blue --fgcolor=white < plot.txt

※プロットする作画情報は、標準入力に与えます。
※改行までを一連のポリライン(線分集合)として描画します。

## Lisence

MIT Lisence

## Author

dyama / Daisuke YAMAGUCHI <dyama@member.fsf.org>

