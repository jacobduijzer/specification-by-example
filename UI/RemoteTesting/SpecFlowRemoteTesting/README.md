# Remote testing with SpecFlow, Selenium, PageObjects

## How to build

```bash
docker build . -t jacobsapps/seleniumdotnet --no-cache
```

## How to run

```bash
docker run  -it \
  -v /home/jacob/Projects/github/specification-by-example/UI/RemoteTesting/SpecFlowRemoteTesting/:/application \
  jacobsapps/seleniumdotnet \
  /bin/bash
  
cd /application
./livingdoc.sh
```

## Possible Errors

1. "This version of ChromeDriver only supports Chrome version xxx"
Solution: Inside the container, check the chrome version. Use that version number to set the version number of the chrome driver

Getting the version number of the installed Chrome:
```bash

```

2. The chromedriver file does not exist in the current directory or in a directory on the PATH environment variable.
Solution: Add the path to the PATH variable: export PATH = "/opt/selenium/
