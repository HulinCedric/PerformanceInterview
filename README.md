## Objectif

Vous venez d'être affecté au centre d'analyse et de supervision d'un nouveau parc d'attraction. Votre mission est d'estimer chaque jour quelle vont être les recettes de la journée pour chaque manège. Vous commencez par vous intéresser aux montagnes russes.

## Règles

Vous remarquez que les montagnes russes plaisent tellement aux gens que dès qu'ils ont fini un tour de manège, ils ne peuvent s’empêcher de revenir pour un nouveau tour.
- Les personnes viennent faire la queue devant l'attraction.
- Elles peuvent soit être seules, soit être en groupe. Lorsque des groupes sont dans la queue, ils veulent forcément monter ensemble à bord, sans être séparés.
- Les personnes ne se doublent jamais dans la file d'attente.
- Dès qu'il n'y a plus assez de place dans l'attraction pour le prochain groupe dans la queue, le manège démarre. (Il n'est donc pas toujours plein).
- Dès que le tour de manège est terminé, les groupes qui en sortent retournent dans la file d'attente dans le même ordre.

Le manège contient un nombre `L` limite de places.    
Le manège ne peut fonctionner que `C` fois dans une journée.    
La file d'attente contient un nombre `N` de groupes.    
Chaque groupe comporte un nombre `Pi` de personnes.    
Chaque personne dépense **1** dirham par tour de manège.

## Exemples

Avec `L`=**3**, `C`=**3** et **4** groupes (`N`=**4**) de tailles [3,1,1,2]:

**Tour 1 :** pour le premier tour de manège, seul le premier groupe peut monter et prend toutes les places. À la fin du tour, ce groupe retourne en fin de queue qui ressemble maintenant à  [1,1,2,3 ].    
_Gain du tour : 3 dirhams._

**Tour 2 :** au second tour, les 2 groupes de 1 personnes suivantes peuvent monter, laissant une place vide (le groupe de 2 personnes qui les suit ne peut pas se séparer). À la fin du tour, ils retournent en fin de file :   [2,3,1,1 ].    
_Gain du tour : 2 dirhams._

**Tour 3 :** pour le dernier tour (C=3), seul le groupe de 2 personnes peut entrer, laissant une place vide.    
_Gain du tour : 2 dirhams._

**Gain total : 3+2+2 = 7 dirhams**

## Contraintes

`Pi` ≤ `L`  1 ≤ `L` ≤ 10^7    
1 ≤ `C` ≤ 10^7    
1 ≤ `N` ≤ 1000    
1 ≤ `Pi` ≤ 10^6