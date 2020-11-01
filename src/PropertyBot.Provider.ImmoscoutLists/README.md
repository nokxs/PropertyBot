# Immoscout List Provider

This provider crawles the properties from the list view of [immobilienscout24](https://immobilienscout24.de). One example is a list like [this](https://portal.immobilienscout24.de/ergebnisliste/14652716#).

## Configuration

The provider can be configured via `settings/providers/ImmoscoutLists.yml`. The following values are available:

| Variable                                  | Description                                    |
|-------------------------------------------|------------------------------------------------|
| listId                                    | The ids of the lists. Can be found in the url. |
