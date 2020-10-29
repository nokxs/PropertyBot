# Immoscout List Provider

This provider crawles the properties from the list view of [immobilienscout24](https://immobilienscout24.de). One example is a list like [this](https://portal.immobilienscout24.de/ergebnisliste/14652716#).

## Configuration

The provider can be configured with the following environment variables. See the provided docker-compose.yml for examples.

| Environment Variable                      | Description                                    | Mandatory | Default   |
|-------------------------------------------|------------------------------------------------|-----------|-----------| 
| PROVIDER_IMMOSCOUT_LIST_IDS               | The ids of the lists. Can be found in the url. Multiple ids can be separated via comma. | yes | - |
