# KSK Data Provider

This provider crawles [Volksbank Stuttgart](https://www.volksbank-stuttgart.de/immobilien/immobilienangebote/regionale-immobilienangebote.html) for new properties.

## Configuration

The provider can be configured with the following environment variables. See the provided docker-compose.yml for examples.

| Environment Variable                      | Description                                    | Mandatory | Default   |
|-------------------------------------------|------------------------------------------------|-----------|-----------| 
| PROVIDER_VBANK_STUTTGART_GEOSL            | The GeoSL of the city to use. Separate multiple GeoSLs with a "," | no        | 600       |
| PROVIDER_VBANK_STUTTGART_PERIMETERS_IN_KM | The radius in km arround the provided GeoSL    | no        | 10        |
| PROVIDER_VBANK_STUTTGART_OBJECT_CATEGORY  | The object category. Must be an int            | no        | 1 (House) |
| PROVIDER_VBANK_STUTTGART_CUSTOMER_ID      | The customer id for immopool.de                | no        | 144298    |
| PROVIDER_VBANK_STUTTGART_LIMIT            | The number of properties to load 			     | no        | 100       |

## Available GeoSL

All available GeoSLs can be found [here](https://cs.immopool.de/CS/getOrt).

| GeoSL | City |
|-------|------|
| 004008001019000008 | Backnang |
| 004008001019000093 | Kernen im Remstal |
| 004008001016000058 | Reichenbach an der Fils |
| 004008001011000000 | Stuttgart (70173) |
| 004008001019000085 | Winnenden |
| 004008001019000086 | Winterbach (73650) |