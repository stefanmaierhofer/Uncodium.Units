# Get started

* How many acres are in a square mile?

```F#
// F# Interactive
> SquareMile / Acre |> float;;
val it : float = 640.0
```
```C#
// C# Interactive
> Print(SquareMile / Acre);
[640]
```
* The difference between a pint in the UK and in the US, in liters?

```F#
// F# Interactive
> 1 * UK.LiquidVolume.Pint - 1 * US.LiquidVolume.UsPint => Liter |> string;;
val it : string = "0.095084777 l"
```
```C#
// C# Interactive
> Print((1 * UK.LiquidVolume.Pint - 1 * US.LiquidVolume.UsPint).ConvertTo(Liter));
[0.095084777 l]
```


