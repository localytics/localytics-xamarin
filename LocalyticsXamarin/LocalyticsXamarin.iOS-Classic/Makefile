MONOXBUILD=/Library/Frameworks/Mono.framework/Commands/xbuild

all : bin/Release/LocalyticsXamarin.iOS-Classic.dll

bin/Release/LocalyticsXamarin.iOS-Classic.dll :
	$(MONOXBUILD) /p:Configuration=Release LocalyticsXamarin.iOS-Classic.csproj

clean :
	rm -rf bin obj

