# Wunschimmo.de Data Provider

This provider crawles [wunschimmo.de](https://www.wunschimmo.de).mobilien/immobilien-finden/immobilien-finden.html)

## Configuration

The provider can be configured with the following environment variables. See the provided docker-compose.yml for examples.

| Environment Variable                      | Description                                    | Mandatory | Default   |
|-------------------------------------------|------------------------------------------------|-----------|-----------| 
| PROVIDER_WUNSCHIMMO_REGIONS               | The region to use. Take the value from the website | no | baden-wuerttemberg,stuttgart,stuttgart |
| PROVIDER_WUNSCHIMMO_PERIMETERS_IN_KM      | The radius in km arround the provided region   | no        | 20        |
| PROVIDER_WUNSCHIMMO_OBJECT_TYPES          | The object type                                | no        | haus-kaufen |
