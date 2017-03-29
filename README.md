# ADS1T1M.TP3.MunirXavierWanis.Solution

## TP3 - Alternativo

### Desenvolvimento de uma aplicação de carga de dados

1. Criar uma solução em branco. Nome da solução: ADS1T1M.TP3.SEU_NOME.Solution

2. Criar uma pasta de solução (solution folder) para as camadas de Apresentação (1Presentation) e Domínio (4-Domain)

Adicionar um projeto Console Application em Apresentação:
ADS1T1M.TP3.SEU_NOME.Presentation.ConsoleApp

Adicionar um projeto Class Library em Domain: ADS1T1M.TP3.SEU_NOME.Domain
(apagar Class1 e referências [menos System e Analyzers])

Em Domain, criar a pasta Entities

Em Domain, criar uma classe para Aluno dentro da pasta Entities. Aluno deve ter um identificador, nome, matricula, data de nascimento, cpf, ativo (bool).

Adicionar uma nova Solution Folder: 5-Infra

Dentro de 5-Infra, crie uma nova Solution Folter 5.1-Data

Dentro de 5.1-Data, adicionar um projeto Class Library

ADS1T1M.TP3.SEU_NOME.Infra.Data (apagar Class1 e referências [menos System e Analyzers])

Adiconar o Entity Framework via Nuget em Infra.Data

Criar em Infra.Data uma pasta Contexts e dentro desta, uma classe EntityContextDb, que servirá de classe de contexto. A classe deve Herdar de DbContext.

Adicione em Infra.Data uma referência para Domain.

Dentro desta classe (EntityContextDb), adicione uma propriedade do tipo `DbSet<Aluno>`

Ache no “window explorer” o diretório da solução. Crie uma pasta “XML-Original”. Coloque os dois arquivos XML dentro dele.

1º arquivo: você deverá criar um arquivo XML (“exporte-alunos-01.xml”) com a estrutura abaixo, para 8 alunos (sugiro o uso dos nomes dos colegas de sala).

```xml
<?xml version="1.0" encoding="utf-8"?>
<alunos>
  <aluno>
    <matricula>fn944098u</matricula>
    <nome>PauloMau</nome>
    <datadenascimento>24/10/1967</datadenascimento>
    <cpf>84189380210</cpf>
    <ativo>1</ativo>
  </aluno>
  <aluno>
    <matricula>9j35tnfgn</matricula>
    <nome>PauloMau</nome>
    <datadenascimento>24/10/1967</datadenascimento>
    <cpf>84189380210</cpf>
    <ativo>0</ativo>
  </aluno>
</alunos>
```

2º arquivo: você deverá criar um segundo (“exporte-alunos-02.xml”) arquivo XML, com os 8 alunos anteriores. Escolha uns 4 alunos e modifique a propriedade ativo... Se for 0, mude para 1. Se for 1, mude para 0. E acrescente mais 3 alunos neste arquivo.

Você deve criar uma pasta Data, dentro do diretório da solução. Copie o primeiro arquivo para dentro da pasta e renomei para “exporte-alunos.xml”.

Em ConsoleApp, você deverá adicionar referências para Infra.Data e Domain. Deverão adicionar via Nuget, o Entity Framework.

LÓGICA: Você precisa no ConsoleApp:

Ler o arquivo XML (“exporte-alunos.xml”) que está dentro da pasta Data usando a classe XmlDocument. Veja o material que deixei no Moodle.

Ler o registro do aluno no arquivo e verificar se o aluno existe na base. Caso negativo: inclua o aluno.

Caso o aluno exista na base, verifique se houve mudança na propriedade "ativo". Se houve, altere o dado na base. Senão, não faça nada.

Você deverá registrar em um arquivo texto ("exporte-alunos-log-de-carga-201612071749.txt"), que deverá ficar dentro da pasta Data, cada operação feita na base, ou não. A numeração no arquivo é a data e hora do momento da criação do arquivo. Esta data e hora deverá ser guardada para uso posterior.

Caso o aluno não exista na base, a linha no log deve ser:

matricula>9j35tnfgn; nome>PauloMau; ativo>0; Adicionado;

Caso o aluno exista na base e não haja nada para fazer, a linha no log deve ser:

matricula>9j35tnfgn; nome>PauloMau; ativo>0; OK;

Caso o aluno exista na base e haja algo para fazer, a linha no log deve ser:

matricula>9j35tnfgn; nome>PauloMau; ativo>0; Alterado: ativo>1;

Uma vez que termine a leitura do arquivo XML, o mesmo deverá ser renomeado para:

“exporte-alunos-20161207-1749.xml”, veja que a numeração é a data e hora que falei para guardar.

Pegue o segundo arquivo “exporte-alunos-02.xml”, copie para dentro da pasta Data e renomei para “exporte-alunos.xml”

Execute o programa novamente.

No final, deverá haver dois arquivos XML dentro da pasta Data, renomeados com as datas da execução. E deverá haver dois outros arquivos texto de log, cada um correspondente a um arquivo XML. 

Requerido:

Programação Orientada a Objetos. Em Program e Main, só deverá ter as chamadas necessárias, a exemplo das demonstrações do System.Io que deixei no Moodle.

Indentação de código.

Realizar cada uma das tarefas solicitadas. 
