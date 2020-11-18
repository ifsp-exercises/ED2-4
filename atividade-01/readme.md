<img src="http://www.brazilusamagazine.com/wp-content/uploads/2018/06/maior_em_obras-e1529758442917.jpg">

UMA EMPRESA POSSUI EM SEU DEPARTAMENTO COMERCIAL, UMA EQUIPE COMPOSTA POR 10 VENDEDORES.

DENTRO DE UM MESMO MÊS, É FEITO DIARIAMENTE UM REGISTRO DA QUANTIDADE DE VENDAS REALIZADAS POR CADA UM DELES, BEM COMO O VALOR TOTAL DESSAS VENDAS.

UTILIZE O DIAGRAMA DE CLASSES APRESENTADO À SEGUIR PARA DESENVOLVER UMA APLICAÇÃO COM AS OPÇÕES DESCRITAS ABAIXO:


------------------------------------
| Venda                            |
|----------------------------------|
| - qtde: int                      |
| - valor: double                  |
|----------------------------------|
| + valorMedio(): double           |
------------------------------------


------------------------------------------------
| Vendedor                                     |
|----------------------------------------------|
| - id: int                                    |
| - nome: string                               |
| - percComissao: double                       |
| - asVendas: Venda[31]                        |
|----------------------------------------------|
| + registrarVenda(int dia, Venda venda): void |
| + valorVendas(): double                      |
| + valorComissao(): double                    |
------------------------------------------------


------------------------------------------------
| Vendedores                                   |
|----------------------------------------------|
| - osVendedores: Vendedor[]                   |
| - max: int                                   |
| - qtde: int                                  |
|----------------------------------------------|
| + valorVendas(): double                      |
| + valorComissao(): double                    |
------------------------------------------------


OPÇÕES:

0. Sair
1. Cadastrar vendedor (*)
2. Consultar vendedor (**)
3. Excluir vendedor   (***)
4. Registrar venda
5. Listar vendedores  (****)


(*)     - Limitar o quantitativo de vendedores cadastrados (máximo 10).
(**)   - Quando encontrado, deverá ser informado o id, nome, o valor total das vendas, o valor da comissão devida e
           o valor médio das vendas diárias (de cada dia que houve registro de venda).
(***)  - O vendedor só poderá ser excluído enquanto não houver nenhuma venda associada a ele.
(****) - Deverá ser informado, para cada vendedor, o id, nome, valor total das vendas e o valor da comissão devida.
           Ao final da listagem, esses valores deverão ser totalizados.
