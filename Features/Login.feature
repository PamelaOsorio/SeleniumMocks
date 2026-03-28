#language: pt
Funcionalidade: Login de Usuário
    Como um usuário do sistema
    Quero realizar login
    Para acessar minha conta

@meuteste
Cenário: Login com sucesso usando Mock
    Dado que eu acesso a página de login
    Quando eu faço login com "teste@email.com" e "senha123"
    Então o sistema deverá retornar na tela a mensagem "Bem-vindo"