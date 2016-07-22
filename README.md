# fwfw

fuwafuwa GUI tool kit for script environment.

* fwfw は Zenity ライクなコマンドラインから呼び出すことができる簡単な GUI ツールキットです。
  * Zenity との互換性はありません。
* .NET Framework のみを利用しているため、バイナリサイズが非常に小さくて済みます。
* 主に Windows 上で動作させることを目的とした、シェルスクリプトや mruby-cli などの標準 GUI を持たない小さなスクリプト・ツールから呼び出すことを想定しています。
  * より複雑なことをしたい方は、Zenity の Windows 版か Tcl/Tk を利用する選択肢があります。;-)
    * さらに大規模なことをしたい方は、Qt や electron がおすすめです。

## Usage

    fwfw.exe [applet-name] [options] [arguments]

## Applets

See: https://github.com/dyama/fwfw/wiki

### Comparison with the Zenity

|            |fwfw|Zenity|
|------------|----|------|
|カレンダー  | o  | o    |
|フォーム    |    | o    |
|スケール    |    | o    |
|メッセージ  | o  | o    |
|テキスト入力| o  | o    |
|リスト      |    | o    |
|テキスト    |    | o    |
|カラー      | o  | o    |
|パスワード  |    | o    |
|通知        | o  | o    |
|ファイル選択| o  | o    |
|プログレス  |    | o    |
|プロッター  | o  |      |


## Lisence

MIT Lisence

## Author

dyama / Daisuke YAMAGUCHI <dyama@member.fsf.org>

