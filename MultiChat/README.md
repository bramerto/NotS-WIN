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
Boxing is het proces van converteren van een *value type* (`int`,`byte`, of een `float`) naar het type `object`. Wat dit doet is dat deze variabele een referentie krijgt naar de managed heap in plaats van op de stack.

```c#
int i = 123;
object o = i;
```

In dit voorbeeld wordt `int i` geboxt naar `object o`. Omdat dit nu een referentie is zal een kopie van `o` ook `o` zelf aanpassen. Om deze variabele weer te unboxen wordt het volgende gedaan:

```c#
o = 123;
i = (int)o;
```

### Code voorbeeld van je eigen code
In de MultiChat app is er op een plaats waar mogelijk boxing gebruikt had kunnen worden. Dit is bij de `btnBuffer_Click()` functie  waar  de `string bufferSize` om wordt gezet naar een `int`. Dit is anders gedaan  met de functie `Int32.TryParse()`. 

Hieronder is een mogelijkheid getoont waarin boxing wordt toegepast in MultiChat

```c#
string bufferInput = "1024";
// Dit kan resulteren in een fout
int i1 = (int)bufferInput;

// 'succes' wordt naar false gezet als dit fout gaat
bool success = int.TryParse(bufferInput, out int n);
```

### Alternatieven & adviezen
Boxing en unboxing is grotendeels overbodig geworden door generics. Ook is het CPU intensief als het op grote schaal wordt gebruikt. Het advies is om boxing en unboxing niet te gebruiken.

### Authentieke en gezaghebbende bronnen
Boxing and unboxing: https://docs.microsoft.com/en-us/dotnet/csharp/programming-guide/types/boxing-and-unboxing

Pluralsight: https://app.pluralsight.com/library/courses/c-sharp-fundamentals-with-visual-studio-2015/table-of-contents

## Delegates & Invoke
### Beschrijving van concept in eigen woorden
Een delegate is een referentie naar een andere methode. Deze methode kan vervolgens worden gestart via elke thread met `invoke`. Met deze manier kan de methode op de juiste thread worden uitgevoerd.

```c#
delegate void TestDelegate(string msg);

public static void MethodDelegate(string msg)
{
    // Do something
}

TestDelegate handler = MethodDelegate;

handler("Hello world!");
```

### Code voorbeeld van je eigen code
In de Windows Form class `MultiChat` is er een delegate gemaakt die onderdelen toevoegt aan de lijst. Omdat dit in de UI thread geregeld moet worden (de lijst is een UI onderdeel) is er een delegate gemaakt die kan worden aangeroepen vanuit andere threads.

Hieronder is een voorbeeld aangemaakt uit de MultiChat.cs class
```c#
protected delegate void UpdateChatDelegate(string message);

public void AddMessage(string message)
{
    if (listChats.InvokeRequired)
        listChats.Invoke(new UpdateChatDelegate(UpdateChat), new object[] { ">> " + message });
    else
        UpdateChat("<< " + message);
}
```

### Alternatieven & adviezen
Een delegate is een handig onderdeel als je deze heel vaak moet gebruiken. Het is ook mogelijk om een anonieme delegate te maken. Deze methode is doorgaans sneller dan een volledige delegate maken. Daarnaast is er een derdere optie: Lambda's. Lambda's zijn het snelst om uit te voeren.

Dit is een klein voorbeeld van een anonieme delegate:

```c#
delegate void TestDelegate(int i);

TestDelegate a = delegate(int count) {
    // Do something
};

a("Hello World!");
```

Dit is een klein voorbeeld van een lambda:

```c#
delegate void TestDelegate(int i);

TestDelegate a = (int count) => {
    // Do something
};

a("Hello World!");
```

### Authentieke en gezaghebbende bronnen

Delegates: https://docs.microsoft.com/en-us/dotnet/csharp/programming-guide/delegates/

Using delegates: https://docs.microsoft.com/en-us/dotnet/csharp/programming-guide/delegates/using-delegates

Lambda expressions: https://docs.microsoft.com/en-us/dotnet/csharp/programming-guide/statements-expressions-operators/lambda-expressions

Anonymous methods: https://docs.microsoft.com/en-us/dotnet/csharp/programming-guide/statements-expressions-operators/anonymous-methods

## Threading & Async
### Beschrijving van concept in eigen woorden


### Code voorbeeld van je eigen code


### Alternatieven & adviezen


### Authentieke en gezaghebbende bronnen

