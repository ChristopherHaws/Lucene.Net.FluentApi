# bootstrap DNVM into this session.
&{$Branch='dev';iex ((new-object net.webclient).DownloadString('https://raw.githubusercontent.com/aspnet/Home/dev/dnvminstall.ps1'))}

# load up the global.json so we can find the DNX version
$globalJson = Get-Content -Path $PSScriptRoot\global.json -Raw -ErrorAction Ignore | ConvertFrom-Json -ErrorAction Ignore

if($globalJson) {
    $dnxVersion = $globalJson.sdk.version
} else {
    Write-Warning "Unable to locate global.json to determine using 'latest'"
    $dnxVersion = "latest"
}

# install DNX
# only installs the default (x86, clr) runtime of the framework.
# If you need additional architectures or runtimes you should add additional calls
# ex: & $env:USERPROFILE\.dnx\bin\dnvm install $dnxVersion -r coreclr
& $env:USERPROFILE\.dnx\bin\dnvm install $dnxVersion -Persistent

 # run DNU restore on all project.json files in the src folder including 2>1 to redirect stderr to stdout for badly behaved tools
Get-ChildItem -Path $PSScriptRoot\src -Filter project.json -Recurse | ForEach-Object { & dnu restore $_.FullName 2>1 }

#$globalNugetPath = "$env:LocalAppData\NuGet"
#
#$globalNugetExists = Test-Path "$globalNugetPath\NuGet.exe"
#if(!$globalNugetExists) {
#	Write-Host "Downloading latest version of NuGet.exe..."
#
#	$globalNugetFolderExists = Test-Path $globalNugetPath
#	if(!$globalNugetFolderExists) {
#		New-Item -ItemType Directory -Path $globalNugetPath
#	}
#
#	$ProgressPreference = 'SilentlyContinue';
#	Invoke-WebRequest 'https://www.nuget.org/nuget.exe' -OutFile "$globalNugetPath\NuGet.exe"
#}
#
#$localNugetPath = ".NuGet"
#$nugetExists = Test-Path "$localNugetPath\NuGet.exe"
#if(!$nugetExists) {
#	$nugetFolderExists = Test-Path $localNugetPath
#	if(!$nugetFolderExists) {
#		New-Item -ItemType Directory -Path $localNugetPath
#	}
#
#	Copy-Item "$globalNugetPath\NuGet.exe" "$localNugetPath"
#}
#
#.nuget\NuGet.exe restore