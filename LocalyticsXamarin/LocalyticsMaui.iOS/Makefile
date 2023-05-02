MONOXBUILD=/Library/Frameworks/Mono.framework/Commands/msbuild

all : bin/Release/LocalyticsMaui.iOS.dll

bin/Release/LocalyticsMaui.iOS.dll :
	$(MONOXBUILD) /p:Configuration=Release LocalyticsMaui.iOS.csproj

clean :
	rm -rf bin obj

