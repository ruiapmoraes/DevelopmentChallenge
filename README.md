# 💡 Desafio .NET - Relatório de Formas Geométricas

Este repositório contém a refatoração do desafio proposto para gerar relatórios de formas geométricas, com suporte a múltiplos idiomas (Espanhol, Inglês e Italiano), além da inclusão de novas formas (Trapézio e Retângulo). A estrutura foi modernizada para seguir boas práticas de orientação a objetos e uso de recursos `.resx` para internacionalização.

---

## 📦 Estrutura do Projeto

- `DevelopmentChallenge.Data` – Projeto principal com a lógica de negócio
- `DevelopmentChallenge.Data.Tests` – Projeto de testes automatizados usando NUnit

---

## 🛠️ Tecnologias

- **C# (.NET Framework 4.8)**
- **NUnit 4.3.2**
- **NUnit3TestAdapter 5.0.0**
- **Microsoft.NET.Test.Sdk 17.8.0**
- **Visual Studio 2022**

---

## 🌍 Idiomas Suportados

| Código | Idioma    |
|--------|-----------|
| 1      | Espanhol  |
| 2      | Inglês    |
| 3      | Italiano  |

---

## 📚 Formas Geométricas Suportadas

Cada forma implementa a interface `IFormaGeometrica`, respeitando os princípios de responsabilidade única e extensibilidade:

- Quadrado
- Retângulo
- Triângulo Equilátero
- Círculo
- Trapézio

---

## 🧪 Testes Unitários

- Criados com `NUnit`, organizados na classe `DataTestsNew`
- Cobrem variações de idioma, combinações de formas, valores decimais e cenários extremos
- Testes exibem mensagens no painel de **Output** com `TestContext.WriteLine` para facilitar depuração
- Alguns testes estão marcados como `[Ignore]` para ilustrar cenários não tratados ou limitações

---

## 🌐 Internacionalização

- Implementada com arquivos `.resx` (Espanhol, Inglês, Italiano)
- A cultura é resolvida via `CultureInfo` com base no inteiro de idioma passado
- As strings são buscadas por chave usando `ResourceManager.GetString(...)`
- Os arquivos `.resx` são configurados como **Embedded Resource**

---

## 🗂️ Estrutura de Pastas

```
DevelopmentChallenge/
│
├── Data/
│   ├── Classes/
│   │   ├── Quadrado.cs
│   │   ├── Circulo.cs
│   │   ├── TrianguloEquilatero.cs
│   │   ├── Trapezio.cs
│   │   └── Retangulo.cs
│   ├── Interfaces/
│   │   └── IFormaGeometrica.cs
│   ├── Enums/
│   │   ├── Forma.cs
│   │   └── Idioma.cs
│   ├── Resources/
│   │   ├── Strings.resx
│   │   ├── Strings.es.resx
│   │   └── Strings.it.resx
│   ├── Helpers/
│   │   └── IdiomaHelper.cs
│   └── RelatorioDeFormas.cs
│
└── Tests/
    └── DataTestsNew.cs
```

---

## 🚀 Como Executar

### Pré-requisitos

- Visual Studio 2022 instalado
- .NET Framework 4.8
- NUnit Test Adapter instalado via gerenciador de extensões (caso não use `PackageReference`)

### Passos

1. Clone o repositório:
   ```bash
   git clone https://github.com/ruiapmoraes/developmentchallenge.git
   ```

2. Abra a solução no Visual Studio

3. Compile os dois projetos (`.Data` e `.Data.Tests`)

4. Vá até `Test > Test Explorer` e clique em `Run All`

5. Confira os detalhes e mensagens no painel de Output

---

## 📈 Melhorias Aplicadas

- ✅ Refatoração completa do código legado
- ✅ Suporte completo a novos idiomas via `.resx`
- ✅ Extensibilidade facilitada para novas formas
- ✅ Cálculos validados com testes precisos
- ✅ Formatação numérica com `ToString("N2", culture)`
- ✅ Testes com saída descritiva via `TestContext.WriteLine`

---

## 👨‍💻 Autor

Desenvolvido para fins de avaliação técnica, com foco em boas práticas de código, testes, organização e clareza.
