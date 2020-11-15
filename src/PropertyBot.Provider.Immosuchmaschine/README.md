# Immosuchmaschine.de Provider

This provider crawles the properties of from the website [Immosuchmaschine.de](https://www.immosuchmaschine.de).

## Configuration

The provider can be configured via `settings/providers/OhneMakler.yml`. The following values are available:

| Variable                                  | Description                                    |
|-------------------------------------------|------------------------------------------------|
| provinceIds                               | See "Available Province Ids". |
| districtIds                               | See "Available District Ids". |
| muncipalIds                               | See "Available Muncipal Ids". |
| type                                      | See "Available Types". |
| priceFrom                                 | The minimum price.  |
| priceTo                                   | The maximum price.  |
| sizeFrom                                  | The minimum area.  |
| sizeTo                                    | The maximum area.  |

## Available Province Ids (as of 15.11.2020)

Multiple provinces can be search at once.

| Province Id Id | Description |
|----------------|-------------|
| 8  | Baden-Württemberg |
| 9  | Bayern  |
| 11 | Berlin |
| 12 | Brandenburg |
| 4  | Bremen  |
| 2  | Hamburg |
| 6  | Hessen |
| 13 | Mecklenburg-Vorpommern |
| 3  | Niedersachsen |
| 5  | Nordrhein-Westfalen |
| 7  | Rheinland-Pfalz |
| 10 | Saarland |
| 14 | Sachsen |
| 15 | Sachsen-Anhalt |
| 1  | Schleswig-Holstein |
| 14 | Sachsen |
| 16 | Thüringen |

## Available District Ids (as of 15.11.2020)

Multiple disticts can be search at once.

| District Id   | Description |
|---------------|-------------|
| district_8115 | Böblingen |
| district_8235 | Calw |
| district_8116 | Esslingen |
| district_8125 | Heilbronn, Landkreis |
| district_8118 | Ludwigsburg |
| district_8111 | Stuttgart |

*This list is not complete. More values can be retrieved form the website. Tip: Inspect the filter dropdown.*

## Available Muncipal Ids (as of 15.11.2020)

Multiple muncipals can be search at once.

| Muncipal Id  | Description |
|--------------|-------------|
| muni_8118001 | Affalterbach |
| muni_8118003 | Asperg |
| muni_8118006 | Benningen am Neckar |
| muni_8118007 | Besigheim |
| muni_8118079 | Bietigheim-Bissingen |
| muni_8118010 | Bönnigheim |
| muni_8118011 | Ditzingen |
| muni_8118012 | Eberdingen |
| muni_8118014 | Erdmannhausen |
| muni_8118015 | Erligheim |
| muni_8118078 | Freiberg am Neckar |
| muni_8118016 | Freudental |
| muni_8118018 | Gemmrigheim |
| muni_8118019 | Gerlingen |
| muni_8118021 | Großbottwar |
| muni_8118027 | Hemmingen |
| muni_8118028 | Hessigheim |
| muni_8118077 | Ingersheim |
| muni_8118040 | Kirchheim am Neckar |
| muni_8118080 | Korntal-Münchingen |
| muni_8118046 | Kornwestheim |
| muni_8118047 | Löchgau |
| muni_8118048 | Ludwigsburg |
| muni_8118049 | Marbach am Neckar |
| muni_8118050 | Markgröningen |
| muni_8118051 | Möglingen |
| muni_8118053 | Mundelsheim |
| muni_8118054 | Murr |
| muni_8118059 | Oberriexingen |
| muni_8118060 | Oberstenfeld |
| muni_8118063 | Pleidelsheim |
| muni_8118081 | Remseck am Neckar |
| muni_8118076 | Sachsenheim |
| muni_8118067 | Schwieberdingen |
| muni_8118068 | Sersheim |
| muni_8118070 | Steinheim an der Murr |
| muni_8118071 | Tamm |
| muni_8118073 | Vaihingen an der Enz |
| muni_8118074 | Walheim|

*This list is not complete. It contains only the muncipals of Ludwigsburg. Retrieve the values for any other munciapl from the website. Tip: Inspect the filter dropdown*

## Available Types (as of 15.11.2020)

### Buy

| Type         | Description |
|--------------|-------------|
| 1_1 | Eigentumswohnungen |
| 2_1 | Häuser kaufen |
| 3_1 | Grundstücke |
| 5_1 | Gewerbeimmobilien kaufen |
| 6_1 | Anlageobjekte |
| 7_1 | Sonstige Immobilien |

### Rent

| Type         | Description |
|--------------|-------------|
| 1_2 | Mietwohnungen |
| 2_2 | Häuser mieten |
| 4_2 | WG-Zimmer |
| 5_2 | Gewerbeimmobilien mieten |
| 5_2_3 | Büros |
| 5_2_4 | Geschäftslokale |
| 5_2_4 | Gastronomiebetriebe |
| 7_2 | Sonstige Immobilien mieten |
