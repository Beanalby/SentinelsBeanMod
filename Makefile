buildCmd=/c/Program\ Files\ \(x86\)/Microsoft\ Visual\ Studio/2022/BuildTools/MSBuild/Current/Bin/MSBuild.exe
build:
	$(buildCmd)

clean:
	rm -r BeanMod/obj BeanMod/bin