# Design Patterns C#
Este trabalho foi criado com o intuito de aprender e tentar fixar na cabeça, de maneira simples os 22 padrões de projeto. Aqui criei um exmplo simples para cada pattern e irei explicá-los detalhadamente.

# Introdução
<p>Padrões de projeto são <b>soluções</b> muito bem testadas para resolver problemas comuns em projetos de softwares, são <b>diretries sobre como lidar com algum determinado problema</b>, basicamente, são soluções utilizando os princípio de orientação a objetos, os padrões de projeto definem uma linguagem única entre os desenvolvedores, pois quando você se depara com um problema, você pode sugerir "isso conseguimos resolver com <b>strategy</b>" e todos os outros desenvolvedores iram entender a ideia da solução proposta.</p>
<p>Os patterns são classificados em três categorias, sejam elas <b>criacionais</b>, <b>estruturais</b> e <b>comportamentais</b> onde</p>
<p><b>Criacionais</b>: Refere-se a mecanismos para a criação de objetos, tem como objetivo abstrair a instancia dos objetos, de maneira que permita a flexibilidade e reutilização do código existente</p>
<p><b>Estruturais</b>: Refere-se a mecanismos para montar objetos em estruturas maiores, organizando a estrutura das classes e o relacionamento entre elas, mantendo as estruturas flexiveis e eficientes</p>
<p><b>Comportamentais</b>: Refere-se a mecanismos para atribuir responsabilidades entre os objetos, definindo como os objetos devem se comportar e se comunicar</p>
 
 <p>De maneira geral, o padrão não é um trecho de código específico e sim um conceito geral, onde você pode seguir os detalhes e implementar no projeto de maneira que faça sentido a realidade do seu sistema</p>
  
 # Atenção
 <p>De qualquer forma, temos que ter em mente que adicionar um padrão de projeto é adicionar complexidade, e complexidade é custo!!</p>
<p>Nas linguagens mais modernas por exemplo, conseguimos resolver um problema que seria solucionado com o pattern strategy, simplesmente utilizando uma função anônima(dependendo do caso), deste modo antes de escolher um pattern deve-se compreender muito bem o problema que você quer resolver, antes de sair implementando com um pattern popular.</p>
<p>Os padrões de projeto podem ser facilmente encontrados na internet(como este por exemplo) mas eles somente nos explicam <b>o que</b> ele é e <b>como</b> implementar, mas eles não nos dizem <b>quando</b> e o <b>por que</b> implementar, as vezes você esta trabalhando com uma linguagem que não tem suporte as funções anônimas e por isso uma das melhores saídas, pode ser o pattern strategy

<p>Devemos implementar os patterns para resolver os nossos problemas e não criar problemas para que seja possível resolver com o pattern</p>
<p>
<img src="https://github.com/Gustavo-Braga/Design-Patterns/blob/feature/CreateReadme/src/BackEnd/image1.jpg">
 <h6><align="center">(fonte: <a href="https://refactoring.guru/design-patterns/criticism" target="_blank">
refactoring.guru</a>)</h6>


</p>

# Tipos de padrões de projeto
<ul>Criacional
  <li>Singleton</li>
  <li>Protótipo(prototype)</li>
  <li>Constutor(builder)</li>
  <li>Método de Fábrica(factory method)</li>
  <li>Fábrica Abstrata(abstract factory)</li>
</ul>
<ul>Estrutural
  <li>Adaptador(adapter)</li>
  <li>Decorador(decorator)</li>
  <li>Ponte(bridge)</li>
  <li>Fachada(facade)</li>
  <li>Proxy</li>
  <li>Composto(composite)</li>
  <li>Flyweight</li>
</ul>

<ul>Comportamental
  <li>Mediador(mediator)</li>
  <li>Observador(observer)</li>
  <li>Cadeia de Responsabilidade(chain of responsibility)</li>
  <li>Comando(command)</li>
  <li>Iterador(iterator)</li>
  <li>Lembrança(memento)</li>
  <li>Método de Modelo(template method)</li>
  <li>Estado(stade)</li>
  <li>Estratégia(strategy)</li>
  <li>Visitante(visitor)</li>
</ul>

# Singleton

<p><b>O que é</b>: Singleton é um padrão de design criacional que lhe permite que apenas uma instância desse tipo de objeto exista.</p>
<p>Exemplo:</p>
<p>Só pode haver um presidente de um país. O mesmo presidente deve ser acionado sempre que o dever exigir. O presidente é singleton.</p>

<p>Para o nosso exemplo, foi criado uma classe de repositório onde só pode haver uma instância do objeto, para esta classe é necessário informar o nome da tabela que o repositório ira atuar. Para esta classe também foi implementado o thread safe para não quebrar a funcionalidade caso seja chamado de vários threads simultaneamente</p>

<p><b>Solução</b>:</p>
<p>Torne o construtor padrão privado, para impedir que outros objetos utilizem o operador "new"</p>
```c#
      private ProductRepository(string tableName)
      {
          TableName = tableName;
      }
      
      public string TableName { get; set; }
      public static ProductRepository _instance;
      public static readonly object _lock = new object();
```
<p>Crie um método de criação estático que atua como construtor, este método deve chamar o construtor privado e salvar em um campo estático, todas as chamadas a seguir devem retornar o objeto estático<p>
 
 ```c#
 public static ProductRepository GetInstance(string tableName)
        {
            if (_instance == null)
                lock (_lock)
                    _instance = new ProductRepository(tableName);

            return _instance;
        }
```

<p>Com isto implementado, todas as chamadas ao ProductRepository ira retornar a mesma instancia salva na variável "_instance", deste modo, para realizar a chamada ao método, fica da seguinte maneira</p>
 ```c#
  var repository = ProductRepository.GetInstance("Product");
  Console.WriteLine($"Somente uma instância de ProductRepository: {repository.TableName}");
```

<p>Use o padrão singleton quando, necessitar de somente uma instância disponível para os classes do sistema, por exemplo, uma classe de banco de dados.</p>  





