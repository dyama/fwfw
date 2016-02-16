# fwfw

fuwafuwa GUI tool kit for script environment.

* fwfw は Zenity ライクなコマンドラインから呼び出すことができる簡単な GUI ツールキットです。
* .NET Framework のみを利用しているため、バイナリサイズが非常に小さくて済みます。

## Usage

fwfw は次のコマンドによって起動します。

    fwfw.exe [アプレット名] [オプション] [引数]

### dialog ... ダイアログ

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

###  openfile ... 「ファイルを開く」ダイアログ

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

## Lisence

MIT Lisence

## Author

dyama / Daisuke YAMAGUCHI <dyama@member.fsf.org>

