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
- Markdown
- Bug fixing

#### Vasco Duarte
- Properties.cs
- Interface.cs (Tudo meno: metodo truncate)
- Search.cs (Ordering, substrings e metade do switch case)
- UML
- Doxyfile
- Markdown
- Bug fixing

#### Francisco Costa
Não trabalhou no projeto

### [Link GitHub](https://github.com/Vascord/LP2_Project1)

## Arquitetura da Solução

### Forma de implementação
- Consola não-interativo

### Descrição da solução

A class `Program` é a class controladora central, ela vai chamar as classes necessárias na boa ordem para o programa funcionar.
 
Primeiramente, ele cria os IEnumerables _planets_ e _stars_, onde vão ser guardadas os dados dos planetas e das estrelas do ficheiro.
 
Depois ele chama a class `Properties`, que organiza os argumentos passados pela linha de comandos. Aí ele vai tratar de saber quais são os dados que o 
utilizador quer ter e saber que tipo de pesquisa ele quer fazer.
 
Depois, ele volta o `Program` e em seguida o ele chama a class `ReadFile` que lê o ficheiro para duas listas, uma composta de `Planets` e outra de `Stars`, em seguida cria dois IEnumerables destas listas e actualiza os dois que já estão no `Program`. Utilizamos `StarComparer` para fazer que o programa reconheceu as
estrelas iguais e assim também ajudou a acumular os dados das estrelas.
 
Após ter as duas coleções criadas o `Program` chama a class `Search` que usa o LINQ para organizar e remover planetas/estrelas que não respeitem as condições passadas pelas linhas de comandos.
 
Por fim, o programa chama a class `Interface` que dá o output do resultado da pesquisa. Esse output também pode ser em csv como pedido e também podes pedir
, graças ao comando _-- help_, ajuda nos comandos a meter para fazer um search.
 
Se o ficheiro ou outputs não forem adequados para a pesquisa (ficheiro incompletos, valores não numéricos na pesquisa de valores numéricos, etc.), 
então o programa vai dar uma mensagem de erro adequada ao utilizador.


### UML

![Diagrama de classes](UML.png)

## Referencias

Para este projeto, utilizamos essencialmente o site .NET API da Microsoft e o site StackOverflow quando precizavamos de uma ajuda.

Estas forao as 2 principais ajudas:

Ajuda para modificar valores de uma propridade graças a uma string : [link](https://stackoverflow.com/questions/1196991/get-property-value-from-string-using-reflection)

Distinct para a class `StarComparor` : [link](https://docs.microsoft.com/en-us/dotnet/api/system.linq.enumerable.distinct?view=net-5.0)

O resto foi maioritariamente pesquizas na API do C# e das aulas.