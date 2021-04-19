#!/usr/bin/env bash

BUILD_FOLDER_PATH="$1"

shopt -s extglob
mkdir "$BUILD_FOLDER_PATH"
cd "$BUILD_FOLDER_PATH" || exit
dotnet new sln -n LaboratoryWork
dotnet new console -n Project
dotnet sln LaboratoryWork.sln add Project/Project.csproj
cp ../!(assembly).cs Project/
mkdir Project/Extensions Project/Utils
cp ../Extensions/*.cs Project/Extensions/
cp ../Utils/*.cs Project/Utils/
rm -f Project/Program.cs
dotnet build LaboratoryWork.sln
