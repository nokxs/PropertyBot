# Volksbank Flowfact Provider

This provider crawles the properties of from any Volksbank supporting the flowfact API. One example is the [Volksbank Neckar-Enz](https://www.vorne.de/immobilien/immobilien-finden.html).

## Configuration

The provider can be configured with the following environment variables. See the provided docker-compose.yml for examples.

| Environment Variable                      | Description                                    | Mandatory | Default   |
|-------------------------------------------|------------------------------------------------|-----------|-----------| 
| PROVIDER_VOLKSBANK_FLOWFACT_INPUT_MASK    | The input mask define which type of properties are crawled. Support multiple values comma separated. | yes | - |
| PROVIDER_VOLKSBANK_FLOWFACT_CLIENT_ID     | The client id of the volksbank to crawl from.  | yes | - |

## Available Input Masks (as of 18.10.2020)

| Input Mask | Type |
|------------|------|
| 9AB30EBD-096C-492E-88E3-D4F779518E91 | Wohnung kaufen |
| DA42D4E4-D160-44A1-A69E-246A39095EFE | Haus kaufen |
| 37FCE1F4-E2FD-4ADF-9A7C-A7F10DC8AB54 | Garage/Stellplatz kaufen |
| 2F70B9A2-0A32-45E9-8089-7122F89EF678 | Renditeobjekt |
| 909D6406-C71C-4305-A94B-083B8BC07724 | Sonstige Gew.Immobilie mieten |

*These values are taken directly from the dropdown of the website.*
