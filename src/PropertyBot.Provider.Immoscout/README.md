# Immobilienscout24 Provider

This provider crawles the properties from the normal search of [immobilienscout24](https://immobilienscout24.de). It is not as reliable as other providers, because Immoscout 
is trying to detect bots and sometimes requests are blocked. This is the reason why every time the crawler runs, only one page is crawled.

## Configuration

The provider can be configured via `settings/providers/ImmoscoutLists.yml`. The following values are available:

| Variable                                  | Description                                    |
|-------------------------------------------|------------------------------------------------|
| type                                      | The type of object to search for. See 'Available Types'. |
| location                                  | The ZIP or Name of the city to search arround it. |
| latitude                                  | The latitude of the place to search arround.  |
| longitude                                 | The longitude of the place to search arround.  |
| radius                                    | The radius to search arround the given city in km.  |

## Available Types (as of 07.11.2020)

* Rent
  * `wohnung-mieten`
  * `haus-mieten`
  * `grundstueck-pachten`
  * `garage-mieten`
  * `wohnen-auf-zeit`
  * `wg-zimmer`
  * `seniorenwohnen`
  * `altenpflege`
* Buy
  * `wohnung-kaufen`
  * `haus-kaufen`
  * `grundstueck-kaufen`
  * `garage-kaufen`
  * `anlageimmobilie`
  * `zwangsversteigerung`
