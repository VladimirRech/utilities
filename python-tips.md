# Python tips
Este documento contém dicas sobre as ações mais comuns em Python

#### Exibindo dados
```python
print('Hello World')
```

#### Definindo métodos
```python
def mathOp(number1, number2, operation = '+'):
    # recebe dois argumentos obrigatórios e um opcional
    
    if operation == '+':
       return number1 + number2
       
    elif operation == '-':
       return number1 - number2
       
    elif operation == '*' or operation == 'x':
       return number1 * number2
       
    elif operation == '/' and number2 > 0:
       return number1 / number2
```

#### Formatação de números
Basta usar a função format().
```Python
valor = 50/3
print("Valor informado {0:1.3f}".format(valor, 3))
```

#### Iteração em listas
```python
myList = ['orange', 'strawberry', 'banana', 'apple']

for i, item in enumerate(myList):
    print((i + 1), item)
```

#### Criando dictionaries
```python
prices = { 'Orange': 4, 'Banana': 3.5, 'Apple': 6, 'Pine Apple': 6.66 }

# Adicionando uma chave
```
