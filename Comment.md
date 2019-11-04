# Comentário do projeto

Versões utilizadas:
Bootstrap 3.4.1;
Html 5;
C# com .Net framework 4.7.1;
jQuery 3.4.1;
MySql 8.0.18

O projeto foi desenvolvido no Visual Studio, utilizando um WebApplication vazio e desenvolvendo a página web a partir deste ponto.

Primeiramente foi criada uma tabela contendo os dados que deveriam ser passados para o cadastro de documentos,
após cadastrar o primeiro documento, uma nova tabela com todas as informações daqueles documento é gerada, sendo gerada uma nova linha
nesta tabela cada vez que um documento é cadastrado. Ao lado de cada linha com as informações há um botão para selecionar aquele
documento específico, e ao selecionar as informações são passadas ao mesmo campo de cadastro, isolando aquelas informações, e
o usuário tem a opção de atualizar as informações, deletar aquele registro de documento (uma janela aparece perguntando 
se ele tem certeza daquela ação antes), ou limpar o campo de cadastro, que permite novamente cadastrar um novo documento ao invés
de alterar o selecionado.

As informações são guardadas no banco de dados MySql(devido ao prazo curto e minha inexperiência no assunto as informações não
consegui utilizar um servidor online, então as informações estão sendo guardadas no localhost), assim como podem ser recuperadas
para visualização do usuário na página web.