# Change the folder directory to the correct one after a git pull
$projectDirA = "R:/github.com/te3que/BasicInventorySystem/InventoryAPI"
$projectNameA = "InventoryAPI.csproj"
# If there are a need for more projects just do as what have been done here
$projectDirB = "R:/github.com/te3que/BasicInventorySystem/InventoryApp"
$projectNameB = "InventoryApp.csproj"

# Start a new instance of PowerShell and run the first project
Start-Process powershell.exe "-NoExit -Command Set-Location $projectDirA; dotnet run --project $projectNameA"

# Wait for a few seconds to allow the first project to start up
Start-Sleep -Seconds 5

# Start another new instance of PowerShell and run the second project
Start-Process powershell.exe "-NoExit -Command Set-Location $projectDirB; dotnet run --project $projectNameB"
