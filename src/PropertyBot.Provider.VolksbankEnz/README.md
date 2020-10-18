# Volksbank Enz Provider

This provider crawles the properties of from [Volksbank Neckar-Enz](https://www.vorne.de/immobilien/immobilien-finden.html).

## Configuration

The provider can be configured with the following environment variables. See the provided docker-compose.yml for examples.

| Environment Variable                      | Description                                    | Mandatory | Default   |
|-------------------------------------------|------------------------------------------------|-----------|-----------| 
| PROVIDER_VBANK_STUTTGART_GEOSL            | The GeoSL of the city to use. Separate multiple GeoSLs with a "," | no | 004008001019000093 |
| PROVIDER_VBANK_STUTTGART_PERIMETERS_IN_KM | The radius in km arround the provided GeoSL    | no        | 10        |
| PROVIDER_VBANK_STUTTGART_OBJECT_CATEGORY  | The object category. Must be an int            | no        | 1 (House) |
| PROVIDER_VBANK_STUTTGART_CUSTOMER_ID      | The customer id for immopool.de                | no        | 144298    |
| PROVIDER_VBANK_STUTTGART_LIMIT            | The number of properties to load 			     | no        | 100       |
