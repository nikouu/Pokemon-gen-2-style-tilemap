$compilerExePath = Join-Path $PSScriptRoot '\TilemapCompiler\bin\Debug\net6.0\TilemapCompiler.exe'
$solutionPath = Join-Path $PSScriptRoot  "\TilemapCompiler\TilemapCompiler.sln"
$tilemapDetails = Join-Path $PSScriptRoot "\TilemapDetails.json"
$readmePath = Join-Path $PSScriptRoot "\README.md"
$tileDirectories = @("Custom", "Original")

dotnet build $solutionPath -c Debug

foreach ($tileDirectory in $tileDirectories) {
	$fullTileDirectoryPath = Join-Path $PSScriptRoot $tileDirectory 
	$outputPath = Join-Path $PSScriptRoot $tileDirectory
	& $compilerExePath $fullTileDirectoryPath $tilemapDetails $outputPath".png" $readmePath
	& $compilerExePath $fullTileDirectoryPath $tilemapDetails $outputPath"_gb.png" $readmePath
}