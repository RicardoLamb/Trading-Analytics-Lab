# ADR-004 - Use UUID Primary Keys

## Status

Accepted

## Context

The platform may evolve into a distributed architecture and eventually support multiple tenants.

## Decision

UUID will be used as the primary key strategy.

## Consequences

### Positive

- Globally unique identifiers
- Better support for distributed systems
- Safer public exposure

### Negative

- Larger storage footprint
- Less human-readable than numeric IDs
