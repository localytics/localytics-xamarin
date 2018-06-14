

JAVA_LT_180 := $(shell expr `javac -version 2>&1 | sed -Ee 's/^.{6}//' -Ee 's/([0-9]{1,2})/\1/g' -Ee 's/\.([0-9]{1,2})/\1/' -Ee 's/\.([0-9]{1,2})/\1/' -Ee 's/_[0-9]*//'` \< 180)

all :
#	cd LocalyticsXamarin/LocalyticsXamarin.iOS && make
#	cd LocalyticsXamarin/LocalyticsXamarin.Android && make
	cd LocalyticsXamarin && msbuild /p:Configuration=Release /t:Rebuild

clean :
	-cd LocalyticsXamarin && msbuild /p:Configuration=Debug /t:Clean
	-cd LocalyticsXamarin && msbuild /p:Configuration=Release /t:Clean
	-cd LocalyticsXamarin/LocalyticsXamarin.iOS && make clean
	-cd LocalyticsXamarin/LocalyticsXamarin.Android && make clean
	-rm -rf LocalyticsXamarin/*/bin LocalyticsXamarin/*/obj build 
	-rm -rf LocalyticsXamarin/LocalyticsMessagingSample.Android/bin LocalyticsXamarin/LocalyticsMessagingSample.Android/obj


release :
ifneq ($(VER),)
	-make  clean
	@echo 
	@echo Building version $(VER)
	@cp LocalyticsXamarin/LocalyticsXamarin.iOS/Properties/AssemblyInfo.cs LocalyticsXamarin/LocalyticsXamarin.iOS/Properties/AssemblyInfo.cs.org
	@sed 's/\(assembly:.AssemblyVersion...\)[0-9\.]*/\1'$(VER)'./' LocalyticsXamarin/LocalyticsXamarin.iOS/Properties/AssemblyInfo.cs.org > LocalyticsXamarin/LocalyticsXamarin.iOS/Properties/AssemblyInfo.cs
	@cp LocalyticsXamarin/LocalyticsXamarin.Android/Properties/AssemblyInfo.cs LocalyticsXamarin/LocalyticsXamarin.Android/Properties/AssemblyInfo.cs.org
	@sed 's/\(assembly:.AssemblyVersion...\)[0-9\.]*/\1'$(VER)'./' LocalyticsXamarin/LocalyticsXamarin.Android/Properties/AssemblyInfo.cs.org > LocalyticsXamarin/LocalyticsXamarin.Android/Properties/AssemblyInfo.cs
	@cp LocalyticsXamarin/LocalyticsXamarin.Common/Properties/AssemblyInfo.cs LocalyticsXamarin/LocalyticsXamarin.Common/Properties/AssemblyInfo.cs.org
	@sed 's/\(assembly:.AssemblyVersion...\)[0-9\.]*/\1'$(VER)'./' LocalyticsXamarin/LocalyticsXamarin.Common/Properties/AssemblyInfo.cs.org > LocalyticsXamarin/LocalyticsXamarin.Common/Properties/AssemblyInfo.cs
	@cp LocalyticsXamarin/LocalyticsXamarin.NuGet/Localytics.NuGet.nuproj LocalyticsXamarin/LocalyticsXamarin.NuGet/Localytics.NuGet.nuproj.org
	@cd LocalyticsXamarin/LocalyticsXamarin.NuGet && sed 's/\(\<PackageVersion\>\)[^\<]*\(\<\/PackageVersion\>\)/\1'$(VER)'\2/' Localytics.NuGet.nuproj.org >  Localytics.NuGet.nuproj
	@rm LocalyticsXamarin/LocalyticsXamarin.iOS/Properties/AssemblyInfo.cs.org LocalyticsXamarin/LocalyticsXamarin.Android/Properties/AssemblyInfo.cs.org LocalyticsXamarin/LocalyticsXamarin.Common/Properties/AssemblyInfo.cs.org LocalyticsXamarin/LocalyticsXamarin.NuGet/Localytics.NuGet.nuproj.org
	@cd LocalyticsXamarin/LocalyticsXamarin.NuGet && msbuild /t:Rebuild /p:Configuration=Release
	echo Publish LocalyticsXamarin/LocalyticsXamarin.NuGet/bin/Release/Localytics.$(VER).nupkg 
endif
