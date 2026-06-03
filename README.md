# Trading Analytics Lab

Transforming raw trading data into actionable insights through performance analytics, behavioral intelligence, and data-driven decision making.

---

## Overview

Trading Analytics Lab is a backend platform designed to help day traders analyze operational performance through structured trading data, performance metrics, and behavioral insights.

The project applies modern software architecture practices to build a scalable and maintainable analytics platform capable of evolving into an intelligent decision-support system.

---

## Business Goals

The platform aims to answer questions such as:

- Which setups generate the highest profitability?
- What trading hours produce the best results?
- Which patterns lead to recurring losses?
- How does trader behavior affect performance?
- Which habits separate profitable traders from losing traders?

---

## Target Audience

Day traders operating:

- WIN (Mini Index)
- WDO (Mini Dollar)

Trading styles:

- Price Action
- Breakout
- Pullback
- VWAP
- Trend Following
- Scalping

---

# Architecture

The project follows enterprise-grade architectural patterns:

- Clean Architecture
- Domain-Driven Design (DDD)
- CQRS
- Repository Pattern
- Unit of Work
- SOLID Principles
- Separation of Concerns

---

## Solution Structure

```text
src
├── TradingAnalyticsLab.Api
├── TradingAnalyticsLab.Application
├── TradingAnalyticsLab.Domain
└── TradingAnalyticsLab.Infrastructure

tests
├── TradingAnalyticsLab.UnitTests
└── TradingAnalyticsLab.IntegrationTests
```

---

## Domain Model

Core domain entities:

- Trader
- TradingAccount
- TradingSession
- Trade
- TradingSetup
- JournalEntry

Entity relationships:

```text
Trader
 └── TradingAccount
      └── TradingSession
           ├── Trade
           └── JournalEntry

Trade
 └── TradingSetup
```

---

# Technology Stack

Backend:

- .NET 8
- ASP.NET Core Web API
- MediatR
- Entity Framework Core

Database:

- PostgreSQL

Architecture:

- Clean Architecture
- CQRS
- DDD

Testing:

- xUnit
- Moq

Infrastructure:

- Docker
- Docker Compose

Documentation:

- Swagger / OpenAPI

---

# Current Features

## Traders

Implemented:

- Create Trader
- Get Trader By Id
- Get All Traders
- Update Trader
- Delete Trader

## Trading Accounts

Implemented:

- Create Trading Account
- Get Trading Account By Id
- Get All Trading Accounts

---

# Database

Database management is performed through:

- Entity Framework Core Migrations
- PostgreSQL
- Docker Containers

Current entities:

- traders
- trading_accounts
- trading_sessions
- trades
- trading_setups
- journal_entries

---

# Development Environment

Requirements:

- .NET 8 SDK
- Docker Desktop
- PostgreSQL (via Docker)

Run database:

```bash
docker compose up -d
```

Apply migrations:

```bash
dotnet ef database update \
--project src/TradingAnalyticsLab.Infrastructure \
--startup-project src/TradingAnalyticsLab.Api
```

Run API:

```bash
dotnet run --project src/TradingAnalyticsLab.Api
```

Swagger:

```text
https://localhost:xxxx/swagger
```

---

# Roadmap

## Phase 1 – Core Platform

- Domain Modeling
- CQRS Foundation
- PostgreSQL Integration
- REST API
- Swagger Documentation

## Phase 2 – Trading Analytics

- Trade Import
- Performance Metrics
- Setup Analytics
- Time Analytics

## Phase 3 – Behavioral Intelligence

- Trading Journal Analysis
- Behavioral Metrics
- Pattern Detection

## Phase 4 – AI Layer

- AI Trading Coach
- Performance Recommendations
- Behavioral Insights
- Predictive Analytics

---

# Project Status

Version: v0.1.0

Status: Active Development

Current Focus:

- Trading Session Aggregate
- Trade Aggregate
- Analytics Foundation

---

# Author

Ricardo Lamb

Backend Engineer | Solution Architect | Cloud Engineer

GitHub:
https://github.com/RicardoLamb
