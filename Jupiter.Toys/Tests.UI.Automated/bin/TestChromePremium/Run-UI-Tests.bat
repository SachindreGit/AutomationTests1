@echo off

echo Executing Tests

"../../../packages/NUnit.ConsoleRunner.3.15.0/tools/nunit3-console.exe" --labels="Before" --out="TestResult.txt" --result="TestResult.xml;format=nunit2" "Tests.UI.Automated.dll" --dispose-runners

TIMEOUT 10

echo generating reports   
 
"../../../packages/SpecFlow.2.4.1/tools/specflow.exe" nunitexecutionreport --ProjectFile "../../Tests.UI.Automated.csproj" --xmlTestResult "TestResult.xml" --OutputFile "result.html"


echo Returning success result
exit 0