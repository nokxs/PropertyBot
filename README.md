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
- [Link Immobilien](https://www.link-immobilien.info/Angebote.htm): [Readme](src/PropertyBot.Provider.ImmoXXL/README.md)
- [Gut Immobilien](https://www.gutimmo.de/Angebote.htm): [Readme](src/PropertyBot.Provider.ImmoXXL/README.md)
- [RJ Immobau Immobilien](http://www.rjimmobau.de/Angebote.htm): [Readme](src/PropertyBot.Provider.ImmoXXL/README.md)
- [Immobilienscout24 Lists](https://portal.immobilienscout24.de/ergebnisliste/14652716): [Readme](src/PropertyBot.Provider.ImmoscoutLists/README.md)
- [Wunschimmo](https://www.wunschimmo.de/): [Readme](src/PropertyBot.Provider.Wunschimmo/README.md)

### Configuration

Every data has to be configured through a YAML file. The configuration has to mounted into the docker container under `/app/settings/providers`. The content of every file can be looked up in the individual README files
of the providers. Example configurations can be found [here](src/PropertyBot.Service/settings/providers).

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