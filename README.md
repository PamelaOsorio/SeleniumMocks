
# Projeto de Teste - Selenium
Projeto simples de teste desenvolvido com Selenium (C#), Cucumber(BDD), Docker e Mocks.

## Requisitos:
- SDK .NET: 8.0.x
- IDE: VS Code ou Visual Studio 2022
- Docker: Necessário para rodar o Selenium Grid localmente
- Ferramenta LivingDoc: dotnet tool install --global SpecFlow.Plus.LivingDoc.CLI

## Comando para clonar o projeto
git clone https://github.com/PamelaOsorio/SeleniumMocks.git

## Tecnologias e Frameworks
- Selenium WebDriver: Automação de interface (Browser).
- SpecFlow: Escrita de cenários em Gherkin (BDD).
- WireMock.Net: Mocking de APIs para testes independentes de backend real.
- FluentAssertions: Asserções com bool.

## Comando para Subir o Selenium Grid (Infraestrutura)
- O projeto está configurado para rodar em containers.
docker compose up -d

## Comando para Restaurar Dependências
dotnet restore

## Comando para Executar os Testes
dotnet test

## Comando para Gerar Relatório LivingDoc
dotnet livingdoc test-assembly bin/Debug/net8.0/ProjetoSeleniumMock.dll -t TestExecution.json

## Suíte de Cenários (BDD):
Os cenários estão escritos em linguagem onipresente (.feature):
- Cenário: Login com sucesso
- Ação do Usuário: Preencher usuário/senha e clicar em Entrar
- Validação de UI: Verificar redirecionamento ou mensagem de sucesso no HTML
- Mock (API): Resposta HTTP 200 OK (HTML/JSON padrão:)

## CI/CD (GitHub Actions)
- Este projeto possui uma esteira de integração contínua que:
- Sobe o Selenium Grid via Docker no Runner.
- Executa o WireMock internamente durante os testes.
- Roda os testes do SpecFlow.
- Gera e faz upload do LivingDoc.html como artefato da build.

## Resultado do teste rodando
<img width="792" height="629" alt="image" src="https://github.com/user-attachments/assets/ffc58a08-57e2-4c62-95a5-7a8d5d4b75fa" />








<img width="851" height="663" alt="image" src="https://github.com/user-attachments/assets/a5073f8c-fbb2-4b8f-9633-
