Write-Output " "
Write-Output "dotnet clean ./PianoTilesRedux.Desktop.slnf"
Write-Output " "

dotnet clean ./PianoTilesRedux.Desktop.slnf

Write-Output " "
Write-Output "dotnet restore ./PianoTilesRedux.Desktop.slnf"
Write-Output " "

dotnet restore ./PianoTilesRedux.Desktop.slnf

Write-Output " "
Write-Output "dotnet build --no-incremental -warnaserror /p:UseSharedCompilation=false /p:Configuration=Debug ./PianoTilesRedux.Desktop.slnf"
Write-Output " "

dotnet build --no-incremental -warnaserror /p:UseSharedCompilation=false /p:Configuration=Debug ./PianoTilesRedux.Desktop.slnf

Write-Output " "