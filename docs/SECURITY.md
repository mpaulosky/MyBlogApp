# Security Policy

## Supported Versions

The following versions of MyBlogApp are supported with security updates:

| Version | Supported          |
|---------|--------------------|
| 0.1.x   | :white_check_mark: |

## Reporting a Vulnerability

To report a security vulnerability, please email [security@myblogapp.com](mailto:security@myblogapp.com) or open a private issue on GitHub.  
You will receive a response within 48 hours.  
If the vulnerability is accepted, we will coordinate a fix and disclosure timeline with you.  
If declined, we will provide a clear explanation.

## Security Practices

This repository enforces the following security requirements:

- HTTPS is required for all environments.
- Authentication and authorization are mandatory (see `README.md` and `Web/Program.cs`).
- Antiforgery tokens, CORS, and secure headers are enabled by default.
- All dependencies are regularly scanned for vulnerabilities.

For more details, see [CONTRIBUTING.md](../docs/CONTRIBUTING.md).