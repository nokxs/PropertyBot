# Immosuchmaschine.de Provider

This provider crawles the properties of from the website [Immosuchmaschine.de](https://www.immosuchmaschine.de).

## Configuration

The provider can be configured via `settings/providers/OhneMakler.yml`. The following values are available:

| Variable                                  | Description                                    |
|-------------------------------------------|------------------------------------------------|
| marketingType                             | See "Available Marketing Types". |
| objectType                                | See "Available Object Types. |
| location                                  | The ZIP or Name of the city to search arround it. |
| stateId                                   | See "Available State Ids". |
| radius                                    | The radius to search arround the given city.  |

## Available Object Types (as of 04.11.2020)

| Object Type | Description |
|------------|------|
| [empty] | All |
| BURO | Büro und Praxisräume |
| EHDL | Einzelhandel |
| GSTR | Gastronomie / Beherbergung |
| GEWF | Gewerbliche Freizeitimobilie |
| GRND | Grundstück |
| HAUS | Haus |
| LNDW | Land- / Forstwirtschaftliches Objekt |
| PROD | Produktions- / Lager- / Gewerbehalle |
| WHNG | Wohnung |
| ZIMM | Zimmer |
| ZNSR | Zinshaus oder Renditeobjekt |
| MWHN | Möbeliertes Wohnen / Wohnen auf Zeit |
| MISC | Garage, Stellplätze |

*These values are taken directly from the dropdown of the website.*

## Available Marketing Types (as of 04.11.2020)

| Marketing Type | Description |
|-----------|------|
| ALL | Alles |
| SELL | Kaufen |
| RENT | Mieten |

## Available State Ids (as of 04.11.2020)

| State Id | Description |
|-----------|------|
| [empty] | Undefined |
| 1  | Baden-Württemberg |
| 2 | Bayern |
| 3 | Berlin |
| 4 | Brandenburg |
| 5 | Bremen |
| 6 | Hamburg |
| 7 | Hessen |
| 8 | Mecklenburg-Vorpommern |
| 9 | Niedersachsen |
| 10 | Nordrhein-Westfalen |
| 11 | Rheinland-Pfalz |
| 12 | Saarland |
| 13 | Sachsen |
| 14 | Sachsen-Anhalt |
| 15 | Schleswig-Holstein |
| 16 | Thüringen |
