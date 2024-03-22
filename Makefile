.phony: build run test

build:
	@echo "Building the project..."
	@dotnet run --project WebApi

run: build
	@echo "Running the project..."
	@dotnet run --project WebApi

test:
	@echo "Running the tests for application..."
	@dotnet run --project Application.Tests
