<h3 align="center">

<img width="64" alt="IFSP" src="https://avatars0.githubusercontent.com/u/62160025?s=200&v=4" />

Atividade 01

</h3>

# Proposta

Uma empresa possui em seu departamento comercial, uma equipe composta por 10 vendedores.

Dentro de um mesmo mês, é feito diariamente um registro da quantidade de vendas realizadas por cada um deles, bem como o valor total dessas vendas.

Utilize o diagrama de classes apresentado à seguir para desenvolver uma aplicação com as opções descritas abaixo:

# Diagramas

| Venda                              |
| ---------------------------------- |
| - qtde: int                        |
| - valor: double                    |
| ---------------------------------- |
| + valorMedio(): double             |

---

| Vendedor                                     |
| -------------------------------------------- |
| - id: int                                    |
| - nome: string                               |
| - percComissao: double                       |
| - asVendas: Venda[31]                        |
| -----------------------                      |
| + registrarVenda(int dia, Venda venda): void |
| + valorVendas(): double                      |
| + valorComissao(): double                    |

---

| Vendedores                 |
| -------------------------- |
| - osVendedores: Vendedor[] |
| - max: int                 |
| - qtde: int                |
| -----------------------    |
| + valorVendas(): double    |
| + valorComissao(): double  |

---

# OPÇÕES

0. Sair
1. Cadastrar vendedor **1**
2. Consultar vendedor **2**
3. Excluir vendedor **3**
4. Registrar venda
5. Listar vendedores **4**

- **1**: Limitar o quantitativo de vendedores cadastrados (máximo 10).
- **2**: Quando encontrado, deverá ser informado o id, nome, o valor total das vendas, o valor da comissão devida e o valor médio das vendas diárias (de cada dia que houve registro de venda).
- **3**: O vendedor só poderá ser excluído enquanto não houver nenhuma venda associada a ele.
- **4**: Deverá ser informado, para cada vendedor, o id, nome, valor total das vendas e o valor da comissão devida. Ao final da listagem, esses valores deverão ser totalizados.
