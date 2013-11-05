

JAVA_LT_180 := $(shell expr `javac -version 2>&1 | sed -Ee 's/^.{6}//' -Ee 's/([0-9]{1,2})/\1/g' -Ee 's/\.([0-9]{1,2})/\1/' -Ee 's/\.([0-9]{1,2})/\1/' -Ee 's/_[0-9]*//'` \< 180)

all :
ifeq ($(JAVA_LT_180), 1)
	cd LocalyticsXamarin/LocalyticsXamarin.iOS && make
	cd LocalyticsXamarin/LocalyticsXamarin.iOS-Classic && make
	cd LocalyticsXamarin/LocalyticsXamarin.Android && make
else
		@echo "Current Java version greater then 1.7. Can't make"
endif

clean :
	cd LocalyticsXamarin/LocalyticsXamarin.iOS && make clean
	cd LocalyticsXamarin/LocalyticsXamarin.iOS-Classic && make clean
	cd LocalyticsXamarin/LocalyticsXamarin.Android && make clean
	rm -rf LocalyticsXamarin/*/bin LocalyticsXamarin/*/obj
