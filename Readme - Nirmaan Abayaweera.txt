1. Technologies used: .Net Framework 4.7, NUnit 3, Selenium 4.2, SpecFlow 2.4

2. When the project is setup to build in CI/CD server (ex: TeamCity), needs to set 'TestChromePremium' as configuration.

3. After the project is built, 'Run-UI-Tests.bat' file is moved to bin folder (ex: Tests.UI.Automated\bin\TestChromePremiumRun-UI-Tests.bat)
and it can be set to execute on CI/CD server to execute automated tests.
After execution 'result.html' is created by SpecFlow in same folder path, which shows test results in more readable format.