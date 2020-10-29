# Property Bot

This bot can crawl websites with properties and notify the user if something new with his search criteria is found.

## Docker image

You can use the pre-build docker image [`liofly/property-bot`](https://hub.docker.com/r/liofly/property-bot).

## Data providers

The following property data providers are currently supported:

- [zvg.com](https://zvg.com): [Readme](src/PropertyBot.ZVG/README.md)
- [Kreissparkasse Böblingen](https://www.kskbb.de/de/home/privatkunden/immobilien/immobilienportal.html): [Readme](src/PropertyBot.Provider.KSK/README.md)
- [Volksbank Immopool](https://www.volksbank-stuttgart.de/immobilien/immobilienangebote/regionale-immobilienangebote.html): [Readme](src/PropertyBot.Provider.VolksbankImmopool/README.md)
- [Volksbank Flowfact](https://www.vorne.de/immobilien/immobilien-finden.html): [Readme](src/PropertyBot.Provider.VolksbankFlowfact/README.md)
- [Link Immobilien](https://www.link-immobilien.info/Angebote.htm): [Readme](src/PropertyBot.Provider.LinkImmo/README.md)
- [Gut Immobilien](https://www.gutimmo.de/Angebote.htm): [Readme](src/PropertyBot.Provider.GutImmo/README.md)
- [RJ Immobau Immobilien](http://www.rjimmobau.de/Angebote.htm): [Readme](src/PropertyBot.Provider.RjImmobau/README.md)
- [Immobilienscout24 Lists](https://portal.immobilienscout24.de/ergebnisliste/14652716): [Readme](src/PropertyBot.Provider.ImmoscoutLists/README.md)

## Senders

The following senders are currently supported:

- [Telegram](https://telegram.org): [Readme](src/PropertyBot.Sender.Telegram/README.md)

## Persistence

Only one persistence provider is allowed at runtime. Currently only mongo db is supported.

The following environment variables are mandatory:

| Environment Variable | Description                | Mandatory |
|----------------------|----------------------------|-----------|
| MONGO_DB_PASSWORD    | Password of the given user | yes		|
| MONGO_DB_USER        | User for the mongo db      | yes		| 

## Common

The following common environment variables can also be used:

| Environment Variable                 | Description                                    | Mandatory | Default |
|--------------------------------------|------------------------------------------------|-----------|---------|
| PROPERTY_POLLING_INTERVAL_IN_SECONDS | The time in seconds between polling properties | no        | 600     |