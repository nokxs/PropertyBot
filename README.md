# Property Bot

This bot can crawl websites with properties and notify the user if something new with his search criteria is found.

## Docker image

You can use the pre-build docker image [`liofly/property-bot`](https://hub.docker.com/r/liofly/property-bot).

## Data providers

The following property data providers are currently supported:

- [zvg.com](https://zvg.com): [Readme](PropertyBot.ZVG/README.md)
- [Kreissparkasse Böblingen](https://www.kskbb.de/de/home/privatkunden/immobilien/immobilienportal.html): [Readme](PropertyBot.Provider.KSK/README.md)
- [Volksbank Immopool](https://www.volksbank-stuttgart.de/immobilien/immobilienangebote/regionale-immobilienangebote.html): [Readme](PropertyBot.Provider.VolksbankStuttgart/README.md)
- [Link Immobilien](https://www.link-immobilien.info/Angebote.htm): [Readme](PropertyBot.Provider.LinkImmo/README.md)
- [Gut Immobilien](https://www.gutimmo.de/Angebote.htm): [Readme](PropertyBot.Provider.GutImmo/README.md)
- [RJ Immobau Immobilien](http://www.rjimmobau.de/Angebote.htm): [Readme](PropertyBot.Provider.RjImmobau/README.md)

## Senders

The following senders are currently supported:

- [Telegram](https://telegram.org): [Readme](PropertyBot.Sender.Telegram/README.md)

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