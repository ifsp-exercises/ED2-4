# Locacao

| Nome       | Tipo                   |
| ---------- | ---------------------- |
| id         | int                    |
| liberado   | bool                   |
| dt_saida   | DateTime               |
| dt_retorno | DateTime               |
| itens      | Stack<TipoEquipamento> |

## Métodos

| Assinatura                     | Retorno |
| ------------------------------ | ------- |
| incluir (TipoEquipamento eTip) | void    |
| buscar(string nome)            | void    |
| Equals(object obj)             | bool    |

# Locacoes

|contratos | List<Locacao>|

## Métodos

| Assinatura           | Retorno |
| -------------------- | ------- |
| incluir(Locacao loc) | void    |

# Equipamento

| Nome     | Tipo |
| -------- | ---- |
| id       | int  |
| avariado | bool |
| locado   | bool |

## Métodos

| Assinatura         | Retorno |
| ------------------ | ------- |
| Equals(object obj) | bool    |

# TipoEquipamento

| Nome  | Tipo              |
| ----- | ----------------- |
| id    | int               |
| nome  | string            |
| itens | List<Equipamento> |

## Métodos

| Assinatura              | Retorno     |
| ----------------------- | ----------- |
| incluir(Equipamento eq) | void        |
| buscar(int id)          | Equipamento |
| Equals(object obj)      | bool        |

# Equipamentos

| Nome    | Tipo                  |
| ------- | --------------------- |
| estoque | List<TipoEquipamento> |

## Métodos

| Assinatura                    | Retorno         |
| ----------------------------- | --------------- |
| incluir(TipoEquipamento eTip) | void            |
| buscar(string nome)           | TipoEquipamento |
