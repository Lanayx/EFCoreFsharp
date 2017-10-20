// Learn more about F# at http://fsharp.org

open System
open Microsoft.EntityFrameworkCore

[<CLIMutable>]
type Product =
    {
        Id: string
        Name: string
    }

type MyContext() =
    inherit DbContext()
    [<DefaultValue>] val mutable products: DbSet<Product>
    member public this.PRODUCTS with get() = this.products
                                and set v = this.products <- v

    override this.OnConfiguring (optionsBuilder: DbContextOptionsBuilder) =
        optionsBuilder.UseNpgsql("abcd") |> ignore


[<EntryPoint>]
let main argv =

    let db = new MyContext()
    let q = query {
        for p in db.PRODUCTS do
        select p.Id
    }
    let x = q.Expression    
    printfn "Hello World from F#!"
    0 // return an integer exit code
