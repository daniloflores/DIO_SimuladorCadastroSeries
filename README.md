# DIO_SimuladorCadastroSeries
Objetivo: Simular um aplicativo de cadastro de séries com operações CRUD (Create, Read, Update, Delete), semelhante à Netflix.
Esse desafio foi proposto pela plataforma [DIO](https://www.dio.me/) em um de seus cursos de C#/.NET.

## Objetivos específicos
- Representar uma lista de séries em uma aplicação
- As séries são implementadas como objetos, com números de id únicos
- Além do id, cada série deve ter as propriedades: título, gênero, descrição e ano 
- A edição da lista de séries é feita a partir de uma classe repositório, que implementa uma interface

## Implementação
- Além dos requisitos pedidos, foi criada também um objeto de interface com o usuário (UI)
- O objeto encapsula a apresentação dos menus de interação e o tratamento dos inputs do usuário
- O usuário tem as opções de listar as séries, excluir, atualizar e inserir novas séries
- Uma opção extra foi adicionada ao menu para listar séries por gênero
  - Para tanto, a lista de séries é filtrada usando a biblioteca LINQ do C#
