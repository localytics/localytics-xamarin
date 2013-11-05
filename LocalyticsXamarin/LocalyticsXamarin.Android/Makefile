MONOXBUILD=/Library/Frameworks/Mono.framework/Commands/xbuild

all : bin/Release/LocalyticsXamarin.Android.dll

bin/Release/LocalyticsXamarin.Android.dll : jars/localytics.jar
	$(MONOXBUILD) /p:Configuration=Release LocalyticsXamarin.Android.csproj

clean :
	rm -rf bin obj
