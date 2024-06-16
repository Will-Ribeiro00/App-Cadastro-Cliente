# Sistema de Cadastro de Clientes

Este é um projeto básico desenvolvido para exercitar conceitos de programação. O sistema permite o cadastro, edição, exclusão e exibição de clientes, com as seguintes propriedades:

- **Id**: Identificador único do cliente.
- **Nome**: Nome completo do cliente (obrigatório).
- **Data de Nascimento**: Data de nascimento do cliente no formato dd/mm/yyyy.
- **Telefone**: Número de telefone no formato (12) 12345-6789.
- **Email**: Endereço de email no formato seu.email@odominio.com.
- **Desconto**: Valor de desconto aplicável ao cliente, não pode ser menor que 0 nem maior que 50.
- **Data de Cadastro**: Data e hora em que o cliente foi cadastrado (DateTime.Now).

## Estrutura do Projeto

<img src="../img/ArquiteturaDoProjeto.png">

    
## Funcionalidades

### 1. Cadastrar Cliente
Permite o cadastro de um novo cliente com validações para as propriedades mencionadas.

### 2. Editar Cliente
Permite a edição dos dados de um cliente existente, com validações específicas para cada propriedade.

### 3. Excluir Cliente
Remove um cliente da base de dados.

### 4. Exibir Todos os Clientes
Lista todos os clientes cadastrados no sistema.

## Normas de Validação

- **Nome**: Deve ser informado e não pode ser nulo.
- **Data de Nascimento**: Deve ser fornecida no formato dd/mm/yyyy.
- **Telefone**: Deve estar no formato (12) 12345-6789.
- **Email**: Deve estar no formato seu.email@odominio.com.
- **Desconto**: Deve estar entre 0 e 50.
- **Data de Cadastro**: É automaticamente definida como DateTime.Now no momento do cadastro.

Este projeto foi desenvolvido como exercício para práticas em programação e manipulação de dados. Qualquer dúvida ou sugestão, sinta-se à vontade para entrar em contato!
