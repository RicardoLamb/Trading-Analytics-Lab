# ADR-003 - Use CQRS

## Status

Accepted

## Context

The platform contains two distinct workloads:

- Data ingestion
- Analytics and reporting

These workloads have different evolution paths.

## Decision

Command Query Responsibility Segregation (CQRS) will be adopted.

## Consequences

### Positive

- Better separation between reads and writes
- Improved maintainability
- Supports future scalability

### Negative

- Additional abstraction
- Increased learning curve
