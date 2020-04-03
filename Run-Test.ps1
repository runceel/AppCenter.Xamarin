appcenter test run uitest --app "KaotaDemo/AndroidApp" `
	--devices "KaotaDemo/default-device-set" `
	--app-path "./AppCenter.Xamarin/AppCenter.Xamarin.Android/bin/UITest/jp.okazuki.appcenter.xamarin-Signed.apk" `
	--test-series "master" `
	--locale "ja_JP" `
	--build-dir "./AppCenter.Xamarin.UITest/bin/UITest" `
	--uitest-tools-dir "$($env:HOMEDRIVE)$($env:HOMEPATH)\.nuget\packages\Xamarin.UITest\3.0.3\Tools"
