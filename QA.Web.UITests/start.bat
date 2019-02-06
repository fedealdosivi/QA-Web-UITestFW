taskkill /im bash.exe /f
Start /B java -jar "C:\dev\QA-Web-UITests-Making\QA-Web-UITestFW\QA.Web.UITests\bin\Debug\selenium-server-standalone-3.9.1.jar"
cmd "C:\ProgramData\chocolatey\lib\nunit-console-runner\tools\nunit3-console.exe" QA.Web.UITests/bin/Debug/QA.Web.UITests.dll