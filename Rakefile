require "rake/clean"

CLEAN.include "*.xam"
CLEAN.include "xamarin-component"

COMPONENT = "localytics-sdk-4.2.0.xam"

file "xamarin-component/xamarin-component.exe" do
	puts "* Downloading xamarin-component..."
	mkdir "xamarin-component"
	sh "curl -L https://components.xamarin.com/submit/xpkg > xamarin-component.zip"
	sh "unzip -o -q xamarin-component.zip -d xamarin-component"
	sh "rm xamarin-component.zip"
end

task :default => "xamarin-component/xamarin-component.exe" do
	line = <<-END
	mono xamarin-component/xamarin-component.exe create-manually #{COMPONENT} \
		--name="Localytics SDK" \
		--summary="The leading analytics and marketing platform for mobile and web apps." \
		--publisher="Localytics" \
		--website="http://www.localytics.com/" \
		--details="component/Details.md" \
		--license="component/License.md" \
		--getting-started="component/GettingStarted.md" \
		--icon="component/localytics-sdk_128x128.png" \
		--icon="component/localytics-sdk_512x512.png" \
		--library="ios-unified":"LocalyticsXamarin/LocalyticsXamarin.iOS/bin/Release/LocalyticsXamarin.iOS.dll" \
		--library="ios":"LocalyticsXamarin/LocalyticsXamarin.iOS-Classic/bin/Release/LocalyticsXamarin.iOS-Classic.dll" \
		--library="android":"LocalyticsXamarin/LocalyticsXamarin.Android/bin/Release/LocalyticsXamarin.Android.dll" \
		--sample="LocalyticsXamarin. Samples for iOS, Android & Forms.":"LocalyticsXamarin/LocalyticsXamarin.sln"
		END
	puts "* Creating #{COMPONENT}..."
	puts line.strip.gsub "\t\t", "\\\n    "
	sh line, :verbose => false
	puts "* Created #{COMPONENT}"
end
