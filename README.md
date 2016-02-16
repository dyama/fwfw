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

See: https://github.com/dyama/fwfw/wiki

## Lisence

MIT Lisence

## Author

dyama / Daisuke YAMAGUCHI <dyama@member.fsf.org>

