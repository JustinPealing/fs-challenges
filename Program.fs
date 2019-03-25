open System

let canTake (queenx, queeny) (otherx, othery) =
    if queenx = otherx then true
    else if queeny = othery then true
    else if queenx - queeny = otherx - othery then true
    else queenx + queeny = otherx + othery

open Microsoft.VisualStudio.TestTools.UnitTesting

[<TestClass>]
type TestClass() =
    [<TestMethod>]
    member this.CanTakeOnRank() =
        Assert.IsTrue(canTake (1, 1) (1, 5))
        Assert.IsTrue(canTake (2, 1) (2, 5))

    [<TestMethod>]
    member this.CanTakeOnFile() =
        Assert.IsTrue(canTake (1, 1) (5, 1))
        Assert.IsTrue(canTake (2, 1) (2, 1))

    [<TestMethod>]
    member this.CanTakeOnDiaganol() =
        Assert.IsTrue(canTake (1, 1) (3, 3))
        Assert.IsTrue(canTake (3, 1) (1, 3))

    [<TestMethod>]
    member this.CannotTakeWhenInvalid() =
        Assert.IsFalse(canTake (1, 1) (2, 3))
        Assert.IsFalse(canTake (3, 1) (4, 3))

[<EntryPoint>]
let main argv =
    printfn "%s" test
    0
