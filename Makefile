BUILD_CMD=/c/Program\ Files\ \(x86\)/Microsoft\ Visual\ Studio/2022/BuildTools/MSBuild/Current/Bin/MSBuild.exe
SENTINELS_MODS_DIR=/e/Steam/steamapps/common/Sentinels\ of\ the\ Multiverse/mods
SENTINELS_THISMOD_DIR=$(SENTINELS_MODS_DIR)/BeanMod

# CONFIG defaults to "Release" if unset
CONFIG?="Release"
all: buildAll tests

checkJSON:
	find . -name \*.json -print0 | xargs -0 -n1 bash -c 'echo checking "$$@"; cat "$$@" | jq > /dev/null;' ''

build: checkJSON
	$(BUILD_CMD) /p:Configuration=$(CONFIG) /t:BeanMod
buildConsole:
	$(BUILD_CMD) /p:Configuration=$(CONFIG) /t:ModConsole
buildTests:
	$(BUILD_CMD) /p:Configuration=$(CONFIG) /t:ModTest
buildAll: build buildConsole buildTests

run: buildConsole
	./ModConsole/bin/$(CONFIG)/ModConsole.exe
runi: buildConsole
	./ModConsole/bin/$(CONFIG)/ModConsole.exe -i

install: build
	mkdir -p $(SENTINELS_THISMOD_DIR)
	cp ./BeanMod/bin/$(CONFIG)/BeanMod.dll $(SENTINELS_THISMOD_DIR)
	cp -r ./Resources/* $(SENTINELS_THISMOD_DIR)

tests: buildTests
# NUnit doesn't like being invoked from WSL
	cmd.exe /c runtests.bat $(CONFIG)

clean:
	rm -r */bin */obj