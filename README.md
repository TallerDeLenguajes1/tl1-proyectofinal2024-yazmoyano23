# DIGIMON KOMBAT

En este juego de combate 1 vs 1, te enfrentarás a una batalla donde solo los más fuertes sobrevivirán. Se cuenta con mas de 100 monstruos icónicos de la serie Digimon, tu objetivo será seleccionar a tu Digimon favorito y derrotar a todos los oponentes en un enfrentamiento de todo o nada. Solo aquellos que logren vencer a cada rival se alzarán con la victoria en el Gran Torneo Digital. ¡Prepárate para demostrar tu fuerza y reclamar el título de campeón definitivo!

## Caracteristicas generales

**Personajes:** Se brinda al jugador una lista con 10 personajes, de los cuales debera eligir uno para llevar a cabo el combate.  

**Mecanica de juego:**  

- Enfrentamientos: El personaje seleccionado se enfrenta a competidores aleatorios uno por uno. 
- Mejora de Habilidades: Si el personaje del jugador gana una batalla, sus habilidades mejoran.
- Victoria o Derrota: El torneo continúa hasta que el personaje del jugador haya derrotado a todos los competidores o sea derrotado. Si gana, se le declara campeón del Gran Torneo Digital.

**Regitro de Resultados:** Si el personaje del jugador gana, se guarda un registro de la pelea, incluyendo el nombre del oponente, la salud restante, y el número de ataques realizados.
Para este registro se utilizan archivos JSON tanto para los personajes como para los ganadores, por su flexibilidad es posible leer y actualizar sus datos. Además asegura que la informacion no se pierda entre partidas, logrando asi la persistencia de datos.

## Uso de la API para Obtener Características de los Personajes

La API se utiliza para obtener información clave sobre los personajes del juego, como su nombre y tipo.
Puede acceder a la misma en el siguiente enlace: [Digimon API](https://digimon-api.vercel.app/api/digimon).