

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
