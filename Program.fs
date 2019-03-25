open System

let canTake (queenx, queeny) (otherx, othery) =
    queenx = otherx || queeny = othery
    || queenx - queeny = otherx - othery
    || queenx + queeny = otherx + othery

let attacking queens =
    let isAttacking q = 
        Seq.exists (canTake q) (Seq.where ((<>) q) queens)
    Seq.where isAttacking queens

open Microsoft.VisualStudio.TestTools.UnitTesting

[<TestClass>]
type CanTakeTests() =
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
        
[<TestClass>]
type AttackingTests() =
    let sequenceEqual a b =
        Seq.fold (&&) true (Seq.zip a b |> Seq.map (fun (aa,bb) -> aa=bb))

    [<TestMethod>]
    member this.EmptyList() =
        let result = attacking []
        Assert.AreEqual(0, Seq.length result)

    [<TestMethod>]
    member this.CannotTake() =
        let result = attacking [(1, 1); (3, 4)]
        Assert.AreEqual(0, Seq.length result)

    [<TestMethod>]
    member this.CanTake() =
        let queens = [(1, 1); (2, 2)]
        sequenceEqual queens (attacking queens) |> Assert.IsTrue

    [<TestMethod>]
    member this.Example() =
        let queens = [(2,1); (4,3); (6,3); (8,4); (3,4); (1,6); (7,7); (5,8)]
        let expected = [(2,1); (4,3); (6,3); (8,4); (3,4); (1,6)]
        sequenceEqual expected (attacking queens) |> Assert.IsTrue

[<EntryPoint>]
let main argv =
    let queens = [(2,1); (4,3); (6,3); (8,4); (3,4); (1,6); (7,7); (5,8)]
    let result = attacking queens |> Seq.toList
    printfn "%A" result
    0
