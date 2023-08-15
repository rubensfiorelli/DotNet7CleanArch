# API Travelnet

Pequeno sistema de venda de Passagens aereas;

Desenvolvida pequena API, porem 99% aderente ao CleanArch, usando alguns conceitos do DDD e principalmente respeitando todos os principios do SOLID.

Não esta completamente implementada no Clean Arch, porque nao estou utilizando Object Values, pelo simples fato da simplicidade da API, acredito que ja estou usando "canhao para matar mosquito", porem isso me ajuda nos meus estudos.

Ferramentas usadas;

Visual Studio 2022
Dot Net 7
MySQL 8
Entity FrameWork 7
Entity Identity
JWT Auth
Angular 15 para o Front

Lembrando que o sistema esta totalmente desacopldo, TODAS as classes do Dominio são seladas e/ou fechadas e protegidas, API e WebUI não tem acesso a camada dedos e todos os mesmos dados tragfegam por DTOs da Camada de aplicação ate poder ser persisto na Base dados e retornados em forma de DTOs para o cliente.
