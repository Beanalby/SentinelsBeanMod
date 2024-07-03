BUILD_CMD=/c/Program\ Files\ \(x86\)/Microsoft\ Visual\ Studio/2022/BuildTools/MSBuild/Current/Bin/MSBuild.exe

# CONFIG defaults to "Release" if unset
CONFIG?="Release"
build:
	echo Buiding $(CONFIG)
	$(BUILD_CMD) /t:BeanMod /p:Configuration=$(CONFIG)

buildConsole:
	$(BUILD_CMD) /t:ModConsole /p:Configuration=$(CONFIG)

run: buildConsole
	./ModConsole/bin/$(CONFIG)/ModConsole.exe

runi: buildConsole
	./ModConsole/bin/$(CONFIG)/ModConsole.exe -i

clean:
	rm -r */bin */obj
