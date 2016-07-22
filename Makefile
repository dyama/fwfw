
all: fwfw
	

fwfw:
	mcs -sdk:4.5 -target:exe -main:fwfw.Program -r:System.Drawing.dll -r:System.Windows.Forms.dll -out:test/fwfw.exe *.cs applets/*.cs Properties/*.cs

