# load up the global.json so we can find the DNX version
$globalJson = Get-Content -Path $PSScriptRoot\global.json -Raw -ErrorAction Ignore | ConvertFrom-Json -ErrorAction Ignore

if($globalJson) {
    $dnxVersion = $globalJson.sdk.version
} else {
    Write-Warning "Unable to locate global.json to determine using '1.0.0-beta5'"
    $dnxVersion = "1.0.0-beta5"
}

& $env:USERPROFILE\.dnx\bin\dnvm exec $dnxVersion dnx .\test\Lucene.Net.FluentApi.Tests\ test
