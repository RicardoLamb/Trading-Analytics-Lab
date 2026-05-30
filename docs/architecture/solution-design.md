# Solution Design

## Architecture Style

Clean Architecture

## Projects

- TradingAnalyticsLab.Api
- TradingAnalyticsLab.Application
- TradingAnalyticsLab.Domain
- TradingAnalyticsLab.Infrastructure

## Test Projects

- TradingAnalyticsLab.UnitTests
- TradingAnalyticsLab.IntegrationTests

## Dependency Rules

Api -> Application

Infrastructure -> Application

Application -> Domain

Domain -> none
