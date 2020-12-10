# 1º Projeto de Linguagens de Programação II
## Autoria 
### Nome dos Autores
Nelson Salvador 21904295 | Vasco Duarte 21905658 | Francisco Costa 21903228

### Informação de trabalho

#### Nelson Salvador
- ReadFile.cs
- Search.cs (Tudo menos: Ordering, Substrings e metade do switch case)
- Stars.cs
- planets.cs
- StarComparer.cs
- Interface.cs (method Truncate)
- Bug fixing

#### Vasco Duarte
- Properties.cs
- Interface.cs (Tudo meno: metodo truncate)
- Search.cs (Ordering, substrings e metade do switch case)
- Bug fixing

#### Francisco Costa
Não trabalhou no projeto

#### [Link GitHub] (https://github.com/Vascord/LP2_Project1)

### Arquitetura da Solução

### UML

![Diagrama de classes](UML.png)

#### Forma de implementação
- Consola não-interativo

#### Descrição da solução

A class program é a class controladora central, esta chama a class properties
que organiza os argumentos passados pela linha de commandos, em seguida o 
program chama a class ReadFile que lê o ficheiro para duas listas, uma composta de 
Planets.cs e outra de Stars.cs, em seguida cria dois IEnumerables destas listas.

Após ter as duas coleções criadas o program chama a class Search que usa o LINQ
para organizar e remover planetas/estrealas que não respeitem as condições passadas 
pelas linhas de comandos. Por fim o program chama a class Interface que dá o 
output do resultado da pesquisa.


