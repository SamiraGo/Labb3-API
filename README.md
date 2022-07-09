# Labb3-API

**```Uppgift 1 - Hämta alla personer i systemet```**

Anrop: **GET** Url: https://localhost:44344/api/person
***

**```Uppgift 2 - Hämta alla intressen som är kopplade till en specifik person```**

Anrop: **GET** Url: https://localhost:44344/api/person/hobbies/1
***

**```Uppgift 3 - Hämta alla länkar som är kopplade till en specifik person```**

Anrop: **GET** Url: https://localhost:44344/api/person/links/3
***

**```Uppgift 4 - Koppla en person till ett nytt intresse```**

Anrop: **POST** Url: https://localhost:44344/api/personhobbies 

{
    "hobbyId": 4,
    "hobby": null,
    "personId": 1,
    "person": null
}

***

**```Uppgift 5 - Lägga in nya länkar för en specifik person och ett specifikt intresse```**

Anrop: **POST** Url: https://localhost:44344/api/links/

{
        "url": "https://en.wikipedia.org/wiki/OilPainting",
        "hobbyId": 1,
        "hobby": null,
        "personId": 4,
        "person": null
    }
