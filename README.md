# apidigitaldoc-netcore
Desafio Backend - Digitaldoc

#Tecnologias:
    • Asp.net Core 3.1
    • Entity Framework Core
    • SQL Server (Azure)

EndPoints:

Users:

- Listar
http://localhost:5000/v1/users

- Pesquisar por id
http://localhost:5000/v1/users/{id}

- Pesquisar por nome que inicia com ...
http://localhost:5000/v1/users?q={search}

- Pesquisar por id da empresa
http://localhost:5000/v1/users/companies/{id}
__

Companies:

- Listar
http://localhost:5000/v1/companies
__

Roles:

- Listar
http://localhost:5000/v1/roles
__

Documents:

- Listar
http://localhost:5000/v1/documents/

- Listar por id do user
http://localhost:5000/v1/documents/fromuser/{id}


