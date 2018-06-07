# Calculator
Console calculator implemented in 4 steps:
1. Tokenizer - split input string into array of tokens (digits, operators and braces). 
2. Parser - using visitor pattern parse each token into specific token value (DigitToken, SumToken, etc), checks whether all tokens are valid.
3. Sorter - sort an array of token values into [Reverse Polish Notation](https://en.wikipedia.org/wiki/Reverse_Polish_notation).
4. Gardener - creates an expression tree, checks whether initial string was valid (each operator has exactly 2 operands). The result expression can be calculated by calling a single method Calculate().

## Example
```
//Input string 
11*3-(19+5)/2
```
1. Array of tokens
```
["11", "*", "3", "-", "(", "19", "+", "5", ")", "/", "2"]
```
2. Array of token values
```
[  
    Digit("11"),   
    Multiply("*"),   
    Digit("3"),   
    Substraction("-"),   
    LeftBrace("("),   
    Digit("19"),   
    Sun("+"),   
    Digit("5"),   
    RightBrace(")"),   
    Division("/"),   
    Digit("2")  
]
```
3. Array of token values sorted in RPN
```
[  
    Digit("11"),   
    Digit("3"),   
    Multiply("*"),   
    Digit("19"),   
    Digit("5"),   
    Sun("+"),   
    Digit("2"),  
    Division("/"),   
    Substraction("-")  
]
```
4. Expression tree  
![Expression tree]()
