<#
 
 creates SQLAgain.zip using necessary files from the Release Directory
 
 Copy the new File at the end into a Visual Studio Session, mark "replace"


#>
pushd  C:\Users\Martin\source\repos\SQLAgain\bin\Release
$zipFile="C:\temp\SQLAgain\SQLAgain.zip"
gci -File | Where-Object  { $_.Name -notmatch ".pdb" -and $_.Name -notmatch ".xml"} | Compress-Archive -DestinationPath $zipFile -Force
"This is my .zip File:"
gci $zipFile

"`n`nCopy this File into Visual Studio / Solution Explorer / Update Directory"
explorer $(Split-Path -Path $zipFile)