#language: pt
Funcionalidade: Login de Usuário
    Como um usuário do sistema
    Quero realizar login
    Para acessar minha conta

@meuteste
Cenário: Login com sucesso usando Mock
    Dado que eu acesso a página de login
    Quando preencher o campo de usuário com "admin@gmail.com" 
    E preencher o campo de senha com "1234567"
    E clicar no botão de entrar
    Então o usuário deverá visualizar na tela a mensagem "Bem-vindo, Admin!"
    E o log do servidor deverá retornar com uma resposta HTTP 200
