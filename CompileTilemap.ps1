$compilerExePath = Join-Path $PSScriptRoot '\TilemapCompiler\bin\Release\net6.0\publish\TilemapCompiler.exe'
$solutionPath = Join-Path $PSScriptRoot  "\TilemapCompiler\TilemapCompiler.sln"
$tilemapDetails = Join-Path $PSScriptRoot "\TilemapDetails.json"
$tileDirectories = @("Custom", "Original")

if (-Not(Test-Path $compilerExePath)){
	dotnet publish $solutionPath -c Release
}

foreach ($tileDirectory in $tileDirectories) {
	$fullTileDirectoryPath = Join-Path $PSScriptRoot $tileDirectory 
	$outputPath = Join-Path $PSScriptRoot $tileDirectory
	& $compilerExePath $fullTileDirectoryPath $tilemapDetails $outputPath".png"
}