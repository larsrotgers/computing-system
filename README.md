# Computing System
This is a C# implementation of the book The Elements of Computing Systems by Noam Nisan & Shimon Schocken. Instead of grabbing a soldering iron, all the logic is done with C# implementations of logical gates to simulate it as much as possible.

## Run
Start the .NET core console application in project _CS.Architecture.App_.

## Contents
Below is a list with the current contents of the project.

### Hardware (chips)
#### Gates
1. Nand
2. Not
3. And
4. Or
5. Xor
6. And3
7. And16
8. Not16
9. Or16
10. Or8Way

#### Multiplexers
1. Mux
2. Mux16
3. Mux4Way16
4. Mux8Way16
5. DMux
6. DMux16
7. DMux4Way16
8. DMux8Way16

#### Arithmetic
1. HalfAdder
2. FullAdder
3. Adder16
4. Inc16
5. ALU

#### Sequential
1. Clock
2. DFF
3. Bit
4. Register
5. RAM8
6. RAM64
7. RAM512
8. RAM4K
9. RAM16K
10. PC (16-bit counter)

## Architecture
_WIP_

1. CPU
2. ROM32K
3. Screen
4. Keyboard
5. Memory
6. Computer

## Machine Language
**A-instruction** 

Instruction `@value` causes the computer to store the specified value in the A register.

15 | 14 | 13 | 12 | 11 | 10 | 9 | 8 | 7 | 6 | 5 | 4 | 3 | 2 | 1 | 0
--- | --- | --- | --- | --- | --- | --- | --- | --- | --- | --- | --- | --- | --- | --- | --- 
**0** | x | x | x | x | x | x | x | x | x | x | x | x | x | x | x

Bit `15` indicates the A-instruction. `x` represents the value.

Used for:
- Constants
- Memory manipulation
- Jump instructions

**C-instruction**

Instruction `dest=comp;jump` causes the computer to execute a computation.
- if `dest` is empty, the `=` is omitted.
- if `jump` is empty, the `;` is omitted. 

15 | 14 | 13 | 12 | 11 | 10 | 9 | 8 | 7 | 6 | 5 | 4 | 3 | 2 | 1 | 0
--- | --- | --- | --- | --- | --- | --- | --- | --- | --- | --- | --- | --- | --- | --- | --- 
**1** | 1 | 1 | a | c1 | c2 | c3 | c4 | c5 | c6 | d1 | d2 | d3 | j1 | j2 | j3

Bit `15` indicates the C-instruction. Bit `14` & `13` are not used and left at `1`. 

**Compute**

Computed function is specified by the `a`-bit and six `c`-bits.

comp (a=0) | c1 | c2 | c3 | c4 | c5 | c6 | comp(a=1)
--- | --- | --- | --- | --- | --- | --- | ---
`0` | 1 | 0 | 1 | 0 | 1 | 0 | 
`1` | 1 | 1 | 1 | 1 | 1 | 1 |
`-1` | 1 | 1 | 1 | 0 | 1 | 0 |
`D` | 0 | 0 | 1 | 1 | 0 | 0 |
`A`| 1 | 1 | 0 | 0 | 0 | 0 | `M`
`!D` | 0 | 0 | 1 | 1 | 0 | 1 |
`!A` | 1 | 1 | 0 | 0 | 0 | 1 | `!M`
`-D` | 0 | 0 | 1 | 1 | 1 | 1 |
`-A` | 1 | 1 | 0 | 0 | 1 | 1 | `-M`
`D+1` | 0 | 1 | 1 | 1 | 1 | 1 |
`A+1` | 1 | 1 | 0 | 1 | 1 | 1 | `M+1`
`D-1` | 0 | 0 | 1 | 1 | 1 | 0 | 
`A-1` | 1 | 1 | 0 | 0 | 1 | 0 | `M-1`
`D+A` | 0 | 0 | 0 | 0 | 1 | 0 | `D+M`
`D-A` | 0 | 1 | 0 | 0 | 1 | 1 | `D-M`
`A-D` | 0 | 0 | 0 | 1 | 1 | 1 | `M-D`
`D&A` | 0 | 0 | 0 | 0 | 0 | 0 | `D&M`
`D\|A` | 0 | 1 | 0 | 1 | 0 | 1 | `D\|M`

**Destination**

Stores the computed value.
- `d1` in the A register
- `d2` in the D register
- `d3` in memory

d1 | d2 | d3 | Mnemonic | Destination
--- | --- | --- | --- | ---
0 | 0 | 0 | `null` | Value is not stored
0 | 0 | 1 | `M` | Memory[A] (memory register addressed by A)
0 | 1 | 0 | `D` | D register
0 | 1 | 1 | `MD` | Memory[A] and D register
1 | 0 | 0 | `A` | A register
1 | 0 | 1 | `AM` | A register and Memory[A]
1 | 1 | 0 | `AD` | A register and D register
1 | 1 | 1 | `AMD` |  A register, Memory[A], and D register

**Jump**

Change the PC to jump to another instruction.

j1 (out < 0) | j2 (out = 0) | j3 (out > 0) | Mnemonic | Effect
--- | --- | --- | --- | ---
0 | 0 | 0 | `null` | No jump
0 | 0 | 1 | `JGT` | If `out > 0` jump
0 | 1 | 0 | `JEQ` | If `out = 0` jump
0 | 1 | 1 | `JGE` | If `out >= 0` jump
1 | 0 | 0 | `JLT` | If `out < 0` jump
1 | 0 | 1 | `JNE` | If `out != 0` jump
1 | 1 | 0 | `JLE` | If `out <= ` jump
1 | 1 | 1 | `JMP` | Jump

## Assembler
TBA

## High-Level Language
TBA

## Operating System
TBA
