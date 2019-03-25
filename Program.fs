open System

let test =
    "Hello world"

open Microsoft.VisualStudio.TestTools.UnitTesting

[<TestClass>]
type TestClass() =
    [<TestMethod>]
    member this.TestMethodPassing() =
        Assert.AreEqual(test, "Hello world")

[<EntryPoint>]
let main argv =
    printfn "%s" test
    0
