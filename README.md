# Property Bot

This bot can crawl websites with properties and notify the user if something new with his search criteria is found.

## Data providers

The following property data providers are currently supported:

- [zvg.com](https://zvg.com): [Readme](PropertyBot.ZVG/README.md)

## Senders

The following senders are currently supported:

- [Telegram](https://telegram.org): [Readme](PropertyBot.Sender.Telegram/README.md)

## Persistence

Only one persistence provider is allowed at runtime. Currently only mongo db is supported.

The following environment variables are mandatory:

| Environment Variable | Description                |
|----------------------|----------------------------|
| MONGO_DB_USER        | User for the mongo db      |
| MONGO_DB_PASSWORD    | Password of the given user |
