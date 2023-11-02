#!/usr/bin/env bash

dotnet tool update --global SpecFlow.Plus.LivingDoc.CLI

dotnet test

~/.dotnet/tools/livingdoc \
  feature-folder SpecFlowRemoteTesting \
  -t SpecFlowRemoteTesting/bin/Debug/net7.0/TestExecution.json \
  --binding-assemblies SpecFlowRemoteTesting/bin/Debug/net7.0/SpecFlowRemoteTesting.dll \
  --output livingdoc.html

echo "Generated the report 'livingdoc.html'."
