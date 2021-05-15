# Teorema del mono infinito
## Algoritmos Genéticos - Grupo 3 - TP 2 - IA 1C 2021

![monos simpsons](https://ep01.epimg.net/elpais/imagenes/2015/04/30/ciencia/1430420317_959498_1430423238_sumario_normal.jpg)

El *teorema del mono infinito* afirma que un mono pulsando teclas al azar sobre un teclado durante un periodo de tiempo infinito casi seguramente podrá escribir finalmente cualquier texto dado. En el mundo angloparlante se suele utilizar el Hamlet de Shakespeare como ejemplo, mientras en el mundo hispanohablante se utiliza el Quijote de Cervantes.

Pero si en lugar de tomar un tiempo infinito, nosotros aplicamos *algoritmos genéticos* al comportamiento de estos monos, podríamos reducir ese tiempo?

Para lograrlo, necesitamos una frase a reproducir por nuestros monos, y luego un grupo de N monos, cada uno creando una frase aleatoria de caracteres y símbolos.
Para saber si nuestros monos se acercan a la frase, vamos a tomar como función de aptitud la proporción de caracteres que coinciden con la frase. De esa manera vamos a ir seleccionando según diferentes mecanismos a las siguientes generaciones de monos.

Como frase vamos a utilizar una muy conocida del quijote:

![Don Quijote frase](https://1.bp.blogspot.com/-zlyoueJg7fI/WrFYST9PcxI/AAAAAAAAEUo/hKIWvI4imJsS4gkZBlOYzjWI1fUkvIw3wCLcBGAs/s400/Vi%25C3%25B1eta%2Bfrase.jpg)

---
Fuente: https://es.wikipedia.org/wiki/Teorema_del_mono_infinito
