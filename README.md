# Design Patterns C#
Este trabalho foi criado com o intuito de aprender e tentar fixar na cabeça, de maneira simples os 22 padrões de projeto. Aqui criei um exmplo simples para cada pattern e irei explicá-los detalhadamente.

# Introdução
<p>Padrões de projeto são <b>soluções</b> muito bem testadas para resolver problemas comuns em projetos de softwares, são <b>diretries sobre como lidar com algum determinado problema</b>, basicamente, são soluções utilizando os princípio de orientação a objetos, os padrões de projeto definem uma linguagem única entre os desenvolvedores, pois quando você se depara com um problema, você pode sugerir "isso conseguimos resolver com <b>strategy</b>" e todos os outros desenvolvedores iram entender a ideia da solução proposta.</p>

<p>Os patterns são classificados em três categorias, sejam elas <b>criacionais</b>, <b>estruturais</b> e <b>comportamentais</b></p>
 
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

* [Criacional](#-Criacional)
* Estrutural
* Comportamental

Criacional
----------

<p>Refere-se a mecanismos para a criação de objetos, tem como objetivo abstrair a instancia dos objetos, de maneira que permita a flexibilidade e reutilização do código existente.</p>

 * [Singleton](#-Singleton)
 * Protótipo(prototype)
 * Constutor(builder)
 * Método de Fábrica(factory method)
 * Fábrica Abstrata(abstract factory)


Singleton
---------

**O que é**: Singleton é um padrão de design criacional que lhe permite que apenas uma instância desse tipo de objeto exista.

**Exemplo do mundo real**:

> Só pode haver um presidente de um país. O mesmo presidente deve ser acionado sempre que o dever exigir. O presidente é singleton.
 
**Problema**: Certifique-se de que uma classe possua uma única instância, o motivo mais comum para isso, seria controlar o acesso a algum recurso compartilhado, por exemplo, uma classe de banco de dados.
 
Para o nosso exemplo, foi criado uma classe de repositório onde só pode haver uma instância do objeto, para esta classe é necessário informar o nome da tabela que o repositório ira atuar. Para esta classe também foi implementado o thread safe para não quebrar a funcionalidade caso seja chamado de vários threads simultaneamente.

**Solução**: Torne o construtor padrão privado, para impedir que outros objetos utilizem o operador "new".

```c#
      private ProductRepository(string tableName)
      {
          TableName = tableName;
      }
      
      public string TableName { get; set; }
      public static ProductRepository _instance;
      public static readonly object _lock = new object();
```

Crie um método de criação estático que atua como construtor, este método deve chamar o construtor privado e salvar em um campo estático, todas as chamadas a seguir devem retornar o objeto estático
 
 ```c#
public static ProductRepository GetInstance(string tableName)
{
    if (_instance == null)
        lock (_lock)
            _instance = new ProductRepository(tableName);

    return _instance;
}
```

Com isto implementado, todas as chamadas ao ProductRepository ira retornar a mesma instancia salva na variável "\_instance", deste modo, para realizar a chamada ao método, fica da seguinte maneira:

 ```c#
var repository = ProductRepository.GetInstance("Product");
Console.WriteLine($"Somente uma instância de ProductRepository: {repository.TableName}");
```

**Saída**

> <p>Hello Word</p>
> <p>Somente uma instância de ProductRepository: Product</p>


Use o padrão singleton quando, necessitar de somente uma instância disponível para as classes do sistema, por exemplo, uma classe de banco de dados. 

# Protótipo(prototype)

<p><b>O que é</b>: protótipo é um padrão de design criacional que permite criar novos objetos a partir de um modelo original, permite 
copiar objetos sem tornar o código dependente de suas classes</p>
 
<p><b>Exemplo do mundo real:</p></b>

> Protóripos são criados para possibilitar os testes antes de iniciar a produção em massa de um determinado produto, no entando esses protótipos não participam de nenhuma produção real, desempenha somente um papel passivo.

<p><b>Problema</b>: Digamos que você tenha um objeto e você precisa criar uma cópia exata dele. Você precisaria criar um novo objeto da mesma classe e percorrer todos os campos do objeto original para o novo objeto, porém, criar um objeto "de fora" nem sempre é possível, pois o objeto original pode conter campos privados que seriam invisíveis para quem está realizando a operação de "cópia" do objeto.</p> 
 
<p>Para o nosso exemplo, foi criado uma classe simples de funcionário, onde recebe duas interfaces, a interface IEmployee que é utilizada somente para teste, mostrando uma alternativa para realizar a chamada do método clone, ou seja, pode ser desconsiderada, e a interface ICloneable que é disponibilizada pela Microsoft através da biblioteca System, esta interface segue o exemplo "comum" para implementação do padrão de protótipo
 
 <p><b>Solução</b>:</p>
<p><b>Implementação alternativa</b>:</p>
<p>Crie um interface e atribua um método para ser possível realizar a clonagem do objeto, no nosso caso, a interface IEmployee</p>

 ```c#
    public interface IEmployee
    {
        //método utilizado para teste, pois em C# existe a interface 
        //ICloneable que subistituiria o uso dessa interface
        IEmployee CloneEmployee();
    }
```

<p>Na classe em que deseja realizar a clonagem, herde a interface IEmployee</p>

```c#
    public class Developer : IEmployee
    {
        public Developer(string name, double salary, IEnumerable<string> languages)
        {
            Name = name;
            Salary = salary;
            Languages = languages;
        }
        
        public string Name { get; set; }
        private double Salary { get; set; }
        public IEnumerable<string> Languages { get; set; }
    }
```

<p>Com isso, você é forçado a implementar o método CloneEmployee, que fica da seguinte maneira</p>

```c#
        public IEmployee CloneEmployee()
        {
            return (Developer)MemberwiseClone();
        }
```

<p>Após a implementação do método, é só realizar a chamada do mesmo</p>

```c#
        static void Main(string[] args)
        {
            Console.WriteLine("Hello World!");
            var developer = new Developer("Fulano", new Random().NextDouble(), new List<string> { "C#", "JS" });
            var prototype = developer.CloneEmployee();
            Console.WriteLine(prototype.ToString());
            developer.Name = "Cicrano";
            Console.WriteLine(prototype.ToString());
        }
```

<p>Agora, irei mostrar sem a utilização da interface IEmployee e sim com a utilização da interface ICloneable</p>
<p>Na classe em que deseja realizar a clonagem, herde a interface ICloneable</p>

```c#
    public class Developer : ICloneable
    {
        public Developer(string name, double salary, IEnumerable<string> languages)
        {
            Name = name;
            Salary = salary;
            Languages = languages;
        }
        
        public string Name { get; set; }
        private double Salary { get; set; }
        public IEnumerable<string> Languages { get; set; }
    }
    
```

<p>Com isso, você é forçado a implementar o método Clone, que fica da seguinte maneira</p>

```c#
        public object Clone()
        {
            return MemberwiseClone();
        }
```

<p>Após a implementação do método, é só realizar a chamada do mesmo</p>

```c#
        static void Main(string[] args)
        {
            var developer = new Developer("Fulano", new Random().NextDouble(), new List<string> { "C#", "JS" });
            var prototype2 = (Developer)developer.Clone();
            Console.WriteLine(prototype2.ToString());
            prototype2.Name = "Beltrano";
            Console.WriteLine(prototype2.ToString());
            Console.ReadKey();
        }
```

<p>Em c# a classe Object(que é a classe base de todas as classes) nos fornece o método MemberwiseClone, que criar uma cópia superficial o objeto.</p>

<p><b>Saída</b>:</p>

> <p>Hello World!</p>
> <p>Fulano, 0,602327118442546, C#, JS</p>
> <p>Fulano, 0,602327118442546, C#, JS</p>
> <p>Cicrano, 0,602327118442546, C#, JS</p>
> <p>Beltrano, 0,602327118442546, C#, JS</p>


<p>Use o padrão protóripo quando necessitar copiar objetos sem depender da sua classe concreta. O padrão protótipo torna bem mais simples a criação de novos objetos complexos</p>  

# Constutor(builder)

<p><b>O que é</b>: Contrutor é um padrão de design criacional que permite construir objetos complexos passo a passo, o padrão construtor descreve uma maneira simples de separar o objeto de sua construção
 
<p><b>Problema</b>: Imagine que você tenha um objeto complexo, em que a inicialização é trabalhosa e precisa de vários passos para que seja possível montar o objeto, o código de inicialização é oculto dentro do construtor e há muitos parametros de entrada, por exemplo, vamos pensar no objeto "House". Para construir uma casa simples, você precisa construir quatro paredes, um piso, instalar uma porta, encaixar um par de janelas e construir um telhado. Mas e se você quiser uma casa maior e mais brilhante, com um quintal e outras coisas? A solução mais simples, seria estender a "House" e criar um conjunto de subclasses para cobrir todas as combinações de parâmetros, porém ja conseguimos imaginar que iria ter um aumento considerável nas subclasses e um aumento considerável nos parâmetros do constutor.</p>


<p>Para o nosso exemplo, estarei mostrando duas alternativas para implementar o padrão construtor, a primeira, utilizando a classe de "Diretor" e a segunda sem a utilização desta classe, no nosso caso trata-se da criação de um veículo, onde é separado o construtor em vários métodos a fins de que se possa montar o objeto veículo de diferentes formas

 <p><b>Solução</b>: Deve ser implementado uma interface <b>IBuilder</b> para que nela possa ser extraido todos os métodos referente a criação do objeto. A classe concreta deve herdar desta interface e nos métodos estará a lógica para a criação das partes específicas. A classe de <b>diretor</b> controla o algoritmo para corder de execução das etapas de criação</p>

<p><b>Alternativa com diretor</b>:</p>
<p>Implemente a interface IBuilder, no nosso caso IVehicleBuilder</p>
 
 ```c#
     public interface IVehicleBuilder
    {
        void SetModel();
        void SetYear();
        void SetColor();
        void SetAcessories();
    }
 ```
 
  <p>Após isso, crie a classe de diretor, a mesma deve conter um atributo do tipo IVehicleBuilder</p>
  
   
 ```c#
  public class VehicleCreator 
    {
        private readonly IVehicleBuilder vehicleBuilder;

        public VehicleCreator(IVehicleBuilder vehicleBuilder)
        {
            this.vehicleBuilder = vehicleBuilder;
        }
    }
 ```
 
<p>Feito isso, nesta classe podemos definir o algoritmo para ordem das etapas de criação do objeto. Implementaremos dois métodos sendo eles, CreateVehicleCaracteristics onde irá carregar as características padrões do veículo e o segundo, CreateVehicleAcessories onde irá carregar os acessórios do veículo</p>

 ```c#
        public void CreateVehicleCaracteristics()
        {
            vehicleBuilder.SetModel();
            vehicleBuilder.SetYear();
            vehicleBuilder.SetColor();
        }

        public void CreateVehicleAcessories()
        {
            vehicleBuilder.SetAcessories();
        }
 ```
 
<p>Agora iremos criar a classe Vehicle que será responsável por representar o nosso veículo</p>

 ```c#
    public class Vehicle
    {
        public Vehicle()
        {
            Acessories = new List<string>();
        }

        public string Model { get; set; }
        public string Color { get; set; }
        public int Year { get; set; }
        public IEnumerable<string> Acessories { get; set; }
    }
 ```

<p>Tudo certo até aqui, neste momento iremos criar a classe CarBuilder que irá representar o nosso veículo, expecíficamente um carro. A classe CarBuilder deve conter um atributo privado do tipo Vehicle e deve herdar da nossa interface de builder, a interface IVehicleBuilder, onde irá forçar implementar seus métodos, nesses métodos ficará a lógica para a criação do nosso carro.</p>

<p>É recomendado que as classes concretas que irão representar o nosso produto, tenha um método para recuperar o objeto, pois pode haver cenários em que vários tipos de construtores retornem diferentes tipos de objetos e por isso este método nao é declarado na interface </p>

 ```c#
public class CarBuilder: IVehicleBuilder
    {
        private Vehicle Vehicle = new Vehicle();

        public void SetModel()
        {
            Vehicle.Model = "Sedan";
        }

        public void SetYear()
        {
            Vehicle.Year = 2020;
        }

        public void SetColor()
        {
            Vehicle.Color = "Vermelho";
        }

        public void SetAcessories()
        {
            Vehicle.Acessories = new List<string> { "Neon", "Capa para bancos", "Alarme"};
        }

        public Vehicle GetVehicle()
        {
            return Vehicle;
        }

        public override string ToString()
        {
            return $"Modelo: {Vehicle.Model}, Ano: {Vehicle.Year}, Cor: {Vehicle.Color}, Acessórios: {string.Join(", ", Vehicle.Acessories)}";
        }

    }
 ```
 
 <p>Tudo pronto para o nosso primeiro exemplo, feito isso é só chamar a classe diretor(VehicleCreator) passando o nosso objeto builder(CarBuilder). Assim conseguiremos utilizar os métodos disponíveis no diretor para criar o nosso carro em etapas</p>
 
 ```c#
         private static void Main(string[] args)
        {
            Console.WriteLine("Hello World!");
            var carBuilder = new CarBuilder();
            var car = new VehicleCreator(carBuilder);
            car.CreateVehicleCaracteristics();
            Console.WriteLine(carBuilder.ToString());

            car.CreateVehicleAcessories();
            Console.WriteLine(carBuilder.ToString());
            
        }
 ```
 
 <p><b>Saída</b>:</p>

> <p>Hello World!</p>
> <p>Modelo: Sedan, Ano: 2020, Cor: Vermelho, Acessórios:</p>
> <p>Modelo: Sedan, Ano: 2020, Cor: Vermelho, Acessórios: Neon, Capa para bancos, Alarme</p>
 
 
 <p><b>Alternativa sem diretor(consequentemente mais fácil)</b>:</p>
 <p>Para este segundo exemplo, iremos criar a classe TruckBuilder que irá representar o nosso veículo, expecíficamente um caminhão. A classe TruckBuilder deve conter um atributo privado do tipo Vehicle e <b>não</b> precisa herdar a interface IVehicleBuilder(para este exemplo). A classe TruckBuilder irá conter os métodos para criar o objeto do tipo Vehicle e em todos os métodos deverá retornar a própria classe, com isso fica mais fácil e intuitivo para realizar a montagem do objeto
 
```c#
public class TruckBuilder
{
    private Vehicle Vehicle = new Vehicle();

    public TruckBuilder SetModel(string model)
    {
        Vehicle.Model = model;
        return this;
    }

    public TruckBuilder SetYear(int year)
    {
        Vehicle.Year = year;
        return this;
    }

    public TruckBuilder SetColor(string color)
    {
        Vehicle.Color = color;
        return this;
    }

    public TruckBuilder SetAcessories(IEnumerable<string> acessories)
    {
        Vehicle.Acessories = new List<string> { "Geladeira", "Capa para bancos", "Alarme" };
        Vehicle.Acessories = acessories;
        return this;
    }

    public Vehicle GetVehicle()
    {
        return Vehicle;
    }

    public override string ToString()
    {
        return $"Modelo: {Vehicle.Model}, Ano: {Vehicle.Year}, Cor: {Vehicle.Color}, Acessórios: {string.Join(", ", Vehicle.Acessories)}";
    }
}

 ```
 
<p>Implementado a classe TruckBuilder é só chama-la e executar seus métodos</p>

 ```c#
      private static void Main(string[] args)
        {
            Console.WriteLine("Hello World!");
            var truckBuilder = new TruckBuilder()
                .SetModel("FH-420")
                .SetColor("Black")
                .SetYear(2020);

            Console.WriteLine(truckBuilder.ToString());

            truckBuilder.SetAcessories(new List<string> { "Geladeira", "Capa para bancos", "Alarme" });
            Console.WriteLine(truckBuilder.ToString());
        }
 ```
 
 <p><b>Saída</b>:</p>

> <p>Hello World!</p>
> <p>Modelo: FH-420, Ano: 2020, Cor: Black, Acessórios:</p>
> <p>Modelo: FH-420, Ano: 2020, Cor: Black, Acessórios: Geladeira, Capa para bancos, Alarme</p>
 
<p>Use o padrão construtor quando deseja se livrar de construtores com 10 parâmetros opcionais. Quando desejar que seu código possa criar representações diferentes sobre algum produto(como o nosso exemplo, carro e caminhão). O padrão construtor pode ser aplicado quando a construção de várias representações do produto envolve etapas semelhantes que diferem apenas nos detalhes.</p>

# Método de Fábrica(factory method)

<p><b>O que é</b>: O Método de Fábrica é um padrão de design criacional que utiliza métodos de fábrica para criar objetos sem precisar especificar a sua classe exata, ele nos fornece uma interface para criar objetos em uma superclasse, mas permite que suas subclasses alterem o tipo do objeto.</p>

<p><b>Problema</b>: Imagine que você esteja criando um aplicativo para gerenciamento de logística, onde a primeira versão do seu aplicativo lida apenas com transportes de caminhões, portanto a maior parte do seu código, fica dentro da classe "Truck". Depois de um tempo, seu aplicativo acaba crescendo bastente e agora existe a necessidade de implementar o transporte marítimo. A maior parte do código foi implementada na classe "Truck", a adição da classe "Ship" exigiria alterações em toda a base do código, além disso, caso exija a necessidade de adicionar um novo tipo de transporte, você enfrentaria os mesmos problemas como código duplicado e diversas condicionais que alteram o comportamento do aplicativo dependendo do objeto de transporte</p>

<p><b>Solução</b>:</p> 
<p>O padrão Factory Method sugere que você substitua chamadas diretas de construção de objetos por chamadas para um método especial de fábrica. Os objetos ainda são criados pelo new operador, mas estão sendo chamados de dentro do método de fábrica. Objetos retornados por um método de fábrica geralmente são chamados de "produtos".  A primeira vista, esta alteração parece inútil, só foi movido a chamada de um contrutor para outra parte do programa, porém agora você consegue substituir o método de fábrica em uma subclasse e alterar a classe de produtos que estão sendo criados pelo método. Porém há uma limitação, as subclasses podem retornar tipos diferentes de produtos somente se eles possuirem uma interface comum, além disso o método de fábrica deve ter seu tipo de retorno declarado como essa interface.</p>

<p>Para implementar o Factory Method temos o <b>Product</b> que é a interface para criação dos objetos, <b>ConcreteProduct</b> que seriam as classes que herdam da interface Product, <b>Creator</b> esta é a classe abstrata que declara o método factory e retorna o objeto do tipo Product, e por fim temos o <b>ConcreteCreator</b> esta é a classe que implementa a classe Creator e substitui o método factory para retornar uma instância de ConcreteProduct</p>

<p>Para o nosso exemplo, seguimos com a implementação de um método de fábrica para nos retornar o tipo de transporte "Truck" ou "Ship"</p>
 
 <p>Inicialmente, iremos criar a nossa interface(Product) "ITransport" nela adicionaremos um método indicando as milias referente a enrega</p>
 
 ```c#
     public interface ITransport
    {
        string Deliver(int miles);
    }
 ```
 
 <p>Feito isso, iremos implementar os nossos meios de transporte(ConcreteProduct) "Truck" e "Ship" onde devem herdar da interface ITransport</p> 
  
 ```c#
    public class Ship : ITransport
    {
        public string Deliver(int miles)
        {
            return $"O valor para o transporte marítimo é {miles * 12}";
        }
    }
    
    public class Truck : ITransport
    {
        public string Deliver(int miles)
        {
            return $"O valor para o transporte de caminhão é {miles * 2}";
        }
    }
 ```
 
 <p>Após a implementação do nosso ConcreteProduct, iremos criar um enun "Transport" para validar qual tipo de transporte será criado</p>
  
  ```c#
    public enum Transport
    {
        Maritime,
        Road
    }
  ```
  
  <p>Tudo certo por enquanto. Agora iremos implementar o creator "TrasnportFactoryBase"</p>
    
  ```c#
    public abstract class TrasnportFactoryBase
    {
        abstract public ITransport GetTransport(Transport transportType);
    }
  ```
  
 <p>Observe que o tipo de retorno, precisa ser o tipo da interface product e não uma classe concreta</p>
  <p>Quase pronto, agora precisamos implementar o nosso concreteCreator, ele deve herdar da classe abstrata de creator e é responsável por criar a classe concreta do tipo product</p>
  
```c#
    public class TransportFactory : TrasnportFactoryBase
    {
        public override ITransport GetTransport(Transport transportType)
        {
            switch (transportType)
            {
                case Transport.Maritime:
                    return new Ship();
                case Transport.Road:
                    return new Truck();
                default: return new Truck();
            }
        }
    }
```

 <p>Pronto, agora temos a nossa classe de fábrica, neste momento é só chamar a classe de concreteCreator no nosso caso, a classe TransportFactory e informar(com o enum) qual é o tipo de transporte que deve ser retornado</p>
 
 ```c#
        private static void Main(string[] args)
        {
            var factory = new TransportFactory();

            var road = factory.GetTransport(Enum.Transport.Road);
            Console.WriteLine(road.Deliver(90));

            var maritime = factory.GetTransport(Enum.Transport.Maritime);
            Console.WriteLine(maritime.Deliver(1200));

            Console.ReadKey();
        }
```
 
<p><b>Saída</b>:</p> 

> <p>Hello World!</p>
> <p>O valor para o transporte de caminhao é 180</p>
> <p>O valor para o transporte marítimo é 14400</p>

<p>A utilização do padrão Factory é útil quando você precisa criar objetos dinamicamente sem conhecer a classe de implementação, somente usando sua interface, ou também quando existe algum processamento genérico em uma classe, mas a subclasse necessária é decidida dinamicamente no tempo de execução, em outras palavras, quando o cliente não sabe de que subclasse exata ele pode precisar</p>

# Fábrica Abstrata(abstract factory)

<p><b>O que é</b>: O padrão de Fábrica Abstrata é um padrão criacional que permite produzir famílias de objetos sem especificar suas classes concretas, este padrão fornece uma maneira de encapsular um grupo de fábricas individuais mas relacionadas, sem especificar suas classes concretas</p>

<p><b>Problema</b>: Imagine que você tenha a necessidade de adquirir uma porta, se você quiser uma porta de madeira, você pode ir até uma loja de portas de madeira e adquirir, caso você queira uma de ferro, você precisará ir até uma loja de portas de ferro e adquirir, assim por diante. Além disso, você precisará de um profissional para instalar a porta com especialidades específicas, por exemplo, um carpinteiro para a porta de madeira ou um soldador para a porta de ferro. Como você pode observar, existe uma dependência para cada tipo de porta que você selecionar.</p>

<p><b>Solução</b>: O padrão de fábrica abstrata, nos permite agrupar fábricas individuais que estejam relacionadas, sem precisar especificar suas classes concretas</p>

<p> para o nosso exemplo, iremos criar uma fábrica para mobílias sejam elas sofá e cadeira, será criada as mobílias do tipo moderno e do tipo vitoriano</p> 

<p>Para o padrão de fábrica abstrata, entendemos que <b>AbstractProduct</b> é a interface que declara um tipo de produto(sofá/cadeira), <b>ConcreteProduct</b> é a classe que implementa a interface de AbstractProduct, <b>AbstractFactory</b> é a interface usada para criar produtos abstratos(fábricas) e <b>ConcreteFactory</b> é a classe que implementa a interface AbstractFactory e nos retorna os produtos concretos</p> 

<p>A primeira coisa que precisamos fazer, é declarar explicitamente interfaces(AbstractProduct) para cada tipo distinto da família de produtos(sofá e cadeira)<p>
 
 ```c#
 
    public interface ISofa
    {
        string GetType();
    }
    
    public interface IChair
    {
        string GetType();
    }
 
 ```

<p>O próximo passo é declarar o AbstractFactory com a lista de métodos de criação para todos os produtos que fazem parte da família de produtos<p>
 
  ```c#
 
    public interface IFurnitureFactory
    {
        IChair CreateChair();
        ISofa CreateSofa();
    }
 
 ```
 
<p>Agora para cada variante do produto(ConcreteProduct) precisaremos criar fábricas(ConcreteFactory) separadas para poder retornar o tipo específico do produto. Irei criar o ConcreteProduct para sofá e cadeira do tipo moderno e vitoriano, criarei também as ConcreteFactory para os respectivos tipos de produto, lembrando ConcreteFactory deve herdar de AbstractFactory e ConcreteProduct deve herdar de AbstractProduct<p>

<p>ConcreteProduct do tipo moderno</p>

```c#
 
public class ModernChair : IChair
    {
        public ModernChair()
        {
        }

        public ModernChair(bool hasLegs)
        {
            HasLegs = hasLegs;
        }

        public bool HasLegs { get; set; }
        public string GetType()
        {
            return $"Esta é uma cadeira Moderna {(HasLegs ? "modelo simples" : "com um modelo inovador")}";
        }
    }
    
     public class ModernSofa : ISofa
    {
        public ModernSofa()
        {
        }

        public ModernSofa(string size, bool isRetratil)
        {
            Size = size;
            IsRetratil = isRetratil;
        }

        public string Size { get; set; }
        public bool IsRetratil { get; set; }

        public string GetType()
        {
            return $"Este é um Sofá Moderno{(IsRetratil ? " retrátil" : "")}{(string.IsNullOrEmpty(Size) ? "" : $", com o tamanho {Size} m")}";
        }
    }
 
```

<p>ConcreteProduct do tipo vitoriano</p>
 
 ```c#
 
public class VictorianChair : IChair
    {
        public VictorianChair()
        {
        }

        public VictorianChair(string texture, bool isMetallic)
        {
            Texture = texture;
            IsMetallic = isMetallic;
        }

        public string Texture { get; set; }
        public bool IsMetallic { get; set; }

        public string GetType()
        {
            return $"Esta é uma cadeira Vitoriana de textura {(string.IsNullOrEmpty(Texture)? "tecido": Texture)} e com acabamento {(IsMetallic? "metálico": "de madeira")}";
        }
    }
 
```

<p>ConcreteFactory do tipo moderno</p>

```c#
public class ModernFurniture : IFurnitureFactory
    {
        public IChair CreateChair(bool hasLegs)
        {
            return new ModernChair(hasLegs);
        }

        public IChair CreateChair()
        {
            return new ModernChair();
        }

        public ISofa CreateSofa(string size, bool isRetratil)
        {
            return new ModernSofa(size, isRetratil);
        }
        public ISofa CreateSofa()
        {
            return new ModernSofa();
        }
    }
```

<p>ConcreteFactory do tipo vitoriano</p>

```c#
public class VictorianFurniture: IFurnitureFactory
    {
        public IChair CreateChair(string texture, bool isMetallic)
        {
            return new VictorianChair(texture, isMetallic);
        }

        public ISofa CreateSofa(string size)
        {
            return new VictorianSofa(size);
        }

        public IChair CreateChair()
        {
            return new VictorianChair();
        }

        public ISofa CreateSofa()
        {
            return new VictorianSofa();
        }
    }
```

<p>Com isso finalizamos a implementação, agora é só realizar a chamada.</p>

```c#
static void Main(string[] args)
        {
            Console.WriteLine("Hello World!");

            var modernFurniture = new ModernFurniture();
            var modernChair1 = modernFurniture.CreateChair(true);
            var modernChair2 = modernFurniture.CreateChair();

            var modernSofa1 = modernFurniture.CreateSofa("1/2",true);
            var modernSofa2 = modernFurniture.CreateSofa();

            Console.WriteLine(modernChair1.GetType());
            Console.WriteLine(modernChair2.GetType());
            Console.WriteLine(modernSofa1.GetType());
            Console.WriteLine(modernSofa2.GetType());

            var victorianurniture = new VictorianFurniture();
            var victorianChair1 = victorianurniture.CreateChair("Couro", true);
            var victorianChair2 = victorianurniture.CreateChair();

            var victorianSofa1 = victorianurniture.CreateSofa("1/2");
            var victorianSofa2 = victorianurniture.CreateSofa();

            Console.WriteLine(victorianChair1.GetType());
            Console.WriteLine(victorianChair2.GetType());
            Console.WriteLine(victorianSofa1.GetType());
            Console.WriteLine(victorianSofa2.GetType());

            Console.ReadKey();
        }
```

<p><b>Saída</b>:</p>

> <p>Hello World!</p>
> <p>Esta é uma cadeira Moderna modelo simples</p>
> <p>Esta é uma cadeira Moderna com um modelo inovador</p>
> <p>Este é um Sofá Moderno retrátil, com o tamanho 1/2 m</p>
> <p>Este é um Sofá Moderno</p>
> <p>Esta é uma cadeira Vitoriana de textura Couro e com acabamento metálico</p>
> <p>Esta é uma cadeira Vitoriana de textura tecido e com acabamento de madeira</p>
> <p>Este é um Sofá Vitoriano, com o tamanho 1/2 m</p>
> <p>Este é um Sofá Vitoriano</p>

<p>Use o Abstract Factory quando seu código precisar trabalhar com várias famílias de produtos relacionados, mas você não deseja que ele dependa das classes concretas desses produtos</p>

# Estrutural

<p>Refere-se a mecanismos para montar objetos em estruturas maiores, organizando a estrutura das classes e o relacionamento entre elas, mantendo as estruturas flexiveis e eficientes.</p>

 * Adaptador(adapter)
 * Decorador(decorator)
 * Ponte(bridge)
 * Fachada(facade)
 * Proxy
 * Composto(composite)
 * Flyweight

# Adaptador(adapter)

<p><b>O que é</b>: O padrão Adaptador é um padrão de designt estrutural que permite a colaboração de objetos com interfaces incompatíveis, permite envolver um objeto incompatível em um adaptador para torná-lo compatível com outra classe.</p>

<p><b>Exemplo do mundo real</b>:</p>

> Imagine que você compre um notebook da Europa, ao chegar aqui no Brasil, você vai coloca-lo para carregar, mas tem uma surpresa, o plugue da tomada não se encaixa para as tomadas aqui no Brasil. Você precisará comprar um adaptador de tomada do padrão europeu para o brasileiro

<p><b>Problema</b>: Imagine que o aplicativo do seu cliente receba somente os dados no formato de XML para executar as operações, porém, para melhorar o seu aplicativo, você irá integra-lo com uma outra biblioteca que receba os dados somente no formato JSON, você poderia tentar alterar a biblioteca para trabalhar com dados no formato XML, porém você corre o risco de quebrar algum código existente que depende da biblioteca</p>


<p><b>Solução</b>: Você precisa criar um adaptador que realiza a conversão da interface de um objeto para que o outro possa entende-lo, este objeto de adaptador irá ocultar a complexidade que ocorre para ser convertido os dados. Para realizar a implementação devemos ter como base que <b>ITarget</b> é a interface usada pelo cliente pata atingir a funcionalidade, <b>Adaptee</b> é a classe que possui a funcionalidade exigida pelo cliente, <b>Adapter</b> é a classe que implementa o ITarget e herda a classe Adaptee, este fará a comunicação entre o Client e o Adaptee, e por fim, Client que é a clase que interage com o ITarget, no nosso caso será a classe Main</p>

<p>Para o nosso exemplo, foi criado uma classe para realizar o envio de email, onde o nosso request não é compatível com a classe de adaptee</p>


<p>Primeiro iremos criar o nosso Adaptee</p>
 
```c#
    public class EmailAdapteeRequest
    {
        public EmailAdapteeRequest(string email, string bodyJson)
        {
            Email = email;
            BodyJson = bodyJson;
        }

        public string Email { get; set; }
        public string BodyJson { get; set; }
    }
    
    
    public class EmailAdaptee
    {
        public void SendEmail(EmailAdapteeRequest emailRequest)
        {
            Console.WriteLine(emailRequest.Email);
            Console.WriteLine(emailRequest.BodyJson);
        }

    }
    
```


<p>Feito isso, iremos criar um model para Email, para que não seja compatível com o esperado no método SendEmail(isso é somente para fazer sentido o nosso exemplo)</p>

```c#
    public class Email
    {
        public Email(string address, BodyEmail body)
        {
            Address = address;
            Body = body;
        }

        public string Address { get; set; }
        public BodyEmail Body { get; set; }

    }
    
    public class BodyEmail
    {
        public BodyEmail(string subject, string body)
        {
            Subject = subject;
            Body = body;
        }

        public string Subject { get; set; }
        public string Body { get; set; }

    }
```

<p>Feito isso nos deparamos com o problema... Nosso model é do tipo Email e o nosso Adaptee espera o tipo EmailAdapteeRequest e também as propriedades são incompatíveis, o nosso body em Email é um objeto enquanto o body em EmailAdapteeRequest é uma string(JSON). Com isso, iremos criar o nosso ITarget a interface utilizada pelo client para atingir a funcionalidade do nosso Adaptee</p>

```c#
    public interface IEmailAdapter
    {
        void SendEmail(Email email);
    }
```

<p>Criamos a nossa interface IEmailAdapter(ITarget), agora precisaremos criar a nossa classe Adapter que irá implementar o método SendEmail e enviar para o método SendEmail do nosso Adaptee, observe que os requests são diferentes, quem é responsável por fazer esta conversão é a nossa classe Adapter<p/>

```c#
    public class EmailAdapter : EmailAdaptee, IEmailAdapter
    {
        public void SendEmail(Email email)
        {
            var emailRequest = new EmailAdapteeRequest(email.Address, JsonConvert.SerializeObject(email.Body));
            base.SendEmail(emailRequest);
        }
    }
```
<p>Nossa classe EmailAdapter(Adapter) herda de Adaptee e herda de ITarget, realiza a conversão do tipo de request e envia para o nosso Adaptee</p>

<p>Feito isso é somente realizar a chamada do nosso Client(Main)</p>


```c#
      static void Main(string[] args)
      {
          var email = new Email("gustavo.braga10@outlook.com", new BodyEmail("teste adapter", "corpo do email"));
          var emailAdapter = new EmailAdapter();
          emailAdapter.SendEmail(email);
          Console.ReadKey();
      }
```

<p><b>Saída</b>:</p>

> <p>gustavo.braga10@outlook.com</p>
> <p>{"Subject":"teste adapter","Body":"corpo do email"}</p>

<p>Use a classe Adapter quando desejar usar alguma classe existente, mas sua interface não é compatível com o restante do seu código. O adaptador permite criar uma camada intermediária que serve como tradutor entre as classes.</p>


# Decorador(decorator)

<p><b>O que é</b>: O Decorador é um padrão de design estrutural que permite anexar novos comportamentos aos objetos, permite alterar dinamicamente o comportamento de um objeto em tempo de execução, envolvendo-os em um objeto de uma classe decoradora.</p>

<p><b>Exemplo do mundo real</b>:</p>

> Imagine que você administra uma Cafeteria que oferece vários tipos diferentes de café, café expresso, café com leite, café mocha e também vários tipos de ingredientes, chocolate, chantilly, etc... Você escolhe um tipo de café e vai adicionando dinamicamente os itens desejados, os preços dos produtos iram alterando até obter o custo final. Aqui cada tipo de ingrediente é um decorador.

<p><b>Problema</b>: Você precisa adicionar um comportamento ou estado a objetos individuais em tempo de execução, porém a herança não é viável porque é estática, você não pode alterar o comportamento de um objeto existente no tempo de execução. Você só pode substituir o objeto inteiro por outro criado a partir de uma subclasse diferente</p>

<p><b>Solução</b>: Uma das maneiras de superar essas advertências é usando Agregação(significa que a parte pode ser compartilhada entre vários objetos. O objeto de A contém os objetos de B, B pode viver sem A) ou Composição(significa que a parte não existe sem o todo. O objeto A consiste nos objetos B, um gerencia o ciclo de vida de B, B não pode viver sem A) em vez de herança. Com esta abordagem você consegue substituir o objeto auxiliar vinculando por outro, alterando o comportamento do container em tempo de execução. Um objeto pode usar o comportamento de várias classes, tendo referências a vários objetos e delegando a eles todos os tipos de trabalho.</p>

<p>Para o nosso exemplo será criado um programa semelhante ao da cafeteria, porém uma pizzaria, onde criamos a pizza e adicionamos uma cobertura(ingrediente) extra. Para desenvolver o padrão decorador, temos que ter em mete que. <b>Component</b> é uma interface que contém os membros que serão implementados pela ConcreteClass e Decorator, <b>Decorator</b> é uma classe abstrata que implementa a interface Component e contém a referencia a uma instância Component, esta classe atua como classe base para todos os decoradores de Component, <b>ConcreteComponent</b> esta é uma classe concreta que imlementa a interface Component, <b>ConcreteDecorator</b> esta é a classe que herda de Decorator e fornece um decorador aos components</p>

<p>Inicialmente vamos criar o nosso Component IOrder(porque nossa pizza é um "pedido")</p>
 
 ```c#
    public interface IOrder
    {
        double GetPrice();
        string GetLabel();
    }
 ```
 
 <p>Agora vamos Criar o nosso ConcreteComponent(que é nossa pizza), lembrando que esta deve herdar de Component(IOrder)</p>
 
  ```c#
 public class Pizza : IOrder
    {
        public Pizza(string label, double price)
        {
            Label = label;
            Price = price;
        }

        public string Label { get; set; }
        public double Price { get; set; }
        public double GetPrice()
        {
            return Price;
        }

        public string GetLabel()
        {
            return Label;
        }
    }
 ```
 
 <p>Certo, agora iremos criar o nosso Decorator que será a nossa classe base para criação dos decoradores, esta também deve herdar de IOrder</p>
 
 ```c#
    public abstract class Extra : IOrder
    {
        protected readonly IOrder _order;
        protected readonly string _label;
        protected readonly double _price;

        public Extra(IOrder order, string label, double price)
        {
            _order = order;
            _label = label;
            _price = price;
        }

        public abstract double GetPrice();

        public string GetLabel()
        {
            return $"{_order.GetLabel()}, {_label}";
        }
    }
 ```
 
 <p>Feito isso, é só ir criando os ConcreteDecorator, cada um deve herdar do nosso Decorator(Extra), com isso é possível "incrementar" o nosso objeto Pizza</p>
 
 ```c#
    public class ExtraCover : Extra
    {
        public ExtraCover(IOrder order, string label, double price) : base(order, label, price)
        {
        }

        public override double GetPrice()
        {
            return _order.GetPrice() + _price;
        }
    }
 ```
 
  <p>Agora é só realizar a chamada do ConcreteComponent primeiramente e depois do ConcreteDecorator</p>
  
   
 ```c#
        static void Main(string[] args)
        {
            Console.WriteLine("Hello World!");
            IOrder pizza = new Pizza("Frango", 21);
            pizza = new ExtraCover(pizza, "catupiry", 8);
            Console.WriteLine(pizza.GetLabel());
            Console.WriteLine(pizza.GetPrice());
            Console.ReadKey();
        }
 ```
 
 <p><b>Saída</b>:</p>

> <p>Hello World!</p>
> <p>Frango, catupiry</p>
> <p>29</p>

<p>Use o padrão Decorator quando precisar atribuir comportamentos extras a objetos em tempo de execução sem quebrar o código que usa esses objetos. Use o padrão quando for estranho ou impossível estender o comportamento de um objeto usando herança.</p>
 
 # Ponte(bridge)
 
 <p><b>O que é</b>: Bridge é um padrão de design estrutural que permite dividir uma classe grande ou um conjunto de classes estreitamente relacionadas em duas hierarquias separadas - abstração e implementação - que podem ser desenvolvidas independentemente uma da outra. O padrão de bridge é referente a composição da herança, os detalhes da implementação são transferidos para uma hierarquia separada</p>
 
 <p><b>Problema</b>: Digamos que você precise criar uma página com diferentes tipos de tema light/dark. Inicialmente você precisaria criar uma cópia de cada página para cada um dos seus temas. Utilizando o padrão de bridge, permite que você crie apenas um tema separado e carregue-o com base na preferência do usuário.</p>
 
 <p><b>Solução</b>: O padrão de bridge tenta resolver esse problema alternando da herança para a composição do objeto. Isso significa que é extraido uma das dimensões em uma hierarquia de classes separada, para que as classes originais façam referência a esse objeto da nova hierarquia</p>
 
 <p>Para o padrão bridge temos que ter em mente que <b>Abstraction</b> é a classe abstrata que contém os membros que definem um objeto de negócio abstrato e suas funcionalidades, ele contém a referência para o objeto do tipo Bridge, <b>Bridge</b> é uma interface que atua como uma ponte entre a classe de abstração e as classes do implementador, <b>RedefinedAbstraction</b> esta é a classe que herda de Abstraction e <b>ImplementationClass</b> são as classes que implementam bridge.</p>
 
 <p>Para o nosso exemplo foi criado uma classe de repositório simples onde faremos a conexão(fake) com um banco relacional e outro não relacional.</p>
 
  <p>Vamos a criação dos models, Cliente e Produto</p>
  
  ```c#
    public class Client
    {
        public Client(string name, int age)
        {
            Name = name;
            Age = age;
        }

        public int Id { get; set; }
        public string Name { get; set; }
        public int Age { get; set; }

        public override string ToString()
        {
            return $"Id: {Id}, Nome: {Name}, Idade: {Age}";
        }

    }
    
    
    public class Product
    {
        public Product(string description)
        {
            Description = description;
        }

        public int Id { get; set; }
        public string Description { get; set; }

        public override string ToString()
        {
            return $"Id: {Id}, Descrição: {Description}";
        }
    } 
    
  ```
 
<p>Agora, vamos criar a nossa interface de Bridge(IConnectionDataBase)</p>

  ```c#
    public interface IConnectionDataBase
    {
        void OpenConnection(string connectionString);
        void CloseConnection();
    }
  ```
  
<p>Com a interface de Bridge criada, conseguimos criar os ImplementationClass que são os nossos objetos para realizar a conexão com o banco relacional ou não relacional</p>
  
```c#
    public class SqlConnection: IConnectionDataBase
    {
        public void OpenConnection(string connectionString)
        {
            Console.WriteLine($"Abre conexão com banco de dados SQL {connectionString}");
        }

        public void CloseConnection()
        {
            Console.WriteLine($"Fecha conexão com banco de dados SQL");
        }
    }
    
    
    public class NoSqlConnection : IConnectionDataBase
    {
        public void OpenConnection(string connectionString)
        {
            Console.WriteLine($"Abre conexão com banco de dados NoSQL {connectionString}");
        }

        public void CloseConnection()
        {
            Console.WriteLine($"Fecha conexão com banco de dados NoSQL");
        }
    }
```

<p>Com isto, é suficiente para criarmos a nossa classe Abstraction que é a classe que terá a referência para a interface de Bridge(IConnectionDataBase)</p>

```c#
    public class RepositoryBase
    {
        protected readonly IConnectionDataBase _connectionDataBase;

        public RepositoryBase(string connectionString, IConnectionDataBase connectionDataBase)
        {
            ConnectionString = connectionString;
            _connectionDataBase = connectionDataBase;
        }

        protected string ConnectionString { get; set; }
    }
```

<p>Quase pronto, agora precisamos criar as classes de RedefinedAbstraction que são as classes que implementarão a classe de Abstraction(RepositoryBase). Foi criado uma outra interface para IRepository devido ao método comum de Insert<p>

```c#
    public interface IRepository<T>
    {
        int Insert(T entity);
    }
```

<p>Agora será feito a implementação das duas RedefinedAbstraction uma para cada model<p>
 
```c#
    public class ClientRepository : RepositoryBase, IRepository<Client>
    {
        public ClientRepository(string connectionString, IConnectionDataBase connectionDataBase) : base(connectionString, connectionDataBase)
        {
        }

        public int Insert(Client entity)
        {
            _connectionDataBase.OpenConnection(ConnectionString);
            entity.Id = new Random().Next(0, 100);
            Console.WriteLine($"inserido cliente {entity.ToString()}");
            _connectionDataBase.CloseConnection();
            return entity.Id;
        }
    }
    
    
    public class ProductRepository : RepositoryBase, IRepository<Product>
    {
        public ProductRepository(string connectionString, IConnectionDataBase connectionDataBase) : base(connectionString, connectionDataBase)
        {
        }

        public int Insert(Product entity)
        {
            _connectionDataBase.OpenConnection(ConnectionString);
            entity.Id = new Random().Next(0, 100);
            Console.WriteLine($"inserido Produto {entity.ToString()}");
            _connectionDataBase.CloseConnection();
            return entity.Id;
        }
    }
```
<p>Tudo pronto, agora só precisamos realizar a chamada e passar qual tipo de conexão queremos para qual repositório</p>

```c#
   static void Main(string[] args)
   {
       Console.WriteLine("Hello World!");
       var client = new Client("Gustavo", 23);
       var connectionStringSql = "connectionStringBancoRelacional";
       var sqlConnection = new SqlConnection();
       var clientRepository = new ClientRepository(connectionStringSql, sqlConnection);
       clientRepository.Insert(client);

       var product = new Product("Martelo");
       var connectionStringNoSql = "connectionStringBancoNÃORelacional";
       var noSqlConnection = new NoSqlConnection();
       var productRepository = new ProductRepository(connectionStringNoSql, noSqlConnection);
       productRepository.Insert(product);

       Console.ReadKey();
   }
```

 <p><b>Saída</b>:</p>

> <p>Hello World!</p>
> <p>Abre conexao com banco de dados SQL connectionStringBancoRelacional</p>
> <p>inserido cliente Id: 21, Nome: Gustavo, Idade: 23</p>
> <p>Fecha conexao com banco de dados SQL</p>
> <p>Abre conexao com banco de dados NoSQL connectionStringBancoNAORelacional</p>
> <p>inserido Produto Id: 69, Descriçao: Martelo</p>
> <p>Fecha conexao com banco de dados NoSQL</p>

<p>Use o padrão Bridge quando desejar dividir e organizar uma classe monolítica que tenha várias variantes de algumas funcionalidades (por exemplo, se a classe puder trabalhar com vários servidores de banco de dados). Use o padrão quando precisar estender uma classe em várias dimensões ortogonais (independentes) ou quando precisar alternar a implementação em tempo de execução.</p> 
 
 # Fachada(facade)
 
 <p><b>O que é</b>: Facade é um padrão de design estrutural que fornece uma interface simplificada referente a uma biblioteca, estrutura ou um conjunto complexo de classes. Em outras palavras o padrão facade fornece uma interface simplificada para um subsistema complexo</p>
 
 <p><b>Problema</b>: Imagine que você precise realizar uma operação e deva consumir uma biblioteca onde há um amplo conjunto de objetos ou estrutura sofisticada, qua precisa inicializar todos os objetos, acompanhar as depêndencias, executar métodos em ordem, assim por diante. Essas bibliotecas são muito complexas, com muito código de difícil compreensão e a única coisa que você deseja é consumir um determinado recurso, você precisa conhecer toda a estrutura interna e os recursos disponíveis para simplismente executar uma operação.</p>
 
 <p><b>Solução</b>: O Facade é uma classe que fornece uma interface simples para esse subsistema complexo, onde é possível extrair as funcionalidades que o cliente realmente precisa se preocupar. Com ele é possível abstrair/simplificar essa complexidade, fazendo com que o desenvolvedor não precise conhecer toda arquitetura por trás da biblioteca, é possível desacoplar o sistema, favorecendo a separação de responsabilidades, possível reduzir dependências e "esconder" o código sujo, inviável de refatorar.</p>
 
 <p>Para realizar a implementação do facade devemos ter em mente que <b>Facade</b> é uma classe de wrapper(trata-se de classes que empacotam tipos primitivos) onde contém um conjunto de membros exigidos pelo cliente</p>

<p>Para o nosso exemplo foi criado um sistema bem simples onde será construido um carro, onde CarModel executa um método, CarBody outro e CarAcessories outro, esse contexto é muito simples para a necessidade real do Facade, porém, podemos imaginar que dentro desses métodos há estruturas muito complexas e impossíveis de compreender 100% em pouco tempo, iremos utilizar o Facade aqui, para abstrair a complexidade que há dentro desses métodos e fornecer uma estruturas simples para o cliente criar um carro completo, sem a necessidade de saber que é necessário executar a classe SetModel, depois SetBody e por ultimo a classe SetAcessories, com o facade ele atinge o objetivo de criar o carro completo, simplesmente através do método CreateCompleteCar.</p>

<p>Para iniciar o desenvolvimento, vamos a criação das nossas classes para a construção do carro</p>

```c#
    public class CarBody
    {
        public void SetBody()
        {
            Console.WriteLine("Body");
        }
    }
    
    public class CarModel
    {
        public void SetModel()
        {
            Console.WriteLine("Model");
        }
    }
    
    public class CarAcessories
    {
        public void SetAcessories()
        {
            Console.WriteLine("Acessories");
        }
    }
```

<p>Queremos esconder este código complexo para a criação do carro, então criaremos o CarFacade e iremos expor o método para criação do carro.</p>

```c#

public class CarFacade
    {
        public CarModel CarModel { get; set; }
        public CarBody CarBody { get; set; }
        public CarAcessories CarAcessories { get; set; }

        public CarFacade()
        {
            CarModel = new CarModel();
            CarBody = new CarBody();
            CarAcessories = new CarAcessories();
        }

        public void CreateCompleteCar()
        {
            CarModel.SetModel();
            CarBody.SetBody();
            CarAcessories.SetAcessories();
        }


    }
  
```

<p>Certo. Com isso temos o nosso objeto de Facade onde conseguiremos através de um método simples criar o nosso carro, sem precisarmos saber que há a necessidade de criar três outras classes para isso.</p>

- Deve-se tomar muito cuidado ao implementar esse pattern, para que você não crie um God Class(Classe Deus, uma classe que sabe demais ou faz demais, em engenharia de software é reconhecido como anti padrão).

<p>Feito isso é só realizar a chamada da nossa Facade.</p>

```c#
        static void Main(string[] args)
        {
            Console.WriteLine("Hello World!");
            var facade = new CarFacade();
            facade.CreateCompleteCar();
            Console.ReadKey();
        }
```

 
 <p><b>Saída</b>:</p>

> <p>Hello World!</p>
> <p>Model</p>
> <p>Body</p>
> <p>Acessories</p>

<p>Use o padrão Fachada quando precisar ter uma interface limitada, mas direta, para um subsistema complexo, quando desejar estruturar um subsistema em camadas.</p>

# Proxy

<p><b>O que é</b>: Proxy é um padrão de design estrutural que representa a funcionalidade de uma outra classe. Um proxy controla o acesso ao objeto original, permitindo que você execute algo antes ou depois que a solicitação chega ao objeto original. É responsável por fornecer um espaço reservado na memória para um outro objeto.</p>
 
- Com o proxy nós conseguimos aplicar lógicas antes ou depois da lógica primária da classe, o proxy permite fazer estas implementações sem alterar a sua classe original. O proxy implementa a mesma interface que a classe original então ela pode ser passada para qualquer cliente que espera um objeto real.


<p><b>Implementação </b>: O padrão Proxy sugere que você crie uma nova classe de proxy com a mesma interface que um objeto de serviço original, para realizar a implementação, devemos ter em mente que: <b>Subject</b> Essa é uma interface com membros que serão implementados pelas classes RealSubject e Proxy, <b>RealSubject</b> esta é a classe original em que o proxy ira atuar, e <b>Proxy</b> esta é a classe que contém a instancia da RealSubject e pode acessar seus membros conforme necessário</p>

<p>Para o nosso exemplo foi criado uma classe de repositório simples onde iremos salvar o produto e o log do produto</p>

<p>Irei iniciar criando a minha classe model</p>

```c#
    public class Product
    {
        public Product(string name)
        {
            Name = name;
        }

        public int Id { get; set; }
        public string Name { get; set; }
    }
```

<p>Agora irei implementar a interface do repositório para produto e para o log do produto</p>

```c#
    public interface IProductRepository
    {
        int Insert(Product product);
    }
    
    public interface IProductLogRepository
    {
        int Insert(Product product);
    }  
```

<p>Agora a classe concreta</p>

```c#
    public class ProductRepository: IProductRepository
    {
        public int Insert(Product product)
        {
            product.Id = new Random().Next(1, 300);
            Console.WriteLine($"Produto inserido = id: {product.Id}, name: {product.Name}");
            return product.Id;
        }
    }


    public class ProductLogRepository : IProductLogRepository
    {
        public int Insert(Product product)
        {
            Console.WriteLine($"Produto Log inserido = id: {product.Id}, name: {product.Name}");
            return product.Id;
        }
    }
    
```

<p>Feito isso, já conseguimos criar a nossa classe de proxy, vamos levar em conta que. RealSubject é a nossa classe ProductRepository, o nosso proxy irá atuar em cima dela, executando uma operação antes de inserir o produto e após inserir, o nosso proxy será responsável por salvar o log de produto que é implemetado na classe ProductLogRepository</p>

<p>Implementando o proxy</p>

```c#
    public class ProxyProductRepository : IProductRepository
    {
        public IProductLogRepository _productLogRepository = new ProductLogRepository();
        public IProductRepository _productRepository = new ProductRepository();


        public int Insert(Product product)
        {
            Console.WriteLine("Iniciando proxy");
            product.Id = _productRepository.Insert(product);

            _productLogRepository.Insert(product);
            Console.WriteLine("Finalizando proxy");
            return product.Id;
        }
    }
```

<p>Observe que ele possui a mesma interface que o RealSubject, ele também possui as variáveis para ProductRepository e ProductLogRepository que devem ser atribuidas via injeção de dependência(ela não foi realizada devido não ter impacto para o entendimento do padrão). Observe que dentro da classe Insert somos livres para implementar os algorítmos necessários para o nosso problema</p>

<p>Agora fica muito mais fácil, e é somente criar o nosso produto e chamar a nossa classe de proxy ProxyProductRepository. Aqui irei realizar as duas chamadas para podermos visualizar melhor, uma chamando somente a classe ProductRepository e a outra chamando o nosso ProxyProductRepository<p>
 
 ```c#
        static void Main(string[] args)
        {
            Console.WriteLine("Hello World!");
            var product1 = new Product("Produto 1");

            var productRepository = new ProductRepository();
            productRepository.Insert(product1);

            var product2 = new Product("Produto 2");
            var proxyProductRepository = new ProxyProductRepository();
            proxyProductRepository.Insert(product2);

            Console.ReadKey();
        }
 ```
 
 <p><b>Saída</b>:</p>
 
> <p>Hello World!</p>
> <p>Produto inserido = id: 239, name: Produto 1</p>
> <p>Iniciando proxy</p>
> <p>Produto inserido = id: 197, name: Produto 2</p>
> <p>Produto Log inserido = id: 197, name: Produto 2</p>
> <p>Finalizando proxy</p>

 <p>Use a classe de proxy quando quiser realizar o controle de acesso(é quando você deseja que apenas clientes específicos possam usar o objeto de serviço). Execução local de um serviço remoto(quando o objeto de serviço está localizado em um servidor remoto). Solicitações de log(quando você deseja manter um histórico de solicitações para o objeto de serviço). Resultados da solicitação de armazenamento em cache(quando você precisa armazenar em cache os resultados das solicitações do cliente e gerenciar o ciclo de vida desse cache, especialmente se os resultados forem muito grandes).</p>


# Composto(composite)

<p><b>O que é</b>: Composto é um padrão de design estrutural que permite compor objetos em estruturas de árvores e trabalhar com essas estruturas como se fossem objetos individuais. O padrão composto descreve que um grupo de objetos deve ser tratado da mesma maneira que uma única instância de um objeto, a intenção deste patern é "compor" os objetos em estruturas de árvores para representar hierarquias de partes inteiras.</p>

<p><b>Problema</b>: Imagine que você tenha dois tipos de objetos, Produtos e Caixas, cada caixa pode conter vários produtos e cada produto pode conter várias caixas, que por sua vez pode conter vários outros produtos ou até mesmo várias outras caixas. Imagine que você deseja identificar o saldo total da sua caixa, a abordagem direta seria acessar cada caixa e verificar o valor de cada produto, porém isso pode não ser tão simples.</p>


<p><b>Solução</b>: O padrão Composto compõe objetos em termos de uma estrutura em árvore para representar partes e hierarquias inteiras. O maior benefício é que você não precisa se preocupar com as classes concretas de objetos que compõem a árvore, você pode tratá-los da mesma forma através da interface.</p>

<p>Para realizar a implementação, precisamos ter em mente que <b>Component</b> é a classe abstrata que contém os membros que serão implementados pela hierarquia(atua como classe base para todos), <b>Leaf</b> é usado para implementar componentes de folha na estrutura da árvore, estar nao podem ter filhos e <b>Composite</b> esta é a classe que inclui os métodos para adicionar, remover, consultar, é aqui que são executadas as operações nos componentes filhos</p>

<p>Para o nosso exemplo foi criado um cenário simples, onde temos os dados de uma empresa, funcionários, departamentos, setores e sede da empresa. Aqui criamos a estrutura de árvore da seguinte maneira, nossa interface IEmployee é a nossa folha(Leaf), todos os funcionários irão implementar esta interface. Foi criado um CompanyMember para que seja nosso objeto Component(classe base) o mesmo implementa a interface IEmployee e também possui os métodos de adicionar, remover, possui os métodos adquados para o seu negócio. Os nossos objetos de Composit serão CompanySector, CompanyDepartment e CompanyHeadquarters, observe que essas classes herdam de CompanyMember que é o nosso Composit, a lógica para este cenário é que, uma lista de funcionários pode estar em um setor, uma lista de setor(com funcionários) pode estar dentro de uma lista de Departamentos(com mais funcionários) e a lista de departamentos com a lista de setores, podem estar dentro da sede da empresa que pos rua vez também possui N funcionários.</p>

<p>Vamos a implementação, primeiramente, criaremos a nossa Leaf(IEmployee)
 
 ```c#
    public interface IEmployee
    {
        decimal GetSalary();
        void Show();
    }
 ```
 
<p>Agora iremos criar as nossas classes de funcionários(para o exemplo deixarei somente um, mas você pode consultar o exemplo completo aqui "link_para_models")</p>

```c#
    public class Developer : IEmployee
    {
        public Developer(string name, decimal salary, IEnumerable<string> skills)
        {
            Name = name;
            Salary = salary;
            Skills = skills;
        }

        public string Name { get; set; }
        public decimal Salary { get; set; }
        public IEnumerable<string> Skills { get; set; }

        public decimal GetSalary()
        {
            return Salary;
        }

        public void Show()
        {
            Console.WriteLine($"Desenvolvedor: Nome: {Name}, Saláio: {Salary}, Habilidades: {string.Join(", ", Skills)}");
        }
    }
```
 
<p>Feito isso, iremos criar nossa classe de Component(CompanyMember) a mesma implementa a interface de Leaf(IEmployee)</p>

```c#
    public abstract class CompanyMember : IEmployee
    {
        public abstract string Description { get; set; }

        public abstract decimal GetSalary();
        public abstract void Show();
        public abstract void AddMember(IEmployee employee);
        public abstract void AddRangeMember(IEnumerable<IEmployee> employees);
    }
```

<p>Tudo certo até aqui. Agora, com isso, ja temos o necessário para implementarmos o nosso composit(para o exemplo deixarei somente um, mas você pode consultar o exemplo completo aqui "link_para_classe_composit")</p>

```c#
    public class CompanyDepartment: CompanyMember
    {
        private List<IEmployee> _companyMembers { get; set; }

        public CompanyDepartment(string description)
        {
            Description = description;
            _companyMembers = new List<IEmployee>();
        }

        public override string Description { get; set; }

        public override decimal GetSalary()
        {
            return _companyMembers.Sum(x => x.GetSalary());
        }

        public override void AddMember(IEmployee employee)
        {
            _companyMembers.Add(employee);
        }
        public override void AddRangeMember(IEnumerable<IEmployee> employees)
        {
            _companyMembers.AddRange(employees);
        }

        public override void Show()
        {
            Console.WriteLine($"Departamento: {Description}");
            foreach (var item in _companyMembers)
            {
                item.Show();
            }
        }
    }

```

<p>Observe que esta classe possui uma lista de Leaf, os métodos de adicionar e obter salário, é feito com base nesta lista(para ficar mais claro, a classe Component(CompanyMember) seria o tronco da árvore, a classe Composit(CompanyDepartment) seria os galhos e a interface Leaf(IEmployee) seria nossas folhas).</p>

<p>Feito isso, agora conseguimos adicionar os funcionários aos departamentos/setores/sede, também conseguimos adicionar setores dentro de departamentos e departamentos dentro de sede. Com base no nosso CompanyMember iremos conseguir trabalhar com toda esta estrutura, de maneira simples. Abaixo eta o exemplo utilizando todos os recursos do nosso CompanyMember.</p>

```c#
   class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("Hello World!");
            var randomSalary = new Random();
            var dev1 = new Developer("Lucas", GetRamdomSalary(randomSalary), new List<string> { "skill1", "skill2", "skill3", "skill4" });
            var dev2 = new Developer("Bruno", GetRamdomSalary(randomSalary), new List<string> { "skill1", "skill2", "skill3" });
            var dev3 = new Developer("Maria", GetRamdomSalary(randomSalary), new List<string> { "skill1", "skill2" });

            var qa1 = new Developer("Julia", GetRamdomSalary(randomSalary), new List<string> { "skill1", "skill2", "skill3", "skill4" });
            var qa2 = new Developer("Pedro", GetRamdomSalary(randomSalary), new List<string> { "skill1", "skill2", "skill3" });
            var qa3 = new Developer("Lucia", GetRamdomSalary(randomSalary), new List<string> { "skill1", "skill2" });
            var qa4 = new Developer("Roberto", GetRamdomSalary(randomSalary), new List<string> { "skill1", "skill2", "skill5" });

            var sectorDev = new CompanySector("Desenvolvimento");
            sectorDev.AddMember(dev1);
            sectorDev.AddMember(dev2);
            sectorDev.AddMember(dev3);

            var sectorQA = new CompanySector("Qualidade");
            sectorQA.AddMember(qa1);
            sectorQA.AddMember(qa2);
            sectorQA.AddMember(qa3);
            sectorQA.AddMember(qa4);

            var tiDepartment = new CompanyDepartment("Tecnologia da Informação");
            var developerManager = new Manager("Adriana", GetRamdomSalary(randomSalary), "Gerente de Desenvolvimento");
            tiDepartment.AddMember(developerManager);
            tiDepartment.AddMember(sectorDev);

            var qualityAnalystManager = new Manager("Pedro", GetRamdomSalary(randomSalary), "Gerente de Qualidade");
            tiDepartment.AddMember(qualityAnalystManager);
            tiDepartment.AddMember(sectorQA);

            var rhManager = new Manager("Luisa", GetRamdomSalary(randomSalary), "Gerente de RH");
            var rhDepartment = new CompanyDepartment("Recursos Humanos");
            rhDepartment.AddMember(rhManager);

            var director = new Director("Nathália", GetRamdomSalary(randomSalary), "Dona da Empresa");
            var headQuarters = new CompanyHeadquarters("Matriz");
            headQuarters.AddMember(director);
            headQuarters.AddRangeMember(new List<CompanyMember> { rhDepartment, tiDepartment });

            Console.WriteLine($"Salario total: {headQuarters.GetSalary()}");
            headQuarters.Show();
            Console.ReadKey();
        }

        public static int GetRamdomSalary(Random randomSalary)
        {
            return randomSalary.Next(0, 10000);
        }
    }
```

<p><b>Saída</b></p>

> <p>Hello World!</p>
> <p>Salario total: 44087</p>
> <p>Matriz: Matriz</p>
> <p>Diretor: Nome: Nathália, Saláio: 4835, Descriçao: Dona da Empresa</p>
> <p>Departamento: Recursos Humanos</p>
> <p>Gerente: Nome: Luisa, Saláio: 3620, Descriçao: Gerente de RH</p>
> <p>Departamento: Tecnologia da Informaçao</p>
> <p>Gerente: Nome: Adriana, Saláio: 9447, Descriçao: Gerente de Desenvolvimento</p>
> <p>Setor: Desenvolvimento</p>
> <p>Desenvolvedor: Nome: Lucas, Saláio: 6543, Habilidades: skill1, skill2, skill3, skill4</p>
> <p>Desenvolvedor: Nome: Bruno, Saláio: 748, Habilidades: skill1, skill2, skill3</p>
> <p>Desenvolvedor: Nome: Maria, Saláio: 5518, Habilidades: skill1, skill2</p>
> <p>Gerente: Nome: Pedro, Saláio: 611, Descriçao: Gerente de Qualidade</p>
> <p>Setor: Qualidade</p>
> <p>Desenvolvedor: Nome: Julia, Saláio: 4274, Habilidades: skill1, skill2, skill3, skill4</p>
> <p>Desenvolvedor: Nome: Pedro, Saláio: 1931, Habilidades: skill1, skill2, skill3</p></p>
> <p>Desenvolvedor: Nome: Lucia, Saláio: 3251, Habilidades: skill1, skill2</p>
> <p>Desenvolvedor: Nome: Roberto, Saláio: 3309, Habilidades: skill1, skill2, skill5</p>

<p>Use o padrão Composto quando precisar implementar uma estrutura de objeto semelhante a uma árvore, quando desejar que o código do cliente trate elementos simples e complexos de maneira uniforme.</p>

# Flyweight

<p><b>O que é</b>: O Flyweight é um padrão de design estrutural que permite ajustar mais objetos à quantidade disponível de RAM. É usado para minimizar o uso de memória ou as despesas computacionais, compartilhando o máximo possível com objetos semelhantes.</p>

<p><b>Problema</b>: Imagine que você esteja criando um jogo simples para se divertir, porém com vários cenários e vários objetos para melhorar a experiência do usuário. Após você finalizar a implementação, você joga por um tempo, garante que está funcionando e passa o jogo para um amigo, porém seu amigo não consegue jogar por muito tempo, o jogo começa a travar e apresentar erros depois de alguns minutos jogando. Após longas horas de depuração de código, você consegue identificar que o real problema era a quantidade insuficiente de memória RAM do computador do seu amigo, pois os objetos criados para exibir o cenário e seus detalhes, continham muitos dados e isso fez com que a memória RAM não suportasse.</p>

<p><b>Solução</b>: O padrão Flyweight tenta reutilizar objetos dos tipos semelhantes já existentes, armazenando-os e criando um novo objeto quando nenhum correspondente é encontrado. Cada objeto flyweight é dividido em duas partes: a parte dependente do estado (extrínseca) e a parte independente do estado (intrínseca). O estado intrínseco é armazenado (compartilhado) no objeto Flyweight. O estado extrínseco é armazenado ou calculado pelos objetos do cliente e passado para o Flyweight quando suas operações são invocadas. Uma característica importante dos objetos flyweight é que eles são imutáveis, isso significa que eles não podem ser modificados depois de construídos.</p>

<p>Para realizar a implementação, devemos ter em mente que <b>Flyweight</b> é uma interface que define os membros dos objetos flyweight, <b>ConcreteFlyweight</b> são as classes que herdam de flyweight, <b>FlyweightFactory</b> esta é a classe que contém as referências dos objetos flyweights, nesta classe quando for solicitado um objeto, a classe verifica se já possui uma instância e caso não, cria uma e retorne-a.</p>


<p>Para o nosso exemplo, vamos criar o jogo do Counter-Strike, tentando minimizar o uso da memória RAM na criação dos personagens.</p>

<p>Inicialmente vamos criar a nossa interface flyweight, no nosso caso será IPlayer, ela também irá possuir alguns métodos para ser utilizado nos nossos players</p>

```c#
    public interface IPlayer
    {
        void AssignWeapon(string weapon);
        void Mission(string task);
        bool IsTerrorist();
        void Show();
    }
```


<p>Agora, vamos criar os jogadores, CounterTerrorist e Terrorist, estes são nossos ConcreteFlyweight</p>

```c#
    public class CounterTerrorist : IPlayer
    {
        public string TaskPlayer { get; set; }
        private string Weapon { get; set; }

        public void AssignWeapon(string weapon)
        {
            Weapon = weapon;
        }

        public void Mission(string task)
        {
            TaskPlayer = $"Policial deve realizar o objetivo de {task}";
        }
        public bool IsTerrorist()
        {
            return false;
        }

        public void Show()
        {
            Console.WriteLine(TaskPlayer);
            Console.WriteLine($"Possui arma: {Weapon}");
        }
    }
    
    
    public class Terrorist : IPlayer
    {
        public string TaskPlayer { get; set; }
        private string Weapon { get; set; }

        public void AssignWeapon(string weapon)
        {
            Weapon = weapon;
        }

        public void Mission(string task)
        {
            TaskPlayer = $"Terrorista deve realizar o objetivo de {task}";
        }

        public bool IsTerrorist()
        {
            return true;
        }

        public void Show()
        {
            Console.WriteLine(TaskPlayer);
            Console.WriteLine($"Possui arma: {Weapon}");
        }
    }
```

<p>Feito isso, já conseguimos implementar a nossa classe de FlyweightFactory, ela será a PlayerFactory, observe que o método GetPlayer verifica se já existe uma instância de IPlayer no nosso dicionário, caso exista, ele simplesmente irá retornar, caso não exista, será criado uma e adicionado ao nosso dicionário e só ai é retornado para que o chamou.</p>

```c#
    public class PlayerFactory
    {
        public PlayerFactory()
        {
            Players = new Dictionary<string, IPlayer>();
        }

        private Dictionary<string, IPlayer> Players { get; set; }

        public IPlayer GetPlayer(string type)
        {
            if (Players.ContainsKey(type))
                return Players[type];
            else
            {
                switch (type.ToUpper())
                {
                    case "TERRORIST":
                        Players.Add(type, new Terrorist());
                        return Players[type];
                    case "COUNTERTERRORIST":
                        Players.Add(type, new CounterTerrorist());
                        return Players[type];
                    default:
                        throw new KeyNotFoundException();
                }
            }
        }
    }
```

<p>Até aqui, nós conseguimos diminuir o uso da memória para criação dos objetos, pois sempre será fornecido a instancia já criada que está no dicionário, então com isso já concluímos o usso do padrão para o nosso cenário. Para ficar ainda mais legal, irei criar uma classe para representar o mapa do jogador, marcando a posição de cada jogador e também para obter algumas informações sobre a partida como por exemplo quantos são terroristas/policiais.</p>

<p>Será criada a classe PlayersMapFactory, onde terá o dicionário armazenando a posição de cada jogador e os métodos pertinentes ao nosso jogo.</p>

```c#
    public class PlayersMapFactory
    {
        public PlayersMapFactory()
        {
            Players = new Dictionary<int, IPlayer>();
        }

        private Dictionary<int, IPlayer> Players { get; set; }

        public bool AddPlayer(int position, IPlayer player)
        {
            if (Players.ContainsKey(position))
                return false;
            else
                Players.Add(position, player);
            return true;
        }

        public int GetTerrorist()
        {
            return Players.Values.Count(x => x.IsTerrorist());
        }

        public int GetPolice()
        {
            return Players.Values.Count(x => !x.IsTerrorist());
        }

        public void ShowPlayers()
        {
            foreach (var item in Players)
            {
                Console.WriteLine($"Jogador {item.Key}");
                item.Value.Show();
            }
        }
    }
```

<p>Feito isso, iremos realizar as chamadas, para o nosso exemplo não foi adicionado métodos intrínseco(campos que contêm dados imutáveis, duplicados em muitos objetos), foram feito somente métodos extrínsecos(campos que contêm dados contextuais exclusivos para cada objeto). Essa divisão é crucial na hora de implementar o patter flyweight, pois deve-se analisar muito bem para realizar esta separação. Aqui no método Main, foi criado alguns métodos para deixar mais dinâmico a criação dos personagens, como por exemplo o tipo de jogador Terrorist/CounterTerrorist tipo de arma e missões.</p>

```c#
    class Program
    {
        public static string[] PlayerType = { "Terrorist", "CounterTerrorist" };
        public static string[] Weapons = { "AK-47", "AWP", "Desert Eagle", "M4A4", "P90", "SSG 08", "MP7" };
        public static string[] PoliceObjective = { "Desarmar Bomba", "Salvar Reféns" };
        public static string[] TerroristObjective = { "Armar Bomba", "Pegar Reféns" };

        static void Main(string[] args)
        {
            Console.WriteLine("Hello World!");

            var playerFactory = new PlayerFactory();
            var playersMapFactory = new PlayersMapFactory();
            for (int i = 0; i < 10; i++)
            {
                var player = playerFactory.GetPlayer(GetPlayerType());
                player.AssignWeapon(GetWeapons());
                if (player.IsTerrorist())
                    player.Mission(GetTerroristObjective());
                else
                    player.Mission(GetPoliceObjective());

                playersMapFactory.AddPlayer(i+1, player);
            }
            Console.WriteLine($"Terroristas: {playersMapFactory.GetTerrorist()}");
            Console.WriteLine($"Policiais: {playersMapFactory.GetPolice()}");
            playersMapFactory.ShowPlayers();

            Console.ReadKey();
        }

        private static string GetPlayerType()
        {
            return PlayerType[new Random().Next(PlayerType.Length)];
        }

        private static string GetWeapons()
        {
            return Weapons[new Random().Next(Weapons.Length)];
        }
        private static string GetPoliceObjective()
        {
            return PoliceObjective[new Random().Next(PoliceObjective.Length)];
        }
        private static string GetTerroristObjective()
        {
            return TerroristObjective[new Random().Next(TerroristObjective.Length)];
        }
    }
```

<p><b>Saída</b></p>

> <p>Hello World!</p>
> <p>Terroristas: 4</p>
> <p>Policiais: 6</p>
> <p>Jogador 1</p>
> <p>Policial deve realizar o objetivo de Salvar Reféns</p>
> <p>Possui arma: SSG 08</p>
> <p>Jogador 2</p>
> <p>Policial deve realizar o objetivo de Salvar Reféns</p>
> <p>Possui arma: SSG 08</p>
> <p>Jogador 3</p>
> <p>Policial deve realizar o objetivo de Salvar Reféns</p>
> <p>Possui arma: SSG 08</p>
> <p>Jogador 4</p>
> <p>Terrorista deve realizar o objetivo de Pegar Reféns</p>
> <p>Possui arma: MP7</p>
> <p>Jogador 5</p>
> <p>Terrorista deve realizar o objetivo de Pegar Reféns</p>
> <p>Possui arma: MP7</p>
> <p>Jogador 6</p>
> <p>Terrorista deve realizar o objetivo de Pegar Reféns</p>
> <p>Possui arma: MP7</p>
> <p>Jogador 7</p>
> <p>Policial deve realizar o objetivo de Salvar Reféns</p>
> <p>Possui arma: SSG 08</p>
> <p>Jogador 8</p>
> <p>Terrorista deve realizar o objetivo de Pegar Reféns</p>
> <p>Possui arma: MP7</p>
> <p>Jogador 9</p>
> <p>Policial deve realizar o objetivo de Salvar Reféns</p>
> <p>Possui arma: SSG 08</p>
> <p>Jogador 10</p>
> <p>Policial deve realizar o objetivo de Salvar Reféns</p>
> <p>Possui arma: SSG 08</p>

<p>Use o padrão Flyweight apenas quando seu programa precisar suportar um grande número de objetos que mal cabem na RAM disponível.</p>

# Comportamental

<p>Refere-se a mecanismos para atribuir responsabilidades entre os objetos, definindo como os objetos devem se comportar e se comunicar</p>

  * Mediador(mediator)
  * Observador(observer)
  * Cadeia de Responsabilidade(chain of responsibility)
  * Comando(command)
  * Iterador(iterator)
  * Lembrança(memento)
  * Método de Modelo(template method)
  * Estado(state)
  * Estratégia(strategy)
  * Visitante(visitor)

# Mediador(mediator)

<p><b>O que é</b>: Mediator é um padrão de design comportamental que visa reduzir dependências entre objetos, este padão restringe as comunicações diretas entre os objetos e os força a realizar a comunicação apenas através de um objeto mediador. O mediator adiciona um objeto de terceiro para controlar a interação entre os objetos.</p> 
 
 
 <p><b>Problema</b>: Você esta tentando criar componentes reutilizáveis, mas a dependência entre os objetos acabou tornando o fenômeno "código espaguete" tentar pegar uma única porção resulta em um conjunto de tudo ou nada</p>
 
 
 <p><b>Exemplo do mundo real</b>:</p>
 
 > Os pilotos que se aproximam ou partem de uma área de controle de aeroporto não se comunicam diretamente entre si. Em vez disso, eles fazem a comunicação com um controlador de tráfego aéreo, sem esse controlador os pilotos precisariam estar cientes de todos os aviões nas proximidades do aeroporto, discutindo as prioridades de pouso com um comitê de dezenas de outros pilotos. Isso provavelmente dispararia as estatísticas de acidentes de avião.</p>
 
 <p>Para este cenário, o controlador de tráfego é o mediador entre os pilotos.</p>
 
 
 <p><b>Solução</b>: O padrão mediator sugere que você interrompa toda a comunicação direta entre os componentes que deseja tornar independentes um do outro. Em vez disso, esses componentes devem colaborar indiretamente, chamando um objeto mediator especial que redireciona as chamadas para os componentes apropriados. Como resultado, os componentes dependem apenas de uma única classe de mediator em vez de serem acoplados a dezenas de classes.</p>
 
 <p>Para o nosso exemplo foi criado uma cenário de calculadora, onde criamos o request com o tipo de operação e enviamos ao mediator para que através dele, consiga identificar o tipo de request e envie ao service correto. Para implementar este pattern, devemos ter em mente que <b>Mediator</b> é a interfce que define as operações que podem ser chamadas para a comunicação, <b>ConcreteMediator</b> esta é a classe que implementa as operações de comunicação da interface mediator, <b>Colleague</b> esta é uma classe que define um campo protegido que mantém a referência a um objeto mediator, <b>ConcreteColleague</b> estas são as classes se comunicam através do mediator.</p>
 
<p>Vamos a implementação. Primeiramente vamos criar a nossa interface mediator</p>

```c#
    public interface IMediator
    {
        void Send(object send);
    }
```

<p>Após isso, vamos criar o nosso Colleague esta será a classe base para os ConcreteColleague</p>

```c#
    public abstract class BaseComponent
    {
        protected IMediator _mediator;

        public BaseComponent(IMediator mediator)
        {
            _mediator = mediator;
        }

        public void Send()
        {
            _mediator.Send(this);
        }
    }
```

<p>Agora faremos os ConcreteColleague, será criado um para cada operação da calculadora, aqui irei deixar somente dois, mas você pode conferir o exemplo completo clicando "AQUI"</p>

```c#

    public class SumComponent : BaseComponent
    {

        public SumComponent(int firstNumber, int secondNumber, IMediator mediator) : base(mediator)
        {
            FirstNumber = firstNumber;
            SecondNumber = secondNumber;
        }

        public int FirstNumber { get; set; }
        public int SecondNumber { get; set; }
    }
    
    public class MultiplicationComponent : BaseComponent
    {

        public MultiplicationComponent(int firstNumber, int secondNumber, IMediator mediator) : base(mediator)
        {
            FirstNumber = firstNumber;
            SecondNumber = secondNumber;
        }

        public int FirstNumber { get; set; }
        public int SecondNumber { get; set; }
    }
    
```

<p>Feito isso iremos implementar o nosso service com todas as operações necessárias</p>

```c#
    public class SimpleCalculatorService
    {
        public void Sum(SumComponent component)
        {
            Console.WriteLine($"A soma dos valores é {component.FirstNumber}+{component.SecondNumber} = {component.FirstNumber + component.SecondNumber}");
        }

        public void Subtraction(SubtractionComponent component)
        {
            Console.WriteLine($"A subtração dos valores é {component.FirstNumber}-{component.SecondNumber} = {component.FirstNumber - component.SecondNumber}");
        }

        public void Multiplication(MultiplicationComponent component)
        {
            Console.WriteLine($"A multiplicação dos valores é {component.FirstNumber}*{component.SecondNumber} = {component.FirstNumber * component.SecondNumber}");
        }

        public void Division(DivisionComponent component)
        {
            Console.WriteLine($"A divisão dos valores é {component.FirstNumber}/{component.SecondNumber} = {(component.SecondNumber == 0 ? "Inválida.. Divisão por 0" : $"{component.FirstNumber / component.SecondNumber}")}");
        }
    }
```

<p>Com tudo isso implementado, só esta faltando criar o nosso ConcreteMediator, então vamos a implementação</p>

```c#
    public class MultiplicationAndDivisionMediator : IMediator
    {
        private SimpleCalculatorService _simpleCalculatorService = new SimpleCalculatorService();
        public void Send(object send)
        {
            if (send is MultiplicationComponent)
                _simpleCalculatorService.Multiplication((MultiplicationComponent)send);
            else if (send is DivisionComponent)
                _simpleCalculatorService.Division((DivisionComponent)send);
            else
                throw new NotImplementedException();
        }
    }
    
    public class SumAndSubtractionMediator : IMediator
    {
        private SimpleCalculatorService _simpleCalculatorService = new SimpleCalculatorService();
        public void Send(object send)
        {
            if (send is SumComponent)
                _simpleCalculatorService.Sum((SumComponent)send);
            else if (send is SubtractionComponent)
                _simpleCalculatorService.Subtraction((SubtractionComponent)send);
            else
                throw new NotImplementedException();
        }
    }
```

<p>Com tudo isso implementado, agora é só realizar a chamada, só precisamos criar o ConcreteMediator e passar para o nosso ConcreteColleague</p>

```c#
    static void Main(string[] args)
    {
        Console.WriteLine("Hello World!");
        var random = new Random();

        var sumAndSubtractionMediator = new SumAndSubtractionMediator();
        var sum = new SumComponent(random.Next(-10, 100), random.Next(-10, 100), sumAndSubtractionMediator);
        var subtraction = new SubtractionComponent(random.Next(-50, 500), random.Next(-50, 500), sumAndSubtractionMediator);

        sum.Send();
        subtraction.Send();

        var multipicationAndDivisionMediator = new MultiplicationAndDivisionMediator();
        var multiplication = new MultiplicationComponent(random.Next(-20, 200), random.Next(-20, 200), multipicationAndDivisionMediator);
        var division = new DivisionComponent(random.Next(-30, 500), random.Next(-20, 600), multipicationAndDivisionMediator);

        multiplication.Send();
        division.Send();

        Console.ReadKey();
    }
```

 <p><b>Saída</b></p>
 
> <p>Hello World!</p>
> <p>A soma dos valores é 23+3 = 26</p>
> <p>A subtraçao dos valores é -34-206 = -240</p>
> <p>A multiplicaçao dos valores é 8*34 = 272</p>
> <p>A divisao dos valores é 269/91 = 2</p>
 
<p>Use o padrão Mediador quando for difícil alterar algumas das classes porque elas estão fortemente acopladas a várias outras classes,  quando não puder reutilizar um componente em um programa diferente, pois é muito dependente de outros componentes, quando se encontrar criando toneladas de subclasses de componentes apenas para reutilizar algum comportamento básico em vários contextos.</p>
 
# Observador(observer)

<p><b>O que é</b>: Observer é um padrão de design comportamental que permite realizar um mecanismo de assinatura em outro objeto e assim ser notificado sobre quaisquer eventos que ocorram no objeto que esta sendo observado. Define uma dependência entre objetos para que, sempre que um objeto alterar seu estado, todos os seus dependentes sejam notificados. </p>


<p><b>Problema</b>: Imagine que você deseja comprar um celular no modelo X e para isso, você vai a loja todos os dias para saber se o modelo X está disponível, porém a maioria dessas viagens estarão sendo inuteis caso o produto não esteja disponível. Uma outra medida, é a loja notificar todos os clientes, todos os dias sobre os produtos que estão disponíveis, isso iria te salvar de muitas viagens, porém você perderá muito tempo olhando produtos que não são do seu interesse e também a loja iria desperdiçar muitos recursos para notificar clientes que no momento não querem nada.</p>

<p><b>Solução</b>: O padrão observer sugere que você adicione um mecanismo de inscrição a classe onde é possível se inscrever e cancelar a inscrição a qualquer momento, assim você será notificado sobre qualquer alteração da classe.</p>

<p>Para implementar este pattern devemos ter em mente que, <b>Subject</b> é a classe que contém uma lista de observadores inscritos para serem notificados, <b>ConcreteSubject</b> esta é a classe que mantém seu próprio estado, quando ocorrer alguma alteração nela, o objeto chama a operação <b>Notify</b> da classe base(Subject) e notificará todos os seus observadores sobre a alateração, <b>Observer</b> esta é a interface que define uma operação de update que deve ser chamado quando o estado do sujeito for alterado, e por fim, <b>ConcreteObserver</b> esta é a classe que implementa o observador e examina o sujeito para determinar o que é relevante referente a as informações alteradas.</p>

<p>Para o nosso cenário, foi criado um exemplo simples onde o sujeito é uma calculadora que recebe os números e armazena um estado para saber qual operação deve ser realizada, será registrado 4 observadores para monitorar o estado e assim realizar a operação, neste exemplo iremos adicionar e remover os observadores e verificar qual será o resultado.</p>

<p>Para iniciar, vamos implementar a nossa interface IObserver, ela receberá um tipo genérico para que possamos analiza-lo dentro dos observadores</p>

```c#
    public interface IObserver<T>
    {
        void Update(T subject);
    }
```

<p>Após isso, iremos implementar a nossa interface de sujeito, onde terá os métodos para adicionar/remover/notificar os observadores.</p>

```c#
    public interface ISubject<T>
    {
        void Attach(IObserver<T> observer);

        void Detach(IObserver<T> observer);

        void Notify(T entity);
    }
```

<p>Iremos implementar o SubjectBase para que as classes de sujeito consigam herdar dela e utilizar os seus métodos.</p>

```c#
    public abstract class SubjectBase<T> : ISubject<T>
    {
        private IList<IObserver<T>> _observers = new List<IObserver<T>>();
        public void Attach(IObserver<T> observer)
        {
            _observers.Add(observer);
        }

        public void Detach(IObserver<T> observer)
        {
            _observers.Remove(observer);
        }

        public void Notify(T entity)
        {
            foreach (var item in _observers)
                item.Update(entity);
        }
    }
```

<p>Feito isso, iremos implementar a nossa SimpleCalculator(sujeito) e herdar da classe SubjectBase.</p>

```c#
    public class SimpleCalculator: SubjectBase<SimpleCalculator>
    {
        public SimpleCalculator(int firstNumber, int secondNumber)
        {
            FirstNumber = firstNumber;
            SecondNumber = secondNumber;
        }

        public int FirstNumber { get; set; }
        public int SecondNumber { get; set; }
        public Operation Operation { get; set; }
    }


    public enum Operation
    {
        Sum,
        Subtraction,
        Multiplication,
        Division
    }
```
<p>Agora na nossa SimpleCalculator é possível adicionarmos observadores e notificá-los quando alguma mudança ocorrer. Então vamos criar os observadores(irei exemplificar somente dois, mas você pode consultar o exemplo completo clicando "AQUI")</p>

```c#
    public class SumObserver : Interfaces.IObserver<SimpleCalculator>
    {
        public void Update(SimpleCalculator subject)
        {
            if(subject.Operation == Operation.Sum)
                Console.WriteLine($"A soma dos valores é {subject.FirstNumber}+{subject.SecondNumber} = {subject.FirstNumber + subject.SecondNumber}");
        }
    }
    
    public class DivisionObserver : Interfaces.IObserver<SimpleCalculator>
    {
        public void Update(SimpleCalculator subject)
        {
            if (subject.Operation == Operation.Division)
                Console.WriteLine($"A divisão dos valores é {subject.FirstNumber}/{subject.SecondNumber} = {(subject.SecondNumber == 0 ? "Inválida.. Divisão por 0" : $"{subject.FirstNumber / subject.SecondNumber}")}");
        }
    }
```

<p>Agora, para realizar a chamada, precisamos criar o nosso sujeito e irmos adicionando os observadores através do método "Attach", para remover utilizaremos o "Detach" e para notificar utilizaremos o "Notify".</p>

```c#
    static void Main(string[] args)
    {
        Console.WriteLine("Hello World!");
        var random = new Random();
        var subject = new SimpleCalculator(random.Next(-20, 100), random.Next(-10, 50));

        var sum = new SumObserver();
        var multiplication = new MultiplicationObserver();

        subject.Attach(multiplication);
        subject.Attach(sum);

        subject.Attach(new DivisionObserver());
        subject.Attach(new SubtractionObserver());

        Console.WriteLine("\nExemplo sorteando os observadores");
        for (int i = 0; i < 2; i++)
        {
            subject.Operation = (Operation)random.Next(0, 3);
            subject.Notify(subject);
        }

        Console.WriteLine("\nExemplo com todos os observadores");
        for (int i = 0; i < 4; i++)
        {
            subject.Operation = (Operation)i;
            subject.Notify(subject);
        }

        subject.Detach(sum);
        subject.Detach(multiplication);

        Console.WriteLine("\nExemplo após remover os observadores de Soma e Multiplicação");
        for (int i = 0; i < 4; i++)
        {
            subject.Operation = (Operation)i;
            subject.Notify(subject);
        }

        Console.ReadKey();
    }
```

<p><b>Saída</b>:</p>

> <p>Hello World!</p>
> <p></p>
> <p>Exemplo sorteando os observadores</p>
> <p>A subtraçao dos valores é 19-10 = 9</p>
> <p>A multiplicaçao dos valores é 19*10 = 190</p>
> <p></p>
> <p>Exemplo com todos os observadores</p>
> <p>A soma dos valores é 19+10 = 29</p>
> <p>A subtraçao dos valores é 19-10 = 9</p>
> <p>A multiplicaçao dos valores é 19*10 = 190</p>
> <p>A divisao dos valores é 19/10 = 1</p>
> <p></p>
> <p>Exemplo após remover os observadores de Soma e Multiplicaçao</p>
> <p>A subtraçao dos valores é 19-10 = 9</p>
> <p>A divisao dos valores é 19/10 = 1</p>

<p>Utilize o padrão Observer quando mudanças no estado de um objeto podem precisar mudar outros objetos, e o atual conjunto de objetos é desconhecido de antemão ou muda dinamicamente, quando alguns objetos em sua aplicação devem observar outros, mas apenas por um tempo limitado ou em casos específicos.</p>

# Cadeia de Responsabilidade(chain of responsibility)

<p><b>O que é</b>: Cadeia de Responsabilidade é um padrão de design comportamental que visa passar solicitações ao longo de uma cadeia de manipuladores, ao receber uma solicitação, cada manipulador decide se ira processar a informação ou passa-la ao próximo manipulador. Em outras palavras Cadeia de Responsabilidade, ajuda construir uma cadeia de objetos, onde a solicitação entra em um extremidade e continua indo até encontrar um manipulador adequado.</p>

<p><b>Problema</b>: Imagine que você criou um sistema e para ele é necessário fazer uma autenticação, porque somente os clientes autenticados poderiam realizar as operações no sistema. Depois de um tempo você notou que quando alguém tenta realizar a autenticação e a validação falhar, não há motivos para seguir com as validações, depois de um tempo, você foi informado que não é legal passar dados brutos diretamente para o sistema, e então você adicionou mais uma validação extra. Mais tarde alguém lhe informou sobre a quebra de senha de força bruta e imediatamente você adicionou mais uma validação para filtrar as solicitações repeditas de um mesmo IP. O código começou a virar uma bagunça, cada vez mais inchado e mais difícil de manter e entender, quando você tentava reutilizar alguma verificação acaba que você precisa duplicar uma parte do código. Devido a esses problemas a melhor das opções foi refatorar tudo.</p>

<p><b>Solução</b>: O padrão de cadeia de responsabilidade, permite que um objeto envie um comando sem saber qual objeto receberá e irá manipular, a solicitação é enviada de um objeto para o outro tornando-os parte de uma cadeia e a cada iteração o objeto pode manipular o comando ou transmiti-lo a outro, ou até mesmo realizar os dois. Para a implementação, cada verificação deve ser extraída para uma classe e deve possuir um único método que executa a verificação, essas classes são passadas por parâmetro e dentro delas é possível dinamizar se irá interromper a iteração ou se ira seguir para a próxima validação.</p>

<p>Para implementar este pattern devemos ter em mente que <b>Client</b> é a classe que gera a solicitação e passa para o primeiro manipulador da cadeia, <b>Handler</b> é a classe abstrata que contém o membro para armazenar o próximo manipulador da cadeia para ser possível definir os sucessores, esta classe também contém o método que deve ser implementado pelos outros manipuladores para executar as validações, e por fim, temos os <b>ConcreteHandlers</b> estas são as classes concretas que irão herdar da classe handler e executar as validações conforme o seu negócio.</p>

<p>Para o nosso exemplo, foi criado um cenário simples onde verificamos se um número é par/impar/maior que mil</p>

<p>Inicialmente, vamos criar a nossa interface IHandler</p>

```c#
    public interface IHandler
    {
        void Execute(int request);
        IHandler Next(IHandler successor);
    }
```

<p>Feito isso vamos criar nossa classe abstrata Handler</p>


```c#
    public abstract class AbstractHandler : IHandler
    {
        protected IHandler _successor;

        public abstract void Execute(int request);

        public IHandler Next(IHandler successor)
        {
             _successor = successor;
            return this;
        }
    }
```

<p>Observe que ela possui o método next para que seja possível ir para o próximo manipulador da cadeia, e também, possui o método Execute, que irá forçar as subclasses a implementar este método</p>

<p>Agora iremos criar os ConcreteHandlers</p>

```c#
    public class EvenNumber: AbstractHandler
    {
        public override void Execute(int request)
        {
            Console.WriteLine($"Número {request} é par: {(request % 2 == 0?"Sim": "Não")}");
            if (_successor != null)
                _successor.Execute(request);
        }
    }
    
    public class OddNumber: AbstractHandler
    {
        public override void Execute(int request)
        {
            Console.WriteLine($"Número {request} é ímpar: {(request % 2 != 0 ? "Sim" : "Não")}");
            if (_successor != null)
                _successor.Execute(request);
        }
    }
    
    
    public class GreaterThanAThousand:AbstractHandler
    {
        public override void Execute(int request)
        {
            Console.WriteLine($"Número {request} é maior que 1000: {(request > 1000 ? "Sim" : "Não")}");
            if (_successor != null)
                _successor.Execute(request);
        }
    }
```

<p>Observe que em cada método execute é validado se possui um sucessor, e se possuir, passa para o próximo, nesse momento, você é livre para decidir se deverá ou não passar a diante a validação</p>

<p>Agora é só realizar a chamada do método e em cada ConcreteHandler definir quem será o sucessor</p>

```c#
    static void Main(string[] args)
    {
        Console.WriteLine("Hello World!");
        var handler = new EvenNumber()
            .Next(new OddNumber()
            .Next(new GreaterThanAThousand()));

        for (int i = 0; i < 3; i++)
        {
            handler.Execute(new Random().Next(0,9999));
        }


        Console.ReadKey();
    }
```

<p><b>Saída</b>:</p>

> <p>Hello World!</p>
> <p>Número 9091 é par: Nao</p>
> <p>Número 9091 é ímpar: Sim</p>
> <p>Número 9091 é maior que 1000: Sim</p>
> <p>Número 1045 é par: Nao</p>
> <p>Número 1045 é ímpar: Sim</p>
> <p>Número 1045 é maior que 1000: Sim</p>
> <p>Número 5619 é par: Nao</p>
> <p>Número 5619 é ímpar: Sim</p>
> <p>Número 5619 é maior que 1000: Sim</p>


<p>Use o padrão da Cadeia de Responsabilidade quando se espera que seu programa processe diferentes tipos de solicitações de várias maneiras, mas os tipos exatos de solicitações e suas sequências são desconhecidos previamente, quando for essencial executar vários manipuladores em uma ordem específica, quando o conjunto de manipuladores e sua ordem forem alterados no tempo de execução.</p>

# Comando(command)

<p><b>O que é</b>: Command é um padrão de design comportamental que permite encapsular ações em objetos. Fornece um meio para separar o cliente do destinatário. Esta padrão permite encapsular uma solicitação para fazer algo em algum objeto específico, os objetos não sabem quais ações estão sendo executadas, eles apenas visualizam um método "execute" e será executada suas solicitações.</p>

<p><b>Problema</b>: Imagine que você precise emitir uma solicitação para um objeto, porém você não sabe nada sobre a operação solicitada e nem quem é o destinatário dessa solicitação.</p>

<p><b>Solução</b>: O Command desacopla o objeto que chama a operação daquele que sabe como executá-la, a classe de solicitação possui um método "execute" que simplismente chama a ação do receiver. Os clientes dos objetos command tratam cada objeto como "caixa preta" pois eles simplesmete executam o metodo "execute".</p>

<p>Para realizar esta implementação devemos ter em mente que <b>Client</b> é a classe que cria e executa os objetos de command, <b>Invoker</b> é a classe que solicita o command para executar a ação, <b>Command</b> é a interface que especifica a operação "execute", <b>ConcreteCommand</b> esta é a classe que implementa a interface Command e o método execute que será executado no receiver e por fim <b>Receiver</b> que é a classe que executa a ação associada a solicitação.</p>

<p>Para o nosso cenário, foi criado um exemplo simples para as funções de uma calculadora</p>

<p>Primeiramente, vamos iniciar criando a nossa interface Command</p>

```c#
   public interface ICommand
   {
       void Execute();
   }
```

<p>Agora, vamos criar o nosso receiver que é a classe que executará as ações</p>

```c#
   public class SimpleCalculator
   {
       public SimpleCalculator(int firstNumber, int secondNumber)
       {
           FirstNumber = firstNumber;
           SecondNumber = secondNumber;
       }

       public int FirstNumber { get; set; }
       public int SecondNumber { get; set; }

       public void Sum()
       {
           Console.WriteLine($"A soma dos valores é {FirstNumber}+{SecondNumber} = {FirstNumber + SecondNumber}");
       }

       public void Subtraction()
       {
           Console.WriteLine($"A subtração dos valores é {FirstNumber}-{SecondNumber} = {FirstNumber - SecondNumber}");
       }

       public void Multiplication()
       {
           Console.WriteLine($"A multiplicação dos valores é {FirstNumber}*{SecondNumber} = {FirstNumber * SecondNumber}");
       }

       public void Division()
       {
           Console.WriteLine($"A divisão dos valores é {FirstNumber}/{SecondNumber} = {(SecondNumber == 0 ? "Inválida.. Divisão por 0" : $"{FirstNumber / SecondNumber}")}");
       }

   }
```

<p>Feito isso, vamos criar os nossos ConcreteCommand, será criado um para cada método da calculadora, porém aqui irei exemplificar somente dois, você pode consultar o exemplo completo clicando "AQUI"</p>

```c#
   public class SubtractionCommand : ICommand
   {
       private readonly SimpleCalculator _simpleCalculator;

       public SubtractionCommand(SimpleCalculator simpleCalculator)
       {
           _simpleCalculator = simpleCalculator;
       }

       public void Execute()
       {
           _simpleCalculator.Subtraction();
       }
   }


   public class MultiplicationCommand : ICommand
   {
       private readonly SimpleCalculator _simpleCalculator;

       public MultiplicationCommand(SimpleCalculator simpleCalculator)
       {
           _simpleCalculator = simpleCalculator;
       }

       public void Execute()
       {
           _simpleCalculator.Multiplication();
       }
   }
```
 
 <p>Perceba que o método execute sabe o que deve ser executado, é ele quem tem conhecimento sobre a lógica do negócio</p>
 
 <p>Agora, iremos criar o nosso Invoker</p>
 
```c#
  public class InvokerCommand
  {
      public List<ICommand> _commands = new List<ICommand>();

      public InvokerCommand()
      {
      }

      public InvokerCommand SetCommand(ICommand command)
      {
          _commands.Add(command);
          return this;
      }

      public void Execute()
      {
          foreach (var item in _commands)
              item.Execute();
      }
  }
```


<p>Repare que ele possui uma lista com todos os commands necessários e também é flexível para você adicionar/remover commands, sendo assim você também pode definir uma ordem de execução. Perceba também que o método execute não tem conhecimento sobre regras de negócio ele somente executa a operação do command.</p>

<p>Por fim, iremos ao nosso client para criar os commands e realizar as chamadas, nesse cenário é o método main</p>

```c#
   static void Main(string[] args)
   {
       Console.WriteLine("Hello World!");
       var random = new Random();
       var simpleCalculator = new SimpleCalculator(random.Next(-5, 30), random.Next(-5, 30));
       var invoke = new InvokerCommand()
           .SetCommand(new SumCommand(simpleCalculator))
           .SetCommand(new DivisionCommand(simpleCalculator))
           .SetCommand(new SubtractionCommand(simpleCalculator))
           .SetCommand(new MultiplicationCommand(simpleCalculator));

       Console.WriteLine("Executa operações");
       invoke.Execute();


       Console.ReadKey();
   }
```


<p><b>Saída</b></p>

> <p>Hello World!</p>
> <p>Executa operaçoes</p>
> <p>A soma dos valores é 28+28 = 56</p>
> <p>A divisao dos valores é 28/28 = 1</p>
> <p>A subtraçao dos valores é 28-28 = 0</p>
> <p>A multiplicaçao dos valores é 28*28 = 784</p>

<p> Use o padrão Comando quando desejar parametrizar objetos com operações, quando desejar enfileirar operações, agendar sua execução ou executá-las remotamente, quando desejar implementar operações reversíveis.</p>

# Iterador(iterator)

<p><b>O que é</b>: O Iterator é um padrão de design comportamental que permite obter uma maneira de acessar os elementos de um objeto de coleção de maneira sequencial, sem a necessidade de conhecer sua representação subjacente, por exemplo lista, pilha, árvore, matriz etc...</p>

<p><b>Problema</b>: Imagine que você precise percorrer uma coleção de objetos, independente do tipo, se é uma lista ou uma coleção em estrutura de árvore, você precisa percorrer sequencialmente os elementos de maneira que não repita os itens.</p>

<p><b>Solução</b>: A idéia principal do padrão Iterator é extrair o comportamento de travessia de uma coleção, ele implementa o próprio algoritimo de travessia e encapsula todos os detalhes. O padrão Iterator assume a responsabilidade de acessar sequencialmente os elementos.</p>

<p>Para implementar este padrão devemos ter em mente que <b>Client</b> é a classe que contém a coleção de objetos e usa a operação Next para recuperar os itens da sequência, <b>Iterador</b> é a interface que define operações para acessar os elementos, <b>ConcreteIterator</b> esta é a classe que implementa a interface iterador, <b>Aggregate</b> é a interface que define as operações para criar um iterador, <b>ConcreteAggregate</b> é a classe que implementa a interface aggregate.</p>


<p>Para o nosso exemplo foi criado uma coleção de objetos</p>

<p>Inicialmente, vamos criar a nossa interface IIterator, para definir os métodos de acesso a nossa coleção</p>

```c#
    public interface IIterator
    {
        object First();
        object Next();
        object Current();
        int GetIndex();
    }
```

<p>Agora, vamos criar nossa interface Aggregate para definir a operação para criar um Iterador</p>

```c#
    public interface IAggregate
    {
        IIterator CreateIterator();
    }
```

<p>Feito isso, vamos implementar o nosso ConcreteAggregate onde será implementado os métodos para inserir um elemento e para obter a quantidade de elementos.</p>

```c#
 public class AggregateCollection : IAggregate
 {
    private ArrayList _items = new ArrayList();
    public IIterator CreateIterator()
    {
        return new IteratorCollection(this);
    }

    public int Count()
    {
        return _items.Count;
    }

    public object this[int index]
    {
        get { return _items[index]; }
        set { _items.Insert(index, value); }
    }

    public void Add(object value)
    {
        _items.Insert(Count(), value);
    }

 }
```

<p>Aqui implementamos os métodos para acessar os registros e para inserir um novo elemento, repare que ela faz uma referência ao IteratorCollection(ConcreteIterator) porém nós ainda não criamos, vamos cria-lo agora.</p>

```c#
  public class IteratorCollection : IIterator
  {
      private AggregateCollection _aggregate;
      private int _current = 0;

      public IteratorCollection(AggregateCollection aggregate)
      {
          _aggregate = aggregate;
      }

      public object First()
      {
          return _aggregate[0];
      }

      public object Next()
      {
          object ret = null;
          if (_current < _aggregate.Count() - 1)
          {
              ret = _aggregate[++_current];
          }

          return ret;
      }

      public object Current()
      {
          return _aggregate[_current];
      }

      public int GetIndex()
      {
          return _current;
      }
  }
```

<p>Repare que o nosso ConcreteIterator possui uma referência ao ConcreteAggregate e utilizamos seus métodos para acessar o próximo registro, para obter o index, atual, primeiro, etc... Esta classe define os meios para acessar a nossa coleção que está no ConcreteAggregate.</p>

<p>Feito isso nós finalizamos a implementação do nosso iterador, agora é só realizar a chamada e utilizar seus métodos. Devemos lembrar que, ConcreteAggregate é a nossa coleção em si e devemos utilizar o ConcreteIterator para percorrermos os itens dessa coleção.</p>

```c#
   static void Main(string[] args)
    {
        Console.WriteLine("Hello World!");
        var collection = new AggregateCollection();
        collection[0] = "item A";
        collection[1] = "item B";
        collection[2] = "item C";

        Console.WriteLine($"Quantidade de itens = {collection.Count()}");


        collection.Add("item D");
        collection.Add("item E");
        collection.Add("item F");

        Console.WriteLine($"Quantidade de itens = {collection.Count()}");

        var iterator = collection.CreateIterator();

        var item = iterator.First();

        while(item != null)
        {
            Console.WriteLine(item);
            item = iterator.Next();
        }


        Console.ReadKey();
    }
}
```

<p><b>Saída</b></p>


> <p>Hello World!</p>
> <p>Quantidade de itens = 3</p>
> <p>Quantidade de itens = 6</p>
> <p>item A</p>
> <p>item B</p>
> <p>item C</p>
> <p>item D</p>
> <p>item E</p>
> <p>item F</p>

<p>Use o padrão Iterator quando sua coleção tiver uma estrutura de dados complexa, mas você deseja ocultar sua complexidade dos clientes (por motivos de conveniência ou segurança). Use quando deseja reduzir a duplicação do código transversal em seu aplicativo, quando desejar que seu código possa atravessar diferentes estruturas de dados ou quando os tipos dessas estruturas forem desconhecidos anteriormente.</p>

# Lembrança(memento)

<p><b>O que é</b>: Memento é um padrão de design comportamental que permite capturar e armazenar o estado atual do objeto, para que seja possível restaurá-lo posteriormente.</p>

<p><b>Problema</b>: Imagine que você precise de um histórico do objeto, onde você tenha que armazenar todas as alterações que o objeto sofreu, ou até mesmo se você precisar executar uma operação de desfazer/reverter.</p>

<p><b>Solução</b>: O padrão de memento delega a criação do estado do objeto, para o proprietário da classe(objeto de origem), portanto, em vez de outros objetos tentarem copiar o estado do editor(de fora), a própria classe cria o seu objeto de memento, pois ela tem acesso total ao seu próprio objeto. O padrão sugere armazenar a cópia do estado do objeto em um objeto especial chamado de "memento", o objeto original deve criar um cópia de si mesmo e retornar esse objeto especial(memento) para que ele possa ser gerenciado através de uma classe "cuidadora" onde nela armazenará uma pilha(LIFO - ultimo a entrar, primeiro a sair) com os mementos.</p>

<p>Para implementar este padrão, devemos ter em mente que, <b>Originator</b> é a classe que cria o objeto de lembrança com o seu estado atual, <b>Memento</b> é a interface que contém as abstrações necessárias para implementação do ConcreteMemento, <b>ConcreteMemento</b> esta é classe que contém as informações sobre o estado salvo no objeto originator, <b>Caretaker</b> esta é a classe usada para armazenar os objetos mementos onde haverá uma pilha com os elementos.</p>

<p>Para o nosso exemplo, iremos criar um cenário onde será salvo um histórico do objeto pessoa, armazenando todos os seus estados.<p>
 
 <p>Inicialmente, vamos criar as interfaces para o objeto memento e para o nosso originador.<p>
 
```c#
   public interface IMemento
   {
       IOriginator GetState();
       DateTime GetDate();
       void Show();
   }
   
   public interface IOriginator
   {
       IMemento Save();
   }
```

<p>Agora, iremos criar o nosso objeto originador "Person".</p>

```c#
   public class Person: IOriginator
   {
       public string Name { get; set; }
       public int Age { get; set; }
       public string Description { get; set; }

       public IMemento Save()
       {
           return new PersonMemento((Person)MemberwiseClone());
       }
   }
```

<p>Observe que o método Save retorna uma interface do IMemento e neste método é criado a classe concreta de memento(PersonMemento que não temos ainda), agora vamos implementar a classe PersonMemento.</p>

```c#
  public class PersonMemento : IMemento
  {
      private Person _person;
      public DateTime Date { get; private set; }

      public PersonMemento(Person person)
      {
          _person = person;
          Date = DateTime.Now;
      }

      public IOriginator GetState()
      {
          return _person;
      }

      public DateTime GetDate()
      {
          return Date;
      }

      public void Show()
      {
          Console.WriteLine($"Pessoa: {_person.Name}, de {_person.Age} anos, {_person.Description}");
      }
  }
```

<p>Repare que o objeto de memento possui a data em que está sendo criado, e no construtor é passado o objeto originador, assim conseguimos "tirar uma foto" do estado atual do objeto.</p>

<p>Com isso feito, temos tudo o que é necessário para implementar o nosso Caretaker que é o responsável por gerenciar esses estados.</p>

```c#
    public class Caretaker
    {
        private Stack<IMemento> _stack = new Stack<IMemento>();
        private IOriginator _originator;
        public Caretaker(IOriginator originator)
        {
            _originator = originator;
        }

        public void Backup()
        {
            _stack.Push(_originator.Save());
        }

        public void Undo()
        {
            _stack.Pop();
        }

        public void ShowHistory()
        {
            foreach (var item in _stack)
            {
                Console.WriteLine($"{item.GetDate().ToString("dd/MM/yyyy HH:mm:ss")}");
                item.Show();
            }
        }
    }
```

<p>Observe que o Caretaker mantém uma pilha dos objetos de memento, e também possui uma referência ao nosso objeto originador. Observe que o método Backup ativa o método Save que é criado no objeto originador e assim inserindo o retorno do método na pilha de lembranças, com isso conseguimos manter seu histórico.</p>

<p>Feito isso, agora é só chamar os método e verificar sua usabilidade.</p>

```c#
       static void Main(string[] args)
        {
            Console.WriteLine("Hello World!");
            var person = new Person();
            var caretaker = new Caretaker(person);
            person.Name = "Gustavo";
            caretaker.Backup();
            person.Age = 23;
            caretaker.Backup();
            person.Description = "lorem ipsum";
            caretaker.Backup();
            person.Description = "lorem ipsum - 2";
            caretaker.Backup();
            caretaker.ShowHistory();
            
            caretaker.Undo();
            caretaker.Undo();
            caretaker.Undo();
            
            caretaker.ShowHistory();
            Console.ReadKey();
        }
```

<p><b>Saída</b></p>

> <p>Hello World!</p>
> <p>19/06/2020 19:26:56</p>
> <p>Pessoa: Gustavo, de 23 anos, lorem ipsum - 2</p>
> <p>19/06/2020 19:26:56</p>
> <p>Pessoa: Gustavo, de 23 anos, lorem ipsum</p>
> <p>19/06/2020 19:26:56</p>
> <p>Pessoa: Gustavo, de 23 anos,</p>
> <p>19/06/2020 19:26:56</p>
> <p>Pessoa: Gustavo, de 0 anos,</p>
> <p>19/06/2020 19:26:56</p>
> <p>Pessoa: Gustavo, de 0 anos,</p>

<p>Use o padrão Memento quando desejar produzir capturas instantâneas do estado do objeto para poder restaurar um estado anterior do objeto ou quando o acesso direto aos campos getters/setters do objeto violar seu encapsulamento.</p>


# Método de Modelo(template method)

<p><b>O que é</b>: O Template Method é um padrão de design comportamental que define o esqueleto de como um algoritmo pode ser executado na superclasse, mas permite que as subclasses substituam essas etapas sem alterar sua estrutura.</p>

<p><b>Problema</b>: Imagine que você esteja trabalhando com dois componentes diferentes, mas que possuem muitos métodos em comum(as vezes são comuns até em termos de negócio), porém para realizar a implementação de um componente, não se tinha em mente que existiria o outro, então não foi pensado em nenhuma estrutura para a criação desses componentes. Portanto, a criação desses componentes resultaram em muito código duplicado o que pode vir a apresentar muitas falhas, principalmente se você precisar alterar um método e se esquecer que o outro também existe(duplicado).</p>

<p><b>Solução</b>: O padrão template method sugere que você divida esses algoritmos em uma série de etapas e transforme essas etapas em métodos que poderão ser chamados através de um único método "Template Method". Basicamente você deve criar uma superclasse contendo todas as etapas em comum e deixando-as em um método "virtual" para que possa ser substituída por uma outra subclasse, a única etapa que não pode ser manipulada é o "Template Method" pois ele é a estrutura principal "o esqueleto".</p>

<p>Para realizar esta implementação devemos ter em mente que, <b>AbstractClass</b> é a classe abstrata que contém o Template Method e as operações para cada etapa, <b>ConcreteClass</b> são as subclasses que heram da AbstractClass e implementa os métodos conforme necessário <b>se</b> for necessário.</p>

<p>Para o nosso exemplo, foi criado um cenário simples onde será aberto dois tipos de arquivos diferentes, um CSV e um PDF, a implementação para abrir e consumir os dados do arquivo são muito semelhantes então criaremos um FileBase(AbstractClass).</p>

<p>Inicialmente, vamos verificar tudo o que há em comum para abrir um arquivo, então podemos considerar que: OpenFile; CloseFile; ExtractData; ParseData. Podemos considerar que esses métodos são comuns independente do tipo de arquivo a ser aberto, a final precisamos abrir o arquivo, extrair os dados, converter os dados e depois fechar o arquivo. Então será isso que implementaremos na nossa classe base.</p>

```c#
    public abstract class FileBase
    {
        public Dictionary<string, IEnumerable<int>> TemplateMethod(string directory)
        {
            var response = new Dictionary<string, IEnumerable<int>>();
            OpenFile(directory);
            var index = 1;
            foreach (var item in ExtractData().Skip(1))
            {
                response.Add($"Linha - {index}", ParseData(item));
                index++;
            }
            CloseFile(directory);
            return response;
        }


        public virtual void OpenFile(string directory)
        {
            Console.WriteLine($"Abre arquivo no diretório {directory}");
        }

        public virtual void CloseFile(string directory)
        {
            Console.WriteLine($"Fecha arquivo no diretório {directory}");
        }

        public virtual IEnumerable<string> ExtractData()
        {
            return new List<string>()
            {
                "um,dois,três,quatro,cinco,seis,sete,oito,nove,dez",
                "1,2,3,4,5,6,7,8,9,10",
                "1,2,3,4,5,6,7,8,9,10",
                "1,2,3,4,5,6,7,8,9,10",
                "1,2,3,4,5,6,7,8,9,10",
                "1,2,3,4,5,6,7,8,9,10"
            };
        }

        public virtual IEnumerable<int> ParseData(string row)
        {
            var response = new List<int>();
            foreach (var item in row.Split(','))
                response.Add(int.Parse(item));

            return response;
        }
    }
```

 - O objetivo desse exemplo, é mostrar como poderíamos utilizar o Template Method, devido a isso não foi implementado a abertura e conversão de um arquivo de verdade, estamos fazendo somente para exemplificar o pattern.

<p>Observe que cada etapa é um método virtual, o que significa que poderá ser substituído por uma subclasse, a final cada uma terá sua particularidade, mas a estrutura, o esqueleto para abrir um arquivo será sempre igual e está presente no nosso Template Method que não pode ser substituído por uma subclasse.</p>


<p>Feito isso, iremos implementar a abertura para o arquivo CSV.</p>

```c#
 public class CsvFile : FileBase
 {

     public override void OpenFile(string directory)
     {
         Console.WriteLine($"Abre arquivo CSV no diretório ~~ {directory}");
     }

     public override void CloseFile(string directory)
     {
         Console.WriteLine($"Fecha arquivo CSV no diretório ~~ {directory}");
     }

     public override IEnumerable<string> ExtractData()
     {
         return new List<string>()
         {
             "A,B,C",
             "1,2,3",
             "1,2,3",
             "1,2,3",
             "1,2,3",
             "1,2,3"
         };
     }
 }
```

<p>Observe que para realizar a abertura, fechamento e extrair os dados de um arquivo, temos uma lógica diferente da implementada na classe base, e por isso houve a necessidade de realizar a implementação.</p>

<p>Agora iremos criar o nosso PDFFile.</p>

```c#
public class PdfFile : FileBase
{

    public override void OpenFile(string directory)
    {
        Console.WriteLine($"Abre arquivo PDF no diretório ~~ {directory}");
    }

    public override void CloseFile(string directory)
    {
        Console.WriteLine($"Fecha arquivo PDF no diretório ~~ {directory}");
    }

}
```

<p>Observe que aqui, a lógica diferente é somente para abrir e fechar o arquivo.</p>

<p>Com isso implementado, conseguimos realizar a implementação do pattern Template Method, agora é só realizar a chamada do método.</p>

```c#
 static void Main(string[] args)
 {
     Console.WriteLine("Hello World!");
     var pflFile = new PdfFile();
     var pdfValues = pflFile.TemplateMethod("diretório para arquivo pdf");
     Console.WriteLine("Resultado pdf File");
     foreach (var row in pdfValues)
     {
         Console.WriteLine(row.Key);
         foreach (var item in row.Value)
             Console.Write($"  {item}");
         Console.WriteLine();
     }

     var csvFile = new CsvFile();
     var csvValues = csvFile.TemplateMethod("diretório para arquivo csv");
     Console.WriteLine("Resultado csv File");
     foreach (var row in csvValues)
     {
         Console.WriteLine(row.Key);
         foreach (var item in row.Value)
             Console.Write($"  {item}");
         Console.WriteLine();
     }

     Console.ReadKey();
 }
```

<p><b>Saída</b></p>

> <p>Hello World!</p>
> <p>Abre arquivo PDF no diretório ~~ diretório para arquivo pdf</p>
> <p>Fecha arquivo PDF no diretório ~~ diretório para arquivo pdf</p>
> <p>Resultado pdf File</p>
> <p>Linha - 1</p>
> <p>  1  2  3  4  5  6  7  8  9  10</p>
> <p>Linha - 2</p>
> <p>  1  2  3  4  5  6  7  8  9  10</p>
> <p>Linha - 3</p>
> <p>  1  2  3  4  5  6  7  8  9  10</p>
> <p>Linha - 4</p>
> <p>  1  2  3  4  5  6  7  8  9  10</p>
> <p>Linha - 5</p>
> <p>  1  2  3  4  5  6  7  8  9  10</p>
> <p>Abre arquivo CSV no diretório ~~ diretório para arquivo csv</p>
> <p>Fecha arquivo CSV no diretório ~~ diretório para arquivo csv</p>
> <p>Resultado csv File</p>
> <p>Linha - 1</p>
> <p>  1  2  3</p>
> <p>Linha - 2</p>
> <p>  1  2  3</p>
> <p>Linha - 3</p>
> <p>  1  2  3</p>
> <p>Linha - 4</p>
> <p>  1  2  3</p>
> <p>Linha - 5</p>
> <p>  1  2  3</p>

<p>Use o padrão Template Method quando desejar permitir que os clientes estendam apenas etapas específicas de um algoritmo, mas não o algoritmo inteiro ou sua estrutura, quando tiver várias classes que contêm algoritmos quase idênticos, com algumas pequenas diferenças. Como resultado, pode ser necessário modificar todas as classes quando o algoritmo for alterado.</p>


# Estado(state)

<p><b>O que é</b>: State é um padrão de design comportamental que permite alterar o comportamento de um objeto de acordo com o seu estado atual, a cada vez que o estado muda,  um novo comportamento pode ser tomado.</p>

<p><b>Problema</b>: Este padrão está relacionado ao conceito de uma máquina de estado finito, ou seja, quando seu código esta cheio de if/else e switch case, tomando vários comportamentos diferentes alterando o comportamento da lógica de negócio.</p>

<p><b>Solução</b>: O padrão State sugere que você crie novas classes para cada comportamento possível de estados, você deve criar uma classe extraindo todos os comportamentos específicos para cada estado em particular, ao invés de implementar tudo no objeto original. O objeto original deve manter uma referência a um objeto de estado(que representa o estado atual) delegando todo o trabalho a ele.</p>

<p>Para implementar esse pattern, devemos ter em mente que <b>State</b> é uma interface utilizada para acessar as funcionalidades que serão utilizadas pelos estados, <b>Context</b> é a classe que contém o objeto de estado concreto e fornece o comportamento de acordo com o seu estado atual, e por fim <b>ConcreteState</b> que é a classe implementada pela interface State e fornece o comportamento para cada determinado estado do objeto Context.</p>

<p>Para o nosso exemplo, foi criado um cenário simples onde de acordo com o tipo de operação, será aplicada uma regra de matemática.</p>

<p>Inicialmente, iremos criar a interface de estado.</p>

```c#
 public interface IStateSimpleCalculator
 {
     void Execute(SimpleCalculator context);
 }
 ```
 
 <p>Observe que para o método execute é passado o objeto SimpleCalculator, ele é o nosso context, vamos cria-lo.</p>
 
```c#
public class SimpleCalculator
{
    private IStateSimpleCalculator _stateSimpleCalculator;

    public SimpleCalculator(int firstNumber, int secondNumber)
    {
        FirstNumber = firstNumber;
        SecondNumber = secondNumber;
    }

    public int FirstNumber { get; set; }
    public int SecondNumber { get; set; }

    public Operation Operation { get; set; }

    public void SetState(IStateSimpleCalculator state)
    {
        _stateSimpleCalculator = state;
    }

    public void ExecuteState()
    {
        _stateSimpleCalculator?.Execute(this);
    }
}

public enum Operation
{
    Sum,
    Subtraction,
    Multiplication,
    Division
}
```

<p>Observe que o nosso Context possui uma referência a interface de state e também possui os métodos para inserir(SetState) e executar(ExecuteState) um estado.</p>

<p>Feito isso, temos a nossa interface de State que será implementado por cada objeto de estado possível e também, temos o nosso Context, o mesmo deve ser passado para cada objeto de estado, para que se possa tomar alguma ação com base nele.</p>
 
 <p>Agora, iremos implementar os objetos de stado, irei exemplificar somente dois, mas você pode consultar o exemplo completo, clicando "aqui".</p>
 
 ```c#
public class DivisionState : IStateSimpleCalculator
{
   public void Execute(SimpleCalculator context)
   {
       Console.WriteLine($"Resultado da divisão é: {context.FirstNumber} / {context.SecondNumber} = {(context.SecondNumber == 0 ? "Inválida.. Divisão por 0" : $"{context.FirstNumber / context.SecondNumber}")}");
   }
}
    
public class SumState : IStateSimpleCalculator
{
   public void Execute(SimpleCalculator context)
   {
       Console.WriteLine($"Resultado da soma é: {context.FirstNumber} + {context.SecondNumber} = {context.FirstNumber + context.SecondNumber}");
   }
}    
 ```
 
 <p>Feito isso, é só validar qual o tipo de operação e qual estado será inserido ao nosso context. Quando tivermos a informação de qual estado deve ser inserido, é só passar o objeto concreto para o context, através do método SetState e para executar é através do método ExecuteState.</p>
 
 ```c#
static void Main(string[] args)
{
    Console.WriteLine("Hello World!");
    var intRandom = new Random();

    for (int i = 0; i < Enum.GetNames(typeof(Operation)).Length; i++)
    {
        var simpleCalculator = new SimpleCalculator(intRandom.Next(-2, 20), intRandom.Next(-2, 20))
        {
            Operation = (Operation)i
        };

        switch (simpleCalculator.Operation)
        {
            case Operation.Multiplication:
                simpleCalculator.SetState(new MultiplicationState());
                break;
            case Operation.Division:
                simpleCalculator.SetState(new DivisionState());
                break;
            case Operation.Subtraction:
                simpleCalculator.SetState(new SubtractionState());
                break;
            case Operation.Sum:
                simpleCalculator.SetState(new SumState());
                break;
        }

        simpleCalculator.ExecuteState();
    }

    Console.ReadKey();
}
 
 ```
 
 <p></b>Saída</b></p>
 
> <p>Hello World!</p>
> <p>Resultado da soma é: 8 + 18 = 26</p>
> <p>Resultado da subtraçao é: 4 - 3 = 1</p>
> <p>Resultado da multiplicaçao é: 5 * 1 = 5</p>
> <p>Resultado da divisao é: 15 / 13 = 1</p>

<p>Use o padrão State quando você tiver um objeto que se comporte de maneira diferente dependendo do estado atual, o número de estados seja enorme e o código específico do estado seja alterado com frequência. Quando tiver uma classe poluída com condicionais massivas que alteram o comportamento da classe de acordo com os valores atuais dos campos da classe.</p>
 
# Estratégia(strategy)

 <p></b>O que é</b>: Strategy é um padrão de design comportamental que lhe permite definir uma família de algoritimos, onde você coloca cada um em uma classe separada, fazendo com que seja possível selecioná-los e executá-los.</p>
 
<p><b>Problema</b>: O objetivo de representar objetos de estratégia, é que você consiga variar o conjunto de estratégia referênte ao contexto, assim você consegue escolher o comportamento que será seguido de acordo com o fluxo/rumo que está sendo tomado, sendo assim, pode-se notar que irá diminuir o acoplamento entre as classes e também vai de encontro ao princípio de "open-closed(SOLID)".</p>

<p><b>Solução</b>: O padrão strategy sugere que você extraia o comportamento específico de um contexto em várias classes separadas de estratégias. A classe original de contexto deve possuir uma referência as classes de estratégia, para que seja possível delegar todo o trabalho a elas. A classe de contexto não tem conhecimento sobre as classes concretas de estratégias e sim da sua interface, tornando possível o contexto executar qualquer estratégia desejada.</p>

<p>Para implementar este pattern, devemos ter em mente que, <b>Strategy</b> é a interface usada pelo contexto para chamar os algoritmos desejados, <b>Context</b> é a classe que possui a referência a interfce Strategy, onde é possível ser configurada em tempo de execução de acordo com a necessidade e por fim <b>ConcreteStrategy</b> é a classe que contém os detalhes da implementação.</p>

<p>Para o nosso exemplo, foi criado um cenário simples onde será executado as operações de uma calculadora.</p>

<p>Inicialmente iremos criar a nossa interface de strategy</p>

```c#
 public interface IStrategy
 {
     string Execute();
 }
```

<p>Agora, iremos criar uma classe de contexto, onde o objetivo é executar as operações de uma calculadora e armazenar o resultado dentro de uma lista, para isso, criaremos o contexto da seguinte maneira.</p>

```c#
public class CalculatorContext
{
   private IList<IStrategy> _strategies = new List<IStrategy>();

   public CalculatorContext SetStrategy(IStrategy strategy)
   {
       _strategies.Add(strategy);
       return this;
   }

   public IEnumerable<string> Execute()
   {
       var response = new List<string>();
       foreach (var item in _strategies)
           response.Add(item.Execute());

       return response;
   }
}
```

<p>Observe que o contexto armazena uma referência a uma lista de estratégias, onde pode ser passada uma a uma por parâmetro através do método SetStrategy, com isso, conseguimos criar o método Execute que irá executar uma por uma das estratégias informadas</p>

<p>Agora, iremos criar as estratégias, irei exemplificar somente duas, mas você pode consultar o exemplo completo clicando "aqui"</p>

```c#
public class DivisionStrategy : IStrategy
{
    public DivisionStrategy(int firstNumber, int secondNumber)
    {
        FirstNumber = firstNumber;
        SecondNumber = secondNumber;
    }

    private int FirstNumber { get; set; }
    private int SecondNumber { get; set; }

    public string Execute()
    {
        return $"Resultado da divisão é: {FirstNumber} / {SecondNumber} = {(SecondNumber == 0 ? "Inválida.. Divisão por 0" : $"{FirstNumber / SecondNumber}")}";
    }
}


public class MultiplicationStrategy : IStrategy
{
    public MultiplicationStrategy(int firstNumber, int secondNumber)
    {
        FirstNumber = firstNumber;
        SecondNumber = secondNumber;
    }

    private int FirstNumber { get; set; }
    private int SecondNumber { get; set; }

    public string Execute()
    {
        return $"Resultado da multplicação é: {FirstNumber} * {SecondNumber} = {FirstNumber * SecondNumber}";
    }
}
```

<p>Observe que se quiséssemos adicionar mais parâmetros isso seria possível, aqui somos livres para implementar da maneria que for necessário. Caso haja a necessiadade de realizar a comunicação com algum outro service, você consegue realizar a implementação.</p>

<p>Agora, é só chamar o nosso contexto, passando as estratégias necessárias e chamar o método execute.</p>

```c#
static void Main(string[] args)
{
    Console.WriteLine("Hello World!");
    var random = new Random();
    var firstNumber = random.Next(-10, 30);
    var secondNumber = random.Next(-20, 40);

    var context = new CalculatorContext();

    context
        .SetStrategy(new SumStrategy(firstNumber, secondNumber))
        .SetStrategy(new SubtractionStrategy(firstNumber, secondNumber))
        .SetStrategy(new MultiplicationStrategy(firstNumber, secondNumber))
        .SetStrategy(new DivisionStrategy(firstNumber, secondNumber));

    foreach (var item in context.Execute())
        Console.WriteLine(item);


    Console.ReadKey();
}
```

<p><b>Saída</b></p>

> <p>Hello World!</p>
> <p>Resultado da soma é: 8 + 4 = 12</p>
> <p>Resultado da subtraçao é: 8 - 4 = 4</p>
> <p>Resultado da multplicaçao é: 8 * 4 = 32</p>
> <p>Resultado da divisao é: 8 / 4 = 2</p>

<p>Use o padrão Strategy quando desejar usar diferentes variantes de um algoritmo dentro de um objeto e poder alternar de um algoritmo para outro durante o tempo de execução, quando tiver muitas classes semelhantes que diferem apenas na maneira como elas executam algum comportamento. Use o padrão para isolar a lógica de negócios de uma classe dos detalhes de implementação de algoritmos que podem não ser tão importantes no contexto dessa lógica.</p>

# Visitante(visitor)

<p><b>O que é</b>: Visitor é um padrão de design comportamental que permite separar algoritmos dos objetos nos quais eles operam. Permite que seja adicionado mais operações sem precisar modificar os objetos.</p>

<p><b>Problema</b>: Imagine que você possua uma classe grande, complexa e em produção. Surgiu uma nova demanda, em que você precisaria realizar uma implementação nesta classe para que seja possível extraí-la em um formato X. A primeira coisa que você pensou, foi adicionar um método a esta classe, para realizar a exportação, porém, o arquiteto não deixou, pois não queria correr o risco, de que uma nova implementação ocasionasse em um bug em algum outro local do sistema, a final, você estaria alterando a classe original. Outro ponto negativo, é que muito provavelmente haveria a necessidade de exportar também para o formato Y e a final, não tinha muito sentido acrescentar o código de exportação dentro dessas classes de nó, pois essa não era sua finalidade.</p>

<p><b>Solução</b>: O padrão visitor sugere que você coloque esse comportamento em uma classe separada chamada visitor, ao invés de integrá-lo a classe original, com isso o objeto original deve simplesmente chamar o método do visitor sendo passado como argumento, assim, o visitor teria acesso a todos os dados necessários do objeto.</p>

<p>Para implementar este padrão, devemos ter em mente que, <b>Client</b> é a classe que tem acesso aos objetos da estrutura e pode informar qual visitante determinado objeto irá receber, no nosso caso, será o metodo Main, <b>Element</b> esta é a interface que define o método Accept, onde será passado como parâmetro um visitor, <b>ConcreteElement</b> esta é a classe "original" onde você poderá instrui-la a aceitar um visitante para executar determinadas ações, <b>Visitor</b> esta é a interface para especificar os objetos concretos, e por fim, <b>ConcreteVisitor</b> essas são as classes que iram implemetar a interface Visitor.</p>

<p>Para o nosso exemplo, foi criado um cenário, onde há duas classes que executam operações de calculadora, e elas só poderãm ser modificadas, somente com base em um visitor(pois o arquiteto nao deixou mexer nelas). Para um dos visitantes deve transformar as classes em um JSON e o outro deve pegar o nome de suas propriedades.</p>

<p>Inicialmente, vamos criar as classes de ConcreteElement</p>

```c#
public class MultiplyNumerics
{
    public int FirstNumber { get; set; }
    public int SecondNumber { get; set; }

    public MultiplyNumerics(int firstNumber, int secondNumber)
    {
        FirstNumber = firstNumber;
        SecondNumber = secondNumber;
    }

    public int Multply()
    {
        return FirstNumber * SecondNumber;
    }
}
    
public class SumDecimals
{
    public decimal FirstNumber { get; set; }
    public decimal SecondNumber { get; set; }

    public SumDecimals(decimal firstNumber, decimal secondNumber)
    {
        FirstNumber = firstNumber;
        SecondNumber = secondNumber;
    }

    public decimal Sum()
    {
        return FirstNumber + SecondNumber;
    }
}    
``` 

<p>Agora, iremos criar a nossa interface de Visitor.</p>

```c#
public interface IVisitor
{
    void VisitElement(MultiplyNumerics multiplyNumerics);
    void VisitElement(SumDecimals sumDecimals);
}
```

<p>Observe que cada método possui o mesmo nome, eles só diferen nos parâmetros que recebem, pois é um para cada tipo de ConcreteElement.</p>

<p>Com isso, conseguimos implementar os nossos ConcreteVisitors.</p>

```c#
public class VisitorGetPropertyName : IVisitor
{
    public void VisitElement(MultiplyNumerics multiplyNumerics)
    {
        Console.WriteLine($"Visitante {this.GetType()}, obtem {multiplyNumerics.GetType()}");
    }

    public void VisitElement(SumDecimals sumDecimals)
    {
        Console.WriteLine($"Visitante {this.GetType()}, obtem {sumDecimals.GetType()}");
    }
}

public class VisitorTransformIntoJson: IVisitor
{
    public void VisitElement(MultiplyNumerics multiplyNumerics)
    {
        Console.WriteLine($"Resultado da multiplicação: {multiplyNumerics.Multply()}");
        Console.WriteLine(JsonConvert.SerializeObject(multiplyNumerics));
    }

    public void VisitElement(SumDecimals sumDecimals)
    {
        Console.WriteLine($"Resultado da soma: {sumDecimals.Sum()}");
        Console.WriteLine(JsonConvert.SerializeObject(sumDecimals));
    }
}
```

<p>Feito isso, temos o nosso Visitor e os ConcreteVisitors, porém o nosso ConcreteElement não consegue acessar esses visitores, devemos implementar a interface Element e ajustar o nosso ConcreteElement com a nova interface.</p>

```c#
public interface IElement
{
    void Accept(IVisitor visitor);
}
```

<p>Agora é só ajustar o nosso ConcreteElement inserindo esta nova interface e ajustando o método Accept</p>

```c#
public class MultiplyNumerics : IElement
{
    public int FirstNumber { get; set; }
    public int SecondNumber { get; set; }

    public MultiplyNumerics(int firstNumber, int secondNumber)
    {
        FirstNumber = firstNumber;
        SecondNumber = secondNumber;
    }

    public int Multply()
    {
        return FirstNumber * SecondNumber;
    }

    public void Accept(IVisitor visitor)
    {
        visitor.VisitElement(this);
    }
}

public class SumDecimals : IElement
{
   public decimal FirstNumber { get; set; }
   public decimal SecondNumber { get; set; }

   public SumDecimals(decimal firstNumber, decimal secondNumber)
   {
       FirstNumber = firstNumber;
       SecondNumber = secondNumber;
   }

   public decimal Sum()
   {
       return FirstNumber + SecondNumber;
   }

   public void Accept(IVisitor visitor)
   {
       visitor.VisitElement(this);
   }
}

```

<p>Agora, finalizamos a implementação, basta somente realizar a chamada e informar um visitor ao nosso ConcreteElement.</p>

```c#
static void Main(string[] args)
{
    Console.WriteLine("Hello World!");
    var client = new List<IElement>
    {
        new MultiplyNumerics(20,30),
        new SumDecimals(53.42M,43.99M)
    };

    var transformIntoJson = new VisitorTransformIntoJson();
    foreach (var item in client)
        item.Accept(transformIntoJson);

    var getPropertyName = new VisitorGetPropertyName();
    foreach (var item in client)
        item.Accept(getPropertyName);

    Console.ReadKey();
}
```

<p><b>Saída</b></p>

> <p>Hello World!</p>
> <p>Resultado da multiplicaçao: 600</p>
> <p>{"FirstNumber":20,"SecondNumber":30}</p>
> <p>Resultado da soma: 97,41</p>
> <p>{"FirstNumber":53.42,"SecondNumber":43.99}</p>
> <p>Visitante Design.Pattern.Visitor.Visitor.VisitorGetPropertyName, obtem Design.Pattern.Visitor.Element.MultiplyNumerics</p>
> <p>Visitante Design.Pattern.Visitor.Visitor.VisitorGetPropertyName, obtem Design.Pattern.Visitor.Element.SumDecimals</p>

<p>Use o Visitor quando precisar executar uma operação em todos os elementos de uma estrutura de objeto complexa (por exemplo, uma árvore de objetos), para limpar a lógica de negócios dos comportamentos auxiliares. Quando um comportamento fizer sentido apenas em algumas classes de uma hierarquia de classes, mas não em outras.</p>







