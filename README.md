# Assumptions and Considerations

1. API is responsible for advertisement management (CRUD) only - ads/channels processing and execution is out of scope
1. In-memory storage will be used for proof-of-concept solution. Real-life solution would require actual database
1. Repository and UnitOfWork patterns can be used at later stages
1. Versioning approach - Versioning via URL path. See [Microsoft REST API Guidelines](https://github.com/Microsoft/api-guidelines/blob/master/Guidelines.md#12-versioning) and https://github.com/Microsoft/aspnet-api-versioning/wiki/Versioning-via-the-URL-Path
1. For full REST compliance use [Media-type versioning](https://github.com/Microsoft/aspnet-api-versioning/wiki/API-Version-Reader#media-type-api-version-reader)
