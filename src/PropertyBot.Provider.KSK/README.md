# KSK Data Provider

This provider crawles the [Kreissparkasse Böblingen](https://www.kskbb.de/de/home/privatkunden/immobilien/immobilienportal.html) for new properties. Every branch of the Kreissparkasse seems to use the same backend, so this 
provider should be able to crawl all properties of any Kreissparkasse. It also works with the [BW Bank](https://www.bw-bank.de/de/home/privatkunden/immobilien/immobilienangebote.html).

## Configuration

The provider can be configured via `settings/providers/KSK.yml`. The following values are available:

| Variable                                  | Description                                    |
|-------------------------------------------|------------------------------------------------|
| limit                                     | The number of properties, which are retrieved at once. A higher number makes the crawling faster. *Caution: A limit > 10 is very instable and the KSK Server resonds most of the time with a 500 status code.* |
| marketingUsageObjectType                  | The type of properties to look for |
| radiusInKm                                | he radius which is searched arround the provided zip |
| regioClientId                             | The id of the client bank |
| zip                                       | Thi ZIP which is used as center of the radius search |

The provider can be configured with the following environment variables. See the provided docker-compose.yml for examples.


### Regio Client IDs

| Client ID | Bank |
|-----------|------|
| 60350130  | KSK Böblingen |
| 60050101  | BW Bank |

### Marketing Usage Object Types

Known types:

* buy_residential_property
* buy_residential_house

**If any others are needed, the KSK Website needs to be debugged.**
