MONOXBUILD=/Library/Frameworks/Mono.framework/Commands/msbuild

all : bin/Release/LocalyticsMaui.Android.dll

bin/Release/LocalyticsMaui.Android.dll : jars/library-6.3.7.aar
	$(MONOXBUILD) /p:Configuration=Release LocalyticsMaui.Android.csproj

clean :
	rm -rf bin obj
