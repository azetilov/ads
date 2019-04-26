# Advertisement API

## Introduction

Start off with exercising the API root endpoint:

http://localhost:5000/api/v1/

Alternatively, API provides Swagger documentation and explorer at:

http://localhost:5000/swagger/index.html


OpenAPI/Swagger specification is available at:

http://localhost:5000/swagger/v1/swagger.json


## API guidelines

### Hypermedia

This API uses JSON Hypertext Application Language (HAL) media type for representing resources and their relations.

Response structure:

Headers:
`Content-Type: application/hal+json; charset=utf-8`

Body:
```
{
    _links: // ...
    _embedded: //...
}
```

Where `_links` include references to related resources and `self`.
`_embedded` includes expanded links and results arrays.

More details:

https://tools.ietf.org/html/draft-kelly-json-hal-08

### API design

This API follows [Microsoft REST API guidelines](https://github.com/Microsoft/api-guidelines)

### Versioning

API follows [Microsoft REST API Versioning Guidelines](https://github.com/Microsoft/api-guidelines/blob/master/Guidelines.md#12-versioning). Specifically, MAJOR version exposed via URL path. See [Versioning via the URL Path](https://github.com/Microsoft/aspnet-api-versioning/wiki/Versioning-via-the-URL-Path)

API follows [Semantic Versioning](https://semver.org/) in which every breaking change MUST increment MAJOR version of the API.

For full REST compliance [Media-type versioning](https://github.com/Microsoft/aspnet-api-versioning/wiki/API-Version-Reader#media-type-api-version-reader) SHOULD be used (out of scope).


## Assumptions and Considerations

1. API is responsible for advertisement management (CRUD) only - ads/channels processing and execution is out of scope
1. In-memory storage will be used for proof-of-concept solution. Real-life solution would require actual database
1. Repository and UnitOfWork patterns can be used at later stages
1. Async-await usage on backend not justified for this prototype
