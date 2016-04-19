# Numeric Library

[![Build status](https://ci.appveyor.com/api/projects/status/8htd22iv2jlxoqrr?svg=true)](https://ci.appveyor.com/project/shederman/numeric)

The Palantir Numeric Library consists of a set of useful types for performing various types of complex, primarily financial, calculations.

## Units of Measure

A unit of measure is a value combined with a named unit, for example, ```100 kg```.

### Unit

Units are the "types" of a measure. Units consist of:

* An abbreviation (e.g. "kg")
* An optional name (e.g. "Kilogram")
* Zero or more *conversions*

A conversion relates one unit to another, along with a scaling factor, which is simply a lambda function.

#### Unit Example

Create ```kilogram``` and ```gram``` units, and add a conversion from kilograms to grams.

~~~csharp
var kg = new Unit("kg");
var g = new Unit("g");

kg.AddConversion(g, x => x * 1000);
~~~

### Measure

A measure is the unification of a value and the unit, in essence the value type.

A measure contains:

* A value
* A reference to the ```Unit```

#### Measure Example

Create a measure of ```100 kg```.

~~~csharp
var kg = new Unit("kg");
var weight = new Measure(110, kg);
~~~

### Unit Calculations

Arithmetic operations can be performed between measures that share a ```Unit```. If not, a conversion will be looked for that converts from the one ```Unit``` to the other, and then the calculationwill be performed.

### Unit Example Requirement

Create a measure of ```100 kg``` and add a measure of ```500 g```.

~~~csharp
var kg = new Unit("kg");
var g = new Unit("g");
kg.AddConversion(g, x => x * 1000);

var weight1 = new Measure(100, kg);
var weight2 = new Measure(500, g);

var result = weight1 + weight2; // 100500 g
~~~

## Money & Currency

```Money``` is quite similar to a Unit of Measure in many respects, with ```Currency``` taking the place of ```Unit```. However, unlike a unit of measure a ```Currency``` can also have a ```Minor Unit``` which defines the smallest allowable denomination in the ```Money``` instance.

### Currency

Currency is the "type" of Money transactions, and is similar to Units. Currencies consist of:

* A Code, e.g. "USD"
* A Symbol, e.g. "$"
* A Minor Unit, e.g. "0.01"

### Money

```Money``` contains the value of Money transactions, and is similar to Measures. Money consists of:

* An Amount, e.g. "1000"
* A ```Currency``` type
* A Minor Unit, e.g. "0.01", which is normally derived from the ```Currency```.

### Money Calculations

Arithmetic operations can be performed between money that shares a ```Currency```. Unlike Units of Measure, no mechanism for performing conversions is built directly into the library.

This is deliberate, currency conversions change rapidly, and require external data, and thus don't lend themselves well to a library of standard conversions.

Some operations on Money types return a ```MoneyQuotient``` type, because it's not possible for a ```Money``` type to have a value that can't be expressed in it's ```MinorUnit```. The ```MoneyQuotient``` type cannot be operated on like a ```Money``` type. However, it can be rounded to a ```Money``` by using the ```Round``` functions.

#### Addition Example

Add ```$ 100``` to ```$ 150```.

~~~csharp
var usd = new Currency("USD", "$", 0.01M);

var value1 = new Money(100, usd);
var value2 = new Money(150, usd);

var result = value1 + value2; // $ 250.00
~~~

#### Division Example

Divide ```$ 100.25``` into 2, and round to nickels.

~~~csharp
var value = new Money(100.25M, usd) / 2; // 50.125

var result = Round.RoundUp(value, 0.05M); // $ 50.15
~~~

## Stochastic Values

The library contains the ```Stochastic``` type which contains an arithmetic mean, and a standard deviation. This type is used to represent a random distribution.

These distributions can be added and subtracted from each other. They can be passed into random generators to create the actual values.

Addition and subtraction against normal numeric types change the mean, in effect "pushing" the stochastic range up or down. Multiplication and division against normal numeric types affect the entire scale, moving the stochastic range up and down the same proportion the standard deviation is affected.

Addition and subtraction against stochastic values affect the mean normally, but the standard deviation is affected as the addition or removal of the appropriate variance.

Multiplication and against stochastic values affect both the mean and the standard deviation.

#### Stochastic Example Addition
~~~csharp
var s1 = new Stochastic(2, 0.82);
var s2 = new Stochastic(3.8, 2.5);

var s3 = s1 + s2; // 2±0.82 + 3.8±2.5 == 5.8±2.631
~~~

#### Stochastic Example Multiplication
~~~csharp
var w = new Stochastic(4.52, 0.02);
var x = new Stochastic(2, 0.2);

var z = w * x; // 4.52±0.02 * 2±0.2 ~= 9.04±0.944
~~~

#### Stochastic Example Unit Multiplication
~~~csharp
// Calculate circumference of circle
var x = new StochasticUnit(3.0, 0.2, cm);

var C = 2 * Math.PI * x; // 2π𝑥 == 18.8±1.3cm
~~~



## Formulas [In Progress]

The Palantir Calculation Library supports complex formulas. These can be parsed from text, and rendered for display.

### Formula Parsing

Formulas can be parsed from text. The following conventions are supported:

* Currency symbol before a number, or three digit code after it, e.g. ```$ 50```, or ```50 USD```.
* Units after a number, e.g. ```50 kg```.
* Stochastics can be identified by a σ, or ± symbol, e.g. ```50 σ 2``` or ```50 ± 2```
* A stochastic Money is identified by the stochastic symbol, and the currency, e.g. ```$ 50 ± 2```.
* Similarly with a stochastic Measure, e.g. ```50 kg σ 2```.
* Known mathematical symbols can be indicated with a text representation, e.g. ```[PI]```, or the symbol, e.g. ```π```.
* Sums can be represented by ```Σn=1→4```, or ```SUM(n, 1, 4)```

#### Formular Parse Example

Parse the formula

![x = \frac{x^3}{\pi}](https://github.com/palantirza/Numeric/raw/master/_images/simple_eq.png "Simple Equation")

~~~csharp
Expression formula = Formula.Parse("x = x^3 \ [Pi]");
~~~

#### Black-Scholes pricing formula for call options

~~~
C = SN(d₁)-N(d₂)Ke^(-rt)
d₁ = ln(S/K)+(r+s²/2)t/s·√t
d₂ = d₁-s·√t
~~~

![Black-Scholes pricing formula for call options](http://i.investopedia.com/blackscholes.png)
*From Investopedia*

## Roadmap

* Formula parsing, including Currency and Unit of Measure and Stochastic
* Financial Formulas
* Stochastic numeric types that contain probability distributions of values.
* Stochastic calculations
* Support for Stochasitic UoM and Currency types.
* Parsing of stochastic values (e.g. "$ 5.3σ0.2")
* Formulas to be parsed to Linq Expression Trees.
* Formula renderer which will output MathML representations of the formula.
* Formula calculator which will progressively calculate the terms, step by step starting at the innermost terms, allowing us to capture the exact calculation steps.
* Logging of formula calculator steps.
* Rendering of formula calculator steps, so a MathML output can be given showing the formula, the variables, and each step of the calculation, for users to review calculation steps.