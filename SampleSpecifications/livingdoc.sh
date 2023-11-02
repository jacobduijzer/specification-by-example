#!/usr/bin/env bash

dotnet tool update --global SpecFlow.Plus.LivingDoc.CLI

dotnet clean && dotnet restore &&  dotnet build --no-restore && dotnet test --no-build

~/.dotnet/tools/livingdoc \
  feature-folder specs/SampleSpecification.Specs \
  -t /home/jacob/Projects/github/specification-by-example/SampleSpecifications/specs/SampleSpecification.Specs/bin/Debug/net7.0/TestExecution.json \
  --output livingdoc.html

  #--binding-assemblies specs/SampleSpecification.Specs/bin/Debug/net7.0/SampleSpecification.Specs.dll \

echo "Generated the report 'livingdoc.html'."
