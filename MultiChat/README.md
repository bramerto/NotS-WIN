Studentnaam: Bram van der Beek

Studentnummer: 603227

# Algemene beschrijving applicatie
De applicatie "MultiChat" die is gerealiseerd in de periode van 18-02-2019 tot 22-02-2019 voor het NotS semester is een applicatie die server en client in een windows forms app samenvoegt. De functie van de app is om een simpele demonstratie te geven hoe een chatapplicatie werkt. In de app wordt er één server opgestart en kunnen er andere instanties van de app worden gemaakt om als clients  die met de server te verbinden te fungeren. Vervolgens kunnen er berichten worden verstuurd tussen de verschillende clients.
 
## Generics
### Beschrijving van concept in eigen woorden
Een generic is een type dat kan worden gebruikt in een class of methode. Het moment dat je de class of methode wilt gebruiken kan je het datatype aangeven waarmee je wilt werken met die class. Met deze methode kan je een class of methode met elk type gebruiken dat je wilt en blijft de applicatie type safe. Je kan een class of methode met een generic instantiëren door <T> aan te geven in de definitie. Je kan de class of methode vervolgens gebruiken door in de plaats van T een datatype aan te geven.
  
```c#
public class List<T>
{
    void Add(T input) { }
}
```

### Code voorbeeld van je eigen code
In de class `Server.cs` is er een lijst gemaakt van clients met de generic class `List`, door hier het type `Client` in de generic te zetten is het gebruik ervan typesafe.

```c#
private List<Client> clients = new List<Client>();
```

### Alternatieven & adviezen
Het is mogelijk om voor elke datatype een class of methode te maken, deze methode is wel type safe maar niet te herbruikbaar en ook niet overzichtelijk voor de developers. Het advies is om dit niet te gebruiken.

Een voorbeeld hoe dit eruit zou gaan zien:

```c#
public class IntList()
{
    void Add(int input) { }
}
```

De tweede mogelijkheid is om een class of methode te maken waar elk type object in mag. Deze methode is wel herbruikbaar maar niet type safe. Het advies is om deze methode niet te gebruiken

Een voorbeeld hoe dit eruit zou zien:

```c#
public class List()
{
    void Add(object input) { }
}
```

### Authentieke en gezaghebbende bronnen

Generics: https://docs.microsoft.com/en-us/dotnet/csharp/programming-guide/generics/
Pluralsight: https://app.pluralsight.com/library/courses/c-sharp-fundamentals-with-visual-studio-2015/table-of-contents

## Boxing & Unboxing
### Beschrijving van concept in eigen woorden


### Code voorbeeld van je eigen code


### Alternatieven & adviezen


### Authentieke en gezaghebbende bronnen


## Delegates & Invoke
### Beschrijving van concept in eigen woorden


### Code voorbeeld van je eigen code


### Alternatieven & adviezen


### Authentieke en gezaghebbende bronnen


## Threading & Async
### Beschrijving van concept in eigen woorden


### Code voorbeeld van je eigen code


### Alternatieven & adviezen


### Authentieke en gezaghebbende bronnen

