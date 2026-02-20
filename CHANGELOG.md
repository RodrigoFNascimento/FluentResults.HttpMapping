# Changelog

All notable changes to this project will be documented in this file.

The format is based on [Keep a Changelog](https://keepachangelog.com/en/1.1.0/),
and this project adheres to Semantic Versioning.

## [2.0.0] – 2026-02-20

### Changed
- Moved helper methods for defining rules based on the state of the `Result` from the context to it's `Result`.
- Replaced error-based with reason-based rule definition.

## [1.0.0] – 2026-02-01

### Added
- Declarative, rule-based HTTP mapping for FluentResults `Result` and `Result<T>`
- First-match-wins rule ordering
- Native support for RFC 7807 Problem Details responses
- Header mapping without polluting endpoints
- Support for both Minimal APIs and MVC controllers
- Dependency-injection–based configuration model

### Stability
- Initial stable public release
