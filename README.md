# fwfw

fuwafuwa GUI tool kit for script environment.

* fwfw �� Zenity ���C�N�ȃR�}���h���C������Ăяo�����Ƃ��ł���ȒP�� GUI �c�[���L�b�g�ł��B
* .NET Framework �݂̂𗘗p���Ă��邽�߁A�o�C�i���T�C�Y�����ɏ������čς݂܂��B

## Usage

fwfw �͎��̃R�}���h�ɂ���ċN�����܂��B

    fwfw.exe [�A�v���b�g��] [�I�v�V����] [����]

### dialog ... �_�C�A���O

#### �I�v�V����

* --type=[abortretryignore|ok|okcancel|retrycancel|yesno|yesnocancel] ... �{�^���̃^�C�v���w�肵�܂��B
  * abortretryignore ... �u���~�v�u�Ď��s�v�u�����v�{�^����\�����܂��B
  * ok ... �uOK�v�{�^���݂̂�\�����܂��B
  * okcancel ... �uOK�v�u�L�����Z���v�{�^����\�����܂��B
  * retrycancel ... �u�Ď��s�v�u�L�����Z���v�{�^����\�����܂��B
  * yesno ... �u�͂��v�u�������v�{�^����\�����܂��B
  * yesnocancel ... �u�͂��v�u�������v�u�L�����Z���v�{�^����\�����܂��B

* --icon=[asterisk|error|exclamation|hand|information|none|question|stop|warning] ... �A�C�R�����w�肵�܂��B
  * asterisk ...
  * error ...
  * exclamation ...
  * hand ...
  * information ...
  * none ...
  * question ...
  * stop ...
  * warning ...

* --caption="string" ... �L���v�V�������w�肵�܂��B
* --default=[1|2|3] ... �f�t�H���g�̃{�^�����w�肵�܂��B

#### ����

�_�C�A���O�ɕ\������e�L�X�g���b�Z�[�W���w�肵�܂��B�����̈�����n���Ɖ��s���܂��B

#### ����

* �I���R�[�h ... ��� 0 ��Ԃ��܂��B
* �W���o�� ...  ���[�U�[�ɂ���ăN���b�N���ꂽ�{�^�������󎚂���܂��B

#### ��

    fwfw.exe dialog --caption="����" --icon=question --type=yesno "���������s���܂����H"
      => yes

###  openfile ... �u�t�@�C�����J���v�_�C�A���O

#### �I�v�V����

* --defaultext=".ext" ... �f�t�H���g�̊g���q���w�肵�܂��B
* --filename="filename" ... �f�t�H���g�̃t�@�C�������w�肵�܂��B
* --filter="desc1|ext1|desc2|ext2|..." ... �g���q�t�B���^���w�肵�܂��B
* --title="string" ... �^�C�g���o�[��������w�肵�܂��B
* --initialdir="path" ... �����̃f�B���N�g�����w�肵�܂��B
* --multiselect=[true|false] ... �����̃t�@�C����I���ł���悤�ɂ��܂��B

#### ����

�Ȃ�

#### ����

* �I���R�[�h ... ��� 0 ��Ԃ��܂��B
* �W���o�� ... �I�����ꂽ�t�@�C�����X�g�����s��؂�ň󎚂��܂��B

#### ��

    fwfw.exe openfile --filter="DXF file(*.dxf)|.dxf|�e�L�X�g�t�@�C��(*.txt)|.txt" --title="�I�����Ă��������B"
      => C:\\Windows\\Temp\\foobar.txt

## Lisence

MIT Lisence

## Author

dyama / Daisuke YAMAGUCHI <dyama@member.fsf.org>

