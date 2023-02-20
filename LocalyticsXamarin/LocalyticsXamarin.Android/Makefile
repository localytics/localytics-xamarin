MONOXBUILD=/Library/Frameworks/Mono.framework/Commands/msbuild

all : bin/Release/LocalyticsXamarin.Android.dll

bin/Release/LocalyticsXamarin.Android.dll : jars/library-6.3.7.aar
	$(MONOXBUILD) /p:Configuration=Release LocalyticsXamarin.Android.csproj

clean :
	rm -rf bin obj
