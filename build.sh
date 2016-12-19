#!/bin/bash
set -ev
dotnet restore
dotnet test ShopService/ShopService.Tests
dotnet build -c Release