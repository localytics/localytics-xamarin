MONOXBUILD=/Library/Frameworks/Mono.framework/Commands/xbuild

all : bin/Release/LocalyticsXamarin.iOS.dll

bin/Release/LocalyticsXamarin.iOS.dll :
	$(MONOXBUILD) /p:Configuration=Release LocalyticsXamarin.iOS.csproj

clean :
	rm -rf bin obj

