# KSK Data Provider

This provider crawles the [Kreissparkasse Böblingen](https://www.kskbb.de/de/home/privatkunden/immobilien/immobilienportal.html) for new properties. Every branch of the Kreissparkasse seems to use the same backend, so this 
provider should be able to crawl all properties of any Kreissparkasse. It also works with the [BW Bank](https://www.bw-bank.de/de/home/privatkunden/immobilien/immobilienangebote.html).

## Configuration

The provider can be configured with the following environment variables. See the provided docker-compose.yml for examples.


### PROVIDER_KSK_ZIPS

**Mandatory**

The Zips, which are used as base for an area search. Accepts multiple zips delmited by a comma. *Example: 71254,70763*


### PROVIDER_KSK_PERIMETERS_IN_KM

**Optional. Default: 15**

The radius which is searched arround the provided zip(s). Specify for every provided zip a perimiter radius of its own. The amount of provided perimeters has to match the amount of provided zips. *Example: 15,10*

Only the following values are allowed (any other will cause the KSK Server to respond with a 500 status code): 1, 2, 5, 10, 15, 25, 50

### PROVIDER_KSK_REGIO_CLIENT_ID

**Optional. Default: 60350130**

The id of the client. The default value is the ID of the Kreissparkasse Böblingen. Use the id `60050101` for the BW Bank.

Specify for every provided zip a regio client id. Example

| Example # | Zip | Perimeter | Regio Client Id |
|-----------|-----|-----------|-----------------|
| 1 | 71638 | 10 | 60350130 |
| 2 | 71638,71254 | 10,15 | 60350130,60050101 |

### PROVIDER_KSK_LIMIT

**Optional. Default: 9**

The number of properties, which are retrieved at once. A higher number makes the crawling faster. *Caution: A limit > 10 is very instable and the KSK Server resonds most of the time with a 500 status code.*

### PROVIDER_KSK_MARKETING_USAGE_OBJECT_TYPES

**Optional. Default: buy_residential_property,buy_residential_house**

The type of properties to look for. If any others are needed, the KSK Website needs to be debugged.
