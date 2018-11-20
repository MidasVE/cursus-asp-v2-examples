## Opdracht

* Voeg een verplicht veldje `isMale` toe aan `Kitten`; geef het een relevant label.
* Breid de indexpagina uit. Laat een icoontje zien afhankelijk van het geslacht, toon de geformatteerde geboortedatum en laat een aantal asterix'en zien gebaseerd op de cuteness-rating.
* Zorg ervoor dat een kitten niet in de toekomst kan geboren worden. Gebruik hiervoor een eigen ´ValidationAttribute´.
* Zorg voor een dropdownlist op de create pagina met daarin alle kittens en geef het veldje de naam "moeder". Laat daarin alleen de vrouwelijke katten zien. Zorg er voor dat je een error krijgt al de kat die je selecteert als moeder dit jaar geboren is. Gebruik hiervoor *geen* `ValidationAttribute`
> Hiervoor ga je waarschijnlijk het model van de Create pagina moeten herschrijven! Maak een CreateKitten model aan met daarin een Kitten property en een lijst van Kittens waaruit je kan selecteren.
* Zorg er voor dat de katten editeerbaar zijn. 
  * Ofwel herbruik je de `create` pagina
  * Ofwel maak je een nieuwe pagina die enkel en alleen voor de edit dient.

## Links

* http://localhost:5000/kitten/create
* http://localhost:5000/kitten