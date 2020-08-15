# Immopool.de Volksbank Data Provider

This provider crawles the properties of different Volksbank branches, which use (immopool.de)[https://www.immopool.de] as backend. At least the following branches are supported

* [Volksbank Stuttgart](https://www.volksbank-stuttgart.de/immobilien/immobilienangebote/regionale-immobilienangebote.html)
* [Volksbank Ludwigsburg](https://www.volksbank-ludwigsburg.de/immobilien/immobilien-finden/immobilien-finden.html)

## Configuration

The provider can be configured with the following environment variables. See the provided docker-compose.yml for examples.

| Environment Variable                      | Description                                    | Mandatory | Default   |
|-------------------------------------------|------------------------------------------------|-----------|-----------| 
| PROVIDER_VBANK_STUTTGART_GEOSL            | The GeoSL of the city to use. Separate multiple GeoSLs with a "," | no | 004008001019000093 |
| PROVIDER_VBANK_STUTTGART_PERIMETERS_IN_KM | The radius in km arround the provided GeoSL    | no        | 10        |
| PROVIDER_VBANK_STUTTGART_OBJECT_CATEGORY  | The object category. Must be an int            | no        | 1 (House) |
| PROVIDER_VBANK_STUTTGART_CUSTOMER_ID      | The customer id for immopool.de                | no        | 144298    |
| PROVIDER_VBANK_STUTTGART_LIMIT            | The number of properties to load 			     | no        | 100       |

## Available GeoSLs

| Customer Id | GeoSL | City | Volksbank Branch |
|-------------|-------|------|------------------|
| 144298 | 004008001019000008 | Backnang | Volksbank Stuttgart |
| 144298 | 004008001019000093 | Kernen im Remstal | Volksbank Stuttgart |
| 144298 | 004008001016000058 | Reichenbach an der Fils | Volksbank Stuttgart |
| 144298 | 004008001011000000 | Stuttgart (70173) | Volksbank Stuttgart |
| 144298 | 004008001019000085 | Winnenden | Volksbank Stuttgart |
| 144298 | 004008001019000086 | Winterbach (73650) | Volksbank Stuttgart |
| 33371  | 004008001018000079 | Bietigheim-Bissingen | Volksbank Ludwigsburg |
| 33371  | 004008001018000070 | Steinheim an der Murr | Volksbank Ludwigsburg |

Use curl to fetch the current list for Volksbank Stuttgart:

```
curl 'https://cs.immopool.de/CS/getOrt' -H 'User-Agent: Mozilla/5.0 (Windows NT 10.0; Win64; x64; rv:79.0) Gecko/20100101 Firefox/79.0' -H 'Accept: */*' -H 'Accept-Language: de,en-US;q=0.7,en;q=0.3' --compressed -H 'Content-Type: application/x-www-form-urlencoded; charset=utf-8' -H 'Origin: https://cs.immopool.de' -H 'Connection: keep-alive' -H 'Referer: https://cs.immopool.de/Iframe/144298/1' -H 'TE: Trailers' --data-raw 'kdnr=144298&objkat=1&firmaVerkn=0&zweitAnbieter=0&zweitGenerell=0&boerseMakler=0&vermarktung=0'
```

Change the field *kdnr* (use the customer id from the table above) in *data-raw* to fetch locations for different branches.