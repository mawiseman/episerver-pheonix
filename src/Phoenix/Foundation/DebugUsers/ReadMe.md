# DebugUsers

## Introduction

When the application is running in Debug mode this feature will ensure that we have the following accounts avalaible

| User | Password | Roles |
|-|-|-|
|Admin|Grover68!|XX|


## Usage

For this to work we need to ensure that the membership provider is set to `SqlServerMembershipProvider`

This can be done by updating te `web.config` file

```
<configuration>
  <system.web>
    <membership defaultProvider="SqlServerMembershipProvider" ... />
    <roleManager defaultProvider="SqlServerRoleProvider" ... />
</configuration>
```