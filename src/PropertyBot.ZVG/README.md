# ZVG Data Provider

This provider crawles [ZVG.com](http://zvg.com) for new properties.

## Configuration

The provider can be configured via `settings/providers/VolksbankFlowfact.yml`. The following values are available:

| Variable                                  | Description                                    |
|-------------------------------------------|------------------------------------------------|
| stateId                                   | The state in germany, which shall be crawled. Accepts only a single integer |
| courtIds                                  | The courts, which shall be crawled. Accepts multiple integeres delmited by a comma |
| objectKindIds                             | The kind of objects, which shall be crawled. Accepts multiple integeres delmited by a comma |


The provider can be configured with the following environment variables. See the provided docker-compose.yml for examples.


### State IDs

The values to use can be found [here](https://www.zvg.com/appl/infomail.prg?act=getForm&dhxr1597057849986=1).

| Id | State                  |
|----|------------------------|
| 2  | Hamburg                |
| 3  | Berlin                 |
| 4  | Baden-Württemberg      |
| 5  | Brandenburg            |
| 6  | Mecklenburg-Vorpommern |
| 8  | Schleswig-Holstein     |
| 9  | Niedersachsen          |
| 10 | Sachsen-Anhalt         |
| 12 | Thüringen              |
| 31 | Reinhland-Pfalz        |


### Court IDs

The values to use can be found [here](https://www.zvg.com/appl/suche.prg?act=getComboAG&dhxr1597057851258=1).


### Object Kind IDs

The values to use can be found [here](https://www.zvg.com/appl/suche.prg?act=getComboOA&dhxr1597057850786=1).
