echo " "
echo "dotnet clean ./PianoTilesRedux.Desktop.slnf"
echo " "

dotnet clean ./PianoTilesRedux.Desktop.slnf

echo " "
echo "dotnet restore ./PianoTilesRedux.Desktop.slnf"
echo " "

dotnet restore ./PianoTilesRedux.Desktop.slnf

echo " "
echo "dotnet build --no-incremental -warnaserror /p:UseSharedCompilation=false /p:Configuration=Debug ./PianoTilesRedux.Desktop.slnf"
echo " "

dotnet build --no-incremental -warnaserror /p:UseSharedCompilation=false /p:Configuration=Debug ./PianoTilesRedux.Desktop.slnf

echo " "