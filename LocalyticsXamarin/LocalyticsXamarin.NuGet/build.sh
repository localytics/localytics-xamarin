make -C ../.. clean
msbuild /t:Rebuild /p:Configuration=Release
cp ./bin/Release/Localytics.5.1.2.nupkg ~/nuget/

