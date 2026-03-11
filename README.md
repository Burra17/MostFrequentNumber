# MostFrequentNumber

Konsolapplikation i C# som hittar den mest frekventa siffran i en array av heltal.

## Beskrivning

Programmet tar en array av heltal och returnerar det tal som förekommer flest gånger. Om flera tal har samma frekvens returneras det minsta talet.

## Lösningsstrategi

- En `Dictionary<int, int>` används för att räkna förekomster av varje tal.
- Arrayen loopas igenom en gång för att fylla dictionaryn.
- Sedan jämförs alla poster för att hitta talet med högst frekvens (vid lika frekvens vinner det lägsta talet).

## Testfall

| Test | Input | Förväntat resultat |
|------|-------|--------------------|
| 1 | `{1, 3, 2, 3, 4, 1, 3, 2, 2, 2, 5}` | `2` |
| 2 | `{7, 7, 5, 5, 1, 1, 1, 2, 2, 2}` | `1` |
| 3 | `{-1, -1, -5, -5, -5, 2, 2}` | `-5` |

## Krav

- .NET 9.0

## Kör programmet

```bash
dotnet run
```
