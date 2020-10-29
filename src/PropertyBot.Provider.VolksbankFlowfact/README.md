# Volksbank Flowfact Provider

This provider crawles the properties of from any Volksbank supporting the flowfact API. One example is the [Volksbank Neckar-Enz](https://www.vorne.de/immobilien/immobilien-finden.html).

## Configuration

The provider can be configured via `settings/providers/VolksbankFlowfact.yml`. The following values are available:

| Variable                                  | Description                                    | Mandatory | Default   |
|-------------------------------------------|------------------------------------------------|-----------|-----------| 
| inputMask                                 | The input mask define which type of properties are crawled. | yes | - |
| clientId                                  | The client id of the volksbank to crawl from.  | yes | - |
| zipTown                                   | The ZIP and Name of the city to search arround it. | yes | - |
| latitude                                  | The latitude of the city which is the center for the search.  | yes | - |
| longitude                                 | The longitude of the city which is the center for the search.  | yes | - |
| radius                                    | The radius to search arround the given city.  | yes | - |

## Available Input Masks (as of 29.10.2020)

| Input Mask | Type |
|------------|------|
| 9AB30EBD-096C-492E-88E3-D4F779518E91 | Wohnung kaufen |
| DA42D4E4-D160-44A1-A69E-246A39095EFE | Haus kaufen |
| 479CF1DE-F316-4CAD-88AA-8D34B207E7E0 | Grundstück kaufen |
| 37FCE1F4-E2FD-4ADF-9A7C-A7F10DC8AB54 | Garage/Stellplatz kaufen |
| 2F70B9A2-0A32-45E9-8089-7122F89EF678 | Renditeobjekt |
| 909D6406-C71C-4305-A94B-083B8BC07724 | Sonstige Gew.Immobilie mieten |

*These values are taken directly from the dropdown of the website.*

## Knonw client IDs (as of 29.10.2020)

| Client ID | Bank |
|-----------|------|
| 60491430  | Volksbank Neckar-Enz |
| 62090100  | Volksbank Heilbronn |
