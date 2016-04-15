# Calculation Engine
The Palantir Calculation Library consists of a set of useful types for performing various types of complex, primarily financial, calculations.

## Units of Measure
A unit of measure is a value combined with a named unit, for example, ```100 kg```.

### Unit
Units are the "types" of a measure. Units consist of:

* An abbreviation (e.g. "kg")
* An optional name (e.g. "Kilogram")
* Zero or more *conversions*

A conversion relates one unit to another, along with a scaling factor, which is simply a lambda function.

**Example**

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

**Example**

Create a measure of ```100 kg```.

~~~csharp
var kg = new Unit("kg");
var weight = new Measure(110, kg);
~~~

### Calculations
Arithmetic operations can be performed between measures that share a ```Unit```. If not, a conversion will be looked for that converts from the one ```Unit``` to the other, and then the calculationwill be performed.

**Example**

Create a measure of ```100 kg``` and add a measure of ```500 g```.

~~~csharp
var kg = new Unit("kg");
var g = new Unit("g");
kg.AddConversion(g, x => x * 1000);

var weight1 = new Measure(100, kg);
var weight2 = new Measure(500, g);

var result = weight1 + weight2; // 100500 g
~~~

## Money
```Money``` is quite similar to a Unit of Measure in many respects, with ```Currency``` taking the place of ```Unit```. However, unlike a unit of measure a ```Currency``` can also have a ```Scale``` which defines the number of digits in the ```Money``` instance.

### Currency [In Progress]

Currency is the "type" of Money transactions, and similar to Units. Currencies consist of:

* A Code, e.g. "USD"
* A Symbol, e.g. "$"
* A Scale, e.g. "2"

### Calculations
Arithmetic operations can be performed between money that shares a ```Currency```. Unlike Units of Measure, no mechanism for performing conversions is built directly into the library.

This is deliberate, currency conversions change rapidly, and require external data, and thus don't lend themselves well to a library of standard conversions.

**Example**

Add ```$ 100``` to ```$ 150```.

~~~csharp
var usd = new Currency("USD", "$", 2);

var value1 = new Money(100, usd);
var value2 = new Money(150, usd);

var result = value1 + value2; // $ 250
~~~

## Formulas [In Progress]

The Palantir Calculation Library supports complex formulas. These can be parsed from text, and rendered for display.

**Example**

Parse the formula ![x = \frac{x^3}{\pi}](https://github.com/palantirza/Numeric/raw/master/_images/simple-eq.png "Simple Equation")

~~~csharp
Expression formula = Formula.Parse("x = x^3 \ [Pi]");
~~~

## Roadmap

* Force Currency operations that result in remainders, to return a different type
* Currency rounding
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