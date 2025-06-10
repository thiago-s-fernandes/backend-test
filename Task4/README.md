# Palindrome Checker (C#)

Este projeto contém uma função recursiva que verifica se uma **string ou frase** é um **palíndromo** — ou seja, se ela pode ser lida da mesma forma de trás para frente, ignorando maiúsculas, acentos e pontuação.

## Exemplo de uso

```csharp
PalindromeChecker.CheckPalindrome("rotor"); // true
PalindromeChecker.CheckPalindrome("motor"); // false
PalindromeChecker.CheckPalindrome("A man, a plan, a canal: Panama"); // true
```

## Lógica

- **Limpeza da string**: remove espaços e caracteres não alfanuméricos.
- **Transformação**: converte todos os caracteres para minúsculo.
- **Verificação recursiva**: compara os caracteres das extremidades até o centro.

## Complexidade

- **Tempo**: O(n), onde `n` é o tamanho da string após limpeza.
- **Espaço**: O(n), devido à criação de uma nova string "cleaned".

## Como executar

1. Certifique-se de ter o [.NET SDK](https://dotnet.microsoft.com/en-us/download) instalado.
2. Compile e execute:

   ```bash
   dotnet run
   ```
