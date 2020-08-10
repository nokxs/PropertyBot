# ZVG Data Provider

This provider crawles [ZVG.com](http://zvg.com) for new properties.

## Configuration

The provider can be configured with the following environment variables. See the provided docker-compose.yml for examples.


### PROVIDER_ZVG_STATE_ID

The state in germany, which shall be crawled. Accepts only a single integer.

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


### PROVIDER_ZVG_COURT_IDS

The courts, which shall be crawled. Accepts multiple integeres delmited by a comma. Exampel: 23,26,31

The values to use can be found [here](https://www.zvg.com/appl/suche.prg?act=getComboAG&dhxr1597057851258=1).


### PROVIDER_ZVG_OBJECT_KIND_ID

The kind of objects, which shall be crawled. Accepts multiple integeres delmited by a comma. Exampel: 171,148

The values to use can be found [here](https://www.zvg.com/appl/suche.prg?act=getComboOA&dhxr1597057850786=1).
